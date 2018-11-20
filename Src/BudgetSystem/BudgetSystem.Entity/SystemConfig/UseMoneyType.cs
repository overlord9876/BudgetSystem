using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 用款类型配置
    /// </summary>
    public class UseMoneyType
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
        /// 提供发票
        /// </summary>
        public bool ProvideInvoice
        {
            get;
            set;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
