using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using BudgetSystem.Entity;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;

namespace BudgetSystem.Deploy
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

            Control.CheckForIllegalCrossThreadCalls = false;


            UserLookAndFeel.Default.SkinName = "Office 2007 Blue";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += Application_ThreadException; //UI线程异常
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException; //多线程异常

            DeployConfig config = DeployConfig.Read();

            VersionChecker checker = new VersionChecker(config);
            CheckResult checkResult = checker.Check();


            Logger = new Util.Logger(System.IO.Path.Combine(Environment.CurrentDirectory, "Log"));


            if (checkResult == CheckResult.UserExit)
            {
                return;
            }


            bool isCanRunMainProgram = true;

            if (checkResult == CheckResult.OldVersion)
            {
                frmVersionUpdate form = new frmVersionUpdate();
                form.NewSystemInfo = checker.NewSystemInfo;
                form.DoUpdate();
                form.ShowDialog();

                //  Application.Run(form);
                isCanRunMainProgram = form.IsSuccess;
                config.VersionCode = checker.NewSystemInfo.Version;
                config.Save();
            }

            if (isCanRunMainProgram)
            {
                string fileName = ConstData.BudgetSystemExecuteFileName;
                Process process = Process.Start(fileName, config.ConnectionString);


            }

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
