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
            this.ucBudgetEdit1.InitData();
            this.ucBudgetEdit1.WorkModel = WorkModel;
            this.ucBudgetEdit1.BindingData(dataID);
            List<Budget> historyData = mmm.GetAllModifyMark<Budget>(dataID);
            if (historyData != null)
            {
                historyData.ForEach(h => { h.SupplierList = null; h.CustomerList = null; });
            }
            this.gridBudget.DataSource = historyData;
        }
    }
}
