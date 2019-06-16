﻿using System;
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
                selectSql += " and b.Salesman=@Salesman";
                dp.Add("Salesman", condition.Salesman, null, null, null);
            }
            if (condition.DeptID >= 0)
            {
                selectSql += " and b.DeptID=@DeptID";
                dp.Add("DeptID", condition.DeptID, null, null, null);
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
where pn.CommitTime BETWEEN @BeginTime AND @EndTime ");
            DynamicParameters dp = new DynamicParameters();
            dp.Add("BeginTime", condition.BeginTimestamp, null, null, null);
            dp.Add("EndTime", condition.EndTimestamp, null, null, null);
            if (!string.IsNullOrEmpty(condition.Salesman))
            {
                selectSql += " AND Applicant=@Applicant ";
                dp.Add("Applicant", condition.Salesman, null, null, null);
            }

            else if (condition.DeptID >= 0)
            {
                selectSql += "  AND Applicant in (SELECT UserName from `user` where DeptID=@DeptID) ";
                dp.Add("DeptID", condition.DeptID, null, null, null);
            }
            if (condition.ID > 0)
            {
                selectSql += " AND pn.BudgetID=@BudgetID AND EXISTS(SELECT 1 FROM BudgetSuppliers WHERE Sup_ID=s.ID and ID=@BudgetID) ";
                dp.Add("BudgetID", condition.ID, null, null, null);
            }

            selectSql += " GROUP BY s.`Name`;";
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
            string selectSql = string.Format(@"SELECT c.`Name`,sum(bs.CNY) as CNY,sum(bs.OriginalCoin) as OriginalCoin,bs.ExchangeRate from customer as c join BankSlip bs on c.ID=bs.Cus_ID
where CreateTimestamp BETWEEN @BeginTime AND @EndTime ");
            DynamicParameters dp = new DynamicParameters();
            dp.Add("BeginTime", condition.BeginTimestamp, null, null, null);
            dp.Add("EndTime", condition.EndTimestamp, null, null, null);
            if (!string.IsNullOrEmpty(condition.Salesman))
            {
                selectSql += " AND ID in (SELECT cs.Customer from customersalesman cs JOIN `user` u on cs.salesman=u.username WHERE u.username=@Salesman ) ";
                dp.Add("Salesman", condition.Salesman, null, null, null);
            }
            else if (condition.DeptID >= 0)
            {
                selectSql += " AND ID in (SELECT cs.Customer from customersalesman cs JOIN `user` u on cs.salesman=u.username WHERE u.DeptID=@DeptID) ";
                dp.Add("DeptID", condition.DeptID, null, null, null);
            }

            selectSql += "group by c.`Name`";
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

        public IEnumerable<RecieptCapital> GetRecieptCapital(BudgetQueryCondition condition, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = @"select  SUM(bb.CNY) as CNY,SUM(bb.OriginalCoin) as OriginalCoin,bs.BankName,bs.PaymentMethod,DeptID,d.`Code`,d.`Name` from budgetbill bb 
LEFT JOIN bankslip bs on bb.BSID=bs.BSID  
LEFT JOIN department d on bb.DeptID=d.ID 
GROUP BY DeptID,bs.BankName,bs.PaymentMethod
UNION SELECT SUM(CNY2) as CNY,SUM(OriginalCoin2) as OriginalCoin,BankName,PaymentMethod,-1,'','余额' from bankslip GROUP BY BankName,PaymentMethod";
            DynamicParameters dp = new DynamicParameters();
            if (condition != null)
            {
                selectSql = @"select  SUM(bb.CNY) as CNY,SUM(bb.OriginalCoin) as OriginalCoin,bs.BankName,bs.PaymentMethod,DeptID,d.`Code`,d.`Name` from budgetbill bb 
LEFT JOIN bankslip bs on bb.BSID=bs.BSID  
LEFT JOIN department d on bb.DeptID=d.ID 
where bb.BSID in (SELECT BSID from bankslip where ReceiptDate BETWEEN @beginTime and @endTime)
GROUP BY DeptID,bs.BankName,bs.PaymentMethod
UNION SELECT SUM(CNY2) as CNY,SUM(OriginalCoin2) as OriginalCoin,BankName,PaymentMethod,-1,'','余额' from bankslip where ReceiptDate BETWEEN @beginTime and @endTime 
GROUP BY BankName,PaymentMethod";
                dp.Add("beginTime", condition.BeginTimestamp, DbType.DateTime, null, null);
                dp.Add("endTime", condition.EndTimestamp, DbType.DateTime, null, null);
            }

            return con.Query<RecieptCapital>(selectSql, dp, tran);
        }

        public IEnumerable<RecieptCapital> GetPaymentCapital(BudgetQueryCondition condition, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = @"SELECT sum(CNY) as CNY,PayingBank as BankName,DeptID,d.`Code`,d.`Name`  from paymentnotes pn
LEFT JOIN department d on pn.DeptID=d.ID 
WHERE PayingBank is not null
GROUP BY DeptID,PayingBank";
            DynamicParameters dp = new DynamicParameters();
            if (condition != null)
            {
                selectSql = @"SELECT sum(CNY) as CNY,PayingBank as BankName,DeptID,d.`Code`,d.`Name`  from paymentnotes pn
LEFT JOIN department d on pn.DeptID=d.ID 
WHERE PaymentDate BETWEEN @beginTime and @endTime AND  PayingBank is not null
GROUP BY DeptID,PayingBank";
                dp.Add("beginTime", condition.BeginTimestamp, DbType.DateTime, null, null);
                dp.Add("endTime", condition.EndTimestamp, DbType.DateTime, null, null);
            }

            return con.Query<RecieptCapital>(selectSql, dp, tran);
        }

        public int GetPaymentCapitalTotalCount(BudgetQueryCondition condition, IDbConnection con, IDbTransaction tran = null)
        {
            int count = 0;

            string selectSql = @"SELECT count(*) from paymentnotes where PayingBank is not null ";

            DynamicParameters dp = new DynamicParameters();
            if (condition != null)
            {
                selectSql += " and PaymentDate BETWEEN @beginTimestamp and @endTimestamp ";
            }
            using (IDbCommand command = con.CreateCommand())
            {
                command.CommandText = selectSql;
                command.Transaction = tran;
                if (condition != null)
                {
                    IDbDataParameter beginTimestampParameter = command.CreateParameter();
                    beginTimestampParameter.ParameterName = "beginTimestamp";
                    beginTimestampParameter.DbType = DbType.DateTime;
                    beginTimestampParameter.Value = condition.BeginTimestamp;
                    command.Parameters.Add(beginTimestampParameter);

                    IDbDataParameter endTimestampParameter = command.CreateParameter();
                    endTimestampParameter.ParameterName = "endTimestamp";
                    endTimestampParameter.DbType = DbType.DateTime;
                    endTimestampParameter.Value = condition.EndTimestamp;
                    command.Parameters.Add(endTimestampParameter);

                }
                object result = command.ExecuteScalar();
                int.TryParse(result.ToString(), out count);
            }
            return count;
        }

        public int GetRecieptCapitalTotalCount(BudgetQueryCondition condition, IDbConnection con, IDbTransaction tran = null)
        {
            int count = 0;

            string selectSql = @"SELECT count(*) from bankslip where 1=1 ";

            DynamicParameters dp = new DynamicParameters();
            if (condition != null)
            {
                selectSql += " and ReceiptDate BETWEEN @beginTimestamp and @endTimestamp ";
            }
            using (IDbCommand command = con.CreateCommand())
            {
                command.CommandText = selectSql;
                command.Transaction = tran;
                if (condition != null)
                {
                    IDbDataParameter beginTimestampParameter = command.CreateParameter();
                    beginTimestampParameter.ParameterName = "beginTimestamp";
                    beginTimestampParameter.DbType = DbType.DateTime;
                    beginTimestampParameter.Value = condition.BeginTimestamp;
                    command.Parameters.Add(beginTimestampParameter);

                    IDbDataParameter endTimestampParameter = command.CreateParameter();
                    endTimestampParameter.ParameterName = "endTimestamp";
                    endTimestampParameter.DbType = DbType.DateTime;
                    endTimestampParameter.Value = condition.EndTimestamp;
                    command.Parameters.Add(endTimestampParameter);

                }
                object result = command.ExecuteScalar();
                int.TryParse(result.ToString(), out count);
            }
            return count;
        }

        public decimal GetAverageUSDExchange(BudgetQueryCondition condition, IDbConnection con, IDbTransaction tran = null)
        {
            decimal useExchange = 0;

            string selectSql = @"SELECT SUM(ExchangeRate)/COUNT(ExchangeRate) from bankslip where 1=1 ";

            DynamicParameters dp = new DynamicParameters();
            selectSql += " and Currency=@Currency ";
            if (condition != null)
            {
                selectSql += " and ReceiptDate BETWEEN @beginTimestamp and @endTimestamp ";
            }
            using (IDbCommand command = con.CreateCommand())
            {
                command.CommandText = selectSql;
                command.Transaction = tran;
                IDbDataParameter parameter = command.CreateParameter();
                parameter.ParameterName = "Currency";
                parameter.DbType = DbType.String;
                parameter.Value = "USD";
                command.Parameters.Add(parameter);
                if (condition != null)
                {
                    IDbDataParameter beginTimestampParameter = command.CreateParameter();
                    beginTimestampParameter.ParameterName = "beginTimestamp";
                    beginTimestampParameter.DbType = DbType.DateTime;
                    beginTimestampParameter.Value = condition.BeginTimestamp;
                    command.Parameters.Add(beginTimestampParameter);

                    IDbDataParameter endTimestampParameter = command.CreateParameter();
                    endTimestampParameter.ParameterName = "endTimestamp";
                    endTimestampParameter.DbType = DbType.DateTime;
                    endTimestampParameter.Value = condition.EndTimestamp;
                    command.Parameters.Add(endTimestampParameter);

                }
                object result = command.ExecuteScalar();
                decimal.TryParse(result.ToString(), out useExchange);
            }
            return useExchange;
        }
    }
}
