using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraNavBar;

namespace DevExpress.Localization.Zh_Chs
{
    public class NavBarLocalizer_zhchs : NavBarLocalizer
    {
        public override string Language
        { get { return "简体中文"; } }
        public override string GetLocalizedString(NavBarStringId id)
        {
            switch (id)
            {
                case NavBarStringId.NavPaneMenuAddRemoveButtons: return "添加或删除按钮（&A）";
                case NavBarStringId.NavPaneMenuShowMoreButtons: return "显示更多按钮（&M）";
                case NavBarStringId.NavPaneChevronHint: return "配置按钮";
                case NavBarStringId.NavPaneMenuShowFewerButtons: return "显示少量按钮（&F）";

            }
            return base.GetLocalizedString(id);
        }
    }
}
