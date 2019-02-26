using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity.QueryCondition
{
    public class OutMoneyQueryCondition : BaseQueryCondition
    {
        public string Supplier { get; set; }
        public string BudgetNO { get; set; }
        public string VoucherNo { get; set; }
        public string Applicant { get; set; }
        public PaymentState PayState { get; set; }
        public string ApproveUser { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public enum PaymentState
    {
        /// <summary>
        /// 所有已付款或未付
        /// </summary>
        All,
        /// <summary>
        /// 待付款
        /// </summary>
        PendingPayment,
        /// <summary>
        /// 已付款
        /// </summary>
        Paid
    }
}
