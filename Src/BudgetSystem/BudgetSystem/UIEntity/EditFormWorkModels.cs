using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem
{
    public enum EditFormWorkModels
    {
        Default,
        New,
        Modify,
        View,
        Custom,
        /// <summary>
        /// 分拆至合同
        /// </summary>
        SplitToBudget,
        Print,
        Review,
        /// <summary>
        /// 财务修改
        /// </summary>
        FinancialModify,
    }
}
