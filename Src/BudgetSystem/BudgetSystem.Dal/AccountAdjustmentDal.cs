using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using BudgetSystem.Entity.QueryCondition;
using System.Data;
using Dapper_NET20;
using System.Linq;
using MySql.Data.MySqlClient;

namespace BudgetSystem.Dal
{
    public class AccountAdjustmentDal : DalBase
    {
        const string insertPaymentDetails = "Insert Into `PaymentAccountAdjustmentDetail` (`ID`,`PID`,`RelationID`,`BudgetID`,`Type`,`OriginalCoin`,`ExchangeRate`,`CNY`,`Operator`,`IsDelete`,`Confirmed`,`OperatorDate`) Values(@ID, @PID, @RelationID, @BudgetID, @Type, @OriginalCoin, @ExchangeRate, @CNY, @Operator, @IsDelete, @Confirmed, @OperatorDate)";
        const string insertReciptDetails = "Insert Into `ReciptAccountAdjustmentDetail` (`ID`,`PID`,`RelationID`,`BudgetID`,`Type`,`OriginalCoin`,`ExchangeRate`,`CNY`,`Operator`,`IsDelete`,`Confirmed`,`OperatorDate`) Values(@ID, @PID, @RelationID, @BudgetID, @Type, @OriginalCoin, @ExchangeRate, @CNY, @Operator, @IsDelete, @Confirmed, @OperatorDate)";
        const string insertInvoiceDetails = "Insert Into `InvoiceAccountAdjustmentDetail` (`ID`,`PID`,`RelationID`,`BudgetID`,`Type`,`OriginalCoin`,`ExchangeRate`,`CNY`,`FeedMoney`,`Payment`,`Amount`,`Operator`,`IsDelete`,`Confirmed`,`OperatorDate`) Values(@ID, @PID, @RelationID, @BudgetID, @Type, @OriginalCoin, @ExchangeRate, @CNY, @FeedMoney, @Payment, @Amount, @Operator, @IsDelete, @Confirmed, @OperatorDate)";


        public AccountAdjustment GetAccountAdjustment(int id, AdjustmentType atType, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = string.Empty;
            EnumFlowDataType dataType = EnumFlowDataType.交单调账;
            if (atType == AdjustmentType.付款)
            {
                dataType = EnumFlowDataType.付款调账;
                selectSql = @"SELECT ra.*,b.ContractNO, pn.CNY,pn.VoucherNo,s.`Name`,u.RealName as CreateRealUserName,IFNULL((f.ApproveResult+f.IsClosed),-1) FlowState,f.ID AS FlowInstanceID,f.FlowName
                            FROM PaymentAccountAdjustment ra JOIN budget b on ra.BudgetID=b.ID
                            JOIN paymentnotes pn on ra.RelationID=pn.ID
                            JOIN `user` u on ra.CreateUser=u.UserName														
                            JOIN supplier s on pn.SupplierID=s.ID 
                            LEFT JOIN `FlowInstance` f ON f.DateItemID=ra.id AND f.DateItemType=@DateItemType AND f.IsRecent=1
                            WHERE ra.ID=@ID;";
            }
            else if (atType == AdjustmentType.收款)
            {
                dataType = EnumFlowDataType.收款调账;
                selectSql = @"SELECT ra.*,b.ContractNO,u.RealName as CreateRealUserName,bb.OriginalCoin,bs.ExchangeRate, bb.CNY,bs.VoucherNo,c.`Name`,bs.NatureOfMoney as MoneyUsed,IFNULL((f.ApproveResult+f.IsClosed),-1) FlowState,f.ID AS FlowInstanceID,f.FlowName
                                FROM ReciptAccountAdjustment ra JOIN budget b on ra.BudgetID=b.ID
                                JOIN budgetbill bb on ra.RelationID=bb.ID
                                JOIN bankslip bs on bb.BSID =bs.BSID 
                                JOIN `user` u on ra.CreateUser=u.UserName	
								JOIN customer c on bb.Cus_ID=c.ID
								LEFT JOIN `FlowInstance` f ON f.DateItemID=ra.id AND f.DateItemType=@DateItemType AND f.IsRecent=1
								WHERE ra.ID=@ID;";
            }
            else
            {
                selectSql = @"SELECT ra.*,b.ContractNO,u.RealName as CreateRealUserName,i.OriginalCoin,i.ExchangeRate,i.Number as VoucherNo,i.SupplierName as `Name`,i.TaxAmount,i.FeedMoney,i.Payment,i.TaxAmount,u.RealName as CreateRealUserName,IFNULL((f.ApproveResult+f.IsClosed),-1) FlowState,f.ID AS FlowInstanceID,f.FlowName
                            FROM InvoiceAccountAdjustment ra JOIN budget b on ra.BudgetID=b.ID
                            JOIN invoice i on ra.RelationID=i.ID
                            JOIN `user` u on ra.CreateUser=u.UserName
							LEFT JOIN `FlowInstance` f ON f.DateItemID=ra.id AND f.DateItemType=@DateItemType AND f.IsRecent=1
                            WHERE ra.ID=@ID;";
            }
            AccountAdjustment AccountAdjustment = con.Query<AccountAdjustment>(selectSql, new { ID = id, DateItemType = dataType.ToString() }, tran).SingleOrDefault();

            return AccountAdjustment;
        }

