using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Newtonsoft.Json;
using BudgetSystem.Entity;
using DevExpress.XtraEditors;
using System.Text.RegularExpressions;

namespace BudgetSystem
{
    public partial class frmRevokeDescription : frmBaseDialogForm
    {
        public Budget CurrentBudget { get; set; }

        public frmRevokeDescription()
        {
            InitializeComponent();
        }

        #region Event Method

        private void frmRevokeDescription_Load(object sender, EventArgs e)
        {
            if (IsDesignMode)
            {
                return;
            }

            this.Text = string.Format("退回修改【{0}】", CurrentBudget.ContractNO);
        }

        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtApplyDetail.Text.Trim()))
            {
                XtraMessageBox.Show("请输入退回修改意见。", "提示");
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public string Description()
        {
            return this.txtApplyDetail.Text.Trim();
        }
    }
}
