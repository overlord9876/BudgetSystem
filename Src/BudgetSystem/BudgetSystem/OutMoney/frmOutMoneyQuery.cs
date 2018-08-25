﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BudgetSystem
{
    public partial class frmOutMoneyQuery : frmBaseQueryForm
    {
        public frmOutMoneyQuery()
        {
            InitializeComponent();
            this.CanRefreshData = false;
        }

        public override void RefreshData()
        {
            XtraMessageBox.Show(this.Text);
        }
    }
}
