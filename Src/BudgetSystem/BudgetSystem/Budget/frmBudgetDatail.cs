using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Newtonsoft.Json;
using BudgetSystem.Entity;
using DevExpress.XtraEditors;
using System.Text.RegularExpressions;

namespace BudgetSystem
{
    public partial class frmBudgetDatail : frmBaseDialogForm
    {
        public Budget CurrentBudget { get; set; }

        private Bll.BudgetManager bm = new Bll.BudgetManager();
        public frmBudgetDatail()
        {
            InitializeComponent();
        }

        protected override void SubmitNewData()
        {
            base.SubmitNewData();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected override void SubmitModifyData()
        {
            base.SubmitModifyData();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        #region Event Method

        private void frmBudgetDatail_Load(object sender, EventArgs e)
        {
            this.ucBudgetDetailView1.WorkModel = EditFormWorkModels.View;
            this.WorkModel = EditFormWorkModels.View;
            this.ucBudgetDetailView1.BindingData(CurrentBudget.ID);
            if (this.WorkModel == EditFormWorkModels.View)
            {
                this.Text = "查看预算单信息";
            }
        }

        #endregion
    }
}
