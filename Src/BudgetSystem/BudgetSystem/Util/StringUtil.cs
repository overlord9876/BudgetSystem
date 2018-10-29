using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Linq;

namespace BudgetSystem
{
    public static class StringUtil
    {
        public static string ToNameString(this List<Customer> customers)
        {
            if (customers != null && customers.Any())
            {
                List<string> names = new List<string>();
                customers.ForEach(c => names.Add(c.Name));
                return string.Join(",", names.ToArray());
            }
            else
            {
                return string.Empty;
            }
        }

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
