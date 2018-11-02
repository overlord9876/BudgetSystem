using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 审批过程表
    /// </summary>
    public class FlowRunPoint : IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 节点ID
        /// </summary>
        public int NodeID { get; set; }

        /// <summary>
        /// 对应的节点顺序号
        /// </summary>
        public int NodeOrderNo { get; set; }

        /// <summary>
        /// 实例ID
        /// </summary>
        public int InstanceID { get; set; }

        /// <summary>
        /// 实际审批人
        /// </summary>
        public string NodeApproveUser { get; set; }

        /// <summary>
        /// 节点审批结果
        /// </summary>
        public bool NodeApproveResult { get; set; }

        /// <summary>
        /// 节点审批意见
        /// </summary>
        public string NodeApproveRemark { get; set; }

        /// <summary>
        /// 运行点状态0，未处理，1已审批
        /// </summary>
        public bool State { get; set; }

        /// <summary>
        /// 生成时间
        /// </summary>
        public DateTime RunPointCreateDate { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime NodeApproveDate { get; set; }

    }
}
