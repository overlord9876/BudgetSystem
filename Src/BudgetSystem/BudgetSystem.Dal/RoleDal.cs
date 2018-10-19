using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Data;
using Dapper_NET20;
using System.Linq;

namespace BudgetSystem.Dal
{
    public class RoleDal
    {

        string deleteSql = "Delete From `Role` Where `Code` = @Code";
        string insertSql = "Insert Into `Role` (`Code`,`Name`,`Remark`) Values (@Code,@Name,@Remark)";
        string selectSql = "Select `Code`,`Name`,`Remark` From `Role` Where`Code` = @Code";
        string updateSql = "Update `Role` Set `Name` = @Name,`Remark` = @Remark Where `Code` = @Code";


        public IEnumerable<Role> GetAllRole(IDbConnection con, IDbTransaction tran)
        {
            string selectSql = "Select `Code`,`Name`,`Remark` From `Role`";
            return con.Query<Role>(selectSql, null, tran);
        }

    }
}
