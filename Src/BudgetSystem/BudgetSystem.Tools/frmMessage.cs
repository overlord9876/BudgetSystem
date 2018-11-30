using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BudgetSystem.Tools
{
    public partial class frmMessage : Form
    {
        public frmMessage()
        {
            InitializeComponent();
        }

        public static void ShowMessage(string message)
        {
            frmMessage form = new frmMessage();
            form.StartPosition = FormStartPosition.CenterParent;
            form.txtMessage.Text = message;
            form.ShowDialog();
        
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.txtMessage.Text.Trim());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
