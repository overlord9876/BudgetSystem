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
    public partial class frmPaymentNotes : frmBaseQueryForm
    {
        public frmPaymentNotes()
        {
            InitializeComponent();
        }

        public override void RefreshData()
        {
            XtraMessageBox.Show(this.Text);
        }

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}