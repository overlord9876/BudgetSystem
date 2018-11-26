using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Linq;

namespace BudgetSystem.Bll
{
    public class SupplierManager : BaseManager
    {

        Bll.FlowManager fm = new FlowManager();
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

        public List<Supplier> GetSupplierListByBudgetId(int budgetId)
        {
            var lst = this.Query<Supplier>((con) =>
            {
                var uList = dal.GetSupplierListByBudgetId(budgetId, con);
                return uList;

            });
            return lst.ToList();
        }

        public Supplier GetSupplier(int id)
        {
            var supplier = this.Query<Supplier>((con) =>
            {
                var uList = dal.GetSupplier(id, con);
                return uList;
            });
            return supplier;
        }

        public int AddSupplier(Supplier supplier)
        {
            return this.ExecuteWithTransaction<int>((con, tran) =>
            {
                int id = dal.AddSupplier(supplier, con, tran);
                return id;
            });
        }

        public void ModifySupplier(Supplier supplier)
        {
            this.ExecuteWithTransaction((con, tran) =>
            {
                dal.ModifySupplier(supplier, con, tran);
            });
        }

        /// <summary>
        /// 启动审批流程
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentUser"></param>
        /// <returns>返回string.Empty为成功，否则为失败原因</returns>
        public string StartFlow(int id, string currentUser)
        {
            Supplier supplier = this.GetSupplier(id);
            if (supplier == null)
            {
                return "数据不存在";
            }
            else if (supplier.EnumFlowState == EnumDataFlowState.审批中)
            {
                return string.Format("{0}中的数据不能重新启动流程", EnumDataFlowState.审批中);
            }
            FlowRunState state = fm.StartFlow(EnumFlowNames.供应商审批流程.ToString(), id, supplier.Name, EnumFlowDataType.供应商.ToString(), currentUser);
            if (state != FlowRunState.启动流程成功)
            {
                return state.ToString();
            }
            return string.Empty;
        }

        public void DeleteSupplier(int id)
        {
            this.ExecuteWithoutTransaction((con) =>
            {
                dal.DeleteSupplier(id, con);
            });
        }


    }
}
