using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 原材料商品
    /// </summary>
    public class RawMaterial
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
        /// 原料价格
        /// </summary>
        public decimal RawMaterialPrice { get; set; }

        /// <summary>
        /// 辅料价格
        /// </summary>
        public decimal ExcipientsPrice { get; set; }

        /// <summary>
        /// 加工价格
        /// </summary>
        public decimal ProcessingPrice { get; set; }

        /// <summary>
        /// 单价（原料价格+辅料价格+加工价格）
        /// </summary>
        public decimal UnitPrice { get { return RawMaterialPrice + ExcipientsPrice + ProcessingPrice; } }

        /// <summary>
        /// 换算人民币金额
        /// </summary>
        public decimal CNYMoney { get { return UnitPrice * Count; } }
    }
}
