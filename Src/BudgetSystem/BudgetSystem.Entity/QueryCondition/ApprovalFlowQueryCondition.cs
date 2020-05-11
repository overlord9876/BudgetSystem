using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity.QueryCondition
{
    /// <summary>
    /// 我审批的单子查询条件
    /// </summary>
    public class ApprovalFlowQueryCondition : BaseQueryCondition
    {
        public int ID { get; set; }

        /// <summary>
        /// 当前用户
        /// </summary>
        public string CurrentUer { get; set; }

        /// <summary>
        /// 审批开始时间
        /// </summary>
        public DateTime BeginTimestamp { get; set; }

        /// <summary>
        /// 审批结束时间。
        /// </summary>
        public DateTime EndTimestamp { get; set; }

        public ApprovalFlowQueryCondition()
        {
            BeginTimestamp = DateTime.MinValue;
            EndTimestamp = DateTime.MinValue;
            DeptID = -1;
        }

    }
}
