using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Configuration;

namespace BudgetSystem.Tools
{
    static class Program
    {

        static BudgetSystem.Util.Logger Logger;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Logger = new Util.Logger(System.IO.Path.Combine(Environment.CurrentDirectory, "Log"));

            Application.ThreadException += Application_ThreadException; //UI线程异常
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException; //多线程异常

            string connectionString = ConfigurationManager.ConnectionStrings["connection"].ToString();
            Bll.BaseManager.SetConnectionString(connectionString, false);


            Application.Run(new frmTools());
        }

        //UI线程异常
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Logger.LogError(e.Exception.ToString());
        }

        //多线程异常
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Logger.LogError("UnhandledException" + e.ExceptionObject.ToString());
        }
    }

}
