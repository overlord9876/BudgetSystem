using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Linq;

namespace BudgetSystem.Bll
{
    public class UserManager : BaseManager
    {

        Dal.UserDal dal = new Dal.UserDal();


        public User Login(string userName, string password)
        {
            var user = this.Query<User>((con) =>
            {

                var uList = dal.GetUser(userName, password, con, null);
                return uList;

            });
            return user;
        }

        public List<User> GetAllUser()
        {
            var lst = this.Query<User>((con) =>
            {

                var uList = dal.GetAllUser(con, null);
                return uList;

            });
            return lst.ToList();
        }

        public List<User> GetAllEnabledUser()
        {
            var lst = this.Query<User>((con) =>
            {

                var uList = dal.GetAllEnabledUser(con, null);
                return uList;

            });
            return lst.ToList();
        }

        public List<User> GetRoleUsers(string roleCode)
        {
            var lst = this.Query<User>((con) =>
            {

                var uList = dal.GetRoleUsers(roleCode, con, null);
                return uList;

            });
            return lst.ToList();
        }

        public List<User> GetCustomerSalesmanList(int customerId)
        {
            var lst = this.Query<User>((con) =>
            {

                var uList = dal.GetCustomerSalesmanList(customerId, con, null);
                return uList;

            });
            return lst.ToList();
        }

        public List<User> GetBankSlipSalesmanList(int actualReceiptId)
        {
            var lst = this.Query<User>((con) =>
            {
                var uList = dal.GetBankSlipSalesmanList(actualReceiptId, con, null);
                return uList;

            });
            return lst.ToList();
        }

        public List<User> GetNotRoleUsers(string roleCode)
        {
            var lst = this.Query<User>((con) =>
            {

                var uList = dal.GetNotRoleUsers(roleCode, con, null);
                return uList;

            });
            return lst.ToList();
        }

        public List<User> GetDepartmentUsers(int deptId)
        {
            var lst = this.Query<User>((con) =>
            {

                var uList = dal.GetDepartmentUsers(deptId, con, null);
                return uList;

            });
            return lst.ToList();
        }

        public User GetUser(string userName)
        {
            var user = this.Query<User>((con) =>
            {

                var uList = dal.GetUser(userName, con, null);
                return uList;

            });
            return user;

        }




        public int CreateUser(User user)
        {
            return this.ExecuteWithTransaction<int>((con, tran) =>
            {
                User existUser = dal.GetUser(user.UserName, con, tran);
                if (existUser != null)
                {
                    return 2;
                }
                dal.AddUser(user, con, null);
                return 1;
            });
        }

        public void ModifyUserInfo(User user)
        {
            this.ExecuteWithoutTransaction((con) =>
            {
                dal.ModifyUser(user, con, null);
            });
        }

        public void ModifyUserPassword(string userName, string password)
        {
            this.ExecuteWithoutTransaction((con) =>
            {

                dal.ModifyPassword(userName, password, con, null);

            });
        }

        public void ModifyUserState(string userName, bool isEnable)
        {
            this.ExecuteWithoutTransaction((con) =>
            {
                dal.ModifyUserState(userName, isEnable, con, null);

            });
        }


        public void SetUserRole(List<string> userList, string roleCode)
        {
            this.ExecuteWithTransaction((con, tran) =>
            {
                dal.SetUsersRole(userList, roleCode, con, tran);

            });
        }

        public void SetUserDepartment(List<string> userList, int deptID)
        {
            this.ExecuteWithTransaction((con, tran) =>
            {
                dal.SetUsersDepartment(userList, deptID, con, tran);

            });
        }
    }
}
