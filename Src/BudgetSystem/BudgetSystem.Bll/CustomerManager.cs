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
                var uList = dal.GetAllCustomer(con,null,condition);
                return uList;

            });
            return lst.ToList();
        }
        public Customer GetCustomer(int id)
        {
            var Customer = this.Query<Customer>((con) =>
            { 
                var uList = dal.GetCustomer(id,con); 
                return uList; 
            });
            return Customer;
        }
        
        public int AddCustomer(Customer Customer)
        {
            return this.ExecuteWithTransaction<int>((con, tran) =>
            { 
                int id= dal.AddCustomer(Customer,con,tran);
                return id;
            });
        }

        public void ModifyCustomer(Customer Customer)
        {
            this.ExecuteWithTransaction((con,tran) =>
            { 
                dal.ModifyCustomer(Customer,con,tran);
            });
        }
        public void ModifyCustomerState(int id, bool state)
        {
            this.ExecuteWithTransaction((con, tran) =>
            {
                dal.ModifyCustomerState(id,state, con, tran);
            });
        }
    }
}
