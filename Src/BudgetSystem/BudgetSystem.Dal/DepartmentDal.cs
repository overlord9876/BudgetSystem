using System;
using System.Collections.Generic;
using System.Text;
using Dapper_NET20;
using System.Linq;
using BudgetSystem.Entity;
using System.Data;


namespace BudgetSystem.Dal
{
    public class DepartmentDal
    {
        string deleteSql = "Delete From `Department` Where `Code` = @Code";
        string insertSql = "Insert Into `Department` (`Code`,`Name`,`Manager`,`AssistantManager`,`Remark`,`CreateUser`,`UpdateDatetime`) Values (@Code,@Name,@Manager,@AssistantManager,@Remark,@CreateUser,@UpdateDatetime)";
        string selectSql = "Select `Code`,`Name`,`Manager`,`AssistantManager`,`Remark`,`CreateUser`,`UpdateDatetime` From `Department` Where`Code` = @Code";
        string updateSql = "Update `Department` Set `Name` = @Name,`Manager` = @Manager,`AssistantManager` = @AssistantManager,`Remark` = @Remark,`CreateUser` = @CreateUser,`UpdateDatetime` = @UpdateDatetime Where `Code` = @Code";

        public IEnumerable<Department> GetAllDepartment(IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select `Code`,`Name`,`Manager`,t1.RealName as ManagerName,`AssistantManager`,t2.RealName as AssistantManagerName,`Remark`,`Department`.`CreateUser`,`Department`.`UpdateDatetime` From `Department` 
            Left Join `User` t1 on t1.UserName= `Department`.Manager 
            Left Join `User` t2 on t2.UserName= `Department`.AssistantManager ";
            return con.Query<Department>(selectSql, null, tran);
        }
    
    }
}
