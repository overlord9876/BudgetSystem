using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Linq;
using BudgetSystem.Entity.QueryCondition;

namespace BudgetSystem.Bll
{
    public class PaymentNotesManager : BaseManager
    {
        Dal.PaymentNotesDal dal = new Dal.PaymentNotesDal();
        Bll.FlowManager fm = new FlowManager();

        public List<PaymentNotes> GetAllPaymentNotes()
        {
            var lst = this.Query<PaymentNotes>((con) =>
            {
                var uList = dal.GetAllPaymentNotes(con, null);
                return uList;
            });
            return lst.ToList();
        }

        public List<PaymentNotes> GetAllPaymentNoteByCondition(OutMoneyQueryCondition condition)
        {
            var lst = this.Query<PaymentNotes>((con) =>
            {
                var uList = dal.GetAllPaymentNoteByCondition(condition, con, null);
                return uList;
            });
            return lst.ToList();
        }

        /// <summary>
        /// 根据合同ID获取所有付款信息
        /// </summary>
        /// <param name="budgetId"></param>
        /// <returns></returns>
        public IEnumerable<PaymentNotes> GetTotalAmountPaymentMoneyByBudgetId(int budgetId)
        {
            var lst = this.Query<PaymentNotes>((con) =>
            {
                var uList = dal.GetTotalAmountPaymentMoneyByBudgetId(budgetId, con, null);
                return uList;
            });
            return lst.ToList();
        }

        public PaymentNotes GetPaymentNoteById(int id)
        {
            var lst = this.Query<PaymentNotes>((con) =>
            {
                var uList = dal.GetPaymentNoteById(id, con, null);
                return uList;
            });
            return lst;
        }

        public int AddPaymentNote(PaymentNotes addPaymentNote)
        {
            return this.ExecuteWithTransaction<int>((con, tran) =>
                    {
                        return dal.AddPaymentNote(addPaymentNote, con, tran);
                    });
        }

        public DateTime ModifyPaymentNote(PaymentNotes modifyPaymentNote)
        {
            return this.ExecuteWithTransaction<DateTime>((con, tran) =>
                 {
                     return dal.ModifyPaymentNote(modifyPaymentNote, con, tran);
                 });
        }

        /// <summary>
        /// 合同付款，单个非合格供方付款人民币总数
        /// </summary>
        /// <param name="budgetId"></param>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        public decimal GetTemporarySupplierPaymentByBudgetId(int budgetId, int supplierId)
        {
            var result = this.Query<decimal>((con) =>
            {
                var totalAmount = dal.GetTemporarySupplierPaymentByBudgetId(budgetId, supplierId, con, null);
                return totalAmount;
            });
            return result;
        }

        /// <summary>
        /// 启动审批流程
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentUser"></param>
        /// <returns>返回string.Empty为成功，否则为失败原因</returns>
        public string StartFlow(int id, string currentUser)
        {
            PaymentNotes payment = this.GetPaymentNoteById(id);
            if (payment == null)
            {
                return "数据不存在";
            }
            else if (payment.EnumFlowState == EnumDataFlowState.审批中)
            {
                return string.Format("{0}中的数据不能重新启动流程", EnumDataFlowState.审批中);
            }
            FlowRunState state = fm.StartFlow(EnumFlowNames.付款审批流程.ToString(), id, payment.VoucherNo, EnumFlowDataType.付款单.ToString(), currentUser);
            if (state != FlowRunState.启动流程成功)
            {
                return state.ToString();
            }
            return string.Empty;
        }

        public void DeletePaymentNote(int id)
        {
            this.ExecuteWithTransaction((con, tran) =>
            {
                dal.DeletePaymentNote(id, con, tran);
            });
        }
    }
}
