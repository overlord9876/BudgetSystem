using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 实收账款，出纳拿着银行汇款单填写单子，之后让业务员认领。
    /// </summary>
    public class ActualReceipts : IEntity
    {
        /// <summary>
        /// 收款ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 合同号
        /// </summary>
        public string ContractNO { get; set; }

        public Budget RelationBudget { get; set; }

        /// <summary>
        /// 合同ID
        /// </summary>
        public int BudgetID
        {
            get
            {
                if (RelationBudget != null)
                {
                    return RelationBudget.ID;
                }
                return 0;
            }
        }

        /// <summary>
        /// 凭证号
        /// </summary>
        public string VoucherNo { get; set; }

        /// <summary>
        /// 原币金额
        /// </summary>
        public decimal OriginalCoin { get; set; }

        /// <summary>
        /// 人民币
        /// </summary>
        public decimal RMB { get; set; }

        /// <summary>
        /// 原币类型
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// 入账时间
        /// </summary>
        public DateTime ReceiptDate { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTimestamp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DepartmentCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float ExchangeRate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Remitter { get; set; }

    }
}
