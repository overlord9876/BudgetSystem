using BudgetSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BudgetSystem.Dal
{
    public static class ExchageRateUtil
    {
        public static decimal GetExchageRate(DateTime date, IEnumerable<DateExchangeRate> exchanges, decimal defaultExchage)
        {
            var lastExchange = exchanges.Last();
            if (lastExchange == null)//如果没有日期汇率键值对，直接返回默认汇率
            {
                return defaultExchage;
            }
            DateExchangeRate item = exchanges.FirstOrDefault(o => o.date == date.ToString("yyyy-MM-dd"));
            if (item != null) { return item.ExchangeRate; }
            DateTime lastDate = DateTime.Parse(lastExchange.date);
            int index = -1;
            if ((lastDate - date).TotalDays > 0)
            {
                index = 1;
            }
            DateTime findMax = date;
            while (item == null)
            {
                findMax = findMax.AddDays(index);
                item = exchanges.FirstOrDefault(o => o.date == findMax.ToString("yyyy-MM-dd"));
            }
            return item?.ExchangeRate ?? defaultExchage;
        }


    }
}
