using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Linq;

namespace BudgetSystem.Bll
{
    public class UserManager:BaseManager
    {

        Dal.UserDal dal = new Dal.UserDal();

        public List<User> GetAllUser()
        {

            var lst = this.Query<User>((con) => {

                var uList = dal.GetAllUser(con, null);
                return uList;
            
            });

            return lst.ToList();
            //IEnumerable<User> users = this.ExecuteWithoutTransaction((con) =>
            //{
            //    var uList = dal.GetAllUser(con, null);
            //    return uList;
               
            //}) as IEnumerable<User>;
            //return users.ToList();
        }

        public void CreateUser(User user)
        {
            this.ExecuteWithoutTransaction((con) =>
            {

                dal.AddUser(user, con, null);

            });
        }

        public void ModifyUserInfo(User user)
        {
            this.ExecuteWithoutTransaction((con) =>
            {
                dal.ModifyUser(user, con, null);
            });
        }

        public void ModifyUserPassword(string userName, string password, string updateUser)
        {
            this.ExecuteWithoutTransaction((con) =>
            {

                dal.ModifyPassword(userName, password, updateUser, con, null);

            });
        }

        public void ModifyUserState(string userName, bool isEnable, string updateUser)
        {
            this.ExecuteWithoutTransaction((con) =>
            {
                dal.ModifyUserState(userName, isEnable, updateUser, con, null);

            });
        }
    }
}
