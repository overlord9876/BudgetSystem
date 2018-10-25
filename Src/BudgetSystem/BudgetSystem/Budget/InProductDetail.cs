using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem
{
    /// <summary>
    /// 内贸产产详情
    /// </summary>
    public class InProductDetail
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
        /// 原材料价格
        /// </summary>
        public decimal RawMaterials { get; set; }

        /// <summary>
        /// 辅料价格
        /// </summary>
        public decimal SubsidiaryMaterials { get; set; }

        /// <summary>
        /// 加工费
        /// </summary>
        public decimal ProcessCost { get; set; }

        /// <summary>
        /// 小计
        /// </summary>
        public decimal Subtotal { get { return RawMaterials + SubsidiaryMaterials + ProcessCost; } }

    }
}
