using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;

namespace BudgetSystem
{
    public static class ModelOperateHelper
    {
        public static ModelOperate GetOperate(OperateTypes operate, string caption = "", UITypes uiType = UITypes.LargeButton, object extendData = null)
        {
            string text = "";
            string group = "";
            int order = (int)operate;
            int imageIndex = -1;



            if (operate == OperateTypes.CommonQuery)
            {
                text = "通用查询";
                group = "查询";
                imageIndex = 48;
            }
            else if (operate == OperateTypes.MyQuery)
            {
                text = "我的查询";
                group = "查询";
                imageIndex = 48;
            }
            else if (operate == OperateTypes.CustomQuery)
            {
                text = "自定义查询";
                group = "查询";
                imageIndex = 48;
            }
            else if (operate == OperateTypes.QueryManager)
            {
                text = "查询配置";
                group = "查询";
                imageIndex = 48;
            }
            else if (operate == OperateTypes.New)
            {
                text = "新增";
                group = "编辑";
                imageIndex = 48;
            }
            else if (operate == OperateTypes.Modify)
            {
                text = "修改";
                group = "编辑";
                imageIndex = 49;
            }
            else if (operate == OperateTypes.Delete)
            {
                text = "删除";
                group = "编辑";
                imageIndex = 50;
            }
            else if (operate == OperateTypes.View)
            {
                text = "查看";
                group = "查看";
                imageIndex = 3;
            }
            else if (operate == OperateTypes.Revoke)
            {
                text = "撤回";
                group = "操作";
                imageIndex = 9;
            }
            else if (operate == OperateTypes.Disabled)
            {
                text = "停用";
                group = "操作";
                imageIndex = 54;
            }
            else if (operate == OperateTypes.Enabled)
            {
                text = "启用";
                group = "操作";
                imageIndex = 34;
            }
            else if (operate == OperateTypes.Approve)
            {
                text = "审批";
                group = "操作";
                imageIndex = 2;
            }   
            else if (operate == OperateTypes.BatchApprove)
            {
                text = "批量审批";
                group = "操作";
                imageIndex = 2;
            }
            else if (operate == OperateTypes.ModifyApply)
            {
                text = "修改申请";
                group = "操作";
                imageIndex = 59;
            }
            else if (operate == OperateTypes.DeleteApply)
            {
                text = "删除申请";
                group = "操作";
                imageIndex = 59;
            }
            else if (operate == OperateTypes.SubmitApply)
            {
                text = "提交流程";
                group = "操作";
                imageIndex = 59;
            }
            else if (operate == OperateTypes.SplitCost)
            {
                text = "费用拆分";
                group = "操作";
                imageIndex = 55;
            }
            else if (operate == OperateTypes.Close)
            {
                text = "关闭预算单";
                group = "操作";
                imageIndex = 56;
            }
            else if (operate == OperateTypes.ViewMoney)
            {
                text = "查看合同收付";
                group = "操作";
                imageIndex = 46;
            }
            else if (operate == OperateTypes.ViewMoneyDetail)
            {
                text = "查看合同货款往来";
                group = "操作";
                imageIndex = 22;
            }
            else if (operate == OperateTypes.ImportData || operate == OperateTypes.ImportData2)
            {
                text = "导入";
                group = "操作";
                imageIndex = 57;
            }
            else if (operate == OperateTypes.Print)
            {
                text = "打印";
                group = "打印";
                imageIndex = 58;
            }
            else if (operate == OperateTypes.PrintList)
            {
                text = "打印列表";
                group = "打印";
                imageIndex = 58;
            }
            else if (operate == OperateTypes.Confirm)
            {
                text = "确认";
                group = "操作";
                imageIndex = 59;
            }
            else if (operate == OperateTypes.GiveUp)
            {
                text = "放弃";
                group = "操作";
                imageIndex = 60;
            }
            else if (operate == OperateTypes.ReSetPassword)
            {
                text = "重置密码";
                group = "操作";
                imageIndex = 61;
            }
            else if (operate == OperateTypes.BudgetAccountBill)
            {
                text = "按合同查看收支情况";
                group = "查看";
                imageIndex = 3;
            }
            else if (operate == OperateTypes.ViewApply)
            {
                text = "查看审批记录";
                group = "查看";
                imageIndex = 3;
            }
            else if (operate == OperateTypes.Save)
            {
                text = "保存";
                group = "编辑";
                imageIndex = 6;
            }
            else if (operate == OperateTypes.ConfirmOrRevoke)
            {
                text = "确认/撤回";
                group = "操作";
                imageIndex = 59;
            }

            ModelOperate mm = new ModelOperate(operate, string.IsNullOrEmpty(caption) ? text : caption, group, order, imageIndex, uiType);
            mm.UIElementData = extendData;



            return mm;
        }




    }
}
