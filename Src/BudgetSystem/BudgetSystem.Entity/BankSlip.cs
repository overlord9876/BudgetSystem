using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 银行流水
    /// </summary>
    public class BankSlip : IEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int BSID { get; set; }

        /// <summary>
        /// 凭证号
        /// </summary>
        public string VoucherNo { get; set; }

        /// <summary>
        /// 汇款客户
        /// </summary>
        public string Remitter { get; set; }

        /// <summary>
        /// 实收原币金额
        /// </summary>
        public decimal OriginalCoin { get; set; }

        /// <summary>
        /// 实收人民币金额
        /// </summary>
        public decimal CNY { get; set; }

        /// <summary>
        /// 水单日期
        /// </summary>
        public DateTime ReceiptDate { get; set; }

        /// <summary>
        /// 汇款方式
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// 未拆分人民币金额
        /// </summary>
        public decimal CNY2 { get; set; }

        /// <summary>
        /// 汇率
        /// </summary>
        public float ExchangeRate { get; set; }

        /// <summary>
        /// 收汇银行
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// 状态
        ///    入账 = 0,
        ///待拆分 = 1,
        ///已拆分 = 2,
        ///关联合同 = 3
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 贸易性质
        /// 0=做单
        ///    1=过单
        /// </summary>
        public int TradeNature { get; set; }

        /// <summary>
        /// 出口名称
        /// </summary>
        public string ExportName { get; set; }

        /// <summary>
        /// 录入人
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// <summary>
        /// 交易附言
        /// </summary>
        public string TradingPostscript { get; set; }

        /// 备注
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime CreateTimestamp { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTimestamp { get; set; }

        /// <summary>
        /// 关联业务员
        /// </summary>
        public List<User> Sales { get; set; }
    }

    public enum BankSlipTradeNature
    {
        做单 = 0,
        过单 = 1
    }

    public enum ReceiptState : int
    {
        入账 = 0,
        待拆分 = 1,
        已拆分 = 2,
        关联合同 = 3,
        作废 = 4

    }
}
