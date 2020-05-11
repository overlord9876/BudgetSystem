using System;
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
        ModifyApply,
        DeleteApply,
        SubmitApply,
        Modify,
        ModifyEx,
        Delete,
        Revoke,
        Disabled,
        Enabled,
        View,
        /// <summary>
        /// 审批
        /// </summary>
        Approve,
        /// <summary>
        /// 批量审批
        /// </summary>
        BatchApprove,
        /// <summary>
        /// 查看审批记录
        /// </summary>
        ViewApply,
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

        /// <summary>
        /// 导出
        /// </summary>
        ExportData,

        PrintList,
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
        /// <summary>
        /// 打印签收单
        /// </summary>
        PrintSignatureForm,

        /// <summary>
        /// 打印成本销售表
        /// </summary>
        PrintCostForm,

        /// <summary>
        /// 结账申请
        /// </summary>
        ClosingAccountApply,

        /// <summary>
        /// 驳回申请
        /// </summary>
        RejectedAccount,

        /// <summary>
        /// 财务归档征求
        /// </summary>
        FinancialArchiveApply,

        /// <summary>
        /// 归档
        /// </summary>
        Archive,
        /// <summary>
        /// 单一合同决算
        /// </summary>
        FinalAccount,
        /// <summary>
        /// 新增支付
        /// </summary>
        NewPayment,
    }
}