        public IEnumerable<AccountAdjustment> GetAllAccountAdjustment(IDbConnection con, IDbTransaction tran = null, AccountAdjustmentQueryCondition condition = null)
        {
            string selectRecSql = $@"SELECT ra.*,b.ContractNO,u.RealName as CreateRealUserName,bb.OriginalCoin,bs.ExchangeRate, bb.CNY,bs.VoucherNo,c.`Name`,bs.NatureOfMoney as MoneyUsed,IFNULL((f.ApproveResult+f.IsClosed),-1) FlowState,f.ID AS FlowInstanceID,f.FlowName
                                FROM ReciptAccountAdjustment ra JOIN budget b on ra.BudgetID=b.ID
                                JOIN budgetbill bb on ra.RelationID=bb.ID
                                JOIN bankslip bs on bb.BSID =bs.BSID 
                                JOIN `user` u on ra.CreateUser=u.UserName		
								JOIN customer c on bb.Cus_ID=c.ID
								LEFT JOIN `FlowInstance` f ON f.DateItemID=ra.id AND f.DateItemType='{EnumFlowDataType.收款调账}' AND f.IsRecent=1 
                                where ra.Id>0 ";
            DynamicParameters dp = new DynamicParameters();

            if (condition != null)
            {
                if (!string.IsNullOrEmpty(condition.Salesman))
                {
                    selectRecSql += " and b.Salesman=@Salesman ";
                    dp.Add("Salesman", condition.Salesman, null, null, null);
                }
                if (condition.DeptID >= 0)
                {
                    selectRecSql += " and b.DeptID=@DeptID ";
                    dp.Add("DeptID", condition.DeptID, null, null, null);
                }
            }

            var recItems = con.Query<AccountAdjustment>(selectRecSql, dp, tran).ToList();

            string selectPaySql = $@"SELECT ra.*,b.ContractNO, pn.CNY,pn.VoucherNo,s.`Name`,u.RealName as CreateRealUserName,IFNULL((f.ApproveResult+f.IsClosed),-1) FlowState,f.ID AS FlowInstanceID,f.FlowName
                            FROM PaymentAccountAdjustment ra JOIN budget b on ra.BudgetID=b.ID
                            JOIN paymentnotes pn on ra.RelationID=pn.ID
                            JOIN `user` u on ra.CreateUser=u.UserName														
                            JOIN supplier s on pn.SupplierID=s.ID 
                            LEFT JOIN `FlowInstance` f ON f.DateItemID=ra.id AND f.DateItemType='{EnumFlowDataType.付款调账}' AND f.IsRecent=1
                            where ra.Id>0 ";
            dp = new DynamicParameters();
            if (condition != null)
            {
                if (!string.IsNullOrEmpty(condition.Salesman))
                {
                    selectPaySql += " and b.Salesman=@Salesman ";
                    dp.Add("Salesman", condition.Salesman, null, null, null);
                }
                if (condition.DeptID >= 0)
                {
                    selectPaySql += " and b.DeptID=@DeptID ";
                    dp.Add("DeptID", condition.DeptID, null, null, null);
                }
            }

            var payItems = con.Query<AccountAdjustment>(selectPaySql, dp, tran);
            recItems.AddRange(payItems);
            string selectInvoiceSql = $@"SELECT ra.*,b.ContractNO,u.RealName as CreateRealUserName,i.OriginalCoin,i.ExchangeRate,i.Number as VoucherNo,i.SupplierName as `Name`,i.TaxAmount,i.FeedMoney,i.Payment,i.TaxAmount,u.RealName as CreateRealUserName,IFNULL((f.ApproveResult+f.IsClosed),-1) FlowState,f.ID AS FlowInstanceID,f.FlowName
                            FROM InvoiceAccountAdjustment ra JOIN budget b on ra.BudgetID=b.ID
                            JOIN invoice i on ra.RelationID=i.ID
                            JOIN `user` u on ra.CreateUser=u.UserName
							LEFT JOIN `FlowInstance` f ON f.DateItemID=ra.id AND f.DateItemType='{EnumFlowDataType.交单调账}' AND f.IsRecent=1
                            where ra.Id>0 ";
            dp = new DynamicParameters();
            if (condition != null)
            {
                if (!string.IsNullOrEmpty(condition.Salesman))
                {
                    selectInvoiceSql += " and b.Salesman=@Salesman ";
                    dp.Add("Salesman", condition.Salesman, null, null, null);
                }
                if (condition.DeptID >= 0)
                {
                    selectInvoiceSql += " and b.DeptID=@DeptID ";
                    dp.Add("DeptID", condition.DeptID, null, null, null);
                }
            }
            var invoiceItems = con.Query<AccountAdjustment>(selectInvoiceSql, dp, tran);
            recItems.AddRange(invoiceItems);
            return recItems;
        }

