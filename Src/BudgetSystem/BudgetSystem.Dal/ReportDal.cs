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
                                select DISTINCT BudgetID from BudgetBill bb inner JOIN BankSlip bs on bb.BSID=bs.BSID where bs.CreateTimestamp BETWEEN @BeginTime and @EndTime) and b.ID<>0 ");//OR b.SignDate BETWEEN @BeginTime and @EndTime");

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
            List<Invoice> iList = GetInvoiceList(condition, con, tran).ToList();
            //iList.AddRange(PaymentToInvoice(pnList.ToList()));
            IEnumerable<BudgetBill> bbList = GetBudgetBillList(condition, con, tran);
            IEnumerable<Declarationform> dList = GetDeclarationformList(condition, con, tran);
            if (budgetList != null)
            {
                foreach (BudgetReport report in budgetList)
                {
                    //过滤签约金额与时间区间累加问题。 2020-04-08
                    if (report.SignDate < condition.BeginTimestamp || report.SignDate > condition.EndTimestamp)
                    {
                        report.USDTotalAmount = 0;
                        report.TotalAmount = 0;
                    }

                    report.PaymentList = pnList.Where(o => o.BudgetID.Equals(report.ID)).ToList();
                    report.InvoiceList = iList.Where(o => o.BudgetID.Equals(report.ID)).ToList();
                    report.BudgetBillList = bbList.Where(o => o.BudgetID.Equals(report.ID)).ToList();
                    report.DeclarationformList = dList.Where(o => o.BudgetID.Equals(report.ID)).ToList();
                }
            }
            return budgetList;
        }

        private IEnumerable<PaymentNotes> GetPaymentNotesList(BudgetQueryCondition condition, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = string.Format(@"SELECT * from PaymentNotes where CommitTime BETWEEN @BeginTime and @EndTime;");
            DynamicParameters dp = new DynamicParameters();
            dp.Add("BeginTime", condition.BeginTimestamp, null, null, null);
            dp.Add("EndTime", condition.EndTimestamp, null, null, null);
            return con.Query<PaymentNotes>(selectSql, dp, tran);
        }

        private List<Invoice> PaymentToInvoice(IEnumerable<PaymentNotes> paymentNotes)
        {
            List<Invoice> returnResult = new List<Invoice>();
            if (paymentNotes != null)//从付款中已交发票内容中提取发票内容。
            {
                foreach (PaymentNotes pn in paymentNotes)
                {
                    if (pn.HasInvoice)
                    {
                        returnResult.Add(new Invoice()
                        {
                            ID = pn.BudgetID,
                            OriginalCoin = pn.OriginalCoin,
                            ExchangeRate = (decimal)pn.ExchangeRate,
                            SupplierName = pn.SupplierName,
                            Payment = pn.OriginalCoin,
                            //TaxAmount = (decimal)pn.ExchangeRate,
                            TaxRebateRate = pn.TaxRebateRate,
                        });
                    }
                }
            }
            return returnResult;
        }

        private IEnumerable<Invoice> GetInvoiceList(BudgetQueryCondition condition, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = string.Format(@"select * from Invoice where FinanceImportDate BETWEEN @BeginTime and @EndTime;");
            DynamicParameters dp = new DynamicParameters();
            dp.Add("BeginTime", condition.BeginTimestamp, null, null, null);
            dp.Add("EndTime", condition.EndTimestamp, null, null, null);
            return con.Query<Invoice>(selectSql, dp, tran);
        }

        public IEnumerable<BudgetBill> GetBudgetBillList(BudgetQueryCondition condition, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = string.Format(@"SELECT bb.*,bs.ExchangeRate FROM BudgetBill bb LEFT JOIN BankSlip bs on bb.BSID=bs.BSID where bs.CreateTimestamp BETWEEN @BeginTime and @EndTime;");
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
            string selectSql = string.Format(@"SELECT s.`Name`,sum(pn.CNY) as TotalCNY,SUM(pn.ExchangeRate)/COUNT(1) as ExchangeRate, sum(pn.OriginalCoin) as TotalOriginalCoin from PaymentNotes pn join Supplier s on pn.SupplierID=s.ID 
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
                        WHERE i.FinanceImportDate BETWEEN @BeginTime AND @EndTime ");
            if (condition.ID > 0)
            {
                selectSql += " AND BudgetID=@BudgetID ";
                dp.Add("BudgetID", condition.ID, null, null, null);
            }

            List<Invoice> invoiceList = con.Query<Invoice>(selectSql, dp, tran).ToList();
            //将付款作为交单信息。
            string selectPaymentNotesSql = string.Format(@"SELECT *,s.`Name` as SupplierName from PaymentNotes pn INNER JOIN supplier s on pn.SupplierID=s.ID where HasInvoice=1  AND MoneyUsed ='运杂费' AND CommitTime BETWEEN @BeginTime and @EndTime ");
            dp = new DynamicParameters();
            dp.Add("BeginTime", condition.BeginTimestamp, null, null, null);
            dp.Add("EndTime", condition.EndTimestamp, null, null, null);
            if (condition.ID > 0)
            {
                selectPaymentNotesSql += " AND BudgetID=@BudgetID ";
                dp.Add("BudgetID", condition.ID, null, null, null);
            }
            if (condition.DeptID >= 0)
            {
                selectPaymentNotesSql += " and DeptID=@DeptID ";
                dp.Add("DeptID", condition.DeptID, null, null, null);
            }
            var paymentNodes = con.Query<PaymentNotes>(selectPaymentNotesSql, dp, tran);

            invoiceList.AddRange(PaymentToInvoice(paymentNodes.ToList()));

            if (result != null)
            {
                foreach (SupplierReport report in result)
                {
                    report.InvoiceList = invoiceList.Where(o => report.Name.Equals(o.SupplierName)).ToList();
                }
            }

            return result;
        }

        public IEnumerable<CustomerReport> GetCustomerReportList(BudgetQueryCondition condition, IDbConnection con, IDbTransaction tran = null)
        {
            IEnumerable<CustomerReport> result = null;
            string selectSql = string.Empty;
            DynamicParameters dp = new DynamicParameters();
            if (condition == null || condition.ID <= 0)
            {
                selectSql = string.Format(@"SELECT c.`Name`,SUM(bs.CNY) as CNY,SUM(bs.OriginalCoin) as OriginalCoin ,AVG(bs.ExchangeRate) as ExchangeRate,SUM(bs.CNY2) as CNY2,SUM(bs.OriginalCoin2) as OriginalCoin2
from bankslip bs join customer c on bs.Cus_ID=c.ID where CreateTimestamp BETWEEN @BeginTime AND @EndTime ");

                dp.Add("BeginTime", condition.BeginTimestamp, DbType.DateTime, null, null);
                dp.Add("EndTime", condition.EndTimestamp, DbType.DateTime, null, null);
                if (!string.IsNullOrEmpty(condition.Salesman))
                {
                    selectSql += " AND ID in (SELECT cs.Customer from customersalesman cs JOIN `user` u on cs.salesman=u.username WHERE u.username=@Salesman ) ";
                    dp.Add("Salesman", condition.Salesman, DbType.String, null, null);
                }
                else if (condition.DeptID >= 0)
                {
                    selectSql += " AND ID in (SELECT cs.Customer from customersalesman cs JOIN `user` u on cs.salesman=u.username WHERE u.DeptID=@DeptID) ";
                    dp.Add("DeptID", condition.DeptID, null, null, null);
                }

                selectSql += " group by c.`Name`";
                result = con.Query<CustomerReport>(selectSql, dp, tran);

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
            }
            else
            {
                selectSql = string.Format(@"SELECT c.`Name`,SUM(bb.CNY) as CNY,SUM(bb.OriginalCoin) as OriginalCoin ,AVG(bs.ExchangeRate) as ExchangeRate ,0 as CNY2 ,0 as OriginalCoin2
from budgetbill bb LEFT JOIN bankslip  bs on bb.BSID=bs.BSID
LEFT JOIN customer c on bb.Cus_ID=c.ID
WHERE bb.Confirmed=1 AND bb.OperateTimestamp BETWEEN @BeginTime AND @EndTime ");

                dp.Add("BeginTime", condition.BeginTimestamp, null, null, null);
                dp.Add("EndTime", condition.EndTimestamp, null, null, null);
                if (!string.IsNullOrEmpty(condition.Salesman))
                {
                    selectSql += " AND bb.Cus_ID in (SELECT cs.Customer from customersalesman cs JOIN `user` u on cs.salesman=u.username WHERE u.username=@Salesman ) ";
                    dp.Add("Salesman", condition.Salesman, null, null, null);
                }
                else if (condition.DeptID >= 0)
                {
                    selectSql += " AND bb.Cus_ID in (SELECT cs.Customer from customersalesman cs JOIN `user` u on cs.salesman=u.username WHERE u.DeptID=@DeptID) ";
                    dp.Add("DeptID", condition.DeptID, null, null, null);
                }
                if (condition.ID > 0)
                {
                    selectSql += " AND bb.BudgetID =@BudgetID";
                    dp.Add("BudgetID", condition.ID, null, null, null);
                }
                selectSql += " group by c.`Name`";
                result = con.Query<CustomerReport>(selectSql, dp, tran);

                selectSql = string.Format(@"select c.`Name`,d.* from Declarationform d join budget b on d.BudgetID=b.ID join customer c on b.CustomerID=c.ID
where d.CreateDate BETWEEN @BeginTime AND @EndTime ");

                if (condition.ID > 0)
                {
                    selectSql += " AND d.BudgetID=@BudgetID";
                    dp.Add("BudgetID", condition.ID, null, null, null);
                }
                IEnumerable<Declarationform> customerReportList = con.Query<Declarationform>(selectSql, dp, tran);
                if (result != null)
                {
                    foreach (CustomerReport report in result)
                    {
                        report.DeclarationformList = customerReportList.Where(o => o.Name.Equals(report.Name)).ToList();
                    }
                }
            }


            return result;
        }

        public IEnumerable<RecieptCapital> GetRecieptCapitalWithUSD(BudgetQueryCondition condition, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = @"select  SUM(bb.CNY) as CNY,SUM(bb.OriginalCoin) as OriginalCoin,bs.BankName,bs.PaymentMethod,DeptID,d.`Code`,d.`Name` from budgetbill bb 
                                LEFT JOIN bankslip bs on bb.BSID=bs.BSID  
                                LEFT JOIN department d on bb.DeptID=d.ID 
                                WHERE  bs.Currency='USD'
                                GROUP BY DeptID,bs.BankName,bs.PaymentMethod
                                UNION SELECT SUM(CNY2) as CNY,SUM(OriginalCoin2) as OriginalCoin,BankName,PaymentMethod,-1,'','余额' from bankslip
                                where Currency='USD'
                                GROUP BY BankName,PaymentMethod";
            DynamicParameters dp = new DynamicParameters();
            if (condition != null)
            {
                selectSql = @"select  SUM(bb.CNY) as CNY,SUM(bb.OriginalCoin) as OriginalCoin,bs.BankName,bs.PaymentMethod,DeptID,d.`Code`,d.`Name` from budgetbill bb 
                            LEFT JOIN bankslip bs on bb.BSID=bs.BSID  
                            LEFT JOIN department d on bb.DeptID=d.ID 
                            where bb.BSID in (SELECT BSID from bankslip where ReceiptDate BETWEEN @beginTime and @endTime) and  bs.Currency='USD'
                            GROUP BY DeptID,bs.BankName,bs.PaymentMethod
                            UNION SELECT SUM(CNY2) as CNY,SUM(OriginalCoin2) as OriginalCoin,BankName,PaymentMethod,-1,'','余额' from bankslip where ReceiptDate BETWEEN @beginTime and @endTime AND Currency='USD'
                            GROUP BY BankName,PaymentMethod";
                if (!string.IsNullOrEmpty(condition.A))
                {
                    selectSql = @"select  SUM(bb.CNY) as CNY,SUM(bb.OriginalCoin) as OriginalCoin,bs.BankName,bs.PaymentMethod,DeptID,d.`Code`,d.`Name` from budgetbill bb 
                            LEFT JOIN bankslip bs on bb.BSID=bs.BSID  
                            LEFT JOIN department d on bb.DeptID=d.ID 
                            where bb.BSID in (SELECT BSID from bankslip where ReceiptDate BETWEEN @beginTime and @endTime AND PaymentMethod in ('T/T','L/C')) and  bs.Currency='USD'
                            GROUP BY DeptID,bs.BankName,bs.PaymentMethod
                            UNION SELECT SUM(CNY2) as CNY,SUM(OriginalCoin2) as OriginalCoin,BankName,PaymentMethod,-1,'','余额' from bankslip where ReceiptDate BETWEEN @beginTime and @endTime AND Currency='USD' AND PaymentMethod in ('T/T','L/C')
                            GROUP BY BankName,PaymentMethod";
                }
                dp.Add("beginTime", condition.BeginTimestamp, DbType.DateTime, null, null);
                dp.Add("endTime", condition.EndTimestamp, DbType.DateTime, null, null);
            }

            return con.Query<RecieptCapital>(selectSql, dp, tran);
        }

        public IEnumerable<RecieptCapital> GetRecieptCapitalWithOutUSD(BudgetQueryCondition condition, IDbConnection con, IDbTransaction tran = null)
        {

            string selectSql = @"select  SUM(bb.CNY) as CNY,SUM(bb.OriginalCoin) as OriginalCoin,bs.BankName,bs.PaymentMethod,DeptID,d.`Code`,d.`Name` from budgetbill bb 
                                LEFT JOIN bankslip bs on bb.BSID=bs.BSID  
                                LEFT JOIN department d on bb.DeptID=d.ID 
                                WHERE  bs.Currency='USD'
                                GROUP BY DeptID,bs.BankName,bs.PaymentMethod
                                UNION SELECT SUM(CNY2) as CNY,SUM(OriginalCoin2) as OriginalCoin,BankName,PaymentMethod,-1,'','余额' from bankslip
                                where Currency<>'USD'
                                GROUP BY BankName,PaymentMethod";
            DynamicParameters dp = new DynamicParameters();
            if (condition != null)
            {
                selectSql = @"select  SUM(bb.CNY) as CNY,SUM(bb.OriginalCoin) as OriginalCoin,bs.BankName,bs.PaymentMethod,DeptID,d.`Code`,d.`Name` from budgetbill bb 
                            LEFT JOIN bankslip bs on bb.BSID=bs.BSID  
                            LEFT JOIN department d on bb.DeptID=d.ID 
                            where bb.BSID in (SELECT BSID from bankslip where ReceiptDate BETWEEN @beginTime and @endTime) and  bs.Currency<>'USD'
                            GROUP BY DeptID,bs.BankName,bs.PaymentMethod
                            UNION SELECT SUM(CNY2) as CNY,SUM(OriginalCoin2) as OriginalCoin,BankName,PaymentMethod,-1,'','余额' from bankslip where ReceiptDate BETWEEN @beginTime and @endTime AND Currency<>'USD'
                            GROUP BY BankName,PaymentMethod";
                if (!string.IsNullOrEmpty(condition.A))
                {
                    selectSql = @"select  SUM(bb.CNY) as CNY,SUM(bb.OriginalCoin) as OriginalCoin,bs.BankName,bs.PaymentMethod,DeptID,d.`Code`,d.`Name` from budgetbill bb 
                            LEFT JOIN bankslip bs on bb.BSID=bs.BSID  
                            LEFT JOIN department d on bb.DeptID=d.ID 
                            where bb.BSID in (SELECT BSID from bankslip where ReceiptDate BETWEEN @beginTime and @endTime AND PaymentMethod in ('T/T','L/C')) and  bs.Currency<>'USD'
                            GROUP BY DeptID,bs.BankName,bs.PaymentMethod
                            UNION SELECT SUM(CNY2) as CNY,SUM(OriginalCoin2) as OriginalCoin,BankName,PaymentMethod,-1,'','余额' from bankslip where ReceiptDate BETWEEN @beginTime and @endTime AND Currency<>'USD' AND PaymentMethod in ('T/T','L/C')
                            GROUP BY BankName,PaymentMethod";
                }
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
                if (!string.IsNullOrEmpty(condition.A))
                {
                    selectSql += " AND PaymentMethod IN ('T/T','T/C')";
                }
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
                if (!string.IsNullOrEmpty(condition.A))
                {
                    selectSql += " and PaymentMethod in ('T/T','L/C') ";
                }
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
