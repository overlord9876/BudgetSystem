using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity.QueryCondition
{
    public class InvoiceQueryCondition : BaseQueryCondition
    {
        public string Code { get; set; }

        public string ContractNO { get; set; }

        public DateTime BeginTimestamp { get; set; }

        public DateTime EndTimestamp { get; set; }

        public string CreateUser { get; set; }
    }
}
