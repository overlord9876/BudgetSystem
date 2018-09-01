using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BudgetSystem
{
    public partial class frmSupplierQuery : frmBaseQueryForm
    {
        public frmSupplierQuery()
        {
            InitializeComponent();
        }

        public override void RefreshData()
        {
            LoadData();
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Enabled));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Disabled));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));
            this.ModelOperatePageName = "供应商管理";
        }


        public override void OperateHandled(ModelOperate operate)
        {

            if (operate.Operate == OperateTypes.Modify.ToString())
            {
                frmFlowEdit form = new frmFlowEdit() { WorkModel = EditFormWorkModels.New };
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                frmFlowEdit form = new frmFlowEdit() {  WorkModel= EditFormWorkModels.View};
                form.ShowDialog(this);
            }
        }


        private void LoadData()
        {
           
        }

        private void frmFlowQuery_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
