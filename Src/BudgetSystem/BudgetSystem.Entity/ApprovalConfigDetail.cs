using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 审批配置子表
    /// </summary>
    public class ApprovalConfigDetail : IEntity
    {

        /// <summary>
        /// 审批配置名称
        /// </summary>
        public string ConfigName { get; set; }

        /// <summary>
        /// 配置顺序号
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 用户角色
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// 审批人
        /// </summary>
        public User ApprovalUser { get; set; }
    }
}
