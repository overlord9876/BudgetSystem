using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BudgetSystem.Entity;

namespace BudgetSystem
{
    public partial class BatchDataControl : DataControl
    {
        public BatchDataControl()
        {
            InitializeComponent();

        }


        Bll.BudgetManager bm;
        Bll.SupplierManager sm;
        Bll.ReceiptMgmtManager rm;
        Bll.PaymentNotesManager pm;


        public void BindingBachData(List<FlowItem> items)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DataText");
            dt.Columns.Add("DataDesc");
            dt.Columns.Add("Money", typeof(decimal));

            InitBusinessObject(items[0].DateItemType);

            foreach (FlowItem item in items)
            {
                decimal money = 0;
                string description = GetItemDesc(item.DateItemType, item.DateItemID, out money);
                dt.Rows.Add(item.DateItemText, description, money);

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


        private string GetItemDesc(string dataType, int dataId, out decimal money)
        {
            money = 0;
            if (dataType == EnumFlowDataType.预算单.ToString())
            {
                Budget b = bm.GetBudget(dataId);
                if (b != null)
                {
                    money = b.TotalAmount;
                    return b.ToDesc();
                }
                else
                {
                    return string.Empty;
                }

            }
            else if (dataType == EnumFlowDataType.供应商.ToString())
            {
                Supplier s = sm.GetSupplier(dataId);
                return s != null ? s.ToDesc() : string.Empty;
            }
            else if (dataType == EnumFlowDataType.付款单.ToString())
            {
                PaymentNotes pn = pm.GetPaymentNoteById(dataId);
                if (pn != null)
                {
                    money = pn.CNY;
                    return pn.ToDesc();
                }
                else
                {
                    return string.Empty;
                }
            }
            else if (dataType == EnumFlowDataType.收款单.ToString())
            {
                BankSlip bs = rm.GetBankSlipByBSID(dataId);
                if (bs != null)
                {
                    money = bs.CNY;
                    return bs.ToDesc();
                }
                else { return string.Empty; }
            }
            return string.Empty;
        }

    }
}
