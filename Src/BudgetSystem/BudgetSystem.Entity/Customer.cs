using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 客户表
    /// </summary>
    public class Customer : IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime CreateDate { get; set; }

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
        /// 可用状态
        /// </summary>
        public bool State { get; set; }
      
        /// <summary>
        /// 客户编号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// 联系人
        /// </summary>
        public string Contacts { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 港口
        /// </summary>
        public string Port { get; set; }



        /// <summary>
        /// 业务员列表
        /// </summary>
        public List<CustomerSalesman> SalesmanList { get; set; }

        /// <summary>
        /// 是否选择
        /// </summary>
        public bool IsSelected { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }

}
