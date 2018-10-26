using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 审批配置主表
    /// </summary>
    public class Flow : IEntity
    {
        /// <summary>
        /// 流程名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 流程版本号
        /// </summary>
        public int VersionNumber { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// 流程说明
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 是否使用版本
        /// </summary>
        public bool IsEnabled { get; set; }

        public List<FlowNode> Details { get; set; }

    }
}
