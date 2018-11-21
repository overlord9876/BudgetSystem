using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 审批主表
    /// </summary>
    public class FlowInstance : IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 流程名称
        /// </summary>
        public string FlowName { get; set; }

        /// <summary>
        /// 流程版本号
        /// </summary>
        public int FlowVersionNumber { get; set; }

        /// <summary>
        /// 数据项ID
        /// </summary>
        public int DateItemID { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public string DateItemType { get; set; }

        /// <summary>
        /// 数据项名称
        /// </summary>
        public string DateItemText { get; set; }

        /// <summary>
        /// 发起时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 发起人
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        public bool ApproveResult { get; set; }

        /// <summary>
        /// 是否已结束
        /// </summary>
        public bool IsClosed { get; set; }

        /// <summary>
        /// 关闭原因
        /// </summary>
        public string CloseReason { get; set; }

        /// <summary>
        /// 关闭时间
        /// </summary>
        public DateTime CloseDateTime { get; set; }

        /// <summary>
        /// 发起人是否已确认
        /// </summary>
        public bool IsCreateUserConfirm { get; set; }

        /// <summary>
        /// 确认时间
        /// </summary>
        public DateTime ConfirmDateTime { get; set; }

        /// <summary>
        /// 是否最近的
        /// </summary>
        public bool IsRecent { get; set; }

    }
}