        public IEnumerable<AccountAdjustment> GetBalanceAccountAdjustmentByBudgetId(int budgetId, IDbConnection con, IDbTransaction tran = null, bool includInvoice = true)
        {
            string selectRecSql = @"SELECT ra.*,b.ContractNO,bb.OriginalCoin,bs.ReceiptDate as Date, bb.CNY,bs.VoucherNo,c.`Name`,bs.NatureOfMoney as MoneyUsed
                                FROM ReciptAccountAdjustment ra JOIN budget b on ra.BudgetID=b.ID
                                JOIN budgetbill bb on ra.RelationID=bb.ID
                                JOIN bankslip bs on bb.BSID =bs.BSID 
								JOIN customer c on bb.Cus_ID=c.ID
								WHERE ra.BudgetID=@BudgetID;";
            var recItems = con.Query<AccountAdjustment>(selectRecSql, new { BudgetID = budgetId }, tran).ToList();

            string selectPaySql = @"SELECT ra.*,b.ContractNO,pn.OriginalCoin,pn.CNY,pn.PaymentDate as Date,pn.VoucherNo,s.`Name`,pn.MoneyUsed,pn.IsDrawback,pn.TaxRebateRate
                                from PaymentAccountAdjustment ra JOIN budget b on ra.BudgetID=b.ID
                                JOIN paymentnotes pn on ra.RelationID=pn.ID
								JOIN supplier s on pn.SupplierID=s.ID
								WHERE ra.BudgetID=@BudgetID;";

            var payItems = con.Query<AccountAdjustment>(selectPaySql, new { BudgetID = budgetId }, tran);
            recItems.AddRange(payItems);

            if (includInvoice)
            {
                string selectInvoiceSql = @"SELECT ia.*,b.ContractNO,i.OriginalCoin,i.ExchangeRate,i.Number as VoucherNo,i.SupplierName as `Name`,i.TaxAmount,i.FeedMoney,i.Payment,i.TaxAmount
                                from invoiceaccountadjustment ia JOIN budget b on ia.BudgetID=b.ID
                                JOIN invoice i on ia.RelationID=i.ID
																where ia.BudgetID=@BudgetID;";
                var invoiceItems = con.Query<AccountAdjustment>(selectInvoiceSql, new { BudgetID = budgetId }, tran);
                recItems.AddRange(invoiceItems);
            }
            return recItems;
        }

        public IEnumerable<AccountAdjustmentDetail> GetBalanceAccountAdjustmentDetailByBudgetId(int budgetId, IDbConnection con, IDbTransaction tran = null, bool includInvoice = true)
        {
            string selectRecSql = @"SELECT pad.*,m.ContractNO as MainContractNO,b.ContractNO,s.`Name`,pn.IsDrawback,pn.MoneyUsed,pn.TaxRebateRate,pn.Currency,pn.PaymentDate as Date,u.RealName as OperatorRealName,pn.VoucherNo from paymentaccountadjustmentdetail pad
                                    JOIN paymentaccountadjustment pa on pad.PID=pa.ID
									JOIN budget b on b.id=pa.BudgetID
									JOIN budget m on m.id=pad.BudgetID
	                                JOIN paymentnotes pn on pad.RelationID=pn.ID 
									JOIN supplier s on s.id = pn.SupplierID
	                                JOIN `user` u on pad.Operator=u.UserName
	                                WHERE pad.BudgetID=@BudgetID AND pad.IsDelete=0;";
            var recItems = con.Query<AccountAdjustmentDetail>(selectRecSql, new { BudgetID = budgetId }, tran).ToList();

            string selectPaySql = @"SELECT rad.*,m.ContractNO as MainContractNO,b.ContractNO,c.`Name`,bs.NatureOfMoney as MoneyUsed,bs.Currency,bs.ReceiptDate as Date,u.RealName as OperatorRealName,bs.VoucherNo  
                                    FROM reciptaccountadjustmentdetail rad
									JOIN reciptaccountadjustment ra on rad.PID=ra.ID
									JOIN budget b on b.id=ra.BudgetID
									JOIN budget m on m.id=rad.BudgetID
                                    JOIN budgetbill bb on rad.RelationID=bb.ID
                                    JOIN bankslip bs on bb.BSID =bs.BSID
									JOIN customer c on bs.Cus_ID=c.id
                                    JOIN `user` u on rad.Operator=u.UserName
                                    WHERE rad.BudgetID=@BudgetID AND rad.IsDelete=0;";
            var payItems = con.Query<AccountAdjustmentDetail>(selectPaySql, new { BudgetID = budgetId }, tran);
            recItems.AddRange(payItems);
            if (includInvoice)
            {
                string selectInvoiceSql = @"SELECT rad.*,m.ContractNO as MainContractNO,b.ContractNO,i.TaxAmount,u.RealName as OperatorRealName,i.SupplierName as `Name`
                                        FROM invoiceaccountadjustmentdetail rad
										JOIN invoiceaccountadjustment ia on rad.PID=ia.ID
									    JOIN budget b on b.id=ia.BudgetID
									    JOIN budget m on m.id=ia.BudgetID
                                        JOIN invoice i on rad.RelationID=i.ID
                                        JOIN `user` u on rad.Operator=u.UserName
                                        WHERE rad.BudgetID=@BudgetID AND rad.IsDelete=0;";
                var invoiceItems = con.Query<AccountAdjustmentDetail>(selectInvoiceSql, new { BudgetID = budgetId }, tran);
                recItems.AddRange(invoiceItems);
            }
            return recItems;
        }

