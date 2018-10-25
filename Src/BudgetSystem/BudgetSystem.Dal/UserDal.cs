using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Data;
using Dapper_NET20;
using System.Linq;

namespace BudgetSystem.Dal
{
    public class UserDal
    {

        public User GetUser(string userName, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select `UserName`,`RealName`,`Role`,`Role`.`Name` as RoleName,`Department`,`Department`.`Name` as DepartmentName,`State`,`User`.`CreateUser`, `User`.`UpdateDateTime` 
            From `User` 
            Left Join `Role` on `User`.`Role` = `Role`.`Code` 
            Left Join `Department` on `User`.`Department` = `Department`.Code
            where UserName=@UserName";
            return con.Query<User>(selectSql, new  { UserName=userName }, tran).SingleOrDefault();
        }

        public User GetUser(string userName,string password, IDbConnection con, IDbTransaction tran)
        {
         

            string selectSql = @"Select `UserName`,`RealName`,`Role`,`Role`.`Name` as RoleName,`Department`,`Department`.`Name` as DepartmentName,`State`,`User`.`CreateUser`, `User`.`UpdateDateTime` 
            From `User` 
            Left Join `Role` on `User`.`Role` = `Role`.`Code` 
            Left Join `Department` on `User`.`Department` = `Department`.Code
            where UserName=@UserName and Password=@Password";
            return con.Query<User>(selectSql, new { UserName = userName, Password=password }, tran).SingleOrDefault();
        }

        public IEnumerable<User> GetAllUser(IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select `UserName`,`RealName`,`Role`,`Role`.`Name` as RoleName,`Department`,`Department`.`Name` as DepartmentName,`State`,`User`.`CreateUser`, `User`.`UpdateDateTime` 
            From `User` 
            Left Join `Role` on `User`.`Role` = `Role`.`Code` 
            Left Join `Department` on `User`.`Department` = `Department`.Code";
            return con.Query<User>(selectSql, null, tran);
        }

        public IEnumerable<User> GetAllEnabledUser(IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select `UserName`,`RealName`,`Role`,`Role`.`Name` as RoleName,`Department`,`Department`.`Name` as DepartmentName,`State`,`User`.`CreateUser`, `User`.`UpdateDateTime` 
            From `User` 
            Left Join `Role` on `User`.`Role` = `Role`.`Code` 
            Left Join `Department` on `User`.`Department` = `Department`.Code
            where `State`=1";
            return con.Query<User>(selectSql, null, tran);
        }

        public IEnumerable<User> GetRoleUsers(string roleCode, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select `UserName`,`RealName`,`Role`,`Role`.`Name` as RoleName,`Department`,`Department`.`Name` as DepartmentName,`State`,`User`.`CreateUser`, `User`.`UpdateDateTime` 
            From `User` 
            Left Join `Role` on `User`.`Role` = `Role`.`Code` 
            Left Join `Department` on `User`.`Department` = `Department`.Code
            Where `Role`=@Role";
            return con.Query<User>(selectSql, new { Role = roleCode }, tran);

        }

        public IEnumerable<User> GetNotRoleUsers(string roleCode, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select `UserName`,`RealName`,`Role`,`Role`.`Name` as RoleName,`Department`,`Department`.`Name` as DepartmentName,`State`,`User`.`CreateUser`, `User`.`UpdateDateTime` 
            From `User` 
            Left Join `Role` on `User`.`Role` = `Role`.`Code` 
            Left Join `Department` on `User`.`Department` = `Department`.Code
            Where `Role`<>@Role";
            return con.Query<User>(selectSql, new { Role = roleCode }, tran);

        }


        public IEnumerable<User> GetDepartmentUsers(string departmentCode, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select `UserName`,`RealName`,`Role`,`Role`.`Name` as RoleName,`Department`,`Department`.`Name` as DepartmentName,`State`,`User`.`CreateUser`, `User`.`UpdateDateTime` 
            From `User` 
            Left Join `Role` on `User`.`Role` = `Role`.`Code` 
            Left Join `Department` on `User`.`Department` = `Department`.Code
            Where `Department`=@Department";
            return con.Query<User>(selectSql, new { Department = departmentCode }, tran);

        }

        public IEnumerable<User> GetNotDepartmentUsers(string departmentCode, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select `UserName`,`RealName`,`Role`,`Role`.`Name` as RoleName,`Department`,`Department`.`Name` as DepartmentName,`State`,`User`.`CreateUser`, `User`.`UpdateDateTime` 
            From `User` 
            Left Join `Role` on `User`.`Role` = `Role`.`Code` 
            Left Join `Department` on `User`.`Department` = `Department`.Code
            Where `Department`<>@Department";
            return con.Query<User>(selectSql, new { Department = departmentCode }, tran);

        }

        public void AddUser(User user,IDbConnection con,IDbTransaction tran)
        {
            string insertSql = "Insert Into `User` (`UserName`,`RealName`,`Role`,`Department`,`Password`,`State`,`CreateUser`,`UpdateDateTime`) Values (@UserName,@RealName,@Role,@Department,@Password,true,@CreateUser,now())";
            con.Execute(insertSql, user, tran);
        }

        public void ModifyPassword(string userName,string newPassword,IDbConnection con,IDbTransaction tran)
        {
            string updateSql = "Update `User` Set `Password` = @Password ,`UpdateDateTime` = now() Where `UserName` = @UserName";
            con.Execute(updateSql, new { Password = newPassword, UserName = userName }, tran);
        }

        public void ModifyUserState(string userName, bool isEnable, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = "Update `User` Set `State` = @State,`UpdateDateTime` = now()  Where `UserName` = @UserName";
            con.Execute(updateSql, new { State = isEnable, UserName = userName }, tran);
        }

        public void ModifyUser(User user, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = "Update `User` Set `RealName` = @RealName,`Role` = @Role,`Department` = @Department,`UpdateDateTime` = now() Where `UserName` = @UserName";
            con.Execute(updateSql, user, tran);
        }

        public void SetUsersRole(List<string> users, string roleCode, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = "Update `User` Set `Role` = @Role ,`UpdateDateTime` = now() Where `UserName` = @UserName";

            List<User> userList = new List<User>();
            foreach (string user in users)
            {
                User u = new User() { UserName = user, Role = roleCode};
                userList.Add(u);
            }

            con.Execute(updateSql, userList, tran);
        }

        public void SetUsersDepartment(List<string> users, string departmentCode, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = "Update `User` Set `Department` = @Department ,`UpdateDateTime` = now() Where `UserName` = @UserName";

            List<User> userList = new List<User>();
            foreach (string user in users)
            {
                User u = new User() { UserName = user, Department = departmentCode };
                userList.Add(u);
            }

            con.Execute(updateSql, userList, tran);
        }
    }
}
 