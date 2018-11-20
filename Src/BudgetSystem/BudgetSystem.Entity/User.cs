using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class User : IEntity
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 用户角色
        /// </summary>
        public string Role { get; set; }

        public string RoleName { get; set; }

        /// <summary>
        /// 所属部门
        /// </summary>
        public string Department { get; set; }

        public string DepartmentName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public bool State { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateDateTime { get; set; }

        public bool IsSelected { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}]-[{1}]", RealName, UserName);
        }
    }
}
