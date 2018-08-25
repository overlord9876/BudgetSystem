using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Accessibility;

namespace DevExpress.Localization.Zh_Chs
{
    public class AccLocalizer_zhchs : AccLocalizer
    {
        public override string Language
        { get { return "简体中文"; } }
        public override string GetLocalizedString(AccStringId id)
        {
            switch (id)
            {
                case AccStringId.BarLinkEdit: return "编辑";
                case AccStringId.NavBarGroupExpand: return "扩展";
                case AccStringId.DescScrollLineUp: return "竖直位置上移一行";
                case AccStringId.SpinRightButton: return "右";
                case AccStringId.GridColumnSortAscending: return "升序排列";
                case AccStringId.GridRowActivate: return "激活";
                case AccStringId.GridCardCollapse: return "折叠";
                case AccStringId.BarLinkCaption: return "项目";
                case AccStringId.DescScrollAreaRight: return "水平位置右移两列";
                case AccStringId.DescScrollAreaUp: return "竖直位置上移两行";
                case AccStringId.GridCellFocus: return "焦点";
                case AccStringId.NameScrollLineUp: return "上一行";
                case AccStringId.NameScrollAreaUp: return "上一页";
                case AccStringId.NameScrollColumnLeft: return "向左一列";
                case AccStringId.DescScrollColumnLeft: return "水平位置左移一列";
                case AccStringId.GridColumnSortNone: return "删除排序";
                case AccStringId.GridRow: return "行 {0}";
                case AccStringId.GridHeaderPanel: return "表头面板";
                case AccStringId.NavBarItemClick: return "压力";
                case AccStringId.GridDataRowCollapse: return "折叠细节";
                case AccStringId.GridCellEdit: return "编辑";
                case AccStringId.GridRowExpand: return "扩展";
                case AccStringId.NameScrollAreaLeft: return "向左一页";
                case AccStringId.NameScrollAreaDown: return "下一页";
                case AccStringId.SpinDownButton: return "向下";
                case AccStringId.DescScrollAreaLeft: return "水平位置左移两列";
                case AccStringId.DescScrollAreaDown: return "竖直位置下移两行";
                case AccStringId.GridFilterRow: return "过滤行";
                case AccStringId.GridCell: return "单元格";
                case AccStringId.NameScrollAreaRight: return "向右一页";
                case AccStringId.MouseDoubleClick: return "双击";
                case AccStringId.DescScrollHorzIndicator: return "显示当前水平位置，可以通过拖拽直接改变位置。";
                case AccStringId.BarLinkClick: return "压力";
                case AccStringId.OpenKeyboardShortcut: return "Alt+Down";
                case AccStringId.GridRowCollapse: return "折叠";
                case AccStringId.ActionPress: return "压力";
                case AccStringId.DescScrollVertIndicator: return "显示当前竖直位置，可以通过拖拽直接改变位置。";
                case AccStringId.GridDataPanel: return "数据面板";
                case AccStringId.NameScrollColumnRight: return "向右一列";
                case AccStringId.NavBarScrollDown: return "向下滚动";
                case AccStringId.CheckEditCheck: return "检查";
                case AccStringId.BarLinkStatic: return "静态";
                case AccStringId.GridNewItemRow: return "新项目行";
                case AccStringId.SpinBox: return "旋转";
                case AccStringId.DescScrollLineDown: return "竖直位置下移一行";
                case AccStringId.NavBarScrollUp: return "向上滚动";
                case AccStringId.SpinUpButton: return "向上";
                case AccStringId.BarDockControlTop: return "靠顶部";
                case AccStringId.BarDockControlRight: return "靠右侧";
                case AccStringId.BarLinkMenuClose: return "关闭";
                case AccStringId.GridCardExpand: return "扩展";
                case AccStringId.BarDockControlBottom: return "靠底部";
                case AccStringId.TabSwitch: return "切换";
                case AccStringId.NameScroll: return "滚动条";
                case AccStringId.SpinLeftButton: return "左";
                case AccStringId.CheckEditUncheck: return "未检查";
                case AccStringId.DescScrollColumnRight: return "水平位置右移一列";
                case AccStringId.GridDataRowExpand: return "扩展细节";
                case AccStringId.BarDockControlLeft: return "靠左侧";
                case AccStringId.BarLinkMenuOpen: return "打开";
                case AccStringId.NameScrollIndicator: return "位置";
                case AccStringId.GridColumnSortDescending: return "降序排列";
                case AccStringId.NavBarGroupCollapse: return "折叠";
                case AccStringId.ButtonClose: return "关闭";
                case AccStringId.ButtonOpen: return "打开";
                case AccStringId.ButtonPush: return "压力";
                case AccStringId.NameScrollLineDown: return "向下一行";

            }
            return base.GetLocalizedString(id);
        }
    }
}
