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
    public partial class frmInvoiceQuery : frmBaseQueryForm
    {
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

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ImportData, "部门导入交单记录"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ImportData2, "财务导入认证记录"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ExportData, "导出交单记录"));

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View, "查看详情"));

            this.ModelOperatePageName = "交单管理";
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
            else if (operate.Operate == OperateTypes.ExportData.ToString())
            {
                ExportInvoice();
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
            if (openFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK
                || !System.IO.File.Exists(openFileDialog1.FileName))
            {
                return;
            }
            frmInvoiceImport form = new frmInvoiceImport(openFileDialog1.FileName, isFinaceImport);
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
                form.CurrentInvoice = invoice;
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.RefreshData();
                }
            }
            else 
            {
                XtraMessageBox.Show("请选择需要修改的项");     
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
            else
            {
                XtraMessageBox.Show("请选择需要查看详情的项");
            }
        }

        private void ExportInvoice()
        {
            if (saveFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            string extension = System.IO.Path.GetExtension(saveFileDialog1.FileName);
            if (extension.ToLower().EndsWith("xls"))
            {
                this.gvInvoice.ExportToXls(saveFileDialog1.FileName);
            }
            else
            {
                this.gvInvoice.ExportToXlsx(saveFileDialog1.FileName);
            }
        }

        protected override void InitGridViewAction()
        {
            this.gridViewAction.Add(this.gvInvoice, new ActionWithPermission() { MainAction = ModifyInvoice, MainOperate = OperateTypes.Modify, SecondAction = ViewInvoice, SecondOperate = OperateTypes.View });
        }



    }
}
