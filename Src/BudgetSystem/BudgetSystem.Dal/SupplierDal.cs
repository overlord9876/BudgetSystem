using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Data;
using Dapper_NET20;
using System.Linq;

namespace BudgetSystem.Dal
{
    public class SupplierDal
    {
        public Supplier GetSupplier(int id, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = @"SELECT s.*,u.RealName AS CreateUserName,d.`Name` AS DepartmentName ,IFNULL((f.ApproveResult+f.IsClosed),-1) FlowState
                                 FROM `Supplier` s
                                 LEFT JOIN `User` u ON s.CreateUser=u.UserName
                                 LEFT JOIN `Department` d ON s.DepartmentCode=d.`Code`  
																 LEFT JOIN `FlowInstance` f ON f.DateItemID=s.id AND f.DateItemType=@DateItemType AND f.IsRecent=1
                                 WHERE s.`ID` = @ID";
            return con.Query<Supplier>(selectSql, new { DateItemType = EnumFlowDataType.供应商.ToString(), ID = id }, tran).SingleOrDefault();
        }
        public IEnumerable<Supplier> GetAllSupplier(IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = @"SELECT s.*,u.RealName AS CreateUserName,d.`Name` AS DepartmentName ,IFNULL((f.ApproveResult+f.IsClosed),-1) FlowState
                                 FROM `Supplier` s
                                 LEFT JOIN `User` u ON s.CreateUser=u.UserName
                                 LEFT JOIN `Department` d ON s.DepartmentCode=d.`Code`
																 LEFT JOIN `FlowInstance` f ON f.DateItemID=s.id AND f.DateItemType=@DateItemType AND f.IsRecent=1";
            return con.Query<Supplier>(selectSql, new { DateItemType = EnumFlowDataType.供应商.ToString() }, tran);
        }
        public int AddSupplier(Supplier supplier, IDbConnection con, IDbTransaction tran = null)
        {
            string insertSql = @"Insert Into `Supplier` (`Name`,`BankNO`,`BankName`,`SupplierType`,`CreateDate`,
                                                         `Nature`,`RegisterCapital`,`Address`,`Tell`,`FaxNumber`,`Contacts`,
                                                         `DepartmentCode`,`PostalCode`,`Legal`,`CreateUser`,`Description`,
                                                         `TaxpayerID`,`Discredited`,`ExistsAgentAgreement`) 
                                               Values (@Name,@BankNO,@BankName,@SupplierType,now(),
                                                       @Nature,@RegisterCapital,@Address,@Tell,@FaxNumber,@Contacts,
                                                       @DepartmentCode,@PostalCode,@Legal,@CreateUser,@Description,
                                                       @TaxpayerID,@Discredited,@ExistsAgentAgreement)";
            int id = con.Insert(insertSql, supplier, tran);
            if (id > 0)
            {
                supplier.ID = id;
            }
            return id;
        }
        public void ModifySupplier(Supplier supplier, IDbConnection con, IDbTransaction tran = null)
        {
            string updateSql = @"Update `Supplier` 
                                Set `Name` = @Name,`BankNO` = @BankNO,`BankName` = @BankName,`SupplierType` = @SupplierType,
                                    `Nature` = @Nature,`RegisterCapital` = @RegisterCapital,`Address` = @Address,`Tell` = @Tell,
                                    `FaxNumber` = @FaxNumber,`Contacts` = @Contacts,`DepartmentCode` = @DepartmentCode,
                                    `PostalCode` = @PostalCode,`Legal` = @Legal ,`Description`=@Description ,
                                    `TaxpayerID`=@TaxpayerID,`Discredited`=@Discredited,`ExistsAgentAgreement`=@ExistsAgentAgreement 
                                    Where `ID` = @ID";
            con.Execute(updateSql, supplier, tran);
        }
        public void DeleteSupplier(int id, IDbConnection con, IDbTransaction tran = null)
        {
            string deleteSql = "Delete From `Supplier` Where `ID` = @ID";
            con.Execute(deleteSql, new { ID = id }, tran);
        }
    }
}
