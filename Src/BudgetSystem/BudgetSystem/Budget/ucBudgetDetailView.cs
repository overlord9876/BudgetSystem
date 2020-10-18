using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BudgetSystem.Entity;
using BudgetSystem.CommonControl;

namespace BudgetSystem
{
    public partial class ucBudgetDetailView : DataControl
    {
        Bll.ModifyMarkManager mmm = new Bll.ModifyMarkManager();
        private Bll.BudgetManager bm = new Bll.BudgetManager();

        public EditFormWorkModels WorkModel
        {
            get;
            set;
        }
        public ucBudgetDetailView()
        {
            InitializeComponent();
            xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(xtraTabControl1_SelectedPageChanged);
            LookUpEditHelper.FillRepositoryItemLookUpEditByEnum_IntValue(this.rilueTradeNature, typeof(EnumTradeNature));
        }

        public override void BindingData(int dataID)
        {
            this.ucBudgetEdit1.WorkModel = WorkModel;
            Budget budget = bm.GetBudget(dataID);
            this.ucBudgetEdit1.BindingBudget(budget);
            xtraTabControl1.TabPages[0].Tag = budget;
            var historyData = mmm.GetAllModifyMark<Budget>(dataID).OrderBy(o => o.UpdateDate);
            //if (historyData != null)
            //{
            //    historyData.ForEach(h => { h.SupplierList = null; h.CustomerList = null; });
            //}
            for (int index = 0; index < historyData.Count() - 1; index++)
            {
                DevExpress.XtraTab.XtraTabPage xtp = new DevExpress.XtraTab.XtraTabPage();
                xtp.Text = string.Format("{0}（{1}）", historyData.ElementAt(index).ContractNO, index + 1);
                xtp.Tag = historyData.ElementAt(index);
                this.xtraTabControl1.TabPages.Add(xtp);
            }
            this.gridBudget.DataSource = historyData.ToList();
            this.gvBudget.BestFitColumns();
        }

        private void gvBudget_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == gcContractNO || e.Column == gcCustomerName || e.Column == gcUpdateDate || e.RowHandle <= 0)
            {
                return;
            }
            else if (!e.CellValue.Equals(gvBudget.GetRowCellValue(e.RowHandle - 1, e.Column)))
            {
                e.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
                e.Appearance.ForeColor = System.Drawing.Color.Red;
                e.Appearance.Options.UseFont = true;
                e.Appearance.Options.UseForeColor = true;
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            var budget = e.Page.Tag as Budget;
            if (budget != null)
            {
                e.Page.Controls.Add(ucBudgetEdit1);
                ucBudgetEdit1.BindingBudget(budget);
            }
        }

    }
}
