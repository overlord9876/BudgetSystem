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
            string selectSql = @"Select ar.`ID`,`BudgetID`,b.`ContractNO`,ar.`VoucherNo`,ar.`TradingPostscript`,ar.`OriginalCoin`,ar.`CNY`,ar.`ReceiptDate`,ar.`CreateUser`,ar.`CreateTimestamp`,ar.`Description`,ar.`PaymentMethod`,ar.`DepartmentCode`,ar.`ExchangeRate`,ar.`BankName`,ar.`Remitter` ,ar.`TradingPostscript`,ar.`State`,ar.`OriginalCoin2`,ar.`CNY2`,ar.`Operator`,ar.`OperateTimestamp`,ar.`IsDelete`,ar.`SourceID`
            From `ActualReceipts` as ar LEFT  JOIN `Budget` as b on  ar.`BudgetID`=b.`ID`
            WHERE ar.IsDelete=0 and ar.`ID`<>0";
            return con.Query<ActualReceipts>(selectSql, null, tran);
        }

        public IEnumerable<ActualReceipts> GetActualReceiptsBySalesman(string salesman, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select ar.`ID`,`BudgetID`,b.`ContractNO`,ar.`VoucherNo`,ar.`TradingPostscript`,ar.`OriginalCoin`,ar.`CNY`,ar.`ReceiptDate`,ar.`CreateUser`,ar.`CreateTimestamp`,ar.`Description`,ar.`PaymentMethod`,ar.`DepartmentCode`,ar.`ExchangeRate`,ar.`BankName`,ar.`Remitter` ,ar.`TradingPostscript`,ar.`State`,ar.`OriginalCoin2`,ar.`CNY2`,ar.`Operator`,ar.`OperateTimestamp`,ar.`IsDelete`,ar.`SourceID`
            From `ActualReceipts` as ar LEFT  JOIN `Budget` as b on  ar.`BudgetID`=b.`ID`
						inner join ReceiptNotice rn on ar.ID=rn.ID
            WHERE ar.IsDelete=0 and ar.`ID`<>0 and rn.UserName=@UserName";
            return con.Query<ActualReceipts>(selectSql, new { UserName = salesman }, tran);
        }

        public ActualReceipts GetActualReceiptById(int id, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select ar.`ID`,`BudgetID`,b.`ContractNO`,ar.`VoucherNo`,ar.`TradingPostscript`,ar.`OriginalCoin`,ar.`CNY`,ar.`ReceiptDate`,ar.`CreateUser`,ar.`CreateTimestamp`,ar.`Description`,ar.`PaymentMethod`,ar.`DepartmentCode`,ar.`ExchangeRate`,ar.`BankName`,ar.`Remitter` ,ar.`TradingPostscript`,ar.`State`,ar.`OriginalCoin2`,ar.`CNY2`,ar.`Operator`,ar.`OperateTimestamp`,ar.`IsDelete`,ar.`SourceID`
            From `ActualReceipts` as ar LEFT  JOIN `Budget` as b on  ar.`BudgetID`=b.`ID` WHERE ar.`ID`=@ID ";
            return con.Query<ActualReceipts>(selectSql, new { ID = id }, tran).SingleOrDefault();
        }

        public int AddActualReceipts(ActualReceipts actualReceipts, IDbConnection con, IDbTransaction tran)
        {
            string insertSql = "Insert Into `ActualReceipts` (`ID`,`VoucherNo`,`OriginalCoin`,`CNY`,`ReceiptDate`,`CreateUser`,`CreateTimestamp`,`Description`,`PaymentMethod`,`DepartmentCode`,`ExchangeRate`,`BankName`,`Remitter`,`BudgetID`,`Currency`,`ReceiptType`,`TradingPostscript`,`SourceID`,`State`,`IsDelete`,`OriginalCoin2`,`CNY2`,`Operator`,`OperateTimestamp`) Values (@ID,@VoucherNo,@OriginalCoin,@CNY,@ReceiptDate,@CreateUser,@CreateTimestamp,@Description,@PaymentMethod,@DepartmentCode,@ExchangeRate,@BankName,@Remitter,@BudgetID,@Currency,@ReceiptType,@TradingPostscript,@SourceID,@State,@IsDelete,@OriginalCoin2,@CNY2,@Operator,@OperateTimestamp)";
            int id = con.Insert(insertSql, actualReceipts, tran);
            if (id > 0)
            {
                actualReceipts.ID = id;
            }
            return id;
        }

        public void ModifyActualReceiptState(int id, int state, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = "Update `ActualReceipts` Set `State` = @State Where `ID` = @ID";
            con.Execute(updateSql, new { State = state, ID = id }, tran);
        }

        public void AddReceiptNotice(string userName, int id, IDbConnection con, IDbTransaction tran)
        {
            string insertSql = "Insert Into `ReceiptNotice` (`UserName`,`ID`) Values (@UserName,@ID)";
            con.Insert(insertSql, new { UserName = userName, ID = id }, tran);
        }

        public void ModifyActualReceipts(ActualReceipts modifyReceipt, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = "Update `ActualReceipts` Set `OriginalCoin2` = @OriginalCoin2,`CNY2` = @CNY2,`State` = @State,`Operator` = @Operator,`OperateTimestamp` = @OperateTimestamp Where `ID` = @ID";
            con.Execute(updateSql, modifyReceipt, tran);
        }

        public void ActualReceiptsRelationToBudget(ActualReceipts modifyReceipt, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = "Update `ActualReceipts` Set `BudgetID`=@BudgetID,`State` = @State,`Operator` = @Operator,`OperateTimestamp` = @OperateTimestamp Where `ID` = @ID";
            con.Execute(updateSql, modifyReceipt, tran);
        }

        public void DeleteRelationBudgetReceipt(int Id, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = @"Update `ActualReceipts` Set `IsDelete` = @IsDelete Where `ID` = @ID";
            con.Execute(updateSql, new { IsDelete = 1, ID = Id }, tran);
        }

        /// <summary>
        /// 删除收帐单关联业务员
        /// </summary>
        /// <param name="id"></param>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        public void DeleteReceiptNoticeByReceiptId(int id, IDbConnection con, IDbTransaction tran)
        {
            string deleteSql = "DELETE FROM `ReceiptNotice` WHERE  `ID` = @ID";
            con.Execute(deleteSql, new { ID = id }, tran);
        }

        /// <summary>
        /// 根据合同ID获取所有收款人民币金额
        /// </summary>
        /// <param name="budgetId"></param>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public decimal GetTotalAmountCNYByBudgetId(int budgetId, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"select sum(CNY) as TotalAmount from actualreceipts
                    where BudgetID=@BudgetID AND STATE<>4";

            IDbCommand command = con.CreateCommand();
            command.CommandText = selectSql;
            command.Transaction = tran;
            IDbDataParameter paramter = command.CreateParameter();
            paramter.DbType = DbType.Int32;
            paramter.ParameterName = "BudgetID";
            paramter.Value = budgetId;
            command.Parameters.Add(paramter);
            object obj = command.ExecuteScalar();
            decimal totalAmount = 0;
            decimal.TryParse(obj.ToString(), out totalAmount);
            return totalAmount;
        }

        /// <summary>
        /// 根据合同ID获取所有收款原币金额
        /// </summary>
        /// <param name="budgetId"></param>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public decimal GetTotalAmountOriginalCoinByBudgetId(int budgetId, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"select sum(OriginalCoin) as TotalAmount from actualreceipts
                    where BudgetID=@BudgetID AND STATE<>4";

            IDbCommand command = con.CreateCommand();
            command.CommandText = selectSql;
            command.Transaction = tran;
            IDbDataParameter paramter = command.CreateParameter();
            paramter.DbType = DbType.Int32;
            paramter.ParameterName = "BudgetID";
            paramter.Value = budgetId;
            command.Parameters.Add(paramter);
            object obj = command.ExecuteScalar();
            decimal totalAmount = 0;
            decimal.TryParse(obj.ToString(), out totalAmount);
            return totalAmount;
        }

        /// <summary>
        /// 获取原单据已经分拆金额。
        /// </summary>
        /// <param name="sourceId"></param>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public decimal GetAmountNotSplitBySourceId(int sourceId, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"select sum(CNY) as TotalAmount from actualreceipts
                    where BudgetID=@BudgetID AND SourceID=@SourceID AND STATE<>4";

            IDbCommand command = con.CreateCommand();
            command.CommandText = selectSql;
            command.Transaction = tran;
            IDbDataParameter paramter = command.CreateParameter();
            paramter.DbType = DbType.Int32;
            paramter.ParameterName = "SourceID";
            paramter.Value = sourceId;
            command.Parameters.Add(paramter);
            object obj = command.ExecuteScalar();
            decimal totalAmount = 0;
            decimal.TryParse(obj.ToString(), out totalAmount);
            return totalAmount;
        }

        public IEnumerable<ActualReceipts> GetActualReceiptsByBudgetId(int budgetId, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select ar.`ID`,`BudgetID`,b.`ContractNO`,ar.`VoucherNo`,ar.`TradingPostscript`,ar.`OriginalCoin`,ar.`CNY`,ar.`ReceiptDate`,ar.`CreateUser`,ar.`CreateTimestamp`,ar.`Description`,ar.`PaymentMethod`,ar.`DepartmentCode`,ar.`ExchangeRate`,ar.`BankName`,ar.`Remitter` ,ar.`TradingPostscript`,ar.`State`,ar.`OriginalCoin2`,ar.`CNY2`,ar.`Operator`,ar.`OperateTimestamp`,ar.`IsDelete`,ar.`SourceID`
            From `ActualReceipts` as ar LEFT  JOIN `Budget` as b on  ar.`BudgetID`=b.`ID`
            WHERE ar.`BudgetID`=@BudgetID AND ar.`ID`<>0";
            return con.Query<ActualReceipts>(selectSql, new { BudgetID = budgetId }, tran);
        }

    }
}
