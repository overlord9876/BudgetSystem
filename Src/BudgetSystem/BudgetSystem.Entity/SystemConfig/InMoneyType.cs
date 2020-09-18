using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 收款类型配置
    /// </summary>
    public class InMoneyType
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 收款类型
        /// </summary>
        public IMType Type { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }

    /// <summary>
    /// 收款类型
    /// </summary>
    public enum IMType
    {
        货款 = 1,
        暂收款 = 2
    }
}
