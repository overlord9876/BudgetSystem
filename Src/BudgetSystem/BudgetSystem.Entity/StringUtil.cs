using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BudgetSystem.Entity
{
    public static class StringUtil
    {
        public static string ToNameString(this List<Supplier> suppliers)
        {
            if (suppliers != null && suppliers.Any())
            {
                List<string> names = new List<string>();
                suppliers.ForEach(c => names.Add(c.Name));
                return string.Join(",", names.ToArray());
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
