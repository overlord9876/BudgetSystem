﻿using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Linq;

namespace BudgetSystem
{
    public static class StringUtil
    {
        /// <summary>
        /// 业务员
        /// </summary>
        internal const string SaleRoleCode = "YWY";
        /// <summary>
        /// 业务部审批员
        /// </summary>
        internal const string SaleDepartmentRoleCode = "BMYWY";
        /// <summary>
        /// 财务人员
        /// </summary>
        internal const string CWRYRoleCode = "CWRY";
        /// <summary>
        /// 财务经理
        /// </summary>
        internal const string FinanceManagerRoleCode = "FinanceManager";
        /// <summary>
        /// 财务副经理
        /// </summary>
        internal const string FinancialAssistantManagerRoleCode = "FinancialAssistantManager";
        /// <summary>
        /// 贸管部职员
        /// </summary>
        internal const string TradeManagementRoleCode = "TradeManagement";
        /// <summary>
        /// 财务收汇确认人员
        /// </summary>
        internal const string CWReceiptRoleCode = "CWReceipt";
        /// <summary>
        /// 出纳
        /// </summary>
        internal const string CWCashierRoleCode = "CWCashier";
        /// <summary>
        /// 供应商审批员
        /// </summary>
        internal const string SupplierApprovalRoleCode = "SupplierApproval";
        /// <summary>
        /// 总经理
        /// </summary>
        internal const string GeneralManagerRoleCode = "GeneralManager";
        /// <summary>
        /// 超级管理员
        /// </summary>
        internal const string SuperManagerRoleCode = "Default";

        

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
                customers.ForEach(c => names.Add(string.Format("{0}({1})", c.Name, c.Country)));
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


        /// <summary>
        /// 金额转换成中文大写金额
        /// </summary>
        /// <param name="LowerMoney">eg:10.74</param>
        /// <returns></returns>
        public static string MoneyToUpper(string LowerMoney)
        {
            string functionReturnValue = null;
            bool IsNegative = false; // 是否是负数
            if (LowerMoney.Trim().Substring(0, 1) == "-")
            {
                // 是负数则先转为正数
                LowerMoney = LowerMoney.Trim().Remove(0, 1);
                IsNegative = true;
            }
            string strLower = null;
            string strUpart = null;
            string strUpper = null;
            int iTemp = 0;
            // 保留两位小数 123.489→123.49　　123.4→123.4
            LowerMoney = Math.Round(double.Parse(LowerMoney), 2).ToString();
            if (LowerMoney.IndexOf(".") > 0)
            {
                if (LowerMoney.IndexOf(".") == LowerMoney.Length - 2)
                {
                    LowerMoney = LowerMoney + "0";
                }
            }
            else
            {
                LowerMoney = LowerMoney + ".00";
            }
            strLower = LowerMoney;
            iTemp = 1;
            strUpper = "";
            while (iTemp <= strLower.Length)
            {
                switch (strLower.Substring(strLower.Length - iTemp, 1))
                {
                    case ".":
                        strUpart = "圆";
                        break;
                    case "0":
                        strUpart = "零";
                        break;
                    case "1":
                        strUpart = "壹";
                        break;
                    case "2":
                        strUpart = "贰";
                        break;
                    case "3":
                        strUpart = "叁";
                        break;
                    case "4":
                        strUpart = "肆";
                        break;
                    case "5":
                        strUpart = "伍";
                        break;
                    case "6":
                        strUpart = "陆";
                        break;
                    case "7":
                        strUpart = "柒";
                        break;
                    case "8":
                        strUpart = "捌";
                        break;
                    case "9":
                        strUpart = "玖";
                        break;
                }

                switch (iTemp)
                {
                    case 1:
                        strUpart = strUpart + "分";
                        break;
                    case 2:
                        strUpart = strUpart + "角";
                        break;
                    case 3:
                        strUpart = strUpart + "";
                        break;
                    case 4:
                        strUpart = strUpart + "";
                        break;
                    case 5:
                        strUpart = strUpart + "拾";
                        break;
                    case 6:
                        strUpart = strUpart + "佰";
                        break;
                    case 7:
                        strUpart = strUpart + "仟";
                        break;
                    case 8:
                        strUpart = strUpart + "万";
                        break;
                    case 9:
                        strUpart = strUpart + "拾";
                        break;
                    case 10:
                        strUpart = strUpart + "佰";
                        break;
                    case 11:
                        strUpart = strUpart + "仟";
                        break;
                    case 12:
                        strUpart = strUpart + "亿";
                        break;
                    case 13:
                        strUpart = strUpart + "拾";
                        break;
                    case 14:
                        strUpart = strUpart + "佰";
                        break;
                    case 15:
                        strUpart = strUpart + "仟";
                        break;
                    case 16:
                        strUpart = strUpart + "万";
                        break;
                    default:
                        strUpart = strUpart + "";
                        break;
                }

                strUpper = strUpart + strUpper;
                iTemp = iTemp + 1;
            }

            strUpper = strUpper.Replace("零拾", "零");
            strUpper = strUpper.Replace("零佰", "零");
            strUpper = strUpper.Replace("零仟", "零");
            strUpper = strUpper.Replace("零零零", "零");
            strUpper = strUpper.Replace("零零", "零");
            strUpper = strUpper.Replace("零角零分", "整");
            strUpper = strUpper.Replace("零分", "整");
            strUpper = strUpper.Replace("零角", "零");
            strUpper = strUpper.Replace("零亿零万零圆", "亿圆");
            strUpper = strUpper.Replace("亿零万零圆", "亿圆");
            strUpper = strUpper.Replace("零亿零万", "亿");
            strUpper = strUpper.Replace("零万零圆", "万圆");
            strUpper = strUpper.Replace("零亿", "亿");
            strUpper = strUpper.Replace("零万", "万");
            strUpper = strUpper.Replace("零圆", "圆");
            strUpper = strUpper.Replace("零零", "零");

            // 对壹圆以下的金额的处理
            if (strUpper.Substring(0, 1) == "圆")
            {
                strUpper = strUpper.Substring(1, strUpper.Length - 1);
            }
            if (strUpper.Substring(0, 1) == "零")
            {
                strUpper = strUpper.Substring(1, strUpper.Length - 1);
            }
            if (strUpper.Substring(0, 1) == "角")
            {
                strUpper = strUpper.Substring(1, strUpper.Length - 1);
            }
            if (strUpper.Substring(0, 1) == "分")
            {
                strUpper = strUpper.Substring(1, strUpper.Length - 1);
            }
            if (strUpper.Substring(0, 1) == "整")
            {
                strUpper = "零圆整";
            }
            functionReturnValue = strUpper;

            if (IsNegative == true)
            {
                return "负" + functionReturnValue;
            }
            else
            {
                return functionReturnValue;
            }
        }
    }
}
