using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Linq;
using BudgetSystem.Entity.QueryCondition;
using BudgetSystem.Dal;

namespace BudgetSystem.Bll
{
    public class AccountAdjustmentManager : BaseManager
    {
        private AccountAdjustmentDal dal = new AccountAdjustmentDal();
        private FlowManager fm = new FlowManager();
        private ModifyMarkDal mmDal = new ModifyMarkDal();

        public List<AccountAdjustment> GetAllAccountAdjustment(AccountAdjustmentQueryCondition condition = null)
        {
            var lst = this.Query<AccountAdjustment>((con) =>
            {
                var uList = dal.GetAllAccountAdjustment(con, null, condition);
                return uList;

            });
            return lst.ToList();
        }

        /// <summary>
        /// 根据预算单ID获取余额信息。
        /// </summary>
        /// <param name="budgetId"></param>
        /// <returns></returns>
        public List<AccountAdjustment> GetBalanceAccountAdjustmentByBudgetId(int budgetId)
        {
            var lst = this.Query<AccountAdjustment>((con) =>
            {
                var uList = dal.GetBalanceAccountAdjustmentByBudgetId(budgetId, con, null);
                return uList;

            });
            return lst.ToList();
        }

        /// <summary>
        /// 根据预算单ID获取余额信息。
        /// </summary>
        /// <param name="budgetId"></param>
        /// <returns></returns>
        public List<AccountAdjustmentDetail> GetBalanceAccountAdjustmentDetailByBudgetId(int budgetId)
        {
            var lst = this.Query<AccountAdjustmentDetail>((con) =>
            {
                var uList = dal.GetBalanceAccountAdjustmentDetailByBudgetId(budgetId, con, null);
                return uList;

            });
            return lst.ToList();
        }

        /// <summary>
        /// 获取调入详情信息。这里关联的合同号是调出主表的合同号。
        /// </summary>
        /// <param name="budgetId"></param>
        /// <returns></returns>
        public IEnumerable<AccountAdjustmentDetail> GetAccountAdjustmentsDetailByBudgetId(int budgetId)
        {
            var lst = this.Query<AccountAdjustmentDetail>((con) =>
            {
                var uList = dal.GetAccountAdjustmentsDetailByBudgetId(budgetId, con, null);
                return uList;

            });
            return lst.ToList();
        }

        /// <summary>
        /// 获取调账报表
        /// </summary>
        /// <param name="budgetId"></param>
        /// <returns></returns>
        public List<AccountAdjustmentReport> GetAccountAdjustmentReportList(BudgetQueryCondition condition)
        {
            var lst = this.Query<AccountAdjustmentReport>((con) =>
            {
                var uList = dal.GetAccountAdjustmentReportList(condition, con, null);
                return uList;

            });
            return lst.ToList();
        }

        /// <summary>
        /// 根据父拆分类型获取列表。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="atType"></param>
        /// <returns></returns>
        public List<AccountAdjustmentDetail> GetAccountAdjustmentDetailByTypeId(int id, AdjustmentType atType)
        {
            var lst = this.Query<AccountAdjustmentDetail>((con) =>
            {
                var uList = dal.GetAccountAdjustmentDetailByTypeId(id, atType, con, null);
                return uList;

            });
            if (lst == null) { return null; }
            return lst.ToList();
        }

        public AccountAdjustment GetAccountAdjustment(int id, AdjustmentType atType)
        {
            var AccountAdjustment = this.Query<AccountAdjustment>((con) =>
            {
                var uList = dal.GetAccountAdjustment(id, atType, con);
                return uList;
            });
            return AccountAdjustment;
        }

        public int AddAccountAdjustment(AccountAdjustment AccountAdjustment, List<AccountAdjustmentDetail> details)
        {
            return this.ExecuteWithTransaction<int>((con, tran) =>
            {
                bool exists = dal.ExistsItem(AccountAdjustment.RelationID, AccountAdjustment.Type, con, tran);
                if (exists) { return -2; }
                int id = dal.AddAccountAdjustment(AccountAdjustment, details, con, tran);
                return id;
            });
        }

        public bool ExistsItem(int relationId, AdjustmentType type)
        {
            return this.ExecuteWithTransaction<bool>((con, tran) =>
           {
               return dal.ExistsItem(relationId, type, con, tran);
           });
        }

        public bool CheckCode(string code, int id, AdjustmentType atType)
        {
            return this.ExecuteWithTransaction<bool>((con, tran) =>
            {
                bool result = dal.CheckCode(code, id, atType, con);
                return result;
            });

        }

        public void DeleteAccountAdjustment(AccountAdjustment AccountAdjustment)
        {
            this.ExecuteWithTransaction((con, tran) =>
           {
               dal.DeleteAccountAdjustment(AccountAdjustment, con, tran);
           });

        }

        public DateTime ModifyAccountAdjustment(AccountAdjustment AccountAdjustment, List<AccountAdjustmentDetail> details)
        {
            return this.ExecuteWithTransaction((con, tran) =>
             {
                 return dal.ModifyAccountAdjustment(AccountAdjustment, details, con, tran);
             });
        }

        /// <summary>
        /// 启动审批流程
        /// </summary>
        /// <param name="adjustment"></param>
        /// <param name="flowName"></param>
        /// <param name="currentUser"></param>
        /// <param name="currentUserName"></param>
        /// <param name="description"></param>
        /// <returns>返回string.Empty为成功，否则为失败原因</returns>
        public string StartFlow(AccountAdjustment adjustment, EnumFlowNames flowName, string currentUser, string currentUserName, string description, bool isAddModifyMark = true)
        {
            adjustment.Details = this.GetAccountAdjustmentDetailByTypeId(adjustment.ID, adjustment.Type);

            //当启动的流程为预算单审批流程才记录修改记录。
            if (flowName == EnumFlowNames.调账审批流程)
            {
                if (adjustment.State == AccountAdjustmentState.调账中)
                {
                    return "数据不完整，请修改补充后再提交";
                }
                if (isAddModifyMark)
                {
                    this.ExecuteWithoutTransaction((con) =>
                    {
                        mmDal.AddModifyMark<AccountAdjustment>(adjustment, adjustment.ID, con);
                    });
                }
            }
            if (!adjustment.CreateUser.Equals(currentUser))
            {
                return string.Format("当前预算单由{0}创建，不允许由{1}提交流程", adjustment.CreateRealUserName, currentUserName);
            }
            EnumFlowDataType flowDataType = adjustment.ToDataType();

            FlowRunState state = fm.StartFlow(flowName.ToString(), adjustment.ID, adjustment.Code, flowDataType.ToString(), currentUser, description);
            if (state != FlowRunState.启动流程成功)
            {
                return state.ToString();
            }
            return string.Empty;
        }

    }
}
