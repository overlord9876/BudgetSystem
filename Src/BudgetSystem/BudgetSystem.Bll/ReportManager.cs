using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using BudgetSystem.Dal;
using Newtonsoft.Json;
using System.Linq;
using BudgetSystem.Entity.QueryCondition;

namespace BudgetSystem.Bll
{
    public class ReportManager : BaseManager
    {
        private ReportDal dal = new ReportDal();

        public List<BudgetReport> GetBudgetReportList(BudgetQueryCondition condition)
        {
            var lst = this.Query<BudgetReport>((con) =>
            {
                var uList = dal.GetBudgetReportList(condition, con);
                return uList;
            });


            return lst.ToList();
        }

        public List<SupplierReport> GetSupplierReportList(BudgetQueryCondition condition)
        {
            var lst = this.Query<SupplierReport>((con) =>
            {
                var uList = dal.GetSupplierReportList(condition, con);
                return uList;
            });


            return lst.ToList();
        }

        public List<CustomerReport> GetCustomerReportList(BudgetQueryCondition condition)
        {
            var lst = this.Query<CustomerReport>((con) =>
            {
                var uList = dal.GetCustomerReportList(condition, con);
                return uList;
            });


            return lst.ToList();
        }


        public List<RecieptCapital> GetRecieptCapital()
        {
            var lst = this.Query<RecieptCapital>((con) =>
            {
                var uList = dal.GetRecieptCapital(con);
                return uList;
            });

            return lst.ToList();
        }
    }
}
