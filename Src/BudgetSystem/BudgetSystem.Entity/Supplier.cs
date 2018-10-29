using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 供应商表
    /// </summary>
    public class Supplier : IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 银行户名
        /// </summary>
        public string BankAccountName { get; set; }

        /// <summary>
        /// 银行账号
        /// </summary>
        public string BankNO { get; set; }

        /// <summary>
        /// 开户行
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 供应商类型
        /// 0=合格供方
        /// 1=临时供方
        /// 2=货运供方
        /// </summary>
        public int SupplierType { get; set; }

        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 企业性质
        /// </summary>
        public string Nature { get; set; }

        /// <summary>
        /// 注册资金
        /// </summary>
        public string RegisterCapital { get; set; }

        /// <summary>
        /// 供方地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Tell { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        public string FaxNumber { get; set; }

        /// <summary>
        /// 主要联系人
        /// </summary>
        public string Contacts { get; set; }

        /// <summary>
        /// 所属部门？
        /// </summary>
        public string DepartmentCode { get; set; }

        /// <summary>
        /// 所属部门名称
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// 法人代表
        /// </summary>
        public string Legal { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 创建人姓名
        /// </summary>
        public string CreateUserName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 是否选择
        /// </summary>
        public bool IsSelected { get; set; }
    }

    public enum EnumSupplierType
    {
        合格供方,
        临时供方,
        货运供方
    }
}
