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
using BudgetSystem.Util;

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

            this.RegeditPrintOperate();
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.PrintSignatureForm));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.PrintCostForm));

            this.ModelOperatePageName = "交单管理";
        }


        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {
            base.OperateHandled(operate, e);

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
            else if (operate.Operate == OperateTypes.PrintCostForm.ToString())
            {
                PrintCostForm();
            }
            else if (operate.Operate == OperateTypes.PrintSignatureForm.ToString())
            {
                PrintSignatureForm();
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
            DevExpress.Utils.WaitDialogForm sdf = new DevExpress.Utils.WaitDialogForm("正在读取数据……");
            try
            {
                List<Invoice> list = this.im.GetAllInvoice();
                if (list == null || list.Count == 0)
                {
                    sdf.Close();
                    XtraMessageBox.Show("没有可导出的数据");
                    return;
                }

                if (saveFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    sdf.Close();
                    return;
                }
                sdf.Caption = "正在生成导出数据……";
                string extension = System.IO.Path.GetExtension(saveFileDialog1.FileName);
                DataTable dt = new DataTable();
                dt.Columns.Add("合同号");
                dt.Columns.Add("原币");
                dt.Columns.Add("汇率");
                dt.Columns.Add("报关单");
                dt.Columns.Add("发票号");
                dt.Columns.Add("退税率");
                dt.Columns.Add("工厂名称");
                dt.Columns.Add("发票金额");
                dt.Columns.Add("税额");
                dt.Columns.Add("佣金");
                dt.Columns.Add("进料款");
                foreach (Invoice invoice in list)
                {
                    dt.Rows.Add(invoice.ContractNO, invoice.OriginalCoin, invoice.ExchangeRate, invoice.CustomsDeclaration,
                        invoice.Number, invoice.TaxRebateRate, invoice.SupplierName, invoice.Payment, invoice.TaxAmount, invoice.Commission, invoice.FeedMoney);
                }
                List<ExcelColumn> columns = new List<ExcelColumn>() { 
                    new ExcelColumn("合同号",4660,0),
                    new ExcelColumn("原币",4660,1,1,"",176),
                    new ExcelColumn("人民币",4660,-1,2,"IF(OR(B{0}=\"\",D{0}=\"\"),\"\",ROUND(B{0}*D{0},2))",7),	
                    new ExcelColumn("汇率",2330,2,1,"",7),	
                    new ExcelColumn("报关单",5660,3),	
                    new ExcelColumn("发票号",4660,4),	
                    new ExcelColumn("退税率",2330,5,1,""),	
                    new ExcelColumn("工厂名称",6660,6),	
                    new ExcelColumn("发票金额",4660,7,1,"",7),	
                    new ExcelColumn("税额",4660,8,1,"",7),	
                    new ExcelColumn("发票含税价",4660,-1,2,"IF(OR(I{0}<>\"\", J{0}<>\"\"),I{0}+J{0},\"\")",7),	
                    new ExcelColumn("退税款",4660,-1,2,"IF(OR(G{0}=\"\",I{0}=\"\",J{0}=\"\"),\"\",IF(OR(G{0}=0,I{0}=0,J{0}=0),0,ROUND(J{0}/ROUND(J{0}/I{0}*100,0)*G{0},2)))",7),	
                    new ExcelColumn("进项转出",4660,-1,2,"IF(OR(J{0}=\"\",L{0}=\"\",G{0}=\"\"),\"\",IF(G{0}=0,0,J{0}-L{0}))",7),	
                    new ExcelColumn("工厂成本",4660,-1,2,"IF(I{0}=\"\",\"\",I{0}+M{0}+P{0})",7),	               	
                    new ExcelColumn("佣金",4660,9,1,"",7),	
                    new ExcelColumn("进料款",4660,10,1,"",7),
                    new ExcelColumn("毛利",4660,-1,2,"C{0}-N{0}-O{0}",7),
                };
                string message = string.Empty;
                int count = ExcelHelper.DataTableToExcel(dt, saveFileDialog1.FileName, columns, out message);
                sdf.Close();
                if (count <= 0)
                {
                    XtraMessageBox.Show("导出失败：" + message);
                }
                else
                {
                    XtraMessageBox.Show("导出成功");
                }
            }
            catch (Exception ex)
            {
                sdf.Close();
                XtraMessageBox.Show("导出失：" + ex.Message);
            }
        }

        private void PrintSignatureForm()
        { 
            List<Invoice> dataSource= this.gridInvoice.DataSource as List<Invoice>;
            frmSignatureForm frm=new frmSignatureForm();
            frm.PrintData(dataSource);
        }

        private void PrintCostForm()
        {
            List<Invoice> dataSource = this.gridInvoice.DataSource as List<Invoice>;
            frmCostForm frm = new frmCostForm();
            frm.PrintData(dataSource);
        }

        protected override void InitGridViewAction()
        {
            this.gridViewAction.Add(this.gvInvoice, new ActionWithPermission() { MainAction = ModifyInvoice, MainOperate = OperateTypes.Modify, SecondAction = ViewInvoice, SecondOperate = OperateTypes.View });
        }

        protected override void PrintItem()
        {
            Invoice invoice = this.gvInvoice.GetFocusedRow() as Invoice;
            if (invoice != null)
            {
                frmInvoiceEdit form = new frmInvoiceEdit();
                form.WorkModel = EditFormWorkModels.View;
                form.CurrentInvoice = invoice;
                form.PrintItem();
            }
            else
            {
                XtraMessageBox.Show("请选择需要打印的项");
            }
        }
    }
}
