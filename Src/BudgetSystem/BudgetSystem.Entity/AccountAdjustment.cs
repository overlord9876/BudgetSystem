using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 调账管理
    /// </summary>
    public class AccountAdjustment : IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 调账编号
        /// </summary>
        public string Code { get; set; }

        public int FlowState { get; set; }

        /// <summary>
        /// 调账类型
        /// </summary>
        public AdjustmentType Type { get; set; }

        /// <summary>
        /// 审批状态
        /// </summary>
        public EnumDataFlowState EnumFlowState { get { return (EnumDataFlowState)FlowState; } }

        /// <summary>
        /// 流程实例ID。
        /// </summary>
        public int FlowInstanceID { get; set; }

        /// <summary>
        /// 流程名称
        /// </summary>
        public string FlowName { get; set; }

        /// <summary>
        /// 关联ID
        /// </summary>
        public int RelationID { get; set; }

        /// <summary>
        /// 供应商、客户名称。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 单号
        /// </summary>
        public string VoucherNo { get; set; }

        /// <summary>
        /// 预算单ID
        /// </summary>
        public int BudgetID { get; set; }

        /// <summary>
        /// 预算单号
        /// </summary>
        public string ContractNO { get; set; }

        /// <summary>
        /// 原币金额
        /// </summary>
        public decimal OriginalCoin { get; set; }

        /// <summary>
        ///金额，从收款、付款单中带出来。
        /// </summary>
        public decimal CNY { get; set; }
        public decimal SplitOriginalCoin { get; set; }
        public decimal SplitCNY { get; set; }
        /// <summary>
        /// 汇率
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public AccountAdjustmentState State { get; set; }

        /// <summary>
        ///已拆出原币金额
        /// </summary>
        public decimal AlreadySplitOriginalCoin { get; set; }

        /// <summary>
        ///已拆出金额
        /// </summary>
        public decimal AlreadySplitCNY { get; set; }

        public decimal AlreadySplitFeedMoney { get; set; }

        public decimal AlreadySplitPayment { get; set; }

        public decimal AlreadySplitTaxAmount { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 创建人姓名
        /// </summary>
        public string CreateRealUserName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// 付款、收款真实发生时间。
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string UpdateUser { get; set; }

        /// <summary>
        /// 创建人姓名
        /// </summary>
        public string UpdateUserRealName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 已收供方发票
        /// </summary>
        public decimal Payment { get; set; }
        /// <summary>
        /// 税额
        /// </summary>
        public decimal TaxAmount { get; set; }

        /// <summary>
        /// 退税率
        /// </summary>
        public decimal TaxRebateRate { get; set; }

        /// <summary>
        /// 进料款
        /// </summary>
        public decimal FeedMoney { get; set; }

        public decimal VatOption { get; set; }

        /// <summary>
        /// 付款用途
        /// </summary>
        public string MoneyUsed { get; set; }

        /// <summary>
        /// 是否退税
        /// </summary>
        public bool IsDrawback { get; set; }

        /// <summary>
        /// 去税金额
        /// </summary>
        public decimal DeTaxationCNY
        {
            get
            {
                if (IsDrawback)
                {
                    return AlreadySplitCNY - Math.Round(AlreadySplitCNY / (1 + VatOption / 100) * (TaxRebateRate / 100), 2);
                }
                else
                {
                    return AlreadySplitCNY;
                }
            }
        }

        /// <summary>
        /// 调账发起人角色。
        /// </summary>
        public int Role { get; set; }

        /// <summary>
        /// 枚举类型
        /// </summary>
        public AdjustmentRole EnumRole
        {
            get { return (AdjustmentRole)this.Role; }
            set { this.Role = (int)value; }
        }

        /// <summary>
        /// 详情
        /// </summary>
        public List<AccountAdjustmentDetail> Details { get; set; }

        public EnumFlowDataType ToDataType()
        {
            EnumFlowDataType dataType = EnumFlowDataType.收款调账;
            switch (this.Type)
            {
                case AdjustmentType.交单:
                    dataType = EnumFlowDataType.交单调账;
                    break;
                case AdjustmentType.付款:
                    dataType = EnumFlowDataType.付款调账;
                    break;
                case AdjustmentType.收款:
                default:
                    dataType = EnumFlowDataType.收款调账;
                    break;
            }
            return dataType;
        }
    }

    /// <summary>
    /// 调账类型。
    /// </summary>
    public enum AdjustmentType : int
    {
        收款 = 0,
        付款 = 1,
        交单 = 2,
    }

    /// <summary>
    /// 调账状态
    /// </summary>
    public enum AccountAdjustmentState : int
    {
        调账中 = 0,
        调账完成 = 1,
    }

    /// <summary>
    /// 调账角色
    /// </summary>
    public enum AdjustmentRole : int
    {
        业务员调账 = 0,
        财务调账
    }
}
