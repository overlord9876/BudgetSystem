using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 应收账款，此为开发票时录入信息
    /// </summary>
    public class ReceivableAccounts : IEntity
    {

        /// <summary>
        /// 凭证号
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 发票号
        /// </summary>
        public string InvoiceNo { get; set; }

        /// <summary>
        /// 交单日期
        /// </summary>
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// 应收原币金额
        /// </summary>
        public decimal OriginalCoin { get; set; }

        /// <summary>
        /// 应收人民币金额
        /// </summary>
        public decimal CNY { get; set; }

        /// <summary>
        /// 录入人
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime CreateTimestamp { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }

    }
}
