using System;
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

        public EditFormWorkModels WorkModel
        {
            get;
            set;
        }
        public ucBudgetDetailView()
        {
            InitializeComponent();
            LookUpEditHelper.FillRepositoryItemLookUpEditByEnum_IntValue(this.rilueTradeNature, typeof(EnumTradeNature));
        }

        public override void BindingData(int dataID)
        {
            this.ucBudgetEdit1.WorkModel = WorkModel;
            this.ucBudgetEdit1.BindingData(dataID);
            List<Budget> historyData = mmm.GetAllModifyMark<Budget>(dataID);
            //if (historyData != null)
            //{
            //    historyData.ForEach(h => { h.SupplierList = null; h.CustomerList = null; });
            //}
            this.gridBudget.DataSource = historyData;
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

    }
}
