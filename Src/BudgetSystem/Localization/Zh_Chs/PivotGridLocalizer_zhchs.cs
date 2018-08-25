using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraPivotGrid.Localization;

namespace DevExpress.Localization.Zh_Chs
{
    public class PivotGridLocalizer_zhchs : PivotGridLocalizer
    {
        public override string Language
        { get { return "简体中文"; } }
        public override string GetLocalizedString(PivotGridStringId id)
        {
            switch (id)
            {
                case PivotGridStringId.RowHeadersCustomization: return "将行域放在这里";
                case PivotGridStringId.ColumnHeadersCustomization: return "将列域放在这里";
                case PivotGridStringId.FilterHeadersCustomization: return "将数据筛选条件域放在这里";
                case PivotGridStringId.DataHeadersCustomization: return "将数据项目放在这里";
                case PivotGridStringId.RowArea: return "行区域";
                case PivotGridStringId.ColumnArea: return "列区域";
                case PivotGridStringId.FilterArea: return "数据筛选区域";
                case PivotGridStringId.DataArea: return "数据区域";
                case PivotGridStringId.FilterShowAll: return "(全部显示)";
                case PivotGridStringId.FilterShowBlanks: return "显示空白";
                case PivotGridStringId.CustomizationFormCaption: return "PivotGrid标题列表";
                case PivotGridStringId.CustomizationFormText: return "将项目放到PivotGrid中";
                case PivotGridStringId.CustomizationFormAddTo: return "增加到";
                case PivotGridStringId.Total: return "合计";
                case PivotGridStringId.GrandTotal: return "总计";
                case PivotGridStringId.TotalFormat: return "{0}合计";
                case PivotGridStringId.TotalFormatCount: return "{0}数据数";
                case PivotGridStringId.TotalFormatSum: return "{0}小计";
                case PivotGridStringId.TotalFormatMin: return "{0} 最小值";
                case PivotGridStringId.TotalFormatMax: return "{0} 最大值";
                case PivotGridStringId.TotalFormatAverage: return "{0}平均";
                case PivotGridStringId.TotalFormatStdDev: return "{0}标准差";
                case PivotGridStringId.TotalFormatStdDevp: return "{0}总体标准差";
                case PivotGridStringId.TotalFormatVar: return "{0}样本方差";
                case PivotGridStringId.TotalFormatVarp: return "{0}总体方差";
                case PivotGridStringId.TotalFormatCustom: return "{0}统计值";
                case PivotGridStringId.PrintDesignerPageOptions: return "选项";
                case PivotGridStringId.PrintDesignerPageBehavior: return "执行";
                case PivotGridStringId.PrintDesignerCategoryDefault: return "默认值";
                case PivotGridStringId.PrintDesignerCategoryLines: return "格线";
                case PivotGridStringId.PrintDesignerCategoryHeaders: return "标题";
                case PivotGridStringId.PrintDesignerHorizontalLines: return "水平格线";
                case PivotGridStringId.PrintDesignerVerticalLines: return "垂直格线";
                case PivotGridStringId.PrintDesignerFilterHeaders: return "数据筛选条件标题";
                case PivotGridStringId.PrintDesignerDataHeaders: return "数据标题";
                case PivotGridStringId.PrintDesignerColumnHeaders: return "列标题";
                case PivotGridStringId.PrintDesignerRowHeaders: return "行标题";
                case PivotGridStringId.PrintDesignerUsePrintAppearance: return "使用打印外观";
                case PivotGridStringId.PopupMenuRefreshData: return "刷新数据";
                case PivotGridStringId.PopupMenuHideField: return "隐藏";
                case PivotGridStringId.PopupMenuShowFieldList: return "显示数据栏清单";
                case PivotGridStringId.PopupMenuHideFieldList: return "隐藏数据栏清单";
                case PivotGridStringId.PopupMenuFieldOrder: return "排序";
                case PivotGridStringId.PopupMenuMovetoBeginning: return "移到开头";
                case PivotGridStringId.PopupMenuMovetoLeft: return "移到左边";
                case PivotGridStringId.PopupMenuMovetoRight: return "移到右边";
                case PivotGridStringId.PopupMenuMovetoEnd: return "移到最后";
                case PivotGridStringId.PopupMenuCollapse: return "收合";
                case PivotGridStringId.PopupMenuCollapseAll: return "全部收合";
                case PivotGridStringId.PopupMenuExpand: return "展开";
                case PivotGridStringId.PopupMenuExpandAll: return "全部展开";
                case PivotGridStringId.DataFieldCaption: return "数据";
                case PivotGridStringId.TopValueOthersRow: return "其他";
                case PivotGridStringId.CellError: return "错误";

            }
            return base.GetLocalizedString(id);
        }
    }
}
