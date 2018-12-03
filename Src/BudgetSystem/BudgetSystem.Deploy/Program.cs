using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using BudgetSystem.Entity;
using DevExpress.LookAndFeel;

namespace BudgetSystem.Deploy
{
    static class Program
    {





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

            DeployConfig config = DeployConfig.Read();

            VersionChecker checker = new VersionChecker(config);
            CheckResult checkResult = checker.Check();



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
                Process process= Process.Start(fileName, config.ConnectionString);
                

            }

        }


    }
}
