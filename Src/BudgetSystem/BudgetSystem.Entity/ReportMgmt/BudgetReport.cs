using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BudgetSystem.Entity
{
    public class BudgetReport
    {
        /// <summary>
        /// 合同ID号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 合同号
        /// </summary>
        public string ContractNO { get; set; }

        private int state = 0;
        /// <summary>
        /// 状态
        /// </summary>
        public int State
        {
            get
            {
                return state;
            }
            set
            {
                this.state = value;
            }
        }

        /// <summary>
        /// 枚举状态
        /// </summary>
        public EnumBudgetState EnumState
        {
            get { return this.State.ToEnumBudgetState(); }
        }

        /// <summary>
        /// 字符串状态
        /// </summary>
        public string StringState
        {
            get { return this.state.ToStringEnumBudgetState(); }
        }

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
        /// 一般贸易 = 1
        /// 来料加工 = 2
        /// 进料加工 = 4
        /// 纯进口 = 8
        /// 内贸 = 12
        /// </summary>
        public int TradeMode { get; set; }

        /// <summary>
        /// 做单=1
        /// 过单=2
        /// </summary>
        public int TradeNature { get; set; }

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
        /// 外贸商品详单
        /// </summary>
        public string OutProductDetail { get; set; }
        /// <summary>
        /// 外贸商品详单
        /// </summary>
        public List<OutProductDetail> OutProductList
        {
            get
            {
                if (!string.IsNullOrEmpty(this.OutProductDetail))
                {
                    return this.OutProductDetail.ToObjectList<List<OutProductDetail>>();
                }
                else
                {
                    return new List<OutProductDetail>();
                }
            }
        }

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
        /// 银行费用
        /// </summary>
        public decimal BankCharges { get; set; }

        /// <summary>
        /// 直接费用
        /// </summary>
        public decimal DirectCosts
        {
            get
            {
                if (PaymentList != null)
                {
                    return PaymentList.Where(o => Util.DirectCostsTextList.Contains(o.MoneyUsed)).Sum(o => o.CNY);
                }
                else { return 0; }
            }
        }

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
        /// 盈利水平2
        /// </summary>
        public decimal ProfitLevel2 { get; set; }

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
        ///  出口退税
        /// </summary>
        public decimal TaxRebate { get; set; }

        /// <summary>
        /// 总进价
        /// </summary>
        public decimal PurchasePrice { get; set; }

        /// <summary>
        /// 美元合同金额
        /// </summary>
        public decimal USDTotalAmount { get; set; }

        /// <summary>
        /// 增值税税率
        /// </summary>
        public decimal VATRate { get; set; }

        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// 更新用户
        /// </summary>
        public string UpdateUser { get; set; }

        /// <summary>
        /// 更新用户名
        /// </summary>
        public string UpdateUserName { get; set; }

        /// <summary>
        /// 主客户国家/地区
        /// </summary>
        public string CustomerCountry { get; set; }

        /// <summary>
        /// 贸易方式描述
        /// </summary>
        public string TradeModeDesc
        {
            get
            {
                if (this.TradeMode == 0)
                {
                    return string.Empty;
                }
                else
                {
                    return ((EnumTradeMode)Enum.Parse(typeof(EnumTradeMode), this.TradeMode.ToString())).ToString();
                }
            }
        }

        /// <summary>
        /// 总成本
        /// </summary>
        public decimal TotalCost
        {
            get
            {
                return PurchasePrice - TaxRebate;
            }
        }

        public List<PaymentNotes> PaymentList { get; set; }

        /// <summary>
        /// 运保费
        /// </summary>
        public decimal Premium
        {
            get
            {
                if (PaymentList != null)
                {
                    return PaymentList.Where(o => Util.PremiumTextList.Contains(o.MoneyUsed)).Sum(o => o.CNY);
                }
                else { return 0; }
            }
        }

        /// <summary>
        /// 运保费成本,去税运保费金额
        /// </summary>
        public decimal PremiumCost
        {
            get
            {
                if (PaymentList != null)
                {
                    return PaymentList.Where(o => Util.PremiumTextList.Contains(o.MoneyUsed)).Sum(o => o.DeTaxationCNY);
                }
                else { return 0; }
            }
        }

        /// <summary>
        /// 佣金
        /// </summary>
        public decimal Commission
        {
            get
            {
                if (PaymentList != null)
                {
                    return PaymentList.Where(o => Util.CommissionUsageNameList.Contains(o.MoneyUsed)).Sum(o => o.CNY);
                }
                else { return 0; }
            }
        }

        /// <summary>
        /// 付款金额
        /// </summary>
        public decimal TotalPayement
        {
            get
            {
                if (PaymentList != null)
                {
                    return PaymentList.Where(o => !Util.PremiumTextList.Contains(o.MoneyUsed) && !Util.CommissionUsageNameList.Contains(o.MoneyUsed)).Sum(o => o.CNY);
                }
                else { return 0; }
            }
        }

        /// <summary>
        /// 销售成本（人民币￥）,等于付款去税金额
        /// </summary>
        public decimal SellingCost
        {
            get
            {
                if (PaymentList != null)
                {
                    return PaymentList.Where(o => !Util.PremiumTextList.Contains(o.MoneyUsed) && !Util.CommissionUsageNameList.Contains(o.MoneyUsed) && !Util.DirectCostsTextList.Contains(o.MoneyUsed)).Sum(o => o.DeTaxationCNY);
                }
                else { return 0; }
            }
        }

        public List<Invoice> InvoiceList { get; set; }

        /// <summary>
        /// 销售金额，等于所有发票金额
        /// </summary>
        public decimal TotalInvoice
        {
            get
            {
                if (InvoiceList != null)
                {
                    return InvoiceList.Sum(o => o.CNY);
                }
                else { return 0; }
            }
        }

        public decimal SupplierInvoice
        {
            get
            {
                if (InvoiceList != null)
                {
                    return InvoiceList.Sum(o => o.FeedMoney + o.Commission);
                }
                else { return 0; }
            }
        }

        public List<BudgetBill> BudgetBillList { get; set; }
        public decimal TotalBudgetBill
        {
            get
            {
                if (BudgetBillList != null)
                {
                    return BudgetBillList.Sum(o => o.CNY);
                }
                else { return 0; }
            }
        }

        public decimal TotalUSDBudgetBill
        {
            get
            {
                if (ExchangeRate != 0)
                {
                    return Math.Round(TotalBudgetBill / (decimal)ExchangeRate, 2);
                }
                else { return 0; }
            }
        }

        public List<Declarationform> DeclarationformList { get; set; }
        public decimal TotalDeclarationform
        {
            get
            {
                if (DeclarationformList != null && ExchangeRate != 0)
                {
                    decimal originalExchangeRate = 0;//预算单原币汇率，取外贸部门商品的第一条商品信息原币汇率
                    if (OutProductList.Count > 0)
                    {
                        originalExchangeRate = OutProductList[0].ExchangeRate;
                    }
                    return Math.Round(DeclarationformList.Sum(o => o.ExportAmount) * originalExchangeRate / (decimal)ExchangeRate, 2);
                }
                else { return 0; }
            }
        }

        public decimal SalesProfit
        {
            get
            {
                return TotalInvoice - SellingCost - Premium - Commission - DirectCosts;
            }
        }


        public decimal ActualProfit
        {
            get
            {
                return TotalBudgetBill - SellingCost - Premium - Commission - DirectCosts;
            }
        }
    }
}
