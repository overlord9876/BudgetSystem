using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BudgetSystem.Entity;

namespace BudgetSystem.Bll
{
    public  class DepartmentManager:BaseManager
    {
        Dal.DepartmentDal dal = new Dal.DepartmentDal();
        public List<Department> GetAllDepartment()
        {
            var lst = this.Query<Department>((con) =>
            {

                var uList = dal.GetAllDepartment(con, null);
                return uList;

            });
            return lst.ToList();
        }




    }
}
