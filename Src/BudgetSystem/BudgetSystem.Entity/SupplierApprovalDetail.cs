using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 供应商表审批表
    /// </summary>
    public class SupplierApprovalDetail : IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 供应商ID
        /// </summary>
        public string SupplierID { get; set; }

        /// <summary>
        /// 顺序号
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 审批人
        /// </summary>
        public string Approver { get; set; }

        /// <summary>
        /// 审批结果
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 是否当前轮次
        /// </summary>
        public int IsCurrentRounds { get; set; }

        /// <summary>
        /// 审批时间。
        /// </summary>
        public DateTime ApprovalTime { get; set; }
    }
}
