using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 付款单
    /// </summary>
    public class PaymentNotes : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CommitTime { get; set; }

        /// <summary>
        /// 原币金额
        /// </summary>
        public decimal OriginalCoin { get; set; }

        /// <summary>
        /// 汇率
        /// </summary>
        public float ExchangeRate { get; set; }

        /// <summary>
        /// 增值税项
        /// </summary>
        public decimal VatOption { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// 付款金额
        /// </summary>
        public decimal CNY { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTimestamp { get; set; }

        /// <summary>
        /// 是否是借条
        /// </summary>
        public bool IsIOU { get; set; }

        /// <summary>
        /// 预计归还日期
        /// </summary>
        public DateTime ExpectedReturnDate { get; set; }

        /// <summary>
        /// 归还借款
        /// </summary>
        public bool RepayLoan { get; set; }

        public string RepayLoanText
        {
            get
            {
                if (IsIOU)
                {
                    return RepayLoan ? "借款已归还" : "未归还借款";
                }
                else { return string.Empty; }
            }
        }

        /// <summary>
        /// 发票号码
        /// </summary>
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// 合同ID
        /// </summary>
        public int BudgetID { get; set; }

        /// <summary>
        /// 客户ID
        /// </summary>
        public int SupplierID { get; set; }

        /// <summary>
        /// 开户行
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 银行账号
        /// </summary>
        public string BankNO { get; set; }

        /// <summary>
        /// 付款时间
        /// </summary>
        public DateTime PaymentDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 部门编号
        /// </summary>
        public string DepartmentCode { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        public string ContractNO { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// 用途
        /// </summary>
        public string MoneyUsed { get; set; }

        /// <summary>
        /// 用途
        /// </summary>
        public string MoneyUsedDesc
        {
            get
            {
                return string.Format("{0}{1}", MoneyUsed, IsDrawback ? "（可退税）" : string.Empty);
            }
        }

        /// <summary>
        /// 是否退税
        /// </summary>
        public bool IsDrawback { get; set; }

        /// <summary>
        /// 是否有发票
        /// </summary>
        public bool HasInvoice { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string VoucherNo { get; set; }

        /// <summary>
        /// 退税率
        /// </summary>
        public float TaxRebateRate { get; set; }

        /// <summary>
        /// 申请人
        /// </summary>
        public string Applicant { get; set; }

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

        public int FlowState { get; set; }

        public string ToDesc()
        {
            return string.Format("{0},于{1}申请向{2}付款人民币{3}",
                this.Applicant, this.CommitTime.ToString("yyyy年MM月dd日"), this.SupplierName, this.CNY);
        }

    }
}
