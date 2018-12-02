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

        public static void SetConnectionString(string connection, bool isEncrypted = true)
        {
            if (isEncrypted)
            {
                ConnectionString = Util.DES.Decrypt(connection);
            }
            else
            {
                ConnectionString = connection;
            }


        }


        private static string ConnectionString
        {
            get;
            set;
        }



        protected IDbConnection GetConnection()
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["connection"].ToString();
            //IDbConnection con = new MySqlConnection(connectionString);

            IDbConnection con = new MySqlConnection(ConnectionString);
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

        protected T ExecuteWithoutTransaction<T>(Func<IDbConnection, T> func)
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


        protected T ExecuteWithTransaction<T>(Func<IDbConnection, IDbTransaction, T> func)
        {
            using (IDbConnection con = GetConnection())
            {
                IDbTransaction tran = con.BeginTransaction();

                try
                {
                    T resut = func(con, tran);
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

        protected T Query<T>(Func<IDbConnection, T> func)
        {
            using (IDbConnection con = GetConnection())
            {
                return func(con);
            }
        }
    }


}
