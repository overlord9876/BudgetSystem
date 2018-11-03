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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace BudgetSystem.WorkSpace
{
    public partial class frmMyFlowListQuery : frmBaseQueryForm
    {
        private GridHitInfo hInfo;
        FlowManager manager = new FlowManager();
        public frmMyFlowListQuery()
        {
            InitializeComponent();
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Confirm));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));
            this.ModelOperatePageName = "我发起的流程";
        }


        public override void OperateHandled(ModelOperate operate)
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
        }

        private void gvFlow_MouseDown(object sender, MouseEventArgs e)
        {
            hInfo = this.gvFlow.CalcHitInfo(e.Y, e.Y);
        }

        private void gvFlow_DoubleClick(object sender, EventArgs e)
        {
            if (hInfo.InRow)
            {
                ConfirmFlowItem();
            }
        }


    }
}