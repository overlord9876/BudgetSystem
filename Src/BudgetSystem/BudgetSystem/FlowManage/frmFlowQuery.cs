using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BudgetSystem.Bll;
using BudgetSystem.Entity;

namespace BudgetSystem.FlowManage
{
    public partial class frmFlowQuery : frmBaseQueryForm
    {
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
            Flow currentRowFlow = this.gvFlow.GetFocusedRow() as Flow;

            if (operate.Operate == OperateTypes.Modify.ToString())
            {
             
                frmFlowEdit form = new frmFlowEdit() { WorkModel = EditFormWorkModels.Modify , Flow = currentRowFlow };
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.RefreshData();
                }
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                frmFlowEdit form = new frmFlowEdit() { WorkModel = EditFormWorkModels.View, Flow = currentRowFlow };
                form.ShowDialog(this);
            }
        }


        public override void LoadData()
        {
            List<Flow> flows = manager.GetAllEnabledFlow();
            this.gdFlow.DataSource = flows;
        }

    }
}
