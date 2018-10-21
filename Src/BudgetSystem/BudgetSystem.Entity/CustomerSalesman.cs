using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 客户业务员匹配关系表
    /// </summary>
    public class CustomerSalesman : IEntity
    {
        /// <summary>
        /// 客户ID
        /// </summary>
        public int Customer { get; set; }

        /// <summary>
        /// 业务员
        /// </summary>
        public string Salesman { get; set; }

    }

}
