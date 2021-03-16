using BudgetSystem.Bll;
using BudgetSystem.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace BudgetSystem
{
    public class SingleBudgetReportHelper
    {
        public DataTable DataTable { get; private set; }
        public Budget CurrentBudget { get; private set; }
        private List<InMoneyType> inMoneyTypeList;
        private List<UseMoneyType> useMoneyTypeList;
        private decimal exchangeRate;
        private SystemConfigManager scm = new SystemConfigManager();
        private CommonManager cm = new CommonManager();

        /// <summary>
        /// 应收原币
        /// </summary>
        public decimal OriginalCoinAmount { get; set; }

        /// <summary>
        /// 应收人民币
        /// </summary>
        public decimal CNYAmount { get; set; }

        /// <summary>
        /// 应收原币余额
        /// </summary>
        public decimal ReceivableOriginalCoin { get; private set; }
        /// <summary>
        /// 应收人民币余额
        /// </summary>
        public decimal ReceivableCNY { get; private set; }
        /// <summary>
        /// 应付人民币余额
        /// </summary>
        public decimal BalancePayable { get; private set; }
        /// <summary>
        /// 利润差值
        /// </summary>
        public decimal ProfitMargin { get; private set; }
        /// <summary>
        /// 销售利润
        /// </summary>
        public decimal SalesProfit { get; private set; }
        /// <summary>
        /// 实际利润
        /// </summary>
        public decimal Profit { get; private set; }

        /// <summary>
        /// 应收原币
        /// </summary>
        public decimal OriginalCoinAmountAfter { get; set; }

        /// <summary>
        /// 应收人民币
        /// </summary>
        public decimal CNYAmountAfter { get; set; }

        /// <summary>
        /// 应收原币
        /// </summary>
        public decimal ReceivableOriginalCoinAfter { get; private set; }
        /// <summary>
        /// 应收人民币
        /// </summary>
        public decimal ReceivableCNYAfter { get; private set; }
        /// <summary>
        /// 应付人民币余额
        /// </summary>
        public decimal BalancePayableAfter { get; private set; }
        /// <summary>
        /// 利润差值
        /// </summary>
        public decimal ProfitMarginAfter { get; private set; }
        /// <summary>
        /// 销售利润
        /// </summary>
        public decimal SalesProfitAfter { get; private set; }
        /// <summary>
        /// 实际利润
        /// </summary>
        public decimal ProfitAfter { get; private set; }

        /// <summary>
        /// 账上收支余额
        /// </summary>
        public decimal Balance { get; private set; }

        private List<DateExchangeRate> dateExchangeRates;

        private AccountAdjustment accountAdjustment = null;
        private AccountAdjustmentDetail adjustmentDetail = null;

        private List<string> supplierList = new List<string>();
        public BudgetSingleReport CurrentBudgetReport { get; private set; }

        public SingleBudgetReportHelper(List<InMoneyType> _inMoneyTypeList = null, List<UseMoneyType> _useMoneyTypeList = null, List<DateExchangeRate> dateExchangeRates = null)
        {
            this.inMoneyTypeList = _inMoneyTypeList;
            this.useMoneyTypeList = _useMoneyTypeList;
            if (inMoneyTypeList == null)
                this.inMoneyTypeList = this.scm.GetSystemConfigValue<List<InMoneyType>>(EnumSystemConfigNames.收款类型.ToString());

            if (useMoneyTypeList == null)
                this.useMoneyTypeList = this.scm.GetSystemConfigValue<List<UseMoneyType>>(EnumSystemConfigNames.用款类型.ToString());
            this.dateExchangeRates = dateExchangeRates;
            if (this.dateExchangeRates == null)
            {
                this.dateExchangeRates = this.cm.GetDateExchanges();
            }
        }

        public void LoadData(Budget budget, AccountAdjustment accountAdjustment = null, AccountAdjustmentDetail adjustmentDetail = null)
        {
            if (budget == null)
            {
                return;
            }
            this.accountAdjustment = accountAdjustment;
            this.adjustmentDetail = adjustmentDetail;
            this.CurrentBudget = budget;
            this.DataTable = CreateDataTable();
            this.supplierList.Clear();
            DataRow row = null;

            var dfList = new DeclarationformManager().GetDeclarationformByBudgetID(budget.ID);
            decimal originalExchangeRate = 0;//预算单原币汇率，取外贸部门商品的第一条商品信息原币汇率
            if (budget.OutProductList != null && budget.OutProductList.Count > 0)
            {
                originalExchangeRate = budget.OutProductList[0].ExchangeRate;
            }
            foreach (Declarationform df in dfList)
            {
                row = this.DataTable.NewRow();
                row["Date"] = df.ExportDate;
                row["CNYOffshoreTotalPrice"] = df.CNYOffshoreTotalPrice;

                //折算成美元=报关原币*预算表原币汇率/预算表美元汇率  
                row["USDOffshoreTotalPrice"] = df.USDOffshoreTotalPrice;
                this.DataTable.Rows.Add(row);
            }

            var accountList = new AccountAdjustmentManager().GetBalanceAccountAdjustmentByBudgetId(budget.ID);
            if (accountAdjustment != null)
            {
                accountList = accountList.Where(o => !o.ID.Equals(accountAdjustment.ID)).ToList();
            }
            var detailRelationAccountList = new AccountAdjustmentManager().GetAdjustmentsByDetailBudgetId(budget.ID);
            var detailList = new AccountAdjustmentManager().GetAccountAdjustmentsDetailsByBudgetId(budget.ID);
            var adjustDetailList = new AccountAdjustmentManager().GetAccountAdjustmentsDetailByBudgetId(budget.ID);
            if (adjustmentDetail != null)
            {
                adjustDetailList = adjustDetailList.Where(o => !o.ID.Equals(adjustmentDetail.ID)).ToList();
            }
            string preix = string.Empty;
            string contracts = string.Empty;
            //付款单表
            var pnData = new PaymentNotesManager().GetTotalIsApprovaledAmountPaymentMoneyByBudgetId(budget.ID);
            foreach (PaymentNotes pn in pnData)
            {
                row = this.DataTable.NewRow();
                this.DataTable.Rows.Add(row);
                row["Date"] = pn.PaymentDate;
                row["MoneyUsed"] = pn.MoneyUsed;
                row["PaymentOriginalCoin"] = pn.OriginalCoin;
                if (pn.Currency == "美元")
                {
                    exchangeRate = (decimal)pn.ExchangeRate;
                    row["PaymentUSD"] = pn.OriginalCoin;
                }
                else
                {
                    exchangeRate = ExchageRateUtil.GetExchageRate(pn.PaymentDate, dateExchangeRates, (Decimal)budget.ExchangeRate);
                    row["PaymentUSD"] = Math.Round(pn.CNY / exchangeRate, 2);
                }
                row["PaymentExchangeRate"] = exchangeRate;
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
                else if (useMoneyTypeList.Where(o => o.Type == PaymentType.进料款).Any(o => o.Name == pn.MoneyUsed))
                {
                    row["PlanFeedMoney"] = pn.CNY;
                }
                else
                {
                    row["CNY"] = pn.CNY;
                }
                row["TaxRebateRate"] = Math.Round(pn.TaxRebateRate / 100, 2);
                row["SupplierName"] = pn.SupplierName;
                supplierList.Add(pn.SupplierName);
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

            //付款单表(调账)调出，则需要减去相应金额
            var reducePNData = accountList.Where(o => o.Type == AdjustmentType.付款);
            foreach (var pn in reducePNData)
            {
                row = this.DataTable.NewRow();
                this.DataTable.Rows.Add(row);
                row["Date"] = pn.CreateDate;

                row["MoneyUsed"] = pn.MoneyUsed;
                row["PaymentOriginalCoin"] = pn.OriginalCoin * -1;
                if (pn.Currency == "美元")
                {
                    exchangeRate = (decimal)pn.ExchangeRate;
                    row["PaymentUSD"] = pn.OriginalCoin * -1;
                }
                else
                {
                    exchangeRate = ExchageRateUtil.GetExchageRate(pn.Date, dateExchangeRates, (Decimal)budget.ExchangeRate);
                    row["PaymentUSD"] = Math.Round(pn.CNY / exchangeRate, 2) * -1;
                }
                row["PaymentExchangeRate"] = exchangeRate;
                if (useMoneyTypeList.Where(o => o.Type == PaymentType.运杂费).Any(o => o.Name == pn.MoneyUsed))
                {
                    row["Premium"] = (0 - pn.AlreadySplitCNY);
                    row["PremiumConst"] = (0 - pn.DeTaxationCNY);
                }
                else if (useMoneyTypeList.Where(o => o.Type == PaymentType.佣金).Any(o => o.Name == pn.MoneyUsed))
                {
                    row["Commission"] = (0 - pn.AlreadySplitCNY);
                }
                else if (useMoneyTypeList.Where(o => o.Type == PaymentType.进料款).Any(o => o.Name == pn.MoneyUsed))
                {
                    row["PlanFeedMoney"] = (0 - pn.AlreadySplitCNY);
                }
                else if (useMoneyTypeList.Where(o => o.Type == PaymentType.直接费用).Any(o => o.Name == pn.MoneyUsed))
                {
                    row["DirectCosts"] = (0 - pn.AlreadySplitCNY);
                }
                else
                {
                    row["CNY"] = (0 - pn.AlreadySplitCNY);
                }
                row["TaxRebateRate"] = Math.Round(pn.TaxRebateRate / 100, 2);
                var details = detailList?.Where(o => o.PID == pn.ID && o.Type == pn.Type);
                preix = details.Count() > 1 ? "分别" : "";
                contracts = string.Join("、", details.Select(o => $"{o.ContractNO}合同").ToArray());
                row["SupplierName"] = $"付款由此合同{preix}调入至{contracts}";
                supplierList.Add(pn.Name);
                row["AdjustmentType"] = (int)AdjustmentType.付款 + 1;
            }

            //付款单表(调账)调出
            var plusPNData = adjustDetailList.Where(o => o.Type == AdjustmentType.付款);
            foreach (var pn in plusPNData)
            {
                row = this.DataTable.NewRow();
                this.DataTable.Rows.Add(row);
                row["Date"] = pn.OperatorDate;

                row["MoneyUsed"] = pn.MoneyUsed;
                row["PaymentOriginalCoin"] = pn.OriginalCoin;
                if (pn.Currency == "美元")
                {
                    exchangeRate = (decimal)pn.ExchangeRate;
                    row["PaymentUSD"] = pn.OriginalCoin;
                }
                else
                {
                    exchangeRate = ExchageRateUtil.GetExchageRate(pn.Date, dateExchangeRates, (Decimal)budget.ExchangeRate);
                    row["PaymentUSD"] = Math.Round(pn.CNY / exchangeRate, 2);
                }
                row["PaymentExchangeRate"] = exchangeRate;
                if (useMoneyTypeList.Where(o => o.Type == PaymentType.运杂费).Any(o => o.Name == pn.MoneyUsed))
                {
                    row["Premium"] = pn.CNY;
                    row["PremiumConst"] = pn.DeTaxationCNY;
                }
                else if (useMoneyTypeList.Where(o => o.Type == PaymentType.佣金).Any(o => o.Name == pn.MoneyUsed))
                {
                    row["Commission"] = pn.CNY;
                }
                else if (useMoneyTypeList.Where(o => o.Type == PaymentType.进料款).Any(o => o.Name == pn.MoneyUsed))
                {
                    row["PlanFeedMoney"] = pn.CNY;
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
                row["SupplierName"] = $"付款由【{ detailRelationAccountList?.Find(o => o.ID == pn.PID)?.ContractNO}】合同调入至此合同，供应商【{pn.Name}】";
                row["AdjustmentType"] = ((int)AdjustmentType.付款 + 1) * 10;
                supplierList.Add(pn.Name);
            }

            //实际收款单表+银行流水表
            var billData = new ReceiptMgmtManager().GetBudgetBillListByBudgetId(budget.ID);
            foreach (var bill in billData)
            {
                row = this.DataTable.NewRow();
                row["Date"] = bill.ReceiptDate;
                row["BillOriginalCoin"] = bill.OriginalCoin;
                row["BillCNY"] = bill.CNY;
                if (bill.Currency == "USD")
                {
                    exchangeRate = bill.ExchangeRate;
                    row["BillUSD"] = bill.OriginalCoin;
                }
                else
                {
                    exchangeRate = ExchageRateUtil.GetExchageRate(bill.ReceiptDate, dateExchangeRates, (Decimal)budget.ExchangeRate);
                    row["BillUSD"] = Math.Round(bill.CNY / exchangeRate, 2);
                }
                row["BillExchangeRate"] = exchangeRate;
                if (supplierList.Any(s => s == bill.Customer))
                {
                    row["BillRemitter"] = $"【暂付退回】{bill.Customer}";
                    row["IsSupplier"] = true;
                }
                else if (supplierList.Any(s => s == bill.Remitter))
                {
                    row["BillRemitter"] = $"【暂付退回】{bill.Remitter}";
                    row["IsSupplier"] = true;
                }
                else
                {
                    row["BillRemitter"] = $"{bill.Remitter}";
                    row["IsSupplier"] = false;
                }
                this.DataTable.Rows.Add(row);
            }

            var reduceBillList = accountList.Where(o => o.Type == AdjustmentType.收款);
            //收款(调账)调出,则需要减去相应金额。
            foreach (var reduceBill in reduceBillList)
            {
                row = this.DataTable.NewRow();
                row["Date"] = reduceBill.CreateDate;
                row["BillOriginalCoin"] = reduceBill.AlreadySplitOriginalCoin * -1;
                row["BillCNY"] = reduceBill.AlreadySplitCNY * -1;
                if (reduceBill.Currency == "USD")
                {
                    exchangeRate = reduceBill.ExchangeRate;
                    row["BillUSD"] = reduceBill.AlreadySplitOriginalCoin * -1;
                }
                else
                {
                    exchangeRate = ExchageRateUtil.GetExchageRate(reduceBill.Date, dateExchangeRates, (Decimal)budget.ExchangeRate);
                    row["BillUSD"] = Math.Round(reduceBill.AlreadySplitCNY / exchangeRate, 2) * -1;
                }
                row["BillExchangeRate"] = exchangeRate;
                var details = detailList?.Where(o => o.PID == reduceBill.ID && o.Type == reduceBill.Type);
                preix = details.Count() > 1 ? "分别" : "";
                contracts = string.Join("、", details.Select(o => $"{o.ContractNO}合同").ToArray());
                row["AdjustmentType"] = (int)AdjustmentType.收款 + 1;
                if (supplierList.Any(s => s == reduceBill.Name))
                {
                    row["BillRemitter"] = $"【暂付退回】收款由此合同{preix}调入至{contracts}";
                    row["IsSupplier"] = true;
                }
                else
                {
                    row["BillRemitter"] = $"收款由此合同{preix}调入至{contracts}";
                    row["IsSupplier"] = false;
                }
                this.DataTable.Rows.Add(row);
            }

            var plusBillList = adjustDetailList.Where(o => o.Type == AdjustmentType.收款);
            //收款(调账)调入，则需要加上相应金额
            foreach (var plusBill in plusBillList)
            {
                row = this.DataTable.NewRow();
                row["Date"] = plusBill.OperatorDate;
                row["BillOriginalCoin"] = plusBill.OriginalCoin;
                if (plusBill.Currency == "USD")
                {
                    exchangeRate = plusBill.ExchangeRate;
                    row["BillUSD"] = plusBill.OriginalCoin;
                }
                else
                {
                    exchangeRate = ExchageRateUtil.GetExchageRate(plusBill.Date, dateExchangeRates, (Decimal)budget.ExchangeRate);
                    row["BillUSD"] = Math.Round(plusBill.CNY / exchangeRate, 2);
                }
                row["BillCNY"] = plusBill.CNY;
                row["BillExchangeRate"] = exchangeRate;
                if (supplierList.Any(s => s == plusBill.Name))
                {
                    row["BillRemitter"] = $"【暂付退回】收款由【{detailRelationAccountList?.Find(o => o.ID == plusBill.PID)?.ContractNO}】合同调入至此合同，付款商【{plusBill.Name}】";
                    row["IsSupplier"] = true;
                }
                else
                {
                    row["BillRemitter"] = $"收款由【{detailRelationAccountList?.Find(o => o.ID == plusBill.PID)?.ContractNO }】合同调入至此合同，付款商【{plusBill.Name}】";
                    row["IsSupplier"] = false;
                }
                row["AdjustmentType"] = ((int)AdjustmentType.收款 + 1) * 10;
                this.DataTable.Rows.Add(row);
            }

            //发票表
            var invoiceData = new InvoiceManager().GetAllInvoiceByBudgetID(budget.ID);
            foreach (Invoice invoice in invoiceData)
            {
                row = this.DataTable.NewRow();
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
                row["PlanCommission"] = invoice.Commission;
                row["ICommission"] = invoice.Commission;
                row["Payment"] = invoice.Payment + invoice.TaxAmount;
                row["TaxRebateRate"] = invoice.TaxRebateRate / 100;
                row["SupplierName"] = invoice.SupplierName;
                row["FeedMoney"] = invoice.FeedMoney;
                this.DataTable.Rows.Add(row);
            }


            //交单表(调账)调出，则减去相应金额
            var reduceInvoiceData = accountList.Where(o => o.Type == AdjustmentType.交单);
            foreach (var invoice in reduceInvoiceData)
            {
                row = this.DataTable.NewRow();
                row["Date"] = invoice.UpdateDate;
                row["OriginalCoin"] = (0 - invoice.AlreadySplitCNY);
                row["ExchangeRate"] = invoice.ExchangeRate;
                row["Payment"] = (0 - invoice.Payment) + (0 - invoice.TaxAmount);
                row["TaxRebateRate"] = invoice.TaxRebateRate / 100;
                var details = detailList?.Where(o => o.PID == invoice.ID && o.Type == invoice.Type);
                preix = details.Count() > 1 ? "分别" : "";
                contracts = string.Join("、", details.Select(o => $"{o.ContractNO}合同").ToArray());
                row["SupplierName"] = $"发票由此合同{preix}调入至{contracts}";
                row["FeedMoney"] = (0 - invoice.FeedMoney);
                row["AdjustmentType"] = (int)AdjustmentType.交单 + 1;
                this.DataTable.Rows.Add(row);
            }

            //付款单表(调账)调入，则加上相应金额。
            var plusInvoiceData = adjustDetailList.Where(o => o.Type == AdjustmentType.交单);
            foreach (var invoice in plusInvoiceData)
            {
                row = this.DataTable.NewRow();
                row["Date"] = invoice.OperatorDate;
                row["OriginalCoin"] = invoice.OriginalCoin;
                row["ExchangeRate"] = invoice.ExchangeRate;
                row["Payment"] = invoice.Payment + invoice.Amount;
                row["TaxRebateRate"] = invoice.TaxRebateRate / 100;
                row["SupplierName"] = $"交单由【{detailRelationAccountList?.Find(o => o.ID == invoice.PID)?.ContractNO}】合同调入至此合同，供应商【{invoice.Name}】";
                row["FeedMoney"] = invoice.FeedMoney;
                row["AdjustmentType"] = ((int)AdjustmentType.交单 + 1) * 10;
                this.DataTable.Rows.Add(row);
            }
            this.DataTable.DefaultView.Sort = "Date";
            this.DataTable = this.DataTable.DefaultView.ToTable();
            if (exchangeRate <= 0)
            {
                exchangeRate = (decimal)budget.ExchangeRate;
            }
            this.DataTable = CalcFormulaColumnData(this.DataTable);
        }

        private DataTable CalcFormulaColumnData(DataTable dt)
        {
            DataRow row;
            decimal originalCoinAmount = 0;//应收原币
            decimal AllTotalAmount = 0;//应收款，即发票金额
            decimal TotalBillCNY = 0;//实收人民币金额总计
            decimal BillCNY = 0;//实收人民币金额
            decimal BackCNY = 0;//暂付退回，即客户名与供应商同名的收款
            decimal BillOriginalCoin = 0;//实收原币金额。
            decimal totalPaymentCNY = 0;//已付金额
            decimal needPayment = 0;//已收发票
            decimal totalProfit = 0;//总实际利润
            decimal totalSalesProfit = 0;//总销售利润
            decimal paymentOriginalCoinAmount = 0;//付款原币总计
            decimal feedMoneyAmount = 0;//进料款（交）总计
            decimal paymentFeedMoneyAmount = 0;//进料款（付）总计
            decimal commissionAmount = 0;//佣金（交）总计
            decimal paymentCommissionAmount = 0;//佣金（付）总计
            decimal DirectCostsAmount = 0;//直接费用（付）总计
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                row = dt.Rows[i];
                //应收人民币（发票金额）=OriginalCoin*ExchangeRate
                if (!row.IsNull("OriginalCoin") && !row.IsNull("ExchangeRate"))
                {
                    originalCoinAmount += GetDecimal(row, "OriginalCoin");
                    var totalAmount = Math.Round(GetDecimal(row, "OriginalCoin") * GetDecimal(row, "ExchangeRate"), 2);
                    row["TotalAmount"] = totalAmount;
                    AllTotalAmount = AllTotalAmount + totalAmount;
                }
                feedMoneyAmount += GetDecimal(row, "FeedMoney");
                commissionAmount += GetDecimal(row, "ICommission");
                BillOriginalCoin = BillOriginalCoin + GetDecimal(row, "BillUSD");//2021-01-07由BillOriginalCoin改为BillUSD，是以原币改为美元合计。
                BillCNY = GetDecimal(row, "BillCNY");
                if (GetBool(row, "IsSupplier"))
                {
                    BackCNY += BillCNY;
                }
                TotalBillCNY = TotalBillCNY + BillCNY;
                //销售成本=已收供方发票/(1+退税率)=Payment/(1+TaxRebateRate)
                if (!row.IsNull("Payment"))
                {
                    needPayment = needPayment + Math.Round(GetDecimal(row, "Payment"), 2) + Math.Round(GetDecimal(row, "FeedMoney"), 2);
                    if (!row.IsNull("TaxRebateRate"))
                    {
                        row["CostOfSales"] = Math.Round(GetDecimal(row, "Payment") / (1 + GetDecimal(row, "TaxRebateRate")), 2);
                    }
                    //出口退税额=已收供方发票-销售成本
                    row["TaxRebate"] = Math.Round(GetDecimal(row, "Payment") - GetDecimal(row, "CostOfSales"), 2);
                }
                var DirectCosts = GetDecimal(row, "DirectCosts");
                var Commission = GetDecimal(row, "Commission");
                DirectCostsAmount += DirectCosts;//直接费用（付）汇总
                paymentCommissionAmount += Commission;//佣金（付）汇总
                string moneyUsed = row["MoneyUsed"]?.ToString();
                if (!string.IsNullOrEmpty(moneyUsed) && useMoneyTypeList.Where(o => o.Type == PaymentType.进料款).Any(o => o.Name == moneyUsed))
                {
                    paymentFeedMoneyAmount += GetDecimal(row, "CNY");//进料款（付）汇总
                }

                //销售利润=应收人民币-销售成本-运杂费-佣金-直接费用-进料款
                var salesProfit = GetDecimal(row, "TotalAmount")
                                        - GetDecimal(row, "CostOfSales")
                                        - GetDecimal(row, "Premium")
                                        - Commission
                                        - DirectCosts
                                        - GetDecimal(row, "FeedMoney");
                row["SalesProfit"] = salesProfit;
                var planSalesProfit = GetDecimal(row, "TotalAmount")
                                    - GetDecimal(row, "CostOfSales")
                                    - GetDecimal(row, "Premium")
                                    - GetDecimal(row, "PlanCommission")
                                    - DirectCosts
                                    - GetDecimal(row, "PlanFeedMoney");
                row["planSalesProfit"] = planSalesProfit;

                totalSalesProfit += salesProfit;

                totalPaymentCNY = totalPaymentCNY + GetDecimal(row, "CNY");

                //paymentOriginalCoinAmount += GetDecimal(row, "PaymentOriginalCoin");//已付原币

                //已付金额=已付货款+运杂费+佣金+直接费用
                var paymentMoney = GetDecimal(row, "CNY") + GetDecimal(row, "Premium") + GetDecimal(row, "Commission") + GetDecimal(row, "DirectCosts");
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
                row["Balance"] = preBalance + profit;
                Balance = preBalance + profit;
            }
            //gridBand10.Caption = (totalOriginalCurrency - BillOriginalCoin).ToString();//应收原币      
            //2020-09-08 应收原币应该将原币换算成人民币，再换算会美元，如果收付款里没有美元，则采用预算单的美元汇率。
            this.OriginalCoinAmount = originalCoinAmount;
            this.CNYAmount = AllTotalAmount;

            this.ReceivableOriginalCoin = Math.Round((AllTotalAmount - TotalBillCNY) / exchangeRate, 2);//应收原币余额
            this.ReceivableCNY = AllTotalAmount - TotalBillCNY;//应收人民币余额
            this.BalancePayable = needPayment - totalPaymentCNY + BackCNY; //应付余额=已收供方发票-已付供方货款+（与供应商同名收款，暂付退回）
            this.ProfitMargin = totalProfit - totalSalesProfit;//"利润差值"实际利润-销售利润(Profit-SalesProfit)
            this.Profit = totalProfit;
            this.SalesProfit = totalSalesProfit;

            decimal OriginalCoinAmountAfter = OriginalCoinAmount;//应收原币
            decimal CNYAmountAfter = CNYAmount;//应收人民币

            decimal originalCoinAmountAfter = originalCoinAmount;//应收原币
            decimal AllTotalAmountAfter = AllTotalAmount;//应收款，即发票金额
            decimal BillOriginalCoinAfter = BillOriginalCoin;//实收原币金额。
            decimal TotalBillCNYAfter = TotalBillCNY;//实收人民币金额总计
            decimal BackCNYAfter = BackCNY;//暂付退回，即客户名与供应商同名的收款
            decimal totalPaymentCNYAfter = totalPaymentCNY;//已付金额
            decimal needPaymentAfter = needPayment;//已收发票
            decimal totalProfitAfter = totalProfit;//总实际利润
            decimal totalSalesProfitAfter = totalSalesProfit;//总销售利润

            decimal paymentOriginalCoinAmountAfter = paymentOriginalCoinAmount;//付款原币总计
            decimal feedMoneyAmountAfter = feedMoneyAmount;//进料款（交）总计
            decimal paymentFeedMoneyAmountAfter = paymentFeedMoneyAmount;//进料款（付）总计
            decimal commissionAmountAfter = commissionAmount;//佣金（交）总计
            decimal paymentCommissionAmountAfter = paymentCommissionAmount;//佣金（付）总计
            decimal DirectCostsAmountAfter = DirectCostsAmount;//直接费用（付）总计

            if (accountAdjustment?.Type == AdjustmentType.收款)
            {
                BillOriginalCoinAfter += (0 - accountAdjustment.AlreadySplitOriginalCoin);//已收金额，如果调出应当减去金额。
                TotalBillCNYAfter += (0 - accountAdjustment.AlreadySplitCNY);// 已收金额，如果调出应当减去金额。
                if (supplierList.Any(o => o == accountAdjustment.Name))
                {
                    BackCNYAfter += (0 - accountAdjustment.AlreadySplitCNY);
                }
            }
            else if (accountAdjustment?.Type == AdjustmentType.付款)
            {
                totalPaymentCNYAfter += (0 - accountAdjustment.AlreadySplitCNY);//已付金额，如果调出了，应当减去金额
                if (useMoneyTypeList.Where(o => o.Type == PaymentType.进料款).Any(a => a.Name == accountAdjustment.MoneyUsed))
                {
                    paymentFeedMoneyAmountAfter += (0 - accountAdjustment.AlreadySplitCNY);
                }
                else if (useMoneyTypeList.Where(o => o.Type == PaymentType.佣金).Any(a => a.Name == accountAdjustment.MoneyUsed))
                {
                    paymentCommissionAmount += (0 - accountAdjustment.AlreadySplitCNY);
                }
                else if (useMoneyTypeList.Where(o => o.Type == PaymentType.直接费用).Any(a => a.Name == accountAdjustment.MoneyUsed))
                {
                    DirectCostsAmountAfter += (0 - accountAdjustment.AlreadySplitCNY);
                }
                //已付金额=已付货款+运杂费+佣金+直接费用，这里其实就是CNY
                var paymentMoney = accountAdjustment.AlreadySplitCNY;
                decimal TaxRebate = 0;//计算退税
                if (accountAdjustment.TaxRebateRate > 0)
                {
                    TaxRebate = accountAdjustment.AlreadySplitCNY - Math.Round(accountAdjustment.AlreadySplitCNY / (1 + (accountAdjustment.TaxRebateRate / 100)), 2);
                }
                //如果是调出付款，利润应当加上付款,减去退税。
                var profit = paymentMoney - TaxRebate;
                totalProfitAfter += profit;

                if (useMoneyTypeList.Where(o => o.Type == PaymentType.运杂费 || o.Type == PaymentType.佣金 || o.Type == PaymentType.直接费用).Any(o => o.Name == accountAdjustment.MoneyUsed))
                {
                    //如果调出付款，则利润需要加上运杂费或、佣金、直接费用。
                    totalSalesProfitAfter += accountAdjustment.AlreadySplitCNY;
                }
            }
            else if (accountAdjustment?.Type == AdjustmentType.交单)
            {
                //已收发票，如果调出去，应当减去
                needPaymentAfter += (0 - (accountAdjustment.Payment + accountAdjustment.TaxAmount + accountAdjustment.FeedMoney));

                var totalAmount = Math.Round(accountAdjustment.AlreadySplitOriginalCoin * accountAdjustment.ExchangeRate, 2);//发票金额
                AllTotalAmountAfter += (0 - totalAmount);
                originalCoinAmountAfter += (0 - accountAdjustment.AlreadySplitOriginalCoin);

                totalSalesProfitAfter += (0 - totalAmount);//发票调出，销售利润应当也调出利润中应收人民币金额

                decimal CostOfSales = 0;
                if (accountAdjustment.TaxRebateRate > 0)
                {
                    //销售成本
                    CostOfSales = Math.Round((accountAdjustment.Payment + accountAdjustment.TaxAmount) / (1 + accountAdjustment.TaxRebateRate), 2);
                }
                //发票调出，销售利润应当也调入相应销售成本
                totalSalesProfitAfter += CostOfSales;

                //进料款调出，销售利润应当加上相应进料款
                totalSalesProfitAfter += accountAdjustment.FeedMoney;
            }
            if (adjustmentDetail?.Type == AdjustmentType.收款)
            {
                if (!adjustmentDetail.IsDelete)
                {
                    BillOriginalCoinAfter += adjustmentDetail.OriginalCoin;//已收金额，如果调入应当加金额。
                    TotalBillCNYAfter += adjustmentDetail.CNY;// 已收金额，如果调进来应当加上金额。

                    if (supplierList.Any(o => o == adjustmentDetail.Name))
                    {
                        BackCNYAfter += adjustmentDetail.CNY;
                    }
                }
                else//如果是删除，则需取反
                {
                    BillOriginalCoinAfter += (0 - adjustmentDetail.OriginalCoin);
                    TotalBillCNYAfter += (0 - adjustmentDetail.CNY);

                    if (supplierList.Any(o => o == adjustmentDetail.Name))
                    {
                        BackCNYAfter += (0 - adjustmentDetail.CNY);
                    }
                }

            }
            else if (adjustmentDetail?.Type == AdjustmentType.付款)
            {
                if (!adjustmentDetail.IsDelete)
                {
                    totalPaymentCNYAfter += adjustmentDetail.CNY;//已付金额，如果调紧来了，应当加上金额
                    if (useMoneyTypeList.Where(o => o.Type == PaymentType.进料款).Any(a => a.Name == adjustmentDetail.MoneyUsed))
                    {
                        paymentFeedMoneyAmountAfter += adjustmentDetail.CNY;
                    }
                    else if (useMoneyTypeList.Where(o => o.Type == PaymentType.佣金).Any(a => a.Name == adjustmentDetail.MoneyUsed))
                    {
                        paymentCommissionAmount += adjustmentDetail.CNY;
                    }
                    else if (useMoneyTypeList.Where(o => o.Type == PaymentType.直接费用).Any(a => a.Name == adjustmentDetail.MoneyUsed))
                    {
                        DirectCostsAmountAfter += adjustmentDetail.CNY;
                    }
                    //已付金额=已付货款+运杂费+佣金+直接费用，这里其实就是CNY
                    var paymentMoney = adjustmentDetail.CNY;
                    decimal TaxRebate = 0;//计算退税
                    if (adjustmentDetail.TaxRebateRate > 0)
                    {
                        TaxRebate = adjustmentDetail.CNY - Math.Round(adjustmentDetail.CNY / (1 + (adjustmentDetail.TaxRebateRate / 100)), 2);
                    }
                    //如果是调入付款，利润应当减去付款,加上退税。
                    var profit = (0 - paymentMoney + TaxRebate);
                    totalProfitAfter += profit;

                    if (useMoneyTypeList.Where(o => o.Type == PaymentType.运杂费 || o.Type == PaymentType.佣金 || o.Type == PaymentType.直接费用).Any(o => o.Name == adjustmentDetail.MoneyUsed))
                    {
                        //如果调入付款，则利润需要减去运杂费或、佣金、直接费用。
                        totalSalesProfitAfter += (0 - adjustmentDetail.CNY);
                    }
                }
                else//如果是删除了，则需要取反。
                {
                    totalPaymentCNYAfter += (0 - adjustmentDetail.CNY);
                    if (useMoneyTypeList.Where(o => o.Type == PaymentType.进料款).Any(a => a.Name == adjustmentDetail.MoneyUsed))
                    {
                        paymentFeedMoneyAmountAfter += (0 - adjustmentDetail.CNY);
                    }
                    else if (useMoneyTypeList.Where(o => o.Type == PaymentType.佣金).Any(a => a.Name == adjustmentDetail.MoneyUsed))
                    {
                        paymentCommissionAmount += (0 - adjustmentDetail.CNY);
                    }
                    else if (useMoneyTypeList.Where(o => o.Type == PaymentType.直接费用).Any(a => a.Name == adjustmentDetail.MoneyUsed))
                    {
                        DirectCostsAmountAfter += (0 - adjustmentDetail.CNY);
                    }
                    //已付金额=已付货款+运杂费+佣金+直接费用，这里其实就是CNY
                    var paymentMoney = adjustmentDetail.CNY;
                    decimal TaxRebate = 0;//计算退税
                    if (adjustmentDetail.TaxRebateRate > 0)
                    {
                        TaxRebate = adjustmentDetail.CNY - Math.Round(adjustmentDetail.CNY / (1 + (adjustmentDetail.TaxRebateRate / 100)), 2);
                    }
                    //如果是调入付款，利润应当减去付款,加上退税。
                    var profit = paymentMoney - TaxRebate;
                    totalProfitAfter += profit;

                    if (useMoneyTypeList.Where(o => o.Type == PaymentType.运杂费 || o.Type == PaymentType.佣金 || o.Type == PaymentType.直接费用).Any(o => o.Name == adjustmentDetail.MoneyUsed))
                    {
                        //如果调入付款，则利润需要减去运杂费或、佣金、直接费用。
                        totalSalesProfitAfter += adjustmentDetail.CNY;
                    }
                }
            }
            else if (adjustmentDetail?.Type == AdjustmentType.交单)
            {
                if (!adjustmentDetail.IsDelete)
                {
                    //已收发票，如果调紧来，应当加上
                    needPaymentAfter += (adjustmentDetail.Payment + adjustmentDetail.Amount + adjustmentDetail.FeedMoney);

                    var totalAmount = Math.Round(adjustmentDetail.OriginalCoin * adjustmentDetail.ExchangeRate, 2);//发票金额
                    AllTotalAmountAfter += totalAmount;
                    originalCoinAmountAfter += adjustmentDetail.OriginalCoin;

                    totalSalesProfitAfter += totalAmount;//发票调入，销售利润应当也调入利润中应收人民币金额

                    decimal CostOfSales = 0;
                    if (adjustmentDetail.TaxRebateRate > 0)
                    {
                        //销售成本
                        CostOfSales = Math.Round((adjustmentDetail.Payment + adjustmentDetail.Amount) / (1 + adjustmentDetail.TaxRebateRate), 2);
                    }
                    //发票调入，销售利润应当也调出相应销售成本
                    totalSalesProfitAfter += (0 - CostOfSales);

                    //进料款调入，销售利润应当减去相应进料款
                    totalSalesProfitAfter += (0 - adjustmentDetail.FeedMoney);
                }
                else//如果是删除，则取反。
                {
                    //已收发票，如果调紧来，应当加上
                    needPaymentAfter += (0 - (adjustmentDetail.Payment + adjustmentDetail.Amount + adjustmentDetail.FeedMoney));

                    var totalAmount = Math.Round(adjustmentDetail.OriginalCoin * adjustmentDetail.ExchangeRate, 2);//发票金额
                    AllTotalAmountAfter += (0 - totalAmount);
                    originalCoinAmountAfter += (0 - adjustmentDetail.OriginalCoin);

                    totalSalesProfitAfter += (0 - totalAmount);//发票调入，销售利润应当也调入利润中应收人民币金额

                    decimal CostOfSales = 0;
                    if (adjustmentDetail.TaxRebateRate > 0)
                    {
                        //销售成本
                        CostOfSales = Math.Round((adjustmentDetail.Payment + adjustmentDetail.Amount) / (1 + adjustmentDetail.TaxRebateRate), 2);
                    }
                    //发票调入，销售利润应当也调出相应销售成本
                    totalSalesProfitAfter += CostOfSales;

                    //进料款调入，销售利润应当减去相应进料款
                    totalSalesProfitAfter += adjustmentDetail.FeedMoney;
                }
            }
            this.CNYAmountAfter = AllTotalAmountAfter;//应收原币
            this.OriginalCoinAmountAfter = originalCoinAmountAfter;//应收原币

            this.ReceivableOriginalCoinAfter = Math.Round((AllTotalAmountAfter - TotalBillCNYAfter) / exchangeRate, 2);//应收原币余额
            this.ReceivableCNYAfter = AllTotalAmountAfter - TotalBillCNYAfter;//应收人民币
            this.BalancePayableAfter = needPaymentAfter - totalPaymentCNYAfter + BackCNYAfter; //应付余额=已收供方发票-已付供方货款
            this.ProfitMarginAfter = totalProfitAfter - totalSalesProfitAfter;//"利润差值"实际利润-销售利润(Profit-SalesProfit)
            this.ProfitAfter = totalProfitAfter;
            this.SalesProfitAfter = totalSalesProfitAfter;

            CurrentBudgetReport = new BudgetSingleReport()
            {
                BudgetId = this.CurrentBudget.ID,
                ContractNO = this.CurrentBudget.ContractNO,
                BillOriginalCoin = BillOriginalCoin,
                BillCNY = TotalBillCNY,
                SalesProfit = this.SalesProfit,
                Profit = this.Profit,
                BalancePayable = needPayment,
                ProfitMargin = this.ProfitMargin,
                ReceivableCNY = this.CNYAmount,
                ReceivableOriginalCoin = this.OriginalCoinAmount,

                PaymentCNY = totalPaymentCNY,
                PaymentCNYAfter = totalPaymentCNYAfter,
                PaymentOriginalCoin = Math.Round(totalPaymentCNY / exchangeRate, 2),
                PaymentOriginalCoinAfter = Math.Round(totalPaymentCNYAfter / exchangeRate, 2),

                BillOriginalCoinAfter = BillOriginalCoinAfter,
                BillCNYAfter = TotalBillCNYAfter,
                SalesProfitAfter = this.SalesProfitAfter,
                ProfitAfter = this.ProfitAfter,
                BalancePayableAfter = needPaymentAfter,
                ProfitMarginAfter = this.ProfitMarginAfter,
                ReceivableCNYAfter = this.CNYAmountAfter,
                ReceivableOriginalCoinAfter = this.OriginalCoinAmountAfter,

                CommissionAmount = commissionAmount,
                CommissionAmountAfter = commissionAmountAfter,
                DirectCostsAmount = DirectCostsAmount,
                DirectCostsAmountAfter = DirectCostsAmountAfter,
                FeedMoneyAmount = feedMoneyAmount,
                FeedMoneyAmountAfter = feedMoneyAmountAfter,
                PaymentCommissionAmount = paymentCommissionAmount,
                PaymentCommissionAmountAfter = paymentCommissionAmountAfter,
                PaymentFeedMoneyAmount = paymentFeedMoneyAmount,
                PaymentFeedMoneyAmountAfter = paymentFeedMoneyAmountAfter,
                PaymentOriginalCoinAmount = paymentOriginalCoinAmount,
                PaymentOriginalCoinAmountAfter = paymentOriginalCoinAmountAfter
            };
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

        private bool GetBool(DataRow row, string column, bool defaultValue = false)
        {
            if (row.IsNull(column))
            {
                return defaultValue;
            }
            else
            {
                return (bool)row[column];
            }
        }

        private DataTable CreateDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("AdjustmentType", typeof(int));//是否调账
            dt.Columns.Add("Date", typeof(DateTime));//日期
            //报关单表
            dt.Columns.Add("CNYOffshoreTotalPrice", typeof(decimal));//报关原币（出口金额）
            dt.Columns.Add("USDOffshoreTotalPrice", typeof(decimal));//报关原币折算美元

            //实际收款单表+银行流水表
            dt.Columns.Add("BillOriginalCoin", typeof(decimal));//实收原币
            dt.Columns.Add("BillUSD", typeof(decimal));//折合美元
            dt.Columns.Add("BillCNY", typeof(decimal));//实收人民币
            dt.Columns.Add("BillExchangeRate", typeof(decimal));//实收汇率
            dt.Columns.Add("BillRemitter", typeof(string));//付款公司
            dt.Columns.Add("IsSupplier", typeof(bool));//是否为供应商，付款公司与供应商相同，则认为是供应商暂付暂收。
            //付款单表
            dt.Columns.Add("PaymentOriginalCoin", typeof(decimal));//已付原币金额
            dt.Columns.Add("PaymentUSD", typeof(decimal));//已付原币金额（暂未使用）
            dt.Columns.Add("PaymentExchangeRate", typeof(decimal));//付款汇率（暂未使用）
            dt.Columns.Add("CNY", typeof(decimal));//已付货款
            dt.Columns.Add("MoneyUsed", typeof(string));//用款类型
            dt.Columns.Add("Premium", typeof(decimal));//运杂费
            dt.Columns.Add("PremiumConst", typeof(decimal));//运杂费(去税金额)
            dt.Columns.Add("Commission", typeof(decimal));//佣金
            dt.Columns.Add("PlanCommission", typeof(decimal));//计划佣金
            dt.Columns.Add("DirectCosts", typeof(decimal));//直接费用 
            //发票表 
            dt.Columns.Add("OriginalCoin", typeof(decimal));//应收原币
            dt.Columns.Add("ExchangeRate", typeof(decimal));//汇率
            dt.Columns.Add("ICommission", typeof(decimal));//佣金
            dt.Columns.Add("Payment", typeof(decimal));//已收供方发票
            dt.Columns.Add("TaxRebateRate", typeof(decimal));//退税率
            dt.Columns.Add("SupplierName", typeof(string));//供货方名称
            dt.Columns.Add("FeedMoney", typeof(decimal));//进料款
            dt.Columns.Add("PlanFeedMoney", typeof(decimal));//计划进料款

            //公式列
            dt.Columns.Add("TotalAmount", typeof(decimal));//  应收人民币=OriginalCoin*ExchangeRate
            dt.Columns.Add("CostOfSales", typeof(decimal));//  销售成本=已收供方发票/(1+退税率0)=Payment/(1+TaxRebateRate)
            dt.Columns.Add("SalesProfit", typeof(decimal));//  销售利润=应收人民币-销售成本-运杂费-佣金-直接费用-进料款
            dt.Columns.Add("PlanSalesProfit", typeof(decimal));//  计划利润=
            dt.Columns.Add("Profit", typeof(decimal));// 实际利润=实收人民币-已付货款-运杂费-佣金-直接费用+已付货款/(1+扣除利息后实际利润)*退税率
            dt.Columns.Add("Balance", typeof(decimal));// 收支余
            dt.Columns.Add("TaxRebate", typeof(decimal));//出口退税额=已收供方发票-销售成本
            return dt;
        }

    }
}
