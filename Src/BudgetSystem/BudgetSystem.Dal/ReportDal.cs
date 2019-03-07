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
        public IEnumerable<BudgetReport> GetBudgetReportList(DateTime beginTime, DateTime endTime, IDbConnection con, IDbTransaction tran = null, BudgetQueryCondition condition = null)
        {
            string selectSql = string.Format(@"SELECT b.*,u.RealName  AS SalesmanName,d.`Code` AS DepartmentCode,d.`Name` AS DepartmentName,c.`Name` AS CustomerName,c.Country AS CustomerCountry,
                                                      IFNULL((f.ApproveResult+f.IsClosed),-1) FlowState,f.ID AS FlowInstanceID,f.FlowName,u2.RealName AS UpdateUserName
                                 FROM `Budget` b                                     
                                 LEFT JOIN `User` u ON b.Salesman=u.UserName 
                                 LEFT JOIN `User` u2 ON b.UpdateUser=u2.UserName 
                                 LEFT JOIN `Department` d ON b.DeptID=d.ID
                                 LEFT JOIN `Customer` c ON b.CustomerID=c.ID 								 
								 LEFT JOIN `FlowInstance` f ON f.DateItemID=b.id AND f.DateItemType=@DateItemType AND f.IsRecent=1
                                 WHERE b.ID<>0 AND SignDate BETWEEN @BeginTime and @EndTime;");
            DynamicParameters dp = new DynamicParameters();
            dp.Add("DateItemType", EnumFlowDataType.预算单.ToString(), null, null, null);
            dp.Add("BeginTime", beginTime, null, null, null);
            dp.Add("EndTime", endTime, null, null, null);
            IEnumerable<BudgetReport> budgetList = con.Query<BudgetReport>(selectSql, dp, tran);

            IEnumerable<PaymentNotes> pnList = GetPaymentNotesList(beginTime, endTime, con, tran);
            IEnumerable<Invoice> iList = GetInvoiceList(beginTime, endTime, con, tran);
            IEnumerable<BudgetBill> bbList = GetBudgetBillList(beginTime, endTime, con, tran);
            IEnumerable<Declarationform> dList = GetDeclarationformList(beginTime, endTime, con, tran);
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

        public IEnumerable<PaymentNotes> GetPaymentNotesList(DateTime beginTime, DateTime endTime, IDbConnection con, IDbTransaction tran = null, BudgetQueryCondition condition = null)
        {
            string selectSql = string.Format(@"SELECT pn.* from PaymentNotes pn JOIN `Budget` b on pn.BudgetID=b.ID
                    where b.SignDate BETWEEN @BeginTime and @EndTime;");
            DynamicParameters dp = new DynamicParameters();
            dp.Add("BeginTime", beginTime, null, null, null);
            dp.Add("EndTime", endTime, null, null, null);
            return con.Query<PaymentNotes>(selectSql, dp, tran);
        }

        public IEnumerable<Invoice> GetInvoiceList(DateTime beginTime, DateTime endTime, IDbConnection con, IDbTransaction tran = null, BudgetQueryCondition condition = null)
        {
            string selectSql = string.Format(@"select i.* from Invoice i join `budget` b on i.BudgetID=b.ID
                    where b.SignDate BETWEEN @BeginTime and @EndTime;");
            DynamicParameters dp = new DynamicParameters();
            dp.Add("BeginTime", beginTime, null, null, null);
            dp.Add("EndTime", endTime, null, null, null);
            return con.Query<Invoice>(selectSql, dp, tran);
        }

        public IEnumerable<BudgetBill> GetBudgetBillList(DateTime beginTime, DateTime endTime, IDbConnection con, IDbTransaction tran = null, BudgetQueryCondition condition = null)
        {
            string selectSql = string.Format(@"SELECT bb.* FROM BudgetBill bb join `budget` b on bb.BudgetID=b.ID
                    where b.SignDate BETWEEN @BeginTime and @EndTime;");
            DynamicParameters dp = new DynamicParameters();
            dp.Add("BeginTime", beginTime, null, null, null);
            dp.Add("EndTime", endTime, null, null, null);
            return con.Query<BudgetBill>(selectSql, dp, tran);
        }

        public IEnumerable<Declarationform> GetDeclarationformList(DateTime beginTime, DateTime endTime, IDbConnection con, IDbTransaction tran = null, BudgetQueryCondition condition = null)
        {
            string selectSql = string.Format(@"SELECT d.* FROM Declarationform d JOIN `budget` b ON d.BudgetID=b.ID
                    WHERE b.SignDate BETWEEN @BeginTime AND @EndTime;");
            DynamicParameters dp = new DynamicParameters();
            dp.Add("BeginTime", beginTime, null, null, null);
            dp.Add("EndTime", endTime, null, null, null);
            return con.Query<Declarationform>(selectSql, dp, tran);
        }

        public IEnumerable<SupplierReport> GetSupplierReportList(DateTime beginTime, DateTime endTime, IDbConnection con, IDbTransaction tran = null, BudgetQueryCondition condition = null)
        {
            string selectSql = string.Format(@"SELECT s.`Name`,sum(pn.CNY) as TotalCNY,pn.ExchangeRate, sum(pn.OriginalCoin) as TotalOriginalCoin from PaymentNotes pn join Supplier s on pn.SupplierID=s.ID 
where pn.CommitTime BETWEEN @BeginTime AND @EndTime
GROUP BY s.`Name`;");
            DynamicParameters dp = new DynamicParameters();
            dp.Add("BeginTime", beginTime, null, null, null);
            dp.Add("EndTime", endTime, null, null, null);
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


        public IEnumerable<CustomerReport> GetCustomerReportList(DateTime beginTime, DateTime endTime, IDbConnection con, IDbTransaction tran = null, BudgetQueryCondition condition = null)
        {
            string selectSql = string.Format(@"SELECT c.`Name`,sum(bs.CNY) as CNY,sum(bs.OriginalCoin) as OriginalCoin,bs.ExchangeRate from customer as c join BankSlip bs on c.`Name`=bs.Remitter
where ReceiptDate BETWEEN @BeginTime AND @EndTime
group by c.`Name`;");
            DynamicParameters dp = new DynamicParameters();
            dp.Add("BeginTime", beginTime, null, null, null);
            dp.Add("EndTime", endTime, null, null, null);
            IEnumerable<CustomerReport> result = con.Query<CustomerReport>(selectSql, dp, tran);

            selectSql = string.Format(@"select c.`Name`,d.* from Declarationform d join budget b on d.BudgetID=b.ID join customer c on b.CustomerID=c.ID
where ExportDate BETWEEN @BeginTime AND @EndTime;");

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
