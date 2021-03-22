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
        进行中 = 1,
        驳回归档征求 = 2,
        财务归档征求 = 4,
        已结束 = 8,
        归档复活 = 16
    }
}
