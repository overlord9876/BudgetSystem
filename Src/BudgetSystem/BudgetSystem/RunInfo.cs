using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;

namespace BudgetSystem
{
    public class RunInfo
    {
        private  RunInfo()
        {
            this.Config = Config.Read();
            this.Logger = new Util.Logger(System.IO.Path.Combine(Environment.CurrentDirectory, "Log"));
        }

        private static object lockObj = new object();
        private static RunInfo instance = null;
       
        public static RunInfo Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new RunInfo();
                    }
                }
                return instance;
            
            }
        }

        public Config Config
        {
            get;
            private set;
        }

        public User CurrentUser
        {
            get;
            set;
        }

        public List<string> UserPermission
        {
            get;
            set;
        }




        private FlowApproveNameConfigCollection flowAppreveNameConfigs = null;
        public FlowApproveNameConfigCollection FlowAppreveNameConfigs
        {
            get
            {
                if (flowAppreveNameConfigs == null)
                {
                    Bll.SystemConfigManager sm = new Bll.SystemConfigManager();
                    flowAppreveNameConfigs = sm.GetSystemConfigValue<FlowApproveNameConfigCollection>("FlowApproveNameConfig");

                    if (flowAppreveNameConfigs == null)
                    {
                        flowAppreveNameConfigs = new FlowApproveNameConfigCollection();
                    }
                }
                return flowAppreveNameConfigs;

            }
        }

        public Util.Logger Logger
        {
            get;
            set;
        }

        public frmMain MainForm
        {
            get;
            set;
        }
    }
}
