using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Linq;

namespace BudgetSystem
{
    public static class StringUtil
    {
        internal const string SaleRoleCode = "YWY";

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
        public static string ToNameAndCountryString(this List<Customer> customers)
        {
            if (customers != null && customers.Any())
            {
                List<string> names = new List<string>();
                customers.ForEach(c => names.Add(string.Format("{0}({1})", c.Name,c.Country)));
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
