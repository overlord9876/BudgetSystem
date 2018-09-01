using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem
{
    public enum OperateTypes
    {
        New,
        Modify,
        Delete,
        Relate,
        Revoke,
        Disabled,
        Enabled,
        View,
        /// <summary>
        /// 审核
        /// </summary>
        Agree
    }
}
