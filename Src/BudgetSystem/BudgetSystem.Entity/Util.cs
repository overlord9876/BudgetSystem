using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    public static class Util
    {

        public static EnumDataFlowState ToEnumDataFlowState(this int flowState)
        {
            switch (flowState)
            {
                case 0:
                    return EnumDataFlowState.审批中;
                case 1:
                    return EnumDataFlowState.审批不通过;
                case 2:
                    return EnumDataFlowState.审批通过;
                default:
                    return EnumDataFlowState.未审批;
            }
        }

        public static string ToEnumDataFlowState(this int flowState, string defaultString)
        {
            switch (flowState)
            {
                case 0:
                    return EnumDataFlowState.审批中.ToString();
                case 1:
                    return EnumDataFlowState.审批不通过.ToString();
                case 2:
                    return EnumDataFlowState.审批通过.ToString();
                default:
                    return defaultString;
            }
        }
        public static EnumBudgetState ToEnumBudgetState(this int budgetState)
        {
            return (EnumBudgetState)budgetState;
        }
        public static string ToStringEnumBudgetState(this int budgetState)
        {
            return ToEnumBudgetState(budgetState).ToString();
        }
        public static T ToObjectList<T>(this string bankInfoJson)
        {
            if (!string.IsNullOrEmpty(bankInfoJson))
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(bankInfoJson);
            }
            else
            {
                return default(T);
            }
        }

        public static string ToJson<T>(this T obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 运保费类型
        /// </summary>
        public static List<string> PremiumTextList = new List<string>() { "运杂费", "运保费" };

        /// <summary>
        /// 佣金类型
        /// </summary>
        public static List<string> CommissionUsageNameList = new List<string>() { "佣金", "咨询费", "服务费", "费用支付审批单" };
        
        /// <summary>
        /// 直接费用类型
        /// </summary>
        public static List<string> DirectCostsTextList = new List<string>() { "海关关税","海关增值税","海关保证金","快递费","其他" };
    }
}
