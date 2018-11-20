using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Data;
using Dapper_NET20;
using System.Linq;

namespace BudgetSystem.Dal
{
    public class SystemConfigDal
    {
        public string GetSystemConfigValue(string name, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = @"SELECT  `Value` FROM SystemConfig  
                                    WHERE Name = @Name";
            IDbCommand command = con.CreateCommand();
            command.CommandText = selectSql;
            command.Transaction = tran;
            command.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("Name", name));
            object obj = command.ExecuteScalar();
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return null;
            }
        }
        public void ModifySystemConfig(string name, string value, IDbConnection con, IDbTransaction tran = null)
        {
            string updateSql = "Update `SystemConfig` Set `Value`=@Value  Where `Name` = @Name";
            con.Execute(updateSql, new { Name = name, Value = value }, tran);
        }
    }
}
