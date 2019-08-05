using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

        /// <summary>
        /// 部门经理姓名
        /// </summary>
        public string ManagerName { get; set; }

        /// <summary>
        /// 部门副经理
        /// </summary>
        public string AssistantManager { get; set; }

        /// <summary>
        /// 部门副经理
        /// </summary>
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
        /// 创建人姓名
        /// </summary>
        public string CreateUserRealName { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateDatetime { get; set; }

        public bool IsSelected { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }

    public static class DepartmentStringUtil
    {
        /// <summary>
        /// 部门名称字符处理
        /// </summary>
        /// <param name="departments"></param>
        /// <returns></returns>
        public static string ToNameString(this List<Department> departments)
        {
            if (departments != null && departments.Any())
            {
                List<string> names = new List<string>();
                departments.ForEach(c => names.Add(string.Format("{0}-{1}", c.Code, c.Name)));
                return string.Join(",", names.ToArray());
            }
            else
            {
                return string.Empty;
            }
        }
    }

}
