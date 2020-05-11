using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Linq;

namespace BudgetSystem.Entity
{
    public class OutMoneyCaculator
    {
        private decimal vatOption;
        private Budget _currentBudget;
        private IEnumerable<PaymentNotes> _paymentList;
        private IEnumerable<BudgetBill> _receiptList;

        /// <summary>
        /// 当前合同
        /// </summary>
        public Budget CurrentBudget { get { return this._currentBudget; } }

        /// <summary>
        /// 增值税税率
        /// </summary>
        public decimal ValueAddedTaxRate
        {
            get { return this.vatOption; }
        }

        /// <summary>
        /// 平均退税率
        /// </summary>
        public decimal AVGExportRebateRate { get; private set; }

        /// <summary>
        /// 收款大于付款金额
        /// </summary>
        public bool IsReceiptGreaterThanTaxPayment(decimal NewPayementMoney)
        {
            return ReceiptMoneyAmount > this.IgnoreTransportationExpensesPaymentMoneyAmount + NewPayementMoney;
        }

        /// <summary>
        /// 预算单计划利润
        /// </summary>
        public decimal PlannedProfit
        {
            get;
            private set;
        }

        /// <summary>
        /// 应留实际利润
        /// </summary>
        public decimal ActualProfit
        {
            get;
            private set;
        }

        /// <summary>
        /// 申请用款金额
        /// </summary>
        public decimal ApplyMoney { get; private set; }

        /// <summary>
        /// 可退税货款款（金额）
        /// </summary>
        public decimal TaxPayment { get; private set; }

        /// <summary>
        /// 退税款（金额）
        /// </summary>
        public decimal TaxRefund
        {
            get;
            private set;
        }

        /// <summary>
        /// 账上余额
        /// </summary>
        public decimal AccountBalance { get; private set; }

        /// <summary>
        /// 合同金额（合同计划款）
        /// </summary>
        public decimal TotalAmount { get { return _currentBudget.TotalAmount; } }

        /// <summary>
        /// 合同预付款
        /// </summary>
        public decimal AdvancePayment
        {
            get { return this._currentBudget.AdvancePayment; }
        }

        /// <summary>
        /// 压缩后的预付款金额
        /// </summary>
        public decimal CompressAdvancePayment
        {
            get;
            private set;
        }

        /// <summary>
        /// 共计退税款
        /// </summary>
        public decimal TotalTaxPayment { get; private set; }

        /// <summary>
        /// 总收款（收汇）人民币
        /// </summary>
        public decimal ReceiptMoneyAmount { get; private set; }

        /// <summary>
        /// 总付款人民币
        /// </summary>
        public decimal PaymentMoneyAmount { get; private set; }

        /// <summary>
        /// 不含运杂费
        /// </summary>
        public decimal IgnoreTransportationExpensesPaymentMoneyAmount { get; private set; }

        /// <summary>
        /// 出口退税%(率)
        /// </summary>
        public List<decimal> TaxRebateRateList
        {
            get
            {
                List<decimal> returnResult = new List<decimal>();
                List<InProductDetail> inProductDetailList = null;
                if (!string.IsNullOrEmpty(_currentBudget.InProductDetail))
                {
                    try
                    {
                        inProductDetailList = _currentBudget.InProductDetail.ToObjectList<List<InProductDetail>>();
                    }
                    catch { }
                }
                else
                {
                    inProductDetailList = new List<InProductDetail>();
                }
                if (inProductDetailList != null && inProductDetailList.Count > 0)
                {
                    foreach (var v in inProductDetailList)
                    {
                        if (!returnResult.Contains(v.TaxRebateRate))
                        {
                            returnResult.Add(v.TaxRebateRate);
                        }
                    }
                }
                return returnResult;
            }
        }

        /// <summary>
        /// 预算款占总额%
        /// </summary>
        public decimal Percentage { get; private set; }

        /// <summary>
        /// 佣金比率
        /// </summary>
        public decimal CommissionRate { get; private set; }

        /// <summary>
        /// 佣金余额
        /// </summary>
        public decimal CommissionBalance { get; private set; }

        /// <summary>
        /// 应付运杂费余额
        /// </summary>
        public decimal Premiumbalance { get; private set; }

        /// <summary>
        /// 净收入额
        /// </summary>
        public decimal NetIncomeCNY { get; private set; }

        /// <summary>
        /// 净收入额(美元)
        /// </summary>
        public decimal NetIncomeUSD { get; private set; }

        /// <summary>
        /// 盈利水平
        /// </summary>
        public decimal ProfitLevel { get; private set; }

