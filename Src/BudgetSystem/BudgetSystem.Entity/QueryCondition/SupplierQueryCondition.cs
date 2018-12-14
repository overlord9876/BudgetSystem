using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity.QueryCondition
{
    /// <summary>
    /// 供应商查询条件
    /// </summary>
    public class SupplierQueryCondition : BaseQueryCondition
    {
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string SupplierName { get; set; }

        private int supplierType = -1;
        /// <summary>
        /// 供应商类型
        /// 0=合格供方
        /// 1=临时供方
        /// 2=其它供方
        /// </summary>
        public int SupplierType
        {
            get
            {
                return supplierType;
            }
            set
            {
                supplierType = value;
            }
        }

        /// <summary>
        /// 所属部门
        /// </summary>
        public string Department { get; set; }
    }
}
