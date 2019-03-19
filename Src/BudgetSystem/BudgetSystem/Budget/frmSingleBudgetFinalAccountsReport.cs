using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;
using BudgetSystem.Bll;

namespace BudgetSystem
{
    public partial class frmSingleBudgetFinalAccountsReport : frmBaseQueryForm
    {
        public Budget CurrentBudget { get; set; }
        public frmSingleBudgetFinalAccountsReport()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmSingleBudgetFinalAccountsReport_Load);
            this.advBandedGridView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(bgvReport_CustomDrawCell);
        }

        void frmSingleBudgetFinalAccountsReport_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        void bgvReport_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == gcIndex)
            {
                //序号列
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }



        public override void LoadData()
        {
            if (this.CurrentBudget == null)
            {
                return;
            }
            Budget budget = new BudgetManager().GetBudget(this.CurrentBudget.ID);
            if (budget != null)
            {
                this.txtContractNO.Text = budget.ContractNO;
                this.txtDepartmentName.Text = budget.DepartmentName;
                this.txtSalesmanName.Text = budget.SalesmanName;
                this.txtTotalAmount.EditValue = budget.TotalAmount;
                this.txtTotalCost.EditValue = budget.TotalCost;
                this.txtProfit.EditValue = budget.Profit;
                this.txtAdvancePayment.EditValue = budget.AdvancePayment;
                DataTable dt = CreateDataTable();
                //预算单表
                DataRow row = dt.NewRow();
                row["Date"] = budget.SignDate;
                row["TotalAmount"] = budget.TotalAmount;
                row["ExchangeRate"] = budget.ExchangeRate;
                row["Premium"] = budget.Premium;
                row["Commission"] = budget.Commission;
                row["DirectCosts"] = budget.DirectCosts;
                dt.Rows.Add(row);
                //报关单表
                var dfList = new DeclarationformManager().GetDeclarationformByBudgetID(budget.ID);
                foreach (Declarationform df in dfList)
                {
                    row = dt.NewRow();
                    row["Date"] = df.ExportDate;
                    row["ExportAmount"] = df.ExportAmount;
                    if (df.ExchangeRate != 0)
                    {
                        //TODO:折算美元，这里先按照报关原币（出口金额）/汇率*预算单汇率 来计算
                        row["USAExportAmount"] = Math.Round(df.ExportAmount / (decimal)df.ExchangeRate * (decimal)budget.ExchangeRate,2);
                    }
                    dt.Rows.Add(row);
                }
                //实际收款单表+银行流水表
                var billData = new ReceiptMgmtManager().GetBudgetBillListByBudgetId(budget.ID);
                foreach (var bill in billData)
                {
                    row = dt.NewRow();
                    row["Date"] = bill.ReceiptDate;
                    row["BillOriginalCoin"] = bill.OriginalCoin;
                    row["BillCNY"] = bill.CNY;
                    row["BillExchangeRate"] = bill.ExchangeRate;
                    row["BillRemitter"] = bill.Remitter;
                    dt.Rows.Add(row);
                }
                //付款单表
                var pnData = new PaymentNotesManager().GetTotalAmountPaymentMoneyByBudgetId(budget.ID);
                foreach (PaymentNotes pn in pnData)
                {
                    row = dt.NewRow();
                    row["Date"] = pn.PaymentDate;
                    row["CNY"] = pn.CNY;
                    dt.Rows.Add(row);
                }
                //发票表
                var invoiceData = new InvoiceManager().GetAllInvoiceByBudgetID(budget.ID);
                foreach (Invoice invoice in invoiceData)
                {
                    row = dt.NewRow();
                    if (invoice.FinanceImportDate != null)
                    {
                        row["Date"] = invoice.FinanceImportDate;
                    }
                    else
                    {
                        row["Date"] = invoice.ImportDate;
                    }
                    row["Payment"] = invoice.AccountsPayable;
                    row["TaxRebateRate"] = invoice.TaxRebateRate/100;
                    row["SupplierName"] = invoice.SupplierName;
                    dt.Rows.Add(row);
                }
                dt.DefaultView.Sort = "Date";
                dt = dt.DefaultView.ToTable();
                this.gcReport.DataSource = CalcFormulaColumnData(dt);
            }
        }

        private DataTable CreateDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Date", typeof(DateTime));//日期
            //报关单表
            dt.Columns.Add("ExportAmount", typeof(decimal));//报关原币（出口金额）
            dt.Columns.Add("USAExportAmount", typeof(decimal));//报关原币折算美元
            //预算单表
            dt.Columns.Add("TotalAmount", typeof(decimal));//应收人民币
            dt.Columns.Add("ExchangeRate", typeof(decimal));//汇率
            //实际收款单表+银行流水表
            dt.Columns.Add("BillOriginalCoin", typeof(decimal));//实收原币
            dt.Columns.Add("BillCNY", typeof(decimal));//实收人民币
            dt.Columns.Add("BillExchangeRate", typeof(decimal));//实收汇率
            dt.Columns.Add("BillRemitter", typeof(string));//付款公司
            //付款单表
            dt.Columns.Add("CNY", typeof(decimal));//已付货款
            //发票表
            dt.Columns.Add("Payment", typeof(decimal));//已收供方发票
            dt.Columns.Add("TaxRebateRate", typeof(decimal));//退税率
            dt.Columns.Add("SupplierName", typeof(string));//供货方名称
            //预算单表
            dt.Columns.Add("Premium", typeof(decimal));//运保费
            dt.Columns.Add("Commission", typeof(decimal));//佣金
            dt.Columns.Add("DirectCosts", typeof(decimal));//直接费用 

            //公式列
            dt.Columns.Add("OriginalCurrency", typeof(decimal));//  应收原币=TotalAmount/ExchangeRate
            dt.Columns.Add("CostOfSales", typeof(decimal));//  销售成本=已收供方发票/(1+退税率0)=Payment/(1+TaxRebateRate)
            dt.Columns.Add("SalesProfit", typeof(decimal));//  销售利润=应收人民币-销售成本-运保费-佣金-直接费用
            dt.Columns.Add("Profit", typeof(decimal));// 实际利润=实收人民币-已付货款-运保费-佣金-直接费用+已付货款/(1+扣除利息后实际利润)*退税率
            dt.Columns.Add("Balance", typeof(decimal));// 收支余
            return dt;
        }

        private DataTable CalcFormulaColumnData(DataTable dt)
        {
            DataRow row;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                row = dt.Rows[i];
                //应收原币=TotalAmount/ExchangeRate 
                if (!row.IsNull("TotalAmount") && !row.IsNull("ExchangeRate") && GetDecimal(row, "ExchangeRate") != 0)
                {
                    row["OriginalCurrency"] = GetDecimal(row, "TotalAmount") / GetDecimal(row, "ExchangeRate");
                }
                //销售成本=已收供方发票/(1+退税率)=Payment/(1+TaxRebateRate)
                if (!row.IsNull("Payment") && !row.IsNull("TaxRebateRate"))
                {
                    row["CostOfSales"] = GetDecimal(row, "Payment") / (1 + GetDecimal(row, "TaxRebateRate"));
                }
                //销售利润=应收人民币-销售成本-运保费-佣金-直接费用
                row["SalesProfit"] = GetDecimal(row, "TotalAmount")
                                 - GetDecimal(row, "CostOfSales")
                                 - GetDecimal(row, "Premium")
                                 - GetDecimal(row, "Commission")
                                 - GetDecimal(row, "DirectCosts");
                //实际利润=实收人民币-已付货款-运保费-佣金-直接费用+已付货款/(1+扣除利息后实际利润)*退税率
                //TODO:此列值未计算“扣除利息后实际利润”
                row["Profit"] = (GetDecimal(row, "BillCNY")
                                 - GetDecimal(row, "CNY")
                                 - GetDecimal(row, "Premium")
                                 - GetDecimal(row, "Commission")
                                 - GetDecimal(row, "DirectCosts")
                                 + GetDecimal(row, "CNY") / (1 + 0) * GetDecimal(row, "TaxRebateRate")).ToString();

                //收支余额=上一条收支余额+当前行实际利润
                decimal preBalance = 0;
                if (i > 0)
                {
                    preBalance = GetDecimal(dt.Rows[i - 1], "Balance");
                }
                //TODO:此列值未计算“扣除利息后实际利润”
                row["Balance"] = preBalance + GetDecimal(row, "Profit");
            }
            return dt;
        }

        private decimal GetDecimal(DataRow row, string column, decimal defaultValue = 0)
        {
            if (row.IsNull(column))
            {
                return defaultValue;
            }
            else
            {
                return (decimal)row[column];
            }
        }


    }
}