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
            string selectSql = @"Select pn.`ID`,pn.`CommitTime`,pn.`Money`,pn.`Approver`,pn.`ApproveTime`,pn.`BudgetID`,b.ContractNO,pn.`SupplierID`,s.`Name` as SupplierName,pn.`Overdue`,pn.`PaymentDate`,pn.`Description`,pn.`DepartmentCode`,d.`Name` as DepartmentName,pn.`MoneyUsed`,pn.`IsDrawback`,pn.`HasInvoice`,pn.`PaymentMethod`,pn.`VoucherNo`,pn.`TaxRebateRate`,pn.`Applicant` 
            From `PaymentNotes` pn LEFT JOIN Budget b on pn.BudgetID=b.ID
						LEFT JOIN supplier s on pn.SupplierID=s.ID
						LEFT JOIN department d on pn.DepartmentCode=d.`Code`";
            return con.Query<PaymentNotes>(selectSql, null, tran);
        }

        public IEnumerable<PaymentNotes> GetTotalAmountPaymentMoneyByBudgetId(int budgetID, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select pn.`ID`,pn.`CommitTime`,pn.`Money`,pn.`Approver`,pn.`ApproveTime`,pn.`BudgetID`,b.ContractNO,pn.`SupplierID`,s.`Name` as SupplierName,pn.`Overdue`,pn.`PaymentDate`,pn.`Description`,pn.`DepartmentCode`,d.`Name` as DepartmentName,pn.`MoneyUsed`,pn.`IsDrawback`,pn.`HasInvoice`,pn.`PaymentMethod`,pn.`VoucherNo`,pn.`TaxRebateRate`,pn.`Applicant` 
            From `PaymentNotes` pn LEFT JOIN Budget b on pn.BudgetID=b.ID
						LEFT JOIN supplier s on pn.SupplierID=s.ID
						LEFT JOIN department d on pn.DepartmentCode=d.`Code`
            WHERE pn.BudgetID=@BudgetID";
            return con.Query<PaymentNotes>(selectSql, new { BudgetID = budgetID }, tran);
        }

        public IEnumerable<PaymentNotes> GetAllPaymentNotesByBudgetId(int budgetId, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select pn.`ID`,pn.`CommitTime`,pn.`Money`,pn.`Approver`,pn.`ApproveTime`,pn.`BudgetID`,b.ContractNO,pn.`SupplierID`,s.`Name` as SupplierName,pn.`Overdue`,pn.`PaymentDate`,pn.`Description`,pn.`DepartmentCode`,d.`Name` as DepartmentName,pn.`MoneyUsed`,pn.`IsDrawback`,pn.`HasInvoice`,pn.`PaymentMethod`,pn.`VoucherNo`,pn.`TaxRebateRate`,pn.`Applicant` 
            From `PaymentNotes` pn LEFT JOIN Budget b on pn.BudgetID=b.ID
						LEFT JOIN supplier s on pn.SupplierID=s.ID
						LEFT JOIN department d on pn.DepartmentCode=d.`Code`";
            return con.Query<PaymentNotes>(selectSql, null, tran);
        }
        public PaymentNotes GetPaymentNoteById(int id, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = "Select * From `PaymentNotes` Where `ID` = @ID";
            return con.Query<PaymentNotes>(selectSql, null, tran).SingleOrDefault();
        }

        public int AddPaymentNote(PaymentNotes addPaymentNote, IDbConnection con, IDbTransaction tran)
        {
            string insertSql = "Insert Into `PaymentNotes` (`ID`,`CommitTime`,`Money`,`Approver`,`ApproveTime`,`BudgetID`,`SupplierID`,`Overdue`,`PaymentDate`,`Description`,`DepartmentCode`,`MoneyUsed`,`IsDrawback`,`HasInvoice`,`PaymentMethod`,`VoucherNo`,`TaxRebateRate`,`Applicant`) Values (@ID,@CommitTime,@Money,@Approver,@ApproveTime,@BudgetID,@SupplierID,@Overdue,@PaymentDate,@Description,@DepartmentCode,@MoneyUsed,@IsDrawback,@HasInvoice,@PaymentMethod,@VoucherNo,@TaxRebateRate,@Applicant)";
            int id = con.Insert(insertSql, addPaymentNote, tran);
            if (id > 0)
            {
                addPaymentNote.ID = id;
            }
            return id;
        }

        public void ModifyPaymentNote(PaymentNotes modifyPaymentNote, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = "Update `PaymentNotes` Set `CommitTime` = @CommitTime,`Money` = @Money,`Approver` = @Approver,`ApproveTime` = @ApproveTime,`BudgetID` = @BudgetID,`SupplierID` = @SupplierID,`Overdue` = @Overdue,`PaymentDate` = @PaymentDate,`Description` = @Description,`DepartmentCode` = @DepartmentCode,`MoneyUsed` = @MoneyUsed,`IsDrawback` = @IsDrawback,`HasInvoice` = @HasInvoice,`PaymentMethod` = @PaymentMethod,`VoucherNo` = @VoucherNo,`TaxRebateRate` = @TaxRebateRate,`Applicant` = @Applicant) Where `ID` = @ID";
            con.Execute(updateSql, modifyPaymentNote, tran);
        }

        public void DeletePaymentNote(int id, IDbConnection con, IDbTransaction tran)
        {
            string deleteSql = "Delete From `PaymentNotes` Where `ID` = @ID";
            con.Execute(deleteSql, new { ID = id }, tran);
        }

    }
}
