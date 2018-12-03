namespace BudgetSystem
{
    partial class ucBudgetEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtExchangeRateView = new BudgetSystem.CommonControl.TextEdit_Number();
            this.txtUSDTotalAmount = new BudgetSystem.CommonControl.TextEdit_Number();
            this.btnSync = new DevExpress.XtraEditors.SimpleButton();
            this.chkTradeMode3 = new DevExpress.XtraEditors.CheckEdit();
            this.chkTradeMode5 = new DevExpress.XtraEditors.CheckEdit();
            this.chkTradeMode2 = new DevExpress.XtraEditors.CheckEdit();
            this.chkTradeMode1 = new DevExpress.XtraEditors.CheckEdit();
            this.chkTradeMode4 = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.luePort = new DevExpress.XtraEditors.LookUpEdit();
            this.pceMainCustomer = new DevExpress.XtraEditors.PopupContainerEdit();
            this.pccCustomer = new DevExpress.XtraEditors.PopupContainerControl();
            this.ucCustomerSelected = new BudgetSystem.ucCustomerSelected();
            this.txtProfitLevel2 = new BudgetSystem.CommonControl.TextEdit_Number();
            this.meDescription = new DevExpress.XtraEditors.MemoEdit();
            this.pccSupplier = new DevExpress.XtraEditors.PopupContainerControl();
            this.ucSupplierSelected = new BudgetSystem.ucSupplierSelected();
            this.txtPurchasePrice = new BudgetSystem.CommonControl.TextEdit_Number();
            this.txtExchangeCost = new BudgetSystem.CommonControl.TextEdit_Number();
            this.txtProfitLevel1 = new BudgetSystem.CommonControl.TextEdit_Number();
            this.txtProfit = new BudgetSystem.CommonControl.TextEdit_Number();
            this.txtNetIncomeCNY = new BudgetSystem.CommonControl.TextEdit_Number();
            this.txtExchangeRate = new BudgetSystem.CommonControl.TextEdit_Number();
            this.txtTotalCost = new BudgetSystem.CommonControl.TextEdit_Number();
            this.txtNetIncome = new BudgetSystem.CommonControl.TextEdit_Number();
            this.txtTaxRebateRateMoney = new BudgetSystem.CommonControl.TextEdit_Number();
            this.txtCommission = new BudgetSystem.CommonControl.TextEdit_Number();
            this.txtPremium = new BudgetSystem.CommonControl.TextEdit_Number();
            this.txtBankCharges = new BudgetSystem.CommonControl.TextEdit_Number();
            this.txtDirectCosts = new BudgetSystem.CommonControl.TextEdit_Number();
            this.txtFeedMoney = new BudgetSystem.CommonControl.TextEdit_Number();
            this.txtSubtotal = new BudgetSystem.CommonControl.TextEdit_Number();
            this.gridOutProductDetail = new DevExpress.XtraGrid.GridControl();
            this.gvOutProductDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ritxtCount = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOriginalCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ricboOriginalCurrency = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gcPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ritxtPrice = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcOriginalCurrencyMoney = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcExchangeRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ritxtExchangeRate = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcCNY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riLinkDelete = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.txtAdvancePayment = new BudgetSystem.CommonControl.TextEdit_Number();
            this.txtPercentage = new BudgetSystem.CommonControl.TextEdit_Number();
            this.txtInterestRate = new BudgetSystem.CommonControl.TextEdit_Number();
            this.txtDays = new BudgetSystem.CommonControl.TextEdit_Number();
            this.txtInterest = new BudgetSystem.CommonControl.TextEdit_Number();
            this.gridInProductDetail = new DevExpress.XtraGrid.GridControl();
            this.bgvInProductDetail = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gcInName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gcInCount = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ritxtInCount = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gcInUnit = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gcRawMaterials = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ritxtRawMaterials = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gcSubsidiaryMaterials = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ritxtSubsidiaryMaterials = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gcProcessCost = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ritxtProcessCost = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridBand8 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gcSubtotal = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ritxtSubtotal = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridBand10 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gcMoneySubtotal = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand13 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gcVat = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ritxtVat = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridBand12 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gcTaxRebateRate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ritxtTaxRebateRate = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridBand11 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gcTaxRebate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand9 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gcInDelete = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.riLinkEditInDelete = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.chkIsQualified = new DevExpress.XtraEditors.CheckEdit();
            this.txtOutSettlementMethod2 = new DevExpress.XtraEditors.TextEdit();
            this.txtOutSettlementMethod = new DevExpress.XtraEditors.TextEdit();
            this.txtTotalAmount = new BudgetSystem.CommonControl.TextEdit_Number();
            this.txtOutSettlementMethod3 = new DevExpress.XtraEditors.TextEdit();
            this.txtPriceClause = new DevExpress.XtraEditors.TextEdit();
            this.rgTradeNature = new DevExpress.XtraEditors.RadioGroup();
            this.dteValidity = new DevExpress.XtraEditors.DateEdit();
            this.dteSignDate = new DevExpress.XtraEditors.DateEdit();
            this.txtSalesman = new DevExpress.XtraEditors.TextEdit();
            this.txtDepartment = new DevExpress.XtraEditors.TextEdit();
            this.txtContractNO = new DevExpress.XtraEditors.TextEdit();
            this.pceCustomer = new DevExpress.XtraEditors.PopupContainerEdit();
            this.pceSupplier = new DevExpress.XtraEditors.PopupContainerEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem32 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem36 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem41 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem44 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem31 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem39 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem38 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem37 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem35 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem34 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem33 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem42 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem45 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem43 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem40 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem47 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem48 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem46 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem49 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtExchangeRateView.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUSDTotalAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTradeMode3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTradeMode5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTradeMode2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTradeMode1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTradeMode4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pceMainCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pccCustomer)).BeginInit();
            this.pccCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProfitLevel2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pccSupplier)).BeginInit();
            this.pccSupplier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchasePrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExchangeCost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProfitLevel1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProfit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNetIncomeCNY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExchangeRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNetIncome.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxRebateRateMoney.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCommission.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPremium.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankCharges.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDirectCosts.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFeedMoney.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubtotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOutProductDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOutProductDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ricboOriginalCurrency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtExchangeRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riLinkDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdvancePayment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercentage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterestRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterest.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInProductDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgvInProductDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtInCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtRawMaterials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtSubsidiaryMaterials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtProcessCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtSubtotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtVat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtTaxRebateRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riLinkEditInDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsQualified.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutSettlementMethod2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutSettlementMethod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutSettlementMethod3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPriceClause.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgTradeNature.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteValidity.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteValidity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteSignDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteSignDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesman.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContractNO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pceCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pceSupplier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtExchangeRateView);
            this.layoutControl1.Controls.Add(this.txtUSDTotalAmount);
            this.layoutControl1.Controls.Add(this.btnSync);
            this.layoutControl1.Controls.Add(this.chkTradeMode3);
            this.layoutControl1.Controls.Add(this.chkTradeMode5);
            this.layoutControl1.Controls.Add(this.chkTradeMode2);
            this.layoutControl1.Controls.Add(this.chkTradeMode1);
            this.layoutControl1.Controls.Add(this.chkTradeMode4);
            this.layoutControl1.Controls.Add(this.labelControl1);
            this.layoutControl1.Controls.Add(this.luePort);
            this.layoutControl1.Controls.Add(this.pceMainCustomer);
            this.layoutControl1.Controls.Add(this.txtProfitLevel2);
            this.layoutControl1.Controls.Add(this.meDescription);
            this.layoutControl1.Controls.Add(this.pccSupplier);
            this.layoutControl1.Controls.Add(this.pccCustomer);
            this.layoutControl1.Controls.Add(this.txtPurchasePrice);
            this.layoutControl1.Controls.Add(this.txtExchangeCost);
            this.layoutControl1.Controls.Add(this.txtProfitLevel1);
            this.layoutControl1.Controls.Add(this.txtProfit);
            this.layoutControl1.Controls.Add(this.txtNetIncomeCNY);
            this.layoutControl1.Controls.Add(this.txtExchangeRate);
            this.layoutControl1.Controls.Add(this.txtTotalCost);
            this.layoutControl1.Controls.Add(this.txtNetIncome);
            this.layoutControl1.Controls.Add(this.txtTaxRebateRateMoney);
            this.layoutControl1.Controls.Add(this.txtCommission);
            this.layoutControl1.Controls.Add(this.txtPremium);
            this.layoutControl1.Controls.Add(this.txtBankCharges);
            this.layoutControl1.Controls.Add(this.txtDirectCosts);
            this.layoutControl1.Controls.Add(this.txtFeedMoney);
            this.layoutControl1.Controls.Add(this.txtSubtotal);
            this.layoutControl1.Controls.Add(this.gridOutProductDetail);
            this.layoutControl1.Controls.Add(this.txtAdvancePayment);
            this.layoutControl1.Controls.Add(this.txtPercentage);
            this.layoutControl1.Controls.Add(this.txtInterestRate);
            this.layoutControl1.Controls.Add(this.txtDays);
            this.layoutControl1.Controls.Add(this.txtInterest);
            this.layoutControl1.Controls.Add(this.gridInProductDetail);
            this.layoutControl1.Controls.Add(this.chkIsQualified);
            this.layoutControl1.Controls.Add(this.txtOutSettlementMethod2);
            this.layoutControl1.Controls.Add(this.txtOutSettlementMethod);
            this.layoutControl1.Controls.Add(this.txtTotalAmount);
            this.layoutControl1.Controls.Add(this.txtOutSettlementMethod3);
            this.layoutControl1.Controls.Add(this.txtPriceClause);
            this.layoutControl1.Controls.Add(this.rgTradeNature);
            this.layoutControl1.Controls.Add(this.dteValidity);
            this.layoutControl1.Controls.Add(this.dteSignDate);
            this.layoutControl1.Controls.Add(this.txtSalesman);
            this.layoutControl1.Controls.Add(this.txtDepartment);
            this.layoutControl1.Controls.Add(this.txtContractNO);
            this.layoutControl1.Controls.Add(this.pceCustomer);
            this.layoutControl1.Controls.Add(this.pceSupplier);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(323, 387, 1151, 769);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1036, 570);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtExchangeRateView
            // 
            this.txtExchangeRateView.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtExchangeRateView.IsSupportNegative = false;
            this.txtExchangeRateView.Location = new System.Drawing.Point(188, 416);
            this.txtExchangeRateView.Name = "txtExchangeRateView";
            this.txtExchangeRateView.Properties.Mask.EditMask = "n";
            this.txtExchangeRateView.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtExchangeRateView.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtExchangeRateView.Properties.NullText = "0.00";
            this.txtExchangeRateView.Properties.ReadOnly = true;
            this.txtExchangeRateView.Size = new System.Drawing.Size(139, 21);
            this.txtExchangeRateView.StyleController = this.layoutControl1;
            this.txtExchangeRateView.TabIndex = 71;
            // 
            // txtUSDTotalAmount
            // 
            this.txtUSDTotalAmount.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtUSDTotalAmount.IsSupportNegative = false;
            this.txtUSDTotalAmount.Location = new System.Drawing.Point(760, 85);
            this.txtUSDTotalAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtUSDTotalAmount.Name = "txtUSDTotalAmount";
            this.txtUSDTotalAmount.Properties.NullText = "0.00";
            this.txtUSDTotalAmount.Properties.ReadOnly = true;
            this.txtUSDTotalAmount.Size = new System.Drawing.Size(139, 21);
            this.txtUSDTotalAmount.StyleController = this.layoutControl1;
            this.txtUSDTotalAmount.TabIndex = 70;
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(946, 171);
            this.btnSync.Margin = new System.Windows.Forms.Padding(2);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(96, 22);
            this.btnSync.StyleController = this.layoutControl1;
            this.btnSync.TabIndex = 69;
            this.btnSync.Text = "同步外贸数据";
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // chkTradeMode3
            // 
            this.chkTradeMode3.Location = new System.Drawing.Point(372, -81);
            this.chkTradeMode3.Margin = new System.Windows.Forms.Padding(2);
            this.chkTradeMode3.Name = "chkTradeMode3";
            this.chkTradeMode3.Properties.Caption = "进料加工";
            this.chkTradeMode3.Size = new System.Drawing.Size(84, 19);
            this.chkTradeMode3.StyleController = this.layoutControl1;
            this.chkTradeMode3.TabIndex = 68;
            // 
            // chkTradeMode5
            // 
            this.chkTradeMode5.Location = new System.Drawing.Point(540, -81);
            this.chkTradeMode5.Margin = new System.Windows.Forms.Padding(2);
            this.chkTradeMode5.Name = "chkTradeMode5";
            this.chkTradeMode5.Properties.Caption = "内贸";
            this.chkTradeMode5.Size = new System.Drawing.Size(76, 19);
            this.chkTradeMode5.StyleController = this.layoutControl1;
            this.chkTradeMode5.TabIndex = 67;
            // 
            // chkTradeMode2
            // 
            this.chkTradeMode2.Location = new System.Drawing.Point(285, -81);
            this.chkTradeMode2.Margin = new System.Windows.Forms.Padding(2);
            this.chkTradeMode2.Name = "chkTradeMode2";
            this.chkTradeMode2.Properties.Caption = "来料加工";
            this.chkTradeMode2.Size = new System.Drawing.Size(83, 19);
            this.chkTradeMode2.StyleController = this.layoutControl1;
            this.chkTradeMode2.TabIndex = 66;
            // 
            // chkTradeMode1
            // 
            this.chkTradeMode1.Location = new System.Drawing.Point(198, -81);
            this.chkTradeMode1.Margin = new System.Windows.Forms.Padding(2);
            this.chkTradeMode1.Name = "chkTradeMode1";
            this.chkTradeMode1.Properties.Caption = "一般贸易";
            this.chkTradeMode1.Size = new System.Drawing.Size(83, 19);
            this.chkTradeMode1.StyleController = this.layoutControl1;
            this.chkTradeMode1.TabIndex = 65;
            // 
            // chkTradeMode4
            // 
            this.chkTradeMode4.Location = new System.Drawing.Point(460, -81);
            this.chkTradeMode4.Margin = new System.Windows.Forms.Padding(2);
            this.chkTradeMode4.Name = "chkTradeMode4";
            this.chkTradeMode4.Properties.Caption = "纯进口";
            this.chkTradeMode4.Size = new System.Drawing.Size(76, 19);
            this.chkTradeMode4.StyleController = this.layoutControl1;
            this.chkTradeMode4.TabIndex = 64;
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(45, -81);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(149, 23);
            this.labelControl1.StyleController = this.layoutControl1;
            this.labelControl1.TabIndex = 63;
            this.labelControl1.Text = "贸易方式：";
            // 
            // luePort
            // 
            this.luePort.Location = new System.Drawing.Point(903, 85);
            this.luePort.Margin = new System.Windows.Forms.Padding(2);
            this.luePort.Name = "luePort";
            this.luePort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luePort.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EnName", "英文名称")});
            this.luePort.Properties.DisplayMember = "EnName";
            this.luePort.Properties.NullText = "";
            this.luePort.Properties.ShowFooter = false;
            this.luePort.Properties.ValueMember = "EnName";
            this.luePort.Size = new System.Drawing.Size(139, 21);
            this.luePort.StyleController = this.layoutControl1;
            this.luePort.TabIndex = 62;
            // 
            // pceMainCustomer
            // 
            this.pceMainCustomer.Location = new System.Drawing.Point(200, -131);
            this.pceMainCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.pceMainCustomer.Name = "pceMainCustomer";
            this.pceMainCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.pceMainCustomer.Properties.PopupControl = this.pccCustomer;
            this.pceMainCustomer.Size = new System.Drawing.Size(842, 21);
            this.pceMainCustomer.StyleController = this.layoutControl1;
            this.pceMainCustomer.TabIndex = 61;
            this.pceMainCustomer.QueryResultValue += new DevExpress.XtraEditors.Controls.QueryResultValueEventHandler(this.pceMainCustomer_QueryResultValue);
            this.pceMainCustomer.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.pceMainCustomer_QueryPopUp);
            // 
            // pccCustomer
            // 
            this.pccCustomer.Controls.Add(this.ucCustomerSelected);
            this.pccCustomer.Location = new System.Drawing.Point(278, 52);
            this.pccCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.pccCustomer.Name = "pccCustomer";
            this.pccCustomer.Size = new System.Drawing.Size(196, 18);
            this.pccCustomer.TabIndex = 58;
            // 
            // ucCustomerSelected
            // 
            this.ucCustomerSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCustomerSelected.Location = new System.Drawing.Point(0, 0);
            this.ucCustomerSelected.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ucCustomerSelected.Name = "ucCustomerSelected";
            this.ucCustomerSelected.Size = new System.Drawing.Size(196, 18);
            this.ucCustomerSelected.TabIndex = 0;
            // 
            // txtProfitLevel2
            // 
            this.txtProfitLevel2.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtProfitLevel2.IsSupportNegative = false;
            this.txtProfitLevel2.Location = new System.Drawing.Point(188, 458);
            this.txtProfitLevel2.Margin = new System.Windows.Forms.Padding(2);
            this.txtProfitLevel2.Name = "txtProfitLevel2";
            this.txtProfitLevel2.Properties.NullText = "0.00";
            this.txtProfitLevel2.Properties.ReadOnly = true;
            this.txtProfitLevel2.Size = new System.Drawing.Size(139, 21);
            this.txtProfitLevel2.StyleController = this.layoutControl1;
            this.txtProfitLevel2.TabIndex = 60;
            this.txtProfitLevel2.ToolTip = "盈利水平=利润/净收入额";
            // 
            // meDescription
            // 
            this.meDescription.Location = new System.Drawing.Point(81, 483);
            this.meDescription.Margin = new System.Windows.Forms.Padding(2);
            this.meDescription.Name = "meDescription";
            this.meDescription.Size = new System.Drawing.Size(961, 46);
            this.meDescription.StyleController = this.layoutControl1;
            this.meDescription.TabIndex = 53;
            // 
            // pccSupplier
            // 
            this.pccSupplier.Controls.Add(this.ucSupplierSelected);
            this.pccSupplier.Location = new System.Drawing.Point(150, 310);
            this.pccSupplier.Margin = new System.Windows.Forms.Padding(2);
            this.pccSupplier.Name = "pccSupplier";
            this.pccSupplier.Size = new System.Drawing.Size(403, 11);
            this.pccSupplier.TabIndex = 59;
            // 
            // ucSupplierSelected
            // 
            this.ucSupplierSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSupplierSelected.Location = new System.Drawing.Point(0, 0);
            this.ucSupplierSelected.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ucSupplierSelected.Name = "ucSupplierSelected";
            this.ucSupplierSelected.Size = new System.Drawing.Size(403, 11);
            this.ucSupplierSelected.TabIndex = 0;
            // 
            // txtPurchasePrice
            // 
            this.txtPurchasePrice.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPurchasePrice.IsSupportNegative = false;
            this.txtPurchasePrice.Location = new System.Drawing.Point(946, 214);
            this.txtPurchasePrice.Margin = new System.Windows.Forms.Padding(2);
            this.txtPurchasePrice.Name = "txtPurchasePrice";
            this.txtPurchasePrice.Properties.NullText = "0.00";
            this.txtPurchasePrice.Properties.ReadOnly = true;
            this.txtPurchasePrice.Size = new System.Drawing.Size(96, 21);
            this.txtPurchasePrice.StyleController = this.layoutControl1;
            this.txtPurchasePrice.TabIndex = 57;
            this.txtPurchasePrice.ToolTip = "内贸合约部分所有行（数量*小计）总和";
            this.txtPurchasePrice.EditValueChanged += new System.EventHandler(this.InProductDetail_EditValueChanged);
            // 
            // txtExchangeCost
            // 
            this.txtExchangeCost.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtExchangeCost.IsSupportNegative = false;
            this.txtExchangeCost.Location = new System.Drawing.Point(331, 458);
            this.txtExchangeCost.Margin = new System.Windows.Forms.Padding(2);
            this.txtExchangeCost.Name = "txtExchangeCost";
            this.txtExchangeCost.Properties.NullText = "0.00";
            this.txtExchangeCost.Properties.ReadOnly = true;
            this.txtExchangeCost.Size = new System.Drawing.Size(282, 21);
            this.txtExchangeCost.StyleController = this.layoutControl1;
            this.txtExchangeCost.TabIndex = 52;
            this.txtExchangeCost.ToolTip = "总成本/合同金额/汇率(USD)";
            // 
            // txtProfitLevel1
            // 
            this.txtProfitLevel1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtProfitLevel1.IsSupportNegative = false;
            this.txtProfitLevel1.Location = new System.Drawing.Point(45, 458);
            this.txtProfitLevel1.Margin = new System.Windows.Forms.Padding(2);
            this.txtProfitLevel1.Name = "txtProfitLevel1";
            this.txtProfitLevel1.Properties.NullText = "0.00";
            this.txtProfitLevel1.Properties.ReadOnly = true;
            this.txtProfitLevel1.Size = new System.Drawing.Size(139, 21);
            this.txtProfitLevel1.StyleController = this.layoutControl1;
            this.txtProfitLevel1.TabIndex = 51;
            this.txtProfitLevel1.ToolTip = "盈利水平1=利润/合同金额/汇率(USD) ";
            // 
            // txtProfit
            // 
            this.txtProfit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtProfit.IsSupportNegative = false;
            this.txtProfit.Location = new System.Drawing.Point(617, 458);
            this.txtProfit.Margin = new System.Windows.Forms.Padding(2);
            this.txtProfit.Name = "txtProfit";
            this.txtProfit.Properties.NullText = "0.00";
            this.txtProfit.Properties.ReadOnly = true;
            this.txtProfit.Size = new System.Drawing.Size(425, 21);
            this.txtProfit.StyleController = this.layoutControl1;
            this.txtProfit.TabIndex = 50;
            this.txtProfit.ToolTip = "利润=折合人名币（净收入额）-总成本-利息（内贸部份）";
            this.txtProfit.EditValueChanged += new System.EventHandler(this.txtProfit_EditValueChanged);
            // 
            // txtNetIncomeCNY
            // 
            this.txtNetIncomeCNY.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtNetIncomeCNY.IsSupportNegative = false;
            this.txtNetIncomeCNY.Location = new System.Drawing.Point(331, 416);
            this.txtNetIncomeCNY.Margin = new System.Windows.Forms.Padding(2);
            this.txtNetIncomeCNY.Name = "txtNetIncomeCNY";
            this.txtNetIncomeCNY.Properties.NullText = "0.00";
            this.txtNetIncomeCNY.Properties.ReadOnly = true;
            this.txtNetIncomeCNY.Size = new System.Drawing.Size(282, 21);
            this.txtNetIncomeCNY.StyleController = this.layoutControl1;
            this.txtNetIncomeCNY.TabIndex = 49;
            this.txtNetIncomeCNY.ToolTip = "净收入额=外贸合约人民币小计-预算小计";
            this.txtNetIncomeCNY.EditValueChanged += new System.EventHandler(this.txtNetIncomeCNY_EditValueChanged);
            // 
            // txtExchangeRate
            // 
            this.txtExchangeRate.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtExchangeRate.IsSupportNegative = false;
            this.txtExchangeRate.Location = new System.Drawing.Point(661, -81);
            this.txtExchangeRate.Margin = new System.Windows.Forms.Padding(2);
            this.txtExchangeRate.Name = "txtExchangeRate";
            this.txtExchangeRate.Properties.NullText = "0.00";
            this.txtExchangeRate.Size = new System.Drawing.Size(141, 21);
            this.txtExchangeRate.StyleController = this.layoutControl1;
            this.txtExchangeRate.TabIndex = 48;
            this.txtExchangeRate.EditValueChanged += new System.EventHandler(this.txtExchangeRate_EditValueChanged);
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtTotalCost.IsSupportNegative = false;
            this.txtTotalCost.Location = new System.Drawing.Point(617, 416);
            this.txtTotalCost.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.Properties.NullText = "0.00";
            this.txtTotalCost.Properties.ReadOnly = true;
            this.txtTotalCost.Size = new System.Drawing.Size(139, 21);
            this.txtTotalCost.StyleController = this.layoutControl1;
            this.txtTotalCost.TabIndex = 47;
            this.txtTotalCost.ToolTip = "总成本=总进价-出口退税额";
            this.txtTotalCost.EditValueChanged += new System.EventHandler(this.txtTotalCost_EditValueChanged);
            // 
            // txtNetIncome
            // 
            this.txtNetIncome.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtNetIncome.IsSupportNegative = false;
            this.txtNetIncome.Location = new System.Drawing.Point(45, 416);
            this.txtNetIncome.Margin = new System.Windows.Forms.Padding(2);
            this.txtNetIncome.Name = "txtNetIncome";
            this.txtNetIncome.Properties.NullText = "0.00";
            this.txtNetIncome.Properties.ReadOnly = true;
            this.txtNetIncome.Size = new System.Drawing.Size(139, 21);
            this.txtNetIncome.StyleController = this.layoutControl1;
            this.txtNetIncome.TabIndex = 46;
            this.txtNetIncome.ToolTip = "折合人名币/汇率";
            this.txtNetIncome.EditValueChanged += new System.EventHandler(this.txtNetIncome_EditValueChanged);
            // 
            // txtTaxRebateRateMoney
            // 
            this.txtTaxRebateRateMoney.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtTaxRebateRateMoney.IsSupportNegative = false;
            this.txtTaxRebateRateMoney.Location = new System.Drawing.Point(760, 416);
            this.txtTaxRebateRateMoney.Margin = new System.Windows.Forms.Padding(2);
            this.txtTaxRebateRateMoney.Name = "txtTaxRebateRateMoney";
            this.txtTaxRebateRateMoney.Properties.NullText = "0.00";
            this.txtTaxRebateRateMoney.Properties.ReadOnly = true;
            this.txtTaxRebateRateMoney.Size = new System.Drawing.Size(282, 21);
            this.txtTaxRebateRateMoney.StyleController = this.layoutControl1;
            this.txtTaxRebateRateMoney.TabIndex = 44;
            this.txtTaxRebateRateMoney.ToolTip = "出口退税额=总进价/1.17*出口退税率";
            this.txtTaxRebateRateMoney.EditValueChanged += new System.EventHandler(this.txtTaxRebateRateMoney_EditValueChanged);
            // 
            // txtCommission
            // 
            this.txtCommission.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCommission.IsSupportNegative = false;
            this.txtCommission.Location = new System.Drawing.Point(45, 374);
            this.txtCommission.Margin = new System.Windows.Forms.Padding(2);
            this.txtCommission.Name = "txtCommission";
            this.txtCommission.Properties.NullText = "0.00";
            this.txtCommission.Size = new System.Drawing.Size(282, 21);
            this.txtCommission.StyleController = this.layoutControl1;
            this.txtCommission.TabIndex = 43;
            this.txtCommission.EditValueChanged += new System.EventHandler(this.Charges_EditValueChanged);
            // 
            // txtPremium
            // 
            this.txtPremium.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPremium.IsSupportNegative = false;
            this.txtPremium.Location = new System.Drawing.Point(331, 374);
            this.txtPremium.Margin = new System.Windows.Forms.Padding(2);
            this.txtPremium.Name = "txtPremium";
            this.txtPremium.Properties.NullText = "0.00";
            this.txtPremium.Size = new System.Drawing.Size(139, 21);
            this.txtPremium.StyleController = this.layoutControl1;
            this.txtPremium.TabIndex = 42;
            this.txtPremium.EditValueChanged += new System.EventHandler(this.Charges_EditValueChanged);
            // 
            // txtBankCharges
            // 
            this.txtBankCharges.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtBankCharges.IsSupportNegative = false;
            this.txtBankCharges.Location = new System.Drawing.Point(474, 374);
            this.txtBankCharges.Margin = new System.Windows.Forms.Padding(2);
            this.txtBankCharges.Name = "txtBankCharges";
            this.txtBankCharges.Properties.NullText = "0.00";
            this.txtBankCharges.Size = new System.Drawing.Size(139, 21);
            this.txtBankCharges.StyleController = this.layoutControl1;
            this.txtBankCharges.TabIndex = 41;
            this.txtBankCharges.EditValueChanged += new System.EventHandler(this.Charges_EditValueChanged);
            // 
            // txtDirectCosts
            // 
            this.txtDirectCosts.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtDirectCosts.IsSupportNegative = false;
            this.txtDirectCosts.Location = new System.Drawing.Point(617, 374);
            this.txtDirectCosts.Margin = new System.Windows.Forms.Padding(2);
            this.txtDirectCosts.Name = "txtDirectCosts";
            this.txtDirectCosts.Properties.NullText = "0.00";
            this.txtDirectCosts.Size = new System.Drawing.Size(139, 21);
            this.txtDirectCosts.StyleController = this.layoutControl1;
            this.txtDirectCosts.TabIndex = 39;
            this.txtDirectCosts.EditValueChanged += new System.EventHandler(this.Charges_EditValueChanged);
            // 
            // txtFeedMoney
            // 
            this.txtFeedMoney.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtFeedMoney.IsSupportNegative = false;
            this.txtFeedMoney.Location = new System.Drawing.Point(760, 374);
            this.txtFeedMoney.Margin = new System.Windows.Forms.Padding(2);
            this.txtFeedMoney.Name = "txtFeedMoney";
            this.txtFeedMoney.Properties.NullText = "0.00";
            this.txtFeedMoney.Size = new System.Drawing.Size(139, 21);
            this.txtFeedMoney.StyleController = this.layoutControl1;
            this.txtFeedMoney.TabIndex = 38;
            this.txtFeedMoney.EditValueChanged += new System.EventHandler(this.Charges_EditValueChanged);
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSubtotal.IsSupportNegative = false;
            this.txtSubtotal.Location = new System.Drawing.Point(903, 374);
            this.txtSubtotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Properties.NullText = "0.00";
            this.txtSubtotal.Properties.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(139, 21);
            this.txtSubtotal.StyleController = this.layoutControl1;
            this.txtSubtotal.TabIndex = 37;
            this.txtSubtotal.ToolTip = "佣金+运保费+银行费用+直接费用+进料款";
            this.txtSubtotal.EditValueChanged += new System.EventHandler(this.txtSubtotal_EditValueChanged);
            // 
            // gridOutProductDetail
            // 
            this.gridOutProductDetail.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridOutProductDetail.Location = new System.Drawing.Point(45, -52);
            this.gridOutProductDetail.MainView = this.gvOutProductDetail;
            this.gridOutProductDetail.Margin = new System.Windows.Forms.Padding(2);
            this.gridOutProductDetail.Name = "gridOutProductDetail";
            this.gridOutProductDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ritxtCount,
            this.ritxtPrice,
            this.ritxtExchangeRate,
            this.riLinkDelete,
            this.ricboOriginalCurrency});
            this.gridOutProductDetail.Size = new System.Drawing.Size(997, 116);
            this.gridOutProductDetail.TabIndex = 36;
            this.gridOutProductDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOutProductDetail});
            this.gridOutProductDetail.Leave += new System.EventHandler(this.gridOutProductDetail_Leave);
            // 
            // gvOutProductDetail
            // 
            this.gvOutProductDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcName,
            this.gcCount,
            this.gcUnit,
            this.gcOriginalCurrency,
            this.gcPrice,
            this.gcOriginalCurrencyMoney,
            this.gcExchangeRate,
            this.gcCNY,
            this.colDelete});
            this.gvOutProductDetail.GridControl = this.gridOutProductDetail;
            this.gvOutProductDetail.Name = "gvOutProductDetail";
            this.gvOutProductDetail.NewItemRowText = "单击此处添加";
            this.gvOutProductDetail.OptionsDetail.EnableMasterViewMode = false;
            this.gvOutProductDetail.OptionsDetail.ShowDetailTabs = false;
            this.gvOutProductDetail.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gvOutProductDetail.OptionsView.ShowGroupPanel = false;
            this.gvOutProductDetail.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvOutProductDetail_CellValueChanged);
            this.gvOutProductDetail.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvOutProductDetail_InvalidRowException);
            this.gvOutProductDetail.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvOutProductDetail_ValidateRow);
            this.gvOutProductDetail.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gvOutProductDetail_ValidatingEditor);
            this.gvOutProductDetail.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.gvOutProductDetail_InvalidValueException);
            // 
            // gcName
            // 
            this.gcName.AppearanceHeader.Options.UseTextOptions = true;
            this.gcName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcName.Caption = "商品规格";
            this.gcName.FieldName = "Name";
            this.gcName.Name = "gcName";
            this.gcName.Visible = true;
            this.gcName.VisibleIndex = 0;
            this.gcName.Width = 141;
            // 
            // gcCount
            // 
            this.gcCount.AppearanceHeader.Options.UseTextOptions = true;
            this.gcCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcCount.Caption = "数量";
            this.gcCount.ColumnEdit = this.ritxtCount;
            this.gcCount.DisplayFormat.FormatString = "n";
            this.gcCount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcCount.FieldName = "Count";
            this.gcCount.Name = "gcCount";
            this.gcCount.Visible = true;
            this.gcCount.VisibleIndex = 1;
            this.gcCount.Width = 141;
            // 
            // ritxtCount
            // 
            this.ritxtCount.AutoHeight = false;
            this.ritxtCount.Name = "ritxtCount";
            // 
            // gcUnit
            // 
            this.gcUnit.AppearanceHeader.Options.UseTextOptions = true;
            this.gcUnit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcUnit.Caption = "单位";
            this.gcUnit.FieldName = "Unit";
            this.gcUnit.Name = "gcUnit";
            this.gcUnit.Visible = true;
            this.gcUnit.VisibleIndex = 2;
            this.gcUnit.Width = 141;
            // 
            // gcOriginalCurrency
            // 
            this.gcOriginalCurrency.AppearanceHeader.Options.UseTextOptions = true;
            this.gcOriginalCurrency.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcOriginalCurrency.Caption = "原币";
            this.gcOriginalCurrency.ColumnEdit = this.ricboOriginalCurrency;
            this.gcOriginalCurrency.FieldName = "OriginalCurrency";
            this.gcOriginalCurrency.Name = "gcOriginalCurrency";
            this.gcOriginalCurrency.Visible = true;
            this.gcOriginalCurrency.VisibleIndex = 3;
            this.gcOriginalCurrency.Width = 141;
            // 
            // ricboOriginalCurrency
            // 
            this.ricboOriginalCurrency.AutoHeight = false;
            this.ricboOriginalCurrency.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ricboOriginalCurrency.Name = "ricboOriginalCurrency";
            this.ricboOriginalCurrency.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // gcPrice
            // 
            this.gcPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.gcPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcPrice.Caption = "单价";
            this.gcPrice.ColumnEdit = this.ritxtPrice;
            this.gcPrice.DisplayFormat.FormatString = "n";
            this.gcPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcPrice.FieldName = "Price";
            this.gcPrice.Name = "gcPrice";
            this.gcPrice.Visible = true;
            this.gcPrice.VisibleIndex = 4;
            this.gcPrice.Width = 141;
            // 
            // ritxtPrice
            // 
            this.ritxtPrice.AutoHeight = false;
            this.ritxtPrice.Name = "ritxtPrice";
            // 
            // gcOriginalCurrencyMoney
            // 
            this.gcOriginalCurrencyMoney.AppearanceHeader.Options.UseTextOptions = true;
            this.gcOriginalCurrencyMoney.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcOriginalCurrencyMoney.Caption = "原币金额";
            this.gcOriginalCurrencyMoney.DisplayFormat.FormatString = "n";
            this.gcOriginalCurrencyMoney.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcOriginalCurrencyMoney.FieldName = "OriginalCurrencyMoney";
            this.gcOriginalCurrencyMoney.Name = "gcOriginalCurrencyMoney";
            this.gcOriginalCurrencyMoney.OptionsColumn.AllowEdit = false;
            this.gcOriginalCurrencyMoney.OptionsColumn.ReadOnly = true;
            this.gcOriginalCurrencyMoney.Visible = true;
            this.gcOriginalCurrencyMoney.VisibleIndex = 5;
            this.gcOriginalCurrencyMoney.Width = 141;
            // 
            // gcExchangeRate
            // 
            this.gcExchangeRate.AppearanceHeader.Options.UseTextOptions = true;
            this.gcExchangeRate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcExchangeRate.Caption = "汇率";
            this.gcExchangeRate.ColumnEdit = this.ritxtExchangeRate;
            this.gcExchangeRate.DisplayFormat.FormatString = "n";
            this.gcExchangeRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcExchangeRate.FieldName = "ExchangeRate";
            this.gcExchangeRate.Name = "gcExchangeRate";
            this.gcExchangeRate.Visible = true;
            this.gcExchangeRate.VisibleIndex = 6;
            this.gcExchangeRate.Width = 141;
            // 
            // ritxtExchangeRate
            // 
            this.ritxtExchangeRate.AutoHeight = false;
            this.ritxtExchangeRate.Name = "ritxtExchangeRate";
            // 
            // gcCNY
            // 
            this.gcCNY.AppearanceHeader.Options.UseTextOptions = true;
            this.gcCNY.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcCNY.Caption = "人民币";
            this.gcCNY.DisplayFormat.FormatString = "n";
            this.gcCNY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcCNY.FieldName = "CNY";
            this.gcCNY.Name = "gcCNY";
            this.gcCNY.OptionsColumn.AllowEdit = false;
            this.gcCNY.OptionsColumn.ReadOnly = true;
            this.gcCNY.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CNY", "合同金额{0}")});
            this.gcCNY.Visible = true;
            this.gcCNY.VisibleIndex = 7;
            this.gcCNY.Width = 185;
            // 
            // colDelete
            // 
            this.colDelete.AppearanceHeader.Options.UseTextOptions = true;
            this.colDelete.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDelete.Caption = "  ";
            this.colDelete.ColumnEdit = this.riLinkDelete;
            this.colDelete.Name = "colDelete";
            this.colDelete.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colDelete.OptionsColumn.AllowMove = false;
            this.colDelete.OptionsColumn.AllowShowHide = false;
            this.colDelete.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDelete.OptionsColumn.ShowInCustomizationForm = false;
            this.colDelete.Visible = true;
            this.colDelete.VisibleIndex = 8;
            this.colDelete.Width = 98;
            // 
            // riLinkDelete
            // 
            this.riLinkDelete.AutoHeight = false;
            this.riLinkDelete.Name = "riLinkDelete";
            this.riLinkDelete.SingleClick = true;
            this.riLinkDelete.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.riLinkDelete_CustomDisplayText);
            this.riLinkDelete.Click += new System.EventHandler(this.riLinkDelete_Click);
            // 
            // txtAdvancePayment
            // 
            this.txtAdvancePayment.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtAdvancePayment.IsSupportNegative = false;
            this.txtAdvancePayment.Location = new System.Drawing.Point(45, 308);
            this.txtAdvancePayment.Margin = new System.Windows.Forms.Padding(2);
            this.txtAdvancePayment.Name = "txtAdvancePayment";
            this.txtAdvancePayment.Properties.NullText = "0.00";
            this.txtAdvancePayment.Size = new System.Drawing.Size(226, 21);
            this.txtAdvancePayment.StyleController = this.layoutControl1;
            this.txtAdvancePayment.TabIndex = 35;
            this.txtAdvancePayment.EditValueChanged += new System.EventHandler(this.InProductDetail_EditValueChanged);
            // 
            // txtPercentage
            // 
            this.txtPercentage.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPercentage.IsSupportNegative = false;
            this.txtPercentage.Location = new System.Drawing.Point(275, 308);
            this.txtPercentage.Margin = new System.Windows.Forms.Padding(2);
            this.txtPercentage.Name = "txtPercentage";
            this.txtPercentage.Properties.NullText = "0.00";
            this.txtPercentage.Properties.ReadOnly = true;
            this.txtPercentage.Size = new System.Drawing.Size(256, 21);
            this.txtPercentage.StyleController = this.layoutControl1;
            this.txtPercentage.TabIndex = 34;
            this.txtPercentage.ToolTip = "（预付款+进料款*(1+增值税率)）/（总进价+进料款*(1+增值税就率))";
            // 
            // txtInterestRate
            // 
            this.txtInterestRate.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtInterestRate.IsSupportNegative = false;
            this.txtInterestRate.Location = new System.Drawing.Point(535, 308);
            this.txtInterestRate.Margin = new System.Windows.Forms.Padding(2);
            this.txtInterestRate.Name = "txtInterestRate";
            this.txtInterestRate.Properties.NullText = "0.00";
            this.txtInterestRate.Size = new System.Drawing.Size(221, 21);
            this.txtInterestRate.StyleController = this.layoutControl1;
            this.txtInterestRate.TabIndex = 32;
            this.txtInterestRate.EditValueChanged += new System.EventHandler(this.InProductDetail_EditValueChanged);
            // 
            // txtDays
            // 
            this.txtDays.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtDays.IsSupportNegative = false;
            this.txtDays.Location = new System.Drawing.Point(760, 308);
            this.txtDays.Margin = new System.Windows.Forms.Padding(2);
            this.txtDays.Name = "txtDays";
            this.txtDays.Properties.NullText = "0.00";
            this.txtDays.Size = new System.Drawing.Size(139, 21);
            this.txtDays.StyleController = this.layoutControl1;
            this.txtDays.TabIndex = 30;
            this.txtDays.EditValueChanged += new System.EventHandler(this.InProductDetail_EditValueChanged);
            // 
            // txtInterest
            // 
            this.txtInterest.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtInterest.IsSupportNegative = false;
            this.txtInterest.Location = new System.Drawing.Point(903, 308);
            this.txtInterest.Margin = new System.Windows.Forms.Padding(2);
            this.txtInterest.Name = "txtInterest";
            this.txtInterest.Properties.NullText = "0.00";
            this.txtInterest.Properties.ReadOnly = true;
            this.txtInterest.Size = new System.Drawing.Size(139, 21);
            this.txtInterest.StyleController = this.layoutControl1;
            this.txtInterest.TabIndex = 29;
            this.txtInterest.ToolTip = "预付款*年利率/360/100*天数";
            this.txtInterest.EditValueChanged += new System.EventHandler(this.txtInterest_EditValueChanged);
            // 
            // gridInProductDetail
            // 
            this.gridInProductDetail.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridInProductDetail.Location = new System.Drawing.Point(45, 171);
            this.gridInProductDetail.MainView = this.bgvInProductDetail;
            this.gridInProductDetail.Margin = new System.Windows.Forms.Padding(2);
            this.gridInProductDetail.Name = "gridInProductDetail";
            this.gridInProductDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ritxtInCount,
            this.ritxtRawMaterials,
            this.ritxtSubsidiaryMaterials,
            this.ritxtProcessCost,
            this.ritxtSubtotal,
            this.riLinkEditInDelete,
            this.ritxtTaxRebateRate,
            this.ritxtVat});
            this.gridInProductDetail.Size = new System.Drawing.Size(897, 116);
            this.gridInProductDetail.TabIndex = 28;
            this.gridInProductDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bgvInProductDetail});
            // 
            // bgvInProductDetail
            // 
            this.bgvInProductDetail.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3,
            this.gridBand4,
            this.gridBand10,
            this.gridBand13,
            this.gridBand12,
            this.gridBand11,
            this.gridBand9});
            this.bgvInProductDetail.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gcInName,
            this.gcInCount,
            this.gcInUnit,
            this.gcRawMaterials,
            this.gcSubsidiaryMaterials,
            this.gcProcessCost,
            this.gcSubtotal,
            this.gcMoneySubtotal,
            this.gcVat,
            this.gcTaxRebateRate,
            this.gcTaxRebate,
            this.gcInDelete});
            this.bgvInProductDetail.GridControl = this.gridInProductDetail;
            this.bgvInProductDetail.Name = "bgvInProductDetail";
            this.bgvInProductDetail.NewItemRowText = "单击此处添加";
            this.bgvInProductDetail.OptionsDetail.EnableMasterViewMode = false;
            this.bgvInProductDetail.OptionsDetail.ShowDetailTabs = false;
            this.bgvInProductDetail.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.bgvInProductDetail.OptionsView.ShowColumnHeaders = false;
            this.bgvInProductDetail.OptionsView.ShowGroupPanel = false;
            this.bgvInProductDetail.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.bgvInProductDetail_InitNewRow);
            this.bgvInProductDetail.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.bgvInProductDetail_CellValueChanged);
            this.bgvInProductDetail.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.bgvInProductDetail_InvalidRowException);
            this.bgvInProductDetail.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.bgvInProductDetail_ValidateRow);
            this.bgvInProductDetail.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.bgvInProductDetail_ValidatingEditor);
            this.bgvInProductDetail.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.bgvInProductDetail_InvalidValueException);
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "品名规格";
            this.gridBand1.Columns.Add(this.gcInName);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 194;
            // 
            // gcInName
            // 
            this.gcInName.Caption = "品名规格";
            this.gcInName.FieldName = "Name";
            this.gcInName.Name = "gcInName";
            this.gcInName.Visible = true;
            this.gcInName.Width = 194;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "数量";
            this.gridBand2.Columns.Add(this.gcInCount);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Width = 77;
            // 
            // gcInCount
            // 
            this.gcInCount.Caption = "数量";
            this.gcInCount.ColumnEdit = this.ritxtInCount;
            this.gcInCount.DisplayFormat.FormatString = "n";
            this.gcInCount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcInCount.FieldName = "Count";
            this.gcInCount.Name = "gcInCount";
            this.gcInCount.Visible = true;
            this.gcInCount.Width = 77;
            // 
            // ritxtInCount
            // 
            this.ritxtInCount.AutoHeight = false;
            this.ritxtInCount.Name = "ritxtInCount";
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.Caption = "单位";
            this.gridBand3.Columns.Add(this.gcInUnit);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.Width = 69;
            // 
            // gcInUnit
            // 
            this.gcInUnit.Caption = "单位";
            this.gcInUnit.FieldName = "Unit";
            this.gcInUnit.Name = "gcInUnit";
            this.gcInUnit.Visible = true;
            this.gcInUnit.Width = 69;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Caption = "单价";
            this.gridBand4.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand5,
            this.gridBand6,
            this.gridBand7,
            this.gridBand8});
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.Width = 406;
            // 
            // gridBand5
            // 
            this.gridBand5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand5.Caption = "原料";
            this.gridBand5.Columns.Add(this.gcRawMaterials);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.Width = 102;
            // 
            // gcRawMaterials
            // 
            this.gcRawMaterials.Caption = "原料";
            this.gcRawMaterials.ColumnEdit = this.ritxtRawMaterials;
            this.gcRawMaterials.DisplayFormat.FormatString = "n";
            this.gcRawMaterials.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcRawMaterials.FieldName = "RawMaterials";
            this.gcRawMaterials.Name = "gcRawMaterials";
            this.gcRawMaterials.Visible = true;
            this.gcRawMaterials.Width = 102;
            // 
            // ritxtRawMaterials
            // 
            this.ritxtRawMaterials.AutoHeight = false;
            this.ritxtRawMaterials.Name = "ritxtRawMaterials";
            // 
            // gridBand6
            // 
            this.gridBand6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand6.Caption = "辅料";
            this.gridBand6.Columns.Add(this.gcSubsidiaryMaterials);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.Width = 91;
            // 
            // gcSubsidiaryMaterials
            // 
            this.gcSubsidiaryMaterials.Caption = "辅料";
            this.gcSubsidiaryMaterials.ColumnEdit = this.ritxtSubsidiaryMaterials;
            this.gcSubsidiaryMaterials.DisplayFormat.FormatString = "n";
            this.gcSubsidiaryMaterials.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcSubsidiaryMaterials.FieldName = "SubsidiaryMaterials";
            this.gcSubsidiaryMaterials.Name = "gcSubsidiaryMaterials";
            this.gcSubsidiaryMaterials.Visible = true;
            this.gcSubsidiaryMaterials.Width = 91;
            // 
            // ritxtSubsidiaryMaterials
            // 
            this.ritxtSubsidiaryMaterials.AutoHeight = false;
            this.ritxtSubsidiaryMaterials.Name = "ritxtSubsidiaryMaterials";
            // 
            // gridBand7
            // 
            this.gridBand7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand7.Caption = "加工";
            this.gridBand7.Columns.Add(this.gcProcessCost);
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.Width = 108;
            // 
            // gcProcessCost
            // 
            this.gcProcessCost.Caption = "加工";
            this.gcProcessCost.ColumnEdit = this.ritxtProcessCost;
            this.gcProcessCost.DisplayFormat.FormatString = "n";
            this.gcProcessCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcProcessCost.FieldName = "ProcessCost";
            this.gcProcessCost.Name = "gcProcessCost";
            this.gcProcessCost.Visible = true;
            this.gcProcessCost.Width = 108;
            // 
            // ritxtProcessCost
            // 
            this.ritxtProcessCost.AutoHeight = false;
            this.ritxtProcessCost.Name = "ritxtProcessCost";
            // 
            // gridBand8
            // 
            this.gridBand8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand8.Caption = "小计";
            this.gridBand8.Columns.Add(this.gcSubtotal);
            this.gridBand8.Name = "gridBand8";
            this.gridBand8.Width = 105;
            // 
            // gcSubtotal
            // 
            this.gcSubtotal.Caption = "小计";
            this.gcSubtotal.ColumnEdit = this.ritxtSubtotal;
            this.gcSubtotal.DisplayFormat.FormatString = "n";
            this.gcSubtotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcSubtotal.FieldName = "Subtotal";
            this.gcSubtotal.Name = "gcSubtotal";
            this.gcSubtotal.OptionsColumn.AllowEdit = false;
            this.gcSubtotal.Visible = true;
            this.gcSubtotal.Width = 105;
            // 
            // ritxtSubtotal
            // 
            this.ritxtSubtotal.AutoHeight = false;
            this.ritxtSubtotal.DisplayFormat.FormatString = "n";
            this.ritxtSubtotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ritxtSubtotal.Name = "ritxtSubtotal";
            // 
            // gridBand10
            // 
            this.gridBand10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand10.Caption = "金额小计";
            this.gridBand10.Columns.Add(this.gcMoneySubtotal);
            this.gridBand10.Name = "gridBand10";
            this.gridBand10.Width = 98;
            // 
            // gcMoneySubtotal
            // 
            this.gcMoneySubtotal.Caption = "金额小计";
            this.gcMoneySubtotal.DisplayFormat.FormatString = "n";
            this.gcMoneySubtotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcMoneySubtotal.FieldName = "MoneySubtotal";
            this.gcMoneySubtotal.Name = "gcMoneySubtotal";
            this.gcMoneySubtotal.OptionsColumn.AllowEdit = false;
            this.gcMoneySubtotal.Visible = true;
            this.gcMoneySubtotal.Width = 98;
            // 
            // gridBand13
            // 
            this.gridBand13.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand13.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridBand13.Caption = "增值税税率(%)";
            this.gridBand13.Columns.Add(this.gcVat);
            this.gridBand13.Name = "gridBand13";
            this.gridBand13.Width = 72;
            // 
            // gcVat
            // 
            this.gcVat.Caption = "增值税率";
            this.gcVat.ColumnEdit = this.ritxtVat;
            this.gcVat.DisplayFormat.FormatString = "n";
            this.gcVat.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcVat.FieldName = "Vat";
            this.gcVat.Name = "gcVat";
            this.gcVat.Visible = true;
            this.gcVat.Width = 72;
            // 
            // ritxtVat
            // 
            this.ritxtVat.AutoHeight = false;
            this.ritxtVat.Name = "ritxtVat";
            // 
            // gridBand12
            // 
            this.gridBand12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand12.Caption = "退税率";
            this.gridBand12.Columns.Add(this.gcTaxRebateRate);
            this.gridBand12.Name = "gridBand12";
            this.gridBand12.Width = 84;
            // 
            // gcTaxRebateRate
            // 
            this.gcTaxRebateRate.Caption = "退税率";
            this.gcTaxRebateRate.ColumnEdit = this.ritxtTaxRebateRate;
            this.gcTaxRebateRate.DisplayFormat.FormatString = "n";
            this.gcTaxRebateRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcTaxRebateRate.FieldName = "TaxRebateRate";
            this.gcTaxRebateRate.Name = "gcTaxRebateRate";
            this.gcTaxRebateRate.Visible = true;
            this.gcTaxRebateRate.Width = 84;
            // 
            // ritxtTaxRebateRate
            // 
            this.ritxtTaxRebateRate.AutoHeight = false;
            this.ritxtTaxRebateRate.Name = "ritxtTaxRebateRate";
            // 
            // gridBand11
            // 
            this.gridBand11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand11.Caption = "退税额";
            this.gridBand11.Columns.Add(this.gcTaxRebate);
            this.gridBand11.Name = "gridBand11";
            this.gridBand11.Width = 97;
            // 
            // gcTaxRebate
            // 
            this.gcTaxRebate.Caption = "退税额";
            this.gcTaxRebate.DisplayFormat.FormatString = "n";
            this.gcTaxRebate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcTaxRebate.FieldName = "TaxRebate";
            this.gcTaxRebate.Name = "gcTaxRebate";
            this.gcTaxRebate.OptionsColumn.AllowEdit = false;
            this.gcTaxRebate.Visible = true;
            this.gcTaxRebate.Width = 97;
            // 
            // gridBand9
            // 
            this.gridBand9.Columns.Add(this.gcInDelete);
            this.gridBand9.Name = "gridBand9";
            this.gridBand9.Width = 68;
            // 
            // gcInDelete
            // 
            this.gcInDelete.Caption = " ";
            this.gcInDelete.ColumnEdit = this.riLinkEditInDelete;
            this.gcInDelete.Name = "gcInDelete";
            this.gcInDelete.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcInDelete.OptionsColumn.AllowMove = false;
            this.gcInDelete.OptionsColumn.AllowShowHide = false;
            this.gcInDelete.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcInDelete.OptionsColumn.ShowInCustomizationForm = false;
            this.gcInDelete.Visible = true;
            this.gcInDelete.Width = 68;
            // 
            // riLinkEditInDelete
            // 
            this.riLinkEditInDelete.AutoHeight = false;
            this.riLinkEditInDelete.Name = "riLinkEditInDelete";
            this.riLinkEditInDelete.SingleClick = true;
            this.riLinkEditInDelete.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.riLinkEditInDelete_CustomDisplayText);
            this.riLinkEditInDelete.Click += new System.EventHandler(this.riLinkEditInDelete_Click);
            // 
            // chkIsQualified
            // 
            this.chkIsQualified.Location = new System.Drawing.Point(896, 144);
            this.chkIsQualified.Margin = new System.Windows.Forms.Padding(2);
            this.chkIsQualified.Name = "chkIsQualified";
            this.chkIsQualified.Properties.Caption = "是否合格供应方";
            this.chkIsQualified.Size = new System.Drawing.Size(146, 19);
            this.chkIsQualified.StyleController = this.layoutControl1;
            this.chkIsQualified.TabIndex = 27;
            this.chkIsQualified.CheckedChanged += new System.EventHandler(this.chkIsQualified_CheckedChanged);
            // 
            // txtOutSettlementMethod2
            // 
            this.txtOutSettlementMethod2.Location = new System.Drawing.Point(331, 85);
            this.txtOutSettlementMethod2.Margin = new System.Windows.Forms.Padding(2);
            this.txtOutSettlementMethod2.Name = "txtOutSettlementMethod2";
            this.txtOutSettlementMethod2.Size = new System.Drawing.Size(139, 21);
            this.txtOutSettlementMethod2.StyleController = this.layoutControl1;
            this.txtOutSettlementMethod2.TabIndex = 25;
            // 
            // txtOutSettlementMethod
            // 
            this.txtOutSettlementMethod.Location = new System.Drawing.Point(188, 85);
            this.txtOutSettlementMethod.Margin = new System.Windows.Forms.Padding(2);
            this.txtOutSettlementMethod.Name = "txtOutSettlementMethod";
            this.txtOutSettlementMethod.Size = new System.Drawing.Size(139, 21);
            this.txtOutSettlementMethod.StyleController = this.layoutControl1;
            this.txtOutSettlementMethod.TabIndex = 22;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtTotalAmount.IsSupportNegative = false;
            this.txtTotalAmount.Location = new System.Drawing.Point(617, 85);
            this.txtTotalAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Properties.NullText = "0.00";
            this.txtTotalAmount.Properties.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(139, 21);
            this.txtTotalAmount.StyleController = this.layoutControl1;
            this.txtTotalAmount.TabIndex = 21;
            this.txtTotalAmount.EditValueChanged += new System.EventHandler(this.txtTotalAmount_EditValueChanged);
            // 
            // txtOutSettlementMethod3
            // 
            this.txtOutSettlementMethod3.Location = new System.Drawing.Point(474, 85);
            this.txtOutSettlementMethod3.Margin = new System.Windows.Forms.Padding(2);
            this.txtOutSettlementMethod3.Name = "txtOutSettlementMethod3";
            this.txtOutSettlementMethod3.Size = new System.Drawing.Size(139, 21);
            this.txtOutSettlementMethod3.StyleController = this.layoutControl1;
            this.txtOutSettlementMethod3.TabIndex = 20;
            // 
            // txtPriceClause
            // 
            this.txtPriceClause.Location = new System.Drawing.Point(45, 85);
            this.txtPriceClause.Margin = new System.Windows.Forms.Padding(2);
            this.txtPriceClause.Name = "txtPriceClause";
            this.txtPriceClause.Size = new System.Drawing.Size(139, 21);
            this.txtPriceClause.StyleController = this.layoutControl1;
            this.txtPriceClause.TabIndex = 19;
            // 
            // rgTradeNature
            // 
            this.rgTradeNature.Location = new System.Drawing.Point(871, -81);
            this.rgTradeNature.Margin = new System.Windows.Forms.Padding(2);
            this.rgTradeNature.Name = "rgTradeNature";
            this.rgTradeNature.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgTradeNature.Properties.Appearance.Options.UseBackColor = true;
            this.rgTradeNature.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgTradeNature.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "做单"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "过单")});
            this.rgTradeNature.Size = new System.Drawing.Size(161, 25);
            this.rgTradeNature.StyleController = this.layoutControl1;
            this.rgTradeNature.TabIndex = 18;
            // 
            // dteValidity
            // 
            this.dteValidity.EditValue = null;
            this.dteValidity.Location = new System.Drawing.Point(903, -156);
            this.dteValidity.Margin = new System.Windows.Forms.Padding(2);
            this.dteValidity.Name = "dteValidity";
            this.dteValidity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteValidity.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dteValidity.Size = new System.Drawing.Size(139, 21);
            this.dteValidity.StyleController = this.layoutControl1;
            this.dteValidity.TabIndex = 8;
            // 
            // dteSignDate
            // 
            this.dteSignDate.EditValue = null;
            this.dteSignDate.Location = new System.Drawing.Point(760, -156);
            this.dteSignDate.Margin = new System.Windows.Forms.Padding(2);
            this.dteSignDate.Name = "dteSignDate";
            this.dteSignDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteSignDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dteSignDate.Size = new System.Drawing.Size(139, 21);
            this.dteSignDate.StyleController = this.layoutControl1;
            this.dteSignDate.TabIndex = 7;
            // 
            // txtSalesman
            // 
            this.txtSalesman.Location = new System.Drawing.Point(536, -156);
            this.txtSalesman.Margin = new System.Windows.Forms.Padding(2);
            this.txtSalesman.Name = "txtSalesman";
            this.txtSalesman.Properties.ReadOnly = true;
            this.txtSalesman.Size = new System.Drawing.Size(220, 21);
            this.txtSalesman.StyleController = this.layoutControl1;
            this.txtSalesman.TabIndex = 6;
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(290, -156);
            this.txtDepartment.Margin = new System.Windows.Forms.Padding(2);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Properties.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(242, 21);
            this.txtDepartment.StyleController = this.layoutControl1;
            this.txtDepartment.TabIndex = 5;
            // 
            // txtContractNO
            // 
            this.txtContractNO.Location = new System.Drawing.Point(45, -156);
            this.txtContractNO.Margin = new System.Windows.Forms.Padding(2);
            this.txtContractNO.Name = "txtContractNO";
            this.txtContractNO.Size = new System.Drawing.Size(241, 21);
            this.txtContractNO.StyleController = this.layoutControl1;
            this.txtContractNO.TabIndex = 9;
            // 
            // pceCustomer
            // 
            this.pceCustomer.Location = new System.Drawing.Point(200, -106);
            this.pceCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.pceCustomer.Name = "pceCustomer";
            this.pceCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.pceCustomer.Size = new System.Drawing.Size(842, 21);
            this.pceCustomer.StyleController = this.layoutControl1;
            this.pceCustomer.TabIndex = 10;
            this.pceCustomer.QueryResultValue += new DevExpress.XtraEditors.Controls.QueryResultValueEventHandler(this.pceCustomer_QueryResultValue);
            this.pceCustomer.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.pceCustomer_QueryPopUp);
            // 
            // pceSupplier
            // 
            this.pceSupplier.Location = new System.Drawing.Point(187, 144);
            this.pceSupplier.Margin = new System.Windows.Forms.Padding(2);
            this.pceSupplier.Name = "pceSupplier";
            this.pceSupplier.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.pceSupplier.Properties.PopupControl = this.pccSupplier;
            this.pceSupplier.Size = new System.Drawing.Size(705, 21);
            this.pceSupplier.StyleController = this.layoutControl1;
            this.pceSupplier.TabIndex = 26;
            this.pceSupplier.QueryResultValue += new DevExpress.XtraEditors.Controls.QueryResultValueEventHandler(this.pceSupplier_QueryResultValue);
            this.pceSupplier.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.pceSupplier_QueryPopUp);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup3,
            this.layoutControlGroup4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, -197);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1066, 750);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AppearanceGroup.Options.UseTextOptions = true;
            this.layoutControlGroup2.AppearanceGroup.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlGroup2.CustomizationFormText = "一、外贸合约部分";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5,
            this.layoutControlItem4,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.layoutControlItem6,
            this.layoutControlItem14,
            this.layoutControlItem32,
            this.layoutControlItem15,
            this.layoutControlItem18,
            this.layoutControlItem21,
            this.layoutControlItem16,
            this.layoutControlItem17,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.layoutControlItem12,
            this.layoutControlItem19,
            this.layoutControlItem20,
            this.layoutControlItem27,
            this.layoutControlItem29,
            this.layoutControlItem36,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.layoutControlItem41,
            this.layoutControlItem44});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(1046, 317);
            this.layoutControlGroup2.Text = "一、外贸合约部分";
            this.layoutControlGroup2.TextLocation = DevExpress.Utils.Locations.Left;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem5.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem5.Control = this.dteValidity;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(858, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(143, 42);
            this.layoutControlItem5.Text = "有效期";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem4.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem4.Control = this.dteSignDate;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(715, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(143, 42);
            this.layoutControlItem4.Text = "订约日期";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem3.Control = this.txtSalesman;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(491, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(224, 42);
            this.layoutControlItem3.Text = "业务员";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem2.Control = this.txtDepartment;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(245, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(246, 42);
            this.layoutControlItem2.Text = "部门";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem1.Control = this.txtContractNO;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(245, 42);
            this.layoutControlItem1.Text = "合同编号 ";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.pceCustomer;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 67);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(1001, 25);
            this.layoutControlItem6.Text = "备注买方名称：";
            this.layoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(150, 18);
            this.layoutControlItem6.TextToControlDistance = 5;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.rgTradeNature;
            this.layoutControlItem14.CustomizationFormText = "layoutControlItem14";
            this.layoutControlItem14.Location = new System.Drawing.Point(761, 92);
            this.layoutControlItem14.MinSize = new System.Drawing.Size(230, 29);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(230, 29);
            this.layoutControlItem14.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem14.Text = "贸易性质：";
            this.layoutControlItem14.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem14.TextSize = new System.Drawing.Size(60, 14);
            this.layoutControlItem14.TextToControlDistance = 5;
            // 
            // layoutControlItem32
            // 
            this.layoutControlItem32.Control = this.gridOutProductDetail;
            this.layoutControlItem32.CustomizationFormText = "layoutControlItem32";
            this.layoutControlItem32.Location = new System.Drawing.Point(0, 121);
            this.layoutControlItem32.MaxSize = new System.Drawing.Size(0, 180);
            this.layoutControlItem32.MinSize = new System.Drawing.Size(104, 120);
            this.layoutControlItem32.Name = "layoutControlItem32";
            this.layoutControlItem32.Size = new System.Drawing.Size(1001, 120);
            this.layoutControlItem32.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem32.Text = "layoutControlItem32";
            this.layoutControlItem32.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem32.TextToControlDistance = 0;
            this.layoutControlItem32.TextVisible = false;
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem15.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem15.Control = this.txtPriceClause;
            this.layoutControlItem15.CustomizationFormText = "layoutControlItem15";
            this.layoutControlItem15.Location = new System.Drawing.Point(0, 241);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(143, 42);
            this.layoutControlItem15.Text = "价格条款";
            this.layoutControlItem15.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem15.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem18.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem18.Control = this.txtOutSettlementMethod;
            this.layoutControlItem18.CustomizationFormText = "layoutControlItem18";
            this.layoutControlItem18.Location = new System.Drawing.Point(143, 241);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(143, 42);
            this.layoutControlItem18.Text = "结算方式（1）";
            this.layoutControlItem18.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem18.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem21.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem21.Control = this.txtOutSettlementMethod2;
            this.layoutControlItem21.CustomizationFormText = "layoutControlItem21";
            this.layoutControlItem21.Location = new System.Drawing.Point(286, 241);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(143, 42);
            this.layoutControlItem21.Text = "结算方式（2）";
            this.layoutControlItem21.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem21.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem16.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem16.Control = this.txtOutSettlementMethod3;
            this.layoutControlItem16.CustomizationFormText = "layoutControlItem16";
            this.layoutControlItem16.Location = new System.Drawing.Point(429, 241);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(143, 42);
            this.layoutControlItem16.Text = "结算方式（3）";
            this.layoutControlItem16.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem16.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem17.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem17.Control = this.txtTotalAmount;
            this.layoutControlItem17.CustomizationFormText = "layoutControlItem17";
            this.layoutControlItem17.Location = new System.Drawing.Point(572, 241);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(143, 42);
            this.layoutControlItem17.Text = "合同金额";
            this.layoutControlItem17.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem17.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.pceMainCustomer;
            this.layoutControlItem9.CustomizationFormText = "主买方名称：";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 42);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(1001, 25);
            this.layoutControlItem9.Text = "主买方名称：";
            this.layoutControlItem9.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(150, 18);
            this.layoutControlItem9.TextToControlDistance = 5;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem10.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem10.Control = this.luePort;
            this.layoutControlItem10.CustomizationFormText = "目的港口";
            this.layoutControlItem10.Location = new System.Drawing.Point(858, 241);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(143, 42);
            this.layoutControlItem10.Text = "目的港口";
            this.layoutControlItem10.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem10.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.labelControl1;
            this.layoutControlItem12.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem12.CustomizationFormText = "贸易方式：";
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 92);
            this.layoutControlItem12.MaxSize = new System.Drawing.Size(153, 27);
            this.layoutControlItem12.MinSize = new System.Drawing.Size(153, 27);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(153, 29);
            this.layoutControlItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem12.Text = "layoutControlItem12";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextToControlDistance = 0;
            this.layoutControlItem12.TextVisible = false;
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.chkTradeMode4;
            this.layoutControlItem19.CustomizationFormText = "layoutControlItem19";
            this.layoutControlItem19.Location = new System.Drawing.Point(415, 92);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(80, 29);
            this.layoutControlItem19.Text = "layoutControlItem19";
            this.layoutControlItem19.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem19.TextToControlDistance = 0;
            this.layoutControlItem19.TextVisible = false;
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Control = this.chkTradeMode1;
            this.layoutControlItem20.CustomizationFormText = "layoutControlItem20";
            this.layoutControlItem20.Location = new System.Drawing.Point(153, 92);
            this.layoutControlItem20.MaxSize = new System.Drawing.Size(0, 27);
            this.layoutControlItem20.MinSize = new System.Drawing.Size(80, 27);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(87, 29);
            this.layoutControlItem20.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem20.Text = "layoutControlItem20";
            this.layoutControlItem20.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem20.TextToControlDistance = 0;
            this.layoutControlItem20.TextVisible = false;
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.Control = this.chkTradeMode2;
            this.layoutControlItem27.CustomizationFormText = "layoutControlItem27";
            this.layoutControlItem27.Location = new System.Drawing.Point(240, 92);
            this.layoutControlItem27.MaxSize = new System.Drawing.Size(0, 27);
            this.layoutControlItem27.MinSize = new System.Drawing.Size(80, 27);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new System.Drawing.Size(87, 29);
            this.layoutControlItem27.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem27.Text = "layoutControlItem27";
            this.layoutControlItem27.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem27.TextToControlDistance = 0;
            this.layoutControlItem27.TextVisible = false;
            // 
            // layoutControlItem29
            // 
            this.layoutControlItem29.Control = this.chkTradeMode5;
            this.layoutControlItem29.CustomizationFormText = "layoutControlItem29";
            this.layoutControlItem29.Location = new System.Drawing.Point(495, 92);
            this.layoutControlItem29.Name = "layoutControlItem29";
            this.layoutControlItem29.Size = new System.Drawing.Size(80, 29);
            this.layoutControlItem29.Text = "layoutControlItem29";
            this.layoutControlItem29.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem29.TextToControlDistance = 0;
            this.layoutControlItem29.TextVisible = false;
            // 
            // layoutControlItem36
            // 
            this.layoutControlItem36.Control = this.chkTradeMode3;
            this.layoutControlItem36.CustomizationFormText = "layoutControlItem36";
            this.layoutControlItem36.Location = new System.Drawing.Point(327, 92);
            this.layoutControlItem36.MaxSize = new System.Drawing.Size(0, 27);
            this.layoutControlItem36.MinSize = new System.Drawing.Size(80, 27);
            this.layoutControlItem36.Name = "layoutControlItem36";
            this.layoutControlItem36.Size = new System.Drawing.Size(88, 29);
            this.layoutControlItem36.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem36.Text = "layoutControlItem36";
            this.layoutControlItem36.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem36.TextToControlDistance = 0;
            this.layoutControlItem36.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 283);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(1001, 10);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(991, 92);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(10, 29);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem41
            // 
            this.layoutControlItem41.Control = this.txtUSDTotalAmount;
            this.layoutControlItem41.CustomizationFormText = "美元合同金额";
            this.layoutControlItem41.Location = new System.Drawing.Point(715, 241);
            this.layoutControlItem41.Name = "layoutControlItem41";
            this.layoutControlItem41.Size = new System.Drawing.Size(143, 42);
            this.layoutControlItem41.Text = "美元合同金额";
            this.layoutControlItem41.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem41.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem44
            // 
            this.layoutControlItem44.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem44.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem44.Control = this.txtExchangeRate;
            this.layoutControlItem44.CustomizationFormText = "折率";
            this.layoutControlItem44.Location = new System.Drawing.Point(575, 92);
            this.layoutControlItem44.Name = "layoutControlItem44";
            this.layoutControlItem44.Size = new System.Drawing.Size(186, 29);
            this.layoutControlItem44.Text = "汇率：";
            this.layoutControlItem44.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem44.TextSize = new System.Drawing.Size(36, 14);
            this.layoutControlItem44.TextToControlDistance = 5;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.AppearanceGroup.Options.UseTextOptions = true;
            this.layoutControlGroup3.AppearanceGroup.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlGroup3.CustomizationFormText = "内贸合约部份";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem22,
            this.layoutControlItem31,
            this.layoutControlItem30,
            this.layoutControlItem28,
            this.layoutControlItem26,
            this.layoutControlItem25,
            this.layoutControlItem24,
            this.layoutControlItem7,
            this.layoutControlItem23,
            this.layoutControlItem13});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 317);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(1046, 213);
            this.layoutControlGroup3.Text = "二、内贸合约部分";
            this.layoutControlGroup3.TextLocation = DevExpress.Utils.Locations.Left;
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.pceSupplier;
            this.layoutControlItem22.CustomizationFormText = "layoutControlItem22";
            this.layoutControlItem22.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new System.Drawing.Size(851, 27);
            this.layoutControlItem22.Text = "工厂名称：";
            this.layoutControlItem22.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem31
            // 
            this.layoutControlItem31.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem31.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem31.Control = this.txtAdvancePayment;
            this.layoutControlItem31.CustomizationFormText = "预付款";
            this.layoutControlItem31.Location = new System.Drawing.Point(0, 147);
            this.layoutControlItem31.Name = "layoutControlItem31";
            this.layoutControlItem31.Size = new System.Drawing.Size(230, 42);
            this.layoutControlItem31.Text = "预付款";
            this.layoutControlItem31.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem31.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem30
            // 
            this.layoutControlItem30.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem30.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem30.Control = this.txtPercentage;
            this.layoutControlItem30.CustomizationFormText = "占总额%";
            this.layoutControlItem30.Location = new System.Drawing.Point(230, 147);
            this.layoutControlItem30.Name = "layoutControlItem30";
            this.layoutControlItem30.Size = new System.Drawing.Size(260, 42);
            this.layoutControlItem30.Text = "占总额%";
            this.layoutControlItem30.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem30.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem28
            // 
            this.layoutControlItem28.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem28.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem28.Control = this.txtInterestRate;
            this.layoutControlItem28.CustomizationFormText = "月利率%";
            this.layoutControlItem28.Location = new System.Drawing.Point(490, 147);
            this.layoutControlItem28.Name = "layoutControlItem28";
            this.layoutControlItem28.Size = new System.Drawing.Size(225, 42);
            this.layoutControlItem28.Text = "年利率%";
            this.layoutControlItem28.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem28.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem26
            // 
            this.layoutControlItem26.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem26.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem26.Control = this.txtDays;
            this.layoutControlItem26.CustomizationFormText = "天数";
            this.layoutControlItem26.Location = new System.Drawing.Point(715, 147);
            this.layoutControlItem26.Name = "layoutControlItem26";
            this.layoutControlItem26.Size = new System.Drawing.Size(143, 42);
            this.layoutControlItem26.Text = "天数";
            this.layoutControlItem26.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem26.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem25
            // 
            this.layoutControlItem25.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem25.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem25.Control = this.txtInterest;
            this.layoutControlItem25.CustomizationFormText = "利息";
            this.layoutControlItem25.Location = new System.Drawing.Point(858, 147);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new System.Drawing.Size(143, 42);
            this.layoutControlItem25.Text = "利息";
            this.layoutControlItem25.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem25.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.Control = this.gridInProductDetail;
            this.layoutControlItem24.CustomizationFormText = "layoutControlItem24";
            this.layoutControlItem24.Location = new System.Drawing.Point(0, 27);
            this.layoutControlItem24.MaxSize = new System.Drawing.Size(0, 180);
            this.layoutControlItem24.MinSize = new System.Drawing.Size(104, 120);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new System.Drawing.Size(901, 120);
            this.layoutControlItem24.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem24.Text = "layoutControlItem24";
            this.layoutControlItem24.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem24.TextToControlDistance = 0;
            this.layoutControlItem24.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem7.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem7.Control = this.txtPurchasePrice;
            this.layoutControlItem7.CustomizationFormText = "总进价（￥）";
            this.layoutControlItem7.Location = new System.Drawing.Point(901, 53);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(100, 50);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(100, 50);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(100, 94);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "总进价（￥）";
            this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.Control = this.chkIsQualified;
            this.layoutControlItem23.CustomizationFormText = "layoutControlItem23";
            this.layoutControlItem23.Location = new System.Drawing.Point(851, 0);
            this.layoutControlItem23.MaxSize = new System.Drawing.Size(150, 27);
            this.layoutControlItem23.MinSize = new System.Drawing.Size(150, 27);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(150, 27);
            this.layoutControlItem23.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem23.Text = "layoutControlItem23";
            this.layoutControlItem23.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem23.TextToControlDistance = 0;
            this.layoutControlItem23.TextVisible = false;
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.btnSync;
            this.layoutControlItem13.CustomizationFormText = "layoutControlItem13";
            this.layoutControlItem13.Location = new System.Drawing.Point(901, 27);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(100, 26);
            this.layoutControlItem13.Text = "layoutControlItem13";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem13.TextToControlDistance = 0;
            this.layoutControlItem13.TextVisible = false;
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.AppearanceGroup.Options.UseTextOptions = true;
            this.layoutControlGroup4.AppearanceGroup.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlGroup4.CustomizationFormText = "预算部份";
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem39,
            this.layoutControlItem38,
            this.layoutControlItem37,
            this.layoutControlItem35,
            this.layoutControlItem34,
            this.layoutControlItem33,
            this.layoutControlItem42,
            this.layoutControlItem45,
            this.layoutControlItem43,
            this.layoutControlItem40,
            this.layoutControlItem47,
            this.layoutControlItem48,
            this.layoutControlItem46,
            this.layoutControlItem49,
            this.layoutControlItem8,
            this.layoutControlItem11});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 530);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(1046, 200);
            this.layoutControlGroup4.Text = "三、预算部分";
            this.layoutControlGroup4.TextLocation = DevExpress.Utils.Locations.Left;
            // 
            // layoutControlItem39
            // 
            this.layoutControlItem39.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem39.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem39.Control = this.txtCommission;
            this.layoutControlItem39.CustomizationFormText = "佣金";
            this.layoutControlItem39.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem39.Name = "layoutControlItem39";
            this.layoutControlItem39.Size = new System.Drawing.Size(286, 42);
            this.layoutControlItem39.Text = "佣金";
            this.layoutControlItem39.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem39.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem38
            // 
            this.layoutControlItem38.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem38.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem38.Control = this.txtPremium;
            this.layoutControlItem38.CustomizationFormText = "运保费";
            this.layoutControlItem38.Location = new System.Drawing.Point(286, 0);
            this.layoutControlItem38.Name = "layoutControlItem38";
            this.layoutControlItem38.Size = new System.Drawing.Size(143, 42);
            this.layoutControlItem38.Text = "运保费";
            this.layoutControlItem38.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem38.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem37
            // 
            this.layoutControlItem37.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem37.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem37.Control = this.txtBankCharges;
            this.layoutControlItem37.CustomizationFormText = "银行费用";
            this.layoutControlItem37.Location = new System.Drawing.Point(429, 0);
            this.layoutControlItem37.Name = "layoutControlItem37";
            this.layoutControlItem37.Size = new System.Drawing.Size(143, 42);
            this.layoutControlItem37.Text = "银行费用";
            this.layoutControlItem37.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem37.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem35
            // 
            this.layoutControlItem35.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem35.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem35.Control = this.txtDirectCosts;
            this.layoutControlItem35.CustomizationFormText = "其它（预）";
            this.layoutControlItem35.Location = new System.Drawing.Point(572, 0);
            this.layoutControlItem35.Name = "layoutControlItem35";
            this.layoutControlItem35.Size = new System.Drawing.Size(143, 42);
            this.layoutControlItem35.Text = "直接费用";
            this.layoutControlItem35.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem35.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem34
            // 
            this.layoutControlItem34.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem34.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem34.Control = this.txtFeedMoney;
            this.layoutControlItem34.CustomizationFormText = "进料款";
            this.layoutControlItem34.Location = new System.Drawing.Point(715, 0);
            this.layoutControlItem34.Name = "layoutControlItem34";
            this.layoutControlItem34.Size = new System.Drawing.Size(143, 42);
            this.layoutControlItem34.Text = "进料款";
            this.layoutControlItem34.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem34.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem33
            // 
            this.layoutControlItem33.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem33.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem33.Control = this.txtSubtotal;
            this.layoutControlItem33.CustomizationFormText = "小计";
            this.layoutControlItem33.Location = new System.Drawing.Point(858, 0);
            this.layoutControlItem33.Name = "layoutControlItem33";
            this.layoutControlItem33.Size = new System.Drawing.Size(143, 42);
            this.layoutControlItem33.Text = "小计";
            this.layoutControlItem33.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem33.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem42
            // 
            this.layoutControlItem42.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem42.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem42.Control = this.txtNetIncome;
            this.layoutControlItem42.CustomizationFormText = "净收入额";
            this.layoutControlItem42.Location = new System.Drawing.Point(0, 42);
            this.layoutControlItem42.Name = "layoutControlItem42";
            this.layoutControlItem42.Size = new System.Drawing.Size(143, 42);
            this.layoutControlItem42.Text = "净收入额（折USD）";
            this.layoutControlItem42.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem42.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem45
            // 
            this.layoutControlItem45.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem45.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem45.Control = this.txtNetIncomeCNY;
            this.layoutControlItem45.CustomizationFormText = "折合人民币";
            this.layoutControlItem45.Location = new System.Drawing.Point(286, 42);
            this.layoutControlItem45.Name = "layoutControlItem45";
            this.layoutControlItem45.Size = new System.Drawing.Size(286, 42);
            this.layoutControlItem45.Text = "折合人民币";
            this.layoutControlItem45.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem45.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem43
            // 
            this.layoutControlItem43.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem43.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem43.Control = this.txtTotalCost;
            this.layoutControlItem43.CustomizationFormText = "总成本";
            this.layoutControlItem43.Location = new System.Drawing.Point(572, 42);
            this.layoutControlItem43.Name = "layoutControlItem43";
            this.layoutControlItem43.Size = new System.Drawing.Size(143, 42);
            this.layoutControlItem43.Text = "总成本";
            this.layoutControlItem43.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem43.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem40
            // 
            this.layoutControlItem40.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem40.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem40.Control = this.txtTaxRebateRateMoney;
            this.layoutControlItem40.CustomizationFormText = "出口退税额";
            this.layoutControlItem40.Location = new System.Drawing.Point(715, 42);
            this.layoutControlItem40.Name = "layoutControlItem40";
            this.layoutControlItem40.Size = new System.Drawing.Size(286, 42);
            this.layoutControlItem40.Text = "出口退税额";
            this.layoutControlItem40.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem40.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem47
            // 
            this.layoutControlItem47.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem47.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem47.Control = this.txtProfitLevel1;
            this.layoutControlItem47.CustomizationFormText = "盈利水平1";
            this.layoutControlItem47.Location = new System.Drawing.Point(0, 84);
            this.layoutControlItem47.Name = "layoutControlItem47";
            this.layoutControlItem47.Size = new System.Drawing.Size(143, 42);
            this.layoutControlItem47.Text = "盈利水平1";
            this.layoutControlItem47.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem47.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem48
            // 
            this.layoutControlItem48.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem48.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem48.Control = this.txtExchangeCost;
            this.layoutControlItem48.CustomizationFormText = "退税后换汇成本（￥或$）";
            this.layoutControlItem48.Location = new System.Drawing.Point(286, 84);
            this.layoutControlItem48.Name = "layoutControlItem48";
            this.layoutControlItem48.Size = new System.Drawing.Size(286, 42);
            this.layoutControlItem48.Text = "退税后换汇成本（￥或$）";
            this.layoutControlItem48.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem48.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem46
            // 
            this.layoutControlItem46.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem46.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem46.Control = this.txtProfit;
            this.layoutControlItem46.CustomizationFormText = "利润";
            this.layoutControlItem46.Location = new System.Drawing.Point(572, 84);
            this.layoutControlItem46.Name = "layoutControlItem46";
            this.layoutControlItem46.Size = new System.Drawing.Size(429, 42);
            this.layoutControlItem46.Text = "利润";
            this.layoutControlItem46.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem46.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem49
            // 
            this.layoutControlItem49.Control = this.meDescription;
            this.layoutControlItem49.CustomizationFormText = "备注：";
            this.layoutControlItem49.Location = new System.Drawing.Point(0, 126);
            this.layoutControlItem49.MaxSize = new System.Drawing.Size(0, 1000);
            this.layoutControlItem49.MinSize = new System.Drawing.Size(228, 50);
            this.layoutControlItem49.Name = "layoutControlItem49";
            this.layoutControlItem49.Size = new System.Drawing.Size(1001, 50);
            this.layoutControlItem49.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem49.Text = "备注：";
            this.layoutControlItem49.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem49.TextSize = new System.Drawing.Size(36, 14);
            this.layoutControlItem49.TextToControlDistance = 0;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem8.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem8.Control = this.txtProfitLevel2;
            this.layoutControlItem8.CustomizationFormText = "盈利水平2";
            this.layoutControlItem8.Location = new System.Drawing.Point(143, 84);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(143, 42);
            this.layoutControlItem8.Text = "盈利水平2";
            this.layoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(139, 14);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem11.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem11.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem11.Control = this.txtExchangeRateView;
            this.layoutControlItem11.CustomizationFormText = "汇率（USD）";
            this.layoutControlItem11.Location = new System.Drawing.Point(143, 42);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(143, 42);
            this.layoutControlItem11.Text = "汇率（USD）";
            this.layoutControlItem11.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem11.TextSize = new System.Drawing.Size(139, 14);
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // ucBudgetEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "ucBudgetEdit";
            this.Size = new System.Drawing.Size(1036, 570);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtExchangeRateView.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUSDTotalAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTradeMode3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTradeMode5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTradeMode2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTradeMode1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTradeMode4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pceMainCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pccCustomer)).EndInit();
            this.pccCustomer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtProfitLevel2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pccSupplier)).EndInit();
            this.pccSupplier.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchasePrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExchangeCost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProfitLevel1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProfit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNetIncomeCNY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExchangeRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNetIncome.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxRebateRateMoney.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCommission.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPremium.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankCharges.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDirectCosts.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFeedMoney.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubtotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOutProductDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOutProductDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ricboOriginalCurrency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtExchangeRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riLinkDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdvancePayment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercentage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterestRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterest.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInProductDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgvInProductDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtInCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtRawMaterials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtSubsidiaryMaterials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtProcessCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtSubtotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtVat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtTaxRebateRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riLinkEditInDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsQualified.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutSettlementMethod2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutSettlementMethod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutSettlementMethod3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPriceClause.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgTradeNature.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteValidity.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteValidity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteSignDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteSignDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesman.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContractNO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pceCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pceSupplier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.DateEdit dteValidity;
        private DevExpress.XtraEditors.DateEdit dteSignDate;
        private DevExpress.XtraEditors.TextEdit txtSalesman;
        private DevExpress.XtraEditors.TextEdit txtDepartment;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.RadioGroup rgTradeNature;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraEditors.TextEdit txtOutSettlementMethod2;
        private DevExpress.XtraEditors.TextEdit txtOutSettlementMethod;
        private BudgetSystem.CommonControl.TextEdit_Number txtTotalAmount;
        private DevExpress.XtraEditors.TextEdit txtOutSettlementMethod3;
        private DevExpress.XtraEditors.TextEdit txtPriceClause;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraEditors.CheckEdit chkIsQualified;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraGrid.GridControl gridInProductDetail;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem24;
        private BudgetSystem.CommonControl.TextEdit_Number txtAdvancePayment;
        private BudgetSystem.CommonControl.TextEdit_Number txtPercentage;
        private BudgetSystem.CommonControl.TextEdit_Number txtInterestRate;
        private BudgetSystem.CommonControl.TextEdit_Number txtDays;
        private BudgetSystem.CommonControl.TextEdit_Number txtInterest;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem25;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem28;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem30;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem31;
        private DevExpress.XtraGrid.GridControl gridOutProductDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOutProductDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gcName;
        private DevExpress.XtraGrid.Columns.GridColumn gcCount;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnit;
        private DevExpress.XtraGrid.Columns.GridColumn gcOriginalCurrency;
        private DevExpress.XtraGrid.Columns.GridColumn gcPrice;
        private DevExpress.XtraGrid.Columns.GridColumn gcOriginalCurrencyMoney;
        private DevExpress.XtraGrid.Columns.GridColumn gcExchangeRate;
        private DevExpress.XtraGrid.Columns.GridColumn gcCNY;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem32;
        private BudgetSystem.CommonControl.TextEdit_Number txtCommission;
        private BudgetSystem.CommonControl.TextEdit_Number txtPremium;
        private BudgetSystem.CommonControl.TextEdit_Number txtBankCharges;
        private BudgetSystem.CommonControl.TextEdit_Number txtDirectCosts;
        private BudgetSystem.CommonControl.TextEdit_Number txtFeedMoney;
        private BudgetSystem.CommonControl.TextEdit_Number txtSubtotal;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem33;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem34;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem35;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem37;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem38;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem39;
        private BudgetSystem.CommonControl.TextEdit_Number txtNetIncomeCNY;
        private BudgetSystem.CommonControl.TextEdit_Number txtExchangeRate;
        private BudgetSystem.CommonControl.TextEdit_Number txtTotalCost;
        private BudgetSystem.CommonControl.TextEdit_Number txtNetIncome;
        private BudgetSystem.CommonControl.TextEdit_Number txtTaxRebateRateMoney;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem40;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem42;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem43;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem44;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem45;
        private BudgetSystem.CommonControl.TextEdit_Number txtExchangeCost;
        private BudgetSystem.CommonControl.TextEdit_Number txtProfitLevel1;
        private BudgetSystem.CommonControl.TextEdit_Number txtProfit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem46;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem47;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem48;
        private DevExpress.XtraEditors.MemoEdit meDescription;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem49;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraEditors.TextEdit txtContractNO;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private BudgetSystem.CommonControl.TextEdit_Number txtPurchasePrice;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.PopupContainerControl pccCustomer;
        private ucCustomerSelected ucCustomerSelected;
        private DevExpress.XtraEditors.PopupContainerEdit pceCustomer;
        private DevExpress.XtraEditors.PopupContainerEdit pceSupplier;
        private DevExpress.XtraEditors.PopupContainerControl pccSupplier;
        private ucSupplierSelected ucSupplierSelected;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtPrice;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtExchangeRate; 
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit riLinkDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtInCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtRawMaterials;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtSubsidiaryMaterials;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtProcessCost;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bgvInProductDetail;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcInName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcInCount;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcInUnit;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcRawMaterials;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcSubsidiaryMaterials;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcProcessCost;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcSubtotal;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtSubtotal;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcInDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit riLinkEditInDelete;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcMoneySubtotal;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcTaxRebateRate;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcTaxRebate;
        private CommonControl.TextEdit_Number txtProfitLevel2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.PopupContainerEdit pceMainCustomer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.LookUpEdit luePort;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtTaxRebateRate;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcVat;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtVat;
        private DevExpress.XtraEditors.CheckEdit chkTradeMode3;
        private DevExpress.XtraEditors.CheckEdit chkTradeMode5;
        private DevExpress.XtraEditors.CheckEdit chkTradeMode2;
        private DevExpress.XtraEditors.CheckEdit chkTradeMode1;
        private DevExpress.XtraEditors.CheckEdit chkTradeMode4;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem29;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem36;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox ricboOriginalCurrency;
        private DevExpress.XtraEditors.SimpleButton btnSync;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private CommonControl.TextEdit_Number txtUSDTotalAmount;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem41;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand8;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand10;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand13;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand12;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand11;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand9;
        private CommonControl.TextEdit_Number txtExchangeRateView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
    }
}