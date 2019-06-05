using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    public class RecieptCapital : IEntity
    {
        public decimal CNY { get; set; }

        public decimal OriginalCoin { get; set; }

        public string BankName { get; set; }

        public string BankCode
        {
            get
            {
                return string.Format("{0}{1}", BankName.Trim(), PaymentMethod.Trim());
            }
        }

        public string PaymentMethod { get; set; }

        public int DeptID { get; set; }

        /// <summary>
        /// 部门编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name { get; set; }

        public string Department { get { return string.Format("{0}{1}", Code, Name); } }
    }
}
