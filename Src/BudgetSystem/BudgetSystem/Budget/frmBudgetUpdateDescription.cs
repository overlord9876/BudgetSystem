using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BudgetSystem
{
    public partial class frmBudgetUpdateDescription : DevExpress.XtraEditors.XtraForm
    {
        public string Description { get; private set; }

        public frmBudgetUpdateDescription()
        {
            InitializeComponent();
            this.Icon = BudgetSystem.Properties.Resources.logo;
        }

        private void btn_Commit_Click(object sender, EventArgs e)
        {
            this.Description = this.txtDescription.Text.Trim();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}