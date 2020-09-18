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
        /// 合同ID
        /// </summary>
        public int BudgetID { get; set; }

        /// <summary>
        /// 原币
        /// </summary>
        public decimal OriginalCoin { get; set; }

        /// <summary>
        /// 汇率
        /// </summary>
        public decimal ExchangeRate { get; set; }

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
                if (!string.IsNullOrEmpty(this.ContractNO) && this.ContractNO.Length > 7)
                {
                    return this.ContractNO.Substring(4, 3);
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
        /// 销售成本（成本=金额+佣金(交）+进料款（交））2020-09-01
        /// 销售成本= 金额（不含税金额）+佣金(交）+进料款（交）+进项转出	进项转出，当退税率为0，进项转出为0，当退税率>0，则进项转出为税额-出口退税。2020-09-11
        /// </summary>
        public decimal TotalCost
        {
            get
            {
                if (this.TaxRebateRate == 0)
                {
                    return Payment + Commission + FeedMoney;
                }
                else
                {
                    return Payment + IncomeExits + Commission + FeedMoney;
                }
            }
        }
        /// <summary>        
        /// 销售毛利润=人民币销售-成本-佣金
        /// 销售毛利润=销售金额—销售成本—佣金（交）—进料款（交）2020-7-24文档要求修改。实际是一致的。
        /// 销售毛利润=原币X汇率—销售成本。
        /// </summary>
        public decimal GrossProfit
        {
            get
            {
                return CNY - TotalCost;
            }
        }
    }

    public enum InvoiceViewMode
    {
        部门交单 = 0,
        财务交单 = 1,
        未核销交单 = 2,
        滞期核销交单 = 3
    }
}
