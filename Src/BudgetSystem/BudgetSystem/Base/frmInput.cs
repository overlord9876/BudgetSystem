using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BudgetSystem.Base
{
    public partial class frmInput : DevExpress.XtraEditors.XtraForm
    {
        public frmInput(string caption,string info,string defaultValue="")
        {
            InitializeComponent();
            this.Text = caption;
            this.labInfo.Text = info;
            this.txtInput.Text = defaultValue;
        }

        public string Result
        {
            get;
            set;
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            this.dxErrorProvider1.ClearErrors();
            if (string.IsNullOrEmpty(this.txtInput.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtInput, "请输入内容");
                return;
            }

            this.Result = this.txtInput.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}