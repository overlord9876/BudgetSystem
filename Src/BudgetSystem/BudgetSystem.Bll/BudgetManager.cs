﻿using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Linq;
using Newtonsoft.Json;

namespace BudgetSystem.Bll
{
    public class BudgetManager : BaseManager
    {
        Dal.BudgetDal dal = new Dal.BudgetDal();
        Dal.ReceiptManagementDal rmDal = new Dal.ReceiptManagementDal();
        Dal.PaymentNotesDal pnd = new Dal.PaymentNotesDal();
        Dal.InvoiceDal idal = new Dal.InvoiceDal();
        Dal.ModifyMarkDal mmdal = new Dal.ModifyMarkDal();
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

        public List<Budget> GetBudgetListByCustomerId(string userName, int customerId)
        {
            var lst = this.Query<Budget>((con) =>
            {
                var uList = dal.GetBudgetListByCustomerId(userName, customerId, con);
                return uList;
            });
            return lst.ToList();
        }

        public List<Customer> GetCustomerListByBudgetId(int budgetId)
        {
            var lst = this.Query<Customer>((con) =>
            {
                var uList = dal.GetCustomerListByBudgetId(budgetId, con);
                return uList;
            });
            return lst.ToList();
        }

        public List<Budget> GetBudgetListBySaleman(string userName)
        {
            var lst = this.Query<Budget>((con) =>
            {
                var uList = dal.GetBudgetListBySaleman(userName, con);
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
                    mmdal.AddModifyMark<Budget>(budget, id, con, tran);
                    FlowRunState state = fm.StartFlow(EnumFlowNames.预算单审批流程.ToString(), id, budget.ContractNO, EnumFlowDataType.预算单.ToString(), budget.Salesman);
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
        public string StartFlow(int id, EnumFlowNames flowName, string currentUser)
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
            this.ExecuteWithoutTransaction((con) =>
            {
                mmdal.AddModifyMark<Budget>(budge, id, con);
            });
            FlowRunState state = fm.StartFlow(flowName.ToString(), id, budge.ContractNO, EnumFlowDataType.预算单.ToString(), currentUser);
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
            Budget oldBudget = this.GetBudget(budget.ID);
            if (oldBudget == null)
            {
                return "数据不存在";
            }
            else if (oldBudget.EnumFlowState == EnumDataFlowState.审批中
                || (EnumFlowNames.预算单审批流程.ToString().Equals(oldBudget.FlowName) && oldBudget.EnumFlowState == EnumDataFlowState.审批通过))
            {
                return string.Format("{0}的预算单不能修改。", oldBudget.EnumFlowState.ToString());
            }
            else if (EnumFlowNames.预算单修改流程.ToString().Equals(oldBudget.FlowName) && oldBudget.EnumFlowState != EnumDataFlowState.审批通过)
            {
                return string.Format("{0}未审批通过不能修改。", EnumFlowNames.预算单修改流程.ToString());
            }
            string message = string.Empty;
            this.ExecuteWithTransaction((con, tran) =>
            {
                dal.ModifyBudget(budget, con, tran);
                if (isStartFlow == true)
                {
                    mmdal.AddModifyMark<Budget>(budget, budget.ID, con, tran);
                    FlowRunState state = fm.StartFlow(EnumFlowNames.预算单审批流程.ToString(), budget.ID, budget.ContractNO, EnumFlowDataType.预算单.ToString(), budget.Salesman);
                    if (state != FlowRunState.启动流程成功)
                    {
                        message = string.Format("创建{0}失败，{1}。", EnumFlowNames.预算单审批流程.ToString(), state.ToString());
                    }
                }
            });
            return message;
        }

        public List<AccountBill> GetAccountBillDetailByBudgetId(int budgetId)
        {
            var lst = this.Query<AccountBill>((con) =>
            {
                var arList = rmDal.GetBudgetBillListByBudgetId(budgetId, con, null);
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

        /// <summary>
        /// 获取所有修改记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Budget> GetAllModifyMark(int id)
        {
            return this.Query<Budget>((con) =>
            {
                return mmdal.GetAllModifyMark<Budget>(id, con);
            }).ToList();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteBudget(int id)
        {
            Budget budget = this.GetBudget(id);
            if (budget == null)
            {
                return "数据不存在";
            }
            else if (!EnumFlowNames.预算单删除流程.ToString().Equals(budget.FlowName)
                      || budget.EnumFlowState != EnumDataFlowState.审批通过)
            {
                return string.Format("{0}没有审批通过，不能删除。", EnumFlowNames.预算单删除流程.ToString());
            }
            string message = string.Empty;
            bool checkResult = false;
            this.ExecuteWithTransaction((con, tran) =>
            {
                checkResult = pnd.CheckContractNO(id, con, tran);
                if (checkResult)
                {
                    message = "存在付款信息，不能删除";
                    return;
                }
                checkResult = idal.CheckContractNO(budget.ContractNO, con, tran);
                if (checkResult)
                {
                    message = "存在发票信息，不能删除";
                    return;
                }
                mmdal.DeleteModifyMark<Budget>(id, con, tran);
                dal.DeleteBudget(id, con, tran);
            });
            return message;
        }

    }
}
