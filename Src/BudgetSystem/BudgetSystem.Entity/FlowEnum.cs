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
        供应商审批流程,
        付款审批流程
    }

    /// <summary>
    /// 流程数据类型
    /// </summary>
    public enum EnumFlowDataType
    {
        预算单,
        供应商,
        付款单
    }
}
