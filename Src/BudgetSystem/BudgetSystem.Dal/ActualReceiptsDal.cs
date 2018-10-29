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
            string selectSql = @"Select ar.`ID`,`BudgetID`,b.`ContractNO`,ar.`VoucherNo`,ar.`OriginalCoin`,ar.`RMB`,ar.`ReceiptDate`,ar.`CreateUser`,ar.`CreateTimestamp`,ar.`Description`,ar.`PaymentMethod`,ar.`DepartmentCode`,ar.`ExchangeRate`,ar.`BankName`,ar.`Remitter` 
            From `ActualReceipts` as ar LEFT  JOIN `Budget` as b on  ar.`BudgetID`=b.`ID`";
            return con.Query<ActualReceipts>(selectSql, null, tran);
        }

        public ActualReceipts GetActualReceiptById(int id, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select ar.`ID`,`BudgetID`,b.`ContractNO`,ar.`VoucherNo`,ar.`OriginalCoin`,ar.`RMB`,ar.`ReceiptDate`,ar.`CreateUser`,ar.`CreateTimestamp`,ar.`Description`,ar.`PaymentMethod`,ar.`DepartmentCode`,ar.`ExchangeRate`,ar.`BankName`,ar.`Remitter` 
            From `ActualReceipts` as ar LEFT  JOIN `Budget` as b on  ar.`BudgetID`=b.`ID` WHERE ar.`ID`=@ID";
            return con.Query<ActualReceipts>(selectSql, new { ID = id }, tran).SingleOrDefault();
        }

        public int AddActualReceipts(ActualReceipts actualReceipts, IDbConnection con, IDbTransaction tran)
        {
            string insertSql = "Insert Into `ActualReceipts` (`BudgetID`,`VoucherNo`,`OriginalCoin`,`RMB`,`ReceiptDate`,`CreateUser`,`CreateTimestamp`,`Description`,`PaymentMethod`,`DepartmentCode`,`ExchangeRate`,`BankName`,`Remitter`) Values (@BudgetID,@VoucherNo,@OriginalCoin,@RMB,@ReceiptDate,@CreateUser,@CreateTimestamp,@Description,@PaymentMethod,@DepartmentCode,@ExchangeRate,@BankName,@Remitter)";
            int id = con.Insert(insertSql, actualReceipts, tran);
            if (id > 0)
            {
                actualReceipts.ID = id;
            }
            return id;
        }

        public void ModifyActualReceipts(ActualReceipts modifyReceipt, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = "Update `ActualReceipts` Set `VoucherNo` = @VoucherNo,`BudgetID` = @BudgetID,`OriginalCoin` = @OriginalCoin,`RMB` = @RMB,`ReceiptDate` = @ReceiptDate,`CreateUser` = @CreateUser,`CreateTimestamp` = @CreateTimestamp,`Description` = @Description,`PaymentMethod` = @PaymentMethod,`DepartmentCode` = @DepartmentCode,`ExchangeRate` = @ExchangeRate,`BankName` = @BankName,`Remitter` = @Remitter Where `ID` = @ID";
            con.Execute(updateSql, modifyReceipt, tran);
        }

        public void RelationActualReceiptsToBudget(int Id, int budgetId, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = @"Update `ActualReceipts` Set `BudgetID` = @BudgetID Where `ID` = @ID";
            con.Execute(updateSql, new { BudgetID = budgetId, ID = Id }, tran);
        }

        /// <summary>
        /// 根据合同ID获取所有收款信息内容
        /// </summary>
        /// <param name="budgetId"></param>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public decimal GetTotalAmountByBudgetId(int budgetId, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"select sum(RMB) as TotalAmount from actualreceipts
                    where BudgetID=@BudgetID";

            IDbCommand command = con.CreateCommand();
            command.CommandText = selectSql;
            command.Transaction = tran;
            IDbDataParameter paramter = command.CreateParameter();
            paramter.DbType = DbType.Int32;
            paramter.ParameterName = "BudgetID";
            paramter.Value = budgetId;
            command.Parameters.Add(paramter);
            object obj = command.ExecuteScalar();
            return Convert.ToDecimal(obj);
        }

        public IEnumerable<ActualReceipts> GetActualReceiptsByBudgetId(int budgetId, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select ar.`ID`,`BudgetID`,b.`ContractNO`,ar.`VoucherNo`,ar.`OriginalCoin`,ar.`RMB`,ar.`ReceiptDate`,ar.`CreateUser`,ar.`CreateTimestamp`,ar.`Description`,ar.`PaymentMethod`,ar.`DepartmentCode`,ar.`ExchangeRate`,ar.`BankName`,ar.`Remitter` 
            From `ActualReceipts` as ar LEFT  JOIN `Budget` as b on  ar.`BudgetID`=b.`ID`
            WHERE ar.`BudgetID`=@BudgetID";
            return con.Query<ActualReceipts>(selectSql, new { BudgetID = budgetId }, tran);
        }

    }
}
