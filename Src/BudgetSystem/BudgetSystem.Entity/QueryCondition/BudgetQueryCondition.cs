using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity.QueryCondition
{
    /// <summary>
    /// 预算单查询条件
    /// </summary>
    public class BudgetQueryCondition : BaseQueryCondition
    {
        /// <summary>
        /// 业务员
        /// </summary>
        public string Salesman { get; set; }

        /// <summary>
        /// 合同号
        /// </summary>
        public string ContractNO { get; set; }
       
        /// <summary>
        /// 所在部门
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 主客户名称
        /// </summary>
        public string CustomerName { get; set; }
    }
}
