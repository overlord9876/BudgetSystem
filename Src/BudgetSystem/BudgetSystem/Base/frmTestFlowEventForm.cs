using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BudgetSystem.Entity;
using BudgetSystem.Bll;
using DevExpress.XtraEditors;

namespace BudgetSystem.Base
{
    public partial class frmTestFlowEventForm : BudgetSystem.Base.frmBaseFlowEventForm
    {
        Bll.SystemConfigManager scm = new Bll.SystemConfigManager();
        PaymentNotesManager pnm = new PaymentNotesManager();
        public frmTestFlowEventForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmTestFlowEventForm_Load);
        }

        private void frmTestFlowEventForm_Load(object sender, EventArgs e)
        {

            List<string> bankNameList = scm.GetSystemConfigValue<List<string>>(EnumSystemConfigNames.银行名称.ToString());
            if (bankNameList != null)
            {
                foreach (var bankName in bankNameList)
                {
                    cboPayingBank.Properties.Items.Add(bankName);
                }
            }
            if (ReleateFlowItems != null && ReleateFlowItems.Count > 0)
            {
                PaymentNotes paymentNode = pnm.GetPaymentNoteById(ReleateFlowItems[0].DateItemID);
                if (paymentNode != null)
                {
                    cboPayingBank.EditValue = paymentNode.PayingBank;
                }
            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            dxErrorProvider1.ClearErrors();
            if (cboPayingBank.EditValue == null || string.IsNullOrEmpty(cboPayingBank.EditValue.ToString()))
            {
                dxErrorProvider1.SetError(cboPayingBank, "请选择付款银行");
            }
            if (dxErrorProvider1.HasErrors) { return; }
            string payingBank = cboPayingBank.EditValue.ToString();
            try
            {
                foreach (FlowItem item in ReleateFlowItems)
                {
                    pnm.ModifyPaymentNotePayingBankName(item.DateItemID, payingBank);
                }
            }
            catch (Exception ex)
            {
                RunInfo.Instance.Logger.LogError(ex);
                XtraMessageBox.Show("保存失败。");
                this.EventResult = null;
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                return;
            }
            this.EventResult = true;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }
    }
}
