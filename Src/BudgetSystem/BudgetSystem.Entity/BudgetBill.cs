using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 实际收款单
    /// 与入帐单关联，分拆到每个合同的金额细则。
    /// </summary>
    public class BudgetBill : IEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 合同ID
        /// </summary>
        public int BudgetID { get; set; }

        /// <summary>
        /// 关联合同对象
        /// </summary>
        public Budget RelationBudget { get; set; }

        /// <summary>
        /// 入帐单ID
        /// </summary>
        public int BSID { get; set; }

        /// <summary>
        /// 原币金额
        /// </summary>
        public decimal OriginalCoin { get; set; }

        /// <summary>
        /// 汇率
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// 人民币金额
        /// </summary>
        public decimal CNY { get; set; }

        /// <summary>
        /// 操作人，金额认领人
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// 认领人所在部门
        /// </summary>
        public string DepartmentCode { get; set; }

        /// <summary>
        /// 操作、认领时间
        /// </summary>
        public DateTime OperateTimestamp { get; set; }

        /// <summary>
        /// 是否已删除
        /// </summary>
        public int IsDelete { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 收款是否已确认
        /// </summary>
        public bool Confirmed { get; set; }

        /// <summary>
        /// 数据操作模式，无操作、添加、修改（修改也包含改为IsDelete为True）
        /// </summary>
        public DataOperatorModel OperatorModel { get; set; }

        /// <summary>
        /// [入帐单]凭证号
        /// </summary>
        public string VoucherNo { get; set; }

        /// <summary>
        /// 合同号
        /// </summary>
        public string ContractNO { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// 付款客户
        /// </summary>
        public string Remitter { get; set; }

        /// <summary>
        /// 接收时间
        /// </summary>
        public DateTime ReceiptDate { get; set; }

    }

    public enum DataOperatorModel
    {
        None,
        Add,
        Modify
    }

}
