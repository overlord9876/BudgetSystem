﻿using System;
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

            this.gdPendingFlow.DataSource = list;
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Approve, "审批"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));
            this.ModelOperatePageName = "我的待审批流程";
        }


        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {
            if (operate.Operate == OperateTypes.Approve.ToString())
            {

                AproveFlowItem();

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
                    frmApprove form = new frmApprove() { FlowItem = item, WorkModel = EditFormWorkModels.Custom, CustomWorkModel = frmApprove.ApproveViewModel };
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
                    frmApprove form = new frmApprove() { FlowItem = item, WorkModel = EditFormWorkModels.Custom, CustomWorkModel = frmApprove.ApproveModel };
                    if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        this.RefreshData();
                    }
                }
            }
            
        }


        protected override void InitGridViewAction()
        {
            this.gridViewAction.Add(this.gvPendingFlow, new ActionWithPermission() { MainAction = AproveFlowItem, MainOperate = OperateTypes.Approve, SecondAction = ViewFlowItem, SecondOperate = OperateTypes.View });

        }



    }
}