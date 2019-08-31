using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using BudgetSystem.Entity.QueryCondition;
using System.Data;
using Dapper_NET20;
using System.Linq;
using MySql.Data.MySqlClient;

namespace BudgetSystem.Dal
{
    public class SupplierDal
    {
        public Supplier GetSupplier(int id, IDbConnection con, IDbTransaction tran = null)
        {
            DateTime datetimeNow = new CommonDal().GetDateTimeNow(con);

            string selectSql = @"SELECT s.*,u.RealName AS CreateUserName,u2.RealName AS UpdateUserName, 
                                        IFNULL((f.ApproveResult+f.IsClosed),-1) FlowState,f.ID AS FlowInstanceID,f.FlowName 
                                 FROM `Supplier` s
                                 LEFT JOIN `User` u ON s.CreateUser=u.UserName
                                 LEFT JOIN `User` u2 ON s.UpdateUser=u2.UserName
								 LEFT JOIN `FlowInstance` f ON f.DateItemID=s.id AND f.DateItemType=@DateItemType AND f.IsRecent=1
                                 WHERE s.`ID` = @ID ";
            var s = con.Query<Supplier>(selectSql, new { DateItemType = EnumFlowDataType.供应商.ToString(), ID = id }, tran).SingleOrDefault();
            if (s != null)
            {
                s.DateTimeNow = datetimeNow;
                string departmentSelectSql = @"SELECT d.* from SupplierRelationDepartment srd JOIN department d on srd.Dep_ID=d.ID where srd.ID=@ID";
                var deptList = con.Query<Department>(departmentSelectSql, new { ID = id }, tran).ToList();
                if (deptList != null)
                {
                    s.Departments.AddRange(deptList);
                }
            }
            return s;
        }

        public IEnumerable<Supplier> GetAllSupplier(IDbConnection con, IDbTransaction tran = null, SupplierQueryCondition condition = null)
        {
            DateTime datetimeNow = new CommonDal().GetDateTimeNow(con);

            string selectSql = @"SELECT s.*,u.RealName AS CreateUserName,u2.RealName AS UpdateUserName, 
                                        IFNULL((f.ApproveResult+f.IsClosed),-1) FlowState,f.ID AS FlowInstanceID,f.FlowName 
                                 FROM `Supplier` s
                                 LEFT JOIN `User` u ON s.CreateUser=u.UserName
                                 LEFT JOIN `User` u2 ON s.UpdateUser=u2.UserName                                 
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
                    strConditionList.Add(" s.ID in (SELECT ID from SupplierRelationDepartment where Dep_ID=@TheDeptID)");
                    dp.Add("TheDeptID", condition.DeptID, null, null, null);
                }

                if (strConditionList.Count > 0)
                {
                    selectSql += string.Format(" where {0}", string.Join(" and ", strConditionList.ToArray()));
                }
            }

