namespace BudgetSystem
{
    partial class frmRoleQuery
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gdAllUser = new DevExpress.XtraGrid.GridControl();
            this.gvAllUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdRoleUsers = new DevExpress.XtraGrid.GridControl();
            this.gvRoleUsers = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdRoleList = new DevExpress.XtraGrid.GridControl();
            this.gvRoleList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnRemveFromRole = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddToRole = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdAllUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAllUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdRoleUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRoleUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdRoleList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRoleList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gdAllUser);
            this.layoutControl1.Controls.Add(this.gdRoleUsers);
            this.layoutControl1.Controls.Add(this.gdRoleList);
            this.layoutControl1.Controls.Add(this.btnRemveFromRole);
            this.layoutControl1.Controls.Add(this.btnAddToRole);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1217, 872);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gdAllUser
            // 
            this.gdAllUser.Location = new System.Drawing.Point(656, 328);
            this.gdAllUser.MainView = this.gvAllUser;
            this.gdAllUser.Name = "gdAllUser";
            this.gdAllUser.Size = new System.Drawing.Size(537, 520);
            this.gdAllUser.TabIndex = 4;
            this.gdAllUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAllUser});
            // 
            // gvAllUser
            // 
            this.gvAllUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14});
            this.gvAllUser.GridControl = this.gdAllUser;
            this.gvAllUser.Name = "gvAllUser";
            this.gvAllUser.OptionsBehavior.Editable = false;
            this.gvAllUser.OptionsSelection.MultiSelect = true;
            this.gvAllUser.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "用户名";
            this.gridColumn10.FieldName = "UserName";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "用户姓名";
            this.gridColumn11.FieldName = "RealName";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 1;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "用户角色";
            this.gridColumn12.FieldName = "RoleName";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 2;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "所在部门";
            this.gridColumn13.FieldName = "DepartmentName";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 3;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "状态";
            this.gridColumn14.FieldName = "State";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 4;
            // 
            // gdRoleUsers
            // 
            this.gdRoleUsers.Location = new System.Drawing.Point(24, 328);
            this.gdRoleUsers.MainView = this.gvRoleUsers;
            this.gdRoleUsers.Name = "gdRoleUsers";
            this.gdRoleUsers.Size = new System.Drawing.Size(484, 520);
            this.gdRoleUsers.TabIndex = 3;
            this.gdRoleUsers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRoleUsers});
            // 
            // gvRoleUsers
            // 
            this.gvRoleUsers.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
            this.gvRoleUsers.GridControl = this.gdRoleUsers;
            this.gvRoleUsers.Name = "gvRoleUsers";
            this.gvRoleUsers.OptionsBehavior.Editable = false;
            this.gvRoleUsers.OptionsSelection.MultiSelect = true;
            this.gvRoleUsers.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "用户名";
            this.gridColumn5.FieldName = "UserName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "用户姓名";
            this.gridColumn6.FieldName = "RealName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "用户角色";
            this.gridColumn7.FieldName = "RoleName";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "所在部门";
            this.gridColumn8.FieldName = "DepartmentName";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "状态";
            this.gridColumn9.FieldName = "State";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            // 
            // gdRoleList
            // 
            this.gdRoleList.Location = new System.Drawing.Point(24, 52);
            this.gdRoleList.MainView = this.gvRoleList;
            this.gdRoleList.Name = "gdRoleList";
            this.gdRoleList.Size = new System.Drawing.Size(1169, 220);
            this.gdRoleList.TabIndex = 8;
            this.gdRoleList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRoleList});
            // 
            // gvRoleList
            // 
            this.gvRoleList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcName,
            this.gcRemark});
            this.gvRoleList.GridControl = this.gdRoleList;
            this.gvRoleList.Name = "gvRoleList";
            this.gvRoleList.OptionsBehavior.Editable = false;
            this.gvRoleList.OptionsView.ShowGroupPanel = false;
            this.gvRoleList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvRoleList_FocusedRowChanged);
            // 
            // gcName
            // 
            this.gcName.Caption = "角色名称";
            this.gcName.FieldName = "Name";
            this.gcName.Name = "gcName";
            this.gcName.Visible = true;
            this.gcName.VisibleIndex = 0;
            this.gcName.Width = 326;
            // 
            // gcRemark
            // 
            this.gcRemark.Caption = "角色描述（权限列表）";
            this.gcRemark.FieldName = "Remark";
            this.gcRemark.Name = "gcRemark";
            this.gcRemark.Visible = true;
            this.gcRemark.VisibleIndex = 1;
            this.gcRemark.Width = 825;
            // 
            // btnRemveFromRole
            // 
            this.btnRemveFromRole.Location = new System.Drawing.Point(524, 587);
            this.btnRemveFromRole.Name = "btnRemveFromRole";
            this.btnRemveFromRole.Size = new System.Drawing.Size(116, 36);
            this.btnRemveFromRole.StyleController = this.layoutControl1;
            this.btnRemveFromRole.TabIndex = 7;
            this.btnRemveFromRole.Text = "移出-->";
            this.btnRemveFromRole.Click += new System.EventHandler(this.btnRemveFromRole_Click);
            // 
            // btnAddToRole
            // 
            this.btnAddToRole.Location = new System.Drawing.Point(524, 547);
            this.btnAddToRole.Name = "btnAddToRole";
            this.btnAddToRole.Size = new System.Drawing.Size(116, 36);
            this.btnAddToRole.StyleController = this.layoutControl1;
            this.btnAddToRole.TabIndex = 6;
            this.btnAddToRole.Text = "<--分配";
            this.btnAddToRole.Click += new System.EventHandler(this.btnAddToRole_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.layoutControlGroup2,
            this.layoutControlGroup3,
            this.layoutControlGroup4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1217, 872);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnAddToRole;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(512, 535);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(120, 40);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(120, 40);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(120, 40);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnRemveFromRole;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(512, 575);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(120, 40);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(120, 40);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(120, 40);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(512, 276);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(120, 0);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(120, 100);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(120, 259);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(512, 615);
            this.emptySpaceItem2.MaxSize = new System.Drawing.Size(120, 0);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(120, 100);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(120, 237);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(1197, 276);
            this.layoutControlGroup2.Text = "角色列表";
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.gdRoleList;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(1173, 224);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "角色当前用户";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 276);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(512, 576);
            this.layoutControlGroup3.Text = "角色当时用户";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gdRoleUsers;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(488, 524);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.CustomizationFormText = "所有用户";
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup4.Location = new System.Drawing.Point(632, 276);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(565, 576);
            this.layoutControlGroup4.Text = "所有用户";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gdAllUser;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(541, 524);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // frmRoleQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 872);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmRoleQuery";
            this.Text = "角色管理";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdAllUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAllUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdRoleUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRoleUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdRoleList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRoleList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gdRoleList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRoleList;
        private DevExpress.XtraEditors.SimpleButton btnRemveFromRole;
        private DevExpress.XtraEditors.SimpleButton btnAddToRole;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraGrid.Columns.GridColumn gcName;
        private DevExpress.XtraGrid.Columns.GridColumn gcRemark;
        private DevExpress.XtraGrid.GridControl gdRoleUsers;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRoleUsers;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl gdAllUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAllUser;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}