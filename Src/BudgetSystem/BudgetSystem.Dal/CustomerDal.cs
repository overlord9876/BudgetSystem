using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using BudgetSystem.Entity.QueryCondition;
using System.Data;
using Dapper_NET20;
using System.Linq;
using MySql.Data.MySqlClient;
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

        public IEnumerable<Customer> GetAllCustomer(IDbConnection con, IDbTransaction tran = null, CustomerQueryCondition condition = null)
        {
            string selectSql = @"SELECT s.*,u.RealName AS CreateUserName  FROM `Customer` s
                                    LEFT JOIN `User` u ON s.CreateUser=u.UserName   ";
            DynamicParameters dp = new DynamicParameters();
            if (condition != null)
            {
                List<string> strConditionList = new List<string>();

                if (!string.IsNullOrEmpty(condition.CreateUser))
                {
                    strConditionList.Add(" s.CreateUser=@CreateUser ");
                    dp.Add("CreateUser", condition.CreateUser, null, null, null);
                }
                if (!string.IsNullOrEmpty(condition.Code))
                {
                    strConditionList.Add(" s.Code Like @Code ");
                    dp.Add("Code", string.Format("%{0}%", condition.Code), null, null, null);
                }
                if (!string.IsNullOrEmpty(condition.CustomName))
                {
                    strConditionList.Add(" s.Name Like @Name ");
                    dp.Add("Name", string.Format("%{0}%", condition.CustomName), null, null, null);
                }

                if (!string.IsNullOrEmpty(condition.Salesman))
                {
                    strConditionList.Add(" ID in (SELECT customer from customersalesman where salesman=@salesman) ");
                    dp.Add("salesman", condition.Salesman, null, null, null);
                }

                if (condition.DeptID >= 0)
                {
                    strConditionList.Add(" ID in (SELECT customer from customersalesman cs LEFT JOIN `user` u on cs.Salesman=u.UserName where u.DeptID=@DeptID) ");

                    dp.Add("DeptID", condition.DeptID, null, null, null);
                }

                if (condition.State >= 0)
                {
                    strConditionList.Add(" s.State>=@State ");
                    dp.Add("State", condition.State, null, null, null);
                }
                if (strConditionList.Count > 0)
                {
                    selectSql += string.Format(" where {0}", string.Join(" and ", strConditionList.ToArray()));
                }
            }
            return con.Query<Customer>(selectSql, dp, tran);
        }

        /// <summary>
        /// 验证名称是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contractNo"></param>
        /// <param name="con"></param>
        /// <returns></returns>
        public bool CheckName(string name, int id, IDbConnection con)
        {
            string selectSql = @"SELECT  id FROM `customer`  WHERE ID<>@ID and `Name`=@Name";
            IDbCommand command = con.CreateCommand();
            command.CommandText = selectSql;
            command.Parameters.Add(new MySqlParameter("ID", id));
            command.Parameters.Add(new MySqlParameter("Name", name));
            object obj = command.ExecuteScalar();
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
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

        public bool IsUsed(Customer customer, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = @"SELECT Cus_ID from budgetcustomers where Cus_ID=@ID;";
            IDbCommand command = con.CreateCommand();
            command.CommandText = selectSql;
            command.Parameters.Add(new MySqlParameter("ID", customer.ID));
            object obj = command.ExecuteScalar();
            if (obj != null)
            {
                return true;
            }

            selectSql = @"SELECT CustomerID from Budget WHERE CustomerID=@ID;";
            command = con.CreateCommand();
            command.CommandText = selectSql;
            command.Parameters.Add(new MySqlParameter("ID", customer.ID));
            obj = command.ExecuteScalar();
            if (obj != null)
            {
                return true;
            }

            selectSql = @"SELECT Cus_ID from BudgetBill where Cus_ID=@ID;";
            command = con.CreateCommand();
            command.CommandText = selectSql;
            command.Parameters.Add(new MySqlParameter("ID", customer.ID));
            obj = command.ExecuteScalar();
            if (obj != null)
            {
                return true;
            }

            selectSql = @"SELECT Cus_ID from BankSlip where Cus_ID=@ID;";
            command = con.CreateCommand();
            command.CommandText = selectSql;
            command.Parameters.Add(new MySqlParameter("ID", customer.ID));
            obj = command.ExecuteScalar();
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteCustomer(Customer customer, IDbConnection con, IDbTransaction tran = null)
        {
            string salesmanDeleteSql = "Delete From `CustomerSalesman` Where `Customer` = @Customer";
            con.Execute(salesmanDeleteSql, new { Customer = customer.ID }, tran);

            string updateSql = @"delete from `Customer` Where `ID` = @ID";
            con.Execute(updateSql, new { ID = customer.ID }, tran);
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
