﻿using System;
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

        public IEnumerable<Department> GetAllDepartment(IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select `ID`,`Code`,`Name`,`Manager`,t1.RealName as ManagerName,`AssistantManager`,t2.RealName as AssistantManagerName,`Remark`,`Department`.`CreateUser`,`Department`.`UpdateDatetime` From `Department` 
            Left Join `User` t1 on t1.UserName= `Department`.Manager 
            Left Join `User` t2 on t2.UserName= `Department`.AssistantManager ";
            return con.Query<Department>(selectSql, null, tran);
        }
        public Department GetDepartment(int deptID, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select `ID`,`Code`,`Name`,`Manager`,t1.RealName as ManagerName,`AssistantManager`,t2.RealName as AssistantManagerName,`Remark`,`Department`.`CreateUser`,`Department`.`UpdateDatetime` From `Department` 
            Left Join `User` t1 on t1.UserName= `Department`.Manager 
            Left Join `User` t2 on t2.UserName= `Department`.AssistantManager 
            Where `Department`.`ID`=@ID";
            return con.Query<Department>(selectSql, new { ID = deptID }, tran).SingleOrDefault();
        }

        public Department GetDepartment(string departmentCode, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select `ID`,`Code`,`Name`,`Manager`,t1.RealName as ManagerName,`AssistantManager`,t2.RealName as AssistantManagerName,`Remark`,`Department`.`CreateUser`,`Department`.`UpdateDatetime` From `Department` 
            Left Join `User` t1 on t1.UserName= `Department`.Manager 
            Left Join `User` t2 on t2.UserName= `Department`.AssistantManager 
            Where `Department`.`ID`=@ID";
            return con.Query<Department>(selectSql, new { ID = departmentCode }, tran).SingleOrDefault();
        }

        public bool CheckDepartmentCode(int id, string code, IDbConnection con)
        {
            string selectSql = @"SELECT  b.id FROM `Department` b  
                                    WHERE ID<>@ID and Code=@Code";
            IDbCommand command = con.CreateCommand();
            command.CommandText = selectSql;
            command.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("ID", id));
            command.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("Code", code));
            object obj = command.ExecuteScalar();
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int AddDepartment(Department department, IDbConnection con, IDbTransaction tran)
        {
            string insertSql = "Insert Into `Department` (`Code`,`Name`,`Manager`,`AssistantManager`,`Remark`,`CreateUser`,`UpdateDatetime`) Values (@Code,@Name,@Manager,@AssistantManager,@Remark,@CreateUser,@UpdateDatetime)";
            int id = con.Insert(insertSql, department, tran);
            return id;
        }

        public void ModifyDepartment(Department department, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = "Update `Department` Set `Code` = @Code,`Name` = @Name,`Manager` = @Manager,`AssistantManager` = @AssistantManager,`Remark` = @Remark,`CreateUser` = @CreateUser,`UpdateDatetime` = @UpdateDatetime Where `ID` = @ID";

            con.Execute(updateSql, department, tran);
        }

    }
}
