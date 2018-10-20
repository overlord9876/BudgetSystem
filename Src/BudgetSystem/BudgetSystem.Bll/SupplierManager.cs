using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Linq;

namespace BudgetSystem.Bll
{
    public class SupplierManager : BaseManager
    {

        Dal.SupplierDal dal = new Dal.SupplierDal();

        public List<Supplier> GetAllSupplier()
        {
            var lst = this.Query<Supplier>((con) =>
            { 
                var uList = dal.GetAllSupplier(con);
                return uList;

            });
            return lst.ToList();
        }
        public Supplier GetSupplier(int id)
        {
            var supplier = this.Query<Supplier>((con) =>
            { 
                var uList = dal.GetSupplier(id,con); 
                return uList; 
            });
            return supplier;
        }
        
        public int AddSupplier(Supplier supplier)
        {
            return this.ExecuteWithTransaction<int>((con, tran) =>
            { 
                int id= dal.AddSupplier(supplier,con,tran);
                return id;
            });
        }
        public void ModifySupplier(Supplier supplier)
        {
            this.ExecuteWithoutTransaction((con) =>
            { 
                dal.ModifySupplier(supplier,con);
            });
        }
        public void DeleteSupplier(int id)
        {
            this.ExecuteWithoutTransaction((con) =>
            {
                dal.DeleteSupplier(id,con);
            });
        }
         
          
    }
}
