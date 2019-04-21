using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity.QueryCondition
{
    /// <summary>
    /// 预算单查询条件
    /// </summary>
    public class BudgetQueryCondition : BaseQueryCondition
    {
        /// <summary>
        /// 业务员
        /// </summary>
        public string Salesman { get; set; }

        /// <summary>
        /// 合同号
        /// </summary>
        public string ContractNO { get; set; }

        /// <summary>
        /// 所在部门
        /// </summary>
        public int DeptID { get; set; }

        /// <summary>
        /// 主客户名称
        /// </summary>
        public string CustomerName { get; set; }

        private bool isGeneralManagerApproval = false;
        /// <summary>
        /// 是否总经理审批查询 
        /// </summary>
        public bool IsGeneralManagerApproval
        {
            get { return isGeneralManagerApproval; }
            set { isGeneralManagerApproval = value; }
        }
        private bool isManagerApproval = false;

        /// <summary>
        /// 是否部门经理审批查询 
        /// </summary>
        public bool IsManagerApproval
        {
            get { return isManagerApproval; }
            set { isManagerApproval = value; }
        }
        private EnumBudgetState state = (EnumBudgetState)(-1);

        /// <summary>
        /// 状态
        /// </summary>
        public EnumBudgetState State
        {
            get { return state; }
            set { state = value; }
        }
        private bool isArchiveWarningQuery = false;

        /// <summary>
        /// 是否归档预警查询 
        /// </summary>
        public bool IsArchiveWarningQuery
        {
            get { return isArchiveWarningQuery; }
            set { isArchiveWarningQuery = value; }
        }

        public DateTime BeginTimestamp { get; set; }
        public DateTime EndTimestamp { get; set; }

        public BudgetQueryCondition()
        {
            BeginTimestamp = DateTime.MinValue;
            EndTimestamp = DateTime.MinValue;
            DeptID = -1;
        }

    }
}
