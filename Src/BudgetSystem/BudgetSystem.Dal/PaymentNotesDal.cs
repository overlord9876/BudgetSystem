using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Data;
using Dapper_NET20;
using System.Linq;

namespace BudgetSystem.Dal
{
    public class PaymentNotesDal
    {
        public IEnumerable<PaymentNotes> GetAllPaymentNotes(IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select pn.*,b.ContractNO,s.`Name` as SupplierName,d.`Name` as DepartmentName,IFNULL((f.ApproveResult+f.IsClosed),-1) FlowState
            From `PaymentNotes` pn LEFT JOIN Budget b on pn.BudgetID=b.ID
						LEFT JOIN supplier s on pn.SupplierID=s.ID
						LEFT JOIN department d on pn.DepartmentCode=d.`Code`
						LEFT JOIN `FlowInstance` f ON f.DateItemID=pn.id AND f.DateItemType=@DateItemType AND f.IsRecent=1";
            return con.Query<PaymentNotes>(selectSql, new { DateItemType = EnumFlowDataType.付款单.ToString() }, tran);
        }

        public IEnumerable<PaymentNotes> GetTotalAmountPaymentMoneyByBudgetId(int budgetID, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select pn.*,b.ContractNO,s.`Name` as SupplierName,d.`Name` as DepartmentName,IFNULL((f.ApproveResult+f.IsClosed),-1) FlowState
            From `PaymentNotes` pn LEFT JOIN Budget b on pn.BudgetID=b.ID
						LEFT JOIN supplier s on pn.SupplierID=s.ID
						LEFT JOIN department d on pn.DepartmentCode=d.`Code`
						LEFT JOIN `FlowInstance` f ON f.DateItemID=pn.id AND f.DateItemType=@DateItemType AND f.IsRecent=1
            WHERE pn.BudgetID=@BudgetID";
            return con.Query<PaymentNotes>(selectSql, new { DateItemType = EnumFlowDataType.付款单.ToString(), BudgetID = budgetID }, tran);
        }

        public PaymentNotes GetPaymentNoteById(int id, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select pn.*,b.ContractNO,s.`Name` as SupplierName,d.`Name` as DepartmentName,IFNULL((f.ApproveResult+f.IsClosed),-1) FlowState
            From `PaymentNotes` pn LEFT JOIN Budget b on pn.BudgetID=b.ID
						LEFT JOIN supplier s on pn.SupplierID=s.ID
						LEFT JOIN department d on pn.DepartmentCode=d.`Code`
						LEFT JOIN `FlowInstance` f ON f.DateItemID=pn.id AND f.DateItemType=@DateItemType AND f.IsRecent=1
            Where pn.`ID` = @ID";
            return con.Query<PaymentNotes>(selectSql, new { DateItemType = EnumFlowDataType.付款单.ToString(), ID = id }, tran).SingleOrDefault();
        }

        public int AddPaymentNote(PaymentNotes addPaymentNote, IDbConnection con, IDbTransaction tran)
        {
            string insertSql = "Insert Into `paymentnotes` (`ID`,`CommitTime`,`CNY`,`BudgetID`,`SupplierID`,`PaymentDate`,`Description`,`DepartmentCode`,`MoneyUsed`,`IsDrawback`,`HasInvoice`,`PaymentMethod`,`VoucherNo`,`TaxRebateRate`,`Applicant`,`OriginalCoin`,`ExchangeRate`,`Currency`,`VatOption`,`UpdateTimestamp`,`BankName`,`BankNO`) Values (@ID,@CommitTime,@CNY,@BudgetID,@SupplierID,@PaymentDate,@Description,@DepartmentCode,@MoneyUsed,@IsDrawback,@HasInvoice,@PaymentMethod,@VoucherNo,@TaxRebateRate,@Applicant,@OriginalCoin,@ExchangeRate,@Currency,@VatOption,@UpdateTimestamp,@BankName,@BankNO)";
            int id = con.Insert(insertSql, addPaymentNote, tran);
            if (id > 0)
            {
                addPaymentNote.ID = id;
            }
            return id;
        }

        public void ModifyPaymentNote(PaymentNotes modifyPaymentNote, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = "Update `paymentnotes` Set `CommitTime` = @CommitTime,`CNY` = @CNY,`BudgetID` = @BudgetID,`SupplierID` = @SupplierID,`PaymentDate` = @PaymentDate,`Description` = @Description,`DepartmentCode` = @DepartmentCode,`MoneyUsed` = @MoneyUsed,`IsDrawback` = @IsDrawback,`HasInvoice` = @HasInvoice,`PaymentMethod` = @PaymentMethod,`VoucherNo` = @VoucherNo,`TaxRebateRate` = @TaxRebateRate,`Applicant` = @Applicant,`OriginalCoin` = @OriginalCoin,`ExchangeRate` = @ExchangeRate,`Currency` = @Currency,`VatOption` = @VatOption,`UpdateTimestamp` = @UpdateTimestamp,`BankName` = @BankName,`BankNO` = @BankNO Where `ID` = @ID";
            con.Execute(updateSql, modifyPaymentNote, tran);
        }

        public void DeletePaymentNote(int id, IDbConnection con, IDbTransaction tran)
        {
            string deleteSql = "Delete From `PaymentNotes` Where `ID` = @ID";
            con.Execute(deleteSql, new { ID = id }, tran);
        }

        /// <summary>
        /// 合同付款，单个非合格供方付款人民币总数
        /// </summary>
        /// <param name="budgetId"></param>
        /// <param name="supplierId"></param>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public decimal GetTemporarySupplierPaymentByBudgetId(int budgetId, int supplierId, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"select SUM(CNY) from PaymentNotes pn
INNER JOIN Supplier s on pn.SupplierID=s.ID and s.SupplierType=1 and s.ID=@SupplierID
 where BudgetID=50;";

            IDbCommand command = con.CreateCommand();
            command.CommandText = selectSql;
            command.Transaction = tran;
            IDbDataParameter budgetIDParamter = command.CreateParameter();
            budgetIDParamter.DbType = DbType.Int32;
            budgetIDParamter.ParameterName = "BudgetID";
            budgetIDParamter.Value = budgetId;
            command.Parameters.Add(budgetIDParamter);

            IDbDataParameter supplierIDParamter = command.CreateParameter();
            supplierIDParamter.DbType = DbType.Int32;
            supplierIDParamter.ParameterName = "SupplierID";
            supplierIDParamter.Value = budgetId;
            command.Parameters.Add(supplierIDParamter);
            object obj = command.ExecuteScalar();
            decimal totalPaymentAmount = 0;
            decimal.TryParse(obj.ToString(), out totalPaymentAmount);
            return totalPaymentAmount;
        }

        /// <summary>
        /// 验证合同ID是否存在
        /// </summary>
        /// <param name="budgetID"></param> 
        /// <param name="con"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public bool CheckContractNO(int budgetID, IDbConnection con, IDbTransaction tran)
        {
            string sql = @"SELECT  id FROM `PaymentNotes`  
                                    WHERE  `BudgetID`=@BudgetID";
            IDbCommand command = con.CreateCommand();
            command.CommandText = sql;
            command.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("BudgetID", budgetID));
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
