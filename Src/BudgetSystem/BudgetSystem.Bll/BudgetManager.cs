using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Linq;
using Newtonsoft.Json;
using BudgetSystem.Entity.QueryCondition;

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
        Dal.FlowDal fmDal = new Dal.FlowDal();

        public List<Budget> GetAllBudget(BudgetQueryCondition condition = null)
        {
            var lst = this.Query<Budget>((con) =>
            {
                var uList = dal.GetAllBudget(con, null, condition);
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

        public Budget GetBudgetByNo(string NO)
        {
            var budget = this.Query<Budget>((con) =>
            {
                var uList = dal.GetBudgetByNo(NO, con);
                return uList;
            });
            return budget;
        }

        public string GetBudgetDesc(int id)
        {
            Budget budget = this.GetBudget(id);
            if (budget != null)
            {
                return budget.ToDesc();
            }
            else
            {
                return string.Empty;
            }
        }

        public int AddBudget(Budget budget, bool isStartFlow = false)
        {
            return this.ExecuteWithTransaction<int>((con, tran) =>
            {
                int id = dal.AddBudget(budget, con, tran);
                if (isStartFlow == true)
                {
                    mmdal.AddModifyMark<Budget>(budget, id, con, tran);
                    FlowRunState state = fm.StartFlow(EnumFlowNames.预算单审批流程.ToString(), id, budget.ContractNO, EnumFlowDataType.预算单.ToString(), budget.Salesman, budget.Description);
                    if (state != FlowRunState.启动流程成功)
                    {
                        throw new Exception(string.Format("创建{0}失败，{1}。", EnumFlowNames.预算单审批流程.ToString(), state.ToString()));
                    }
                }
                return id;
            });
        }

        /// <summary>
        /// 修改预算单 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public string ModifyBudgetState(int id, EnumBudgetState state)
        {
            Budget oldBudget = this.GetBudget(id);
            if (oldBudget == null)
            {
                return "数据不存在";
            }
            else if (!EnumFlowNames.预算单审批流程.ToString().Equals(oldBudget.FlowName) || oldBudget.EnumFlowState != EnumDataFlowState.审批通过)
            {
                return string.Format("预算单当前不满足{0}且审批状态为{1}，不能进行当前操作。", EnumFlowNames.预算单审批流程, EnumDataFlowState.审批通过);
            }
            string message = string.Empty;
            this.ExecuteWithTransaction((con, tran) =>
            {
                dal.ModifyBudgetState(id, state, con, tran);
            });
            return message;
        }

        /// <summary>
        /// 启动审批流程
        /// </summary>
        /// <param name="id"></param>
        /// <param name="flowName"></param>
        /// <param name="currentUser"></param>
        /// <param name="currentUserName"></param>
        /// <param name="description"></param>
        /// <returns>返回string.Empty为成功，否则为失败原因</returns>
        public string StartFlow(int id, EnumFlowNames flowName, string currentUser, string currentUserName, string description)
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
            else if (!budge.UpdateUser.Equals(currentUser))
            {
                return string.Format("当前预算单由{0}创建，不允许由{1}提交流程", budge.UpdateUserName, currentUserName);
            }
            EnumFlowNames? oldFlowName = null;
            if (!string.IsNullOrEmpty(budge.FlowName))
            {
                oldFlowName = (EnumFlowNames)Enum.Parse(typeof(EnumFlowNames), budge.FlowName);
            }
            string message = EnumCheckUtil.CheckCurrentFlowStart(flowName, oldFlowName, budge.EnumFlowState);
            if (!string.IsNullOrEmpty(message)) { return message; }
            //当启动的流程为预算单审批流程才记录修改记录。
            if (flowName == EnumFlowNames.预算单审批流程)
            {
                if (budge.IsValid == false)
                {
                    return "数据不完整，请修改补充后再提交";
                }
                this.ExecuteWithoutTransaction((con) =>
            {
                mmdal.AddModifyMark<Budget>(budge, id, con);
            });
            }

            FlowRunState state = fm.StartFlow(flowName.ToString(), id, budge.ContractNO, EnumFlowDataType.预算单.ToString(), currentUser, description);
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
        public string ModifyBudget(Budget budget, string description, bool isStartFlow = false)
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
                    FlowRunState state = fm.StartFlow(EnumFlowNames.预算单审批流程.ToString(), budget.ID, budget.ContractNO, EnumFlowDataType.预算单.ToString(), budget.Salesman, description);
                    if (state != FlowRunState.启动流程成功)
                    {
                        message = string.Format("创建{0}失败，{1}。", EnumFlowNames.预算单审批流程.ToString(), state.ToString());
                    }
                }
            });
            return message;
        }

        public void ModifyBudgetDescription(Budget budget)
        {
            this.ExecuteWithTransaction((con, tran) =>
              {
                  dal.ModifyBudgetDescription(budget, con, tran);
              });
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
        /// 验证合同编号是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contractNo"></param>
        /// <param name="con"></param>
        /// <returns></returns>
        public int CheckContractNO(string contractNo)
        {
            return this.ExecuteWithoutTransaction<int>((con) =>
                    {
                        return dal.CheckContractNO(contractNo, con);
                    });
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
            else if ((!string.IsNullOrEmpty(budget.FlowName)) && !EnumFlowNames.预算单删除流程.ToString().Equals(budget.FlowName))
            {
                return string.Format("流程单正处于{0}，不能删除。", budget.FlowName);
            }
            else if (EnumFlowNames.预算单删除流程.ToString().Equals(budget.FlowName) && budget.EnumFlowState != EnumDataFlowState.审批通过)
            {
                return string.Format("{0}未审批通过，不能删除。", EnumFlowNames.预算单删除流程);
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
                checkResult = idal.CheckContractNO(budget.ID, con, tran);
                if (checkResult)
                {
                    message = "存在发票信息，不能删除";
                    return;
                }
                mmdal.DeleteModifyMark<Budget>(id, con, tran);
                fmDal.DeleteFlowInstanceByDateItem(id, EnumFlowDataType.预算单.ToString(), con, tran);
                dal.DeleteBudget(id, con, tran);
            });
            return message;
        }

    }
}
