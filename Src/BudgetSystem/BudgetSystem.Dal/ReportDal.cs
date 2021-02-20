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
        public IEnumerable<BudgetReport> GetBudgetReportList(BudgetQueryCondition condition, List<UseMoneyType> umtList, List<InMoneyType> imtList, IDbConnection con, IDbTransaction tran = null)
        {
            CommonDal dal = new CommonDal();

            string selectSql = string.Format(@"SELECT b.*,u.RealName  AS SalesmanName,d.`Code` AS DepartmentCode,d.`Name` AS DepartmentName
                                 FROM `Budget` b                                     
                                 LEFT JOIN `User` u ON b.Salesman=u.UserName 
                                 LEFT JOIN `Department` d ON b.DeptID=d.ID
                                where b.ID in (SELECT DISTINCT BudgetID from PaymentNotes where PaymentDate BETWEEN @BeginTime and @EndTime
                                UNION
                                select DISTINCT BudgetID from Invoice where {0} BETWEEN @BeginTime and @EndTime
                                UNION
                                select DISTINCT BudgetID from Declarationform  where ExportDate BETWEEN @BeginTime and @EndTime
                                UNION
                                select DISTINCT BudgetID from BudgetBill bb inner JOIN BankSlip bs on bb.BSID=bs.BSID where bs.CreateTimestamp BETWEEN @BeginTime and @EndTime) and b.ID<>0 ", condition.ViewMode == InvoiceViewMode.财务交单 ? "FinanceImportDate" : "ImportDate");//OR b.SignDate BETWEEN @BeginTime and @EndTime");

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
            if (!budgetList.Any())
            {
                return budgetList;
            }
            string budgetIds = string.Join(",", budgetList.Select(o => string.Format("{0}", o.ID)).ToArray());

            var dataExchangeRates = dal.GetDateExchanges(con, tran);

            IEnumerable<PaymentNotes> pnList = GetPaymentNotesList(condition, con, tran);
            decimal exchangeRate = 0;
            foreach (var pn in pnList)
            {
                if (pn.Currency == "美元")
                {
                    pn.USD = pn.OriginalCoin;
                }
                else
                {
                    exchangeRate = ExchageRateUtil.GetExchageRate(pn.PaymentDate, dataExchangeRates, (decimal)pn.ExchangeRate);
                    pn.USD = Math.Round(pn.CNY / exchangeRate, 2);
                }
            }
            List<Invoice> iList = GetInvoiceList(condition, con, tran).ToList();

            List<Invoice> iSingleBudgetFinalAccountsList = GetInvoiceList(budgetIds, con, tran).ToList();

            //iList.AddRange(PaymentToInvoice(pnList.ToList()));
            IEnumerable<BudgetBill> bbList = GetBudgetBillList(condition, con, tran);
            foreach (BudgetBill bb in bbList)
            {
                if (bb.Currency == "USD")
                {
                    bb.USD = bb.OriginalCoin;
                }
                else
                {
                    exchangeRate = ExchageRateUtil.GetExchageRate(bb.ReceiptDate, dataExchangeRates, bb.ExchangeRate);
                    bb.USD = Math.Round(bb.CNY / exchangeRate, 2);
                }
            }
            IEnumerable<BudgetBill> bbSingleBudgetFinalAccountsList = GetBudgetBillList(budgetIds, con, tran);
            foreach (BudgetBill bb in bbSingleBudgetFinalAccountsList)
            {
                if (bb.Currency == "USD")
                {
                    bb.USD = bb.OriginalCoin;
                }
                else
                {
                    exchangeRate = ExchageRateUtil.GetExchageRate(bb.ReceiptDate, dataExchangeRates, bb.ExchangeRate);
                    bb.USD = Math.Round(bb.CNY / exchangeRate, 2);
                }
            }
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
                    report.UMTList = umtList;
                    report.IMTList = imtList;
                    report.PaymentList = pnList.Where(o => o.BudgetID.Equals(report.ID)).ToList();
                    report.InvoiceList = iList.Where(o => o.BudgetID.Equals(report.ID)).ToList();
                    report.BudgetBillList = bbList.Where(o => o.BudgetID.Equals(report.ID)).ToList();
                    report.InvoiceSingleBudgetFinalAccountsList = iSingleBudgetFinalAccountsList.Where(o => o.BudgetID.Equals(report.ID)).ToList();
                    report.BBSingleBudgetFinalAccountsList = bbSingleBudgetFinalAccountsList.Where(o => o.BudgetID.Equals(report.ID)).ToList();
                    report.DeclarationformList = dList.Where(o => o.BudgetID.Equals(report.ID)).ToList();
                }
            }
            return budgetList;
        }

        private IEnumerable<PaymentNotes> GetPaymentNotesList(BudgetQueryCondition condition, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = string.Format(@"SELECT * from PaymentNotes where PaymentDate BETWEEN @BeginTime and @EndTime;");
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
            string selectSql = string.Format(@"select * from Invoice where {0} BETWEEN @BeginTime and @EndTime;", condition.ViewMode == InvoiceViewMode.财务交单 ? "FinanceImportDate" : "ImportDate");
            DynamicParameters dp = new DynamicParameters();
            dp.Add("BeginTime", condition.BeginTimestamp, null, null, null);
            dp.Add("EndTime", condition.EndTimestamp, null, null, null);
            return con.Query<Invoice>(selectSql, dp, tran);
        }

        private IEnumerable<Invoice> GetInvoiceList(string budgetIds, IDbConnection con, IDbTransaction tran = null)
        {
            //2020-09-17 计算交单信息，纳入财务未审核，并且交单时间为业务员交单信息，在统计信息里去除这些查询信息。
            string selectSql = string.Format(@"select * from Invoice where BudgetID in ({0}) ;", budgetIds);

            return con.Query<Invoice>(selectSql, null, tran);
        }

        public IEnumerable<BudgetBill> GetBudgetBillList(BudgetQueryCondition condition, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = string.Format(@"SELECT bb.*,bs.ExchangeRate,bs.NatureOfMoney,bs.ReceiptDate FROM BudgetBill bb LEFT JOIN BankSlip bs on bb.BSID=bs.BSID where bs.ReceiptDate BETWEEN @BeginTime and @EndTime AND bb.IsDelete=0;");
            DynamicParameters dp = new DynamicParameters();
            dp.Add("BeginTime", condition.BeginTimestamp, null, null, null);
            dp.Add("EndTime", condition.EndTimestamp, null, null, null);
            return con.Query<BudgetBill>(selectSql, dp, tran);
        }

        private IEnumerable<BudgetBill> GetBudgetBillList(string budgetIds, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = string.Format(@"SELECT bb.*,bs.ExchangeRate,bs.NatureOfMoney,bs.ReceiptDate FROM BudgetBill bb LEFT JOIN BankSlip bs on bb.BSID=bs.BSID WHERE BudgetID in ({0}) and  bb.IsDelete=0;", budgetIds);

            return con.Query<BudgetBill>(selectSql, null, tran);
        }

        public IEnumerable<Declarationform> GetDeclarationformList(BudgetQueryCondition condition, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = string.Format(@"SELECT * FROM Declarationform  where ExportDate BETWEEN @BeginTime and @EndTime;");
            DynamicParameters dp = new DynamicParameters();
            dp.Add("BeginTime", condition.BeginTimestamp, null, null, null);
            dp.Add("EndTime", condition.EndTimestamp, null, null, null);
            return con.Query<Declarationform>(selectSql, dp, tran);
        }

        public IEnumerable<SupplierReport> GetSupplierReportList(BudgetQueryCondition condition, List<UseMoneyType> typeList, IDbConnection con, IDbTransaction tran = null)
        {
            var result = SupplierReports(condition, con);
            if (result.Count > 0)
            {
                //与供应商名称相同的客户是供应商退款使用。
                string customName = string.Join(",", result.Select(o => $"{o.Name}").Distinct().ToArray());

                result.AddRange(CustomReports(condition, customName, con));
            }

            DynamicParameters dp = new DynamicParameters();
            dp.Add("BeginTime", condition.BeginTimestamp, null, null, null);
            dp.Add("EndTime", condition.EndTimestamp, null, null, null);
            string selectSql = string.Format(@"select i.* from Invoice i
                        WHERE i.FinanceImportDate BETWEEN @BeginTime AND @EndTime ");
            if (condition.ID > 0)
            {
                selectSql += " AND BudgetID=@BudgetID ";
                dp.Add("BudgetID", condition.ID, null, null, null);
            }

            string typeString = string.Join(",", typeList.Select(o => string.Format($"'{o.Name}'")).ToArray());

            List<Invoice> invoiceList = con.Query<Invoice>(selectSql, dp, tran).ToList();
            //将付款作为交单信息。
            string selectPaymentNotesSql = string.Format(@"SELECT *,s.`Name` as SupplierName from PaymentNotes pn INNER JOIN supplier s on pn.SupplierID=s.ID where HasInvoice=1   AND FIND_IN_SET(MoneyUsed ,@MoneyUsed) AND CommitTime BETWEEN @BeginTime and @EndTime ");
            dp = new DynamicParameters();
            dp.Add("MoneyUsed", typeString, null, null, null);
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
            List<SupplierReport> reports = new List<SupplierReport>();
            if (result != null)
            {
                CommonDal cd = new CommonDal();
                var dateExchanges = cd.GetDateExchanges(con);
                result.ToList().ForEach(o => { o.ResetExchangeRate(dateExchanges); });
                var suppliers = result.Select(o => o.Name).Distinct();
                decimal exchangeRate = 0;
                decimal totalCNY = 0;
                decimal totalUSD = 0;
                string supplierName = string.Empty;
                foreach (var sup in suppliers)
                {
                    var sups = result.Where(o => o.Name == sup);

                    exchangeRate = Math.Round(sups.Sum(o => o.ExchangeRate) / sups.Count(), 6);
                    totalCNY = sups.Sum(o => o.CNY);
                    totalUSD = sups.Sum(o => o.OriginalCoin);
                    supplierName = sups.ElementAt(0).Name;
                    SupplierReport supplier = new SupplierReport()
                    {
                        Name = supplierName,
                        ID = sups.ElementAt(0).ID,
                        ExchangeRate = exchangeRate,
                        TotalCNY = totalCNY,
                        TotalOriginalCoin = totalUSD,
                        InvoiceList = invoiceList.Where(o => supplierName.Equals(o.SupplierName)).ToList()
                    };
                    reports.Add(supplier);
                }
            }

            return reports;
        }

        private List<SupplierReportItem> SupplierReports(BudgetQueryCondition condition, IDbConnection con, IDbTransaction tran = null)
        {
            #region 供应商付款信息

            string selectSql = string.Format(@"SELECT s.ID,s.`Name`,pn.CNY,pn.ExchangeRate,pn.Currency, pn.OriginalCoin,DATE_FORMAT(pn.PaymentDate, '%Y-%m-%d') as PaymentDate from PaymentNotes pn join Supplier s on pn.SupplierID=s.ID 
where pn.CommitTime BETWEEN @BeginTime AND @EndTime");
            DynamicParameters dp = new DynamicParameters();
            dp.Add("BeginTime", condition.BeginTimestamp, null, null, null);
            dp.Add("EndTime", condition.EndTimestamp, null, null, null);
            if (!string.IsNullOrEmpty(condition.Salesman))
            {
                selectSql += " AND pn.BudgetID in (SELECT DISTINCT b.ID from `user` u JOIN budget b on u.UserName=b.Salesman where u.DeptID=@UserName) ";
                dp.Add("UserName", condition.Salesman, null, null, null);
            }
            else if (condition.DeptID >= 0)
            {
                selectSql += " AND pn.BudgetID in (SELECT DISTINCT b.ID from `user` u JOIN budget b on u.UserName=b.Salesman where u.DeptID=@DeptID) ";
                dp.Add("DeptID", condition.DeptID, null, null, null);
            }
            if (condition.ID > 0)
            {
                selectSql += " AND pn.BudgetID=@BudgetID "; //AND EXISTS(SELECT 1 FROM BudgetSuppliers WHERE Sup_ID = s.ID and ID = @BudgetID) 
                dp.Add("BudgetID", condition.ID, null, null, null);
            }

            var result = con.Query<SupplierReportItem>(selectSql, dp, tran).ToList();

            #endregion

            #region 供应商付款调出信息

            selectSql = string.Format(@"SELECT s.ID,s.`Name`,pa.AlreadySplitCNY as CNY,pa.AlreadySplitOriginalCoin as OriginalCoin,pn.ExchangeRate,DATE_FORMAT(pn.PaymentDate, '%Y-%m-%d') as PaymentDate FROM paymentaccountadjustment pa JOIN PaymentNotes pn on pa.RelationID=pn.ID join Supplier s on pn.SupplierID=s.ID 
WHERE  pn.PaymentDate BETWEEN @BeginTime AND @EndTime ");
            dp = new DynamicParameters();

            dp.Add("BeginTime", condition.BeginTimestamp, null, null, null);
            dp.Add("EndTime", condition.EndTimestamp, null, null, null);
            if (!string.IsNullOrEmpty(condition.Salesman))
            {
                selectSql += " AND pa.BudgetID in (SELECT DISTINCT b.ID from `user` u JOIN budget b on u.UserName=b.Salesman where u.DeptID=@UserName) ";
                dp.Add("UserName", condition.Salesman, null, null, null);
            }
            else if (condition.DeptID >= 0)
            {
                selectSql += " AND pa.BudgetID in (SELECT DISTINCT b.ID from `user` u JOIN budget b on u.UserName=b.Salesman where u.DeptID=@DeptID) ";
                dp.Add("DeptID", condition.DeptID, null, null, null);
            }
            if (condition.ID > 0)
            {
                selectSql += " AND pa.BudgetID=@BudgetID "; //AND EXISTS(SELECT 1 FROM BudgetSuppliers WHERE Sup_ID = s.ID and ID = @BudgetID) 
                dp.Add("BudgetID", condition.ID, null, null, null);
            }

            var adjustsmentPayments = con.Query<SupplierReportItem>(selectSql, dp, tran).ToList();
            adjustsmentPayments.ForEach(o =>
            {
                o.OriginalCoin = o.OriginalCoin * -1;
                o.CNY = o.CNY * -1;
            });
            result.AddRange(adjustsmentPayments);

            #endregion

            #region 供应商付款调入信息

            selectSql = string.Format(@"SELECT s.ID,s.`Name`,pad.CNY,pad.OriginalCoin,pn.ExchangeRate,DATE_FORMAT(pn.PaymentDate, '%Y-%m-%d') as PaymentDate FROM paymentaccountadjustmentdetail pad JOIN PaymentNotes pn on pad.RelationID=pn.ID join Supplier s on pn.SupplierID=s.ID 
WHERE  pn.PaymentDate BETWEEN @BeginTime AND @EndTime ");
            dp = new DynamicParameters();

            dp.Add("BeginTime", condition.BeginTimestamp, null, null, null);
            dp.Add("EndTime", condition.EndTimestamp, null, null, null);
            if (!string.IsNullOrEmpty(condition.Salesman))
            {
                selectSql += " AND pad.BudgetID in (SELECT DISTINCT b.ID from `user` u JOIN budget b on u.UserName=b.Salesman where u.DeptID=@UserName) ";
                dp.Add("UserName", condition.Salesman, null, null, null);
            }
            else if (condition.DeptID >= 0)
            {
                selectSql += " AND pad.BudgetID in (SELECT DISTINCT b.ID from `user` u JOIN budget b on u.UserName=b.Salesman where u.DeptID=@DeptID) ";
                dp.Add("DeptID", condition.DeptID, null, null, null);
            }
            if (condition.ID > 0)
            {
                selectSql += " AND pad.BudgetID=@BudgetID "; //AND EXISTS(SELECT 1 FROM BudgetSuppliers WHERE Sup_ID = s.ID and ID = @BudgetID) 
                dp.Add("BudgetID", condition.ID, null, null, null);
            }

            var adjustsmentDetailPayments = con.Query<SupplierReportItem>(selectSql, dp, tran).ToList();

            result.AddRange(adjustsmentDetailPayments);

            #endregion

            return result;
        }

        /// <summary>
        /// 获取付款退回（客户收款的客户名称与供应商一致，视为暂收款退回）
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="customNames"></param>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        private List<SupplierReportItem> CustomReports(BudgetQueryCondition condition, string customNames, IDbConnection con, IDbTransaction tran = null)
        {
            #region 客户收款信息（与供应商名称相同视为付款退回）

            string selectSql = string.Format(@"SELECT c.ID,c.`Name`,bb.CNY,bb.OriginalCoin,bs.ExchangeRate,DATE_FORMAT(bs.ReceiptDate, '%Y-%m-%d') as PaymentDate FROM budgetbill bb JOIN bankslip bs on bb.BSID=bs.BSID JOIN customer c on bs.Cus_ID=c.ID
WHERE FIND_IN_SET(c.`Name`,@Names) AND bs.ReceiptDate BETWEEN @BeginTime AND @EndTime ");
            DynamicParameters dp = new DynamicParameters();
            dp.Add("Names", customNames, null, null, null);
            dp.Add("BeginTime", condition.BeginTimestamp, null, null, null);
            dp.Add("EndTime", condition.EndTimestamp, null, null, null);
            if (condition.ID > 0)
            {
                selectSql += " AND bb.BudgetID=@BudgetID ";
                dp.Add("BudgetID", condition.ID, null, null, null);
            }
            if (!string.IsNullOrEmpty(condition.Salesman))
            {
                selectSql += " bb.BudgetID in (SELECT DISTINCT b.ID from `user` u JOIN budget b on u.UserName=b.Salesman where b.Salesman=@Salesman); ";
                dp.Add("Salesman", condition.Salesman, null, null, null);
            }

            else if (condition.DeptID >= 0)
            {
                selectSql += " bb.BudgetID in (SELECT DISTINCT b.ID from `user` u JOIN budget b on u.UserName=b.Salesman where u.DeptID=@DeptID); ";
                dp.Add("DeptID", condition.DeptID, null, null, null);
            }
            var result = con.Query<SupplierReportItem>(selectSql, dp, tran).ToList();
            result.ForEach(o =>
            {
                o.IsCustomer = true;
                o.CNY = o.CNY * -1;
                o.CNY = o.OriginalCoin * -1;
            });

            #endregion

            #region 供应商退款退回调出。

            selectSql = string.Format(@"SELECT c.ID,c.`Name`,ra.AlreadySplitCNY CNY,ra.AlreadySplitOriginalCoin OriginalCoin,bs.ExchangeRate,DATE_FORMAT(bs.ReceiptDate, '%Y-%m-%d') as PaymentDate FROM reciptaccountadjustment ra JOIN  budgetbill bb on ra.RelationID=bb.ID JOIN bankslip bs on bb.BSID=bs.BSID JOIN customer c on bs.Cus_ID=c.ID
WHERE  FIND_IN_SET(c.`Name`,@Names) AND bs.ReceiptDate BETWEEN @BeginTime AND @EndTime ");
            dp = new DynamicParameters();
            dp.Add("Names", customNames, null, null, null);
            dp.Add("BeginTime", condition.BeginTimestamp, null, null, null);
            dp.Add("EndTime", condition.EndTimestamp, null, null, null);
            if (condition.ID > 0)
            {
                selectSql += " AND ra.BudgetID=@BudgetID ";
                dp.Add("BudgetID", condition.ID, null, null, null);
            }
            if (!string.IsNullOrEmpty(condition.Salesman))
            {
                selectSql += " ra.BudgetID in (SELECT DISTINCT b.ID from `user` u JOIN budget b on u.UserName=b.Salesman where b.Salesman=@Salesman); ";
                dp.Add("Salesman", condition.Salesman, null, null, null);
            }

            else if (condition.DeptID >= 0)
            {
                selectSql += " ra.BudgetID in (SELECT DISTINCT b.ID from `user` u JOIN budget b on u.UserName=b.Salesman where u.DeptID=@DeptID); ";
                dp.Add("DeptID", condition.DeptID, null, null, null);
            }
            var adjustmentBB = con.Query<SupplierReportItem>(selectSql, dp, tran).ToList();
            adjustmentBB.ForEach(o =>
            {
                o.IsCustomer = true;
            });
            result.AddRange(adjustmentBB);

            #endregion

            #region 供应商退款退回调入。

            selectSql = string.Format(@"SELECT c.ID,c.`Name`,rad.CNY,rad.OriginalCoin,bs.ExchangeRate,DATE_FORMAT(bs.ReceiptDate, '%Y-%m-%d') as PaymentDate FROM reciptaccountadjustmentdetail rad JOIN  budgetbill bb on rad.RelationID=bb.ID JOIN bankslip bs on bb.BSID=bs.BSID JOIN customer c on bs.Cus_ID=c.ID
WHERE  FIND_IN_SET(c.`Name`,@Names) AND bs.ReceiptDate BETWEEN @BeginTime AND @EndTime ");
            dp = new DynamicParameters();
            dp.Add("Names", customNames, null, null, null);
            dp.Add("BeginTime", condition.BeginTimestamp, null, null, null);
            dp.Add("EndTime", condition.EndTimestamp, null, null, null);
            if (condition.ID > 0)
            {
                selectSql += " AND rad.BudgetID=@BudgetID ";
                dp.Add("BudgetID", condition.ID, null, null, null);
            }
            if (!string.IsNullOrEmpty(condition.Salesman))
            {
                selectSql += " rad.BudgetID in (SELECT DISTINCT b.ID from `user` u JOIN budget b on u.UserName=b.Salesman where b.Salesman=@Salesman); ";
                dp.Add("Salesman", condition.Salesman, null, null, null);
            }

            else if (condition.DeptID >= 0)
            {
                selectSql += " rad.BudgetID in (SELECT DISTINCT b.ID from `user` u JOIN budget b on u.UserName=b.Salesman where u.DeptID=@DeptID); ";
                dp.Add("DeptID", condition.DeptID, null, null, null);
            }
            var adjustmentDetailBB = con.Query<SupplierReportItem>(selectSql, dp, tran).ToList();
            adjustmentDetailBB.ForEach(o =>
            {
                o.CNY = o.CNY * -1;
                o.CNY = o.OriginalCoin * -1;
                o.IsCustomer = true;
            });
            result.AddRange(adjustmentDetailBB);

            #endregion

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
                        //report.DeclarationformList = customerReportList.Where(o => o.Name.Equals(report.Name)).ToList();
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
                        //report.DeclarationformList = customerReportList.Where(o => o.Name.Equals(report.Name)).ToList();
                    }
                }
            }


            return result;
        }

        public IEnumerable<RecieptCapital> GetRecieptCapitalWithUSD(BudgetQueryCondition condition, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = @"select  SUM(bb.CNY) as CNY,SUM(bb.OriginalCoin) as OriginalCoin,bs.BankName,bs.PaymentMethod,bs.NatureOfMoney,DeptID,d.`Code`,d.`Name` from budgetbill bb 
                                LEFT JOIN bankslip bs on bb.BSID=bs.BSID  
                                LEFT JOIN department d on bb.DeptID=d.ID 
                                WHERE  bs.Currency='USD'
                                GROUP BY DeptID,bs.BankName,bs.PaymentMethod,bs.NatureOfMoney
                                UNION SELECT SUM(CNY2) as CNY,SUM(OriginalCoin2) as OriginalCoin,BankName,PaymentMethod,NatureOfMoney,-1,'','余额' from bankslip
                                where Currency='USD'
                                GROUP BY BankName,PaymentMethod,NatureOfMoney";
            DynamicParameters dp = new DynamicParameters();
            if (condition != null)
            {
                selectSql = @"select  SUM(bb.CNY) as CNY,SUM(bb.OriginalCoin) as OriginalCoin,bs.BankName,bs.NatureOfMoney,bs.PaymentMethod,DeptID,d.`Code`,d.`Name` from budgetbill bb 
                            LEFT JOIN bankslip bs on bb.BSID=bs.BSID  
                            LEFT JOIN department d on bb.DeptID=d.ID 
                            where bb.BSID in (SELECT BSID from bankslip where ReceiptDate BETWEEN @beginTime and @endTime) and  bs.Currency='USD'
                            GROUP BY DeptID,bs.BankName,bs.PaymentMethod,bs.NatureOfMoney
                            UNION SELECT SUM(CNY2) as CNY,SUM(OriginalCoin2) as OriginalCoin,BankName,NatureOfMoney,PaymentMethod,-1,'','余额' from bankslip where ReceiptDate BETWEEN @beginTime and @endTime AND Currency='USD'
                            GROUP BY BankName,PaymentMethod,NatureOfMoney";
                if (!string.IsNullOrEmpty(condition.A))
                {
                    selectSql = @"select  SUM(bb.CNY) as CNY,SUM(bb.OriginalCoin) as OriginalCoin,bs.BankName,bs.PaymentMethod,bs.NatureOfMoney,DeptID,d.`Code`,d.`Name` from budgetbill bb 
                            LEFT JOIN bankslip bs on bb.BSID=bs.BSID  
                            LEFT JOIN department d on bb.DeptID=d.ID 
                            where bb.BSID in (SELECT BSID from bankslip where ReceiptDate BETWEEN @beginTime and @endTime AND PaymentMethod in ('T/T','L/C')) and  bs.Currency='USD'
                            GROUP BY DeptID,bs.BankName,bs.PaymentMethod,bs.NatureOfMoney
                            UNION SELECT SUM(CNY2) as CNY,SUM(OriginalCoin2) as OriginalCoin,BankName,PaymentMethod,NatureOfMoney,-1,'','余额' from bankslip where ReceiptDate BETWEEN @beginTime and @endTime AND Currency='USD' AND PaymentMethod in ('T/T','L/C')
                            GROUP BY BankName,PaymentMethod,NatureOfMoney";
                }
                dp.Add("beginTime", condition.BeginTimestamp, DbType.DateTime, null, null);
                dp.Add("endTime", condition.EndTimestamp, DbType.DateTime, null, null);
            }

            return con.Query<RecieptCapital>(selectSql, dp, tran);
        }

        public IEnumerable<RecieptCapital> GetRecieptCapitalWithOutUSD(BudgetQueryCondition condition, IDbConnection con, IDbTransaction tran = null)
        {

            string selectSql = @"select  SUM(bb.CNY) as CNY,SUM(bb.OriginalCoin) as OriginalCoin,bs.BankName,bs.PaymentMethod,bs.NatureOfMoney,DeptID,d.`Code`,d.`Name` from budgetbill bb 
                                LEFT JOIN bankslip bs on bb.BSID=bs.BSID  
                                LEFT JOIN department d on bb.DeptID=d.ID 
                                WHERE  bs.Currency='USD'
                                GROUP BY DeptID,bs.BankName,bs.PaymentMethod,bs.NatureOfMoney
                                UNION SELECT SUM(CNY2) as CNY,SUM(OriginalCoin2) as OriginalCoin,BankName,PaymentMethod,NatureOfMoney,-1,'','余额' from bankslip
                                where Currency<>'USD'
                                GROUP BY BankName,PaymentMethod,NatureOfMoney";
            DynamicParameters dp = new DynamicParameters();
            if (condition != null)
            {
                selectSql = @"select  SUM(bb.CNY) as CNY,SUM(bb.OriginalCoin) as OriginalCoin,bs.BankName,bs.PaymentMethod,bs.NatureOfMoney,DeptID,d.`Code`,d.`Name` from budgetbill bb 
                            LEFT JOIN bankslip bs on bb.BSID=bs.BSID  
                            LEFT JOIN department d on bb.DeptID=d.ID 
                            where bb.BSID in (SELECT BSID from bankslip where ReceiptDate BETWEEN @beginTime and @endTime) and  bs.Currency<>'USD'
                            GROUP BY DeptID,bs.BankName,bs.PaymentMethod,bs.NatureOfMoney
                            UNION SELECT SUM(CNY2) as CNY,SUM(OriginalCoin2) as OriginalCoin,BankName,PaymentMethod,NatureOfMoney,-1,'','余额' from bankslip where ReceiptDate BETWEEN @beginTime and @endTime AND Currency<>'USD'
                            GROUP BY BankName,PaymentMethod,NatureOfMoney";
                if (!string.IsNullOrEmpty(condition.A))
                {
                    if (condition.A == "人民币")
                    {
                        selectSql = @"select  SUM(bb.CNY) as CNY,SUM(bb.OriginalCoin) as OriginalCoin,bs.BankName,bs.PaymentMethod,bs.NatureOfMoney,DeptID,d.`Code`,d.`Name` from budgetbill bb 
                            LEFT JOIN bankslip bs on bb.BSID=bs.BSID  
                            LEFT JOIN department d on bb.DeptID=d.ID 
                            where bb.BSID in (SELECT BSID from bankslip where ReceiptDate BETWEEN @beginTime and @endTime AND Currency = 'CNY') and  bs.Currency='CNY'
                            GROUP BY DeptID,bs.BankName,bs.PaymentMethod,bs.NatureOfMoney
                            UNION SELECT SUM(CNY2) as CNY,SUM(OriginalCoin2) as OriginalCoin,BankName,PaymentMethod,NatureOfMoney,-1,'','余额' from bankslip where ReceiptDate BETWEEN @beginTime and @endTime  AND Currency = 'CNY'
                            GROUP BY BankName,PaymentMethod,NatureOfMoney";
                    }
                    else
                    {
                        selectSql = @"select  SUM(bb.CNY) as CNY,SUM(bb.OriginalCoin) as OriginalCoin,bs.BankName,bs.PaymentMethod,bs.NatureOfMoney,DeptID,d.`Code`,d.`Name` from budgetbill bb 
                            LEFT JOIN bankslip bs on bb.BSID=bs.BSID  
                            LEFT JOIN department d on bb.DeptID=d.ID 
                            where bb.BSID in (SELECT BSID from bankslip where ReceiptDate BETWEEN @beginTime and @endTime AND PaymentMethod in ('T/T','L/C')) and  bs.Currency<>'USD'
                            GROUP BY DeptID,bs.BankName,bs.PaymentMethod,bs.NatureOfMoney
                            UNION SELECT SUM(CNY2) as CNY,SUM(OriginalCoin2) as OriginalCoin,BankName,PaymentMethod,NatureOfMoney,-1,'','余额' from bankslip where ReceiptDate BETWEEN @beginTime and @endTime AND Currency<>'USD' AND PaymentMethod in ('T/T','L/C')
                            GROUP BY BankName,PaymentMethod,NatureOfMoney";
                    }
                }
                dp.Add("beginTime", condition.BeginTimestamp, DbType.DateTime, null, null);
                dp.Add("endTime", condition.EndTimestamp, DbType.DateTime, null, null);
            }

            return con.Query<RecieptCapital>(selectSql, dp, tran);
        }

        public IEnumerable<RecieptCapital> GetPaymentCapital(BudgetQueryCondition condition, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = @"SELECT sum(CNY) as CNY,PayingBank as BankName,DeptID,d.`Code`,d.`Name`,pn.MoneyUsed as NatureOfMoney  from paymentnotes pn
LEFT JOIN department d on pn.DeptID=d.ID 
WHERE PayingBank is not null
GROUP BY DeptID,PayingBank,pn.MoneyUsed";
            DynamicParameters dp = new DynamicParameters();
            if (condition != null)
            {
                selectSql = @"SELECT sum(CNY) as CNY,PayingBank as BankName,DeptID,d.`Code`,d.`Name`,pn.MoneyUsed as NatureOfMoney   from paymentnotes pn
LEFT JOIN department d on pn.DeptID=d.ID 
WHERE PaymentDate BETWEEN @beginTime and @endTime AND  PayingBank is not null
GROUP BY DeptID,PayingBank,pn.MoneyUsed";
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
