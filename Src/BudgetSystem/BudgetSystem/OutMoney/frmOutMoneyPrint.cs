using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;
using BudgetSystem.Bll;
using Newtonsoft.Json;

namespace BudgetSystem.OutMoney
{
    public partial class frmOutMoneyPrint : frmBaseDialogForm
    {
        private Bll.SystemConfigManager scm = new Bll.SystemConfigManager();
        CommonManager cm = new CommonManager();
        Bll.FlowManager fm = new FlowManager();
        PaymentNotesManager pnm = new PaymentNotesManager();
        BudgetManager bm = new BudgetManager();
        ReceiptMgmtManager rm = new ReceiptMgmtManager();
        SupplierManager sm = new SupplierManager();
        public PaymentNotes CurrentPaymentNotes { get; set; }

        public frmOutMoneyPrint()
        {
            InitializeComponent();
        }

        private void frmOutMoneyPrint_Load(object sender, EventArgs e)
        {
            this.Text = "付款信息打印";
            if (CurrentPaymentNotes != null)
            {
                foreach (var control in this.layoutControl1.Controls)
                {
                    if (control is BaseEdit)
                    {
                        (control as BaseEdit).Properties.ReadOnly = true;
                    }
                }

                Budget currentBudget = bm.GetBudget(CurrentPaymentNotes.BudgetID);

                var paymentNotes = pnm.GetTotalAmountPaymentMoneyByBudgetId(CurrentPaymentNotes.BudgetID);
                //过滤当前自己的单据
                if (CurrentPaymentNotes != null)
                {
                    paymentNotes = paymentNotes.Where(o => o.ID != CurrentPaymentNotes.ID);
                }
                var receiptList = rm.GetBudgetBillListByBudgetId(currentBudget.ID);

                Supplier supplier = sm.GetSupplier(CurrentPaymentNotes.SupplierID);

                var useMoneTypeList = scm.GetSystemConfigValue<List<UseMoneyType>>(EnumSystemConfigNames.用款类型.ToString());
                OutMoneyCaculator caculator = new OutMoneyCaculator(currentBudget, paymentNotes, receiptList, CurrentPaymentNotes.VatOption, useMoneTypeList);

                caculator.ApplyForPayment(this.CurrentPaymentNotes.CNY, (decimal)this.CurrentPaymentNotes.TaxRebateRate, this.CurrentPaymentNotes.IsDrawback);

                labelControl3.Text = CurrentPaymentNotes.VoucherNo;
                this.labelControl2.Text = this.CurrentPaymentNotes.CommitTime.ToString("yyyy年MM月dd日");
                this.txtBudget.Text = this.CurrentPaymentNotes.ContractNO;
                this.chkIsIOU.Checked = this.CurrentPaymentNotes.IsIOU && !this.CurrentPaymentNotes.RepayLoan;
                this.txtMoneyUsed.Text = this.CurrentPaymentNotes.MoneyUsed;
                this.chkIsDrawback_Yes.Checked = this.CurrentPaymentNotes.IsDrawback;
                this.chkIsDrawback_No.Checked = !this.CurrentPaymentNotes.IsDrawback;
                this.chkHasInvoice_Yes.Checked = this.CurrentPaymentNotes.HasInvoice;
                this.chkHasInvoice_No.Checked = !this.CurrentPaymentNotes.HasInvoice;

                if (!string.IsNullOrEmpty(this.CurrentPaymentNotes.InvoiceNumber))
                {
                    List<InvoiceInfo> invoiceInfoList = this.CurrentPaymentNotes.InvoiceNumber.ToObjectList<List<InvoiceInfo>>();
                    string invoiceInfo = string.Empty;
                    foreach (var invoice in invoiceInfoList)
                    {
                        invoiceInfo = invoiceInfo + invoice.InvoiceNumber + ",";
                    }
                    if (invoiceInfo.EndsWith(","))
                    {
                        invoiceInfo = invoiceInfo.Substring(0, invoiceInfo.Length - 1);
                    }
                    txtInvoiceNumber.Text = invoiceInfo;
                }
                else
                {
                    lciInvoiceNumber.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }

                this.txtSupplier.Text = this.CurrentPaymentNotes.SupplierName;
                this.txtBankName.Text = this.CurrentPaymentNotes.BankName;
                this.txtBankNO.Text = this.CurrentPaymentNotes.BankNO;
                this.chkIsQualified.Checked = supplier.IsQualified;
                this.txtAccountBalance.Text = caculator.AccountBalance.ToString();
                if (caculator.AdvancePayment == 0)
                {
                    this.txtAdvancePayment.Text = "无预付款";
                }
                else
                {
                    this.txtAdvancePayment.Text = caculator.CompressAdvancePayment.ToString();
                }
                this.txtAmountTaxRebate.Text = Math.Round(caculator.AllTaxes, 2).ToString();

                this.txtPaymentMethod.Text = this.CurrentPaymentNotes.PaymentMethod;
                string currency = this.CurrentPaymentNotes.Currency;
                string currencyChar = "";//"￥";
                //if (!string.IsNullOrEmpty(this.CurrentPaymentNotes.Currency) && this.CurrentPaymentNotes.Currency.Equals("USD"))
                //{
                //    currency = "美元";
                //    currencyChar = "$";
                //}

                UserManager um = new UserManager();
                this.txtOriginalCoinBig.Text = currency + StringUtil.MoneyToUpper(Math.Round(this.CurrentPaymentNotes.OriginalCoin, 2).ToString());
                this.txtOriginalCoin.Text = currencyChar + Math.Round(this.CurrentPaymentNotes.OriginalCoin, 2).ToString();
                User u = um.GetUser(CurrentPaymentNotes.Applicant);
                this.txtApplicant.Text = u != null ? u.ToString() : CurrentPaymentNotes.Applicant;
                this.txtPayingBank.Text = this.CurrentPaymentNotes.PayingBank;
                List<FlowRunPoint> points = fm.GetIsRecentFlowRunPointsByData(CurrentPaymentNotes.ID, EnumFlowDataType.付款单.ToString());
                string applyList = string.Empty;
                for (int index = 0; index < points.Count; index++)
                {
                    FlowRunPoint frp = points[index];
                    if (frp.State)
                    {
                        FlowApproveDisplayHelper.SetRunPointFlowNodeApproveResultWithStateDisplayName(frp, string.Empty);
                        applyList += string.Format("{0}-{1}【{2}】", frp.NodeValueRemark, frp.NodeApproveUser, frp.RealName);
                        if (index < points.Count - 1)
                        {
                            applyList += "-->";
                        }
                    }
                }
                this.txtApplyList.Text = applyList;

                this.txtDescription.Text = this.CurrentPaymentNotes.Description;
                textEdit18.Text = "QR-211-02";
                textEdit19.Text = cm.GetDateTimeNow().ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            SubmitDataByWorkModel();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        public override void PrintData()
        {
            //this.Height -= 50;
            this.labelControl1.Focus();
            PrinterHelper.PrintControl(false, this.layoutControl2, false, System.Drawing.Printing.PaperKind.Custom);
        }
    }
}