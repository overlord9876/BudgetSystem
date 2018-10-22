using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Linq;

namespace BudgetSystem.Bll
{
    public class BudgetManager:BaseManager
    { 
        Dal.BudgetDal dal = new Dal.BudgetDal();

        public List<Budget> GetAllBudget()
        {
            var lst = this.Query<Budget>((con) =>
            {
                var uList = dal.GetAllBudget(con);
                return uList; 
            });
            return lst.ToList();
        }
        public Budget GetBudget(int id)
        {
            var Budget = this.Query<Budget>((con) =>
            {
                var uList = dal.GetBudget(id, con);
                return uList;
            });
            return Budget;
        }

        public int AddBudget(Budget Budget)
        {
            return this.ExecuteWithTransaction<int>((con, tran) =>
            {
                int id = dal.AddBudget(Budget, con, tran);
                return id;
            });
        }
        public void ModifyBudget(Budget Budget)
        {
            this.ExecuteWithTransaction((con,tran) =>
            {
                dal.ModifyBudget(Budget, con,tran);
            });
        }
    }
}
