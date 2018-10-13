using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 客户信息
    /// </summary>
    public class Supplier : IEntity
    {
        /// <summary>
        /// 客户名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 银行户名
        /// </summary>
        public string BankAccountName { get; set; }

        /// <summary>
        /// 银行账号
        /// </summary>
        public string BankNO { get; set; }

        /// <summary>
        /// 开户行
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 是否合格供应商
        /// </summary>
        public bool IsQualified { get; set; }

        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
