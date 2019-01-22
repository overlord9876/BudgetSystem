using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 预算的状态枚举
    /// </summary>
    public enum EnumBudgetState
    {
        进行中=0,
        结账申请=1,
        财务平账征求=2,
        已结束=3,
    }
}
