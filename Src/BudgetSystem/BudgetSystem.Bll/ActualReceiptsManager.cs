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
        public void CreateActualReceipts(ActualReceipts addReceipts)
        {
            this.ExecuteWithTransaction((con, tran) =>
           {
               dal.AddActualReceipts(addReceipts, con, tran);
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
                dal.RelationActualReceiptsToBudget(relationReceipt.ID, relationReceipt.BudgetID, con, tran);
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


    }
}
