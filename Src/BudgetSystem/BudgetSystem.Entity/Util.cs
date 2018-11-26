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

        public static List<BankInfo> ToBankInfoList(this string bankInfoJson)
        {
            if (!string.IsNullOrEmpty(bankInfoJson))
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<BankInfo>>(bankInfoJson);
            }
            else
            {
                return new List<BankInfo>();
            }
        }

        public static string ToJson<T>(this T obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

    }
}
