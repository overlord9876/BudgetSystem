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
    public partial class frmInvoiceQuery : frmBaseQueryFormWithCondtion
    {
        public frmInvoiceQuery()
        {
            InitializeComponent();
            this.CanRefreshData = false;
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New, "新增付款凭证"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify, "修改付款凭证"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Delete, "删除付款凭证"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View, "查看付款凭证"));

            this.ModelOperatePageName = "付款凭证管理";
        }

        public override void RefreshData()
        {
            XtraMessageBox.Show(this.Text);
        }


        public override void OperateHandled(ModelOperate operate)
        {

            if (operate.Operate == OperateTypes.New.ToString())
            {
                frmVoucherNotesEdit form = new frmVoucherNotesEdit();
                form.ShowDialog(this);
                XtraMessageBox.Show("新增付款凭证（开票）");
            }
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                frmVoucherNotesEdit form = new frmVoucherNotesEdit();
                form.ShowDialog(this);
                XtraMessageBox.Show("修改付款凭证（发票）");
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                frmVoucherNotesEdit form = new frmVoucherNotesEdit();
                form.ShowDialog(this);
                XtraMessageBox.Show("查看付款凭证（发票）");
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
