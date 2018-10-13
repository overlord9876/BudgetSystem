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
    public partial class frmCustomerQuery : frmBaseQueryForm
    {
        public frmCustomerQuery()
        {
            InitializeComponent();
        }

        public override void RefreshData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Country", typeof(string));
            dt.Columns.Add("Seaport", typeof(string));
            dt.Columns.Add("State", typeof(string));
            dt.Columns.Add("CreateUser", typeof(string));
            dt.Columns.Add("CreateDate", typeof(DateTime));

            dt.Rows.Add("CRAFT OF SCANDINAVIA AB", "瑞士", "SWE", "启用", "张三", DateTime.Now);
            dt.Rows.Add("URDI PRY LTD CRAFTSPORTSWEAR NORTH", "瑞士", "SWE", "启用", "李四", DateTime.Now);
            dt.Rows.Add("UNITED BRANDS", "瑞士", "SWE", "启用", "李四", DateTime.Now);

            this.gridControl1.DataSource = dt;
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Enabled));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Disabled));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Relate, "业务员维护"));
            this.ModelOperatePageName = "客户列表";
        }


        public override void OperateHandled(ModelOperate operate)
        {

            if (operate.Operate == OperateTypes.New.ToString())
            {
                frmCustomerEdit form = new frmCustomerEdit();
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                frmCustomerEdit form = new frmCustomerEdit();
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                frmCustomerEdit form = new frmCustomerEdit();
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.Relate.ToString())
            {

            }
            else if (operate.Operate == OperateTypes.Revoke.ToString())
            {
                XtraMessageBox.Show("Revoke");
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