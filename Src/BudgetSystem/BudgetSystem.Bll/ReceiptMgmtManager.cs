using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Linq;

namespace BudgetSystem.Bll
{
    public class ReceiptMgmtManager : BaseManager
    {
        Dal.ReceiptManagementDal dal = new Dal.ReceiptManagementDal();

        public List<BankSlip> GetAllBankSlipList()
        {
            var lst = this.Query<BankSlip>((con) =>
            {

                var uList = dal.GetAllBankSlipList(con, null);
                return uList;
            });
            return lst.ToList();
        }

        public List<BankSlip> GetBankSlipListByUserName(string salesman)
        {
            var lst = this.Query<BankSlip>((con) =>
            {

                var uList = dal.GetBankSlipListByUserName(salesman, con, null);
                return uList;
            });
            return lst.ToList();
        }

        public BankSlip GetAllActualReceipts(int bsID)
        {
            var lst = this.Query<BankSlip>((con) =>
            {
                var uList = dal.GetAllActualReceipts(bsID, con, null);
                return uList;
            });
            return lst;
        }


        /// <summary>
        /// 创建收款记录
        /// </summary>
        /// <param name="addBankSlip"></param>
        public int AddBankSlip(BankSlip addBankSlip)
        {
            return this.ExecuteWithTransaction<int>((con, tran) =>
            {
                int id = dal.AddBankSlip(addBankSlip, con, tran);
                foreach (User u in addBankSlip.Sales)
                {
                    dal.AddReceiptNotice(id, u.UserName, con, tran);
                }
                return id;
            });
        }


        /// <summary>
        /// 修改入帐单
        /// </summary>
        /// <param name="modifyBankSlip"></param>
        /// <returns></returns>
        public DateTime ModifyBankSlip(BankSlip modifyBankSlip)
        {
            return this.ExecuteWithTransaction<DateTime>((con, tran) =>
            {
                DateTime versionNumber = dal.ModifyBankSlip(modifyBankSlip, con, tran);
                dal.DeleteReceiptNotice(modifyBankSlip.BSID, con, tran);
                foreach (User u in modifyBankSlip.Sales)
                {
                    dal.AddReceiptNotice(modifyBankSlip.BSID, u.UserName, con, tran);
                }
                return versionNumber;
            });
        }

        /// <summary>
        /// 拆分金额
        /// </summary>
        /// <param name="modifyBankSlip"></param>
        /// <returns></returns>
        public DateTime SplitAmountOfBankSlip(BankSlip modifyBankSlip, List<BudgetBill> budgetBillList)
        {
            return this.ExecuteWithTransaction<DateTime>((con, tran) =>
            {
                DateTime versionNumber = dal.ModifyBankSlipAmountMoney(modifyBankSlip, con, tran);
                bool confirmed = (modifyBankSlip.CNY2 == 0);

                foreach (BudgetBill b in budgetBillList)
                {
                    b.Confirmed = confirmed;
                    if (b.OperatorModel == DataOperatorModel.Add)
                    {
                        dal.AddBudgetBill(b, con, tran);
                    }
                    else if (b.OperatorModel == DataOperatorModel.Modify)
                    {
                        dal.ModifyBudgetBill(b, con, tran);
                    }
                }

                return versionNumber;
            });
        }

        /// <summary>
        /// 根据合同ID获取所有收款信息内容
        /// </summary>
        /// <param name="budgetId"></param>
        /// <returns></returns>
        public decimal GetTotalAmountCNYByBudgetId(int budgetId)
        {
            return this.ExecuteWithTransaction<decimal>((con, tran) =>
             {
                 return dal.GetTotalAmountCNYByBudgetId(budgetId, con, tran);
             });

        }

        /// <summary>
        /// 根据合同ID获取所有收款原币金额
        /// </summary>
        /// <param name="budgetId"></param>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public decimal GetTotalAmountOriginalCoinByBudgetId(int budgetId)
        {
            return this.ExecuteWithTransaction<decimal>((con, tran) =>
             {
                 return dal.GetTotalAmountOriginalCoinByBudgetId(budgetId, con, tran);
             });

        }
    }
}
