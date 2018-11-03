﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem
{
    public enum OperateTypes
    {
        New,
        Modify,
        Delete,
        Relate,
        Revoke,
        Disabled,
        Enabled,
        View,
        /// <summary>
        /// 审批
        /// </summary>
        Approve,

        /// <summary>
        /// 拆分费用
        /// </summary>
        SplitCost,
        /// <summary>
        /// 关闭审批单
        /// </summary>
        Close,
        ViewMoney,
        ViewMoneyDetail,
        /// <summary>
        /// 导入
        /// </summary>
        ImportData,


        Print,
        Confirm,
        GiveUp,

        /// <summary>
        /// 重置密码
        /// </summary>
        ReSetPassword,
        /// <summary>
        /// 按合同查看收支情况
        /// </summary>
        BudgetAccountBill,
        Save
    }
}
