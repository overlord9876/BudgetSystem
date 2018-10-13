using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 预算单信息
    /// </summary>
    public class Budget : IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        public string ContractNO { get; set; }

        /// <summary>
        /// 合同状态
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 业务员
        /// </summary>
        public string Salesman { get; set; }

        /// <summary>
        /// 业务员所在部门
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 合同签约时间
        /// </summary>
        public string SignDate { get; set; }

        /// <summary>
        /// 合约有效期
        /// </summary>
        public string Validity { get; set; }

        /// <summary>
        /// 买方名称
        /// </summary>
        public string Purchaser { get; set; }
        /// <summary>
        /// 买方名称1
        /// </summary>
        public string Purchaser1 { get; set; }
        /// <summary>
        /// 买方名称2
        /// </summary>
        public string Purchaser2 { get; set; }
        /// <summary>
        /// 买方名称3
        /// </summary>
        public string Purchaser3 { get; set; }
        /// <summary>
        /// 买方名称4
        /// </summary>
        public string Purchaser4 { get; set; }
        /// <summary>
        /// 买方名称5
        /// </summary>
        public string Purchaser5 { get; set; }
        /// <summary>
        /// 贸易方式
        /// </summary>
        public TradeMode TradeMode { get; set; }
        /// <summary>
        /// 贸易性质
        /// </summary>
        public TradeNature TradeNature { get; set; }

        /// <summary>
        /// 外贸商品详单
        /// </summary>
        public List<Product> OutProductDetail { get; set; }

        /// <summary>
        /// 价格条款
        /// </summary>
        public string PriceClause { get; set; }

        /// <summary>
        /// 交货口岸
        /// </summary>
        public string Seaport { get; set; }

        /// <summary>
        /// 对外结算方式1
        /// </summary>
        public string OutSettlementMethod { get; set; }

        /// <summary>
        /// 对外结算方式2
        /// </summary>
        public string OutSettlementMethod2 { get; set; }

        /// <summary>
        /// 对外结算方式3
        /// </summary>
        public string OutSettlementMethod3 { get; set; }

        /// <summary>
        /// 合同总金额
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 进口国别（目的港）
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 工厂列表
        /// </summary>
        public string Supplier { get; set; }

        /// <summary>
        /// 是否有效合格供方
        /// </summary>
        public bool IsQualifiedSupplier { get; set; }

        /// <summary>
        /// 内贸产品详单
        /// </summary>
        public List<RawMaterial> InProductDetail { get; set; }

        /// <summary>
        /// 对内结算方式1
        /// </summary>
        public string InSettlementMethod1 { get; set; }

        /// <summary>
        /// 对内结算方式2
        /// </summary>
        public string InSettlementMethod2 { get; set; }

        /// <summary>
        /// 预付金额
        /// </summary>
        public decimal AdvancePayment { get; set; }

        /// <summary>
        /// 预付金额银行利率
        /// </summary>
        public float InterestRate { get; set; }

        /// <summary>
        /// 天数（预付）
        /// </summary>
        public int Days { get; set; }

        /// <summary>
        /// 佣金
        /// </summary>
        public decimal Commission { get; set; }

        /// <summary>
        /// 运保费
        /// </summary>
        public decimal Premium { get; set; }

        /// <summary>
        /// 银行费用
        /// </summary>
        public decimal BankCharges { get; set; }

        /// <summary>
        /// 直接费用
        /// </summary>
        public decimal DirectCosts { get; set; }

        /// <summary>
        /// 进料款
        /// </summary>
        public decimal FeedMoney { get; set; }

        /// <summary>
        /// 汇率
        /// </summary>
        public float ExchangeRate { get; set; }
    }

    public enum TradeMode
    {
        一般贸易 = 0,
        来料加工 = 1,
        进料加工 = 2,
        纯进口 = 3,
        内贸 = 4,
    }

    public enum TradeNature
    {
        做单 = 0,
        过单 = 1
    }
}