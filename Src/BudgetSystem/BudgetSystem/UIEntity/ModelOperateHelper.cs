using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem
{
    public static class ModelOperateHelper
    {
        public static ModelOperate GetOperate(OperateTypes operate, string caption = "")
        {
            string text = "";
            string group = "";
            int order = (int)operate;
            int imageIndex = -1;

            if (operate == OperateTypes.New)
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
            else if (operate == OperateTypes.Relate)
            {
                text = "关联";
                group = "操作";
                imageIndex = 51;
            }
            else if (operate == OperateTypes.Disabled)
            {
                text = "停用";
                group = "操作";
                imageIndex = 51;
            }
            else if (operate == OperateTypes.Enabled)
            {
                text = "启用";
                group = "操作";
                imageIndex = 51;
            }

            ModelOperate mm = new ModelOperate(operate, string.IsNullOrEmpty(caption) ? text : caption, group, order, imageIndex);
            return mm;
        }




    }
}
