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
using DevExpress.XtraGrid;

namespace BudgetSystem
{
    public partial class frmSingleBudgetFinalAccountsReport : frmBaseQueryForm
    {
        private SystemConfigManager scm = new SystemConfigManager();
        private List<InMoneyType> inMoneyTypeList;
        private List<UseMoneyType> useMoneyTypeList;
        public Budget CurrentBudget { get; set; }
        private decimal ExchangeRate;
        public frmSingleBudgetFinalAccountsReport()
        {
            InitializeComponent();
            inMoneyTypeList = this.scm.GetSystemConfigValue<List<InMoneyType>>(EnumSystemConfigNames.收款类型.ToString());
            useMoneyTypeList = this.scm.GetSystemConfigValue<List<UseMoneyType>>(EnumSystemConfigNames.用款类型.ToString());

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
                DataRow row = null;
                //预算单表(赞不计算预算单信息)
                //row = dt.NewRow();
                //row["Date"] = budget.SignDate;
                //row["Premium"] = budget.Premium;
                //row["Commission"] = budget.Commission;
                //row["DirectCosts"] = budget.DirectCosts;
                //dt.Rows.Add(row);
                //报关单表
                gridBand29.Caption = budget.Premium.ToString();// 预算运杂费
                gridBand32.Caption = budget.Commission.ToString();// 预算佣金
                var dfList = new DeclarationformManager().GetDeclarationformByBudgetID(budget.ID);
                decimal originalExchangeRate = 0;//预算单原币汇率，取外贸部门商品的第一条商品信息原币汇率
                if (budget.OutProductList != null && budget.OutProductList.Count > 0)
                {
                    originalExchangeRate = budget.OutProductList[0].ExchangeRate;
                }
                foreach (Declarationform df in dfList)
                {
                    row = dt.NewRow();
                    row["Date"] = df.ExportDate;
                    row["ExportAmount"] = df.ExportAmount;
                    if (budget.ExchangeRate != 0 && originalExchangeRate != 0)
                    {
                        //折算成美元=报关原币*预算表原币汇率/预算表美元汇率  
                        row["USAExportAmount"] = Math.Round(df.ExportAmount * originalExchangeRate / (decimal)budget.ExchangeRate, 2);
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
                    if (bill.Currency == "USD")
                    {
                        ExchangeRate = bill.ExchangeRate;
                    }
                    row["BillExchangeRate"] = bill.ExchangeRate;
                    row["BillRemitter"] = bill.Remitter;
                    dt.Rows.Add(row);
                }
                //付款单表
                var pnData = new PaymentNotesManager().GetTotalIsApprovaledAmountPaymentMoneyByBudgetId(budget.ID);
                foreach (PaymentNotes pn in pnData)
                {
                    row = dt.NewRow();
                    dt.Rows.Add(row);
                    row["Date"] = pn.PaymentDate;

                    if (useMoneyTypeList.Where(o => o.Type == PaymentType.运杂费).Any(o => o.Name == pn.MoneyUsed))
                    {
                        row["Premium"] = pn.CNY;
                        row["PremiumConst"] = pn.DeTaxationCNY;
                    }
                    else if (useMoneyTypeList.Where(o => o.Type == PaymentType.佣金).Any(o => o.Name == pn.MoneyUsed))
                    {
                        row["Commission"] = pn.CNY;
                    }
                    else if (useMoneyTypeList.Where(o => o.Type == PaymentType.直接费用).Any(o => o.Name == pn.MoneyUsed))
                    {
                        row["DirectCosts"] = pn.CNY;
                    }
                    else
                    {
                        row["CNY"] = pn.CNY;
                    }
                    row["TaxRebateRate"] = Math.Round(pn.TaxRebateRate / 100, 2);
                    row["SupplierName"] = pn.SupplierName;
                    //if (pn.HasInvoice)//如果付款中已经提交发票，则这部分钱是为发票内容。
                    //{
                    //    row = dt.NewRow();

                    //    row["Date"] = pn.CommitTime;
                    //    row["OriginalCoin"] = pn.OriginalCoin;
                    //    row["ExchangeRate"] = pn.ExchangeRate;
                    //    row["Payment"] = pn.CNY;
                    //    row["TaxRebateRate"] = pn.TaxRebateRate / 100;
                    //    row["SupplierName"] = string.Format("{0}(付款已收发票)", pn.SupplierName);
                    //    row["FeedMoney"] = 0;
                    //    dt.Rows.Add(row);
                    //}
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
                    row["OriginalCoin"] = invoice.OriginalCoin;
                    row["ExchangeRate"] = invoice.ExchangeRate;
                    row["Payment"] = invoice.Payment + invoice.TaxAmount;
                    row["TaxRebateRate"] = invoice.TaxRebateRate / 100;
                    row["SupplierName"] = invoice.SupplierName;
                    row["FeedMoney"] = invoice.FeedMoney;
                    dt.Rows.Add(row);
                }
                dt.DefaultView.Sort = "Date";
                dt = dt.DefaultView.ToTable();
                if (ExchangeRate <= 0)
                {
                    ExchangeRate = (decimal)budget.ExchangeRate;
                }
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

            //实际收款单表+银行流水表
            dt.Columns.Add("BillOriginalCoin", typeof(decimal));//实收原币
            dt.Columns.Add("BillCNY", typeof(decimal));//实收人民币
            dt.Columns.Add("BillExchangeRate", typeof(decimal));//实收汇率
            dt.Columns.Add("BillRemitter", typeof(string));//付款公司
            //付款单表
            dt.Columns.Add("CNY", typeof(decimal));//已付货款
            //发票表 
            dt.Columns.Add("OriginalCoin", typeof(decimal));//应收原币
            dt.Columns.Add("ExchangeRate", typeof(decimal));//汇率
            dt.Columns.Add("Payment", typeof(decimal));//已收供方发票
            dt.Columns.Add("TaxRebateRate", typeof(decimal));//退税率
            dt.Columns.Add("SupplierName", typeof(string));//供货方名称
            dt.Columns.Add("FeedMoney", typeof(decimal));//供货方名称
            //预算单表
            dt.Columns.Add("Premium", typeof(decimal));//运杂费
            dt.Columns.Add("PremiumConst", typeof(decimal));//运杂费
            dt.Columns.Add("PremiumTaxRebateRate", typeof(decimal));//运杂费税率
            dt.Columns.Add("Commission", typeof(decimal));//佣金
            dt.Columns.Add("DirectCosts", typeof(decimal));//直接费用 

            //公式列
            dt.Columns.Add("TotalAmount", typeof(decimal));//  应收人民币=OriginalCoin*ExchangeRate
            dt.Columns.Add("CostOfSales", typeof(decimal));//  销售成本=已收供方发票/(1+退税率0)=Payment/(1+TaxRebateRate)
            dt.Columns.Add("SalesProfit", typeof(decimal));//  销售利润=应收人民币-销售成本-运杂费-佣金-直接费用-进料款
            dt.Columns.Add("Profit", typeof(decimal));// 实际利润=实收人民币-已付货款-运杂费-佣金-直接费用+已付货款/(1+扣除利息后实际利润)*退税率
            dt.Columns.Add("Balance", typeof(decimal));// 收支余
            dt.Columns.Add("TaxRebate", typeof(decimal));//出口退税额=已收供方发票-销售成本
            return dt;
        }

        private DataTable CalcFormulaColumnData(DataTable dt)
        {
            DataRow row;
            decimal totalOriginalCurrency = 0;
            decimal BillOriginalCoin = 0;
            decimal AllTotalAmount = 0;
            decimal BillCNY = 0;
            decimal totalPaymentCNY = 0;//已付金额
            decimal needPayment = 0;//已收发票
            decimal totalProfit = 0;//总实际利润
            decimal totalSalesProfit = 0;//总销售利润
            decimal taxRebate = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                row = dt.Rows[i];
                //应收人民币=OriginalCoin*ExchangeRate
                if (!row.IsNull("OriginalCoin") && !row.IsNull("ExchangeRate"))
                {
                    var totalAmount = Math.Round(GetDecimal(row, "OriginalCoin") * GetDecimal(row, "ExchangeRate"), 2);
                    row["TotalAmount"] = totalAmount;
                    totalOriginalCurrency = totalOriginalCurrency + GetDecimal(row, "OriginalCoin");
                    AllTotalAmount = AllTotalAmount + totalAmount;
                }
                BillOriginalCoin = BillOriginalCoin + GetDecimal(row, "BillOriginalCoin");
                BillCNY = BillCNY + GetDecimal(row, "BillCNY");
                //销售成本=已收供方发票/(1+退税率)=Payment/(1+TaxRebateRate)
                if (!row.IsNull("Payment"))
                {
                    needPayment = needPayment + Math.Round(GetDecimal(row, "Payment"), 2) + Math.Round(GetDecimal(row, "FeedMoney"), 2);
                    if (!row.IsNull("TaxRebateRate"))
                    {
                        row["CostOfSales"] = Math.Round(GetDecimal(row, "Payment") / (1 + GetDecimal(row, "TaxRebateRate")), 2);
                    }
                    //出口退税额=已收供方发票-销售成本
                    taxRebate = Math.Round(GetDecimal(row, "Payment") - GetDecimal(row, "CostOfSales"), 2);
                    row["TaxRebate"] = taxRebate;
                }
                //销售利润=应收人民币-销售成本-运杂费-佣金-直接费用-进料款
                var salesProfit = GetDecimal(row, "TotalAmount")
                                        - GetDecimal(row, "CostOfSales")
                                        - GetDecimal(row, "Premium")
                                        - GetDecimal(row, "Commission")
                                        - GetDecimal(row, "DirectCosts")
                                        - GetDecimal(row, "FeedMoney");
                row["SalesProfit"] = salesProfit;

                totalSalesProfit += salesProfit;

                //已付金额=已付货款+运杂费+佣金+直接费用
                var paymentMoney = GetDecimal(row, "CNY") + GetDecimal(row, "Premium") + GetDecimal(row, "Commission") + GetDecimal(row, "DirectCosts");
                totalPaymentCNY = totalPaymentCNY + GetDecimal(row, "CNY");
                //实际利润=实收人民币-已付货款-运杂费-佣金-直接费用+(已付货款/(1+扣除利息后实际利润)*退税率)
                //TODO:此列值未计算“扣除利息后实际利润”
                decimal TaxRebate = 0;
                if (GetDecimal(row, "TaxRebateRate") > 0)
                {
                    TaxRebate = GetDecimal(row, "CNY") - Math.Round(GetDecimal(row, "CNY") / (1 + GetDecimal(row, "TaxRebateRate")), 2);
                }
                var profit = GetDecimal(row, "BillCNY")
                        - paymentMoney + TaxRebate;

                row["Profit"] = profit.ToString();

                totalProfit += profit;

                //收支余额=上一条收支余额+当前行实际利润
                decimal preBalance = 0;
                if (i > 0)
                {
                    preBalance = GetDecimal(dt.Rows[i - 1], "Balance");
                }
                //TODO:此列值未计算“扣除利息后实际利润”
                row["Balance"] = preBalance + GetDecimal(row, "Profit");
            }
            //gridBand10.Caption = (totalOriginalCurrency - BillOriginalCoin).ToString();//应收原币      
            //2020-09-08 应收原币应该将原币换算成人民币，再换算会美元，如果收付款里没有美元，则采用预算单的美元汇率。
            gridBand10.Caption = (Math.Round((AllTotalAmount - BillCNY) / ExchangeRate, 2)).ToString();//应收原币
            gridBand3.Caption = (AllTotalAmount - BillCNY).ToString();//应收人民币
            gridBand23.Caption = (needPayment - totalPaymentCNY).ToString(); //应付余额=已收供方发票-已付供方货款
            gridBand4.Caption = (totalProfit - totalSalesProfit).ToString();//"利润差值"实际利润-销售利润(Profit-SalesProfit)
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

        private void advBandedGridView_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            GridSummaryItem gridSummaryItem = e.Item as GridSummaryItem;
            if (gridSummaryItem != null && "Balance".Equals(gridSummaryItem.FieldName) && e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            {
                DataTable dt = this.gcReport.DataSource as DataTable;
                decimal balance = 0;
                if (dt != null && dt.Rows.Count > 0)
                {
                    int dtCount = dt.Rows.Count;
                    balance = GetDecimal(dt.Rows[dtCount - 1], "Balance", 0);
                }
                e.TotalValue = balance;
            }
        }

    }
}