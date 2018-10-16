using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BudgetSystem.Bll
{
    public class TestManager:BaseManager
    {
        public void Test()
        {
            Dal.TestDal dal = new Dal.TestDal();

            this.ExecuteWithoutTransaction((con) =>
            {
                dal.Test2(con, null);
                dal.Test3(con,null);
                dal.Test3(con, null);
            });

            this.ExecuteWithTransaction((con, tran) =>
            {

                dal.Test2(con, null);
                dal.Test3(con, null);
                dal.Test3(con, null);
                
            });
        }

    }
}
