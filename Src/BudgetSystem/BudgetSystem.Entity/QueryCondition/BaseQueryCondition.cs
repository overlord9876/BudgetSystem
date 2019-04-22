using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity.QueryCondition
{
    public class BaseQueryCondition
    {
        public string Name
        {
            get;
            set;
        }

        public override string ToString()
        {
            return this.Name;
        }

        /// <summary>
        /// 所在部门
        /// </summary>
        public int DeptID { get; set; }

        /// <summary>
        /// 业务员
        /// </summary>
        public string Salesman { get; set; }

    }

}
