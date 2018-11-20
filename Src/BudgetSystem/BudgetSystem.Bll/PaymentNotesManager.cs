using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Linq;

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

        public void ModifyPaymentNote(PaymentNotes modifyPaymentNote)
        {
            this.ExecuteWithTransaction((con, tran) =>
            {
                dal.ModifyPaymentNote(modifyPaymentNote, con, tran);
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
            PaymentNotes payment = this.GetPaymentNoteById(id);
            if (payment == null)
            {
                return "数据不存在";
            }
            else if (payment.EnumFlowState == EnumDataFlowState.审批中)
            {
                return string.Format("{0}中的数据不能重新启动流程", EnumDataFlowState.审批中);
            }
            FlowRunState state = fm.StartFlow(EnumFlowNames.付款审批流程.ToString(), id, EnumFlowDataType.付款单.ToString(), currentUser);
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
