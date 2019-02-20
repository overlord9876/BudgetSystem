using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using BudgetSystem.Entity;
using DevExpress.XtraPivotGrid;
using DevExpress.Utils;

namespace BudgetSystem.Report
{
    public partial class frmSlipperReport : Base.frmBaseCommonReportForm
    {
        public frmSlipperReport()
        {
            InitializeComponent();
            this.Module = BusinessModules.SlipperReport;
        }

        protected override void InitLayout()
        {
            base.InitModelOperate();

            InitSlipperReportGrid();
        }

        protected override void InitModelOperate()
        {
            this.supportPivotGrid = true;
            this.supportPivotGridSaveView = true;
        }
        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {
            base.OperateHandled(operate, e);
        }

        private void frmTestReport1_Load(object sender, EventArgs e)
        {
            InitShowStyle();
        }

        public override void LoadData()
        {
            SupplierReport();
        }

        private void SupplierReport()
        {
            Bll.ReportManager um = new Bll.ReportManager();
            var lst = um.GetSupplierReportList(new DateTime(2018, 1, 1), new DateTime(2020, 1, 1));

            this.pivotGridControl.DataSource = lst;
        }

        private void InitSlipperReportGrid()
        {
            base.CreateGridColumn("供应商名称", "Name");
            base.CreateGridColumn("已付原币金额", "OriginalCoin");
            base.CreateGridColumn("人民币", "TotalCNY");
            base.CreateGridColumn("汇率", "ExchangeRate");
            base.CreateGridColumn("已收发票金额", "InvoiceTotal");
            base.CreatePivotGridField("供应商名称", "Name");
            base.CreatePivotGridField("已付原币金额", "OriginalCoin");
            base.CreatePivotGridField("人民币", "TotalCNY");
            base.CreatePivotGridField("汇率", "ExchangeRate");
            base.CreatePivotGridField("已收发票金额", "InvoiceTotal");
            base.CreatePivotGridDefaultRowField();
        }
    }
}
