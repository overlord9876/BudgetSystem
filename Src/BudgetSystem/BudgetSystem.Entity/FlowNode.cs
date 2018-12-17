using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 审批配置子表
    /// </summary>
    public class FlowNode : IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 流程名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 流程版本号
        /// </summary>
        public int VersionNumber { get; set; }

        /// <summary>
        /// 顺序号
        /// </summary>
        public int OrderNo { get; set; }

        /// <summary>
        /// 节点配置0人1部门&经理 2部门&副经理
        /// </summary>
        public int NodeConfig { get; set; }

        /// <summary>
        /// 节点配置值
        /// </summary>
        public string NodeValue { get; set; }


        /// <summary>
        /// 节点配置值的显示内容
        /// </summary>
        public string NodeValueDisplayValue { get; set; }

        /// <summary>
        /// 节点配置值描述(用于打印时的抬头)
        /// </summary>
        public string NodeValueRemark { get; set; }

        /// <summary>
        /// 节点提交扩展事件
        /// </summary>
        public string NodeExtEvent { get; set; }

    }
}
