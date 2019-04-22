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

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ConfirmOrRevoke));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));
            this.ModelOperatePageName = "我发起的流程";
        }

        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {
            if (operate.Operate == OperateTypes.ConfirmOrRevoke.ToString())
            {

                ConfirmOrRevokeFlowData();

            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                ViewFlowData();
              //  ViewFlowItem();
            }
        }

        private void ViewFlowData()
        {
            if (this.gvFlow.FocusedRowHandle >= 0)
            {
                FlowItem item = this.gvFlow.GetFocusedRow() as FlowItem;
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

        private void ConfirmOrRevokeFlowData()
        {
            if (this.gvFlow.FocusedRowHandle >= 0)
            {
                FlowItem item = this.gvFlow.GetFocusedRow() as FlowItem;
                if (item != null)
                {
                    frmApproveEx form = new frmApproveEx() { FlowItem = item, WorkModel = EditFormWorkModels.Custom, CustomWorkModel = frmApproveEx.ConfirmOrRevokeModel };
                
                    if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        this.RefreshData();
                    }
                }
            }
        }

        //private void ViewFlowItem()
        //{
        //    if (this.gvFlow.FocusedRowHandle >= 0)
        //    {
        //        FlowItem item = this.gvFlow.GetFocusedRow() as FlowItem;
        //        if (item != null)
        //        {
        //            frmApprove form = new frmApprove() { FlowItem = item, WorkModel = EditFormWorkModels.Custom, CustomWorkModel = frmApprove.ConfirmViewModel };
        //            form.ShowDialog(this);
        //        }
        //    }


        //}

        //private void ConfirmFlowItem()
        //{
        //    if (this.gvFlow.FocusedRowHandle >= 0)
        //    {
        //        FlowItem item = this.gvFlow.GetFocusedRow() as FlowItem;
        //        if (item != null)
        //        {
        //            frmApprove form = new frmApprove() { FlowItem = item, WorkModel = EditFormWorkModels.Custom, CustomWorkModel = frmApprove.ConfirmModel };
        //            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
        //            {
        //                this.RefreshData();
        //            }
        //        }
        //    }
        //}

        //private void RevokeFlowItem()
        //{
        //    if (this.gvFlow.FocusedRowHandle >= 0)
        //    {
        //        FlowItem item = this.gvFlow.GetFocusedRow() as FlowItem;
        //        if (item != null)
        //        {
        //            frmApprove form = new frmApprove() { FlowItem = item, WorkModel = EditFormWorkModels.Custom, CustomWorkModel = frmApprove.RevokeModel };
        //            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
        //            {
        //                this.RefreshData();
        //            }
        //        }
        //    }
        //}

        public override void RefreshData()
        {
            var lst = manager.GetUnConfirmFlowByUser(RunInfo.Instance.CurrentUser.UserName);
            lst.ForEach(FlowApproveDisplayHelper.SetFlowItemInstanceStateWithEmptyStateDisplayName);
            this.gdFlow.DataSource = lst;
            
            this.gvFlow.ExpandAllGroups();
        }

        protected override void InitGridViewAction()
        {
            this.gridViewAction.Add(this.gvFlow, new ActionWithPermission() { MainAction = this.ConfirmOrRevokeFlowData, MainOperate = OperateTypes.Confirm, SecondAction = this.ViewFlowData, SecondOperate = OperateTypes.View });

        }

    }
}