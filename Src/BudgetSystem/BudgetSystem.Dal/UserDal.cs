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
            string selectSql = @"Select `UserName`,`RealName`,`Role`,`Role`.`Name` as RoleName,DeptID,`Department`.Code as Department,`Department`.`Name` as DepartmentName,`State`,`User`.`CreateUser`, `User`.`UpdateDateTime` 
            From `User` 
            Left Join `Role` on `User`.`Role` = `Role`.`Code` 
            Left Join `Department` on `User`.`DeptID` = `Department`.ID
            where UserName=@UserName";
            return con.Query<User>(selectSql, new { UserName = userName }, tran).SingleOrDefault();
        }

        public User GetUser(string userName, string password, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select `UserName`,`RealName`,`Role`,`Role`.`Name` as RoleName,DeptID,`Department`.Code as Department,`Department`.`Name` as DepartmentName,`State`,`User`.`CreateUser`, `User`.`UpdateDateTime` 
            From `User` 
            Left Join `Role` on `User`.`Role` = `Role`.`Code` 
            Left Join `Department` on `User`.`DeptID` = `Department`.ID
            where UserName=@UserName and Password=@Password";
            return con.Query<User>(selectSql, new { UserName = userName, Password = password }, tran).SingleOrDefault();
        }

        public IEnumerable<User> GetAllUser(IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select `UserName`,`RealName`,`Role`,`Role`.`Name` as RoleName,DeptID,`Department`.Code as Department,`Department`.`Name` as DepartmentName,`State`,`User`.`CreateUser`, `User`.`UpdateDateTime` 
            From `User` 
            Left Join `Role` on `User`.`Role` = `Role`.`Code` 
            Left Join `Department` on `User`.`DeptID` = `Department`.ID";
            return con.Query<User>(selectSql, null, tran);
        }

        public IEnumerable<User> GetAllEnabledUser(IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select `UserName`,`RealName`,`Role`,`Role`.`Name` as RoleName,DeptID,`Department`.Code as Department,`Department`.`Name` as DepartmentName,`State`,`User`.`CreateUser`, `User`.`UpdateDateTime` 
            From `User` 
            Left Join `Role` on `User`.`Role` = `Role`.`Code` 
            Left Join `Department` on `User`.`DeptID` = `Department`.ID
            where `State`=1";
            return con.Query<User>(selectSql, null, tran);
        }

        public IEnumerable<User> GetRoleUsers(string roleCode, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select `UserName`,`RealName`,`Role`,`Role`.`Name` as RoleName,DeptID,`Department`.Code as Department,`Department`.`Name` as DepartmentName,`State`,`User`.`CreateUser`, `User`.`UpdateDateTime` 
            From `User` 
            Left Join `Role` on `User`.`Role` = `Role`.`Code` 
            Left Join `Department` on `User`.`DeptID` = `Department`.ID
            Where `Role`=@Role";
            return con.Query<User>(selectSql, new { Role = roleCode }, tran);

        }

        public List<User> GetCustomerSalesmanList(int customerId, IDbConnection con, IDbTransaction tran = null)
        {
            string salesmanSelectSql = @"Select `UserName`,`RealName`,`Role`,`Role`.`Name` as RoleName,DeptID,`Department`.Code as Department,`Department`.`Name` as DepartmentName,`State`,`User`.`CreateUser`, `User`.`UpdateDateTime` 
            From `CustomerSalesman` sm left join `User` on sm.Salesman=`User`.`UserName`
            Left Join `Role` on `User`.`Role` = `Role`.`Code` 
            Left Join `Department` on `User`.`DeptID` = `Department`.ID
            Where sm.`Customer` = @ID";

            return con.Query<User>(salesmanSelectSql, new { ID = customerId }, tran).ToList();
        }

        public List<User> GetBankSlipSalesmanList(int bsID, IDbConnection con, IDbTransaction tran = null)
        {
            string salesmanSelectSql = @"Select `USER`.`UserName`,`RealName`,`Role`,`Role`.`Name` as RoleName,DeptID,`Department`.Code as Department,`Department`.`Name` as DepartmentName,`State`,`User`.`CreateUser`, `User`.`UpdateDateTime` 
            From `ReceiptNotice` rn left join `User` on rn.UserName=`User`.`UserName`
            Left Join `Role` on `User`.`Role` = `Role`.`Code` 
            Left Join `Department` on `User`.`DeptID` = `Department`.ID
            Where rn.`BSID` = @ID";

            return con.Query<User>(salesmanSelectSql, new { ID = bsID }, tran).ToList();
        }

        public IEnumerable<User> GetNotRoleUsers(string roleCode, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select `UserName`,`RealName`,`Role`,`Role`.`Name` as RoleName,DeptID,`Department`.Code as Department,`Department`.`Name` as DepartmentName,`State`,`User`.`CreateUser`, `User`.`UpdateDateTime` 
            From `User` 
            Left Join `Role` on `User`.`Role` = `Role`.`Code` 
            Left Join `Department` on `User`.`DeptID` = `Department`.ID
            Where `Role`<>@Role";
            return con.Query<User>(selectSql, new { Role = roleCode }, tran);

        }


        public IEnumerable<User> GetDepartmentUsers(int deptId, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select `UserName`,`RealName`,`Role`,`Role`.`Name` as RoleName,DeptID,`Department`.Code as Department,`Department`.`Name` as DepartmentName,`State`,`User`.`CreateUser`, `User`.`UpdateDateTime` 
            From `User` 
            Left Join `Role` on `User`.`Role` = `Role`.`Code` 
            Left Join `Department` on `User`.`DeptID` = `Department`.ID
            Where `User`.`DeptID`=@DeptID";
            return con.Query<User>(selectSql, new { DeptID = deptId }, tran);

        }

        public void AddUser(User user, IDbConnection con, IDbTransaction tran)
        {
            string insertSql = "Insert Into `User` (`UserName`,`RealName`,`Role`,`DeptID`,`Password`,`State`,`CreateUser`,`UpdateDateTime`) Values (@UserName,@RealName,@Role,@DeptID,@Password,true,@CreateUser,now())";
            con.Execute(insertSql, user, tran);
        }

        public void ModifyPassword(string userName, string newPassword, IDbConnection con, IDbTransaction tran)
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
            string updateSql = "Update `User` Set `RealName` = @RealName,`Role` = @Role,`DeptID` = @DeptID,`UpdateDateTime` = now() Where `UserName` = @UserName";
            con.Execute(updateSql, user, tran);
        }

        public void SetUsersRole(List<string> users, string roleCode, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = "Update `User` Set `Role` = @Role ,`UpdateDateTime` = now() Where `UserName` = @UserName";

            List<User> userList = new List<User>();
            foreach (string user in users)
            {
                User u = new User() { UserName = user, Role = roleCode };
                userList.Add(u);
            }

            con.Execute(updateSql, userList, tran);
        }

        public void SetUsersDepartment(List<string> users, int deptID, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = "Update `User` Set `DeptID` = @DeptID ,`UpdateDateTime` = now() Where `UserName` = @UserName";

            List<User> userList = new List<User>();
            foreach (string user in users)
            {
                User u = new User() { UserName = user, DeptID = deptID };
                userList.Add(u);
            }

            con.Execute(updateSql, userList, tran);
        }
    }
}
