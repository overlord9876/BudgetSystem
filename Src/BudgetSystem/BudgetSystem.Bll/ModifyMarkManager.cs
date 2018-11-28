using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Linq;

namespace BudgetSystem.Bll
{
    public class ModifyMarkManager : BaseManager
    {
        Dal.ModifyMarkDal dal = new Dal.ModifyMarkDal();
        public List<T> GetAllModifyMark<T>(int dataID)
        {
            var lst = this.Query<T>((con) =>
            {
                var uList = dal.GetAllModifyMark<T>(dataID, con);
                return uList;
            });
            return lst.ToList<T>();
        }
    }
}
