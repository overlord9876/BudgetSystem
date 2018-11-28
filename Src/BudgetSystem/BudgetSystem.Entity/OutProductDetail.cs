using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 外贸产产详情
    /// </summary>
    public class OutProductDetail
    {
        /// <summary>
        /// 商品规格
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal Count { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 原币
        /// </summary>
        public string OriginalCurrency { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 原币金额
        /// </summary>
        public decimal OriginalCurrencyMoney { get { return Count * Price; } }
        /// <summary>
        /// 汇率
        /// </summary>
        public decimal ExchangeRate { get; set; }
        /// <summary>
        /// 人民币
        /// </summary>
        public decimal CNY { get { return OriginalCurrencyMoney * ExchangeRate; } }
    }
}
