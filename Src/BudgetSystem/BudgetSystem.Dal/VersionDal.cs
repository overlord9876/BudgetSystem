using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Data;
using Dapper_NET20;
using System.Linq;


namespace BudgetSystem.Dal
{
    public class VersionDal
    {
        //string deleteSql = "Delete From `VersionInfo` Where `ID` = @ID";
        //string insertSql = "Insert Into `VersionInfo` (`ID`,`Version`,`FileMD5`,`FileName`,`FilePath`) Values (@ID,@Version,@FileMD5,@FileName,@FilePath)";
        //string selectSql = "Select `ID`,`Version`,`FileMD5`,`FileName`,`FilePath` From `VersionInfo` Where`ID` = @ID";
        //string updateSql = "Update `VersionInfo` Set `Version` = @Version,`FileMD5` = @FileMD5,`FileName` = @FileName,`FilePath` = @FilePath Where `ID` = @ID";


        public VersionFile GetTopVersionInfoFile(string verion, IDbConnection con, IDbTransaction tran)
        {
            string sql = "select * from `VersionInfo` where `Version` = @Version LIMIT 1";
            return con.Query<VersionFile>(sql, new { Version = verion }, tran).SingleOrDefault();
        }


        public void AddVerisonInfoFiles(List<VersionFile> files, IDbConnection con, IDbTransaction tran)
        {
            string insertSql = "Insert Into `VersionInfo` (`ID`,`Version`,`FileMD5`,`FileName`,`FilePath`) Values (@ID,@Version,@FileMD5,@FileName,@FilePath)";
            con.Execute(insertSql, files, tran);
        }

    }
}
