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

namespace BudgetSystem.WorkSpace
{
    public partial class frmApprovalListQuery : frmBaseQueryForm
    {


        FlowManager manager = new FlowManager();
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
            if (!CheckBatchApproveItems(selectItems,out info))
            {
                XtraMessageBox.Show(info);
                return;
            }

            frmApproveEx form = new frmApproveEx() { BatchFlowItems = selectItems, WorkModel = EditFormWorkModels.Custom, CustomWorkModel = frmApproveEx.BatchApproveModel };

            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.RefreshData();
            }



            

        
        
        }




        private List<FlowItem> GetSelectedFlowItem()
        {
            List<FlowItem> items = new List<FlowItem>();

            foreach (int i in this.gvPendingFlow.GetSelectedRows())
            {
                FlowItem item= this.gvPendingFlow.GetRow(i) as FlowItem;

                if (item != null)
                {
                    items.Add(item);
                }
            }

            return items;
        }


        private bool CheckBatchApproveItems(List<FlowItem> items,out string error)
        {
            if (items.Count == 0)
            {
                error = "请选中要审批的数据项！";
                return false; ;
            }

            string baseFlowName = items[0].FlowName;

            foreach (FlowItem item in items)
            {
                if (item.FlowName != baseFlowName)
                {
                    error = "选中数据项来自于多个不同的流程，不可以进行批量审批，请重新选择！";
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