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
    }
}
