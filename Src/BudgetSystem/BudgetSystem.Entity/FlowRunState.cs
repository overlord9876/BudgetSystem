using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    public enum FlowRunState
    {
        启动成功,
        存在未完成的实例,
        流程未配置审批过程,
        流程发起人未配置部门,
        创建运行点成功,
        流程审批完成,
        提交的流程节点已审批过了,
        确认的流程实例已经确认过了,
        确认的流程实例未审批完成,
        确认成功,
    }
}
