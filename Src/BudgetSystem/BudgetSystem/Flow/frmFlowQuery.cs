using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BudgetSystem
{
    public partial class frmFlowQuery : frmBaseQueryForm
    {
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
                frmFlowEdit form = new frmFlowEdit() { WorkModel = EditFormWorkModels.New };
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                frmFlowEdit form = new frmFlowEdit() {  WorkModel= EditFormWorkModels.View};
                form.ShowDialog(this);
            }
        }


        public override void LoadData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("Editor", typeof(string));
            dt.Columns.Add("EditTime", typeof(DateTime));

            dt.Rows.Add("预算审批流程", "预算审批流程", "XX", DateTime.Now);
            dt.Rows.Add("附款审批流程", "附款审批流程", "XX", DateTime.Now);
            this.gridControl1.DataSource = dt;
        }

    }
}
