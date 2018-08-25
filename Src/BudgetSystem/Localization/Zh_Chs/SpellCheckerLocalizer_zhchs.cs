using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraSpellChecker.Localization;

namespace DevExpress.Localization.Zh_Chs
{
    public class SpellCheckerLocalizer_zhchs : SpellCheckerLocalizer
    {
        public override string Language
        { get { return "简体中文"; } }
        public override string GetLocalizedString(SpellCheckerStringId id)
        {
            switch (id)
            {
                case SpellCheckerStringId.ListBoxNoSuggestions: return "没有建议";
                case SpellCheckerStringId.MnuAddtoDictionaryCaption: return "增加到字典";
                case SpellCheckerStringId.MnuDeleteRepeatedWord: return "删除重复字";
                case SpellCheckerStringId.MnuIgnoreAllItemCaption: return "忽略全部";
                case SpellCheckerStringId.MnuIgnoreRepeatedWord: return "忽略";
                case SpellCheckerStringId.MnuItemCaption: return "拼写检查";
                case SpellCheckerStringId.MnuNoSuggestionsCaption: return "(没有拼写建议)";
                case SpellCheckerStringId.MsgBoxCaption: return "Xtra拼写检查器";
                case SpellCheckerStringId.MsgBoxCheckNotSelectedText: return "已经完成所选部分的检查。是否继续检查其余项目？";
                case SpellCheckerStringId.MsgBoxFinishCheck: return "已经完成拼写检查。";
                case SpellCheckerStringId.MsgCanUseCurrentWord: return "你选择了一个在主字典或定制字典里不存在的字。是否使用该字并继续检查？";

            }
            return base.GetLocalizedString(id);
        }
    }
}