            var result = con.Query<Supplier>(selectSql, dp, tran);
            foreach (var supplier in result)
            {
                supplier.DateTimeNow = datetimeNow;
            }
            return result;
        }

        public IEnumerable<Supplier> GetSupplierListByBudgetId(int budgetId, IDbConnection con, IDbTransaction tran = null)
        {
            DateTime datetimeNow = new CommonDal().GetDateTimeNow(con);
            string selectSql = @"SELECT s.*,u.RealName AS CreateUserName,u2.RealName AS UpdateUserName,
                                        IFNULL((f.ApproveResult+f.IsClosed),-1) FlowState,f.ID AS FlowInstanceID,f.FlowName 
                                 FROM `Supplier` s
                                 INNER JOIN BudgetSuppliers bs on s.ID=bs.Sup_ID and (bs.ID=@BudgetID or  SupplierType=1)
                                 LEFT JOIN `User` u ON s.CreateUser=u.UserName
                                 LEFT JOIN `User` u2 ON s.UpdateUser=u2.UserName
								 LEFT JOIN `FlowInstance` f ON f.DateItemID=s.id AND f.DateItemType=@DateItemType AND f.IsRecent=1";
            var result = con.Query<Supplier>(selectSql, new { DateItemType = EnumFlowDataType.供应商.ToString(), BudgetID = budgetId }, tran);
            foreach (var supplier in result)
            {
                supplier.DateTimeNow = datetimeNow;
            }
            return result;
        }

        public bool IsUsed(Supplier suppplier, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = @"SELECT SupplierID from PaymentNotes where SupplierID=@ID;";
            IDbCommand command = con.CreateCommand();
            command.CommandText = selectSql;
            command.Parameters.Add(new MySqlParameter("ID", suppplier.ID));
            object obj = command.ExecuteScalar();
            if (obj != null)
            {
                return true;
            }

            selectSql = @"SELECT Sup_ID from BudgetSuppliers WHERE Sup_ID=@ID;";
            command = con.CreateCommand();
            command.CommandText = selectSql;
            command.Parameters.Add(new MySqlParameter("ID", suppplier.ID));
            obj = command.ExecuteScalar();
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteSupplier(Supplier supplier, IDbConnection con, IDbTransaction tran = null)
        {
            string salesmanDeleteSql = "Delete From `supplierrelationdepartment` Where `ID` = @ID";
            con.Execute(salesmanDeleteSql, new { ID = supplier.ID }, tran);

            string updateSql = @"delete from `Supplier` Where `ID` = @ID";
            con.Execute(updateSql, new { ID = supplier.ID }, tran);
        }

        public int AddSupplier(Supplier supplier, IDbConnection con, IDbTransaction tran = null)
        {
            string insertSql = @"Insert Into `Supplier` (`Name`,`BankInfoDetail`,`SupplierType`,`CreateDate`,
                                                         `Nature`,`RegisterCapital`,`Address`,`Tell`,`FaxNumber`,`Contacts`,
                                                         `PostalCode`,`Legal`,`CreateUser`,`Description`,`UpdateDate`,`UpdateUser`,
                                                         `TaxpayerID`,`Discredited`,`AgentType`,`RegistrationDate`,`BusinessEffectiveDate`,
                                                         `AgreementDate`,`ReviewDate`,`ExistsLicenseCopy`,`FirstReviewContents`,`ReviewContents`) 
                                               Values (@Name,@BankInfoDetail,@SupplierType,now(),
                                                       @Nature,@RegisterCapital,@Address,@Tell,@FaxNumber,@Contacts,
                                                       @PostalCode,@Legal,@CreateUser,@Description,now(),@UpdateUser,
                                                       @TaxpayerID,@Discredited,@AgentType,@RegistrationDate,@BusinessEffectiveDate,
                                                       @AgreementDate,@ReviewDate,@ExistsLicenseCopy,@FirstReviewContents,@ReviewContents)";
            int id = con.Insert(insertSql, supplier, tran);
            if (id > 0)
            {
                supplier.ID = id;
                AddSupplierDepartments(supplier, con, tran);
            }
            return id;
        }

        public void ModifySupplier(Supplier supplier, IDbConnection con, IDbTransaction tran = null)
        {
            string updateSql = @"Update `Supplier` 
                                 Set `Name` = @Name,`BankInfoDetail` = @BankInfoDetail,`SupplierType` = @SupplierType,
                                    `Nature` = @Nature,`RegisterCapital` = @RegisterCapital,`Address` = @Address,`Tell` = @Tell,
                                    `FaxNumber` = @FaxNumber,`Contacts` = @Contacts,
                                    `PostalCode` = @PostalCode,`Legal` = @Legal ,`Description`=@Description ,
                                    `TaxpayerID`=@TaxpayerID,`Discredited`=@Discredited,`AgentType`=@AgentType,
                                    `RegistrationDate`=@RegistrationDate,`BusinessEffectiveDate`=@BusinessEffectiveDate,`AgreementDate`=@AgreementDate,
                                    `UpdateDate`=now(),`UpdateUser`=@UpdateUser,`ReviewDate`=@ReviewDate,
                                    `ExistsLicenseCopy`=@ExistsLicenseCopy,`FirstReviewContents`=@FirstReviewContents,`ReviewContents`=@ReviewContents
                                    Where `ID` = @ID";
            con.Execute(updateSql, supplier, tran);


            string deleteSql = @"Delete From `SupplierRelationDepartment` Where `ID` = @ID;";
            con.Execute(deleteSql, new { ID = supplier.ID }, tran);

            AddSupplierDepartments(supplier, con, tran);
        }

        public void ModifySupplierFirstReviewContents(int id, string firstReviewContents, IDbConnection con, IDbTransaction tran = null)
        {
            string updateSql = @"Update `Supplier` 
                                 Set `FirstReviewContents`=@FirstReviewContents
                                    Where `ID` = @ID";
            con.Execute(updateSql, new { ID = id, FirstReviewContents = firstReviewContents }, tran);
        }

        public void ModifySupplierReviewContents(int id, string reviewContents, IDbConnection con, IDbTransaction tran = null)
        {
            string updateSql = @"Update `Supplier` 
                                 Set `ReviewContents`=@ReviewContents
                                    Where `ID` = @ID";
            con.Execute(updateSql, new { ID = id, ReviewContents = reviewContents }, tran);
        }

        public void DeleteSupplier(int id, IDbConnection con, IDbTransaction tran = null)
        {

            string deleteSupplierRelationDepartmentSql = "Delete From `SupplierRelationDepartment` Where `ID` = @ID";
            con.Execute(deleteSupplierRelationDepartmentSql, new { ID = id }, tran);

            string deleteSql = "Delete From `Supplier` Where `ID` = @ID";
            con.Execute(deleteSql, new { ID = id }, tran);
        }

        /// <summary>
        /// 验证名称是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contractNo"></param>
        /// <param name="con"></param>
        /// <returns></returns>
        public bool CheckName(string name, int id, IDbConnection con)
        {
            string selectSql = @"SELECT  s.id FROM `Supplier` s 
                                    WHERE ID<>@ID and `Name`=@Name";
            IDbCommand command = con.CreateCommand();
            command.CommandText = selectSql;
            command.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("ID", id));
            command.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("Name", name));
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


        private void AddSupplierDepartments(Supplier supplier, IDbConnection con, IDbTransaction tran)
        {
            if (supplier.Departments != null && supplier.Departments.Any())
            {
                string supplierRelationDepartmentInserSql = "INSERT INTO SupplierRelationDepartment(ID,Dep_ID)VALUES(@ID,@DeptID); ";
                List<object> supplierRelationDepartments = new List<object>();
                supplier.Departments.ForEach(s => supplierRelationDepartments.Add(new { ID = supplier.ID, DeptID = s.ID }));
                con.Execute(supplierRelationDepartmentInserSql, supplierRelationDepartments, tran);
            }
        }

    }
}
