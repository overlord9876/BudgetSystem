using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;

using Dapper_NET20;
using BudgetSystem.Entity;

namespace BudgetSystem.Dal
{
    public class InvoiceDal
    {
        string selectSql = @"SELECT i.*,u1.RealName ImportUserName,u2.RealName FinanceImportUserName FROM `Invoice` i
                                 LEFT JOIN `User` u1 ON i.ImportUser=u1.UserName
                                 LEFT JOIN `user` u2 on i.FinanceImportUser =u2.UserName ";
        public IEnumerable<Invoice> GetAllInvoice(IDbConnection con, IDbTransaction tran)
        {
            return con.Query<Invoice>(selectSql, null, tran);
        }

        public Invoice GetInvoice(int id, IDbConnection con, IDbTransaction tran)
        {
            string sql = selectSql + " WHERE i.ID=@ID";
            return con.Query<Invoice>(sql, new { ID = id }, tran).SingleOrDefault();
        }

        public void AddInvoice(Invoice invoice, IDbConnection con, IDbTransaction tran)
        {
            string insertSql = @"Insert Into `Invoice` (`Number`,`Code`,`ContractNO`,`OriginalCoin`,`ExchangeRate`,`CustomsDeclaration`,`TaxRebateRate`,
                                        `Commission`,`FeedMoney`,`TaxpayerID`,`SupplierName`,`Payment`,`TaxAmount`,`ImportUser`,`ImportDate`,`FinanceImportUser`,`FinanceImportDate`) 
                                  Values (@Number,@Code,@ContractNO,@OriginalCoin,@ExchangeRate,@CustomsDeclaration,@TaxRebateRate,@Commission,@FeedMoney,
                                          @TaxpayerID,@SupplierName, @Payment,@TaxAmount,@ImportUser,now(),@FinanceImportUser,@FinanceImportDate)";
            con.Insert(insertSql, invoice, tran);
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
            string updateSql = @"Update `Invoice` Set `Number` = @Number,`Code` = @Code,`ContractNO` = @ContractNO,`OriginalCoin` = @OriginalCoin,
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
            IDbCommand command = con.CreateCommand();
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
}
