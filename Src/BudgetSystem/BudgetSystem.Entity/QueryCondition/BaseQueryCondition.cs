using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity.QueryCondition
{
    public abstract class BaseQueryCondition
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
