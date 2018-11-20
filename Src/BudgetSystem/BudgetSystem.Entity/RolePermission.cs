using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 角色权限
    /// </summary>
    public class RolePermission : IEntity
    {
        /// <summary>
        /// 角色标识
        /// </summary>
        public string RoleCode { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        public string Permission { get; set; }

    }
}
