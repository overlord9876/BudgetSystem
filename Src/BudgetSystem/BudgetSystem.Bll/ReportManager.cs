using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using BudgetSystem.Dal;
using Newtonsoft.Json;
using System.Linq;

namespace BudgetSystem.Bll
{
    public class ReportManager : BaseManager
    {
        private ReportDal dal = new ReportDal();

        public List<BudgetReport> GetBudgetReportList(DateTime beginTimestamp, DateTime endTimestamp)
        {
            var lst = this.Query<BudgetReport>((con) =>
            {
                var uList = dal.GetBudgetReportList(beginTimestamp, endTimestamp, con, null);
                return uList;
            });


            return lst.ToList();
        }

        public List<SupplierReport> GetSupplierReportList(DateTime beginTimestamp, DateTime endTimestamp)
        {
            var lst = this.Query<SupplierReport>((con) =>
            {
                var uList = dal.GetSupplierReportList(beginTimestamp, endTimestamp, con, null);
                return uList;
            });


            return lst.ToList();
        }

        public List<CustomerReport> GetCustomerReportList(DateTime beginTimestamp, DateTime endTimestamp)
        {
            var lst = this.Query<CustomerReport>((con) =>
            {
                var uList = dal.GetCustomerReportList(beginTimestamp, endTimestamp, con, null);
                return uList;
            });


            return lst.ToList();
        }

    }
}
