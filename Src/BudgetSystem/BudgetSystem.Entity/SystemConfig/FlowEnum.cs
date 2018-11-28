using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 流程名称枚举
    /// </summary>
    public enum EnumFlowNames
    {
        预算单审批流程,
        预算单修改流程,
        预算单删除流程,
        供应商审批流程,
        付款审批流程,
        入账审修改批流程
    }

    /// <summary>
    /// 流程数据类型
    /// </summary>
    public enum EnumFlowDataType
    {
        预算单,
        供应商,
        付款单,
        收款单
    }

    /// <summary>
    /// 业务数据流程状态
    /// </summary>
    public enum EnumDataFlowState
    {
        未审批 = -1,//（未加入流程）
        审批中 = 0,
        审批不通过 = 1,//（已关闭）
        审批通过 = 2,//
    }

}
