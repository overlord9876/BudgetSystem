using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 客户表
    /// </summary>
    public class CustomerReport : IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 总人民币金额
        /// </summary>
        public decimal CNY { get; set; }

        /// <summary>
        /// 未拆分人民币
        /// </summary>
        public decimal CNY2 { get; set; }

        /// <summary>
        /// 汇率
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// 总原币金额
        /// </summary>
        public decimal OriginalCoin { get; set; }

        /// <summary>
        /// 未拆分原币金额
        /// </summary>
        public decimal OriginalCoin2 { get; set; }

        public List<Declarationform> DeclarationformList { get; set; }
        public decimal DeclarationformTotal
        {
            get
            {
                if (DeclarationformList != null)
                {
                    return DeclarationformList.Sum(o => o.ExportAmount);
                }
                else
                {
                    return 0;
                }
            }
        }

    }

}
