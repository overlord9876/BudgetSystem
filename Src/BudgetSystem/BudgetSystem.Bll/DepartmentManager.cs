using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BudgetSystem.Entity;

namespace BudgetSystem.Bll
{
    public class DepartmentManager : BaseManager
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

        public Department GetDepartment(int deptID)
        {
            var department = this.Query<Department>((con) =>
            {

                var uList = dal.GetDepartment(deptID, con, null);
                return uList;

            });
            return department;
        }
        
        public bool CheckDepartmentCode(int id, string code)
        {
            return this.ExecuteWithTransaction<bool>((con, tran) =>
            {
                return dal.CheckDepartmentCode(id, code, con);
            });
        }

        public int CreateDepartment(Department department)
        {
            return this.ExecuteWithTransaction<int>((con, tran) =>
            {
                return dal.AddDepartment(department, con, null);
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
