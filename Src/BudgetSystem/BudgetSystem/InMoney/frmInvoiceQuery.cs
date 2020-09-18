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
using BudgetSystem.Entity.QueryCondition;
using DevExpress.XtraBars;
using BudgetSystem.Bll;

namespace BudgetSystem.InMoney
{
    public partial class frmInvoiceQuery : frmBaseQueryForm
    {
        private InvoiceQueryCondition currentCondition = null;
        private CommonManager cm = new CommonManager();
        private BudgetManager bm = new BudgetManager();
        private DateTime datetimeNow = DateTime.MinValue;
        private Bll.InvoiceManager im = new Bll.InvoiceManager();

        private const string COMMONQUERY_MYCREATE = "我创建的";

        public frmInvoiceQuery()
        {
            InitializeComponent();
            if (!IsDesignMode)
            {
                datetimeNow = cm.GetDateTimeNow();
                int year = datetimeNow.Year - 2;
                for (int index = 0; index < 52; index++)
                {
                    cboYears.Items.Add((year + index));
                }
                this.cboSelectYear.EditValue = datetimeNow.Year;

                this.deStartDate.EditValue = new DateTime(datetimeNow.Year, datetimeNow.Month, 1);
                DateTime nextMonth = new DateTime(datetimeNow.Year, datetimeNow.Month, 1);
                this.deEndDate.EditValue = new DateTime(datetimeNow.Year, datetimeNow.Month, nextMonth.AddMonths(1).AddDays(-1).Day);

                BudgetQueryCondition condition = new BudgetQueryCondition();
                condition = RunInfo.Instance.GetConditionByCurrentUser(condition) as BudgetQueryCondition;
                List<Budget> budgetList = bm.GetAllBudget(condition);
                this.repositoryItemGridLookUpEdit1.DataSource = budgetList;
                repositoryItemComboBox2.Items.Add(InvoiceViewMode.部门交单);
                repositoryItemComboBox2.Items.Add(InvoiceViewMode.财务交单);
                repositoryItemComboBox2.Items.Add(InvoiceViewMode.未核销交单);
                if (RunInfo.Instance.CurrentUser.UserName == "0007")
                {
                    repositoryItemComboBox2.Items.Add(InvoiceViewMode.滞期核销交单);
                }
                barSelectedMode.EditValue = InvoiceViewMode.部门交单;
            }
            this.repositoryItemGridLookUpEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(repositoryItemGridLookUpEdit1_ButtonClick);
            this.Module = BusinessModules.InvoiceManagement;
            this.cboSelectYear.EditValueChanged += new System.EventHandler(this.cboSelectYear_EditValueChanged);
            this.barSelected.EditValueChanged += new EventHandler(cboSelectYear_EditValueChanged);
            this.barSelectedMode.EditValueChanged += new EventHandler(barSelectedMode_EditValueChanged);
        }

        private void repositoryItemGridLookUpEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                this.barSelected.EditValue = null;
            }
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Delete));

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ImportData, "部门导入交单记录"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ImportData2, "财务导入认证记录"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ExportData, "导出交单记录"));

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View, "查看详情"));

            this.RegeditPrintOperate();
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.PrintSignatureForm));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.PrintCostForm));

            this.RegeditQueryOperate<InvoiceQueryCondition>(true, new List<string> { COMMONQUERY_MYCREATE }, "交单查询");

            this.ModelOperatePageName = "交单管理";
        }

        protected override void DoCommonQuery(string queryName)
        {
            if (COMMONQUERY_MYCREATE.Equals(queryName))
            {
                InvoiceQueryCondition condition = new InvoiceQueryCondition() { CreateUser = RunInfo.Instance.CurrentUser.UserName };
                LoadData(condition);
            }
        }

        protected override void DoConditionQuery(BudgetSystem.Entity.QueryCondition.BaseQueryCondition condition)
        {
            this.LoadData((InvoiceQueryCondition)condition);
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
            else if (operate.Operate == OperateTypes.Delete.ToString())
            {
                DeleteInvoice();
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
            LoadData(null);
        }

        private void LoadData(InvoiceQueryCondition condition)
        {
            currentCondition = condition;
            if (condition == null)
            {
                condition = new InvoiceQueryCondition();

                DateTime startTime = (DateTime)deStartDate.EditValue;
                startTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 0, 0, 0);
                DateTime endTime = (DateTime)deEndDate.EditValue;
                endTime = new DateTime(endTime.Year, endTime.Month, endTime.Day, 0, 0, 0).AddDays(1).AddSeconds(-1);

                condition = RunInfo.Instance.GetConditionByCurrentUser(condition) as InvoiceQueryCondition;


                InvoiceViewMode viewMode = InvoiceViewMode.部门交单;
                viewMode = (InvoiceViewMode)Enum.Parse(typeof(InvoiceViewMode), this.barSelectedMode.EditValue.ToString());
                condition.ViewMode = viewMode;
                condition.BeginTimestamp = startTime;
                condition.EndTimestamp = endTime;

                var selectedValue = this.barSelected.EditValue as Budget;
                if (selectedValue != null)
                {
                    condition.ContractNO = selectedValue.ContractNO.Trim();
                }
            }

            var list = im.GetAllInvoice(condition);
            this.gridInvoice.DataSource = list;
            this.gvInvoice.BestFitColumns();
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

        protected override QueryConditionEditorForm CreateConditionEditorForm()
        {
            frmInvoiceQueryConditionEditor form = new frmInvoiceQueryConditionEditor();
            form.QueryName = this.GetType().ToString();
            form.QueryCondition = this.currentCondition;
            return form;
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
            if (this.gvInvoice.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("请选择需要修改的项");
                return;
            }
            Invoice invoice = this.gvInvoice.GetRow(this.gvInvoice.FocusedRowHandle) as Invoice;
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
            if (this.gvInvoice.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("请选择需要查看详情的项");
                return;
            }
            Invoice invoice = this.gvInvoice.GetRow(this.gvInvoice.FocusedRowHandle) as Invoice;
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

        private void DeleteInvoice()
        {
            if (this.gvInvoice.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("请选择需要删除的项");
                return;
            }
            Invoice invoice = this.gvInvoice.GetRow(this.gvInvoice.FocusedRowHandle) as Invoice;
            if (invoice != null)
            {
                if (XtraMessageBox.Show("确认删除吗？", "删除提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.im.DeleteInvoice(invoice);
                    this.RefreshData();
                }
            }
            else
            {
                XtraMessageBox.Show("请选择需要删除的项");
            }
        }

        private void ExportInvoice()
        {
            DevExpress.Utils.WaitDialogForm sdf = new DevExpress.Utils.WaitDialogForm("正在读取数据……");
            try
            {
                InvoiceQueryCondition condition = new InvoiceQueryCondition();
                condition = RunInfo.Instance.GetConditionByCurrentUser(condition) as InvoiceQueryCondition;

                List<Invoice> list = this.im.GetAllInvoice(condition);
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
                    new ExcelColumn("销售毛利润",4660,-1,2,"C{0}-N{0}-O{0}",7),
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
            List<Invoice> dataSource = this.gridInvoice.DataSource as List<Invoice>;
            frmSignatureForm frm = new frmSignatureForm();
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
            if (this.gvInvoice.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("请选择需要打印的项");
                return;
            }
            Invoice invoice = this.gvInvoice.GetRow(this.gvInvoice.FocusedRowHandle) as Invoice;
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

        #region Search

        private void btnJanuary_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChangedMonth(1);
        }

        private void btnFebruary_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChangedMonth(2);
        }

        private void btnMarch_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChangedMonth(3);
        }

        private void btnApril_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChangedMonth(4);
        }

        private void btnMay_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChangedMonth(5);
        }

        private void btnJune_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChangedMonth(6);
        }

        private void btnJuly_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChangedMonth(7);
        }

        private void btnAugust_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChangedMonth(8);
        }

        private void btnSeptember_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChangedMonth(9);
        }

        private void btnOctober_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChangedMonth(10);
        }

        private void btnNovember_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChangedMonth(11);
        }

        private void btnDecember_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChangedMonth(12);
        }

        private void cboSelectYear_EditValueChanged(object sender, EventArgs e)
        {
            int year = (int)cboSelectYear.EditValue;
            deStartDate.EditValue = new DateTime(year, 1, 1, 0, 0, 0);
            deEndDate.EditValue = new DateTime(year, 1, 1, 0, 0, 0).AddYears(1).AddMinutes(-1);
            LoadData();
        }

        private void barSelectedMode_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ChangedMonth(int month)
        {
            int year = (int)cboSelectYear.EditValue;
            DateTime beginDate = new DateTime(year, month, 1, 0, 0, 0);
            deStartDate.EditValue = beginDate;
            deEndDate.EditValue = beginDate.AddMonths(1).AddMinutes(-1);
            LoadData();
        }

        private void btnSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData();
        }

        private void btn_Print_ItemClick(object sender, ItemClickEventArgs e)
        {
            PrinterHelper.PrintControl(true, this.gridInvoice, false, System.Drawing.Printing.PaperKind.A4);
        }

        private void btnExportExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "选择保存路径";
                dialog.Filter = "excel文件|*.xls";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.gvInvoice.ExportToXls(dialog.FileName);
                }
            }
        }

        #endregion

    }
}
