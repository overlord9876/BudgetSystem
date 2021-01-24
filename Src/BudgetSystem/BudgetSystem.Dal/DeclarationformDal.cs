﻿using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Data;
using Dapper_NET20;
using System.Linq;
using BudgetSystem.Entity.QueryCondition;

namespace BudgetSystem.Dal
{
    public class DeclarationformDal
    {
        public IEnumerable<Declarationform> GetAllDeclarationform(VoucherNotesQueryCondition condition, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select d.*,b.ContractNO ,u.RealName as CreateUserRealName
                                From `Declarationform` d 
                                INNER JOIN budget b on d.BudgetID=b.ID
                                INNER JOIN `user` u on d.CreateUser=u.UserName WHERE d.ID>=0 ";
            DynamicParameters dp = new DynamicParameters();
            if (condition.ExportBeginDate != DateTime.MinValue && condition.ExportEndDate != DateTime.MinValue)
            {
                selectSql += " AND d.ExportDate BETWEEN @BeginDate AND @EndDate ";
                dp.Add("BeginDate", condition.ExportBeginDate, null, null, null);
                dp.Add("EndDate", condition.ExportEndDate, null, null, null);
            }
            if (condition.BudgetId >= 0)
            {
                selectSql += " AND d.BudgetID = @BudgetID ";
                dp.Add("BudgetID", condition.BudgetId, null, null, null);
            }
            if (!string.IsNullOrEmpty(condition.TradeMode))
            {
                selectSql += " AND d.TradeMode LIKE '%@TradeMode%' ";
                dp.Add("TradeMode", condition.TradeMode, null, null, null);
            }
            if (!string.IsNullOrEmpty(condition.FinalCountry))
            {
                selectSql += "AND FIND_IN_SET(d.FinalCountry , @FinalCountry) ";
                dp.Add("FinalCountry", condition.FinalCountry, null, null, null);
            }
            return con.Query<Declarationform>(selectSql, dp, tran);
        }

        public Declarationform GetDeclarationformByID(int id, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = "Select * From `Declarationform` Where `ID` = @ID";
            return con.Query<Declarationform>(selectSql, new { ID = id }, tran).SingleOrDefault();
        }

        public IEnumerable<Declarationform> GetDeclarationformByBudgetID(int budgetID, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select d.*,u.RealName as CreateUserRealName
                                From `Declarationform` d 
                                INNER JOIN `user` u on d.CreateUser=u.UserName Where `BudgetID` = @BudgetID";
            return con.Query<Declarationform>(selectSql, new { BudgetID = budgetID }, tran);
        }

        public int AddDeclarationform(Declarationform declarationform, IDbConnection con, IDbTransaction tran)
        {
            string insertSql = "Insert Into `Declarationform` (`ID`,`NO`,`BudgetID`,`ExportDate`,`Overseas`,`TradeMode`,`Port`,`Currency`,`PriceClause`,`Country`,`ProdNumber`,`ProdName`,`Model`,`DealCount`,`DealUnit`,`Price`,`TotalPrice`,`FinalCountry`,`DomesticSource`,`OffshoreTotalPrice`,`USDOffshoreTotalPrice`,`CNYOffshoreTotalPrice`,`CreateUser`,`CreateDate`,`UpdateUser`,`UpdateDate`) Values (@ID,@NO,@BudgetID,@ExportDate,@Overseas,@TradeMode,@Port,@Currency,@PriceClause,@Country,@ProdNumber,@ProdName,@Model,@DealCount,@DealUnit,@Price,@TotalPrice,@FinalCountry,@DomesticSource,@OffshoreTotalPrice,@USDOffshoreTotalPrice,@CNYOffshoreTotalPrice,@CreateUser,@CreateDate,@UpdateUser,@UpdateDate)";
            int id = con.Insert(insertSql, declarationform, tran);
            if (id > 0)
            {
                declarationform.ID = id;
            }
            return id;
        }

        /// <summary>
        /// 验证报关单号是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <param name="NO"></param>
        /// <param name="dealCount"></param>
        /// <param name="totalPrice"></param>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public bool CheckNumber(int id, string NO, double dealCount, decimal totalPrice, IDbConnection con, IDbTransaction tran)
        {
            string sql = @"SELECT  ID FROM `Declarationform`  WHERE ID<>@ID and `NO`=@NO and dealCount=@dealCount AND totalPrice=@totalPrice";
            using (IDbCommand command = con.CreateCommand())
            {
                command.CommandText = sql;
                command.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("ID", id));
                command.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("NO", NO));
                command.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("dealCount", dealCount));
                command.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("totalPrice", totalPrice));
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

        public void ModifyDeclarationform(Declarationform declarationform, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = "Update `Declarationform` Set `NO` = @NO,`BudgetID` = @BudgetID,`ExportDate` = @ExportDate,`Overseas` = @Overseas,`TradeMode` = @TradeMode,`Port` = @Port,`Currency` = @Currency,`PriceClause` = @PriceClause,`Country` = @Country,`ProdNumber` = @ProdNumber,`ProdName` = @ProdName,`Model` = @Model,`DealCount` = @DealCount,`DealUnit` = @DealUnit,`Price` = @Price,`TotalPrice` = @TotalPrice,`FinalCountry` = @FinalCountry,`DomesticSource` = @DomesticSource,`OffshoreTotalPrice` = @OffshoreTotalPrice,`USDOffshoreTotalPrice` = @USDOffshoreTotalPrice,`CNYOffshoreTotalPrice` = @CNYOffshoreTotalPrice,`CreateUser` = @CreateUser,`CreateDate` = @CreateDate,`UpdateUser` = @UpdateUser,`UpdateDate` = @UpdateDate) Where `ID` = @ID";
            con.Execute(updateSql, declarationform, tran);
        }

        public void DeleteDeclarationformById(int Id, IDbConnection con, IDbTransaction tran)
        {
            string deleteSql = "Delete From `Declarationform` Where `ID` = @ID";
            con.Execute(deleteSql, new { ID = Id }, tran);
        }
    }
}
