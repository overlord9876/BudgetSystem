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
    public partial class frmInMoneyReport : Base.frmBaseCommonReportForm
    {
        public frmInMoneyReport()
        {
            InitializeComponent();
        }

        protected override void InitData()
        {
            this.supportPivotGrid = true;
            this.supportPivotGridSaveView = true;
        }


        private void frmTestReport1_Load(object sender, EventArgs e)
        {
            InitShowStyle();
        }

        public override void LoadData()
        {
            Bll.ReceiptMgmtManager arm = new Bll.ReceiptMgmtManager();
            var lst = arm.GetAllBankSlipList(); 
            base.CreateGridColumn("合同号", "ContractNO");
            base.CreateGridColumn("客户名称", "Remitter");
            base.CreateGridColumn("银行凭证号", "VoucherNo");
            base.CreateGridColumn("实收原币金额", "OriginalCoin");
            base.CreateGridColumn("币种", "Currency");
            base.CreateGridColumn("实收人民币金额", "CNY");
            base.CreateGridColumn("支付方式", "PaymentMethod");
            base.CreateGridColumn("银行", "BankName");
            base.CreateGridColumn("收汇日期", "ReceiptDate");
            base.CreateGridColumn("汇率", "ExchangeRate");
            base.CreateGridColumn("创建人", "CreateUser");
            base.CreateGridColumn("创建时间", "CreateTimestamp");
            base.gridControl.DataSource = lst; 
            base.CreatePivotGridField("合同号", "ContractNO");
            base.CreatePivotGridField("客户名称", "Remitter");
            base.CreatePivotGridField("银行凭证号", "VoucherNo");
            base.CreatePivotGridField("实收原币金额", "OriginalCoin");
            base.CreatePivotGridField("币种", "Currency");
            base.CreatePivotGridField("实收人民币金额", "CNY");
            base.CreatePivotGridField("支付方式", "PaymentMethod");
            base.CreatePivotGridField("银行", "BankName");
            base.CreatePivotGridField("收汇日期", "ReceiptDate", valueFormatType: FormatType.DateTime, valueFormatString: "D");
            base.CreatePivotGridField("汇率", "ExchangeRate");
            base.CreatePivotGridField("创建人", "CreateUser");
            base.CreatePivotGridField("创建时间", "CreateTimestamp", valueFormatType: FormatType.DateTime, valueFormatString: "D");  
            base.CreatePivotGridDefaultRowField();

            this.pivotGridControl.DataSource = lst;
        }


        protected override void InitModelOperate()
        {
            base.InitModelOperate();
        }
    }
}
