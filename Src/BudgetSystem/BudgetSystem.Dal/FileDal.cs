using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Data;
using Dapper_NET20;
using System.Linq;

namespace BudgetSystem.Dal
{
    public class FileDal
    {
        //string deleteSql = "Delete From `Files` Where `MD5` = @MD5";
        //string insertSql = "Insert Into `Files` (`MD5`,`Data`) Values (@MD5,@FileData)";
        //string selectSql = "Select `MD5`,`Data` From `Files` Where`MD5` = @MD5";
        //string updateSql = "Update `Files` Set `Data` = @Data Where `MD5` = @MD5";
        public Entity.FileData GetFileWihoutData(string md5, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = "Select `MD5` From `Files` Where`MD5` = @MD5";
            return con.Query<FileData>(selectSql, new { MD5 = md5 }, tran).SingleOrDefault();
        }


        public FileData GetFileWihData(string md5, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = "Select `MD5`,`Data` From `Files` Where`MD5` = @MD5";
            return con.Query<FileData>(selectSql, new { MD5 = md5 }, tran).SingleOrDefault();
        }

        public void AddFile(FileData file, IDbConnection con, IDbTransaction tran)
        {
            using (IDbCommand command = con.CreateCommand())
            {
                command.CommandText = "Insert Into `Files` (`MD5`,`Data`) Values (@MD5,@Data)";
                command.Transaction = tran;


                MySql.Data.MySqlClient.MySqlParameter p1 = new MySql.Data.MySqlClient.MySqlParameter("@MD5", MySql.Data.MySqlClient.MySqlDbType.String);
                p1.Value = file.MD5;
                MySql.Data.MySqlClient.MySqlParameter p2 = new MySql.Data.MySqlClient.MySqlParameter("@Data", MySql.Data.MySqlClient.MySqlDbType.MediumBlob);
                p2.Value = file.Data;
                command.Parameters.Add(p1);
                command.Parameters.Add(p2);
                command.ExecuteNonQuery();
            }
        }

    }
}
