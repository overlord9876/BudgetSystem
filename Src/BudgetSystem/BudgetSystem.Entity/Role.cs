using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class Role : IEntity
    {
        /// <summary>
        /// 角色标识
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 角色描述
        /// </summary>
        public string Remark { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

    }
}
