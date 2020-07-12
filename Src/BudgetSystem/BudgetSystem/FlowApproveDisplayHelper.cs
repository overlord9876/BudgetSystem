using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BudgetSystem.Entity;

namespace BudgetSystem
{
    public class FlowApproveDisplayHelper
    {
        public static void SetFlowItemInstanceStateWithEmptyStateDisplayName(FlowItem item)
        {
            item.InstanceStateWithEmptyState = item.IsClosed ? (item.ApproveResult ? RunInfo.Instance.FlowAppreveNameConfigs.GetDisplayAcceptName(item.FlowName) : RunInfo.Instance.FlowAppreveNameConfigs.GetDisplayRefuseName(item.FlowName)) : ""; ;
        }

        public static void SetRunPointFlowNodeApproveResultWithStateDisplayName(FlowRunPoint point, string flowName)
        {
            point.NodeApproveResultWithState = point.State ? (point.NodeApproveResult ? RunInfo.Instance.FlowAppreveNameConfigs.GetDisplayAcceptName(flowName) : RunInfo.Instance.FlowAppreveNameConfigs.GetDisplayRefuseName(flowName)) : ""; ;
        }

        public static string GetRunPointFlowNodeApproveResultWithStateDisplayName(FlowRunPoint point)
        {
            return point.NodeApproveResultWithState = point.State ? (point.NodeApproveResult ? RunInfo.Instance.FlowAppreveNameConfigs.GetDisplayAcceptName(point.FlowName) : RunInfo.Instance.FlowAppreveNameConfigs.GetDisplayRefuseName(point.FlowName)) : point.CloseReason; ;
        }

        public static string GetRunPointFlowNodeApproveResultWithStateDisplayName(List<FlowRunPoint> runPoints)
        {
            return string.Join("\r\n", runPoints.Select(o => string.Format("{0}|{1}【{2}】{3}【{4}】{5}", o.NodeApproveDate.ToString("yyyy-MM-dd hh:mm:ss"), o.NodeValueRemark, o.RealName, GetFlowStateDisplayName(o), o.FlowName, o.NodeApproveRemark)).ToArray());
            //return string.Join("\r\n", runPoints.Select(o => string.Format("{0}{1}【{2}】{3}", o.NodeApproveDate.ToString("yyyy-MM-dd hh:mm:ss"), o.NodeValueRemark, o.RealName, FlowApproveDisplayHelper.GetRunPointFlowNodeApproveResultWithStateDisplayName(o))).ToArray());
        }

        public static void SetRunPointFlowNodeApproveResultWithStateDisplayName(FlowRunPoint point)
        {
            SetRunPointFlowNodeApproveResultWithStateDisplayName(point, string.Empty);
        }

        private static string GetFlowStateDisplayName(FlowRunPoint o)
        {
            if (o.State)
            {
                if (o.NodeApproveResult)
                {
                    return RunInfo.Instance.FlowAppreveNameConfigs.GetDisplayAcceptName(o.FlowName);
                }
                else
                {
                    return RunInfo.Instance.FlowAppreveNameConfigs.GetDisplayRefuseName(o.FlowName) + " " + o.NodeApproveRemark;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(o.CloseReason))
                {
                    return "待审批";
                }
                else
                {
                    return o.CloseReason;
                }
            }
        }

    }
}
