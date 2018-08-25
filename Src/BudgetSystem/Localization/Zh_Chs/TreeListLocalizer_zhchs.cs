using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraTreeList.Localization;

namespace DevExpress.Localization.Zh_Chs
{
    public class TreeListLocalizer_zhchs : TreeListLocalizer
    {
        public override string Language
        { get { return "简体中文"; } }
        public override string GetLocalizedString(TreeListStringId id)
        {
            switch (id)
            {
                case TreeListStringId.MenuColumnBestFit: return "最佳匹配";
                case TreeListStringId.PrintDesignerHeader: return "打印设置";
                case TreeListStringId.ColumnCustomizationText: return "自定义";
                case TreeListStringId.MenuFooterMin: return "最小值";
                case TreeListStringId.MenuFooterMax: return "最大值";
                case TreeListStringId.MenuFooterSum: return "和";
                case TreeListStringId.MenuFooterAllNodes: return "所有节点";
                case TreeListStringId.MenuFooterCount: return "计数";
                case TreeListStringId.MenuColumnSortAscending: return "升序排列";
                case TreeListStringId.MenuFooterNone: return "无";
                case TreeListStringId.MenuColumnSortDescending: return "降序排列";
                case TreeListStringId.PrintDesignerDescription: return "为当前的树状列表设置不同的打印选项";
                case TreeListStringId.MenuColumnBestFitAllColumns: return "最佳匹配 (所有列)";
                case TreeListStringId.MenuFooterAverageFormat: return "平均值={0:#.##}";
                case TreeListStringId.ColumnNamePrefix: return "列";
                case TreeListStringId.MenuFooterMinFormat: return "最小值={0}";
                case TreeListStringId.MenuFooterCountFormat: return "{0}";
                case TreeListStringId.MenuColumnColumnCustomization: return "列选择";
                case TreeListStringId.MenuFooterMaxFormat: return "最大值={0}";
                case TreeListStringId.MenuFooterSumFormat: return "和={0:#.##}";
                case TreeListStringId.MultiSelectMethodNotSupported: return "OptionsBehavior.MultiSelect未激活时，指定方法不能工作.";
                case TreeListStringId.InvalidNodeExceptionText: return " 要修正当前值吗?";
                case TreeListStringId.MenuFooterAverage: return "平均值";

            }
            return base.GetLocalizedString(id);
        }
    }
}
