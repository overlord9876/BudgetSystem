using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using BudgetSystem.Entity.QueryCondition;

namespace BudgetSystem
{
    public class RunInfo
    {
        private RunInfo()
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
        /// <summary>
        /// 当前用户所有部门
        /// </summary>
        public Department CurrentUserDepartment
        {
            get;
            set;
        }
        public List<string> UserPermission
        {
            get;
            set;
        }

        public BaseQueryCondition GetConditionByCurrentUser(BaseQueryCondition condition)
        {
            if (RunInfo.Instance.CurrentUser.Role == StringUtil.SaleRoleCode)
            {
                condition.Salesman = RunInfo.Instance.CurrentUser.UserName;
            }
            else if (CurrentUser.Role == StringUtil.SaleDepartmentRoleCode)
            {
                condition.DeptID = RunInfo.Instance.CurrentUser.DeptID;
            }
            else
            {
            }
            return condition;
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

        public AdjustmentRole GetAdjustmentRole()
        {
            if (CurrentUser.Role == StringUtil.SaleRoleCode || CurrentUser.Role == StringUtil.SaleDepartmentRoleCode)
            {
                return AdjustmentRole.业务员调账;
            }
            else
            {
                return AdjustmentRole.财务调账;
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
