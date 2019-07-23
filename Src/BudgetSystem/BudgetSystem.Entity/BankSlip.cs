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

        public int Cus_ID { get; set; }

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
        /// 款项性质
        /// </summary>
        public string NatureOfMoney { get; set; }

        /// <summary>
        /// 汇款方式
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// 未拆分人民币金额
        /// </summary>
        public decimal CNY2 { get; set; }

        /// <summary>
        /// 未拆原币金额
        /// </summary>
        public decimal OriginalCoin2 { get; set; }

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
        ///    已发布 = 0,
        ///拆分中 = 1，
        ///拆分完成=2
        /// </summary>
        public int State { get; private set; }

        /// <summary>
        /// 拆分状态
        /// </summary>
        public ReceiptState ReceiptState
        {
            get { return (ReceiptState)State; }
            set { State = (int)value; }
        }

        /// <summary>
        /// 流程状态
        /// </summary>
        public int FlowState { get; set; }

        /// <summary>
        /// 流程状态
        /// </summary>
        public EnumDataFlowState EnumFlowState
        {
            get
            {
                return this.FlowState.ToEnumDataFlowState();
            }
        }

        /// <summary>
        /// 流程状态
        /// </summary>
        public string EnumFlowStateDisplayValue
        {
            get
            {
                return this.FlowState.ToEnumDataFlowState("");
            }
        }

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
        /// 录入人姓名
        /// </summary>
        public string CreateRealName { get; set; }

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

        /// <summary>
        /// 是否活跃（允许修改）
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int RemarkState { get; set; }

        /// <summary>
        /// 拆分信息描述
        /// </summary>
        public string SplitInfo { get; set; }

        public BankSlip()
        {
            TradeNature = -1;
        }

        public string ToDesc()
        {
            return string.Format("{0}水单,需要修改合同入账",
                this.VoucherNo);
        }
    }

    public enum BankSlipTradeNature
    {
        一般贸易 = 0,
        来料加工 = 1,
        进料加工 = 2,
        其他 = 3
    }

    public enum ReceiptState : int
    {
        已发布 = 0,
        拆分中 = 1,
        已拆分 = 2

    }

    public enum RemarkState : int
    {
        None = 0,
        水单付款人余预算单买方不同备注 = 1,
        另附纸质说明 = 2
    }
}
