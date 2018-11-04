using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;

namespace BudgetSystem
{
    public partial class frmVoucherNotesQuery : frmBaseQueryFormWithCondtion
    {
        public frmVoucherNotesQuery()
        {
            InitializeComponent();
            this.CanRefreshData = false;
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();

            //this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New, "新增付款凭证"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ImportData, "导入付款凭证"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Delete, "删除付款凭证"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View, "查看付款凭证"));

            this.ModelOperatePageName = "付款凭证管理";
        }

        public override void RefreshData()
        {
            //            BudNo
            //InvoiceNo
            //InvoiceDate
            //Payment
            //CreateUser
            //CtreateDate
            //Description
            DataTable dt = new DataTable();
            dt.Columns.Add("BudNo", typeof(string));
            dt.Columns.Add("InvoiceNo", typeof(string));
            dt.Columns.Add("InvoiceDate", typeof(DateTime));
            dt.Columns.Add("Payment", typeof(string));
            dt.Columns.Add("CreateUser", typeof(string));
            dt.Columns.Add("CtreateDate", typeof(DateTime));
            dt.Columns.Add("Description", typeof(string));

            dt.Rows.Add("18G-002-001", "201809130923123313231", DateTime.Now, "24255000.00", "张三", DateTime.Now, "");
            dt.Rows.Add("18G-002-002", "201809130923123313875", DateTime.Now, "24255000.00", "张三", DateTime.Now, "");
            dt.Rows.Add("18G-002-003", "201809130923123313980", DateTime.Now, "24255000.00", "张三", DateTime.Now, "");

            this.gridControl1.DataSource = dt;
        }


        public override void OperateHandled(ModelOperate operate)
        {

            if (operate.Operate == OperateTypes.ImportData.ToString())
            {
                XtraMessageBox.Show("导入付款凭证");
            }
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                frmVoucherNotesEdit form = new frmVoucherNotesEdit();
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                frmVoucherNotesEdit form = new frmVoucherNotesEdit();
                form.ShowDialog(this);
            }
            else if (operate.Operate == "Test1")
            {
                XtraMessageBox.Show("Test1");
            }
            else
            {
                XtraMessageBox.Show("未定义的操作1");
            }
        }
    }
}
