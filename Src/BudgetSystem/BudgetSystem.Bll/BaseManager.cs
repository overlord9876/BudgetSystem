using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace BudgetSystem.Bll
{
    public abstract class BaseManager
    {

        protected IDbConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connection"].ToString();
            IDbConnection con = new MySqlConnection(connectionString);
            con.Open();
            return con;
        }

        protected void ExecuteWithoutTransaction(Action<IDbConnection> action)
        {
            using (IDbConnection con = GetConnection())
            {
                action(con);
            }
        }

        protected object ExecuteWithoutTransaction(Func<IDbConnection, object> func)
        {
            using (IDbConnection con = GetConnection())
            {
                return func(con);
            }
        }

        protected void ExecuteWithTransaction(Action<IDbConnection, IDbTransaction> action)
        {
            using (IDbConnection con = GetConnection())
            {
                IDbTransaction tran = con.BeginTransaction();

                try
                {
                    action(con, tran);
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }

        }


        protected object ExecuteWithTransaction(Func<IDbConnection, IDbTransaction, object> func)
        {
            using (IDbConnection con = GetConnection())
            {
                IDbTransaction tran = con.BeginTransaction();

                try
                {
                    object resut = func(con, tran);
                    tran.Commit();
                    return resut;
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }

        }


        protected IEnumerable<T> Query<T>(Func<IDbConnection, IEnumerable<T>> func)
        {
            using (IDbConnection con = GetConnection())
            {
                return func(con);
            }
        }
    }


}