        /// <summary>
        /// 获取调入详情信息。这里关联的合同号是调出主表的合同号。
        /// </summary>
        /// <param name="budgetId"></param>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        /// <param name="includInvoice"></param>
        /// <returns></returns>
        public IEnumerable<AccountAdjustmentDetail> GetAccountAdjustmentsDetailByBudgetId(int budgetId, IDbConnection con, IDbTransaction tran = null, bool includInvoice = true)
        {
            string selectRecSql = @"SELECT pad.*,b.ContractNO,pn.IsDrawback,pn.MoneyUsed,pn.TaxRebateRate,pn.Currency,pn.PaymentDate as Date,u.RealName as OperatorRealName,pn.VoucherNo,s.`Name` from paymentaccountadjustmentdetail pad
									JOIN budget b on b.id=pad.BudgetID
	                                JOIN paymentnotes pn on pad.RelationID=pn.ID 
	                                JOIN `user` u on pad.Operator=u.UserName
									JOIN supplier s on pn.SupplierID=s.ID
										WHERE pad.PID IN (SELECT ID from paymentaccountadjustment WHERE BudgetID=@BudgetID) AND pad.IsDelete=0;";
            var recItems = con.Query<AccountAdjustmentDetail>(selectRecSql, new { BudgetID = budgetId }, tran).ToList();

            string selectPaySql = @"SELECT rad.*,b.ContractNO,bs.NatureOfMoney as MoneyUsed,bs.ExchangeRate,bs.Currency,bs.ReceiptDate as Date,u.RealName as OperatorRealName,bs.VoucherNo,c.`Name` 
                                    FROM reciptaccountadjustmentdetail rad
									JOIN budget b on b.id=rad.BudgetID
                                    JOIN budgetbill bb on rad.RelationID=bb.ID
                                    JOIN bankslip bs on bb.BSID =bs.BSID
									JOIN customer c on bs.Cus_ID=c.ID
                                    JOIN `user` u on rad.Operator=u.UserName
									WHERE rad.PID IN (SELECT ID from reciptaccountadjustment WHERE BudgetID=@BudgetID) AND rad.IsDelete=0;";
            var payItems = con.Query<AccountAdjustmentDetail>(selectPaySql, new { BudgetID = budgetId }, tran);
            recItems.AddRange(payItems);
            if (includInvoice)
            {
                string selectInvoiceSql = @"SELECT rad.*,b.ContractNO,i.ExchangeRate,i.FeedMoney,i.Payment,i.TaxAmount,u.RealName as OperatorRealName,i.SupplierName as `Name`
                                        FROM invoiceaccountadjustmentdetail rad
									    JOIN budget b on b.id=rad.BudgetID
                                        JOIN invoice i on rad.RelationID=i.ID
                                        JOIN `user` u on rad.Operator=u.UserName
										WHERE rad.PID IN (SELECT ID from invoiceaccountadjustment WHERE BudgetID=@BudgetID) AND rad.IsDelete=0;";
                var invoiceItems = con.Query<AccountAdjustmentDetail>(selectInvoiceSql, new { BudgetID = budgetId }, tran);
                recItems.AddRange(invoiceItems);
            }
            return recItems;
        }

