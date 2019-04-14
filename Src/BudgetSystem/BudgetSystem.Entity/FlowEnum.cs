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
        付款审批流程,
        入账审修改批流程,
        预算单删除流程,
        预算单修改流程
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

    public class EnumCheckUtil
    {
        public static string CheckCurrentFlowStart(EnumFlowNames currentFlowName, EnumFlowNames oldFlowName, EnumDataFlowState oldFlowState)
        {
            if (currentFlowName == oldFlowName && oldFlowState == EnumDataFlowState.审批通过)
            {
                return string.Format("{0}已经{1},不允许重复提交", currentFlowName, oldFlowState);
            }
            if (currentFlowName == EnumFlowNames.预算单审批流程)
            {
                if ((oldFlowName == EnumFlowNames.预算单修改流程 || oldFlowName == EnumFlowNames.预算单删除流程) && oldFlowState == EnumDataFlowState.审批不通过)//预算单修改流程或预算单删除被驳回，实际上就是预算单审批通过状态
                {
                    return string.Format("{0}已经{1},不允许再次提交{2}", oldFlowName, oldFlowState, currentFlowName);
                }
                else if (oldFlowName == EnumFlowNames.预算单删除流程 && oldFlowState == EnumDataFlowState.审批通过)
                {
                    return string.Format("{0}已经{1},不允许再次提交{2}", oldFlowName, oldFlowState, currentFlowName);
                }
            }
            else if (currentFlowName == EnumFlowNames.预算单修改流程)
            {
                if (oldFlowName == EnumFlowNames.预算单审批流程 && oldFlowState == EnumDataFlowState.审批不通过)//预算单修改流程被驳回，实际上就是预算单审批通过状态
                {
                    return string.Format("{0}已经{1},不允许再次提交{2}", oldFlowName, oldFlowState, currentFlowName);
                }
                else if (oldFlowName == EnumFlowNames.预算单删除流程 && oldFlowState == EnumDataFlowState.审批通过)//预算单已经通过删除流程，不允许再提交修改审批。
                {
                    return string.Format("{0}已经{1},不允许再次提交{2}", oldFlowName, oldFlowState, currentFlowName);
                }
            }
            else if (currentFlowName == EnumFlowNames.预算单删除流程)
            {
                //应该任何时候都可以提出删除流程？
            }
            return string.Empty;
        }
    }


}
