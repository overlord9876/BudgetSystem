using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 实收账款，出纳拿着银行汇款单填写单子，之后让业务员认领。
    /// </summary>
    public class ReceivableAccounts : IEntity
    {

        /// <summary>
        /// 凭证号
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 收汇日期
        /// </summary>
        public DateTime ReceiptDate { get; set; }

        /// <summary>
        /// 实收原币金额
        /// </summary>
        public decimal OriginalCoin { get; set; }

        /// <summary>
        /// 实收人民币金额
        /// </summary>
        public decimal RMB { get; set; }

        /// <summary>
        /// 录入人
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime CreateTimestamp { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public bool State { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }

    }
}
