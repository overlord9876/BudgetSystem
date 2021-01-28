using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BudgetSystem.Util;

namespace BudgetSystem.InMoney
{
    public partial class frmCostForm : frmBaseForm
    { 
        public frmCostForm()
        {
            InitializeComponent(); 
        }

        public void PrintData(List<Invoice> dataSource)
        {
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.LookAndFeel.SkinName = "Whiteprint";
            this.gridInvoice.DataSource = dataSource;
            this.Visible = false;
            this.Show();
            PrinterHelper.PrintControl(true, this.gridInvoice, Size.Empty);
            this.Close();
        }
    }
}
