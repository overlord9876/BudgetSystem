using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity.QueryCondition
{
    public class InMoneyQueryCondition : BaseQueryCondition
    {
        public string Customer { get; set; }
        public string VoucherNo { get; set; }
        public string BudgetNO { get; set; }
        public DateTime ReceiptDateBegin { get; set; }
        public DateTime ReceiptDateEnd { get; set; }
        public QueryReceiptState State { get; set; }
    }

    public enum QueryReceiptState
    {
        所有银行水单,
        未确认银行水单,
        已确认银行水单
    }
}
