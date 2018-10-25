using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BudgetSystem
{
    public partial class frmApprovalListQuery : frmBaseQueryForm
    {
        public frmApprovalListQuery()
        {
            InitializeComponent();
        }

        public override void RefreshData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ApprovalType", typeof(string));
            dt.Columns.Add("ApprovalName", typeof(string));
            dt.Columns.Add("Commiter", typeof(string));
            dt.Columns.Add("CommitDate", typeof(DateTime));
            dt.Columns.Add("CreateTime", typeof(DateTime));

            dt.Rows.Add("预算单审批", "XXX流程审批", "张三", DateTime.Now, DateTime.Now);
            dt.Rows.Add("合格供方审批", "XXX流程审批", "张三", DateTime.Now, DateTime.Now);
            dt.Rows.Add("财务付款", "XXX流程审批", "张三", DateTime.Now, DateTime.Now);
            dt.Rows.Add("预算单审批", "XXX流程审批", "张三", DateTime.Now, DateTime.Now);

            this.gridControl1.DataSource = dt;
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Agree, "审批"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));
            this.ModelOperatePageName = "待审流程";
        }


        public override void OperateHandled(ModelOperate operate)
        {

            if (operate.Operate == OperateTypes.Agree.ToString())
            {
                frmApprovalEdit form = new frmApprovalEdit();
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                frmBudgetEdit form = new frmBudgetEdit();
                form.ShowDialog(this);
            }
            else if (operate.Operate == "Test")
            {
                XtraMessageBox.Show("Test");
            }
            else
            {
                XtraMessageBox.Show("未定义的操作");
            }
        }




    }
}