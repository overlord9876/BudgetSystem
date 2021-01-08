using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BudgetSystem.Dal
{
    public class DalBase
    {
        protected virtual bool CheckExpired(DateTime updateDate1, DateTime updateDate2)
        {
            return updateDate1.ToString("yyyyMMddHHmmssfff") != updateDate2.ToString("yyyyMMddHHmmssfff");
        }

        /// <summary>
        /// 获取当前更新时间
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="ModifyDateTimeColumnName"></param>
        /// <param name="id"></param>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        /// <param name="PKColumnName"></param>
        /// <returns></returns>
        public DateTime GetModifyDateTimeByTable(string tableName, string ModifyDateTimeColumnName, int id, IDbConnection con, IDbTransaction tran, string PKColumnName = "ID")
        {
            string selectSql = string.Format(@"select {0} from {1} where {2}=@ID", ModifyDateTimeColumnName, tableName, PKColumnName);

            IDbCommand command = con.CreateCommand();
            command.CommandText = selectSql;
            command.Transaction = tran;
            IDbDataParameter paramter = command.CreateParameter();
            paramter.DbType = DbType.Int32;
            paramter.ParameterName = "ID";
            paramter.Value = id;
            command.Parameters.Add(paramter);
            object obj = command.ExecuteScalar();
            DateTime versionNumber = DateTime.MinValue.AddDays(1);
            if (obj != null)
            {
                DateTime.TryParse(obj.ToString(), out versionNumber);
            }
            return versionNumber;
        }

        public DateTime GetDateTimeNow(IDbConnection con)
        {
            string selectSql = "SELECT NOW();";
            IDbCommand command = con.CreateCommand();
            command.CommandText = selectSql;
            object obj = command.ExecuteScalar();
            return Convert.ToDateTime(obj);
        }
    }
}
