using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 供应商表
    /// </summary>
    public class SupplierReport : IEntity
    {
        private decimal exchangeRate;

        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 付款人民币
        /// </summary>
        public decimal TotalCNY { get; set; }

        /// <summary>
        /// 汇率
        /// </summary>
        public decimal ExchangeRate
        {
            get
            {
                return Math.Round(this.exchangeRate, 2);
            }
            set { this.exchangeRate = value; }
        }

        /// <summary>
        /// 付款原币金额
        /// </summary>
        public decimal TotalOriginalCoin { get; set; }

        /// <summary>
        /// 应付人民币余额
        /// </summary>
        public decimal BalanceDue
        {
            get
            {
                return InvoiceTotal - TotalCNY;
            }
        }

        public List<Invoice> InvoiceList { get; set; }
        public decimal InvoiceTotal
        {
            get
            {
                if (InvoiceList != null)
                {
                    return InvoiceList.Sum(o => (o.Payment + o.TaxAmount));
                }
                else
                {
                    return 0;
                }
            }
        }

    }

    public class SupplierReportItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal OriginalCoin { get; set; }
        public decimal CNY { get; set; }
        public string PaymentDate { get; set; }

        public void ResetExchangeRate(IEnumerable<DateExchangeRate> dateExchangeRates)
        {
            if (!"美元".Equals(Currency))
            {
                var exchangeRateItem = dateExchangeRates?.FirstOrDefault(o => o.date == PaymentDate);
                if (exchangeRateItem != null)
                {
                    ExchangeRate = exchangeRateItem.ExchangeRate;
                    OriginalCoin = Math.Round(CNY / exchangeRateItem.ExchangeRate, 2);
                }
            }
        }
    }
}
