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
    public partial class frmDepartmentQuery : frmBaseQueryForm
    {
        public frmDepartmentQuery()
        {
            InitializeComponent();
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Delete));
            this.ModelOperatePageName = "部门管理";
        }


        public override void OperateHandled(ModelOperate operate)
        {
            if (operate.Operate == OperateTypes.New.ToString())
            {
                frmDepartmentEdit form = new frmDepartmentEdit() { WorkModel = EditFormWorkModels.New };
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                frmDepartmentEdit form = new frmDepartmentEdit() { WorkModel = EditFormWorkModels.Modify };
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                XtraMessageBox.Show("删除");
            }
        }
        public override void LoadData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DepartmentNo", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Manager", typeof(string));
            dt.Columns.Add("DeputyManager", typeof(string));

            dt.Rows.Add("001", "一部", "张三", "李四");
            dt.Rows.Add("002", "二部", "张三", "李四");
            dt.Rows.Add("003", "三部", "张三", "李四");

            this.gridControl3.DataSource = dt;


            DataTable userdt = new DataTable();
            userdt.Columns.Add("Name");
            userdt.Columns.Add("RealName");
            userdt.Columns.Add("Role");
            userdt.Columns.Add("State");

            userdt.Rows.Add("User1", "张三", "业务员", "可用");
            userdt.Rows.Add("User2", "李四", "业务员", "可用");
            this.gridControl1.DataSource = userdt;


            DataTable userdt2 = new DataTable();
            userdt2.Columns.Add("Name");
            userdt2.Columns.Add("RealName");
            userdt2.Columns.Add("Role");
            userdt2.Columns.Add("State");

            userdt2.Rows.Add("User3", "王五", "业务员", "可用");
            userdt2.Rows.Add("User4", "赵六", "业务员", "停用");
            this.gridControl2.DataSource = userdt2;
        }
    }
}
