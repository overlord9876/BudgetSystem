using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BudgetSystem.Bll;
using BudgetSystem.Entity;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace BudgetSystem.FlowManage
{
    public partial class frmFlowQuery : frmBaseQueryForm
    {
        private GridHitInfo hInfo;
        FlowManager manager = new FlowManager();

        public frmFlowQuery()
        {
            InitializeComponent();
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));
            this.ModelOperatePageName = "流程管理";
        }


        public override void OperateHandled(ModelOperate operate)
        {
            if (operate.Operate == OperateTypes.Modify.ToString())
            {
                ModifyFlow();
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                ViewFlow();
            }
        }

       

        private void ModifyFlow()
        {
            Flow currentRowFlow = this.gvFlow.GetFocusedRow() as Flow;
            frmFlowEdit form = new frmFlowEdit() { WorkModel = EditFormWorkModels.Modify, Flow = currentRowFlow };
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.RefreshData();
            }
        }

        private void ViewFlow()
        {
            Flow currentRowFlow = this.gvFlow.GetFocusedRow() as Flow;
            frmFlowEdit form = new frmFlowEdit() { WorkModel = EditFormWorkModels.View, Flow = currentRowFlow };
            form.ShowDialog(this);
        }

        public override void LoadData()
        {
            List<Flow> flows = manager.GetAllEnabledFlow();
            this.gdFlow.DataSource = flows;
        }

        private void gvFlow_MouseDown(object sender, MouseEventArgs e)
        {
            hInfo = gvFlow.CalcHitInfo(e.Y, e.Y);
        }

        private void gvFlow_DoubleClick(object sender, EventArgs e)
        {
            if (hInfo.InRow)
            {
                ModifyFlow();
            }
        }




    }
}
