using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.LookAndFeel;

namespace BudgetSystem
{
    static class Program
    {



       
     
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevExpress.Localization.Util.Set_zhchs_Culture();
            OfficeSkins.Register();
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            
             UserLookAndFeel.Default.SkinName=RunInfo.Instance.Config.SkinName;
          

            frmLogin loginForm = new frmLogin();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {

                Application.Run(new frmMain());
            }

            
        }
    }
}
