using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    public class FlowItem:FlowInstance
    {

        /// <summary>
        /// 流程发起人名字
        /// </summary>
        public string CreateUserRealName
        {
            get;
            set;
        }

        public int RunPointID
        {
            get;
            set;
        }

        /// <summary>
        /// 用于存流程实例的状态的，主要处理未结束流程显示空的问题
        /// </summary>
        public string InstanceStateWithEmptyState
        {
            get
            {
               return this.IsClosed ? (this.ApproveResult ? "同意" : "驳回") : "";
            }
        }
    }
}
