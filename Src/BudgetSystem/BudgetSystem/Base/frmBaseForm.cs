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
    public partial class frmBaseForm : DevExpress.XtraEditors.XtraForm
    {
        public frmBaseForm()
        {
            InitializeComponent();
        }


        public virtual void LoadData()
        { 
        
        }
    }
}