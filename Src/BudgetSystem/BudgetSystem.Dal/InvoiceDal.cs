using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;

using Dapper_NET20;
using BudgetSystem.Entity;
using BudgetSystem.Entity.QueryCondition;

namespace BudgetSystem.Dal
{
    public class InvoiceDal
    {
        private const string selectSql = @"SELECT i.*,c.`Name` CustomerName,u1.RealName ImportUserName,u2.RealName FinanceImportUserName,b.ContractNO FROM `Invoice` i
                             LEFT JOIN `Budget` b ON i.BudgetID=b.ID
							 LEFT JOIN `Customer` c ON b.CustomerID =c.ID
                             LEFT JOIN `User` u1 ON i.ImportUser=u1.UserName
                             LEFT JOIN `user` u2 on i.FinanceImportUser =u2.UserName
                             WHERE 1=1 ";
        public IEnumerable<Invoice> GetAllInvoice(InvoiceQueryCondition condition, IDbConnection con, IDbTransaction tran)
        {
            List<string> strConditionList = new List<string>();
            DynamicParameters dp = new DynamicParameters();
            string sql = selectSql;
            if (condition != null)
            {
                if (condition.DeptID >= 0)
                {
                    sql += " and i.ImportUser in (select UserName from `user` where DeptID=@DeptID)";
                    dp.Add("DeptID", condition.DeptID, DbType.Int32, ParameterDirection.Input, null);
                }
                if (!string.IsNullOrEmpty(condition.ContractNO))
                {
                    sql += " AND i.BudgetID in (SELECT ID FROM budget where ContractNO LIKE @ContractNO)";
                    dp.Add("@ContractNO", string.Format("%{0}%", condition.ContractNO), DbType.String, ParameterDirection.Input, null);
                }

                if (!string.IsNullOrEmpty(condition.Code))
                {
                    sql += @" AND i.BudgetID in (SELECT b.ID FROM budget b JOIN `Customer` c  on b.CustomerID=c.ID WHERE c.`Name` LIKE @Name)";
                    dp.Add("@Name", string.Format("%{0}%", condition.Code), DbType.String, ParameterDirection.Input, null);
                }
                if (condition.BeginTimestamp > new DateTime(1995, 1, 1) || condition.EndTimestamp > new DateTime(1995, 1, 1))
                {
                    if (condition.ViewMode == InvoiceViewMode.部门交单)
                    {
                        sql += @" AND i.ImportDate BETWEEN @BeginTimestamp AND @EndTimestamp";
                    }
                    else if (condition.ViewMode == InvoiceViewMode.财务交单)
                    {
                        sql += @" AND i.FinanceImportDate BETWEEN @BeginTimestamp AND @EndTimestamp";
                    }
                    else if (condition.ViewMode == InvoiceViewMode.未核销交单)
                    {
                        sql += @" AND i.ImportDate BETWEEN @BeginTimestamp AND @EndTimestamp AND i.ID NOT IN (SELECT ID from invoice WHERE FinanceImportDate BETWEEN @BeginTimestamp AND @EndTimestamp)";
                    }
                    else
                    {
                        sql += @" AND i.FinanceImportDate BETWEEN @BeginTimestamp AND @EndTimestamp AND i.ID NOT IN (SELECT ID from invoice WHERE ImportDate BETWEEN @BeginTimestamp AND @EndTimestamp)";
                    }
                    dp.Add("@BeginTimestamp", condition.BeginTimestamp, DbType.DateTime, ParameterDirection.Input, null);
                    dp.Add("@EndTimestamp", condition.EndTimestamp, DbType.DateTime, ParameterDirection.Input, null);
                }
            }
            return con.Query<Invoice>(sql, dp, tran);
        }

        public IEnumerable<Invoice> GetAllInvoiceByBudgetID(int budgetID, IDbConnection con, IDbTransaction tran)
        {
            string sql = selectSql + " and b.ID=@ID ";
            return con.Query<Invoice>(sql, new { ID = budgetID }, tran);
        }

