using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Linq;

namespace BudgetSystem.Bll
{
    public class DeclarationformManager : BaseManager
    {
        Dal.DeclarationformDal dal = new Dal.DeclarationformDal();
        Dal.BudgetDal budgetDal = new Dal.BudgetDal();


        public List<Declarationform> GetAllDeclarationform()
        {
            var lst = this.Query<Declarationform>((con) =>
            {

                var uList = dal.GetAllDeclarationform(con, null);
                return uList;
            });
            return lst.ToList();
        }

        public List<Declarationform> GetDeclarationformByBudgetID(int budgetID)
        {
            var lst = this.Query<Declarationform>((con) =>
            {
                var uList = dal.GetDeclarationformByBudgetID(budgetID, con, null);
                return uList;
            });
            return lst.ToList();
        }

        public Declarationform GetDeclarationformByID(int id)
        {
            var lst = this.Query<Declarationform>((con) =>
            {

                var uList = dal.GetDeclarationformByID(id, con, null);
                return uList;
            });
            return lst;
        }

        public int AddDeclarationform(Declarationform declarationform)
        {
            return this.ExecuteWithTransaction<int>((con, tran) =>
            {
                int id = dal.AddDeclarationform(declarationform, con, tran);
                return id;
            });
        }

        public bool CheckNumber(string NO)
        {
            return this.ExecuteWithoutTransaction<bool>((con) =>
               {
                   return dal.CheckNumber(0, NO, con, null);
               });
        }

        public int CheckContractNO(string contractNO)
        {
            return this.ExecuteWithoutTransaction<int>((con) =>
            {
                return budgetDal.CheckContractNO(contractNO, con);
            });
        }

        /// <summary>
        /// 验证导入数据是否合法
        /// </summary>
        /// <param name="list">待导入数据</param>
        /// <returns></returns>
        public bool CheckImportData(List<Declarationform> list)
        {
            bool result = true;
            this.ExecuteWithoutTransaction((con) =>
            {
                foreach (Declarationform df in list)
                {
                    if (string.IsNullOrEmpty(df.NO.Trim()))
                    {
                        df.Message += "报关单号不能为空;";
                        result = false;
                    }
                    else if (list.Count(i => i.NO == df.NO) > 1)
                    {
                        df.Message += "导入报关单号存在重复;";
                        result = false;
                    }
                    else if (dal.CheckNumber(0, df.NO.Trim(), con, null))
                    {
                        df.Message += "报关单号已导入，不允许重复导入;";
                        result = false;
                    }

                    if (string.IsNullOrEmpty(df.ContractNO.Trim()))
                    {
                        df.Message += "合同号不能为空;";
                        result = false;
                    }
                    else
                    {
                        int budgetId = budgetDal.CheckContractNO(df.ContractNO.Trim(), con);
                        if (budgetId < 0)
                        {
                            df.Message += "合同号不存在;";
                            result = false;
                        }
                        else
                        {
                            df.BudgetID = budgetId;
                        }
                    }
                    if (df.ExportAmount <= 0)
                    {
                        df.Message += "出口金额应大于0;";
                        result = false;
                    }
                    if (string.IsNullOrEmpty(df.Currency.Trim()))
                    {
                        df.Message += "报关币种不能为空";
                        result = false;
                    }
                    if (df.ExchangeRate <= 0)
                    {
                        df.Message += "汇率应大于0;";
                        result = false;
                    }
                }

            });
            return result;
        }

        public int ImportDeclarationform(List<Declarationform> declarationformList)
        {
            return this.ExecuteWithTransaction<int>((con, tran) =>
            {
                int id = 0;
                foreach (Declarationform df in declarationformList)
                {
                    id = dal.AddDeclarationform(df, con, tran);
                }
                return id;
            });
        }

        public void AddDeclarationformList(List<Declarationform> declarationformList)
        {
            this.ExecuteWithTransaction((con, tran) =>
            {
                foreach (var addItem in declarationformList)
                {
                    addItem.ID = dal.AddDeclarationform(addItem, con, tran);
                }
            });
        }

        public void ModifyDeclarationform(Declarationform declarationform)
        {
            this.ExecuteWithTransaction((con, tran) =>
            {
                dal.ModifyDeclarationform(declarationform, con, tran);
            });
        }

        public void DeleteDeclarationformById(int Id)
        {
            this.ExecuteWithTransaction((con, tran) =>
            {
                dal.DeleteDeclarationformById(Id, con, tran);
            });
        }
    }
}
