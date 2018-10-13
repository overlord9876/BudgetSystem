using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 出口商品
    /// </summary>
    public class Product
    {
        /// <summary>
        /// 产品顺序号
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 产品数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 原币类型
        /// </summary>
        public string OriginalCoin { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public int UnitPrice { get; set; }

        /// <summary>
        /// 汇率
        /// </summary>
        public float ExchangeRate { get; set; }

        /// <summary>
        /// 原币金额
        /// </summary>
        public decimal OriginalCoinMoney { get { return Count * UnitPrice; } }

        /// <summary>
        /// 换算人民币金额
        /// </summary>
        public decimal RMBMoney { get { return OriginalCoinMoney * (decimal)ExchangeRate; } }
    }
}