        public IEnumerable<Invoice> GetAllInvoiceWithoutAdjustmentByBudgetID(int budgetID, IDbConnection con, IDbTransaction tran)
        {
            string sql = selectSql + " and b.ID=@BudgetID AND i.ID NOT IN (SELECT RelationID FROM invoiceaccountadjustment WHERE BudgetID=@BudgetID)";
            return con.Query<Invoice>(sql, new { BudgetID = budgetID });
        }

        public Invoice GetInvoice(int id, IDbConnection con, IDbTransaction tran)
        {
            string sql = selectSql + " and i.ID=@ID";
            return con.Query<Invoice>(sql, new { ID = id }, tran).SingleOrDefault();
        }

        public void AddInvoice(Invoice invoice, IDbConnection con, IDbTransaction tran)
        {
            string insertSql = @"Insert Into `Invoice` (`Number`,`Code`,`BudgetID`,`OriginalCoin`,`ExchangeRate`,`CustomsDeclaration`,`TaxRebateRate`,
                                        `Commission`,`FeedMoney`,`TaxpayerID`,`SupplierName`,`Payment`,`TaxAmount`,`ImportUser`,`ImportDate`,`FinanceImportUser`,`FinanceImportDate`) 
                                  Values (@Number,@Code,@BudgetID,@OriginalCoin,@ExchangeRate,@CustomsDeclaration,@TaxRebateRate,@Commission,@FeedMoney,
                                          @TaxpayerID,@SupplierName, @Payment,@TaxAmount,@ImportUser,now(),@FinanceImportUser,@FinanceImportDate)";
            con.Insert(insertSql, invoice, tran);
        }

        public void DeleteInvoice(Invoice invoice, IDbConnection con, IDbTransaction tran)
        {
            string insertSql = @"DELETE FROM `Invoice` WHERE ID = @ID";
            con.Execute(insertSql, new { ID = invoice.ID }, tran);
        }

        public int ModifyFinanceData(Invoice invoice, IDbConnection con, IDbTransaction tran)
        {
            string sql = @"UPDATE `Invoice` Set `Code` = @Code,`TaxpayerID` = @TaxpayerID,`SupplierName` = @SupplierName,`Payment` = @Payment,
                                              `TaxAmount` = @TaxAmount, `FinanceImportUser` = @FinanceImportUser,`FinanceImportDate` = now() 
                         WHERE `Number` = @Number";
            return con.Execute(sql, invoice, tran);
        }

        public void ModifyInvoice(Invoice invoice, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = @"Update `Invoice` Set `Number` = @Number,`Code` = @Code,`BudgetID` = @BudgetID,`OriginalCoin` = @OriginalCoin,
                                        `ExchangeRate` = @ExchangeRate,`CustomsDeclaration` = @CustomsDeclaration,`TaxRebateRate` = @TaxRebateRate,
                                        `Commission` = @Commission,`FeedMoney` = @FeedMoney,`TaxpayerID` = @TaxpayerID,`SupplierName` = @SupplierName,
                                         `Payment` = @Payment,`TaxAmount` = @TaxAmount,`ImportUser` = @ImportUser,`ImportDate` = @ImportDate,
                                         `FinanceImportUser` = @FinanceImportUser,`FinanceImportDate` = now()
                                  Where `ID` = @ID";
            con.Execute(updateSql, invoice, tran);
        }

        /// <summary>
        /// 验证发票号是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <param name="number"></param>
        /// <param name="con"></param>
        /// <returns></returns>
        public bool CheckNumber(int id, string number, IDbConnection con, IDbTransaction tran)
        {
            string sql = @"SELECT  id FROM `Invoice`  
                                    WHERE ID<>@ID and Number=@Number";
            using (IDbCommand command = con.CreateCommand())
            {
                command.CommandText = sql;
                command.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("ID", id));
                command.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("Number", number));
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

        /// <summary>
        /// 验证合同号是否存在
        /// </summary>
        /// <param name="budgetId"></param>
        /// <param name="?"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public bool CheckContractNO(int budgetId, IDbConnection con, IDbTransaction tran)
        {
            string sql = @"SELECT  id FROM `Invoice`  
                                    WHERE  `BudgetID`=@BudgetID";
            using (IDbCommand command = con.CreateCommand())
            {
                command.CommandText = sql;
                command.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("BudgetID", budgetId));
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

    }
}
