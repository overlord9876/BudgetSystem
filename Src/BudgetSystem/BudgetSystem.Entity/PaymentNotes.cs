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
        /// 
        /// </summary>
        public int BudgetID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int SupplierID { get; set; }

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
        /// 
        /// </summary>
        public bool IsDrawback { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool HasInvoice { get; set; }

        /// <summary>
        /// 
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

    }
}
