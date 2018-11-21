using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Linq;

namespace BudgetSystem.Bll
{
    public class BudgetManager : BaseManager
    {
        Dal.BudgetDal dal = new Dal.BudgetDal();
        Dal.ActualReceiptsDal arDal = new Dal.ActualReceiptsDal();
        Dal.PaymentNotesDal pnd = new Dal.PaymentNotesDal();
        Bll.FlowManager fm = new FlowManager();
        public List<Budget> GetAllBudget()
        {
            var lst = this.Query<Budget>((con) =>
            {
                var uList = dal.GetAllBudget(con);
                return uList;
            });
            return lst.ToList();
        }

        public Budget GetBudget(int id)
        {
            var budget = this.Query<Budget>((con) =>
            {
                var uList = dal.GetBudget(id, con);
                return uList;
            });
            return budget;
        }

        public int AddBudget(Budget budget, bool isStartFlow = false)
        {
            return this.ExecuteWithTransaction<int>((con, tran) =>
            {
                int id = dal.AddBudget(budget, con, tran);
                if (isStartFlow == true)
                {
                    FlowRunState state = fm.StartFlow(EnumFlowNames.预算单审批流程.ToString(), id,budget.ContractNO, EnumFlowDataType.预算单.ToString(), budget.Salesman);
                    if (state != FlowRunState.启动流程成功)
                    {
                        throw new Exception(string.Format("创建{0}失败，{1}。", EnumFlowNames.预算单审批流程.ToString(), state.ToString()));
                    }
                }
                return id;
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
            Budget budge = this.GetBudget(id);
            if (budge == null)
            {
                return "数据不存在";
            }
            else if (budge.EnumFlowState == EnumDataFlowState.审批中)
            {
                return string.Format("{0}中的数据不能重新启动流程", EnumDataFlowState.审批中);
            }
            FlowRunState state = fm.StartFlow(EnumFlowNames.预算单审批流程.ToString(), id,budge.ContractNO,EnumFlowDataType.预算单.ToString(), currentUser);
            if (state != FlowRunState.启动流程成功)
            {
                return state.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="budget"></param>
        /// <param name="isStartFlow"></param>
        /// <returns>修改成功返回string.Empty,否则返回失败原因</returns>
        public string ModifyBudget(Budget budget, bool isStartFlow = false)
        {
            Budget budge = this.GetBudget(budget.ID);
            if (budge == null)
            {
                return "数据不存在";
            }
            else if (budge.EnumFlowState == EnumDataFlowState.审批中
                || budget.EnumFlowState == EnumDataFlowState.审批通过)
            {
                return string.Format("{0}的预算单不能修改。");
            }
            string message = string.Empty;
            this.ExecuteWithTransaction((con, tran) =>
            {
                dal.ModifyBudget(budget, con, tran);
                if (isStartFlow == true)
                {
                    FlowRunState state = fm.StartFlow(EnumFlowNames.预算单审批流程.ToString(), budget.ID,budget.ContractNO, EnumFlowDataType.预算单.ToString(), budget.Salesman);
                    if (state != FlowRunState.启动流程成功)
                    {
                        message = string.Format("创建{0}失败，{1}。", EnumFlowNames.预算单审批流程.ToString(), state.ToString());
                    }
                }
            });
            return string.Empty;
        }

        public List<AccountBill> GetAccountBillDetailByBudgetId(int budgetId)
        {
            var lst = this.Query<AccountBill>((con) =>
            {
                var arList = arDal.GetActualReceiptsByBudgetId(budgetId, con, null);
                var abList = arList.ToAccountBillList();
                var pmList = pnd.GetTotalAmountPaymentMoneyByBudgetId(budgetId, con, null);
                abList.AddRange(pmList.ToAccountBillList());
                return abList.OrderBy(o => o.CreateDate);
            });
            return lst.ToList();
        }

        /// <summary>
        /// 验证合同编号是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contractNo"></param>
        /// <param name="con"></param>
        /// <returns></returns>
        public bool CheckContractNO(int id, string contractNo)
        {
            bool result = this.ExecuteWithoutTransaction<bool>((con) =>
            {
                return dal.CheckContractNO(id, contractNo, con);
            });
            return result;
        }
    }
}
