using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 预算单
    /// </summary>
    public class Budget : IEntity
    {
        /// <summary>
        /// 合同ID号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 合同号
        /// </summary>
        public string ContractNO { get; set; }

        /// <summary>
        /// 状态
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
        /// 录入时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 订约日期
        /// </summary>
        public DateTime SignDate { get; set; }

        /// <summary>
        /// 有效截止期
        /// </summary>
        public DateTime Validity { get; set; }

        /// <summary>
        /// 0=一般贸易
        /// 1=来料加工
        /// 2=进料加工
        /// 3=纯进口
        /// 4=内贸
        /// </summary>
        public int TradeMode { get; set; }

        /// <summary>
        /// 0=做单
        /// 1=过单
        /// </summary>
        public int TradeNature { get; set; }

        /// <summary>
        /// 外贸商品详单
        /// </summary>
        public string OutProductDetail { get; set; }

        /// <summary>
        /// 价格条款
        /// </summary>
        public string PriceClause { get; set; }



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
        /// 合同金额？
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 进口国别（目的港）
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 是否要求合格供方
        /// </summary>
        public bool IsQualifiedSupplier { get; set; }

        /// <summary>
        /// 内贸产品详单
        /// </summary>
        public string InProductDetail { get; set; }


        /// <summary>
        /// 预付金额
        /// </summary>
        public decimal AdvancePayment { get; set; }

        /// <summary>
        /// 是否有预付款
        /// </summary>
        public bool HasAdvancePayment
        {
            get
            {
                return AdvancePayment > 0;
            }
        }

        /// <summary>
        /// 利率
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

        /// <summary>
        /// 利润
        /// </summary>
        public decimal Profit { get; set; }

        /// <summary>
        /// 流程状态
        /// </summary>
        public int FlowState { get; set; }



        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 业务员姓名
        /// </summary>
        public string SalesmanName { get; set; }

        /// <summary>
        /// 部门描述
        /// </summary>
        public string DepartmentDesc
        {
            get { return this.Department + this.DepartmentName; }
        }
        /// <summary>
        /// 客户编号
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// 目的港口
        /// </summary>
        public string Port { get; set; }

        /// <summary>
        ///  出口退税
        /// </summary>
        public decimal TaxRebate { get; set; }

        /// <summary>
        /// 总进价
        /// </summary>
        public decimal PurchasePrice { get; set; }

        /// <summary>
        /// 主客户名称
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 客户列表
        /// </summary>
        public List<Customer> CustomerList { get; set; }

        /// <summary>
        /// 供应商列表
        /// </summary>
        public List<Supplier> SupplierList { get; set; }

        /// <summary>
        /// 流程状态
        /// </summary>
        public EnumDataFlowState EnumFlowState
        {
            get
            {
                return this.FlowState.ToEnumDataFlowState();
            }
        }

        public override string ToString()
        {
            return string.Format("{0}", ContractNO);
        }
    }


    public enum EnumTradeMode : int
    {
        一般贸易 = 0,
        来料加工 = 1,
        进料加工 = 2,
        纯进口 = 3,
        内贸 = 4,
    }

    public enum EnumTradeNature : int
    {
        做单 = 0,
        过单 = 1
    }
}