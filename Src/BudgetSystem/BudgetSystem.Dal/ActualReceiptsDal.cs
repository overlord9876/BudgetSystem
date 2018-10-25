using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Data;
using Dapper_NET20;
using System.Linq;

namespace BudgetSystem.Dal
{
    public class ActualReceiptsDal
    {
        public IEnumerable<ActualReceipts> GetAllActualReceipts(IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select `ActualReceipts`.`ID`,`BudgetID`,`Budget`.`ContractNO`,`ActualReceipts`.`VoucherNo`,`ActualReceipts`.`OriginalCoin`,`ActualReceipts`.`RMB`,`ActualReceipts`.`ReceiptDate`,`ActualReceipts`.`CreateUser`,`ActualReceipts`.`CreateTimestamp`,`ActualReceipts`.`Description`,`ActualReceipts`.`PaymentMethod`,`ActualReceipts`.`DepartmentCode`,`ActualReceipts`.`ExchangeRate`,`ActualReceipts`.`BankName`,`ActualReceipts`.`Remitter` 
            From `ActualReceipts` LEFT  JOIN `Budget` on  `ActualReceipts`.`BudgetID`=`Budget`.`ID`";
            return con.Query<ActualReceipts>(selectSql, null, tran);
        }

        public ActualReceipts GetActualReceiptById(int id, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select `ActualReceipts`.`ID`,`BudgetID`,`Budget`.`ContractNO`,`ActualReceipts`.`VoucherNo`,`ActualReceipts`.`OriginalCoin`,`ActualReceipts`.`RMB`,`ActualReceipts`.`ReceiptDate`,`ActualReceipts`.`CreateUser`,`ActualReceipts`.`CreateTimestamp`,`ActualReceipts`.`Description`,`ActualReceipts`.`PaymentMethod`,`ActualReceipts`.`DepartmentCode`,`ActualReceipts`.`ExchangeRate`,`ActualReceipts`.`BankName`,`ActualReceipts`.`Remitter` 
            From `ActualReceipts` LEFT  JOIN `Budget` on  `ActualReceipts`.`BudgetID`=`Budget`.`ID` WHERE `ActualReceipts`.`ID`=" + id;
            return con.Query<ActualReceipts>(selectSql, null, tran).SingleOrDefault();
        }

        public void AddActualReceipts(ActualReceipts user, IDbConnection con, IDbTransaction tran)
        {
            string insertSql = "Insert Into `ActualReceipts` (`ID`,`BudgetID`,`VoucherNo`,`OriginalCoin`,`RMB`,`ReceiptDate`,`CreateUser`,`CreateTimestamp`,`Description`,`PaymentMethod`,`DepartmentCode`,`ExchangeRate`,`BankName`,`Remitter`) Values (@ID,@BudgetID,@VoucherNo,@OriginalCoin,@RMB,@ReceiptDate,@CreateUser,@CreateTimestamp,@Description,@PaymentMethod,@DepartmentCode,@ExchangeRate,@BankName,@Remitter)";
            con.Execute(insertSql, user, tran);
        }

        public void ModifyActualReceipts(ActualReceipts user, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = "Update `ActualReceipts` Set `VoucherNo` = @VoucherNo,`BudgetID` = @BudgetID,`OriginalCoin` = @OriginalCoin,`RMB` = @RMB,`ReceiptDate` = @ReceiptDate,`CreateUser` = @CreateUser,`CreateTimestamp` = @CreateTimestamp,`Description` = @Description,`PaymentMethod` = @PaymentMethod,`DepartmentCode` = @DepartmentCode,`ExchangeRate` = @ExchangeRate,`BankName` = @BankName,`Remitter` = @Remitter) Where `ID` = @ID";
            con.Execute(updateSql, user, tran);
        }
    }
}
