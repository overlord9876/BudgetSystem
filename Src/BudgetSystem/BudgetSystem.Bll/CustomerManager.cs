using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Linq;
using BudgetSystem.Entity.QueryCondition;

namespace BudgetSystem.Bll
{
    public class CustomerManager : BaseManager
    {
        Dal.CustomerDal dal = new Dal.CustomerDal();

        public List<Customer> GetAllCustomer(CustomerQueryCondition condition = null)
        {
            var lst = this.Query<Customer>((con) =>
            {
                var uList = dal.GetAllCustomer(con, null, condition);
                return uList;

            });
            return lst.ToList();
        }

        public Customer GetCustomer(int id)
        {
            var Customer = this.Query<Customer>((con) =>
            {
                var uList = dal.GetCustomer(id, con);
                return uList;
            });
            return Customer;
        }

        public int AddCustomer(Customer customer)
        {
            return this.ExecuteWithTransaction<int>((con, tran) =>
            {
                int id = dal.AddCustomer(customer, con, tran);
                return id;
            });
        }

        public bool CheckName(string name, int id)
        {
            return this.ExecuteWithTransaction<bool>((con, tran) =>
            {
                bool result = dal.CheckName(name, id, con);
                return result;
            });

        }

        public bool IsUsed(Customer customer)
        {
            return this.ExecuteWithTransaction<bool>((con, tran) =>
            {
                bool isUsed = dal.IsUsed(customer, con, tran);
                return isUsed;
            });

        }

        public void DeleteCustomer(Customer customer)
        {
            this.ExecuteWithTransaction((con, tran) =>
           {
               dal.DeleteCustomer(customer, con, tran);
           });

        }

        public void ModifyCustomer(Customer customer)
        {
            this.ExecuteWithTransaction((con, tran) =>
            {
                dal.ModifyCustomer(customer, con, tran);
            });
        }

        public void ModifyCustomerState(int id, bool state)
        {
            this.ExecuteWithTransaction((con, tran) =>
            {
                dal.ModifyCustomerState(id, state, con, tran);
            });
        }
    }
}
