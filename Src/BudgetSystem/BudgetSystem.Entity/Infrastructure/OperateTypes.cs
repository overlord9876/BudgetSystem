﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    public enum OperateTypes
    {
        /// <summary>
        /// None,CommonQuery,MyQuery,CustomQuery是不要权限的
        /// </summary>
        None,
        CommonQuery,
        MyQuery,
        CustomQuery,
        QueryManager,
        
        
        
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
        /// 拆分申请
        /// </summary>
        SplitRequest,
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
        ImportData2,


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
        Save,

        /// <summary>
        /// 分配角色权限
        /// </summary>
        DistributeRolePermission,
        /// <summary>
        /// 分配角色用户
        /// </summary>
        DistributeRoleUser,

        /// <summary>
        /// 分配部门用户
        /// </summary>
        DistributeDepartmentUser,


        ConfirmOrRevoke,
    }
}