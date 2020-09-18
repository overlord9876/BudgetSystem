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
        /// 去税金额
        /// </summary>
        public decimal DeTaxationCNY
        {
            get
            {
                if (IsDrawback)
                {
                    return CNY - Math.Round(CNY / (1 + VatOption / 100) * ((decimal)TaxRebateRate / 100), 2);
                }
                else
                {
                    return CNY;
                }
            }
        }

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

        public int RepayLoanText
        {
            get
            {
                if (IsIOU)
                {
                    return RepayLoan ? 0 : -1;
                }
                else if (RepayLoan)
                {
                    return 0;
                }
                else { return 0; }
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
        /// 部门ID
        /// </summary>
        public int DeptID { get; set; }

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

        public PaymentType PaymentType { get; set; }

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
        /// 申请人姓名
        /// </summary>
        public string ApplicantRealName { get; set; }

        /// <summary>
        /// 付款银行
        /// </summary>
        public string PayingBank { get; set; }

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
        /// 预算单的预付款金额
        /// </summary>
        public decimal AdvancePayment { get; set; }

        /// <summary>
        /// 合同计算后的余额。
        /// </summary>
        public decimal Balance { get; set; }

        public int FlowState { get; set; }

        public string ToDesc()
        {
            return string.Format("{0}向{1}用于{2}付款￥{3}，预付款为：{4}，付款后余额为：{5}",
                this.ApplicantRealName, this.SupplierName, this.MoneyUsedDesc, this.CNY, this.AdvancePayment, this.Balance);
        }

        public string ToDesc2()
        {
            return string.Format("合同号【{0}】付款金额【￥{1}】用途：【{2}】",
                this.ContractNO.Trim(), this.CNY, this.MoneyUsedDesc);
        }
    }
}
