using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Data;
using Dapper_NET20;

namespace BudgetSystem.Dal
{
    public class UserDal
    {

        public IEnumerable<User> GetAllUser(IDbConnection con, IDbTransaction tran)
        {
            string selectSql = "Select `UserName`,`RealName`,`Role`,`Department`,`State`,`UpdateUser`,`UpdateDateTime` From `User`";
            return con.Query<User>(selectSql, null, tran);
        }

        public void AddUser(User user,IDbConnection con,IDbTransaction tran)
        {
            string insertSql = "Insert Into `User` (`UserName`,`RealName`,`Role`,`Department`,`Password`,`State`,`UpdateUser`,`UpdateDateTime`) Values (@UserName,@RealName,@Role,@Department,@Password,true,@UpdateUser,now())";
            con.Execute(insertSql, user, tran);
        }

        public void ModifyPassword(string userName,string newPassword,string updateUser,IDbConnection con,IDbTransaction tran)
        {
            string updateSql = "Update `User` Set `Password` = @Password ,`UpdateUser` = @UpdateUser,`UpdateDateTime` = now() Where `UserName` = @UserName";
            con.Execute(updateSql, new { Password = newPassword, UserName = userName, UpdateUser = updateUser }, tran);
        }

        public void ModifyUserState(string userName, bool isEnable, string updateUser, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = "Update `User` Set `State` = @State,`UpdateUser` = @UpdateUser,`UpdateDateTime` = now()  Where `UserName` = @UserName";
            con.Execute(updateSql, new { State = isEnable, UserName = userName, UpdateUser = updateUser }, tran);
        }

        public void ModifyUser(User user, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = "Update `User` Set `RealName` = @RealName,`Role` = @Role,`Department` = @Department,`UpdateUser` = @UpdateUser,`UpdateDateTime` = now() Where `UserName` = @UserName";
            con.Execute(updateSql, user, tran);
        }
    }
}
