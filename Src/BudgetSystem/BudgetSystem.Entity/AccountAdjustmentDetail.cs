using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 调账详情
    /// </summary>
    public class AccountAdjustmentDetail : IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        public int PID { get; set; }

        /// <summary>
        /// 关联ID
        /// </summary>
        public int RelationID { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        public int BudgetID { get; set; }

        /// <summary>
        /// 合同号。
        /// </summary>
        public string ContractNO { get; set; }

        /// <summary>
        /// 调账类型
        /// </summary>
        public AdjustmentType Type { get; set; }

        /// <summary>
        /// 原币金额
        /// </summary>
        public decimal OriginalCoin { get; set; }

        /// <summary>
        ///金额，从收款、付款单中带出来。
        /// </summary>
        public decimal CNY { get; set; }

        /// <summary>
        /// 汇率
        /// </summary>
        public decimal ExchangeRate { get; set; }

        public string Currency { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string OperatorRealName { get; set; }

        /// <summary>
        /// 编辑方式
        /// </summary>
        public DataOperatorModel OperatorModel { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// 是否已经确认。
        /// </summary>
        public bool Confirmed { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperatorDate { get; set; }

        /// <summary>
        /// 已收供方发票
        /// </summary>
        public decimal Payment { get; set; }

        /// <summary>
        /// 税额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 退税率
        /// </summary>
        public decimal TaxRebateRate { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// 进料款
        /// </summary>
        public decimal FeedMoney { get; set; }

        private Budget _relationBudget;

        /// <summary>
        /// 关联合同。
        /// </summary>
        public Budget RelationBudget
        {
            get { return this._relationBudget; }
            set
            {
                this._relationBudget = value;
                if (this._relationBudget != null)
                {
                    BudgetID = this._relationBudget.ID;
                }
                else { BudgetID = -1; }
            }
        }

        /// <summary>
        /// 付款用途
        /// </summary>
        public string MoneyUsed { get; set; }

        /// <summary>
        /// 是否退税
        /// </summary>
        public bool IsDrawback { get; set; }

        public decimal VatOption { get; set; }

        /// <summary>
        /// 余额
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// 去税金额
        /// </summary>
        public decimal DeTaxationCNY
        {
            get
            {
                if (IsDrawback)
                {
                    return CNY - Math.Round(CNY / (1 + VatOption / 100) * (TaxRebateRate / 100), 2);
                }
                else
                {
                    return CNY;
                }
            }
        }

        public DateTime Date { get; set; }
    }

}
