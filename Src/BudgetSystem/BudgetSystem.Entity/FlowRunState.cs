using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    public enum FlowRunState
    {
        启动流程成功,
        数据项已正在,
        流程未配置审批过程,
        流程发起人未配置部门,
        创建运行点成功,
        流程审批完成,
        提交的流程节点已审批过了,
        确认的流程实例已经确认过了,
        确认的流程实例未审批完成,
        确认成功,
        撤回的流程实例已经审批完成了,
        撤回的流程实例已经有人审批过了,
        撤回成功,
        最后一个审批不是当前用户,
    }

}
