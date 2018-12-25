using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Bll;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BudgetSystem.Entity;
using BudgetSystem.Entity.QueryCondition;

namespace BudgetSystem.InMoney
{
    public partial class frmInMoneyDetailExport : frmBaseQueryForm
    {
        ReceiptMgmtManager arm = new ReceiptMgmtManager();

        public frmInMoneyDetailExport()
        {
            InitializeComponent();
        }

        public void ExportData()
        {

            this.gcInMoney.DataSource = arm.GetBudgetBillListByCondition();
            this.gvInMoney.RefreshData();
            this.Visible = false;

            if (saveFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            this.gcInMoney.ExportToXls(saveFileDialog1.FileName);
        }
    }
}
