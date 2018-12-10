using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;

namespace BudgetSystem
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
                return pn.CNY / (1 + pn.VatOption / 100) * ((decimal)pn.TaxRebateRate / 100);
            }
            else
            {
                return decimal.Zero;
            }
        }

    }
}
