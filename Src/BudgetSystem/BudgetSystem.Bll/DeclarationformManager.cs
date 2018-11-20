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


        public List<Declarationform> GetAllDeclarationform()
        {
            var lst = this.Query<Declarationform>((con) =>
            {

                var uList = dal.GetAllDeclarationform(con, null);
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
