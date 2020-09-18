﻿using System;
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
        /// 类型
        /// </summary>
        public PaymentType Type { get; set; }

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

    public enum PaymentType
    {
        货款 = 1,
        进料款 = 2,
        佣金 = 4,
        运杂费 = 8,
        直接费用 = 16,
        暂付款 = 32
    }
}
