using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;

namespace BudgetSystem.WorkSpace
{
    public static class FlowRunStateTranslator
    {
        public static bool Translate(this FlowRunState state, out string info)
        {
            bool result = false;
            info = "";
            switch (state)
            {
                case FlowRunState.启动流程成功:
                    result = true;
                    info = "启动流程成功";
                    break;
                case FlowRunState.数据项已正在:
                    info = "提交流程失败，当前数据项的流程已存在，不可以发起重复审批";
                    break;
                case FlowRunState.流程未配置审批过程:
                    info = "提交流程失败，当前流程未配置，请先配置审批流程";
                    break;
                case FlowRunState.流程发起人未配置部门:
                    info = "提交流程失败，创建下一审批节点时，未能找到创建人部门，无法确认审批责任人";
                    break;
                case FlowRunState.创建运行点成功:
                    result = true;
                    info = "提交成功";
                    break;
                case FlowRunState.流程审批完成:
                    result = true;
                    info = "审批完成";
                    break;
                case FlowRunState.提交的流程节点已审批过了:

                    info = "提交流程失败，当前提交的审批已被审批过了，请刷新数据";
                    break;
                case FlowRunState.确认的流程实例已经确认过了:
                    info = "确认失败，当前确认的流程已被确认过了，请刷新数据";
                    break;
                case FlowRunState.确认的流程实例未审批完成:
                    info = "确认失败，当前确认的流程还未被审批完成";
                    break;
                case FlowRunState.确认成功:
                    result = true;
                    info = "确认成功";
                    break;
            }
            return result;

        }

    }
}
