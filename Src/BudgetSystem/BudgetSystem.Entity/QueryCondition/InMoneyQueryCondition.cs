﻿using System;
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
        public string Salesman { get; set; }
    }
}
