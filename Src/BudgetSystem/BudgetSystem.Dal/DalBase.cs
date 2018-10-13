using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BudgetSystem.Dal
{
    public class DalBase
    {
        protected IDbConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connection"].ToString();

            IDbConnection con = new MySqlConnection(connectionString);

            con.Open();

            return con;
        }


    }
}
