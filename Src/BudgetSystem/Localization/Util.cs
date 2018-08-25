using System.Text;
using System.IO;
using System.Resources;
using System.Collections;
using DevExpress.Localization.Zh_Chs;
using DevExpress.XtraNavBar;
using DevExpress.XtraWizard.Localization;
using DevExpress.XtraVerticalGrid.Localization;
using DevExpress.XtraTreeList.Localization;
using DevExpress.XtraSpellChecker.Localization;
using DevExpress.XtraScheduler.Localization;
using DevExpress.XtraReports.Localization;
using DevExpress.XtraLayout.Localization;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraRichEdit.Localization;
using DevExpress.XtraPrinting.Localization;
using DevExpress.XtraBars.Localization;
using DevExpress.Accessibility;
using DevExpress.XtraCharts.Localization;
using DevExpress.XtraPivotGrid.Localization;


namespace DevExpress.Localization
{
    public class Util
    {        /// <summary>
        /// 设置简体中文语言环境
        /// </summary>
        public static void Set_zhchs_Culture()
        {

            WizardLocalizer.Active = new WizardLocalizer_zhchs();
            VGridLocalizer.Active = new VGridLocalizer_zhchs();
            TreeListLocalizer.Active = new TreeListLocalizer_zhchs();
            SpellCheckerLocalizer.Active = new SpellCheckerLocalizer_zhchs();
            SchedulerExtensionsLocalizer.Active = new SchedulerExtensionsLocalizer_zhchs();
            SchedulerLocalizer.Active = new SchedulerLocalizer_zhchs();
            ReportLocalizer.Active = new ReportLocalizer_zhchs();
            NavBarLocalizer.Active = new NavBarLocalizer_zhchs();
            LayoutLocalizer.Active = new LayoutLocalizer_zhchs();
            GridLocalizer.Active = new GridLocalizer_zhchs();
            Localizer.Active = new Localizer_zhchs();
            BarLocalizer.Active = new BarLocalizer_zhchs();
            NavBarLocalizer.Active = new NavBarLocalizer_zhchs();
            GridLocalizer.Active = new GridLocalizer_zhchs();
            AccLocalizer.Active = new AccLocalizer_zhchs();
            XtraRichEditLocalizer.Active = new XtraRichEditLocalizer_zhchs();
            ChartLocalizer.Active = new ChartLocalizer_zhchs();
            PreviewLocalizer.Active = new PreviewLocalizer_zhchs();
            PivotGridLocalizer.Active = new PivotGridLocalizer_zhchs();

        }


    }
}
