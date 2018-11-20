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
    public partial class frmOutMoneyReport : Base.frmBaseCommonReportForm
    {
        public frmOutMoneyReport()
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
            Bll.PaymentNotesManager pnm = new Bll.PaymentNotesManager();
            var lst = pnm.GetAllPaymentNotes();
            base.CreateGridColumn("供应商", "SupplierName");
            base.CreateGridColumn("合同号", "ContractNO");
            base.CreateGridColumn("付款单号", "VoucherNo");
            base.CreateGridColumn("付款原币金额", "OriginalCoin");
            base.CreateGridColumn("审批状态", "EnumFlowState");
            base.CreateGridColumn("币种", "Currency");
            base.CreateGridColumn("汇率", "ExchangeRate");
            base.CreateGridColumn("付款人民币金额", "CNY");
            base.CreateGridColumn("付款申请人", "Applicant");
            base.CreateGridColumn("提交时间", "CommitTime");
            base.CreateGridColumn("财务确认人", "Approver");
            base.CreateGridColumn("确认时间", "ApproveTime");
            base.CreateGridColumn("付款日期", "PaymentDate");
            base.CreateGridColumn("备注", "Description");
            base.CreateGridColumn("所属部门", "DepartmentName");
            base.CreateGridColumn("用途", "MoneyUsed");
            base.CreateGridColumn("是否退税", "IsDrawback");
            base.CreateGridColumn("是否收到发票", "HasInvoice");
            base.CreateGridColumn("付款方式", "PaymentMethod"); 

            base.gridControl.DataSource = lst;
            base.CreatePivotGridField("供应商", "SupplierName");
            base.CreatePivotGridField("合同号", "ContractNO");
            base.CreatePivotGridField("付款单号", "VoucherNo");
            base.CreatePivotGridField("付款原币金额", "OriginalCoin");
            base.CreatePivotGridField("审批状态", "EnumFlowState");
            base.CreatePivotGridField("币种", "Currency");
            base.CreatePivotGridField("汇率", "ExchangeRate");
            base.CreatePivotGridField("付款人民币金额", "CNY");
            base.CreatePivotGridField("付款申请人", "Applicant");
            base.CreatePivotGridField("提交时间", "CommitTime", valueFormatType: FormatType.DateTime, valueFormatString: "D");
            base.CreatePivotGridField("财务确认人", "Approver");
            base.CreatePivotGridField("确认时间", "ApproveTime", valueFormatType: FormatType.DateTime, valueFormatString: "D");
            base.CreatePivotGridField("付款日期", "PaymentDate", valueFormatType: FormatType.DateTime, valueFormatString: "D");
            base.CreatePivotGridField("备注", "Description");
            base.CreatePivotGridField("所属部门", "DepartmentName");
            base.CreatePivotGridField("用途", "MoneyUsed");
            base.CreatePivotGridField("是否退税", "IsDrawback");
            base.CreatePivotGridField("是否收到发票", "HasInvoice");
            base.CreatePivotGridField("付款方式", "PaymentMethod"); 
            base.CreatePivotGridDefaultRowField();

            this.pivotGridControl.DataSource = lst;
        }


        protected override void InitModelOperate()
        {
            base.InitModelOperate();
        }
    }
}
