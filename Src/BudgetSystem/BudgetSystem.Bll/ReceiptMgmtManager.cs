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
        Bll.FlowManager fm = new FlowManager();

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

        public BankSlip GetBankSlipByBSID(int bsID)
        {
            var lst = this.Query<BankSlip>((con) =>
            {
                var uList = dal.GetBankSlipByBSID(bsID, con, null);
                return uList;
            });
            return lst;
        }

        public List<BudgetBill> GetBudgetBillListByBankSlipID(int bsID)
        {
            var lst = this.Query<BudgetBill>((con) =>
            {
                var uList = dal.GetBudgetBillListByBankSlipID(bsID, con, null);
                return uList;
            });
            return lst.ToList();
        }

        public IEnumerable<BudgetBill> GetBudgetBillListByBudgetId(int budgetId)
        {
            var lst = this.Query<BudgetBill>((con) =>
            {
                var uList = dal.GetBudgetBillListByBudgetId(budgetId, con, null);
                return uList;
            });
            return lst.ToList();
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
        /// 启动审批流程
        /// </summary>
        /// <param name="bsID"></param>
        /// <param name="currentUser"></param>
        /// <returns>返回string.Empty为成功，否则为失败原因</returns>
        public string StartFlow(int bsID, string currentUser)
        {
            BankSlip bankSlip = this.GetBankSlipByBSID(bsID);
            if (bankSlip == null)
            {
                return "数据不存在";
            }
            else if (bankSlip.EnumFlowState == EnumDataFlowState.审批中)
            {
                return string.Format("{0}中的数据不能重新启动流程", EnumDataFlowState.审批中);
            }
            FlowRunState state = fm.StartFlow(EnumFlowNames.入账审修改批流程.ToString(), bsID, bankSlip.VoucherNo, EnumFlowDataType.收款单.ToString(), currentUser);
            if (state != FlowRunState.启动流程成功)
            {
                return state.ToString();
            }
            return string.Empty;
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
                    b.BudgetID = b.RelationBudget.ID;
                    if (b.OperatorModel == DataOperatorModel.Add)
                    {
                        b.BSID = modifyBankSlip.BSID;
                        b.Cus_ID = b.Custom.ID;
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

        public DateTime ConfirmSplitAmount(BankSlip modifyBankSlip)
        {
            return this.ExecuteWithTransaction<DateTime>((con, tran) =>
            {
                DateTime versionNumber = dal.ModifyBankSlipAmountMoney(modifyBankSlip, con, tran);
                bool confirmed = (modifyBankSlip.CNY2 == 0);
                dal.ConfirmSplitBankSlip(modifyBankSlip.BSID, con, tran);
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
