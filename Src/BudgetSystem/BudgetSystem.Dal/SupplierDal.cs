using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Data;
using Dapper_NET20;
using System.Linq;

namespace BudgetSystem.Dal
{
    public  class SupplierDal
    {
        public Supplier GetSupplier(int id, IDbConnection con, IDbTransaction tran=null)
        { 
            string selectSql = @"SELECT s.*,u.RealName AS CreateUserName,d.`Name` AS DepartmentName FROM `Supplier` s
                                    LEFT JOIN `User` u ON s.CreateUser=u.UserName
                                    LEFT JOIN `Department` d ON s.DepartmentCode=d.`Code`  
                                    WHERE s.`ID` = @ID";
            return con.Query<Supplier>(selectSql, new { ID = id }, tran).SingleOrDefault();
        }
        public IEnumerable<Supplier> GetAllSupplier(IDbConnection con, IDbTransaction tran=null)
        {
            string selectSql = @"SELECT s.*,u.RealName AS CreateUserName,d.`Name` AS DepartmentName FROM `Supplier` s
                                    LEFT JOIN `User` u ON s.CreateUser=u.UserName
                                    LEFT JOIN `Department` d ON s.DepartmentCode=d.`Code`  ";
            return con.Query<Supplier>(selectSql, null, tran);
        }
        public int AddSupplier(Supplier supplier, IDbConnection con, IDbTransaction tran=null)
        {
            string insertSql = "Insert Into `Supplier` (`Name`,`BankAccountName`,`BankNO`,`BankName`,`SupplierType`,`CreateDate`,`Nature`,`RegisterCapital`,`Address`,`Tell`,`FaxNumber`,`Contacts`,`DepartmentCode`,`PostalCode`,`Legal`,`CreateUser`,`Description`) Values (@Name,@BankAccountName,@BankNO,@BankName,@SupplierType,now(),@Nature,@RegisterCapital,@Address,@Tell,@FaxNumber,@Contacts,@DepartmentCode,@PostalCode,@Legal,@CreateUser,@Description)";
            return con.Insert(insertSql, supplier, tran);
        }
        public void ModifySupplier(Supplier supplier, IDbConnection con, IDbTransaction tran=null)
        {
            string updateSql = "Update `Supplier` Set `Name` = @Name,`BankAccountName` = @BankAccountName,`BankNO` = @BankNO,`BankName` = @BankName,`SupplierType` = @SupplierType,`Nature` = @Nature,`RegisterCapital` = @RegisterCapital,`Address` = @Address,`Tell` = @Tell,`FaxNumber` = @FaxNumber,`Contacts` = @Contacts,`DepartmentCode` = @DepartmentCode,`PostalCode` = @PostalCode,`Legal` = @Legal ,`CreateUser`=@CreateUser,`Description`=@Description Where `ID` = @ID";
            con.Execute(updateSql, supplier, tran);
        }
        public void DeleteSupplier(int id, IDbConnection con, IDbTransaction tran=null)
        {
            string deleteSql = "Delete From `Supplier` Where `ID` = @ID";
            con.Execute(deleteSql, new { ID = id },tran);
        }
    }
}
