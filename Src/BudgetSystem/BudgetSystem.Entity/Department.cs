using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 部门表
    /// </summary>
    public class Department : IEntity
    {
        /// <summary>
        /// 主键标识
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 标识
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 部门经理
        /// </summary>
        public string Manager { get; set; }

        public string MaangerName { get; set; }

        /// <summary>
        /// 部门副经理
        /// </summary>
        public string AssistantManager { get; set; }

        public string AssistantManagerName { get; set; }


        /// <summary>
        /// 描述
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateDatetime { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

    }
}
