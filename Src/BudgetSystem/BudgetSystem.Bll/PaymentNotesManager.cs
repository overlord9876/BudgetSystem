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


        public List<PaymentNotes> GetAllPaymentNotes()
        {
            var lst = this.Query<PaymentNotes>((con) =>
            {
                var uList = dal.GetAllPaymentNotes(con, null);
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

        public void AddPaymentNote(PaymentNotes addPaymentNote)
        {
            this.ExecuteWithTransaction((con, tran) =>
            {
                dal.AddPaymentNote(addPaymentNote, con, tran);
            });
        }

        public void ModifyPaymentNote(PaymentNotes modifyPaymentNote)
        {
            this.ExecuteWithTransaction((con, tran) =>
            {
                dal.ModifyPaymentNote(modifyPaymentNote, con, tran);
            });
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
