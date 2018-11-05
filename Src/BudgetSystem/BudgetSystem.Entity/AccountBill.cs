using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 收支明细
    /// </summary>
    public class AccountBill
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        public string BudgetNO { get; set; }

        /// <summary>
        /// 申请用款金额
        /// </summary>
        public decimal PaymentMoney { get; set; }

        /// <summary>
        /// 收款金额
        /// </summary>
        public decimal RecieptMoney { get; set; }

        /// <summary>
        /// 折合人民币
        /// </summary>
        public decimal CNY { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// 如果是付款则为供应商、如果是收款则为客户方
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// 凭证号
        /// </summary>
        public string VoucherNo { get; set; }


        /// <summary>
        /// 用途
        /// </summary>
        public string MoneyUsed { get; set; }

    }

    public static class AccountBillConvertExtension
    {
        public static List<AccountBill> ToAccountBillList(this List<PaymentNotes> paymentNotes)
        {
            List<AccountBill> returnResult = new List<AccountBill>();
            foreach (PaymentNotes pn in paymentNotes)
            {
                returnResult.Add(pn.ToToAccountBill());
            }
            return returnResult;
        }

        public static List<AccountBill> ToAccountBillList(this List<ActualReceipts> actualReceipts)
        {
            List<AccountBill> returnResult = new List<AccountBill>();
            foreach (ActualReceipts ar in actualReceipts)
            {
                returnResult.Add(ar.ToToAccountBill());
            }
            return returnResult;
        }
        public static List<AccountBill> ToAccountBillList(this IEnumerable<PaymentNotes> paymentNotes)
        {
            List<AccountBill> returnResult = new List<AccountBill>();
            foreach (PaymentNotes pn in paymentNotes)
            {
                returnResult.Add(pn.ToToAccountBill());
            }
            return returnResult;
        }

        public static List<AccountBill> ToAccountBillList(this IEnumerable<ActualReceipts> actualReceipts)
        {
            List<AccountBill> returnResult = new List<AccountBill>();

            foreach (ActualReceipts ar in actualReceipts)
            {
                returnResult.Add(ar.ToToAccountBill());
            }
            return returnResult;
        }

        public static AccountBill ToToAccountBill(this ActualReceipts receipt)
        {
            return new AccountBill()
                {
                    BudgetNO = receipt.ContractNO,
                    CreateDate = receipt.CreateTimestamp,
                    PaymentMoney = Decimal.Zero,
                    Currency = receipt.Currency,
                    VoucherNo = receipt.VoucherNo,
                    MoneyUsed = receipt.Description,
                    CNY = receipt.CNY,
                    RecieptMoney = receipt.OriginalCoin,
                    Company = receipt.Remitter
                };
        }

        public static AccountBill ToToAccountBill(this PaymentNotes pn)
        {
            return new AccountBill()
                    {
                        BudgetNO = pn.ContractNO,
                        CreateDate = pn.ApproveTime,
                        PaymentMoney = pn.CNY,
                        Currency = "CNY",
                        VoucherNo = pn.VoucherNo,
                        MoneyUsed = pn.MoneyUsed,
                        CNY = pn.CNY * -1,
                        RecieptMoney = Decimal.Zero,
                        Company = pn.SupplierName
                    };
        }
    }
}
