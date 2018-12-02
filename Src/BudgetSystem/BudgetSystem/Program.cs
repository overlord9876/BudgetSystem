
#define UsePermission






using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.LookAndFeel;
using System.Configuration;

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

            try
            {

                Environment.CurrentDirectory = Application.StartupPath;
                DevExpress.Localization.Util.Set_zhchs_Culture();
                OfficeSkins.Register();
                BonusSkins.Register();
                SkinManager.EnableFormSkins();
            }
            catch (Exception ex)
            {
                RunInfo.Instance.Logger.LogInfomation(ex.ToString());
            }

            Application.ThreadException += Application_ThreadException; //UI线程异常
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException; //多线程异常

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);



            UserLookAndFeel.Default.SkinName = RunInfo.Instance.Config.SkinName;


            string connectionString = ConfigurationManager.ConnectionStrings["connection"].ToString();
            Bll.BaseManager.ConnectionString = connectionString;

            frmLogin loginForm = new frmLogin();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {

                Application.Run(new frmMain());
            }


        }

        //UI线程异常
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            RunInfo.Instance.Logger.LogError(e.Exception.ToString());
        }

        //多线程异常
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            RunInfo.Instance.Logger.LogError("UnhandledException" + e.ExceptionObject.ToString());
        }
    }
}
