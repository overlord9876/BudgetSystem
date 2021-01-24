using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 国家信息配置
    /// </summary>
    public class Country
    {
        /// <summary>
        /// 编码
        /// </summary>
        public string Code
        {
            get;
            set;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 英文名称
        /// </summary>
        public string EnName
        {
            get;
            set;
        }

        /// <summary>
        /// 是否一带一路。
        /// </summary>
        public bool IsBR { get; set; }
    }
}
