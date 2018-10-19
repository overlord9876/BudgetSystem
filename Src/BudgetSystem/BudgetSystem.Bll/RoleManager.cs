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

        

    

    }
}
