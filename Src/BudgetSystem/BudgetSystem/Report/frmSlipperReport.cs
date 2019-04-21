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
using BudgetSystem.Entity.QueryCondition;

namespace BudgetSystem.Report
{
    public partial class frmSlipperReport : Base.frmBaseCommonReportForm
    {
        public frmSlipperReport()
        {
            InitializeComponent();
            this.Module = BusinessModules.SlipperReport;
            InitSlipperReportGrid();
        }

        protected override void InitLayout()
        {
            base.InitModelOperate();
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

        protected override void LoadDataByCondition(BudgetQueryCondition condition)
        {
            Bll.ReportManager um = new Bll.ReportManager();

            var lst = um.GetSupplierReportList(condition);

            this.pivotGridControl.DataSource = lst;
            this.gridControl.DataSource = lst;
        }

        private void InitSlipperReportGrid()
        {
            base.CreateGridColumn("供应商名称", "Name");
            base.CreateGridColumn("已付原币金额", "OriginalCoin");
            base.CreateGridColumn("人民币", "TotalCNY");
            base.CreateGridColumn("汇率", "ExchangeRate");
            base.CreateGridColumn("已收发票金额", "InvoiceTotal");
            base.CreatePivotGridField("供应商名称", "Name");
            base.CreatePivotGridField("已付原币金额", "OriginalCoin", valueFormatType: FormatType.Custom, formatProvider: new MyDecimalFormat());
            base.CreatePivotGridField("人民币", "TotalCNY");
            base.CreatePivotGridField("汇率", "ExchangeRate");
            base.CreatePivotGridField("已收发票金额", "InvoiceTotal");
            base.CreatePivotGridDefaultRowField();
        }
    }
}
