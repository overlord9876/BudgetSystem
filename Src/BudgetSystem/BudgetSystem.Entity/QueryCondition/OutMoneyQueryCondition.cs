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
        public PaymentState PayState { get; set; }
        public string ApproveUser { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime CommitBeginDate { get; set; }
        public DateTime CommitEndDate { get; set; }

        public OutMoneyQueryCondition()
        {
            CommitBeginDate = DateTime.MinValue;
            CommitEndDate = DateTime.MinValue;
            BeginDate = DateTime.MinValue;
            EndDate = DateTime.MinValue;
        }
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
