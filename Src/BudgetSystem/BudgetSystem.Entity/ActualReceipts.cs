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
        /// 拆分来源ID
        /// </summary>
        public int SourceID { get; set; }

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
        /// 关联业务员
        /// </summary>
        public List<User> Sales
        {
            get;
            set;
        }

        /// <summary>
        /// 凭证号
        /// </summary>
        public string VoucherNo { get; set; }

        /// <summary>
        /// 交易附言
        /// </summary>
        public string TradingPostscript { get; set; }


        public int ReceiptType { get; set; }

        /// <summary>
        /// 原币金额
        /// </summary>
        public decimal OriginalCoin { get; set; }

        /// <summary>
        /// 人民币
        /// </summary>
        public decimal CNY { get; set; }

        /// <summary>
        /// 未拆分原币金额
        /// </summary>
        public decimal OriginalCoin2 { get; set; }

        /// <summary>
        /// 未拆分人民币金额
        /// </summary>
        public decimal CNY2 { get; set; }

        /// <summary>
        /// 原币类型
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// 入账单状态
        /// 入账 = 0,
        /// 待拆分 = 1,
        /// 已拆分 = 2,
        /// 关联合同 = 3,
        /// 作废 = 4
        /// </summary>
        public int State { get; set; }

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

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// 拆分操作人
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperateTimestamp { get; set; }
    }

    public enum ReceiptState : int
    {
        入账 = 0,
        待拆分 = 1,
        已拆分 = 2,
        关联合同 = 3,
        作废 = 4

    }
}
