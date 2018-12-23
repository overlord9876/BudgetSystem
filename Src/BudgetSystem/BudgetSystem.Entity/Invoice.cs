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
        public string ImportUserName { get; set; }

        /// <summary>
        /// 财务导入人姓名
        /// </summary>
        public string FinanceImportUserName { get; set; }

        /// <summary>
        /// 导入时的验证信息
        /// </summary>
        public string Message { get; set; }

       
        /// <summary>
        /// 部门编号（从合同编号中提取）
        /// </summary>
        public string DepartmentCode
        {
            get
            {
                if (!string.IsNullOrEmpty(this.ContractNO) && this.ContractNO.Length > 6)
                {
                    return this.ContractNO.Substring(4, 2);
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName
        {
            get;
            set;
        }

        /// <summary>
        /// 人民币
        /// 人民币销售=ROUND(原币*汇率,2)
        /// </summary>
        public decimal CNY
        {
            get
            {
                return Math.Round(OriginalCoin * (decimal)ExchangeRate, 2);
            }
        }

        /// <summary>
        /// 出口退税
        /// 出口退税=ROUND(税金/ROUND(税金/金额*100,0)*退税率,2)
        /// </summary>
        public decimal TaxRebate
        {
            get
            {
                if (Payment == 0 || TaxAmount == 0)
                {
                    return 0;
                }
                else
                {
                    return Math.Round(TaxAmount / Math.Round(TaxAmount / Payment * 100, 0) * (decimal)TaxRebateRate, 2);
                }
            }
        }

        /// <summary>
        /// 进项转出
        /// 进项转出=IF(退税率=0,0,税金-出口退税)
        /// </summary>
        public decimal IncomeExits
        {
            get
            {
                if (TaxRebateRate == 0)
                {
                    return 0;
                }
                else
                {
                    return TaxAmount - TaxRebate;
                }
            }
        }

        /// <summary>
        /// 应付账款
        /// 应付账款=金额+税额
        /// </summary>
        public decimal AccountsPayable
        {
            get
            {
                return Payment + TaxAmount;
            }
        }
        /// <summary>
        /// 成本(成本=金额+进项转出+进料款) 
        /// </summary>
        public decimal TotalCost
        {
            get
            {
                if (this.TaxRebateRate == 0)
                {
                    return Payment + FeedMoney;
                }
                else
                {
                    return Payment + IncomeExits + FeedMoney ;
                }
            }
        }
        /// <summary>
        /// 毛利
        /// 毛利=人民币销售-成本-佣金
        /// </summary>
        public decimal GrossProfit
        {
            get
            {
                return CNY - TotalCost - Commission;
            }
        }
    }

}
