using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Linq;

namespace BudgetSystem.Bll
{
    public class ActualReceiptsManager : BaseManager
    {
        Dal.ActualReceiptsDal dal = new Dal.ActualReceiptsDal();

        public List<ActualReceipts> GetAllActualReceipts()
        {
            var lst = this.Query<ActualReceipts>((con) =>
            {

                var uList = dal.GetAllActualReceipts(con, null);
                return uList;
            });
            return lst.ToList();
        }

        public ActualReceipts GetActualReceiptById(int id)
        {
            var lst = this.Query<ActualReceipts>((con) =>
            {
                var uList = dal.GetActualReceiptById(id, con, null);
                return uList;
            });
            return lst;
        }

        /// <summary>
        /// 创建收款记录
        /// </summary>
        /// <param name="addReceipts"></param>
        public int CreateActualReceipts(ActualReceipts addReceipts)
        {
            return this.ExecuteWithTransaction<int>((con, tran) =>
                    {
                        int id = dal.AddActualReceipts(addReceipts, con, tran);
                        foreach (User u in addReceipts.Sales)
                        {
                            dal.AddReceiptNotice(u.UserName, id, con, tran);
                        }
                        return id;
                    });
        }



        /// <summary>
        /// 创建收款记录
        /// </summary>
        /// <param name="addReceipts"></param>
        public void ModifyActualReceipts(ActualReceipts modifyReceipts)
        {
            this.ExecuteWithTransaction((con, tran) =>
            {
                dal.ModifyActualReceipts(modifyReceipts, con, tran);
            });
        }

        /// <summary>
        /// 关联合同费用
        /// </summary>
        /// <param name="relationReceipt"></param>
        public void RelationActualReceiptToBudget(ActualReceipts relationReceipt, List<ActualReceipts> splitReceiptList)
        {
            this.ExecuteWithTransaction((con, tran) =>
            {
                foreach (ActualReceipts newReceipt in splitReceiptList)
                {
                    dal.AddActualReceipts(newReceipt, con, tran);
                }
                dal.ModifyActualReceipts(relationReceipt, con, tran);
            });
        }

        /// <summary>
        /// 拆分合同费用
        /// </summary>
        /// <param name="modifyReceipts"></param>
        /// <param name="addReceipts"></param>
        public void SplitActualReceipts(ActualReceipts modifyReceipts, List<ActualReceipts> addReceipts)
        {
            this.ExecuteWithTransaction((con, tran) =>
            {
                foreach (ActualReceipts newReceipt in addReceipts)
                {
                    dal.AddActualReceipts(newReceipt, con, tran);
                }
                dal.ModifyActualReceipts(modifyReceipts, con, tran);
            });
        }

        /// <summary>
        /// 根据合同ID获取所有收款信息内容
        /// </summary>
        /// <param name="budgetId"></param>
        /// <returns></returns>
        public decimal GetTotalAmountByBudgetId(int budgetId)
        {
            return this.ExecuteWithTransaction<decimal>((con, tran) =>
             {
                 return dal.GetTotalAmountByBudgetId(budgetId, con, tran);
             });

        }

    }
}
