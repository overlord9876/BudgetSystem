using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BudgetSystem.Base
{
    public partial class frmBaseCommonReportForm : frmBaseQueryForm
    {
        public frmBaseCommonReportForm()
        {
            InitializeComponent();
        }

        private void frmBaseCommonReportForm_Load(object sender, EventArgs e)
        {

        }


        protected bool supportPivotGrid = true;
        protected bool supportPivotGridSaveView = true;

        protected List<string> GridToolBarActions = new List<string>();
        protected List<string> PrivotToolBarActions = new List<string>();

        protected void Init()
        { 
        
        
        }

    }
}
