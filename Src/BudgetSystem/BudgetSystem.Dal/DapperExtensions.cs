using System;
using System.Collections.Generic;
using System.Text;
using Dapper_NET20;
using System.Data;
using System.Linq;

namespace BudgetSystem.Dal
{
    public static class DapperExtensions
    {
        public static int Insert(this IDbConnection con, string sql, object param, IDbTransaction transaction = null)
        {
            con.Execute(sql, param, transaction);
            IDbCommand command = con.CreateCommand();
            command.CommandText = "Select LAST_INSERT_ID() id";
            command.Transaction = transaction;
            object obj = command.ExecuteScalar();
            return Convert.ToInt32(obj);
        }
    }
}
