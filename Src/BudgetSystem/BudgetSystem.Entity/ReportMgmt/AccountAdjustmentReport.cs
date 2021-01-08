using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 供应商表
    /// </summary>
    public class AccountAdjustmentReport : IEntity
    {
        /// <summary>
        /// 合同编号
        /// </summary>
        public string ContractNO { get; set; }
        public string DeptCode { get; set; }
        public decimal PaymentCNYOut { get; set; }
        public decimal PaymentCNYIn { get; set; }
        public decimal BillCNYOut { get; set; }
        public decimal BillCNYIn { get; set; }
        public decimal InvoiceCNYOut { get; set; }
        public decimal InvoiceCNYIn { get; set; }
        public DateTime Date { get; set; }
    }
}
