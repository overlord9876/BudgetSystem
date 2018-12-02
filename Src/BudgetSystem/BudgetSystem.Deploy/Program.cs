using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using BudgetSystem.Entity;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            DeployConfig config= DeployConfig.Read();

            SystemInfo newVersionInfo = CheckConfigConnectionAndGetServerVersionInfo(config);


            bool isCanRunMainProgram = true;

            if (newVersionInfo != null && newVersionInfo.Version != config.VersionCode)
            {
                frmVersionUpdate form = new frmVersionUpdate();
                form.NewSystemInfo = newVersionInfo;
                Application.Run(form);
                isCanRunMainProgram = form.IsSuccess;
                config.VersionCode = newVersionInfo.Version;
                
            }

            if (isCanRunMainProgram)
            {
                string fileName = System.IO.Path.Combine(Application.StartupPath, @"bin\BudgetSystem.exe");
                Process.Start(fileName, config.ConnectionString);
            }

        }

        private static SystemInfo CheckConfigConnectionAndGetServerVersionInfo(DeployConfig config)
        {
            SystemInfo newVersionInfo = null;
            Bll.SystemConfigManager sm = new Bll.SystemConfigManager();

            bool isModifyConfig = false;
            do
            {

                if (string.IsNullOrEmpty(config.ConnectionString.Trim()))
                {
                    frmSetting settingForm = new frmSetting();
                    if (settingForm.ShowDialog() == DialogResult.OK)
                    {
                        config.ConnectionString = settingForm.Connection;
                        isModifyConfig = true;
                    }
                }

                if (!string.IsNullOrEmpty(config.ConnectionString.Trim()))
                {
                    try
                    {
                        Bll.BaseManager.SetConnectionString(config.ConnectionString);
                        newVersionInfo = sm.GetSystemConfigValue<SystemInfo>("SystemInfo");
                    }
                    catch
                    {
                        config.ConnectionString = "";
                    }
                }

            } while (string.IsNullOrEmpty(config.ConnectionString));

            if (isModifyConfig)
            {
                config.Save();
            }
            return newVersionInfo;
        }
    }
}
