using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;

namespace BudgetSystem
{
    public class FlowApproveDisplayHelper
    {
        public static void SetFlowItemInstanceStateWithEmptyStateDisplayName(FlowItem item)
        {
            item.InstanceStateWithEmptyState = item.IsClosed ? (item.ApproveResult ? RunInfo.Instance.FlowAppreveNameConfigs.GetDisplayAcceptName(item.FlowName) : RunInfo.Instance.FlowAppreveNameConfigs.GetDisplayRefuseName(item.FlowName)) : ""; ;
        }

        public static void SetRunPointFlowNodeApproveResultWithStateDisplayName(FlowRunPoint point,string flowName)
        {
            point.NodeApproveResultWithState = point.State ? (point.NodeApproveResult ? RunInfo.Instance.FlowAppreveNameConfigs.GetDisplayAcceptName(flowName) : RunInfo.Instance.FlowAppreveNameConfigs.GetDisplayRefuseName(flowName)) : ""; ;
        }

    }
}
