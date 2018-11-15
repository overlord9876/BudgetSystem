namespace BudgetSystem.Base
{
    partial class frmBaseCommonReportForm
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
            this.listBox = new DevExpress.XtraEditors.ListBoxControl();
            this.pivotGridControl = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.lcgPivote = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcStatBar = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcList = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem = new DevExpress.XtraLayout.SplitterItem();
            this.lcgGrid = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcGridBar = new DevExpress.XtraLayout.LayoutControlItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.pivotViewBar = new DevExpress.XtraBars.Bar();
            this.btnSaveView = new DevExpress.XtraBars.BarButtonItem();
            this.btnShowOrVisible = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeleteView = new DevExpress.XtraBars.BarButtonItem();
            this.gridViewBar = new DevExpress.XtraBars.Bar();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPivote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcStatBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGridBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.listBox);
            this.layoutControl1.Controls.Add(this.pivotGridControl);
            this.layoutControl1.Controls.Add(this.gridControl);
            this.layoutControl1.Controls.Add(this.barDockControlLeft);
            this.layoutControl1.Controls.Add(this.barDockControlRight);
            this.layoutControl1.Controls.Add(this.barDockControlBottom);
            this.layoutControl1.Controls.Add(this.barDockControlTop);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6,
            this.layoutControlItem7});
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(829, 657, 552, 529);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1731, 757);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // listBox
            // 
            this.listBox.Location = new System.Drawing.Point(24, 79);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(340, 654);
            this.listBox.StyleController = this.layoutControl1;
            this.listBox.TabIndex = 12;
            this.listBox.DoubleClick += new System.EventHandler(this.listBox_DoubleClick);
            // 
            // pivotGridControl
            // 
            this.pivotGridControl.Location = new System.Drawing.Point(373, 79);
            this.pivotGridControl.Name = "pivotGridControl";
            this.pivotGridControl.Size = new System.Drawing.Size(1334, 654);
            this.pivotGridControl.TabIndex = 6;
            // 
            // gridControl
            // 
            this.gridControl.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.First.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControl.Location = new System.Drawing.Point(24, 79);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(1683, 654);
            this.gridControl.TabIndex = 4;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(151, 73);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 0);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(151, 49);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(24, 49);
            this.barDockControlBottom.Size = new System.Drawing.Size(1683, 29);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Location = new System.Drawing.Point(24, 49);
            this.barDockControlTop.Size = new System.Drawing.Size(1683, 26);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.barDockControlLeft;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(1155, 24);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(50, 20);
            this.layoutControlItem6.TextToControlDistance = 5;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.barDockControlRight;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(1155, 24);
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(50, 20);
            this.layoutControlItem7.TextToControlDistance = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1731, 757);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.CustomizationFormText = "TabControl";
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.lcgPivote;
            this.tabbedControlGroup1.SelectedTabPageIndex = 1;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(1711, 737);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgGrid,
            this.lcgPivote});
            this.tabbedControlGroup1.Text = "TabControl";
            // 
            // lcgPivote
            // 
            this.lcgPivote.CustomizationFormText = "统计视图";
            this.lcgPivote.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.lcStatBar,
            this.lcList,
            this.splitterItem});
            this.lcgPivote.Location = new System.Drawing.Point(0, 0);
            this.lcgPivote.Name = "lcgPivote";
            this.lcgPivote.Size = new System.Drawing.Size(1687, 688);
            this.lcgPivote.Text = "统计视图";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.pivotGridControl;
            this.layoutControlItem3.CustomizationFormText = "统计表";
            this.layoutControlItem3.Location = new System.Drawing.Point(349, 30);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1338, 658);
            this.layoutControlItem3.Text = "统计表";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // lcStatBar
            // 
            this.lcStatBar.Control = this.barDockControlTop;
            this.lcStatBar.CustomizationFormText = "统计视图工具栏";
            this.lcStatBar.Location = new System.Drawing.Point(0, 0);
            this.lcStatBar.MaxSize = new System.Drawing.Size(0, 30);
            this.lcStatBar.MinSize = new System.Drawing.Size(1, 30);
            this.lcStatBar.Name = "lcStatBar";
            this.lcStatBar.Size = new System.Drawing.Size(1687, 30);
            this.lcStatBar.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcStatBar.Text = "lcStatBar";
            this.lcStatBar.TextSize = new System.Drawing.Size(0, 0);
            this.lcStatBar.TextToControlDistance = 0;
            this.lcStatBar.TextVisible = false;
            // 
            // lcList
            // 
            this.lcList.Control = this.listBox;
            this.lcList.CustomizationFormText = "统计视表列表";
            this.lcList.Location = new System.Drawing.Point(0, 30);
            this.lcList.Name = "lcList";
            this.lcList.Size = new System.Drawing.Size(344, 658);
            this.lcList.Text = "统计视表列表";
            this.lcList.TextSize = new System.Drawing.Size(0, 0);
            this.lcList.TextToControlDistance = 0;
            this.lcList.TextVisible = false;
            // 
            // splitterItem
            // 
            this.splitterItem.AllowHotTrack = true;
            this.splitterItem.CustomizationFormText = "splitterItem1";
            this.splitterItem.Location = new System.Drawing.Point(344, 30);
            this.splitterItem.Name = "splitterItem";
            this.splitterItem.Size = new System.Drawing.Size(5, 658);
            // 
            // lcgGrid
            // 
            this.lcgGrid.CustomizationFormText = "表格视图";
            this.lcgGrid.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.lcGridBar});
            this.lcgGrid.Location = new System.Drawing.Point(0, 0);
            this.lcgGrid.Name = "lcgGrid";
            this.lcgGrid.Size = new System.Drawing.Size(1687, 688);
            this.lcgGrid.Text = "表格视图";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl;
            this.layoutControlItem1.CustomizationFormText = "表格";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1687, 658);
            this.layoutControlItem1.Text = "表格";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // lcGridBar
            // 
            this.lcGridBar.Control = this.barDockControlBottom;
            this.lcGridBar.CustomizationFormText = "表格视图工具栏";
            this.lcGridBar.Location = new System.Drawing.Point(0, 0);
            this.lcGridBar.MaxSize = new System.Drawing.Size(0, 30);
            this.lcGridBar.MinSize = new System.Drawing.Size(1, 30);
            this.lcGridBar.Name = "lcGridBar";
            this.lcGridBar.Size = new System.Drawing.Size(1687, 30);
            this.lcGridBar.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcGridBar.Text = "lcGridBar";
            this.lcGridBar.TextSize = new System.Drawing.Size(0, 0);
            this.lcGridBar.TextToControlDistance = 0;
            this.lcGridBar.TextVisible = false;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.pivotViewBar,
            this.gridViewBar});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this.layoutControl1;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnShowOrVisible,
            this.btnSaveView,
            this.btnDeleteView});
            this.barManager1.MaxItemId = 3;
            // 
            // pivotViewBar
            // 
            this.pivotViewBar.BarName = "Custom 7";
            this.pivotViewBar.DockCol = 0;
            this.pivotViewBar.DockRow = 0;
            this.pivotViewBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.pivotViewBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSaveView),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDeleteView),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnShowOrVisible, true)});
            this.pivotViewBar.OptionsBar.AllowQuickCustomization = false;
            this.pivotViewBar.OptionsBar.DisableCustomization = true;
            this.pivotViewBar.OptionsBar.DrawDragBorder = false;
            this.pivotViewBar.OptionsBar.UseWholeRow = true;
            this.pivotViewBar.Text = "Custom 7";
            // 
            // btnSaveView
            // 
            this.btnSaveView.Caption = "保存为常用视图";
            this.btnSaveView.Id = 1;
            this.btnSaveView.Name = "btnSaveView";
            this.btnSaveView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveView_ItemClick);
            // 
            // btnShowOrVisible
            // 
            this.btnShowOrVisible.Caption = "显示/隐藏视图树";
            this.btnShowOrVisible.Id = 0;
            this.btnShowOrVisible.Name = "btnShowOrVisible";
            this.btnShowOrVisible.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShowOrVisible_ItemClick);
            // 
            // btnDeleteView
            // 
            this.btnDeleteView.Caption = "删除视图";
            this.btnDeleteView.Id = 2;
            this.btnDeleteView.Name = "btnDeleteView";
            this.btnDeleteView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDeleteView_ItemClick);
            // 
            // gridViewBar
            // 
            this.gridViewBar.BarName = "Custom 2";
            this.gridViewBar.DockCol = 0;
            this.gridViewBar.DockRow = 0;
            this.gridViewBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.gridViewBar.OptionsBar.AllowQuickCustomization = false;
            this.gridViewBar.OptionsBar.AllowRename = true;
            this.gridViewBar.OptionsBar.DisableClose = true;
            this.gridViewBar.OptionsBar.DrawDragBorder = false;
            this.gridViewBar.OptionsBar.UseWholeRow = true;
            this.gridViewBar.Text = "Custom 2";
            // 
            // frmBaseCommonReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1731, 757);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmBaseCommonReportForm";
            this.Text = "frmBaseCommonReportForm";
            this.Load += new System.EventHandler(this.frmBaseCommonReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPivote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcStatBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGridBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        protected DevExpress.XtraLayout.LayoutControl layoutControl1;
        protected DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl;
        protected DevExpress.XtraGrid.GridControl gridControl;
        protected DevExpress.XtraGrid.Views.Grid.GridView gridView;
        protected DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        protected DevExpress.XtraLayout.LayoutControlGroup lcgPivote;
        protected DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        protected DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        protected DevExpress.XtraBars.BarManager barManager1;
        protected DevExpress.XtraBars.Bar pivotViewBar;
        protected DevExpress.XtraBars.Bar gridViewBar;
        protected DevExpress.XtraBars.BarButtonItem btnShowOrVisible;
        protected DevExpress.XtraBars.BarButtonItem btnSaveView;
        protected DevExpress.XtraEditors.ListBoxControl listBox;
        protected DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        protected DevExpress.XtraLayout.LayoutControlGroup lcgGrid;
        protected DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        protected DevExpress.XtraLayout.LayoutControlItem lcGridBar;
        protected DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        protected DevExpress.XtraLayout.LayoutControlItem lcStatBar;
        protected DevExpress.XtraLayout.SplitterItem splitterItem;
        protected DevExpress.XtraLayout.LayoutControlItem lcList;
        protected DevExpress.XtraBars.BarButtonItem btnDeleteView;
    }
}