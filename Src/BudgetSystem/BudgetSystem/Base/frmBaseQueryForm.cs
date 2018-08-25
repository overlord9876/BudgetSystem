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
    public partial class frmBaseQueryForm : frmBaseForm
    {
        public frmBaseQueryForm()
        {
            InitializeComponent();
            this.CanRefreshData = true;
        }


        public virtual bool CanRefreshData 
        {
            get;
            set;
        } 

        public virtual void RefreshData()
        {

        }
    }
}