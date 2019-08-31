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
        FlowManager manager = new FlowManager();

        public frmFlowQuery()
        {
            InitializeComponent();
            this.Module = BusinessModules.FlowManagement;
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Confirm, "流程引擎测试"));
            this.ModelOperatePageName = "流程管理";
        }


        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {
            if (operate.Operate == OperateTypes.Modify.ToString())
            {
                ModifyFlow();
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                ViewFlow();
            }
            else if (operate.Operate == OperateTypes.Confirm.ToString())
            {
                TestFlow();
            }
        }

        private void TestFlow()
        {
            string flowName = "预算单审批流程";
            int dataID = 888;
            string dataType = "测试业务数据";
            Bll.FlowManager fm = new FlowManager();
            FlowRunState state = fm.StartFlow(flowName, dataID, "测试用的数据项", dataType, RunInfo.Instance.CurrentUser.UserName, string.Format("发起{0}", flowName));

        }



        private void ModifyFlow()
        {
            Flow currentRowFlow = this.gvFlow.GetFocusedRow() as Flow;
            if (currentRowFlow != null)
            {
                frmFlowEdit form = new frmFlowEdit() { WorkModel = EditFormWorkModels.Modify, Flow = currentRowFlow };
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.RefreshData();
                }
            }
        }

        private void ViewFlow()
        {
            Flow currentRowFlow = this.gvFlow.GetFocusedRow() as Flow;
            if (currentRowFlow != null)
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


        protected override void InitGridViewAction()
        {
            this.gridViewAction.Add(this.gvFlow, new ActionWithPermission() { MainAction = ModifyFlow, MainOperate = OperateTypes.Modify, SecondAction = ViewFlow, SecondOperate = OperateTypes.View });

        }

    }
}
