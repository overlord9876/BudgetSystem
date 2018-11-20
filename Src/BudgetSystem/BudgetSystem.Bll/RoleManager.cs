using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Linq;
namespace BudgetSystem.Bll
{
    public class RoleManager:BaseManager
    {

        Dal.RoleDal dal = new Dal.RoleDal();


        public List<Role> GetAllRole()
        {
            var lst = this.Query<Role>((con) =>
            {

                var uList = dal.GetAllRole(con, null);
                return uList;

            });
            return lst.ToList();
        }

        public List<string> GetRolePermissions(string roleCode)
        {
            var lst = this.Query<string>((con) =>
            {

                var pList = dal.GetRolePermissions(roleCode,con, null);
                return pList;

            });
            return lst.ToList();
        }


        public void AddRolePermission(string roleCode, List<string> newPermissions)
        {

            this.ExecuteWithTransaction((con, tran) => 
            {
                var pList = dal.GetRolePermissions(roleCode, con, tran);

                List<string> ps = pList.Union(newPermissions).ToList();

                dal.ClearRolePermissons(roleCode, con, tran);
                dal.SaveRolePermissons(roleCode, ps, con, tran);
            
            
            });


        
        }

        public void RemoveRolePermission(string roleCode, List<string> removePermissions)
        {
            this.ExecuteWithTransaction((con, tran) =>
            {
                var pList = dal.GetRolePermissions(roleCode, con, tran);

                List<string> ps = pList.Except(removePermissions).ToList();

                dal.ClearRolePermissons(roleCode, con, tran);
                dal.SaveRolePermissons(roleCode, ps, con, tran);


            });

        }

    }
}
