using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Linq;

namespace BudgetSystem
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
        /// 收款大于可退税货款
        /// </summary>
        public bool IsReceiptGreaterThanTaxPayment(decimal NewPayementMoney)
        {
            return ReceiptMoneyAmount > this.TaxPayment + NewPayementMoney;
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
        /// 加上本次用款，共计退税款
        /// </summary>
        public decimal AllTaxes { get; private set; }

        /// <summary>
        /// 支付后余额
        /// </summary>
        public decimal Balance { get; private set; }

        /// <summary>
        /// 扣除应留利润余额
        /// </summary>
        public decimal RetainedInterestBalance { get { return Balance - ActualProfit; } }

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
        /// 压缩预付款金额
        /// </summary>
        public decimal CompressAdvancePayment
        {
            get
            {
                if (ReceiptMoneyAmount > 0)
                {
                    if (_currentBudget.TotalAmount != 0)
                    {
                        return (1 - (ReceiptMoneyAmount / _currentBudget.TotalAmount)) * AdvancePayment;
                    }
                    else { return 0; }
                }
                else
                {
                    return AdvancePayment;
                }
            }
        }

        /// <summary>
        /// 总收款（收汇）人民币
        /// </summary>
        public decimal ReceiptMoneyAmount { get; private set; }

        /// <summary>
        /// 总付款人民币
        /// </summary>
        public decimal PaymentMoneyAmount { get; private set; }

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
        /// 佣金比率
        /// </summary>
        public decimal CommissionRate { get; private set; }

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

            decimal interest = Math.Round(AdvancePayment * (decimal)CurrentBudget.InterestRate * CurrentBudget.Days / 30 / 100, 2);
            decimal subTotal = CurrentBudget.Commission + CurrentBudget.Premium + CurrentBudget.BankCharges +/*直接费用*/0 + CurrentBudget.FeedMoney;

            //  净收入额=外贸合约人民币小计-内贸合约部分的利息-预算小计
            NetIncomeCNY = TotalAmount - CurrentBudget.PurchasePrice - interest - subTotal;
            //总收金额（USD）=折合人名币/汇率

            if (CurrentBudget.ExchangeRate != 0)
            {
                NetIncomeUSD = decimal.Round(NetIncomeCNY / (decimal)CurrentBudget.ExchangeRate, 2);
            }
            //出口退税额=总进价/1.17*出口退税率
            //decimal TaxRebateRateMoney = Math.Round(SelectedBudget.DirectCosts / (decimal)1.17 * (decimal)SelectedBudget.TaxRebateRate / 100, 2);
            //总成本=总进价-出口退税额
            decimal totalCost = CurrentBudget.PurchasePrice - (decimal)CurrentBudget.TaxRebate;

            //利润=折合人名币（净收入额）-总成本
            PlannedProfit = NetIncomeCNY - totalCost;

            if (NetIncomeCNY != 0)
            {
                //盈利水平=利润/净收入额
                ProfitLevel = PlannedProfit / NetIncomeCNY;
            }

            if (TotalAmount != 0)
            {
                ActualProfit = PlannedProfit / TotalAmount * ReceiptMoneyAmount;
            }
            //收汇超计划%=（已收汇人民币-合同计划款）/合同计划款*100%
            if (this.TotalAmount != 0)
            {
                this.SuperPaymentScheme = (Math.Round((this.ReceiptMoneyAmount - TotalAmount) / TotalAmount, 2)) * 100;
            }
        }

        private void CalcAboutReceiptMoney()
        {
            ReceiptMoneyAmount = _receiptList.Sum(o => o.CNY);
        }

        private void CalcAboutPaymentMoney()
        {
            TaxPayment = _paymentList.Where(o => o.IsDrawback).Sum(o => o.CNY);

            decimal commissionTotal = _paymentList.Where(o => o.MoneyUsed == "佣金").Sum(o => o.CNY);
            if (this.CurrentBudget.Commission > 0)
            {
                CommissionRate = (commissionTotal - this.CurrentBudget.Commission) / this.CurrentBudget.Commission * 100;
            }
            TaxRefund = _paymentList.Sum(o => o.AmountOfTaxRebate());
        }

        /// <summary>
        /// 当前最新计算的退税额
        /// </summary>
        public decimal CurrentTaxes { get; private set; }


        /// <summary>
        /// 获取所有税款
        /// </summary>
        /// <param name="paymentMoney"></param>
        /// <param name="exportRebateRate"></param>
        /// <returns></returns>
        public void GetAllTaxes(decimal paymentMoney, decimal exportRebateRate)
        {
            CurrentTaxes = TaxRefund + paymentMoney / (1 + ValueAddedTaxRate / 100) * (exportRebateRate / 100);
            if (_currentBudget.AdvancePayment > 0)
            {
                if (IsReceiptGreaterThanTaxPayment(paymentMoney))
                {
                    AllTaxes = TaxRefund + CurrentTaxes;
                }
                else
                {
                    //收到的钱小于或等于退税款，按实际收汇金额计算
                    AllTaxes = (ReceiptMoneyAmount / (1 + ValueAddedTaxRate / 100)) * (exportRebateRate / 100);
                }
            }
            else
            {
                AllTaxes = TaxRefund + CurrentTaxes;
            }

            this.Balance = ReceiptMoneyAmount - PaymentMoneyAmount + AllTaxes - paymentMoney + AdvancePayment;
        }

        public decimal GetUsagePayMoney(string usageName)
        {
            return this._paymentList.Where(o => o.MoneyUsed == usageName).Sum(o => o.CNY);
        }

    }
}
