using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity.QueryCondition
{
    public class VoucherNotesQueryCondition : BaseQueryCondition
    {
        /// <summary>
        /// 预算单ID
        /// </summary>
        public int BudgetId { get; set; }

        /// <summary>
        /// 出口开始日期
        /// </summary>
        public DateTime ExportBeginDate { get; set; }
        /// <summary>
        /// 出口结束日期
        /// </summary>
        public DateTime ExportEndDate { get; set; }

        /// <summary>
        /// 贸易方式
        /// </summary>
        public string TradeMode { get; set; }

        /// <summary>
        /// 最终目的国地区（贸易国别地区）
        /// </summary>
        public string FinalCountry { get; set; }

        public VoucherNotesQueryCondition()
        {
            BudgetId = -1;
            ExportBeginDate = DateTime.MinValue;
            ExportEndDate = DateTime.MinValue;
        }
    }
}
