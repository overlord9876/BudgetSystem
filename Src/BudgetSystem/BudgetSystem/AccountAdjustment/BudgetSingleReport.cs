using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem
{
    public class BudgetSingleReport
    {
        /// <summary>
        /// 合同ID
        /// </summary>
        public int BudgetId { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        public string ContractNO { get; set; }

        /// <summary>
        /// 调出，还是跳入
        /// </summary>
        public bool IsOut { get; set; }

        public string Title
        {
            get
            {
                string preix = IsOut ? "调出" : "调入";
                return $"{ContractNO}{preix}";
            }
        }

        /// <summary>
        /// 实收人民币金额
        /// </summary>
        public decimal BillCNY { get; set; }
        /// <summary>
        /// 实收原币金额
        /// </summary>
        public decimal BillOriginalCoin { get; set; }

        /// <summary>
        /// 实付人民币金额
        /// </summary>
        public decimal PaymentCNY { get; set; }

        /// <summary>
        /// 实付原币金额
        /// </summary>
        public decimal PaymentOriginalCoinAfter { get; set; }

        /// <summary>
        /// 实付原币金额
        /// </summary>
        public decimal PaymentOriginalCoin { get; set; }

        /// <summary>
        /// 实付人民币金额
        /// </summary>
        public decimal PaymentCNYAfter { get; set; }

        /// <summary>
        /// 应收原币
        /// </summary>
        public decimal ReceivableOriginalCoin { get; set; }
        /// <summary>
        /// 应收人民币
        /// </summary>
        public decimal ReceivableCNY { get; set; }
        /// <summary>
        /// 应收余额
        /// </summary>
        public decimal BalancePayable { get; set; }
        /// <summary>
        /// 利润差值
        /// </summary>
        public decimal ProfitMargin { get; set; }
        /// <summary>
        /// 销售利润
        /// </summary>
        public decimal SalesProfit { get; set; }
        /// <summary>
        /// 实际利润
        /// </summary>
        public decimal Profit { get; set; }

        /// <summary>
        /// 实收人民币金额
        /// </summary>
        public decimal BillCNYAfter { get; set; }
        /// <summary>
        /// 实收原币金额
        /// </summary>
        public decimal BillOriginalCoinAfter { get; set; }
        /// <summary>
        /// 应收原币
        /// </summary>
        public decimal ReceivableOriginalCoinAfter { get; set; }
        /// <summary>
        /// 应收人民币
        /// </summary>
        public decimal ReceivableCNYAfter { get; set; }
        /// <summary>
        /// 应收余额
        /// </summary>
        public decimal BalancePayableAfter { get; set; }
        /// <summary>
        /// 利润差值
        /// </summary>
        public decimal ProfitMarginAfter { get; set; }
        /// <summary>
        /// 销售利润
        /// </summary>
        public decimal SalesProfitAfter { get; set; }
        /// <summary>
        /// 实际利润
        /// </summary>
        public decimal ProfitAfter { get; set; }

        /// <summary>
        /// 付款原币总计
        /// </summary>
        public decimal PaymentOriginalCoinAmount { get; set; }
        /// <summary>
        /// 付款原币总计
        /// </summary>
        public decimal PaymentOriginalCoinAmountAfter { get; set; }

        /// <summary>
        /// 进料款（交）总计
        /// </summary>
        public decimal FeedMoneyAmount { get; set; }
        /// <summary>
        /// 进料款（交）总计
        /// </summary>
        public decimal FeedMoneyAmountAfter { get; set; }

        /// <summary>
        /// 进料款（付）总计
        /// </summary>
        public decimal PaymentFeedMoneyAmount { get; set; }
        /// <summary>
        /// 进料款（付）总计
        /// </summary>
        public decimal PaymentFeedMoneyAmountAfter { get; set; }
        /// <summary>
        /// 佣金（交）总计
        /// </summary>
        public decimal CommissionAmount { get; set; }
        /// <summary>
        /// 佣金（交）总计
        /// </summary>
        public decimal CommissionAmountAfter { get; set; }

        /// <summary>
        /// 佣金（付）总计
        /// </summary>
        public decimal PaymentCommissionAmount { get; set; }
        /// <summary>
        /// 佣金（付）总计
        /// </summary>
        public decimal PaymentCommissionAmountAfter { get; set; }

        /// <summary>
        /// 直接费用（付）总计
        /// </summary>
        public decimal DirectCostsAmount { get; set; }
        /// <summary>
        /// 直接费用（付）总计
        /// </summary>
        public decimal DirectCostsAmountAfter { get; set; }


        public BudgetSingleReport()
        {

        }
    }
}
