﻿using System;
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

        public List<RecieptCapital> GetRecieptCapitalWithUSD(BudgetQueryCondition condition)
        {
            var lst = this.Query<RecieptCapital>((con) =>
            {
                var uList = dal.GetRecieptCapitalWithUSD(condition, con);
                return uList;
            });

            return lst.ToList();
        }

        public List<RecieptCapital> GetRecieptCapitalWithOutUSD(BudgetQueryCondition condition)
        {
            var lst = this.Query<RecieptCapital>((con) =>
            {
                var uList = dal.GetRecieptCapitalWithOutUSD(condition, con);
                return uList;
            });

            return lst.ToList();
        }

        public List<RecieptCapital> GetPaymentCapital(BudgetQueryCondition condition)
        {
            var lst = this.Query<RecieptCapital>((con) =>
            {
                var uList = dal.GetPaymentCapital(condition, con);
                return uList;
            });

            return lst.ToList();
        }

        public decimal GetAverageUSDExchange(BudgetQueryCondition condition)
        {
            return this.Query<decimal>((con) =>
                {
                    return dal.GetAverageUSDExchange(condition, con);
                });
        }

        public int GetPaymentCapitalTotalCount(BudgetQueryCondition condition)
        {
            return this.Query<int>((con) =>
            {
                return dal.GetPaymentCapitalTotalCount(condition, con);
            });
        }

        public int GetRecieptCapitalTotalCount(BudgetQueryCondition condition)
        {
            return this.Query<int>((con) =>
            {
                return dal.GetRecieptCapitalTotalCount(condition, con);
            });
        }

    }
}
