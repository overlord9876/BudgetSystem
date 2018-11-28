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
            get
            {
                return _currentBudget.Profit;
            }
        }

        /// <summary>
        /// 应留实际利润
        /// </summary>
        public decimal ActualProfit
        {
            get
            {
                if (_currentBudget.TotalAmount != 0)
                {
                    return PlannedProfit / _currentBudget.TotalAmount * ReceiptMoneyAmount;
                }
                else { return 0; }
            }
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
                            returnResult.Add(v.TaxRebateRate);
                        }
                    }
                }
                return returnResult;
            }
        }

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
        }

        private void CalcAboutReceiptMoney()
        {
            ReceiptMoneyAmount = _receiptList.Sum(o => o.CNY);
        }

        private void CalcAboutPaymentMoney()
        {
            TaxPayment = _paymentList.Where(o => o.IsDrawback).Sum(o => o.CNY);
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
            CurrentTaxes = TaxRefund + paymentMoney / (1 + ValueAddedTaxRate) * exportRebateRate;
            if (_currentBudget.AdvancePayment > 0)
            {
                if (IsReceiptGreaterThanTaxPayment(paymentMoney))
                {
                    AllTaxes = TaxRefund + CurrentTaxes;
                }
                else
                {
                    //收到的钱小于或等于退税款，按实际收汇金额计算
                    AllTaxes = (ReceiptMoneyAmount / ValueAddedTaxRate) * exportRebateRate;
                }
            }
            else
            {
                AllTaxes = TaxRefund + CurrentTaxes;
            }

            this.Balance = ReceiptMoneyAmount - PaymentMoneyAmount + TaxRefund - paymentMoney + AdvancePayment;
        }


    }
}
