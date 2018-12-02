using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BudgetSystem.Entity;

namespace BudgetSystem.Deploy
{
    public partial class frmVersionUpdate : Form
    {
        public frmVersionUpdate()
        {
            InitializeComponent();
        }


        public bool IsSuccess
        {
            get;
            set;
        }

        private void frmVersionUpdate_Load(object sender, EventArgs e)
        {
            this.labInfo.Text = NewSystemInfo.ToString();


            this.IsSuccess = true;
        }


        public SystemInfo NewSystemInfo
        {
            get;
            set;
        }


    }
}