        public IEnumerable<AccountAdjustmentReport> GetAccountAdjustmentReportList(BudgetQueryCondition condition, IDbConnection con, IDbTransaction tran = null)
        {
            string selectPaymentSql = $@"SELECT b.ContractNO,CONCAT(d.`Code`,d.`Name`) as DeptCode,paa.AlreadySplitCNY as PaymentCNYOut,f.CloseDateTime as Date from paymentaccountadjustment paa JOIN budget b on paa.BudgetID=b.ID JOIN department d on b.DeptID=d.ID JOIN FlowInstance f on paa.ID=f.DateItemID AND f.DateItemType='{EnumFlowDataType.付款调账}' AND f.IsRecent=1 ";
            DynamicParameters dp = new DynamicParameters();
            if (condition != null)
            {
                selectPaymentSql += " AND f.CloseDateTime BETWEEN @BeginDate AND @EndDate";
                dp.Add("BeginDate", condition.BeginTimestamp, null, null, null);
                dp.Add("EndDate", condition.EndTimestamp, null, null, null);
            }
            var payItems = con.Query<AccountAdjustmentReport>(selectPaymentSql, dp, tran).ToList();

            string selectPayDetailSql = $@"SELECT b.ContractNO,CONCAT(d.`Code`,d.`Name`) as DeptCode,(0-pad.CNY) as PaymentCNYIn,f.CloseDateTime as Date from paymentaccountadjustmentDetail pad JOIN budget b on pad.BudgetID=b.ID JOIN department d on b.DeptID=d.ID JOIN paymentaccountadjustment pa on pa.ID=pad.PID  JOIN FlowInstance f on pa.ID=f.DateItemID AND f.DateItemType='{EnumFlowDataType.付款调账}' AND f.IsRecent=1";
            dp = new DynamicParameters();
            if (condition != null)
            {
                selectPayDetailSql += " AND f.CloseDateTime BETWEEN @BeginDate AND @EndDate";
                dp.Add("BeginDate", condition.BeginTimestamp, null, null, null);
                dp.Add("EndDate", condition.EndTimestamp, null, null, null);
            }
            var payDetailItems = con.Query<AccountAdjustmentReport>(selectPayDetailSql, dp, tran);
            payItems.AddRange(payDetailItems);

            string selectRecieptSql = $@"SELECT b.ContractNO,CONCAT(d.`Code`,d.`Name`) as DeptCode,raa.AlreadySplitCNY as BillCNYOut,f.CloseDateTime as Date from reciptaccountadjustment raa JOIN budget b on raa.BudgetID=b.ID JOIN department d on b.DeptID=d.ID JOIN FlowInstance f on raa.ID=f.DateItemID AND f.DateItemType='{EnumFlowDataType.收款调账}' AND f.IsRecent=1";
            dp = new DynamicParameters();
            if (condition != null)
            {
                selectRecieptSql += " AND f.CloseDateTime BETWEEN @BeginDate AND @EndDate";
                dp.Add("BeginDate", condition.BeginTimestamp, null, null, null);
                dp.Add("EndDate", condition.EndTimestamp, null, null, null);
            }
            var recieptList = con.Query<AccountAdjustmentReport>(selectRecieptSql, dp, tran).ToList();
            payItems.AddRange(recieptList);

            string selectRecieptDetailSql = $@"SELECT b.ContractNO,CONCAT(d.`Code`,d.`Name`) as DeptCode,(0-rad.CNY) as BillCNYIn,rad.OperatorDate as Date  from reciptaccountadjustmentDetail rad JOIN budget b on rad.BudgetID=b.ID JOIN department d on b.DeptID=d.ID JOIN reciptaccountadjustment ra on ra.ID=rad.PID  JOIN FlowInstance f on ra.ID=f.DateItemID AND f.DateItemType='{EnumFlowDataType.收款调账}' AND f.IsRecent=1";
            dp = new DynamicParameters();
            if (condition != null)
            {
                selectRecieptDetailSql += " AND f.CloseDateTime BETWEEN @BeginDate AND @EndDate";
                dp.Add("BeginDate", condition.BeginTimestamp, null, null, null);
                dp.Add("EndDate", condition.EndTimestamp, null, null, null);
            }
            var recieptDetailList = con.Query<AccountAdjustmentReport>(selectRecieptDetailSql, dp, tran);
            payItems.AddRange(recieptDetailList);

            string selectInvoiceSql = $@"SELECT b.ContractNO,CONCAT(d.`Code`,d.`Name`) as DeptCode,iaa.AlreadySplitCNY as InvoiceCNYOut,f.CloseDateTime as Date  from invoiceaccountadjustment iaa JOIN budget b on iaa.BudgetID=b.ID JOIN department d on b.DeptID=d.ID JOIN FlowInstance f on iaa.ID=f.DateItemID AND f.DateItemType='{EnumFlowDataType.交单调账}' AND f.IsRecent=1";
            dp = new DynamicParameters();
            if (condition != null)
            {
                selectInvoiceSql += " AND f.CloseDateTime BETWEEN @BeginDate AND @EndDate";
                dp.Add("BeginDate", condition.BeginTimestamp, null, null, null);
                dp.Add("EndDate", condition.EndTimestamp, null, null, null);
            }
            var invoiceItems = con.Query<AccountAdjustmentReport>(selectInvoiceSql, dp, tran).ToList();
            payItems.AddRange(invoiceItems);

            string selectInvoiceDetailSql = $@"SELECT b.ContractNO,CONCAT(d.`Code`,d.`Name`) as DeptCode,(0-iad.CNY) as InvoiceCNYIn,iad.OperatorDate as Date  from invoiceaccountadjustmentDetail iad JOIN budget b on iad.BudgetID=b.ID JOIN department d on b.DeptID=d.ID JOIN invoiceaccountadjustment ia on ia.ID=iad.PID  JOIN FlowInstance f on ia.ID=f.DateItemID AND f.DateItemType='{EnumFlowDataType.交单调账}' AND f.IsRecent=1";
            dp = new DynamicParameters();
            if (condition != null)
            {
                selectInvoiceDetailSql += " AND f.CloseDateTime BETWEEN @BeginDate AND @EndDate";
                dp.Add("BeginDate", condition.BeginTimestamp, null, null, null);
                dp.Add("EndDate", condition.EndTimestamp, null, null, null);
            }
            var invoiceDetailItems = con.Query<AccountAdjustmentReport>(selectInvoiceDetailSql, dp, tran);
            payItems.AddRange(invoiceDetailItems);

            return payItems;
        }

