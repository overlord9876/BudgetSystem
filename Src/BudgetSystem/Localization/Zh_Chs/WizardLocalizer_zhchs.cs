﻿using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraWizard.Localization;

namespace DevExpress.Localization.Zh_Chs
{
    public class WizardLocalizer_zhchs : WizardLocalizer
    {
        public override string Language
        { get { return "简体中文"; } }
        public override string GetLocalizedString(WizardStringId id)
        {
            switch (id)
            {
                case WizardStringId.CancelText: return "取消";
                case WizardStringId.CaptionError: return "错误";
                case WizardStringId.CompletionPageFinishText: return "您已经顺利完成向导";
                case WizardStringId.CompletionPageProceedText: return "单击结束关闭向导";
                case WizardStringId.CompletionPageTitleText: return "完成向导";
                case WizardStringId.FinishText: return "结束";
                case WizardStringId.HelpText: return "帮助";
                case WizardStringId.InteriorPageTitleText: return "向导页标题";
                case WizardStringId.NextText: return "下一步 >";
                case WizardStringId.PageDescriptionText: return "向导页说明:帮助拥护完成子任务";
                case WizardStringId.PreviousText: return "< 上一步";
                case WizardStringId.WelcomePageIntroductionText: return "该向导简单地指导用户通过一系列步骤来执行一个复杂的任务设置";
                case WizardStringId.WelcomePageProceedText: return "单击下一步继续";
                case WizardStringId.WelcomePageTitleText: return "欢迎使用向导";
                case WizardStringId.WizardTitle: return "向导标题";

            }
            return base.GetLocalizedString(id);
        }
    }
}
