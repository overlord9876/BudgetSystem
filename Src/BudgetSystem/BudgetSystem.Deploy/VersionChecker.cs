using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BudgetSystem.Deploy
{
    public class VersionChecker
    {

        public VersionChecker(DeployConfig config)
        {
            this.Config = config;
        }

        public DeployConfig Config
        {
            get;
            private set;
        }

        public SystemInfo NewSystemInfo
        {
            get;
            private set;
        }


        private  void ShowWaitingForm()
        {
            System.Threading.Thread.Sleep(1500);
            DevExpress.Utils.WaitDialogForm waitForm = new DevExpress.Utils.WaitDialogForm("", "版本检查中,请稍后");
            System.Threading.Thread.Sleep(10000);
        }
        
        public CheckResult Check()
        {
            Bll.SystemConfigManager sm = new Bll.SystemConfigManager();
            bool isModifyConfig = false;
            do
            {

                if (string.IsNullOrEmpty(Config.ConnectionString.Trim()))
                {
                    frmSetting settingForm = new frmSetting();
                    if (settingForm.ShowDialog() == DialogResult.OK)
                    {
                        Config.ConnectionString = settingForm.Connection;
                        isModifyConfig = true;
                    }
                    else
                    {
                        return CheckResult.UserExit;
                    }
                }

                if (!string.IsNullOrEmpty(Config.ConnectionString.Trim()))
                {
                    System.Threading.Thread waitFormThread = null;
                    try
                    {

                        waitFormThread = new System.Threading.Thread(ShowWaitingForm);
                        waitFormThread.IsBackground = true;
                        waitFormThread.Start();

                        Bll.BaseManager.SetConnectionString(Config.ConnectionString);
                        NewSystemInfo = sm.GetSystemConfigValue<SystemInfo>("SystemInfo");
                        CloseWaitingForm(waitFormThread);
                    }
                    catch (System.FormatException fex)
                    {
                        CloseWaitingForm(waitFormThread);
                        XtraMessageBox.Show("输入连接不合法！");
                        Config.ConnectionString = "";
                    }
                    catch (System.Security.Cryptography.CryptographicException cex)
                    {
                        CloseWaitingForm(waitFormThread);
                        XtraMessageBox.Show("输入连接不合法！");
                        Config.ConnectionString = "";
                    }
                    catch (Exception ex)
                    {
                        CloseWaitingForm(waitFormThread);
                        XtraMessageBox.Show("连接服务器失败！\r\n" + ex.Message);
                        Config.ConnectionString = "";
                    }
                }



            } while (string.IsNullOrEmpty(Config.ConnectionString));


            if (isModifyConfig)
            {
                Config.Save();
            }

            if (NewSystemInfo != null && NewSystemInfo.Version != Config.VersionCode)
            {
                return CheckResult.OldVersion;
            }
            else
            {
                return CheckResult.LastVersion;
            }


        }

        private void CloseWaitingForm( System.Threading.Thread waitingThread)
        {
            if (waitingThread != null && waitingThread.IsAlive)
            {
                waitingThread.Abort();
            }
        }

    }


    public enum CheckResult
    {
        UserExit,
        LastVersion,
        OldVersion
    }

}
