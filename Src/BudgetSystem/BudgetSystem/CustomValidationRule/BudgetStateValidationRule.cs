using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Windows.Forms;
using BudgetSystem.Entity;

namespace BudgetSystem
{
    public class BudgetStateValidationRule : ValidationRule
    {
        public override bool Validate(Control control, object value)
        {

            Budget budget = value as Budget;
            return false;// budget.State == "审批结束";
        }
    }
}
