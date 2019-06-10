using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 供应商初审内容
    /// </summary>
    public class SupplierFirstReviewContents
    {
        /// <summary>
        /// 评审项
        /// </summary>
        public Dictionary<string, int> ReviewItems { get; set; }

        /// <summary>
        /// 评审结论
        /// </summary>
        public int Result { get; set; }

        /// <summary>
        /// 业务员
        /// </summary>
        public string Salesman { get; set; }


        /// <summary>
        /// 业务员结论
        /// </summary>
        public int SalesmanResult { get; set; }
       
        /// <summary>
        /// 部门经理
        /// </summary>
        public string Manager { get; set; }
      
        /// <summary>
        /// 部门经理结论
        /// </summary>
        public int ManagerResult { get; set; }
      
        /// <summary>
        /// 评审组长
        /// </summary>
        public string Leader { get; set; }
      
        /// <summary>
        /// 评审组长结果 
        /// </summary>
        public int LeaderResult { get; set; }
        
        /// <summary>
        /// 结论日期
        /// </summary>
        public DateTime? ResultDate { get; set; }

        public SupplierFirstReviewContents()
        {
            ReviewItems = new Dictionary<string, int>();
        }
    }
}
