using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Linq;

namespace BudgetSystem.Bll
{
    public class BudgetManager : BaseManager
    {
        Dal.BudgetDal dal = new Dal.BudgetDal();
        Dal.ActualReceiptsDal arDal = new Dal.ActualReceiptsDal();
        Dal.PaymentNotesDal pnd = new Dal.PaymentNotesDal();

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
            this.ExecuteWithTransaction((con, tran) =>
            {
                dal.ModifyBudget(Budget, con, tran);
            });
        }

        public List<AccountBill> GetAccountBillDetailByBudgetId(int budgetId)
        {
            var lst = this.Query<AccountBill>((con) =>
            {
                var arList = arDal.GetActualReceiptsByBudgetId(budgetId, con, null);
                var abList = arList.ToAccountBillList();
                var pmList = pnd.GetTotalAmountPaymentMoneyByBudgetId(budgetId, con, null);
                abList.AddRange(pmList.ToAccountBillList());
                return abList.OrderBy(o => o.CreateDate);
            });
            return lst.ToList();

        }

    }
}
