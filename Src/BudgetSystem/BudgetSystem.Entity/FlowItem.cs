using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    public class FlowItem : FlowInstance
    {

        /// <summary>
        /// 流程发起人名字
        /// </summary>
        public string CreateUserRealName
        {
            get;
            set;
        }

        /// <summary>
        /// 下一个审批人名字
        /// </summary>
        public string NextUserRealName
        {
            get;
            set;
        }

        public int RunPointID
        {
            get;
            set;
        }

        public int NodeID
        {
            get;
            set;
        }

        /// <summary>
        /// 用于存流程实例的状态的，主要处理未结束流程显示空的问题
        /// </summary>
        public string InstanceStateWithEmptyState
        {
            get;
            set;
        }

        /// <summary>
        /// 审批时间。
        /// </summary>
        public DateTime NodeApproveDate { get; set; }
    }
}
