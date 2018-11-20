using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    public class FlowConst
    {
        public const string FlowCreateUser = "%StartUser%";
        public const string FlowCreateUserDisplayName = "流程发起人";
        public const string FlowCreateUserDepartment = "%StartUserDepartment%";
        public const string FlowCreateUserDepartmentDisplayName = "流程发起人所在部门";
        public const string FlowNotApprovedMessage = "审批不通过";
        public const string FlowApprovedMessage = "审批通过";
        public const string FlowUserNotConfigDepartmentMessage = "流转失败，流程发起人未配置部门，无法定位审批人";
    }

   
}
