using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 审批配置表
    /// </summary>
    public class ApprovalConfig : IEntity
    {

        /// <summary>
        /// 审批配置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 配置顺序号
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTimestamp { get; set; }
    }
}
