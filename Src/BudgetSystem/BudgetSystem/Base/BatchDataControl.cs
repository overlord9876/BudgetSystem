using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BudgetSystem.Entity;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Data;

namespace BudgetSystem
{
    public partial class BatchDataControl : DataControl
    {
        public BatchDataControl()
        {
            InitializeComponent();

            this.gvBatchApproveData.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(gvBatchApproveData_CustomSummaryCalculate);
        }

        decimal customSummary = 0;
        void gvBatchApproveData_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            SummaryItemType summaryType = (e.Item as DevExpress.XtraGrid.GridSummaryItem).SummaryType;
            GridView gridView = sender as GridView;
            // Initialization 
            if (e.SummaryProcess == CustomSummaryProcess.Start)
            {
                customSummary = 0;
            }
            // Calculation 
            if (e.SummaryProcess == CustomSummaryProcess.Calculate)
            {
                if (summaryType == SummaryItemType.Custom)
                {
                    bool isSelected = (bool)gridView.GetRowCellValue(e.RowHandle, gcIsSelected);

                    if (isSelected) customSummary += Convert.ToInt32(e.FieldValue);
                }
            }
            // Finalization 
            if (e.SummaryProcess == CustomSummaryProcess.Finalize)
            {
                if (summaryType == SummaryItemType.Custom)
                {
                    e.TotalValue = customSummary;
                }
            }
        }


        Bll.BudgetManager bm;
        Bll.SupplierManager sm;
        Bll.ReceiptMgmtManager rm;
        Bll.PaymentNotesManager pm;


        public void BindingBachData(List<FlowItem> items)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IsSelected", typeof(bool));
            dt.Columns.Add("DataText");
            dt.Columns.Add("DataDesc");
            dt.Columns.Add("Money", typeof(decimal));

            InitBusinessObject(items[0].DateItemType);
            InitBatchApproveColumn(items[0].DateItemType);

            foreach (FlowItem item in items)
            {
                decimal money = 0;
                BatchApproveDataItemDesc iv = GetItemDesc(item.DateItemType, item.DateItemID);
                dt.Rows.Add(false, item.DateItemText, iv.Desc, iv.Money);
            }

            this.gdBatchApproveData.DataSource = dt;

        }

        private void InitBusinessObject(string dataType)
        {
            if (dataType == EnumFlowDataType.预算单.ToString())
            {
                bm = new Bll.BudgetManager();
            }
            else if (dataType == EnumFlowDataType.供应商.ToString())
            {
                sm = new Bll.SupplierManager();
            }
            else if (dataType == EnumFlowDataType.付款单.ToString())
            {
                pm = new Bll.PaymentNotesManager();
            }
            else if (dataType == EnumFlowDataType.收款单.ToString())
            {
                rm = new Bll.ReceiptMgmtManager();
            }
        }

        private void InitBatchApproveColumn(string dataType)
        {
            if (dataType == EnumFlowDataType.供应商.ToString())
            {
                this.gcMoney.Visible = false;
            }
        }

        private BatchApproveDataItemDesc GetItemDesc(string dataType, int dataId)
        {
            BatchApproveDataItemDesc item = new BatchApproveDataItemDesc();


            if (dataType == EnumFlowDataType.预算单.ToString())
            {
                Budget b = bm.GetBudget(dataId);
                if (b != null)
                {
                    item.Money = b.TotalAmount;
                    item.Desc = b.ToDesc();
                }
            }
            else if (dataType == EnumFlowDataType.供应商.ToString())
            {
                Supplier s = sm.GetSupplier(dataId);

                item.Desc = s != null ? s.ToDesc() : string.Empty;

            }
            else if (dataType == EnumFlowDataType.付款单.ToString())
            {
                PaymentNotes pn = pm.GetPaymentNoteById(dataId);
                if (pn != null)
                {
                    item.Money = pn.CNY;
                    item.Desc = pn.ToDesc();
                }

            }
            else if (dataType == EnumFlowDataType.收款单.ToString())
            {
                BankSlip bs = rm.GetBankSlipByBSID(dataId);
                if (bs != null)
                {
                    item.Money = bs.CNY;
                    item.Desc = bs.ToDesc();
                }

            }
            return item;
        }



        private class BatchApproveDataItemDesc
        {
            public BatchApproveDataItemDesc()
            {
                this.Desc = "";
                this.Money = 0;
            }
            public string Desc
            {
                get;
                set;
            }

            public decimal Money
            {
                get;
                set;
            }
        }
    }
}
