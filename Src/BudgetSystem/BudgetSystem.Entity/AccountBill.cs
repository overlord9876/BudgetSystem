using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 收支明细
    /// </summary>
    public class AccountBill
    {
        /// <summary>
        /// 付款、收款发生时间，以确认获取最精确汇率。
        /// </summary>
        public DateTime Date { get; set; }

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
        /// 是否为付款，否则为收款。
        /// </summary>
        public string IsPayment { get; set; }

        /// <summary>
        /// 折合美元。
        /// </summary>
        public decimal USD { get; set; }

        /// <summary>
        /// 折合人民币
        /// </summary>
        public decimal CNY { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// 汇率
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// 当前币种为美元。
        /// </summary>
        public bool IsUSD { get; set; } = false;

        /// <summary>
        /// 如果是付款则为供应商、如果是收款则为客户方
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// 真实付款客户
        /// </summary>
        public string Company2 { get; set; }

        /// <summary>
        /// 凭证号
        /// </summary>
        public string VoucherNo { get; set; }


        /// <summary>
        /// 用途
        /// </summary>
        public string MoneyUsed { get; set; }

        /// <summary>
        /// 款项性质
        /// </summary>
        public string NatureOfMoney { get; set; }

        public string UseType { get; set; }

        /// <summary>
        /// 是否退税
        /// </summary>
        public bool IsDrawback { get; set; }

        public int AdjustmentType { get; set; } = 0;

        /// <summary>
        /// 用途
        /// </summary>
        public string MoneyUsedDesc
        {
            get
            {
                return string.Format("{0}{1}", MoneyUsed, IsDrawback ? "（可退税）" : string.Empty);
            }
        }

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

        public static List<AccountBill> ToAccountBillList(this List<BudgetBill> actualReceipts)
        {
            List<AccountBill> returnResult = new List<AccountBill>();
            foreach (BudgetBill ar in actualReceipts)
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

        public static List<AccountBill> ToAccountBillList(this IEnumerable<AccountAdjustment> adjustments, IEnumerable<AccountAdjustmentDetail> detailList)
        {
            List<AccountBill> returnResult = new List<AccountBill>();
            foreach (AccountAdjustment adjustment in adjustments)
            {
                var item = adjustment.ToToAccountBill(detailList);
                if (item != null) { returnResult.Add(item); }
            }
            return returnResult;
        }

        public static List<AccountBill> ToAccountBillList(this IEnumerable<AccountAdjustmentDetail> adjustmentDetails)
        {
            List<AccountBill> returnResult = new List<AccountBill>();
            foreach (AccountAdjustmentDetail adjustmentDetail in adjustmentDetails)
            {
                returnResult.Add(adjustmentDetail.ToToAccountBill());
            }
            return returnResult;
        }

        public static List<AccountBill> ToAccountBillList(this IEnumerable<BudgetBill> actualReceipts)
        {
            List<AccountBill> returnResult = new List<AccountBill>();

            foreach (BudgetBill ar in actualReceipts)
            {
                returnResult.Add(ar.ToToAccountBill());
            }
            return returnResult;
        }

        public static AccountBill ToToAccountBill(this BudgetBill receipt)
        {
            bool isUSD = receipt.Currency == "USD";
            return new AccountBill()
            {
                Date = receipt.ReceiptDate,
                BudgetNO = receipt.ContractNO,
                CreateDate = receipt.ReceiptDate,
                PaymentMoney = Decimal.Zero,
                Currency = receipt.Currency,
                VoucherNo = receipt.VoucherNo,
                MoneyUsed = receipt.Remark,
                CNY = receipt.CNY,
                USD = receipt.OriginalCoin,
                IsUSD = isUSD,
                IsPayment = false.ToString(),
                ExchangeRate = receipt.ExchangeRate,
                RecieptMoney = receipt.OriginalCoin,
                Company = receipt.Remitter,
                Company2 = receipt.Customer,
                NatureOfMoney = receipt.NatureOfMoney,
            };
        }

        public static AccountBill ToToAccountBill(this PaymentNotes pn)
        {
            bool isUSD = pn.Currency == "美元";
            return new AccountBill()
            {
                Date = pn.PaymentDate,
                BudgetNO = pn.ContractNO,
                CreateDate = pn.CommitTime,
                PaymentMoney = pn.OriginalCoin,
                Currency = pn.Currency,
                IsUSD = isUSD,
                VoucherNo = pn.VoucherNo,
                MoneyUsed = pn.MoneyUsed,
                CNY = pn.CNY * -1,
                USD = pn.OriginalCoin,
                ExchangeRate = (decimal)pn.ExchangeRate,
                IsPayment = true.ToString(),
                IsDrawback = pn.IsDrawback,
                RecieptMoney = Decimal.Zero,
                Company = pn.SupplierName
            };
        }

        public static AccountBill ToToAccountBill(this AccountAdjustment adjustment, IEnumerable<AccountAdjustmentDetail> detailList)
        {
            bool isUSD = false;
            decimal paymentMoney = 0;
            decimal CNY = 0;
            decimal recieptMoney = 0;
            decimal USD = 0;
            bool IsPayment = false;
            string name = string.Empty;
            var currentDetails = detailList.Where(o => o.PID == adjustment.ID);
            if (currentDetails == null || !currentDetails.Any()) { return null; }
            string priex = detailList.Count() > 0 ? "分别" : "";
            string contracts = string.Join("、", currentDetails.Select(o => $"{o.ContractNO}合同").ToArray());
            if (adjustment.Type == AdjustmentType.付款)
            {
                name = "供应商";
                isUSD = adjustment.Currency == "美元";
                CNY = adjustment.AlreadySplitCNY;
                paymentMoney = adjustment.AlreadySplitOriginalCoin * -1;
                USD = adjustment.AlreadySplitOriginalCoin;
                IsPayment = true;
            }
            else if (adjustment.Type == AdjustmentType.收款)
            {
                name = "客户";
                isUSD = adjustment.Currency == "USD";
                CNY = adjustment.AlreadySplitCNY * -1;
                recieptMoney = adjustment.AlreadySplitOriginalCoin * -1;
                USD = adjustment.AlreadySplitOriginalCoin * -1;
            }

            return new AccountBill()
            {
                Date = adjustment.Date,
                BudgetNO = adjustment.ContractNO,
                CreateDate = adjustment.CreateDate,
                PaymentMoney = paymentMoney,
                Currency = adjustment.Currency,
                VoucherNo = adjustment.VoucherNo,
                MoneyUsed = adjustment.MoneyUsed,
                CNY = CNY,
                IsUSD = isUSD,
                USD = USD,
                IsPayment = IsPayment.ToString(),
                IsDrawback = adjustment.IsDrawback,
                RecieptMoney = recieptMoney,
                ExchangeRate = adjustment.ExchangeRate,
                Company = $"{adjustment.Type.ToString()}{priex}调出至{contracts},{name}【{adjustment.Name}】",
                AdjustmentType = (int)adjustment.Type + 1
            };
        }

        public static AccountBill ToToAccountBill(this AccountAdjustmentDetail adjustmentDetail)
        {
            bool isUSD = false;
            decimal paymentMoney = 0;
            decimal CNY = 0;
            decimal recieptMoney = 0;
            decimal USD = 0;
            bool IsPayment = false;
            string name = string.Empty;
            if (adjustmentDetail.Type == AdjustmentType.付款)
            {
                name = "供应商";
                isUSD = adjustmentDetail.Currency == "美元";
                CNY = adjustmentDetail.CNY * -1;
                USD = adjustmentDetail.OriginalCoin * -1;
                paymentMoney = adjustmentDetail.OriginalCoin;
                IsPayment = true;
            }
            else if (adjustmentDetail.Type == AdjustmentType.收款)
            {
                name = "客户";
                isUSD = adjustmentDetail.Currency == "USD";
                CNY = adjustmentDetail.CNY;
                recieptMoney = adjustmentDetail.OriginalCoin;
                USD = adjustmentDetail.OriginalCoin;
            }
            return new AccountBill()
            {
                Date = adjustmentDetail.Date,
                CreateDate = adjustmentDetail.OperatorDate,
                PaymentMoney = paymentMoney,
                Currency = adjustmentDetail.Currency,
                IsUSD = isUSD,
                USD = USD,
                BudgetNO = adjustmentDetail.MainContractNO,
                IsPayment = IsPayment.ToString(),
                VoucherNo = adjustmentDetail.VoucherNo,
                MoneyUsed = adjustmentDetail.MoneyUsed,
                CNY = CNY,
                IsDrawback = adjustmentDetail.IsDrawback,
                RecieptMoney = recieptMoney,
                ExchangeRate = adjustmentDetail.ExchangeRate,
                Company = $"由{adjustmentDetail.ContractNO}{adjustmentDetail.Type.ToString()}调入至此合同，供应商【{adjustmentDetail.Name}】",
                AdjustmentType = ((int)adjustmentDetail.Type + 1) * 10

            };
        }
    }
}
