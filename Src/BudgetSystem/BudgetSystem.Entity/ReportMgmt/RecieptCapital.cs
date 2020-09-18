using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    public class RecieptCapital : IEntity
    {
        private string code;

        public decimal CNY { get; set; }

        public decimal OriginalCoin { get; set; }

        public string BankName { get; set; }

        public string BankCode
        {
            get
            {
                return string.Format("{0}{1}", BankName.Trim(), string.IsNullOrEmpty(PaymentMethod) ? "" : PaymentMethod.Trim());
            }
        }

        public string PaymentMethod { get; set; }

        public int DeptID { get; set; }

        /// <summary>
        /// 部门编号
        /// </summary>
        public string Code
        {
            get
            {
                if (string.IsNullOrEmpty(code) && Name == "余额")
                {
                    return "999";
                }
                return code;
            }
            set { code = value; }
        }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name { get; set; }

        public string Department
        {
            get
            {
                if (Name == "余额")
                {
                    return Name;
                }
                else
                {
                    return string.Format("{0}{1}", Code, Name);
                }
            }
        }

        /// <summary>
        /// 款项性质
        /// </summary>
        public string NatureOfMoney { get; set; }
    }
}
