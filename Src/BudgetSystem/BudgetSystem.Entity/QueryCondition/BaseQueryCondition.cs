using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity.QueryCondition
{
    public class BaseQueryCondition
    {
        public string Name
        {
            get;
            set;
        }


        public override string ToString()
        {
            return this.Name;
        }
    }

}
