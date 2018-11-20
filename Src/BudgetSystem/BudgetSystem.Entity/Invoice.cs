using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 发票表
    /// </summary>
    public class Invoice : IEntity
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 发票号
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 发票代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 合同号
        /// </summary>
        public string ContractNO { get; set; }

        /// <summary>
        /// 原币
        /// </summary>
        public decimal OriginalCoin { get; set; }

        /// <summary>
        /// 汇率
        /// </summary>
        public float ExchangeRate { get; set; }

        /// <summary>
        /// 报关单
        /// </summary>
        public string CustomsDeclaration { get; set; }

        /// <summary>
        /// 退税率
        /// </summary>
        public float TaxRebateRate { get; set; }

        /// <summary>
        /// 佣金
        /// </summary>
        public decimal Commission { get; set; }

        /// <summary>
        /// 进料款
        /// </summary>
        public decimal FeedMoney { get; set; }

        /// <summary>
        /// 销方税号
        /// </summary>
        public string TaxpayerID { get; set; }

        /// <summary>
        /// 销方名称
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Payment { get; set; }

        /// <summary>
        /// 税额
        /// </summary>
        public decimal TaxAmount { get; set; }

        /// <summary>
        /// 导入人
        /// </summary>
        public string ImportUser { get; set; }

        /// <summary>
        /// 导入日期
        /// </summary>
        public DateTime ImportDate { get; set; }

        /// <summary>
        /// 财务导入人
        /// </summary>
        public string FinanceImportUser { get; set; }

        /// <summary>
        /// 财务导入日期
        /// </summary>
        public DateTime? FinanceImportDate { get; set; }

        /// <summary>
        /// 导入人姓名
        /// </summary>
        public string ImportUserName{get;set;}

        /// <summary>
        /// 财务导入人姓名
        /// </summary>
        public string FinanceImportUserName { get; set; }

        /// <summary>
        /// 导入时的验证信息
        /// </summary>
        public string Message { get; set; }
    }

}