        /// <summary>
        /// 根据父拆分类型获取列表。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="atType"></param>
        /// <returns></returns>
        public IEnumerable<AccountAdjustmentDetail> GetAccountAdjustmentDetailByTypeId(int id, AdjustmentType atType, IDbConnection con, IDbTransaction tran = null)
        {
            if (atType == AdjustmentType.付款)
            {
                string selectRecSql = @"SELECT pad.*,pn.IsDrawback,pn.MoneyUsed,pn.TaxRebateRate,u.RealName as OperatorRealName from paymentaccountadjustmentdetail pad
	                                    join paymentnotes pn on pad.RelationID=pn.ID 
	                                    JOIN `user` u on pad.Operator=u.UserName
	                                    WHERE pad.PID=@PID;";
                return con.Query<AccountAdjustmentDetail>(selectRecSql, new { PID = id }, tran).ToList();
            }

            if (atType == AdjustmentType.收款)
            {
                string selectPaySql = @"SELECT rad.*,bs.NatureOfMoney as MoneyUsed,u.RealName as OperatorRealName from reciptaccountadjustmentdetail rad
                                        JOIN budgetbill bb on rad.RelationID=bb.ID
                                        JOIN bankslip bs on bb.BSID =bs.BSID 
                                        JOIN `user` u on rad.Operator=u.UserName
                                        WHERE rad.PID=@PID;";

                return con.Query<AccountAdjustmentDetail>(selectPaySql, new { PID = id }, tran);
            }

            if (atType == AdjustmentType.交单)
            {
                string selectInvoiceSql = @"SELECT rad.*,i.ExchangeRate,i.FeedMoney,i.Payment,i.TaxAmount,u.RealName as OperatorRealName from invoiceaccountadjustmentdetail rad
                                            JOIN invoice i on rad.RelationID=i.ID
                                            JOIN `user` u on rad.Operator=u.UserName
                                            WHERE rad.PID=@PID ;";

                return con.Query<AccountAdjustmentDetail>(selectInvoiceSql, new { PID = id }, tran);
            }
            return null;
        }

