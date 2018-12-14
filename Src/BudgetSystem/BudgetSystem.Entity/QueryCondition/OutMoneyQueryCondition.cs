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
    }
}
