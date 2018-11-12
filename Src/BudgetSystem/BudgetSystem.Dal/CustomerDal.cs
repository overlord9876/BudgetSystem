using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Data;
using Dapper_NET20;
using System.Linq;
namespace BudgetSystem.Dal
{
    public class CustomerDal
    {
        public Customer GetCustomer(int id, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = @"SELECT s.*,u.RealName AS CreateUserName  FROM `Customer` s
                                    LEFT JOIN `User` u ON s.CreateUser=u.UserName 
                                    WHERE s.`ID` = @ID";
            Customer customer = con.Query<Customer>(selectSql, new { ID = id }, tran).SingleOrDefault();
            string salesmanSelectSql = "Select * From `CustomerSalesman` Where `Customer` = @ID";
            if (customer != null)
            {
                customer.SalesmanList = con.Query<CustomerSalesman>(salesmanSelectSql, new { ID = id }, tran).ToList();
            }
            return customer;
        }

        public IEnumerable<Customer> GetAllCustomer(IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = @"SELECT s.*,u.RealName AS CreateUserName  FROM `Customer` s
                                    LEFT JOIN `User` u ON s.CreateUser=u.UserName   ";
            return con.Query<Customer>(selectSql, null, tran);
        }

        public int AddCustomer(Customer customer, IDbConnection con, IDbTransaction tran = null)
        {
            string insertSql = @"Insert Into `Customer` (`Name`,`Country`,`CreateDate`,`CreateUser`,`Description`,`State`,
                                                          `Code`,`Email`,`Contacts`,`Address`,`Port`)
                                                 Values (@Name,@Country,now(),@CreateUser,@Description,@State,
                                                         @Code,@Email,@Contacts,@Address,@Port)";
            int id = con.Insert(insertSql, customer, tran);
            string salesmanInsertSql = "Insert Into `CustomerSalesman` (`Customer`,`Salesman`) Values(@Customer,@Salesman)";
            if (id > 0 && customer.SalesmanList != null && customer.SalesmanList.Any())
            {
                customer.SalesmanList.ForEach(s => s.Customer = id);
                con.Execute(salesmanInsertSql, customer.SalesmanList, tran);
            }
            return id;
        }
        public void ModifyCustomer(Customer customer, IDbConnection con, IDbTransaction tran = null)
        {
            string updateSql = @"Update `Customer` 
                                 Set `Name` = @Name,`Country` = @Country,`Description` = @Description,`State` = @State,
                                     `Code`=@Code,`Email`=@Email,`Contacts`=@Contacts,`Address`=@Address,`Port`=@Port
                                  Where `ID` = @ID";
            con.Execute(updateSql, customer, tran);
            string salesmanDeleteSql = "Delete From `CustomerSalesman` Where `Customer` = @Customer";
            con.Execute(salesmanDeleteSql, new { Customer = customer.ID }, tran);
            string salesmanInsertSql = "Insert Into `CustomerSalesman` (`Customer`,`Salesman`) Values(@Customer,@Salesman)";
            if (customer.SalesmanList != null && customer.SalesmanList.Any())
            {
                customer.SalesmanList.ForEach(s => s.Customer = customer.ID);
                con.Execute(salesmanInsertSql, customer.SalesmanList, tran);
            }
        }

        public void ModifyCustomerState(int id, bool state, IDbConnection con, IDbTransaction tran = null)
        {
            string updateSql = "Update `Customer` Set  `State` = @State  Where `ID` = @ID";
            con.Execute(updateSql, new { ID = id, State = state }, tran);
        }
    }
}
