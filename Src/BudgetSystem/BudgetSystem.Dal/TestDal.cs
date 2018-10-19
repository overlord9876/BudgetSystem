using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BudgetSystem.Entity;
using Dapper_NET20;
using System.Linq;

namespace BudgetSystem.Dal
{
    public class TestDal 
    {
        public void Test(IDbConnection con)
        {


            User user1 = new User();
            user1.UserName = "test1";
            user1.RealName = "test1";
            user1.Password = "abc";
            user1.Role = "";
            user1.Department = "";
            user1.CreateUser = "admin";
            user1.State = true;
            user1.UpdateDateTime = DateTime.Now;

            User user2 = new User();
            user2.UserName = "test2";
            user2.RealName = "test2";
            user2.Password = "abc";
            user2.Role = "";
            user2.Department = "";
            user2.CreateUser = "admin";
            user2.State = true;
            user2.UpdateDateTime = DateTime.Now;


            string deleteSql = "Delete From `User` Where `UserName` = @UserName";
            string insertSql = "Insert Into `User` (`UserName`,`RealName`,`Role`,`Department`,`Password`,`State`,`CreateUser`,`UpdateDateTime`) Values (@UserName,@RealName,@Role,@Department,@Password,@State,@CreateUser,@UpdateDateTime)";
            string selectSql = "Select `UserName`,`RealName`,`Role`,`Department`,`Password`,`State`,`CreateUser`,`UpdateDateTime` From `User` Where`UserName` = @UserName";
            string updateSql = "Update `User` Set `RealName` = @RealName,`Role` = @Role,`Department` = @Department,`Password` = @Password,`State` = @State,`CreateUser` = @CreateUser,`UpdateDateTime` = @UpdateDateTime Where `UserName` = @UserName";


            //插入用户
            int i = con.Execute(insertSql, user1);

            User user = con.Query<User>(selectSql, new { UserName = "test1" }).First();

            //修改用户
            user1.RealName = "ccccc";
            i = con.Execute(updateSql, user1);

            //删除用户
            i = con.Execute(deleteSql, user1);

            //批量插入
            i = con.Execute(insertSql, new object[] { user1, user2 });

            //使用 in
            deleteSql = "Delete From `User` Where `UserName` in @UserNames";

            i = con.Execute(deleteSql, new { UserNames = new string[] { "test1", "test2" } });

            user2.UserName = "test1";

            i = con.Execute(insertSql, user1);
            i = con.Execute(insertSql, user1);




            //多表的我就不写了，参见文章：https://www.cnblogs.com/guokun/p/5843871.html


        }

        public void Test2(IDbConnection con, IDbTransaction tran)
        {
            string insertSql = "Insert Into `User` (`UserName`,`RealName`,`Role`,`Department`,`Password`,`State`,`CreateUser`,`UpdateDateTime`) Values (@UserName,@RealName,@Role,@Department,@Password,@State,@CreateUser,@UpdateDateTime)";

            User user1 = new User();
            user1.UserName = "test1";
            user1.RealName = "test1";
            user1.Password = "abc";
            user1.Role = "";
            user1.Department = "";
            user1.CreateUser = "admin";
            user1.State = true;
            user1.UpdateDateTime = DateTime.Now;

            con.Execute(insertSql, user1, tran);
        }


        public void Test3(IDbConnection con, IDbTransaction tran)
        {

            string insertSql = "Insert Into `User` (`UserName`,`RealName`,`Role`,`Department`,`Password`,`State`,`CreateUser`,`UpdateDateTime`) Values (@UserName,@RealName,@Role,@Department,@Password,@State,@CreateUser,@UpdateDateTime)";


            User user2 = new User();
            user2.UserName = "test2";
            user2.RealName = "test2";
            user2.Password = "abc";
            user2.Role = "";
            user2.Department = "";
            user2.CreateUser = "admin";
            user2.State = true;
            user2.UpdateDateTime = DateTime.Now;

            con.Execute(insertSql, user2, tran);



          
            
        }

    }
}
