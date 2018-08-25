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
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {


            RunInfo.Instance.Config.UserName = this.txtUserName.Text;
            RunInfo.Instance.Config.Save();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.txtUserName.Text = RunInfo.Instance.Config.UserName;
        }
    }
}