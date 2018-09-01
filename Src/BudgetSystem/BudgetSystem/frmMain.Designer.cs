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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection();
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
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage4 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup10 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager();
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView();
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
            this.btnOptionManager});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.ribbonControl1.MaxItemId = 37;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.PageHeaderItemLinks.Add(this.btnRefresh);
            this.ribbonControl1.PageHeaderItemLinks.Add(this.btnReLogin);
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage4});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(1692, 184);
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
            this.btnbudgetQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnbudgetQuery_ItemClick);
            // 
            // btnInMoneyQuery
            // 
            this.btnInMoneyQuery.Caption = "收款管理";
            this.btnInMoneyQuery.Id = 8;
            this.btnInMoneyQuery.ImageIndex = 43;
            this.btnInMoneyQuery.Name = "btnInMoneyQuery";
            this.btnInMoneyQuery.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnInMoneyQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInMoneyQuery_ItemClick);
            // 
            // btnOutMoneyQuery
            // 
            this.btnOutMoneyQuery.Caption = "付款管理";
            this.btnOutMoneyQuery.Id = 10;
            this.btnOutMoneyQuery.ImageIndex = 42;
            this.btnOutMoneyQuery.Name = "btnOutMoneyQuery";
            this.btnOutMoneyQuery.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnOutMoneyQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOutMoneyQuery_ItemClick);
            // 
            // btnUserQuery
            // 
            this.btnUserQuery.Caption = "用户管理";
            this.btnUserQuery.Id = 25;
            this.btnUserQuery.ImageIndex = 39;
            this.btnUserQuery.Name = "btnUserQuery";
            this.btnUserQuery.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnUserQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUserQuery_ItemClick);
            // 
            // btnCustomerQuery
            // 
            this.btnCustomerQuery.Caption = "客户管理";
            this.btnCustomerQuery.Id = 26;
            this.btnCustomerQuery.ImageIndex = 24;
            this.btnCustomerQuery.Name = "btnCustomerQuery";
            this.btnCustomerQuery.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnCustomerQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCustomerQuery_ItemClick);
            // 
            // btnSupplierQuery
            // 
            this.btnSupplierQuery.Caption = "供应商管理";
            this.btnSupplierQuery.Id = 27;
            this.btnSupplierQuery.ImageIndex = 26;
            this.btnSupplierQuery.Name = "btnSupplierQuery";
            this.btnSupplierQuery.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSupplierQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSupplierQuery_ItemClick);
            // 
            // btnInvoiceQuery
            // 
            this.btnInvoiceQuery.Caption = "开票管理";
            this.btnInvoiceQuery.Id = 28;
            this.btnInvoiceQuery.ImageIndex = 45;
            this.btnInvoiceQuery.Name = "btnInvoiceQuery";
            this.btnInvoiceQuery.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnInvoiceQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInvoiceQuery_ItemClick);
            // 
            // btnVoucherNotesQuery
            // 
            this.btnVoucherNotesQuery.Caption = "付款凭证";
            this.btnVoucherNotesQuery.Id = 29;
            this.btnVoucherNotesQuery.ImageIndex = 12;
            this.btnVoucherNotesQuery.Name = "btnVoucherNotesQuery";
            this.btnVoucherNotesQuery.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnVoucherNotesQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVoucherNotesQuery_ItemClick);
            // 
            // btnApprovalList
            // 
            this.btnApprovalList.Caption = "待审批单管理";
            this.btnApprovalList.Id = 30;
            this.btnApprovalList.ImageIndex = 47;
            this.btnApprovalList.Name = "btnApprovalList";
            this.btnApprovalList.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnApprovalList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnApprovalList_ItemClick);
            // 
            // btnMyOrder
            // 
            this.btnMyOrder.Caption = "我提交的单子";
            this.btnMyOrder.Id = 31;
            this.btnMyOrder.ImageIndex = 17;
            this.btnMyOrder.Name = "btnMyOrder";
            this.btnMyOrder.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnMyOrder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMyOrder_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "决算管理";
            this.barButtonItem4.Id = 32;
            this.barButtonItem4.ImageIndex = 46;
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnFlowConfig
            // 
            this.btnFlowConfig.Caption = "流程配置";
            this.btnFlowConfig.Id = 33;
            this.btnFlowConfig.ImageIndex = 52;
            this.btnFlowConfig.Name = "btnFlowConfig";
            this.btnFlowConfig.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnFlowConfig.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFlowConfig_ItemClick);
            // 
            // btnDepartment
            // 
            this.btnDepartment.Caption = "部门管理";
            this.btnDepartment.Id = 34;
            this.btnDepartment.ImageIndex = 40;
            this.btnDepartment.Name = "btnDepartment";
            this.btnDepartment.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDepartment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDepartment_ItemClick);
            // 
            // btnRoleManager
            // 
            this.btnRoleManager.Caption = "角色管理";
            this.btnRoleManager.Id = 35;
            this.btnRoleManager.ImageIndex = 37;
            this.btnRoleManager.Name = "btnRoleManager";
            this.btnRoleManager.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnRoleManager.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRoleManager_ItemClick);
            // 
            // btnOptionManager
            // 
            this.btnOptionManager.Caption = "选择管理";
            this.btnOptionManager.Id = 36;
            this.btnOptionManager.ImageIndex = 35;
            this.btnOptionManager.Name = "btnOptionManager";
            this.btnOptionManager.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnOptionManager.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOptionManager_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup5,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "业务";
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
            this.ribbonPageGroup2.Text = "收支管理";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btnApprovalList);
            this.ribbonPageGroup5.ItemLinks.Add(this.btnMyOrder);
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "我的工作";
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
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 960);
            this.ribbonStatusBar1.Margin = new System.Windows.Forms.Padding(2);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1692, 37);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1692, 997);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "上服集团预算系统   ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MdiChildActivate += new System.EventHandler(this.frmMain_MdiChildActivate);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
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
    }
}