        public decimal SuperPaymentScheme { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="currentBudget">预算单（合同）对象</param>
        /// <param name="paymentList">付款记录</param>
        /// <param name="receiptList">收款记录</param>
        /// <param name="vatOption">增值税率</param>
        public OutMoneyCaculator(Budget currentBudget, IEnumerable<PaymentNotes> paymentList, IEnumerable<BudgetBill> receiptList, decimal vatOption)
        {


            this.vatOption = vatOption;
            this._currentBudget = currentBudget;
            this._paymentList = paymentList;
            this._receiptList = receiptList;
            CalcAboutReceiptMoney();

            CalcAboutPaymentMoney();

            #region 1.佣金比率=((已付佣金总额-预算单佣金总额)/预算单佣金金额)*100%

            //已付佣金总额
            decimal commissionTotal = _paymentList.Where(o => Util.PaymentUseCommissionUsageNameList.Contains(o.MoneyUsed)).Sum(o => o.CNY);

            decimal premiumTotal = _paymentList.Where(o => Util.PaymentUsePremiumTextList.Contains(o.MoneyUsed)).Sum(o => o.CNY);

            if (this.CurrentBudget.Commission > 0)
            {
                CommissionRate = Math.Round((commissionTotal - this.CurrentBudget.Commission) / this.CurrentBudget.Commission * 100, 2);

                CommissionBalance = this.CurrentBudget.Commission - commissionTotal;
            }

            if (this.CurrentBudget.Premium > 0)
            {
                //应付运杂费余额=已付运杂费-预算运杂费
                Premiumbalance = this.CurrentBudget.Premium - premiumTotal;
            }

            #endregion

            #region 2.压缩后的预付款=（1-已收汇（人民币）金额/预算单的合同金额）*预算单的预付款

            if (TotalAmount != 0 && ReceiptMoneyAmount <= TotalAmount)
            {
                CompressAdvancePayment = Math.Round((1 - (ReceiptMoneyAmount / TotalAmount)) * AdvancePayment, 2);
            }

            #endregion

            #region 3.预算款占总额%=(预付款)/(总进价+预算部分进料款*(1+增值税税率%/100))*100%

            if (this.CurrentBudget.PurchasePrice != 0)
            {
                Percentage = Math.Round(((AdvancePayment / (this.CurrentBudget.PurchasePrice + this.CurrentBudget.FeedMoney * (1 + this.CurrentBudget.VATRate / 100))) * 100), 2);
            }

            #endregion

            #region 4.账上余额 =已收汇（人民币）金额 – 申请用款金额（所有付款）

            AccountBalance = ReceiptMoneyAmount - PaymentMoneyAmount;

            #endregion

            #region 其他

            decimal interest = Math.Round(AdvancePayment * (decimal)CurrentBudget.InterestRate / 360 / 100 * CurrentBudget.Days, 2);
            decimal subTotal = CurrentBudget.Commission + CurrentBudget.Premium + CurrentBudget.BankCharges +/*直接费用*/0 + CurrentBudget.FeedMoney;

            //  净收入额=外贸合约人民币小计-预算小计
            NetIncomeCNY = TotalAmount - subTotal;
            //总收金额（USD）=折合人名币/汇率

            if (CurrentBudget.ExchangeRate != 0)
            {
                NetIncomeUSD = decimal.Round(NetIncomeCNY / (decimal)CurrentBudget.ExchangeRate, 2);
            }

            List<InProductDetail> inProductDetailList;
            if (!string.IsNullOrEmpty(currentBudget.InProductDetail))
            {
                inProductDetailList = currentBudget.InProductDetail.ToObjectList<List<InProductDetail>>();
            }
            else
            {
                inProductDetailList = new List<InProductDetail>();
            }
            //出口退税额
            decimal taxRebateRateMoney = inProductDetailList.Sum(o => o.TaxRebate);

            //总成本=总进价-出口退税额
            decimal totalCost = CurrentBudget.TotalCost - taxRebateRateMoney;

            //利润=折合人名币（净收入额）-总成本
            PlannedProfit = currentBudget.Profit;

            if (NetIncomeUSD != 0)
            {
                //盈利水平=利润/净收入额（USD）
                ProfitLevel = PlannedProfit / NetIncomeUSD;
            }

            #endregion

            #region 5.应留实际利润=预算单（预算）利润/预算单合同金额*已收汇（人民币）金额

            if (TotalAmount != 0 && ReceiptMoneyAmount != 0)
            {
                ActualProfit = Math.Round(PlannedProfit / TotalAmount * ReceiptMoneyAmount, 2);
            }
            else
            {
                ActualProfit = PlannedProfit;
            }

            #endregion

            #region 6.收汇超计划%=((已收汇（人民币）金额-合同计划款)/合同计划款)*100%

            if (this.TotalAmount != 0)
            {
                this.SuperPaymentScheme = Math.Round(((this.ReceiptMoneyAmount - TotalAmount) / TotalAmount) * 100, 2);
            }

            #endregion

        }

        /// <summary>
        /// 暂计退税款
        /// </summary>
        public decimal CurrentTaxes { get; private set; }

        /// <summary>
        /// 加上本次用款，共计退税款
        /// </summary>
        public decimal AllTaxes { get; private set; }

        /// <summary>
        /// 扣除应留利润余额
        /// </summary>
        public decimal RetainedInterestBalance { get; private set; }

        /// <summary>
        /// 启用预付款支付后余额
        /// </summary>
        public decimal EnablingAdvancePayment { get; private set; }

        #region Public Method

        /// <summary>
        /// 获取所有税款
        /// </summary>
        /// <param name="paymentMoney">申请用款</param>
        /// <param name="exportRebateRate">退税率</param>
        /// <param name="isDrawback">是否含有退税</param>
        public void ApplyForPayment(decimal paymentMoney, decimal exportRebateRate, bool isDrawback = true)
        {
            if (isDrawback)
            {
                //暂计退税款=(现申请用款/(1+增值税率%/100))*(出口退税率%/100)
                CurrentTaxes = Math.Round(paymentMoney / (1 + ValueAddedTaxRate / 100) * (exportRebateRate / 100), 2);
            }
            else
            {
                CurrentTaxes = 0;
            }
            if (_currentBudget.AdvancePayment == 0)//不包含预付款情况
            {
                //共计退税款=Sum(单笔付款金额/ (1+增值税率%/100)*出口退税率%/100)+ 暂计退税款
                AllTaxes = TaxRefund + CurrentTaxes;
                //支付后余额=账上余额+共计退税款-现申请用款
                this.Balance = AccountBalance + AllTaxes - paymentMoney;
            }
            else
            {
                #region  2019-06-26调整，退税款都按照付款（可退税）金额来计算，即：共计退税款=Sum(单笔付款金额/ (1+增值税率%)*出口退税率%)+ 暂计退税款

                #region 旧规则

                //if (IsReceiptGreaterThanTaxPayment(paymentMoney))//合同有预付款（所有可退税货款（辅料款）< 收款时）
                //{
                //    AllTaxes = TaxRefund + CurrentTaxes;
                //}
                //else//合同有预付款（所有可退税货款（辅料款）> 收款，或两者都为零时）
                //{
                //    CurrentTaxes = 0;
                //    if (exportRebateRate == 0)
                //    {
                //        exportRebateRate = AVGExportRebateRate;
                //    }
                //    //收到的钱小于或等于退税款，按实际收汇金额计算
                //    AllTaxes = Math.Round((ReceiptMoneyAmount / (1 + ValueAddedTaxRate / 100)) * (exportRebateRate / 100), 2);
                //}

                #endregion

                AllTaxes = TaxRefund + CurrentTaxes;

                #endregion


                //支付后余额=账上余额+共计退税款-现申请用款
                this.Balance = AccountBalance + AllTaxes - paymentMoney;

                //启用预付款支付后余额
                this.EnablingAdvancePayment = this.Balance + this.CompressAdvancePayment;

            }
            //留利后可支付款含退税款
            this.RetainedInterestBalance = this.Balance - this.ActualProfit;
        }

        /// <summary>
        /// 支付后余额
        /// </summary>
        public decimal Balance { get; private set; }

        public decimal GetUsagePayMoney(string usageName)
        {
            return this._paymentList.Where(o => o.MoneyUsed == usageName).Sum(o => o.CNY);
        }

        public decimal GetUsagePayMoney(List<string> usageNames)
        {
            return this._paymentList.Where(o => usageNames.Contains(o.MoneyUsed)).Sum(o => o.CNY);
        }

        #endregion

        #region Private Method

        private void CalcAboutReceiptMoney()
        {
            if (_receiptList != null)
            {
                ReceiptMoneyAmount = _receiptList.Where(o => !o.IsDelete).Sum(o => o.CNY);
            }
        }

        private void CalcAboutPaymentMoney()
        {
            TaxPayment = _paymentList.Where(o => o.IsDrawback).Sum(o => o.CNY);

            PaymentMoneyAmount = _paymentList.Sum(o => o.CNY);
            TotalTaxPayment = _paymentList.Where(o => o.IsDrawback).Sum(o => o.CNY);
            //AVGExportRebateRate = (decimal)_paymentList.Where(o => o.IsDrawback).Average(o => o.TaxRebateRate);

            IgnoreTransportationExpensesPaymentMoneyAmount = _paymentList.Where(o => !o.MoneyUsed.Equals(TransportationExpensesCaption)).Sum(o => o.CNY);
            TaxRefund = _paymentList.Sum(o => o.AmountOfTaxRebate());
        }

        #endregion

        public const string TransportationExpensesCaption = "运杂费";

    }
}
