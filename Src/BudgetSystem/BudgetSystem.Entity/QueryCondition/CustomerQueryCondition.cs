using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity.QueryCondition
{
    /// <summary>
    /// 客户查询条件
    /// </summary>
    public class CustomerQueryCondition : BaseQueryCondition
    {
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomName { get; set; }

        /// <summary>
        /// 客户编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 客户状态
        /// </summary>
        public int State { get; set; }

        public CustomerQueryCondition()
        {
            State = -1;
        }
    }
}
