﻿using System;
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
            var Budget = this.Query<Budget>((con) =>
            {
                var uList = dal.GetBudget(id, con);
                return uList;
            });
            return Budget;
        }

        public int AddBudget(Budget Budget)
        {
            return this.ExecuteWithTransaction<int>((con, tran) =>
            {
                int id = dal.AddBudget(Budget, con, tran);
                FlowRunState state = fm.StartFlow(EnumFlowNames.预算单审批流程.ToString(), id, EnumFlowDataType.预算单.ToString(), Budget.Salesman);
                if (state != FlowRunState.启动流程成功)
                {
                    throw new Exception(string.Format("创建{0}失败，{1}。",EnumFlowNames.预算单审批流程.ToString(),state.ToString()));
                }
                return id;
            });
        }

        public void ModifyBudget(Budget Budget)
        {
            this.ExecuteWithTransaction((con, tran) =>
            {
                dal.ModifyBudget(Budget, con, tran);
            });
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
                return dal.CheckContractNO(id,contractNo,con);
            });
            return result;
        }
    }
}
