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

        public Permisson(BusinessModules module,OperateTypes operate,string displayName,int displayOrder)
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


        public static List<Permisson> GetAll()
        {
            return new List<Permisson>() 
            { 
                new Permisson(BusinessModules.UserManagement, OperateTypes.New,"用户管理模板",100),
                new Permisson(BusinessModules.UserManagement, OperateTypes.New,"用户管理-新增用户",110),
                new Permisson(BusinessModules.UserManagement, OperateTypes.New,"用户管理-修改用户",120),
                new Permisson(BusinessModules.UserManagement, OperateTypes.New,"用户管理-启动用户",130),
                new Permisson(BusinessModules.UserManagement, OperateTypes.New,"用户管理-停用用户",140),
                new Permisson(BusinessModules.UserManagement, OperateTypes.New,"用户管理-重置密码",150),
                new Permisson(BusinessModules.UserManagement, OperateTypes.New,"用户管理-查看用户详情",1060),
                new Permisson(BusinessModules.RoleManagement, OperateTypes.New,"角色管理模块",200),
                new Permisson(BusinessModules.UserManagement, OperateTypes.DistributeRolePermission,"角色管理-分配权限",210),
                new Permisson(BusinessModules.UserManagement, OperateTypes.DistributeRoleUser,"角色管理-分配用户",220),
               


            
            
            
            };
        
        
        
        }
    }

  

}
