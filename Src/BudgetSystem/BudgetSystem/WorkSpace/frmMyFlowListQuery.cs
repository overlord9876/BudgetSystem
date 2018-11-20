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

namespace BudgetSystem.WorkSpace
{
    public partial class frmMyFlowListQuery : frmBaseQueryForm
    {

        FlowManager manager = new FlowManager();
        public frmMyFlowListQuery()
        {
            InitializeComponent();
            this.Module = BusinessModules.MySubmitFlowManagement;
            this.gvFlow.ExpandAllGroups();
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Confirm));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));
            this.ModelOperatePageName = "我发起的流程";
        }


        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {



            if (operate.Operate == OperateTypes.Confirm.ToString())
            {

                ConfirmFlowItem();

            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                ViewFlowItem();
            }
        }

        private void ViewFlowItem()
        {
            if (this.gvFlow.FocusedRowHandle >= 0)
            {
                FlowItem item = this.gvFlow.GetFocusedRow() as FlowItem;
                if (item != null)
                {
                    frmApprove form = new frmApprove() { FlowItem = item, WorkModel = EditFormWorkModels.Custom, CustomWorkModel = frmApprove.ConfirmViewModel };
                    form.ShowDialog(this);
                }
            }


        }

        private void ConfirmFlowItem()
        {
            if (this.gvFlow.FocusedRowHandle >= 0)
            {
                FlowItem item = this.gvFlow.GetFocusedRow() as FlowItem;
                if (item != null)
                {
                    frmApprove form = new frmApprove() { FlowItem = item, WorkModel = EditFormWorkModels.Custom, CustomWorkModel = frmApprove.ConfirmModel };
                    if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        this.RefreshData();
                    }
                }
            }
        }



        public override void RefreshData()
        {
            var lst = manager.GetUnConfirmFlowByUser(RunInfo.Instance.CurrentUser.UserName);

            foreach (var i in lst)
            {

                i.InstanceStateWithEmptyState = i.IsClosed ? (i.ApproveResult ? "同意" : "驳回") : "";
            }


            this.gdFlow.DataSource = lst;
            
            this.gvFlow.ExpandAllGroups();
        }

        protected override void InitGridViewAction()
        {
            this.gridViewAction.Add(this.gvFlow, new ActionWithPermission() { MainAction = ConfirmFlowItem, MainOperate = OperateTypes.Confirm, SecondAction = ViewFlowItem, SecondOperate = OperateTypes.View });

        }

    }
}