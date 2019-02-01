using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Data;
using Dapper_NET20;
using System.Linq;

namespace BudgetSystem.Dal
{
    public class DeclarationformDal
    {
        public IEnumerable<Declarationform> GetAllDeclarationform(IDbConnection con, IDbTransaction tran)
        {
            string selectSql = "Select d.*,b.ContractNO From `Declarationform` d join budget b on d.BudgetID=b.ID";
            return con.Query<Declarationform>(selectSql, null, tran);
        }

        public Declarationform GetDeclarationformByID(int id, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = "Select * From `Declarationform` Where `ID` = @ID";
            return con.Query<Declarationform>(selectSql, new { ID = id }, tran).SingleOrDefault();
        }

        public int AddDeclarationform(Declarationform declarationform, IDbConnection con, IDbTransaction tran)
        {
            string insertSql = "Insert Into `Declarationform` (`ID`,`NO`,`Currency`,`ExportAmount`,`ExportDate`,`BudgetID`,`IsReport`,`CreateUser`,`CreateDate`) Values (@ID,@NO,@Currency,@ExportAmount,@ExportDate,@BudgetID,@IsReport,@CreateUser,@CreateDate)";
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
        /// <param name="con"></param>
        /// <returns></returns>
        public bool CheckNumber(int id, string NO, IDbConnection con, IDbTransaction tran)
        {
            string sql = @"SELECT  ID FROM `Declarationform`  
                                    WHERE ID<>@ID and `NO`=@NO";
            IDbCommand command = con.CreateCommand();
            command.CommandText = sql;
            command.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("ID", id));
            command.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("NO", NO));
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

        public void ModifyDeclarationform(Declarationform declarationform, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = "Update `Declarationform` Set `NO` = @NO,`Currency` = @Currency,`ExportAmount` = @ExportAmount,`ExportDate` = @ExportDate,`BudgetID` = @BudgetID,`IsReport` = @IsReport,`CreateUser` = @CreateUser,`CreateDate` = @CreateDate Where `ID` = @ID";
            con.Execute(updateSql, declarationform, tran);
        }

        public void DeleteDeclarationformById(int Id, IDbConnection con, IDbTransaction tran)
        {
            string deleteSql = "Delete From `Declarationform` Where `ID` = @ID";
            con.Execute(deleteSql, new { ID = Id }, tran);
        }
    }
}
