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
            string selectSql = "Select * From `Declarationform`";
            return con.Query<Declarationform>(selectSql, null, tran);
        }

        public Declarationform GetDeclarationformByID(int id, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = "Select * From `Declarationform` Where `ID` = @ID";
            return con.Query<Declarationform>(selectSql, new { ID = id }, tran).SingleOrDefault();
        }

        public int AddDeclarationform(Declarationform declarationform, IDbConnection con, IDbTransaction tran)
        {
            string insertSql = "Insert Into `Declarationform` (`ID`,`NO`,`Currency`,`ExportAmount`,`ExportDate`,`ContractNO`,`IsReport`,`CreateUser`,`CreateDate`) Values (@ID,@NO,@Currency,@ExportAmount,@ExportDate,@ContractNO,@IsReport,@CreateUser,@CreateDate)";
            int id = con.Insert(insertSql, declarationform, tran);
            if (id > 0)
            {
                declarationform.ID = id;
            }
            return id;
        }

        public void ModifyDeclarationform(Declarationform declarationform, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = "Update `Declarationform` Set `NO` = @NO,`Currency` = @Currency,`ExportAmount` = @ExportAmount,`ExportDate` = @ExportDate,`ContractNO` = @ContractNO,`IsReport` = @IsReport,`CreateUser` = @CreateUser,`CreateDate` = @CreateDate Where `ID` = @ID";
            con.Execute(updateSql, declarationform, tran);
        }

        public void DeleteDeclarationformById(int Id, IDbConnection con, IDbTransaction tran)
        {
            string deleteSql = "Delete From `Declarationform` Where `ID` = @ID";
            con.Execute(deleteSql, new { ID = Id }, tran);
        }
    }
}
