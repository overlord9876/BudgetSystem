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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BudgetSystem.Entity.QueryCondition;
using BudgetSystem.OutMoney;

namespace BudgetSystem.WorkSpace
{
    public partial class frmMyApprovalFlowListQuery : frmBaseQueryForm
    {

        private const string COMMONQUERY_DAY = "当天";
        private const string COMMONQUERY_WEEK = "一周内";
        private const string COMMONQUERY_MONTH = "一月内";
        private const string COMMONQUERY_YEAR = "一年内";
        private const string COMMONQUERY_ALL = "所有我审批的单子";

        private FlowManager manager = new FlowManager();
        private CommonManager commonManager = new CommonManager();

        public frmMyApprovalFlowListQuery()
        {
            InitializeComponent();
            this.Module = BusinessModules.MyApprovalFlowManagement;
            this.gvFlow.ExpandAllGroups();
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ConfirmOrRevoke, "撤回付款审批"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Print));

            this.RegeditQueryOperate<ApprovalFlowQueryCondition>(true, new List<string>
                                                                            { COMMONQUERY_DAY,
                                                                              COMMONQUERY_WEEK,
                                                                              COMMONQUERY_MONTH,
                                                                              COMMONQUERY_YEAR,
                                                                              COMMONQUERY_ALL}, "审批的单子查询");
            this.ModelOperatePageName = "我审批的流程";
        }

        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {
            base.OperateHandled(operate, e);
            if (operate.Operate == OperateTypes.ConfirmOrRevoke.ToString())
            {
                ConfirmOrRevokeFlowData();
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                ViewFlowData();
            }
            else if (operate.Operate == OperateTypes.Print.ToString())
            {
                PrintRowItem();
            }
        }

        private void ViewFlowData()
        {
            if (this.gvFlow.FocusedRowHandle >= 0)
            {
                FlowItem item = this.gvFlow.GetRow(this.gvFlow.FocusedRowHandle) as FlowItem;
                if (item != null)
                {
                    frmApproveEx form = new frmApproveEx() { FlowItem = item, WorkModel = EditFormWorkModels.Custom, CustomWorkModel = frmApproveEx.ViewModel };

                    if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        this.RefreshData();
                    }
                }
            }
        }

        private void PrintRowItem()
        {
            if (this.gvFlow.SelectedRowsCount > 0)
            {
                foreach (var rowIndex in this.gvFlow.GetSelectedRows())
                {
                    FlowItem item = this.gvFlow.GetRow(rowIndex) as FlowItem;
                    if (item != null)
                    {
                        if (item.DateItemType == EnumFlowDataType.付款单.ToString())
                        {
                            PaymentNotesManager pnm = new PaymentNotesManager();
                            var currentItem = pnm.GetPaymentNoteById(item.DateItemID);
                            if (currentItem != null)
                            {
                                frmOutMoneyPrint form = new frmOutMoneyPrint();
                                form.WorkModel = EditFormWorkModels.View;
                                form.CurrentPaymentNotes = currentItem;
                                form.PrintItem();
                            }
                        }
                    }
                }
            }
        }

        private void ConfirmOrRevokeFlowData()
        {
            if (this.gvFlow.FocusedRowHandle >= 0)
            {
                FlowItem item = this.gvFlow.GetRow(this.gvFlow.FocusedRowHandle) as FlowItem;
                if (item == null)
                {
                    return;
                }
                if (!EnumFlowDataType.付款单.ToString().Equals(item.DateItemType) || !EnumFlowNames.付款审批流程.ToString().Equals(item.FlowName))
                {
                    XtraMessageBox.Show(string.Format("只允许{0}才能撤回自己审批的单子。", EnumFlowNames.付款审批流程));
                    return;
                }
                if (XtraMessageBox.Show("确认撤回审批的付款单？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    FlowRunState state = manager.RevokePaymentFlow(item.ID, RunInfo.Instance.CurrentUser.UserName, true);
                    MessageBox.Show(state.ToString());
                    if (state == FlowRunState.撤回成功)
                    {
                        this.gvFlow.DeleteRow(this.gvFlow.FocusedRowHandle);
                    }
                }
            }
        }

        protected override void DoCommonQuery(string queryName)
        {

            DateTime datetime = commonManager.GetDateTimeNow();
            ApprovalFlowQueryCondition condition = new ApprovalFlowQueryCondition() { CurrentUer = RunInfo.Instance.CurrentUser.UserName };
            if (COMMONQUERY_DAY.Equals(queryName))
            {
                condition.BeginTimestamp = new DateTime(datetime.Year, datetime.Month, datetime.Day);
                condition.EndTimestamp = condition.BeginTimestamp.AddDays(1);
                LoadData(condition);
            }
            else if (COMMONQUERY_WEEK.Equals(queryName))
            {
                condition.BeginTimestamp = datetime.AddDays(-7);
                condition.EndTimestamp = datetime.AddDays(1);
                LoadData(condition);
            }
            else if (COMMONQUERY_MONTH.Equals(queryName))
            {
                condition.BeginTimestamp = datetime.AddMonths(-1);
                condition.EndTimestamp = datetime.AddDays(1);
                LoadData(condition);
            }
            else if (COMMONQUERY_YEAR.Equals(queryName))
            {
                condition.BeginTimestamp = datetime.AddYears(-1);
                condition.EndTimestamp = datetime.AddDays(1);
                LoadData(condition);
            }
            else if (COMMONQUERY_ALL.Equals(queryName))
            {
                LoadData(condition);
            }
        }

        protected override void DoConditionQuery(BaseQueryCondition condition)
        {
            this.LoadData((ApprovalFlowQueryCondition)condition);
        }

        protected override QueryConditionEditorForm CreateConditionEditorForm()
        {
            frmApprovalFlowQueryConditionEditor form = new frmApprovalFlowQueryConditionEditor();
            form.QueryName = this.GetType().ToString();
            return form;
        }

        private void LoadData(ApprovalFlowQueryCondition condition)
        {
            if (condition == null)
            {
                condition = new ApprovalFlowQueryCondition();
            }
            condition.CurrentUer = RunInfo.Instance.CurrentUser.UserName;
            var lst = manager.GetAprrovalFlowByCondition(condition);
            lst.ForEach(FlowApproveDisplayHelper.SetFlowItemInstanceStateWithEmptyStateDisplayName);
            this.gdFlow.DataSource = lst;

            this.gvFlow.ExpandAllGroups();
        }

        public override void LoadData()
        {
            DoCommonQuery(COMMONQUERY_DAY);
        }

        public override void RefreshData()
        {
            DoCommonQuery(COMMONQUERY_DAY);
        }

        protected override void InitGridViewAction()
        {
            this.gridViewAction.Add(this.gvFlow, new ActionWithPermission() { MainAction = this.ViewFlowData, MainOperate = OperateTypes.View });

        }

    }

}