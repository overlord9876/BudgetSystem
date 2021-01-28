using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 报关单
    /// </summary>
    public class Declarationform : IEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 报关单号
        /// </summary>
        public string NO { get; set; }

        /// <summary>
        /// 合同ID
        /// </summary>
        public int BudgetID { get; set; }

        /// <summary>
        /// 合同单号
        /// </summary>
        public string ContractNO { get; set; }

        /// <summary>
        /// 出口时间
        /// </summary>
        public DateTime? ExportDate { get; set; }

        /// <summary>
        /// 境外收发货人企业名称英文
        /// </summary>
        public string Overseas { get; set; }

        /// <summary>
        /// 监管方式（贸易方式）
        /// </summary>
        public string TradeMode { get; set; }

        /// <summary>
        /// 指运港
        /// </summary>
        public string Port { get; set; }

        /// <summary>
        /// 币制
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// 成交方式
        /// </summary>
        public string PriceClause { get; set; }

        /// <summary>
        /// 贸易国别地区
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        public string ProdNumber { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProdName { get; set; }

        /// <summary>
        /// 规格型号
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// 成交数量
        /// </summary>
        public double DealCount { get; set; }

        /// <summary>
        /// 成交计量单位
        /// </summary>
        public string DealUnit { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 总价
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// 最终目的国地区（贸易国别地区）
        /// </summary>
        public string FinalCountry { get; set; }

        /// <summary>
        /// 境内货源地
        /// </summary>
        public string DomesticSource { get; set; }

        /// <summary>
        /// 离岸价
        /// </summary>
        public decimal OffshoreTotalPrice { get; set; }

        /// <summary>
        /// 美元离岸价
        /// </summary>
        public decimal USDOffshoreTotalPrice { get; set; }

        /// <summary>
        /// 人民币离岸价
        /// </summary>
        public decimal CNYOffshoreTotalPrice { get; set; }

        /// <summary>
        /// 录入人
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 业务员所在部门
        /// </summary>
        public string DepartmentCode { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 部门描述
        /// </summary>
        public string DepartmentDesc
        {
            get { return this.DepartmentCode + this.DepartmentName; }
        }
        
        /// <summary>
        /// 录入人姓名
        /// </summary>
        public string CreateUserRealName { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public string UpdateUser { get; set; }

        /// <summary>
        /// 录入人姓名
        /// </summary>
        public string UpdateUserRealName { get; set; }

        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// 汇率
        /// </summary>
        public decimal ExchangeRate
        {
            get
            {
                if (DealCount != 0)
                {
                    return Math.Round(Price / (decimal)CNYOffshoreTotalPrice, 2);
                }
                return 0;
            }
        }

        /// <summary>
        /// 美元汇率
        /// </summary>
        public decimal USDExchangeRate
        {
            get
            {
                if (DealCount != 0)
                {
                    return Math.Round(CNYOffshoreTotalPrice / (decimal)USDOffshoreTotalPrice, 2);
                }
                return 0;
            }
        }

        /// <summary>
        /// 验证消息
        /// </summary>
        public string Message { get; set; }
    }
}
