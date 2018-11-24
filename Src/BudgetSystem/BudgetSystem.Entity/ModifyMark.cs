using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 修改留痕记录
    /// </summary>
    public class ModifyMark
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        public string DateItemType { get; set; }
        /// <summary>
        /// 数据ID
        /// </summary>
        public int DataID { get; set; }
        /// <summary>
        /// 数据内容
        /// </summary>
        public string Content { get; set; }
    }     
}
