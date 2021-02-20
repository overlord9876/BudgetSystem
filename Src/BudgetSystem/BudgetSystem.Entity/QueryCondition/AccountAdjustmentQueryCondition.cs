using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity.QueryCondition
{
    /// <summary>
    /// 客户查询条件
    /// </summary>
    public class AccountAdjustmentQueryCondition : BaseQueryCondition
    {
        /// <summary>
        /// 合同号
        /// </summary>
        public string ContractNO { get; set; }

        /// <summary>
        /// 主客户名称
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime BeginDate { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime EndTime { get; set; }

        public AccountAdjustmentQueryCondition()
        {
            BeginDate = DateTime.MinValue;
            EndTime = DateTime.MinValue;
        }
    }
}
