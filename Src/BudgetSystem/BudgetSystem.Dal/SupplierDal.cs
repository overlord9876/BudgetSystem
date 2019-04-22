using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using BudgetSystem.Entity.QueryCondition;
using System.Data;
using Dapper_NET20;
using System.Linq;

namespace BudgetSystem.Dal
{
    public class SupplierDal
    {
        public Supplier GetSupplier(int id, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = @"SELECT s.*,u.RealName AS CreateUserName,d.`Code`as DepartmentCode,d.`Name` AS DepartmentName ,u2.RealName AS UpdateUserName, 
                                        IFNULL((f.ApproveResult+f.IsClosed),-1) FlowState,f.ID AS FlowInstanceID,f.FlowName 
                                 FROM `Supplier` s
                                 LEFT JOIN `User` u ON s.CreateUser=u.UserName
                                 LEFT JOIN `User` u2 ON s.UpdateUser=u2.UserName
                                 LEFT JOIN `Department` d ON s.DeptID=d.`ID`  
								 LEFT JOIN `FlowInstance` f ON f.DateItemID=s.id AND f.DateItemType=@DateItemType AND f.IsRecent=1
                                 WHERE s.`ID` = @ID ";
            return con.Query<Supplier>(selectSql, new { DateItemType = EnumFlowDataType.供应商.ToString(), ID = id }, tran).SingleOrDefault();
        }

        public IEnumerable<Supplier> GetAllSupplier(IDbConnection con, IDbTransaction tran = null, SupplierQueryCondition condition = null)
        {
            string selectSql = @"SELECT s.*,u.RealName AS CreateUserName,d.`Code`as DepartmentCode,d.`Name` AS DepartmentName ,u2.RealName AS UpdateUserName, 
                                        IFNULL((f.ApproveResult+f.IsClosed),-1) FlowState,f.ID AS FlowInstanceID,f.FlowName 
                                 FROM `Supplier` s
                                 LEFT JOIN `User` u ON s.CreateUser=u.UserName
                                 LEFT JOIN `User` u2 ON s.UpdateUser=u2.UserName
                                 LEFT JOIN `Department` d ON s.DeptID=d.`ID`  
								 LEFT JOIN `FlowInstance` f ON f.DateItemID=s.id AND f.DateItemType=@DateItemType AND f.IsRecent=1 ";
            DynamicParameters dp = new DynamicParameters();
            dp.Add("DateItemType", EnumFlowDataType.供应商.ToString(), null, null, null);
            if (condition != null)
            {
                List<string> strConditionList = new List<string>();
                if (!string.IsNullOrEmpty(condition.CreateUser))
                {
                    strConditionList.Add(" s.CreateUser=@CreateUser");
                    dp.Add("CreateUser", condition.CreateUser, null, null, null);
                }
                if (!string.IsNullOrEmpty(condition.Department))
                {
                    strConditionList.Add(" d.Code=@Department");
                    dp.Add("Department", condition.Department, null, null, null);
                }
                if (condition.SupplierType >= 0)
                {
                    strConditionList.Add("s.SupplierType=@SupplierType");
                    dp.Add("SupplierType", condition.SupplierType, null, null, null);
                }
                if (!string.IsNullOrEmpty(condition.SupplierName))
                {
                    strConditionList.Add("s.Name like @Name");
                    dp.Add("Name", string.Format("%{0}%", condition.SupplierName), null, null, null);
                }

                if (condition.DeptID > 0)
                {
                    strConditionList.Add(" s.DeptID=@TheDeptID ");
                    dp.Add("TheDeptID", condition.DeptID, null, null, null);
                }

                if (strConditionList.Count > 0)
                {
                    selectSql += string.Format(" where {0}", string.Join(" and ", strConditionList.ToArray()));
                }
            }

            return con.Query<Supplier>(selectSql, dp, tran);
        }

        public IEnumerable<Supplier> GetSupplierListByBudgetId(int budgetId, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = @"SELECT s.*,u.RealName AS CreateUserName,d.`Code`as DepartmentCode,d.`Name` AS DepartmentName,u2.RealName AS UpdateUserName,
                                        IFNULL((f.ApproveResult+f.IsClosed),-1) FlowState,f.ID AS FlowInstanceID,f.FlowName 
                                 FROM `Supplier` s
                                 INNER JOIN BudgetSuppliers bs on s.ID=bs.Sup_ID and (bs.ID=@BudgetID or  SupplierType=1)
                                 LEFT JOIN `User` u ON s.CreateUser=u.UserName
                                 LEFT JOIN `User` u2 ON s.UpdateUser=u2.UserName
                                 LEFT JOIN `Department` d ON s.DeptID=d.`ID` 
								 LEFT JOIN `FlowInstance` f ON f.DateItemID=s.id AND f.DateItemType=@DateItemType AND f.IsRecent=1";
            return con.Query<Supplier>(selectSql, new { DateItemType = EnumFlowDataType.供应商.ToString(), BudgetID = budgetId }, tran);
        }

        public int AddSupplier(Supplier supplier, IDbConnection con, IDbTransaction tran = null)
        {
            string insertSql = @"Insert Into `Supplier` (`Name`,`BankInfoDetail`,`SupplierType`,`CreateDate`,
                                                         `Nature`,`RegisterCapital`,`Address`,`Tell`,`FaxNumber`,`Contacts`,
                                                         `DeptID`,`PostalCode`,`Legal`,`CreateUser`,`Description`,`UpdateDate`,`UpdateUser`,
                                                         `TaxpayerID`,`Discredited`,`ExistsAgentAgreement`,`RegistrationDate`,`BusinessEffectiveDate`,`AgreementDate`) 
                                               Values (@Name,@BankInfoDetail,@SupplierType,now(),
                                                       @Nature,@RegisterCapital,@Address,@Tell,@FaxNumber,@Contacts,
                                                       @DeptID,@PostalCode,@Legal,@CreateUser,@Description,now(),@UpdateUser,
                                                       @TaxpayerID,@Discredited,@ExistsAgentAgreement,@RegistrationDate,@BusinessEffectiveDate,@AgreementDate)";
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
                                 Set `Name` = @Name,`BankInfoDetail` = @BankInfoDetail,`SupplierType` = @SupplierType,
                                    `Nature` = @Nature,`RegisterCapital` = @RegisterCapital,`Address` = @Address,`Tell` = @Tell,
                                    `FaxNumber` = @FaxNumber,`Contacts` = @Contacts,`DeptID` = @DeptID,
                                    `PostalCode` = @PostalCode,`Legal` = @Legal ,`Description`=@Description ,
                                    `TaxpayerID`=@TaxpayerID,`Discredited`=@Discredited,`ExistsAgentAgreement`=@ExistsAgentAgreement,
                                    `RegistrationDate`=@RegistrationDate,`BusinessEffectiveDate`=@BusinessEffectiveDate,`AgreementDate`=@AgreementDate,
                                    `UpdateDate`=now(),`UpdateUser`=@UpdateUser
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
