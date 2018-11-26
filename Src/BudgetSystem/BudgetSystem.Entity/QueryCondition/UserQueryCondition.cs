using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity.QueryCondition
{
    public class UserQueryCondition:BaseQueryCondition
    {
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string RoleCode { get; set; }
        public string DepartmentCode { get; set; }
    }
}
