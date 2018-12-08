﻿using System;
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

            InitBusinessObject(items[0].DateItemType);

            foreach (FlowItem item in items)
            {
                dt.Rows.Add(item.DateItemText, GetItemDesc(item.DateItemType,item.DateItemID));
                
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


        private string GetItemDesc(string dataType,int dataId)
        {
            return "Desc";
            //if (dataType == EnumFlowDataType.预算单.ToString())
            //{
            //    return bm.xxx(dataId);
            //}
            //else if (dataType == EnumFlowDataType.供应商.ToString())
            //{
            //    return sm.xxx(dataId);
            //}
            //else if (dataType == EnumFlowDataType.付款单.ToString())
            //{
            //    return pm.xxx(dataId);
            //}
            //else if (dataType == EnumFlowDataType.收款单.ToString())
            //{
            //    return rm.xxx(dataId);
            //}
        }

    }
}
