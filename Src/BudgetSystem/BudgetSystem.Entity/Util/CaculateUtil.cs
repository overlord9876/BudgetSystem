using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    public static class CaculateUtil
    {
        /// <summary>
        /// 计算每个付款单的退税金额
        /// </summary>
        /// <param name="pn"></param>
        /// <returns></returns>
        public static decimal AmountOfTaxRebate(this PaymentNotes pn)
        {
            if (pn.IsDrawback)
            {
                return Math.Round(pn.CNY / (1 + pn.VatOption / 100) * ((decimal)pn.TaxRebateRate / 100), 2);
            }
            else
            {
                return decimal.Zero;
            }
        }

    }
}
