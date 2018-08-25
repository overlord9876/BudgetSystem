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
            this.btnAddBudget = new DevExpress.XtraBars.BarButtonItem();
            this.btnInMoneyQuery = new DevExpress.XtraBars.BarButtonItem();
            this.btnInMoneyAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnOutMoneyQuery = new DevExpress.XtraBars.BarButtonItem();
            this.btnOutMoneyAdd = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPage5 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage4 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup10 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
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
            this.btnAddBudget,
            this.btnInMoneyQuery,
            this.btnInMoneyAdd,
            this.btnOutMoneyQuery,
            this.btnOutMoneyAdd});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonControl1.MaxItemId = 12;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.PageHeaderItemLinks.Add(this.btnRefresh);
            this.ribbonControl1.PageHeaderItemLinks.Add(this.btnReLogin);
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage3,
            this.ribbonPage5,
            this.ribbonPage4});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(1139, 184);
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
            this.btnbudgetQuery.Caption = "查询";
            this.btnbudgetQuery.Id = 6;
            this.btnbudgetQuery.ImageIndex = 3;
            this.btnbudgetQuery.Name = "btnbudgetQuery";
            this.btnbudgetQuery.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnbudgetQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnbudgetQuery_ItemClick);
            // 
            // btnAddBudget
            // 
            this.btnAddBudget.Caption = "创建";
            this.btnAddBudget.Id = 7;
            this.btnAddBudget.ImageIndex = 19;
            this.btnAddBudget.Name = "btnAddBudget";
            this.btnAddBudget.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnInMoneyQuery
            // 
            this.btnInMoneyQuery.Caption = "查询";
            this.btnInMoneyQuery.Id = 8;
            this.btnInMoneyQuery.ImageIndex = 3;
            this.btnInMoneyQuery.Name = "btnInMoneyQuery";
            this.btnInMoneyQuery.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnInMoneyQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInMoneyQuery_ItemClick);
            // 
            // btnInMoneyAdd
            // 
            this.btnInMoneyAdd.Caption = "创建";
            this.btnInMoneyAdd.Id = 9;
            this.btnInMoneyAdd.ImageIndex = 42;
            this.btnInMoneyAdd.Name = "btnInMoneyAdd";
            this.btnInMoneyAdd.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnOutMoneyQuery
            // 
            this.btnOutMoneyQuery.Caption = "查询";
            this.btnOutMoneyQuery.Id = 10;
            this.btnOutMoneyQuery.ImageIndex = 3;
            this.btnOutMoneyQuery.Name = "btnOutMoneyQuery";
            this.btnOutMoneyQuery.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnOutMoneyQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOutMoneyQuery_ItemClick);
            // 
            // btnOutMoneyAdd
            // 
            this.btnOutMoneyAdd.Caption = "创建";
            this.btnOutMoneyAdd.Id = 11;
            this.btnOutMoneyAdd.ImageIndex = 43;
            this.btnOutMoneyAdd.Name = "btnOutMoneyAdd";
            this.btnOutMoneyAdd.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "业务";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnbudgetQuery);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAddBudget);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "预算单管理";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnInMoneyQuery);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnInMoneyAdd);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "收款";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnOutMoneyQuery);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnOutMoneyAdd);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "付款";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "发票";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5,
            this.ribbonPageGroup6});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "我的工作";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "我的待审批流程";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "我提交的单据";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "报表";
            // 
            // ribbonPage5
            // 
            this.ribbonPage5.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup7,
            this.ribbonPageGroup8,
            this.ribbonPageGroup9});
            this.ribbonPage5.Name = "ribbonPage5";
            this.ribbonPage5.Text = "配置";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.Text = "用户管理";
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            this.ribbonPageGroup8.Text = "客户管理";
            // 
            // ribbonPageGroup9
            // 
            this.ribbonPageGroup9.Name = "ribbonPageGroup9";
            this.ribbonPageGroup9.Text = "供应商管理";
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
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1139, 37);
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 997);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup9;
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
        private DevExpress.XtraBars.BarButtonItem btnAddBudget;
        private DevExpress.XtraBars.BarButtonItem btnInMoneyQuery;
        private DevExpress.XtraBars.BarButtonItem btnInMoneyAdd;
        private DevExpress.XtraBars.BarButtonItem btnOutMoneyQuery;
        private DevExpress.XtraBars.BarButtonItem btnOutMoneyAdd;
    }
}

