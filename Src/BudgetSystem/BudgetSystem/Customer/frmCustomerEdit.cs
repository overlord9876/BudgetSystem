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
    public partial class frmCustomerEdit : frmBaseDialogForm
    {
        public frmCustomerEdit()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmCustomerEdit_Load);
        }

        private void frmCustomerEdit_Load(object sender, EventArgs e)
        {


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