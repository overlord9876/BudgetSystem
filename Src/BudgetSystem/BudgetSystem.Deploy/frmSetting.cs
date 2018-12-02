using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BudgetSystem.Deploy
{
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtConnectoinString.Text.Trim()))
            {
                MessageBox.Show("请输入服务器连接");
                return;
            }
            Connection = this.txtConnectoinString.Text.Trim();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }


        public string Connection
        {
            get;
            private set;
        }
    }
}
