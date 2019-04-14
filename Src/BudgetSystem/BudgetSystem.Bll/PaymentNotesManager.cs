﻿using System;
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
        Dal.FlowDal fDal = new Dal.FlowDal();
        Bll.ReceiptMgmtManager rm = new ReceiptMgmtManager();
        Bll.BudgetManager bm = new BudgetManager();
        private Bll.SystemConfigManager scm = new Bll.SystemConfigManager();

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

        public PaymentNotes GetPaymentNoteDetailById(int id)
        {
            var lst = this.Query<PaymentNotes>((con) =>
            {
                var uList = dal.GetPaymentNoteById(id, con, null);
                return uList;
            });

            if (lst != null)
            {
                var valueAddedTaxRate = scm.GetSystemConfigValue<decimal>(EnumSystemConfigNames.增值税税率.ToString());
                var currentBudget = bm.GetBudget(lst.BudgetID);
                if (currentBudget != null)
                {
                    var receiptList = rm.GetBudgetBillListByBudgetId(currentBudget.ID);
                    var paymentNotes = GetTotalAmountPaymentMoneyByBudgetId(currentBudget.ID);

                    var pnList = paymentNotes.Where(o => !o.ID.Equals(lst.ID)).ToList<PaymentNotes>();
                    var caculator = new OutMoneyCaculator(currentBudget, pnList, receiptList, valueAddedTaxRate);


                    caculator.ApplyForPayment(lst.CNY, (decimal)lst.TaxRebateRate, lst.IsDrawback);

                    lst.AdvancePayment = currentBudget.AdvancePayment;
                    lst.Balance = caculator.Balance;
                }
            }
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

        public void ModifyPaymentNotePayingBankName(int pnId, string bankName)
        {
            this.ExecuteWithTransaction((con, tran) =>
                          {
                              dal.ModifyPaymentNotePayingBankName(pnId, bankName, con, tran);
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
                fDal.DeleteFlowInstanceByDateItem(id, EnumFlowDataType.付款单.ToString(), con, tran);

                dal.DeletePaymentNote(id, con, tran);
            });
        }
    }
}
