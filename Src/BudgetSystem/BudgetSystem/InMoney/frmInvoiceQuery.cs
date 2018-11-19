using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace BudgetSystem.InMoney
{
    public partial class frmInvoiceQuery : frmBaseQueryFormWithCondtion
    {
        private GridHitInfo hInfo;
        private Bll.InvoiceManager im = new Bll.InvoiceManager();
        public frmInvoiceQuery()
        {
            InitializeComponent(); 
            this.Module = BusinessModules.InvoiceManagement; 
        }


        protected override void InitModelOperate()
        {
            base.InitModelOperate();
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify));

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ImportData, "部门导入开票记录"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ImportData2, "财务导入开票记录"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View, "查看详情"));

            this.ModelOperatePageName = "开票管理"; 
        }


        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {
            if (operate.Operate == OperateTypes.New.ToString())
            {
                CreateInvoice();
            }
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                ModifyInvoice();
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                ViewInvoice();
            }
            else if (operate.Operate == OperateTypes.ImportData.ToString())
            {
                ImportInvoice(false);
            }
            else if (operate.Operate == OperateTypes.ImportData2.ToString())
            {
                ImportInvoice(true);
            }
            else
            {
                XtraMessageBox.Show("未定义的操作");
            }
        }

        public override void LoadData()
        {
            var list = im.GetAllInvoice();
            this.gridInvoice.DataSource = list;
        }

        private void ImportInvoice(bool isFinaceImport)
        {
            frmInvoiceImport form = new frmInvoiceImport(isFinaceImport); 
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.RefreshData();
            }
        }
        private void CreateInvoice()
        {
            frmInvoiceEdit form = new frmInvoiceEdit();
            form.WorkModel = EditFormWorkModels.New;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.RefreshData();
            }
        }

        private void ModifyInvoice()
        {
            Invoice invoice = this.gvInvoice.GetFocusedRow() as Invoice;
            if (invoice != null)
            {
                frmInvoiceEdit form = new frmInvoiceEdit();
                form.WorkModel = EditFormWorkModels.Modify;
                form.CurrentInvoice=invoice;
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.RefreshData();
                }
            }
        }

        private void ViewInvoice()
        {
            Invoice invoice = this.gvInvoice.GetFocusedRow() as Invoice;
            if (invoice != null)
            {
                frmInvoiceEdit form = new frmInvoiceEdit();
                form.WorkModel = EditFormWorkModels.View;
                form.CurrentInvoice = invoice;
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.RefreshData();
                }
            }
        }

        private void gvInvoice_DoubleClick(object sender, EventArgs e)
        {
            if (hInfo.InRow)
            {
                ModifyInvoice();
            }
        }

        private void gvInvoice_MouseDown(object sender, MouseEventArgs e)
        {
            hInfo = gvInvoice.CalcHitInfo(e.Y, e.Y);
        }
 
    }
}
