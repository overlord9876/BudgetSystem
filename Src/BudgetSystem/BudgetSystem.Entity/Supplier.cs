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
        private List<Department> departments = new List<Department>();

        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 合同号（只查询时候用）
        /// </summary>
        public int BudgetID { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 银行信息
        /// </summary>
        public string BankInfoDetail { get; set; }

        /// <summary>
        /// 供应商类型
        /// 0=合格供方
        /// 1=临时供方
        /// 2=其它供方
        /// 3=货运供方
        /// 4=佣金供方
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
        /// 传真/Email
        /// </summary>
        public string FaxNumber { get; set; }

        /// <summary>
        /// 主要联系人
        /// </summary>
        public string Contacts { get; set; }

        /// <summary>
        /// 部门列表
        /// </summary>
        public List<Department> Departments { get { return this.departments; } }

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
        /// 纳税人识别号
        /// </summary>
        public string TaxpayerID { get; set; }

        /// <summary>
        /// 是否失信企业
        /// </summary>
        public bool Discredited { get; set; }

        /// <summary>
        /// 是否有合格供方代理协议
        /// </summary>
        public int AgentType { get; set; }

        public EnumAgentType EnumAgentType
        {
            get { return (EnumAgentType)AgentType; }
        }

        /// <summary>
        /// 经营登记日期
        /// </summary>
        public DateTime? RegistrationDate { get; set; }

        /// <summary>
        /// 经营截止时间
        /// </summary>
        public DateTime? BusinessEffectiveDate { get; set; }

        /// <summary>
        /// 代理协议有效期
        /// </summary>
        public DateTime? AgreementDate { get; set; }

        /// <summary>
        /// 年审日期
        /// </summary>
        public DateTime? ReviewDate { get; set; }

        /// <summary>
        /// 营业执照复印件
        /// </summary>
        public bool ExistsLicenseCopy { get; set; }

        /// <summary>
        /// 初审内容
        /// </summary>
        public string FirstReviewContents { get; set; }

        /// <summary>
        /// 复审内容
        /// </summary>
        public string ReviewContents { get; set; }


        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        public string UpdateUser { get; set; }

        /// <summary>
        /// 更新人名
        /// </summary>
        public string UpdateUserName { get; set; }

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

        public int FlowState { get; set; }
        /// <summary>
        /// 流程实例ID
        /// </summary>
        public int FlowInstanceID { get; set; }

        /// <summary>
        /// 流程名
        /// </summary>
        public string FlowName { get; set; }

        /// <summary>
        /// 是否选择
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// 是否警告（提醒评审）
        /// </summary>
        public bool IsWarned
        {
            get
            {
                if (SupplierType == (int)EnumSupplierType.合格供方 && EnumFlowState == EnumDataFlowState.审批通过)
                {
                    if ((this.BusinessEffectiveDate != null && this.BusinessEffectiveDate.Value > DateTime.MinValue.AddDays(30)
                         && this.BusinessEffectiveDate.Value.Date.AddDays(-30) <= DateTimeNow.Date && DateTimeNow.Date <= this.BusinessEffectiveDate.Value.Date)
                       || (this.AgentType == (int)EnumAgentType.代理 && this.AgreementDate != null && this.AgreementDate.Value > DateTime.MinValue.AddDays(30)
                           && this.AgreementDate.Value.Date.AddDays(-30) <= DateTimeNow.Date && DateTimeNow.Date <= this.AgreementDate.Value.Date)
                       || (this.ReviewDate != null && this.ReviewDate.Value < DateTime.MaxValue.AddDays(-30)
                          && this.ReviewDate.Value.Date <= DateTimeNow.Date && DateTimeNow.Date <= this.ReviewDate.Value.AddDays(30).Date))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// 是否超过审批警告日期任然没有提交审批
        /// </summary>
        public bool IsExpires
        {
            get
            {
                if (SupplierType == (int)EnumSupplierType.合格供方 && EnumFlowState == EnumDataFlowState.审批通过)
                {
                    if ((this.BusinessEffectiveDate != null && DateTimeNow.Date > this.BusinessEffectiveDate.Value.Date)
                       || (this.AgentType == (int)EnumAgentType.代理 && this.AgreementDate != null && DateTimeNow.Date > this.AgreementDate.Value.Date)
                       || (this.ReviewDate != null && DateTimeNow.Date.AddDays(-30) > this.ReviewDate.Value.Date))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// 是否合格供应商
        /// </summary>
        public bool IsQualified
        {
            get
            {
                if (SupplierType == (int)EnumSupplierType.合格供方 && this.EnumFlowState == EnumDataFlowState.审批通过)
                {
                    if ((this.BusinessEffectiveDate != null && this.BusinessEffectiveDate.Value.Date >= DateTimeNow.Date)
                        && ((this.AgentType == (int)EnumAgentType.代理 && this.AgreementDate != null && this.AgreementDate.Value.Date >= DateTimeNow.Date)
                            || this.AgentType == (int)EnumAgentType.货代 || this.AgentType == (int)EnumAgentType.自营)
                        && (this.ReviewDate != null && this.ReviewDate.Value.Date >= DateTimeNow.Date.AddDays(-30)))
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public Supplier()
        {
            FlowState = -1;
            AgentType = (int)EnumAgentType.无;
            DateTimeNow = new DateTime(2000, 1, 1);
        }

        public Supplier(DateTime datetimeNow)
            : this()
        {
            this.DateTimeNow = datetimeNow;
        }

        public DateTime DateTimeNow { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public string ToDesc()
        {
            return string.Format("名称[{0}],法人[{1}],合格供方代理协议类型[{2}],经营异常企业[{3}],联系人[{4}],所属部门[{5}]",
                this.Name, this.Legal, AgentType, Discredited ? "是" : "否", Contacts, DepartmentCode + "-" + DepartmentName);
        }

    }

    public enum EnumSupplierType
    {
        合格供方 = 0,
        临时供方 = 1,
        其它供方 = 2
    }
    /// <summary>
    /// 供应商代理类型
    /// </summary>
    public enum EnumAgentType
    {
        无 = 0,
        代理 = 1,
        自营 = 2,
        货代 = 3
    }
}
