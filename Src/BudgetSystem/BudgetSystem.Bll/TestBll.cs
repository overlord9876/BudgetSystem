using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Bll
{
    public class TestBll
    {
        public void Test()
        {
            Dal.TestDal dal = new Dal.TestDal();
            dal.Test();
        
        }

    }
}
