using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper_NET20;
using BudgetSystem.Entity;

namespace BudgetSystem.Dal
{
    public class CommonDal
    {
        public bool ExistsCodeType(CodeType ct, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = "select COUNT(1) from CodeGenerator where CodeType=@CodeType;";
            using (IDbCommand command = con.CreateCommand())
            {
                command.CommandText = selectSql;
                command.Transaction = tran;
                IDbDataParameter paramter = command.CreateParameter();
                paramter.DbType = DbType.Int16;
                paramter.ParameterName = "CodeType";
                paramter.Value = ct;
                command.Parameters.Add(paramter);
                object obj = command.ExecuteScalar();
                int count = 0;
                int.TryParse(obj.ToString(), out count);
                return count > 0;
            }
        }

        public int GetCodeValueByType(CodeType ct, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = "select CodeValue from CodeGenerator where CodeType=@CodeType;";
            using (IDbCommand command = con.CreateCommand())
            {
                command.CommandText = selectSql;
                command.Transaction = tran;
                IDbDataParameter paramter = command.CreateParameter();
                paramter.DbType = DbType.Int16;
                paramter.ParameterName = "CodeType";
                paramter.Value = ct;
                command.Parameters.Add(paramter);
                object obj = command.ExecuteScalar();
                int codeValue = 1;
                int.TryParse(obj.ToString(), out codeValue);
                return codeValue;
            }
        }

        public int AddCodeGenerator(CodeType ct, IDbConnection con, IDbTransaction tran = null)
        {
            string insertSql = @"INSERT into CodeGenerator(CodeType,CodeValue)Values(@CodeType,@CodeValue);";
            return con.Execute(insertSql, new { CodeType = (int)ct, CodeValue = 1 }, tran);
        }

        public int UpdateCodeGenerator(CodeType ct, int codeValue, IDbConnection con, IDbTransaction tran = null)
        {
            string updateSql = @"update CodeGenerator set CodeValue=@CodeValue where CodeType=@CodeType;";
            return con.Execute(updateSql, new { CodeType = (int)ct, CodeValue = codeValue }, tran);
        }

        public DateTime GetDateTimeNow(IDbConnection con)
        {
            string selectSql = "SELECT NOW();";
            using (IDbCommand command = con.CreateCommand())
            {
                command.CommandText = selectSql;
                object obj = command.ExecuteScalar();
                return Convert.ToDateTime(obj);
            }
        }

        public IEnumerable<DateExchangeRate> GetDateExchanges(IDbConnection con, IDbTransaction tran = null)
        {
            string sql = @"SELECT item.date, round(AVG(item.ExchangeRate), 6) as ExchangeRate from(
                         SELECT DATE_FORMAT(ReceiptDate, '%Y-%m-%d') as date, ExchangeRate FROM bankslip WHERE Currency = 'USD'
                         UNION
                         SELECT DATE_FORMAT(PaymentDate, '%Y-%m-%d') as date, ExchangeRate from paymentnotes WHERE Currency = '美元') item
                         GROUP BY item.date
                         ORDER BY item.date";
            return con.Query<DateExchangeRate>(sql, null, tran);
        }

    }
}