        /// <summary>
        /// 验证名称是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <param name="code"></param>
        /// <param name="atType"></param>
        /// <param name="con"></param>
        /// <returns></returns>
        public bool CheckCode(string code, int id, AdjustmentType atType, IDbConnection con)
        {
            string selectSql = string.Empty;
            if (atType == AdjustmentType.付款)
            {
                selectSql = @"SELECT  id FROM `PaymentAccountAdjustment`  WHERE ID<>@ID and `Code`=@Code";
            }
            else if (atType == AdjustmentType.收款)
            {
                selectSql = @"SELECT  id FROM `reciptaccountadjustment`  WHERE ID<>@ID and `Code`=@Code";
            }
            else
            {
                selectSql = @"SELECT  id FROM `invoiceaccountadjustment`  WHERE ID<>@ID and `Code`=@Code";
            }
            using (IDbCommand command = con.CreateCommand())
            {
                command.CommandText = selectSql;
                command.Parameters.Add(new MySqlParameter("ID", id));
                command.Parameters.Add(new MySqlParameter("Code", code));
                object obj = command.ExecuteScalar();
                if (obj != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public int AddAccountAdjustment(AccountAdjustment AccountAdjustment, List<AccountAdjustmentDetail> details, IDbConnection con, IDbTransaction tran = null)
        {
            string insertSql = string.Empty;
            string insertDetails = string.Empty;
            if (AccountAdjustment.Type == AdjustmentType.付款)
            {
                insertSql = "Insert Into `PaymentAccountAdjustment` (`ID`,`Code`,`Type`,`RelationID`,`BudgetID`,`ExchangeRate`,`Currency`,`State`,`AlreadySplitOriginalCoin`,`AlreadySplitCNY`,`CreateDate`,`CreateUser`,`UpdateDate`,`UpdateUser`,`Remark`,`SplitOriginalCoin`,`SplitCNY`,Role) Values (@ID,@Code,@Type,@RelationID,@BudgetID,@ExchangeRate,@Currency,@State,@AlreadySplitOriginalCoin,@AlreadySplitCNY,@CreateDate,@CreateUser,@UpdateDate,@UpdateUser,@Remark,@SplitOriginalCoin,@SplitCNY,@Role)";
                insertDetails = insertPaymentDetails;
            }
            else if (AccountAdjustment.Type == AdjustmentType.收款)
            {
                insertSql = "Insert Into `ReciptAccountAdjustment` (`ID`,`Code`,`Type`,`RelationID`,`BudgetID`,`ExchangeRate`,`Currency`,`State`,`AlreadySplitOriginalCoin`,`AlreadySplitCNY`,`CreateDate`,`CreateUser`,`UpdateDate`,`UpdateUser`,`Remark`,`SplitOriginalCoin`,`SplitCNY`,Role) Values (@ID,@Code,@Type,@RelationID,@BudgetID,@ExchangeRate,@Currency,@State,@AlreadySplitOriginalCoin,@AlreadySplitCNY,@CreateDate,@CreateUser,@UpdateDate,@UpdateUser,@Remark,@SplitOriginalCoin,@SplitCNY,@Role)";
                insertDetails = insertReciptDetails;
            }
            else if (AccountAdjustment.Type == AdjustmentType.交单)
            {
                insertSql = "Insert Into `InvoiceAccountAdjustment` (`ID`,`Code`,`Type`,`RelationID`,`BudgetID`,`ExchangeRate`,`Currency`,`State`,`AlreadySplitOriginalCoin`,`AlreadySplitCNY`,`AlreadySplitFeedMoney`,`AlreadySplitPayment`,`AlreadySplitTaxAmount`,`CreateDate`,`CreateUser`,`UpdateDate`,`UpdateUser`,`Remark`,`SplitOriginalCoin`,`SplitCNY`,Role) Values (@ID,@Code,@Type,@RelationID,@BudgetID,@ExchangeRate,@Currency,@State,@AlreadySplitOriginalCoin,@AlreadySplitCNY,@AlreadySplitFeedMoney,@AlreadySplitPayment,@AlreadySplitTaxAmount,@CreateDate,@CreateUser,@UpdateDate,@UpdateUser,@Remark,@SplitOriginalCoin,@SplitCNY,@Role)";
                insertDetails = insertInvoiceDetails;
            }
            int id = con.Insert(insertSql, AccountAdjustment, tran);

            if (details != null)
            {
                foreach (var item in details)
                {
                    item.PID = id;
                    con.Insert(insertDetails, item, tran);
                }
            }

            return id;
        }

        public bool ExistsItem(int relationId, AdjustmentType type, IDbConnection con, IDbTransaction tran = null)
        {
            string existsQuery = string.Empty;
            if (type == AdjustmentType.付款)
            {
                existsQuery = "SELECT ID FROM `PaymentAccountAdjustment` WHERE Type=@Type AND RelationID=@RelationID;";
            }
            else if (type == AdjustmentType.收款)
            {
                existsQuery = "SELECT ID FROM `ReciptAccountAdjustment` WHERE Type=@Type AND RelationID=@RelationID;";
            }
            else if (type == AdjustmentType.交单)
            {
                existsQuery = "SELECT ID FROM `InvoiceAccountAdjustment` WHERE Type=@Type AND RelationID=@RelationID;";
            }
            bool exists = false;
            using (IDbCommand command = con.CreateCommand())
            {
                command.CommandText = existsQuery;
                command.Parameters.Add(new MySqlParameter("RelationID", relationId));
                command.Parameters.Add(new MySqlParameter("Type", (int)type));
                object obj = command.ExecuteScalar();
                if (obj != null)
                {
                    exists = true;
                }
            }
            return exists;
        }

        public DateTime ModifyAccountAdjustment(AccountAdjustment accountAdjustment, List<AccountAdjustmentDetail> details, IDbConnection con, IDbTransaction tran = null)
        {
            string updateSql = "";
            string insertDetails = string.Empty;
            string existsQuery = string.Empty;
            string detailUpdateSql = "";
            DateTime versionNumber = DateTime.MinValue;
            if (accountAdjustment.Type == AdjustmentType.收款)
            {
                versionNumber = GetModifyDateTimeByTable("`ReciptAccountAdjustment`", "`UpdateDate`", accountAdjustment.ID, con, tran, "`ID`");
                updateSql = "Update `ReciptAccountAdjustment` Set `ExchangeRate` = @ExchangeRate,`Currency` = @Currency,`State` = @State,`AlreadySplitOriginalCoin` = @AlreadySplitOriginalCoin,`AlreadySplitCNY` = @AlreadySplitCNY,`UpdateDate` = @UpdateDate,`UpdateUser` = @UpdateUser,`Remark` = @Remark,SplitOriginalCoin=@SplitOriginalCoin,SplitCNY=@SplitCNY Where `ID` = @ID";
                insertDetails = insertReciptDetails;
                existsQuery = "select ID from ReciptAccountAdjustmentDetail where Id=@ID";
                detailUpdateSql = "Update `ReciptAccountAdjustmentDetail` Set `BudgetID` = @BudgetID,`Type` = @Type,`OriginalCoin` = @OriginalCoin,`ExchangeRate` = @ExchangeRate,`CNY` = @CNY,`Operator` = @Operator,`IsDelete` = @IsDelete,`Confirmed` = @Confirmed,`OperatorDate` = @OperatorDate Where `ID` = @ID";
            }
            else if (accountAdjustment.Type == AdjustmentType.付款)
            {
                versionNumber = GetModifyDateTimeByTable("`PaymentAccountAdjustment`", "`UpdateDate`", accountAdjustment.ID, con, tran, "`ID`");
                updateSql = "Update `PaymentAccountAdjustment` Set `ExchangeRate` = @ExchangeRate,`Currency` = @Currency,`State` = @State,`AlreadySplitCNY` = @AlreadySplitCNY,`AlreadySplitOriginalCoin` = @AlreadySplitOriginalCoin,`UpdateDate` = @UpdateDate,`UpdateUser` = @UpdateUser,`Remark` = @Remark,SplitOriginalCoin=@SplitOriginalCoin,SplitCNY=@SplitCNY Where `ID` = @ID";
                insertDetails = insertPaymentDetails;
                existsQuery = "select ID from PaymentAccountAdjustmentDetail where Id=@ID";
                detailUpdateSql = "Update `PaymentAccountAdjustmentDetail` Set `BudgetID` = @BudgetID,`Type` = @Type,`OriginalCoin` = @OriginalCoin,`ExchangeRate` = @ExchangeRate,`CNY` = @CNY,`Operator` = @Operator,`IsDelete` = @IsDelete,`Confirmed` = @Confirmed,`OperatorDate` = @OperatorDate Where `ID` = @ID";
            }
            else if (accountAdjustment.Type == AdjustmentType.交单)
            {
                versionNumber = GetModifyDateTimeByTable("`InvoiceAccountAdjustment`", "`UpdateDate`", accountAdjustment.ID, con, tran, "`ID`");
                updateSql = "Update `InvoiceAccountAdjustment` Set `ExchangeRate` = @ExchangeRate,`Currency` = @Currency,`State` = @State,`AlreadySplitOriginalCoin` = @AlreadySplitOriginalCoin,`AlreadySplitCNY` = @AlreadySplitCNY,`AlreadySplitFeedMoney` = @AlreadySplitFeedMoney,`AlreadySplitPayment` = @AlreadySplitPayment,`AlreadySplitTaxAmount` = @AlreadySplitTaxAmount,`UpdateDate` = @UpdateDate,`UpdateUser` = @UpdateUser,`Remark` = @Remark,SplitOriginalCoin=@SplitOriginalCoin,SplitCNY=@SplitCNY Where `ID` = @ID";
                insertDetails = insertInvoiceDetails;
                existsQuery = "select ID from InvoiceAccountAdjustmentDetail where Id=@ID";
                detailUpdateSql = "Update `InvoiceAccountAdjustmentDetail` Set `BudgetID` = @BudgetID,`Type` = @Type,`OriginalCoin` = @OriginalCoin,`ExchangeRate` = @ExchangeRate,`CNY` = @CNY,`FeedMoney` = @FeedMoney,`Payment` = @Payment,`Amount` = @Amount,`Operator` = @Operator,`IsDelete` = @IsDelete,`Confirmed` = @Confirmed,`OperatorDate` = @OperatorDate Where `ID` = @ID";
            }
            if (this.CheckExpired(versionNumber, accountAdjustment.UpdateDate))
            {
                throw new VersionNumberException("当前数据已过期，请刷新数据之后再完成修改。");
            }
            versionNumber = GetDateTimeNow(con);
            accountAdjustment.UpdateDate = versionNumber;

            con.Execute(updateSql, accountAdjustment, tran);
            bool exists = false;
            if (details != null)
            {
                foreach (var item in details)
                {
                    exists = false;
                    item.PID = accountAdjustment.ID;
                    using (IDbCommand command = con.CreateCommand())
                    {
                        command.CommandText = existsQuery;
                        command.Parameters.Add(new MySqlParameter("ID", item.ID));
                        object obj = command.ExecuteScalar();
                        if (obj != null)
                        {
                            exists = true;
                        }
                    }
                    if (exists)
                    {
                        con.Execute(detailUpdateSql, item, tran);
                    }
                    else
                    {
                        con.Insert(insertDetails, item, tran);
                    }
                }
            }
            return versionNumber;
        }

        public void DeleteAccountAdjustment(AccountAdjustment accountAdjustment, IDbConnection con, IDbTransaction tran = null)
        {
            if (accountAdjustment.Type == AdjustmentType.交单)
            {
                string detailDeleteSql = "Delete From `InvoiceAccountAdjustmentDetail` Where `PID` = @PID";
                con.Execute(detailDeleteSql, new { PID = accountAdjustment.ID }, tran);

                string deleteSql = @"delete from `InvoiceAccountAdjustment` Where `ID` = @ID";
                con.Execute(deleteSql, new { ID = accountAdjustment.ID }, tran);
            }
            else if (accountAdjustment.Type == AdjustmentType.付款)
            {
                string detailDeleteSql = "Delete From `PaymentAccountAdjustmentDetail` Where `PID` = @PID";
                con.Execute(detailDeleteSql, new { PID = accountAdjustment.ID }, tran);

                string deleteSql = @"delete from `PaymentAccountAdjustment` Where `ID` = @ID";
                con.Execute(deleteSql, new { ID = accountAdjustment.ID }, tran);
            }
            else if (accountAdjustment.Type == AdjustmentType.收款)
            {
                string detailDeleteSql = "Delete From `ReciptAccountAdjustmentDetail` Where `PID` = @PID";
                con.Execute(detailDeleteSql, new { PID = accountAdjustment.ID }, tran);

                string deleteSql = @"delete from `ReciptAccountAdjustment` Where `ID` = @ID";
                con.Execute(deleteSql, new { ID = accountAdjustment.ID }, tran);
            }
        }

    }
}
