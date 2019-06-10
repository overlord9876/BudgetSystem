using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;
using Newtonsoft.Json;

namespace BudgetSystem
{
    public partial class frmSupplierReviewHistory : frmBaseDialogForm
    {
        int supplierID = 0;
        public frmSupplierReviewHistory(int supplierID)
        {
            InitializeComponent();
            this.supplierID = supplierID;
        }

        private void frmSupplierReviewHistory_Load(object sender, EventArgs e)
        {
            List<SupplierReviewContents> list = new Bll.ModifyMarkManager().GetAllModifyMark<SupplierReviewContents>(supplierID);
            this.gridSupplier.DataSource = list;
        }

    }
}