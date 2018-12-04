namespace BudgetSystem
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.rgbStyle = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.btnReLogin = new DevExpress.XtraBars.BarButtonItem();
            this.btnbudgetQuery = new DevExpress.XtraBars.BarButtonItem();
            this.btnInMoneyQuery = new DevExpress.XtraBars.BarButtonItem();
            this.btnOutMoneyQuery = new DevExpress.XtraBars.BarButtonItem();
            this.btnUserQuery = new DevExpress.XtraBars.BarButtonItem();
            this.btnCustomerQuery = new DevExpress.XtraBars.BarButtonItem();
            this.btnSupplierQuery = new DevExpress.XtraBars.BarButtonItem();
            this.btnInvoiceQuery = new DevExpress.XtraBars.BarButtonItem();
            this.btnVoucherNotesQuery = new DevExpress.XtraBars.BarButtonItem();
            this.btnApprovalList = new DevExpress.XtraBars.BarButtonItem();
            this.btnMyOrder = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.btnFlowConfig = new DevExpress.XtraBars.BarButtonItem();
            this.btnDepartment = new DevExpress.XtraBars.BarButtonItem();
            this.btnRoleManager = new DevExpress.XtraBars.BarButtonItem();
            this.btnOptionManager = new DevExpress.XtraBars.BarButtonItem();
            this.btnModifyPassword = new DevExpress.XtraBars.BarButtonItem();
            this.btnReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnBudgetReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnInMoneyReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnOutMoney = new DevExpress.XtraBars.BarButtonItem();
            this.bsiLoginInfo = new DevExpress.XtraBars.BarStaticItem();
            this.rpMain = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage4 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup10 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnApproval = new DevExpress.XtraBars.BarButtonItem();
            this.btnOutMoneyAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnInMoneyAdd = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationButtonText = null;
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.Name = "";
            this.ribbonControl1.Images = this.imageCollection1;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnRefresh,
            this.rgbStyle,
            this.btnReLogin,
            this.btnbudgetQuery,
            this.btnInMoneyQuery,
            this.btnOutMoneyQuery,
            this.btnUserQuery,
            this.btnCustomerQuery,
            this.btnSupplierQuery,
            this.btnInvoiceQuery,
            this.btnVoucherNotesQuery,
            this.btnApprovalList,
            this.btnMyOrder,
            this.barButtonItem4,
            this.btnFlowConfig,
            this.btnDepartment,
            this.btnRoleManager,
            this.btnOptionManager,
            this.btnModifyPassword,
            this.btnReport,
            this.btnBudgetReport,
            this.btnInMoneyReport,
            this.btnOutMoney,
            this.bsiLoginInfo});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ribbonControl1.MaxItemId = 44;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.PageHeaderItemLinks.Add(this.btnModifyPassword);
            this.ribbonControl1.PageHeaderItemLinks.Add(this.btnRefresh);
            this.ribbonControl1.PageHeaderItemLinks.Add(this.btnReLogin);
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpMain,
            this.ribbonPage4});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(1515, 169);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "Add_32x32.png");
            this.imageCollection1.Images.SetKeyName(1, "Refresh_32x32.png");
            this.imageCollection1.Images.SetKeyName(2, "Show_32x32.png");
            this.imageCollection1.Images.SetKeyName(3, "Zoom_32x32.png");
            this.imageCollection1.Images.SetKeyName(4, "ZoomIn_32x32.png");
            this.imageCollection1.Images.SetKeyName(5, "ZoomOut_32x32.png");
            this.imageCollection1.Images.SetKeyName(6, "Save_32x32.png");
            this.imageCollection1.Images.SetKeyName(7, "HistoryItem_32x32.png");
            this.imageCollection1.Images.SetKeyName(8, "Redo_32x32.png");
            this.imageCollection1.Images.SetKeyName(9, "Undo_32x32.png");
            this.imageCollection1.Images.SetKeyName(10, "MasterFilter_32x32.png");
            this.imageCollection1.Images.SetKeyName(11, "PieSeries_32x32.png");
            this.imageCollection1.Images.SetKeyName(12, "Copy_32x32.png");
            this.imageCollection1.Images.SetKeyName(13, "Customization_32x32.png");
            this.imageCollection1.Images.SetKeyName(14, "Cut_32x32.png");
            this.imageCollection1.Images.SetKeyName(15, "Delete_32x32.png");
            this.imageCollection1.Images.SetKeyName(16, "Edit_32x32.png");
            this.imageCollection1.Images.SetKeyName(17, "Paste_32x32.png");
            this.imageCollection1.Images.SetKeyName(18, "AddNewDataSource_32x32.png");
            this.imageCollection1.Images.SetKeyName(19, "TopBottomRules_32x32.png");
            this.imageCollection1.Images.SetKeyName(20, "Phone_32x32.png");
            this.imageCollection1.Images.SetKeyName(21, "3DColumn_32x32.png");
            this.imageCollection1.Images.SetKeyName(22, "Area3_32x32.png");
            this.imageCollection1.Images.SetKeyName(23, "BarOfPie_32x32.png");
            this.imageCollection1.Images.SetKeyName(24, "BOCustomer_32x32.png");
            this.imageCollection1.Images.SetKeyName(25, "BODetails_32x32.png");
            this.imageCollection1.Images.SetKeyName(26, "BOEmployee_32x32.png");
            this.imageCollection1.Images.SetKeyName(27, "BOOrder_32x32.png");
            this.imageCollection1.Images.SetKeyName(28, "BOPermission_32x32.png");
            this.imageCollection1.Images.SetKeyName(29, "BORules_32x32.png");
            this.imageCollection1.Images.SetKeyName(30, "BOSaleItem_32x32.png");
            this.imageCollection1.Images.SetKeyName(31, "First_32x32.png");
            this.imageCollection1.Images.SetKeyName(32, "MoveDown_32x32.png");
            this.imageCollection1.Images.SetKeyName(33, "MoveUp_32x32.png");
            this.imageCollection1.Images.SetKeyName(34, "Next_32x32.png");
            this.imageCollection1.Images.SetKeyName(35, "Design_32x32.png");
            this.imageCollection1.Images.SetKeyName(36, "Home_32x32.png");
            this.imageCollection1.Images.SetKeyName(37, "AssignTo_32x32.png");
            this.imageCollection1.Images.SetKeyName(38, "AssignToMe_32x32.png");
            this.imageCollection1.Images.SetKeyName(39, "Customer_32x32.png");
            this.imageCollection1.Images.SetKeyName(40, "PublicFix_32x32.png");
            this.imageCollection1.Images.SetKeyName(41, "Technology_32x32.png");
            this.imageCollection1.Images.SetKeyName(42, "IncreaseDecimal_32x32.png");
            this.imageCollection1.Images.SetKeyName(43, "DecreaseDecimal_32x32.png");
            this.imageCollection1.Images.SetKeyName(44, "Add_32x32.png");
            this.imageCollection1.Images.SetKeyName(45, "Edit_32x32.png");
            this.imageCollection1.Images.SetKeyName(46, "SolidGreenDataBar_32x32.png");
            this.imageCollection1.Images.SetKeyName(47, "TableLayout_32x32.png");
            this.imageCollection1.Images.SetKeyName(48, "AddItem_32x32.png");
            this.imageCollection1.Images.SetKeyName(49, "Edit_32x32.png");
            this.imageCollection1.Images.SetKeyName(50, "Delete_32x32.png");
            this.imageCollection1.Images.SetKeyName(51, "Inbox_32x32.png");
            this.imageCollection1.Images.SetKeyName(52, "ShowDetail_32x32.png");
            this.imageCollection1.Images.SetKeyName(53, "Outbox_32x32.png");
            this.imageCollection1.Images.SetKeyName(54, "Stop_32x32.png");
            this.imageCollection1.Images.SetKeyName(55, "Separator_32x32.png");
            this.imageCollection1.Images.SetKeyName(56, "None_32x32.png");
            this.imageCollection1.Images.SetKeyName(57, "ImportMap_32x32.png");
            this.imageCollection1.Images.SetKeyName(58, "Print_32x32.png");
            this.imageCollection1.Images.SetKeyName(59, "NewTask_32x32.png");
            this.imageCollection1.Images.SetKeyName(60, "BreakingChange_32x32.png");
            this.imageCollection1.Images.SetKeyName(61, "BOUser_32x32.png");
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "刷新";
            this.btnRefresh.Description = "刷新当前窗体数据";
            this.btnRefresh.Id = 2;
            this.btnRefresh.ImageIndex = 1;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // rgbStyle
            // 
            this.rgbStyle.Caption = "外观选择";
            this.rgbStyle.Id = 3;
            this.rgbStyle.Name = "rgbStyle";
            this.rgbStyle.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.rgbStyle_GalleryItemClick);
            // 
            // btnReLogin
            // 
            this.btnReLogin.Caption = "重新登录";
            this.btnReLogin.Description = "重新登录";
            this.btnReLogin.Id = 5;
            this.btnReLogin.ImageIndex = 38;
            this.btnReLogin.Name = "btnReLogin";
            this.btnReLogin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReLogin_ItemClick);
            // 
            // btnbudgetQuery
            // 
            this.btnbudgetQuery.Caption = "预算单管理";
            this.btnbudgetQuery.Id = 6;
            this.btnbudgetQuery.ImageIndex = 19;
            this.btnbudgetQuery.Name = "btnbudgetQuery";
            this.btnbudgetQuery.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnbudgetQuery.Tag = "BuggetManagement";
            this.btnbudgetQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnbudgetQuery_ItemClick);
            // 
            // btnInMoneyQuery
            // 
            this.btnInMoneyQuery.Caption = "收款管理";
            this.btnInMoneyQuery.Id = 8;
            this.btnInMoneyQuery.ImageIndex = 43;
            this.btnInMoneyQuery.Name = "btnInMoneyQuery";
            this.btnInMoneyQuery.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnInMoneyQuery.Tag = "InMoneyManagement";
            this.btnInMoneyQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInMoneyQuery_ItemClick);
            // 
            // btnOutMoneyQuery
            // 
            this.btnOutMoneyQuery.Caption = "付款管理";
            this.btnOutMoneyQuery.Id = 10;
            this.btnOutMoneyQuery.ImageIndex = 42;
            this.btnOutMoneyQuery.Name = "btnOutMoneyQuery";
            this.btnOutMoneyQuery.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnOutMoneyQuery.Tag = "OutMoneyManagement";
            this.btnOutMoneyQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOutMoneyQuery_ItemClick);
            // 
            // btnUserQuery
            // 
            this.btnUserQuery.Caption = "用户管理";
            this.btnUserQuery.Id = 25;
            this.btnUserQuery.ImageIndex = 39;
            this.btnUserQuery.Name = "btnUserQuery";
            this.btnUserQuery.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnUserQuery.Tag = "UserManagement";
            this.btnUserQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUserQuery_ItemClick);
            // 
            // btnCustomerQuery
            // 
            this.btnCustomerQuery.Caption = "客户管理";
            this.btnCustomerQuery.Id = 26;
            this.btnCustomerQuery.ImageIndex = 24;
            this.btnCustomerQuery.Name = "btnCustomerQuery";
            this.btnCustomerQuery.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnCustomerQuery.Tag = "CustomerManagement";
            this.btnCustomerQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCustomerQuery_ItemClick);
            // 
            // btnSupplierQuery
            // 
            this.btnSupplierQuery.Caption = "供应商管理";
            this.btnSupplierQuery.Id = 27;
            this.btnSupplierQuery.ImageIndex = 26;
            this.btnSupplierQuery.Name = "btnSupplierQuery";
            this.btnSupplierQuery.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSupplierQuery.Tag = "SupplierManagement";
            this.btnSupplierQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSupplierQuery_ItemClick);
            // 
            // btnInvoiceQuery
            // 
            this.btnInvoiceQuery.Caption = "交单管理";
            this.btnInvoiceQuery.Id = 28;
            this.btnInvoiceQuery.ImageIndex = 45;
            this.btnInvoiceQuery.Name = "btnInvoiceQuery";
            this.btnInvoiceQuery.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnInvoiceQuery.Tag = "InvoiceManagement";
            this.btnInvoiceQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInvoiceQuery_ItemClick);
            // 
            // btnVoucherNotesQuery
            // 
            this.btnVoucherNotesQuery.Caption = "报关单管理";
            this.btnVoucherNotesQuery.Id = 29;
            this.btnVoucherNotesQuery.ImageIndex = 12;
            this.btnVoucherNotesQuery.Name = "btnVoucherNotesQuery";
            this.btnVoucherNotesQuery.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnVoucherNotesQuery.Tag = "VoucherNotesManagement";
            this.btnVoucherNotesQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVoucherNotesQuery_ItemClick);
            // 
            // btnApprovalList
            // 
            this.btnApprovalList.Caption = "待审批单管理";
            this.btnApprovalList.Id = 30;
            this.btnApprovalList.ImageIndex = 47;
            this.btnApprovalList.Name = "btnApprovalList";
            this.btnApprovalList.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnApprovalList.Tag = "MyPendingFlowManagement";
            this.btnApprovalList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnApprovalList_ItemClick);
            // 
            // btnMyOrder
            // 
            this.btnMyOrder.Caption = "我提交的单子";
            this.btnMyOrder.Id = 31;
            this.btnMyOrder.ImageIndex = 17;
            this.btnMyOrder.Name = "btnMyOrder";
            this.btnMyOrder.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnMyOrder.Tag = "MySubmitFlowManagement";
            this.btnMyOrder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMyOrder_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "决算管理";
            this.barButtonItem4.Id = 32;
            this.barButtonItem4.ImageIndex = 46;
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // btnFlowConfig
            // 
            this.btnFlowConfig.Caption = "流程配置";
            this.btnFlowConfig.Id = 33;
            this.btnFlowConfig.ImageIndex = 52;
            this.btnFlowConfig.Name = "btnFlowConfig";
            this.btnFlowConfig.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnFlowConfig.Tag = "FlowManagement";
            this.btnFlowConfig.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFlowConfig_ItemClick);
            // 
            // btnDepartment
            // 
            this.btnDepartment.Caption = "部门管理";
            this.btnDepartment.Id = 34;
            this.btnDepartment.ImageIndex = 40;
            this.btnDepartment.Name = "btnDepartment";
            this.btnDepartment.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDepartment.Tag = "DepartmentManagement";
            this.btnDepartment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDepartment_ItemClick);
            // 
            // btnRoleManager
            // 
            this.btnRoleManager.Caption = "角色管理";
            this.btnRoleManager.Id = 35;
            this.btnRoleManager.ImageIndex = 37;
            this.btnRoleManager.Name = "btnRoleManager";
            this.btnRoleManager.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnRoleManager.Tag = "RoleManagement";
            this.btnRoleManager.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRoleManager_ItemClick);
            // 
            // btnOptionManager
            // 
            this.btnOptionManager.Caption = "选项管理";
            this.btnOptionManager.Id = 36;
            this.btnOptionManager.ImageIndex = 35;
            this.btnOptionManager.Name = "btnOptionManager";
            this.btnOptionManager.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnOptionManager.Tag = "OptionManagement";
            this.btnOptionManager.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOptionManager_ItemClick);
            // 
            // btnModifyPassword
            // 
            this.btnModifyPassword.Caption = "修改密码";
            this.btnModifyPassword.Id = 37;
            this.btnModifyPassword.ImageIndex = 61;
            this.btnModifyPassword.Name = "btnModifyPassword";
            this.btnModifyPassword.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModifyPassword_ItemClick);
            // 
            // btnReport
            // 
            this.btnReport.Caption = "测试报表";
            this.btnReport.Id = 38;
            this.btnReport.ImageIndex = 21;
            this.btnReport.Name = "btnReport";
            this.btnReport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReport1_ItemClick);
            // 
            // btnBudgetReport
            // 
            this.btnBudgetReport.Caption = "预算单报表";
            this.btnBudgetReport.Id = 40;
            this.btnBudgetReport.ImageIndex = 21;
            this.btnBudgetReport.Name = "btnBudgetReport";
            this.btnBudgetReport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnBudgetReport.Tag = "BudgetReport";
            this.btnBudgetReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBudgetReport_ItemClick);
            // 
            // btnInMoneyReport
            // 
            this.btnInMoneyReport.Caption = "收款报表";
            this.btnInMoneyReport.Id = 41;
            this.btnInMoneyReport.ImageIndex = 21;
            this.btnInMoneyReport.Name = "btnInMoneyReport";
            this.btnInMoneyReport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnInMoneyReport.Tag = "InMoneyReport";
            this.btnInMoneyReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInMoneyReport_ItemClick);
            // 
            // btnOutMoney
            // 
            this.btnOutMoney.Caption = "付款报表";
            this.btnOutMoney.Id = 42;
            this.btnOutMoney.ImageIndex = 21;
            this.btnOutMoney.Name = "btnOutMoney";
            this.btnOutMoney.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnOutMoney.Tag = "OutMoneyReport";
            this.btnOutMoney.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOutMoney_ItemClick);
            // 
            // bsiLoginInfo
            // 
            this.bsiLoginInfo.Caption = "bsiLoginInfo";
            this.bsiLoginInfo.Id = 43;
            this.bsiLoginInfo.Name = "bsiLoginInfo";
            this.bsiLoginInfo.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // rpMain
            // 
            this.rpMain.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup5,
            this.rpGroup,
            this.ribbonPageGroup4});
            this.rpMain.Name = "rpMain";
            this.rpMain.Text = "业务";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnbudgetQuery);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "预算单管理";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnInMoneyQuery);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnOutMoneyQuery);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnInvoiceQuery);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnVoucherNotesQuery);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "收款管理";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btnApprovalList);
            this.ribbonPageGroup5.ItemLinks.Add(this.btnMyOrder);
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "我的工作";
            // 
            // rpGroup
            // 
            this.rpGroup.ItemLinks.Add(this.btnReport);
            this.rpGroup.ItemLinks.Add(this.btnBudgetReport);
            this.rpGroup.ItemLinks.Add(this.btnInMoneyReport);
            this.rpGroup.ItemLinks.Add(this.btnOutMoney);
            this.rpGroup.Name = "rpGroup";
            this.rpGroup.Text = "统计报告";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnCustomerQuery);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnSupplierQuery);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnUserQuery);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnRoleManager);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnDepartment);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnFlowConfig);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnOptionManager);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "系统设置";
            // 
            // ribbonPage4
            // 
            this.ribbonPage4.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup10});
            this.ribbonPage4.Name = "ribbonPage4";
            this.ribbonPage4.Text = "外观";
            // 
            // ribbonPageGroup10
            // 
            this.ribbonPageGroup10.ItemLinks.Add(this.rgbStyle);
            this.ribbonPageGroup10.Name = "ribbonPageGroup10";
            this.ribbonPageGroup10.Text = "界面效果";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.bsiLoginInfo);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 874);
            this.ribbonStatusBar1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1515, 34);
            // 
            // documentManager1
            // 
            this.documentManager1.MdiParent = this;
            this.documentManager1.MenuManager = this.ribbonControl1;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // tabbedView1
            // 
            this.tabbedView1.DocumentProperties.AllowFloat = false;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "修改";
            this.barButtonItem1.Id = 19;
            this.barButtonItem1.ImageIndex = 45;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnApproval
            // 
            this.btnApproval.Caption = "审批";
            this.btnApproval.Id = 14;
            this.btnApproval.ImageIndex = 2;
            this.btnApproval.Name = "btnApproval";
            this.btnApproval.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnOutMoneyAdd
            // 
            this.btnOutMoneyAdd.Caption = "创建";
            this.btnOutMoneyAdd.Id = 11;
            this.btnOutMoneyAdd.ImageIndex = 43;
            this.btnOutMoneyAdd.Name = "btnOutMoneyAdd";
            this.btnOutMoneyAdd.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnOutMoneyAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOutMoneyAdd_ItemClick);
            // 
            // btnInMoneyAdd
            // 
            this.btnInMoneyAdd.Caption = "创建";
            this.btnInMoneyAdd.Id = 9;
            this.btnInMoneyAdd.ImageIndex = 42;
            this.btnInMoneyAdd.Name = "btnInMoneyAdd";
            this.btnInMoneyAdd.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnInMoneyAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInMoneyAdd_ItemClick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1515, 908);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "上服集团预算系统   ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MdiChildActivate += new System.EventHandler(this.frmMain_MdiChildActivate);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpMain;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup10;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.RibbonGalleryBarItem rgbStyle;
        private DevExpress.XtraBars.BarButtonItem btnReLogin;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.BarButtonItem btnbudgetQuery;
        private DevExpress.XtraBars.BarButtonItem btnInMoneyQuery;
        private DevExpress.XtraBars.BarButtonItem btnOutMoneyQuery;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnUserQuery;
        private DevExpress.XtraBars.BarButtonItem btnCustomerQuery;
        private DevExpress.XtraBars.BarButtonItem btnSupplierQuery;
        private DevExpress.XtraBars.BarButtonItem btnApproval;
        private DevExpress.XtraBars.BarButtonItem btnOutMoneyAdd;
        private DevExpress.XtraBars.BarButtonItem btnInMoneyAdd;
        private DevExpress.XtraBars.BarButtonItem btnInvoiceQuery;
        private DevExpress.XtraBars.BarButtonItem btnVoucherNotesQuery;
        private DevExpress.XtraBars.BarButtonItem btnApprovalList;
        private DevExpress.XtraBars.BarButtonItem btnMyOrder;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem btnFlowConfig;
        private DevExpress.XtraBars.BarButtonItem btnDepartment;
        private DevExpress.XtraBars.BarButtonItem btnRoleManager;
        private DevExpress.XtraBars.BarButtonItem btnOptionManager;
        private DevExpress.XtraBars.BarButtonItem btnModifyPassword;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpGroup;
        private DevExpress.XtraBars.BarButtonItem btnReport;
        private DevExpress.XtraBars.BarButtonItem btnBudgetReport;
        private DevExpress.XtraBars.BarButtonItem btnInMoneyReport;
        private DevExpress.XtraBars.BarButtonItem btnOutMoney;
        private DevExpress.XtraBars.BarStaticItem bsiLoginInfo;
    }
}

