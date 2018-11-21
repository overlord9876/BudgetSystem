
#define UsePermission






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
            Environment.CurrentDirectory = Application.StartupPath;
            DevExpress.Localization.Util.Set_zhchs_Culture();
            OfficeSkins.Register();
            BonusSkins.Register();
            SkinManager.EnableFormSkins();


            Application.ThreadException += Application_ThreadException; //UI线程异常
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException; //多线程异常

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            
             UserLookAndFeel.Default.SkinName=RunInfo.Instance.Config.SkinName;
          

            frmLogin loginForm = new frmLogin();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {

                Application.Run(new frmMain());
            }

            
        }
    
        //UI线程异常
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            //Log
        }

        //多线程异常
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //Log
        }
    }
}
