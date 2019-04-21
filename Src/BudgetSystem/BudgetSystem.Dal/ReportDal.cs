using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using BudgetSystem.Entity.QueryCondition;
using System.Data;
using Dapper_NET20;
using System.Linq;

namespace BudgetSystem.Dal
{
    public class ReportDal
    {
        public IEnumerable<BudgetReport> GetBudgetReportList(BudgetQueryCondition condition, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = string.Format(@"SELECT b.*,u.RealName  AS SalesmanName,d.`Code` AS DepartmentCode,d.`Name` AS DepartmentName
                                 FROM `Budget` b                                     
                                 LEFT JOIN `User` u ON b.Salesman=u.UserName 
                                 LEFT JOIN `Department` d ON b.DeptID=d.ID
                                where b.ID in (SELECT DISTINCT BudgetID from PaymentNotes where CommitTime BETWEEN @BeginTime and @EndTime
                                UNION
                                select DISTINCT BudgetID from Invoice where FinanceImportDate BETWEEN @BeginTime and @EndTime
                                UNION
                                select DISTINCT BudgetID from Declarationform  where CreateDate BETWEEN @BeginTime and @EndTime
                                UNION
                                select DISTINCT BudgetID from BudgetBill bb inner JOIN BankSlip bs on bb.BSID=bs.BSID where bs.CreateTimestamp BETWEEN @BeginTime and @EndTime) and b.ID<>0 ");

            DynamicParameters dp = new DynamicParameters();
            dp.Add("BeginTime", condition.BeginTimestamp, null, null, null);
            dp.Add("EndTime", condition.EndTimestamp, null, null, null);

            if (!string.IsNullOrEmpty(condition.Salesman))
            {
                selectSql += " and b.DeptID=@DeptID";
                dp.Add("DeptID", condition.DeptID, null, null, null);
            }
            if (condition.DeptID >= 0)
            {
                selectSql += " and b.Salesman=@Salesman";
                dp.Add("Salesman", condition.Salesman, null, null, null);
            }
            IEnumerable<BudgetReport> budgetList = con.Query<BudgetReport>(selectSql, dp, tran);

            IEnumerable<PaymentNotes> pnList = GetPaymentNotesList(condition, con, tran);
            IEnumerable<Invoice> iList = GetInvoiceList(condition, con, tran);
            IEnumerable<BudgetBill> bbList = GetBudgetBillList(condition, con, tran);
            IEnumerable<Declarationform> dList = GetDeclarationformList(condition, con, tran);
            if (budgetList != null)
            {
                foreach (BudgetReport report in budgetList)
                {
                    report.PaymentList = pnList.Where(o => o.BudgetID.Equals(report.ID)).ToList();
                    report.InvoiceList = iList.Where(o => o.BudgetID.Equals(report.ID)).ToList();
                    report.BudgetBillList = bbList.Where(o => o.BudgetID.Equals(report.ID)).ToList();
                    report.DeclarationformList = dList.Where(o => o.BudgetID.Equals(report.ID)).ToList();
                }
            }
            return budgetList;
        }

        public IEnumerable<PaymentNotes> GetPaymentNotesList(BudgetQueryCondition condition, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = string.Format(@"SELECT * from PaymentNotes where CommitTime BETWEEN @BeginTime and @EndTime;");
            DynamicParameters dp = new DynamicParameters();
            dp.Add("BeginTime", condition.BeginTimestamp, null, null, null);
            dp.Add("EndTime", condition.EndTimestamp, null, null, null);
            return con.Query<PaymentNotes>(selectSql, dp, tran);
        }

        public IEnumerable<Invoice> GetInvoiceList(BudgetQueryCondition condition, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = string.Format(@"select * from Invoice where FinanceImportDate BETWEEN @BeginTime and @EndTime;");
            DynamicParameters dp = new DynamicParameters();
            dp.Add("BeginTime", condition.BeginTimestamp, null, null, null);
            dp.Add("EndTime", condition.EndTimestamp, null, null, null);
            return con.Query<Invoice>(selectSql, dp, tran);
        }

        public IEnumerable<BudgetBill> GetBudgetBillList(BudgetQueryCondition condition, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = string.Format(@"SELECT * FROM BudgetBill bb inner JOIN BankSlip bs on bb.BSID=bs.BSID where bs.CreateTimestamp BETWEEN @BeginTime and @EndTime;");
            DynamicParameters dp = new DynamicParameters();
            dp.Add("BeginTime", condition.BeginTimestamp, null, null, null);
            dp.Add("EndTime", condition.EndTimestamp, null, null, null);
            return con.Query<BudgetBill>(selectSql, dp, tran);
        }

        public IEnumerable<Declarationform> GetDeclarationformList(BudgetQueryCondition condition, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = string.Format(@"SELECT * FROM Declarationform  where CreateDate BETWEEN @BeginTime and @EndTime;");
            DynamicParameters dp = new DynamicParameters();
            dp.Add("BeginTime", condition.BeginTimestamp, null, null, null);
            dp.Add("EndTime", condition.EndTimestamp, null, null, null);
            return con.Query<Declarationform>(selectSql, dp, tran);
        }

        public IEnumerable<SupplierReport> GetSupplierReportList(BudgetQueryCondition condition, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = string.Format(@"SELECT s.`Name`,sum(pn.CNY) as TotalCNY,pn.ExchangeRate, sum(pn.OriginalCoin) as TotalOriginalCoin from PaymentNotes pn join Supplier s on pn.SupplierID=s.ID 
where pn.CommitTime BETWEEN @BeginTime AND @EndTime
GROUP BY s.`Name`;");
            DynamicParameters dp = new DynamicParameters();
            dp.Add("BeginTime", condition.BeginTimestamp, null, null, null);
            dp.Add("EndTime", condition.EndTimestamp, null, null, null);
            IEnumerable<SupplierReport> result = con.Query<SupplierReport>(selectSql, dp, tran);

            selectSql = string.Format(@"select i.* from Invoice i
                        WHERE i.FinanceImportDate BETWEEN @BeginTime AND @EndTime;");

            IEnumerable<Invoice> invoiceList = con.Query<Invoice>(selectSql, dp, tran);
            if (result != null)
            {
                foreach (SupplierReport report in result)
                {
                    report.InvoiceList = invoiceList.Where(o => o.SupplierName.Equals(report.Name)).ToList();
                }
            }

            return result;
        }


        public IEnumerable<CustomerReport> GetCustomerReportList(BudgetQueryCondition condition, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = string.Format(@"SELECT c.`Name`,sum(bs.CNY) as CNY,sum(bs.OriginalCoin) as OriginalCoin,bs.ExchangeRate from customer as c join BankSlip bs on c.`Name`=bs.Remitter
where CreateTimestamp BETWEEN @BeginTime AND @EndTime
group by c.`Name`;");
            DynamicParameters dp = new DynamicParameters();
            dp.Add("BeginTime", condition.BeginTimestamp, null, null, null);
            dp.Add("EndTime", condition.EndTimestamp, null, null, null);
            IEnumerable<CustomerReport> result = con.Query<CustomerReport>(selectSql, dp, tran);

            selectSql = string.Format(@"select c.`Name`,d.* from Declarationform d join budget b on d.BudgetID=b.ID join customer c on b.CustomerID=c.ID
where d.CreateDate BETWEEN @BeginTime AND @EndTime;");

            IEnumerable<Declarationform> customerReportList = con.Query<Declarationform>(selectSql, dp, tran);
            if (result != null)
            {
                foreach (CustomerReport report in result)
                {
                    report.DeclarationformList = customerReportList.Where(o => o.Name.Equals(report.Name)).ToList();
                }
            }

            return result;
        }
    }
}
