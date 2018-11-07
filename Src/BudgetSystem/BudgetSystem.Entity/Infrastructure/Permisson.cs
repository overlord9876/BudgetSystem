using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    public class Permisson
    {

        public Permisson()
        {

        }

        public Permisson(BusinessModules module, OperateTypes operate, string displayName, int displayOrder)
        {

            this.Module = module;
            this.Operate = operate;
            this.DisplayName = displayName;
            this.DisplayOrder = displayOrder;
        }


        public BusinessModules Module
        {
            get;
            set;
        }

        public OperateTypes Operate
        {
            get;
            set;
        }


        public string DisplayName
        {
            get;
            set;
        }

        public int DisplayOrder
        {
            get;
            set;
        }

        public string Code
        {
            get
            {
                if (Operate == OperateTypes.None)
                {
                    return this.Module.ToString();
                }
                else
                {
                    return this.Module + "." + this.Operate;
                }
            }
        }


        private static List<Permisson> allPermission = null;

        public static List<Permisson> Permissions
        {
            get
            {
                if (allPermission == null)
                {
                    allPermission = new List<Permisson>() 
                    { 
                        new Permisson(BusinessModules.UserManagement, OperateTypes.None,"用户管理模块",100),
                        new Permisson(BusinessModules.UserManagement, OperateTypes.New,"用户管理-新增用户",110),
                        new Permisson(BusinessModules.UserManagement, OperateTypes.Modify,"用户管理-修改用户",120),
                        new Permisson(BusinessModules.UserManagement, OperateTypes.Enabled,"用户管理-启动用户",130),
                        new Permisson(BusinessModules.UserManagement, OperateTypes.Disabled,"用户管理-停用用户",140),
                        new Permisson(BusinessModules.UserManagement, OperateTypes.ReSetPassword,"用户管理-重置密码",150),
                        new Permisson(BusinessModules.UserManagement, OperateTypes.View,"用户管理-查看用户详情",160),

                        new Permisson(BusinessModules.RoleManagement, OperateTypes.None,"角色管理模块",200),
                        new Permisson(BusinessModules.RoleManagement, OperateTypes.DistributeRolePermission,"角色管理-分配权限",210),
                        new Permisson(BusinessModules.RoleManagement, OperateTypes.DistributeRoleUser,"角色管理-分配用户",220),
                
                        new Permisson(BusinessModules.DepartmentManagement, OperateTypes.None,"部门管理模块",300),
                        new Permisson(BusinessModules.DepartmentManagement, OperateTypes.New,"部门管理-新增部门",310),
                        new Permisson(BusinessModules.DepartmentManagement, OperateTypes.Modify,"部门管理-修改部门",320),
                        new Permisson(BusinessModules.DepartmentManagement, OperateTypes.View,"部门管理-查看部门",330),
                        new Permisson(BusinessModules.DepartmentManagement, OperateTypes.DistributeDepartmentUser,"部门管理-分配部门用户",340),


                        new Permisson(BusinessModules.FlowManagement, OperateTypes.None,"流程管理模块",400),
                        new Permisson(BusinessModules.FlowManagement, OperateTypes.Modify,"流程管理-修改流程",410),
                        new Permisson(BusinessModules.FlowManagement, OperateTypes.View,"流程管理-查看流程",420),

                        new Permisson(BusinessModules.MyPendingFlowManagement, OperateTypes.None,"我的待审批流程",500),
                        new Permisson(BusinessModules.MyPendingFlowManagement, OperateTypes.Approve,"我的待审批流程-审批",510),
                        new Permisson(BusinessModules.MyPendingFlowManagement, OperateTypes.View,"我的待审批流程-查看",520),

                        new Permisson(BusinessModules.MySubmitFlowManagement, OperateTypes.None,"我提交的流程",600),
                        new Permisson(BusinessModules.MySubmitFlowManagement, OperateTypes.Confirm,"我提交的流程-确认",610),
                        new Permisson(BusinessModules.MySubmitFlowManagement, OperateTypes.View,"我提交的流程-查看",620),
                    };
                }
                return allPermission;
            }
            
        }

        public static Permisson GetPermission(string permission)
        {
            foreach (var p in Permissions)
            {
                if (p.Code == permission)
                {
                    return p;
                }
            }
            return null;
        }
    }

  

}
