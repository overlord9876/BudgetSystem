using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Bll;
using System.Linq;
using BudgetSystem.Entity;
using BudgetSystem.WorkSpace;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using BudgetSystem.OutMoney;

namespace BudgetSystem.WorkSpace
{
    public partial class frmApprovalListQuery : frmBaseQueryForm
    {


        FlowManager manager = new FlowManager();
        PaymentNotesManager pnm = new PaymentNotesManager();
        public frmApprovalListQuery()
        {
            InitializeComponent();
            this.Module = BusinessModules.MyPendingFlowManagement;
        }

        public override void RefreshData()
        {
            var list = manager.GetPendingFlowByUser(RunInfo.Instance.CurrentUser.UserName);

            list.ForEach(FlowApproveDisplayHelper.SetFlowItemInstanceStateWithEmptyStateDisplayName);

            this.gdPendingFlow.DataSource = list;
            this.gvPendingFlow.ExpandAllGroups();
        }


        protected override void InitModelOperate()
        {
            base.InitModelOperate();

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Approve, "审批"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Print, "打印付款"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.BatchApprove, "批量审批"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));
            this.ModelOperatePageName = "我的待审批流程";
        }


        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {
            if (operate.Operate == OperateTypes.Approve.ToString())
            {
                AproveFlowItem();
            }
            else if (operate.Operate == OperateTypes.BatchApprove.ToString())
            {
                AproveBatch();
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                ViewFlowItem();
            }
            else if (operate.Operate == OperateTypes.Print.ToString())
            {
                PrintAndSure();
            }
        }

        private void PrintAndSure()
        {
            if (this.gvPendingFlow.FocusedRowHandle >= 0)
            {
                int[] rowIndexList = this.gvPendingFlow.GetSelectedRows();
                Dictionary<int, FlowItem> flowItems = new Dictionary<int, FlowItem>();
                for (int index = rowIndexList.Length - 1; index >= 0; index--)
                {
                    int rowIndex = rowIndexList[index];
                    FlowItem item = this.gvPendingFlow.GetRow(rowIndex) as FlowItem;
                    if (item != null)
                    {
                        if (item.DateItemType != EnumFlowDataType.付款单.ToString())
                        {
                            XtraMessageBox.Show(string.Format("当前{0}审批流程不属于付款单类型，不允许直接打印通过审批", item.DateItemText));
                            break;
                        }
                        flowItems.Add(rowIndex, item);
                    }
                }
                if (flowItems.Count > 0)
                {
                    PaymentNotesManager pnm = new PaymentNotesManager();
                    foreach (int rowIndex in flowItems.Keys)
                    {
                        FlowItem item = flowItems[rowIndex];
                        PaymentNotes currentItem = pnm.GetPaymentNoteById(item.DateItemID);
                        if (currentItem == null)
                        {
                            XtraMessageBox.Show("当前数据已经不存在。");
                            return;
                        }
                        FlowRunState state = pnm.Payemenent(currentItem, item.RunPointID);
                        string info;
                        if (state.Translate(out info))
                        {
                            frmOutMoneyPrint form = new frmOutMoneyPrint();
                            form.WorkModel = EditFormWorkModels.View;
                            form.CurrentPaymentNotes = currentItem;
                            form.PrintItem();
                            this.gvPendingFlow.DeleteRow(rowIndex);
                        }
                        else
                        {
                            XtraMessageBox.Show(info);
                        }
                    }
                }

            }
        }

        private void ViewFlowItem()
        {
            if (this.gvPendingFlow.FocusedRowHandle >= 0)
            {
                FlowItem item = this.gvPendingFlow.GetFocusedRow() as FlowItem;
                if (item != null)
                {
                    frmApproveEx form = new frmApproveEx() { FlowItem = item, WorkModel = EditFormWorkModels.Custom, CustomWorkModel = frmApproveEx.ViewModel };

                    form.ShowDialog(this);
                }

            }
        }
        private void AproveFlowItem()
        {
            if (this.gvPendingFlow.FocusedRowHandle >= 0)
            {
                FlowItem item = this.gvPendingFlow.GetFocusedRow() as FlowItem;
                if (item != null)
                {
                    frmApproveEx form = new frmApproveEx() { FlowItem = item, WorkModel = EditFormWorkModels.Custom, CustomWorkModel = frmApproveEx.ApproveModel };

                    if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        this.RefreshData();
                    }
                }
            }
        }

        private void AproveBatch()
        {

            List<FlowItem> selectItems = GetSelectedFlowItem();

            string info;
            if (!CheckBatchApproveItems(selectItems, out info))
            {
                XtraMessageBox.Show(info);
                return;
            }

            frmApproveEx form = new frmApproveEx() { BatchFlowItems = selectItems, WorkModel = EditFormWorkModels.Custom, CustomWorkModel = frmApproveEx.BatchApproveModel };

            form.ShowDialog(this);
            {
                this.RefreshData();
            }
        }


        private List<FlowItem> GetSelectedFlowItem()
        {
            List<FlowItem> items = new List<FlowItem>();
            int[] selectRows = this.gvPendingFlow.GetSelectedRows();
            foreach (int i in selectRows)
            {
                if (i >= 0)
                {
                    FlowItem item = this.gvPendingFlow.GetRow(i) as FlowItem;

                    if (item != null)
                    {
                        items.Add(item);
                    }
                }
                else
                {
                    items.AddRange(GetGroupedRow(i, this.gvPendingFlow));
                }
            }

            return items;
        }


        private List<FlowItem> GetGroupedRow(int groupIndex, GridView view)
        {
            int groupedRowCount = view.GetChildRowCount(groupIndex);
            List<FlowItem> result = new List<FlowItem>();
            for (int i = 0; i < groupedRowCount; i++)
            {
                int crow = view.GetChildRowHandle(groupIndex, i);
                FlowItem p = view.GetRow(crow) as FlowItem;
                result.Add(p);
            }
            return result;


        }

        private bool CheckBatchApproveItems(List<FlowItem> items, out string error)
        {
            if (items.Count == 0)
            {
                error = "请选中要审批的数据项！";
                return false; ;
            }

            string baseFlowName = items[0].FlowName;
            int baseFlowVersion = items[0].FlowVersionNumber;
            int baseNodeID = items[0].NodeID;


            foreach (FlowItem item in items)
            {
                if (item.FlowName != baseFlowName)
                {
                    error = "选中数据项来自于多个不同的流程，不可以进行批量审批，请重新选择！";
                    return false;
                }

                if (item.FlowVersionNumber != baseFlowVersion)
                {
                    error = "选中数据项来源自不同的流程图版本，不可以进行批量审批，请重新选择！";
                    return false;
                }


                if (item.NodeID != baseNodeID)
                {
                    error = "选中数据项处于不同的流程节点，不可以进行批量审批，请重新选择！";
                    return false;
                }
            }
            error = "";
            return true;
        }

        protected override void InitGridViewAction()
        {
            this.gridViewAction.Add(this.gvPendingFlow, new ActionWithPermission() { MainAction = AproveFlowItem, MainOperate = OperateTypes.Approve, SecondAction = ViewFlowItem, SecondOperate = OperateTypes.View });

        }



    }
}