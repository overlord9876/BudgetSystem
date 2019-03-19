using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 报关单
    /// </summary>
    public class Declarationform : IEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 报关单号
        /// </summary>
        public string NO { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// 出口金额
        /// </summary>
        public decimal ExportAmount { get; set; }

        /// <summary>
        /// 出口时间
        /// </summary>
        public DateTime ExportDate { get; set; }

        /// <summary>
        /// 合同单号
        /// </summary>
        public string ContractNO { get; set; }

        /// <summary>
        /// 合同ID
        /// </summary>
        public int BudgetID { get; set; }

        /// <summary>
        /// 是否已报告延期收款
        /// </summary>
        public bool IsReport { get; set; }

        /// <summary>
        /// 录入人
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 录入人姓名
        /// </summary>
        public string CreateUserRealName { get; set; }

        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 汇率
        /// </summary>
        public float ExchangeRate { get; set; }

        /// <summary>
        /// 验证消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string Name { get; set; } 
    }
}
