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

        public Department GetDepartment(string departmentCode)
        {
            var department = this.Query<Department>((con) =>
            {

                var uList = dal.GetDepartment(departmentCode,con, null);
                return uList;

            });
            return department;
        }

        public int CreateDepartment(Department department)
        {
            return this.ExecuteWithTransaction<int>((con, tran) =>
            {
                Department existdepartment = dal.GetDepartment(department.Code, con, tran);
                if (existdepartment != null)
                {
                    return 2;
                }
                dal.AddDepartment(department, con, null);
                return 1;
            });
        }

        public void ModifyDepartmentInfo(Department department)
        {
            this.ExecuteWithoutTransaction((con) =>
            {
                dal.ModifyDepartment(department, con, null);
            });
        }
    }
}
