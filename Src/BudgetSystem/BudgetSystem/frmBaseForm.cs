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
    public partial class frmBaseForm : XtraForm
    {
        public frmBaseForm()
        {
            InitializeComponent();
        }

        public bool CanRefreshData
        {
            get;
            set;
        }

        public void RefreshData()
        { 
        
        }
    }
}
