
#define UsePermission






using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.LookAndFeel;
using System.Configuration;
using MySql.Data.MySqlClient;
using DevExpress.XtraEditors;

namespace BudgetSystem
{

    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
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


# if (UseDeploy)

            if (args.Length == 0)
            {
                RunInfo.Instance.Logger.LogError("在Deploy模式下，传入参数为空");
                return;
            }
            string connectionString = args[0];
            Bll.BaseManager.SetConnectionString(connectionString, true);

# else
            bool isEncrypted = false;
            string connectionString = string.Empty;
            if (args.Length > 0)
            {
                connectionString = args[0];
                isEncrypted = true;
            }
            else
            {
                connectionString = ConfigurationManager.ConnectionStrings["connection"].ToString();
            }
            Bll.BaseManager.SetConnectionString(connectionString, isEncrypted);
#endif



            frmLogin loginForm = new frmLogin();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new frmMain());
            }
        }

        //UI线程异常
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (e.Exception is MySqlException)
            {
                XtraMessageBox.Show("访问数据服务失败，请联系管理员。");
            }
            RunInfo.Instance.Logger.LogError(e.Exception.ToString());
        }

        //多线程异常
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            RunInfo.Instance.Logger.LogError("UnhandledException" + e.ExceptionObject.ToString());
        }
    }
}
