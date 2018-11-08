namespace BudgetSystem.UserManage
{
    partial class frmUserQuery
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
            this.gridUser = new DevExpress.XtraGrid.GridControl();
            this.gvUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRealName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRole = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcState = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUser)).BeginInit();
            this.SuspendLayout();
            // 
            // gridUser
            // 
            this.gridUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridUser.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridUser.Location = new System.Drawing.Point(0, 0);
            this.gridUser.MainView = this.gvUser;
            this.gridUser.Margin = new System.Windows.Forms.Padding(2);
            this.gridUser.Name = "gridUser";
            this.gridUser.Size = new System.Drawing.Size(1291, 929);
            this.gridUser.TabIndex = 1;
            this.gridUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUser});
            // 
            // gvUser
            // 
            this.gvUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcUserName,
            this.gcRealName,
            this.gcRole,
            this.gcDepartment,
            this.gcState});
            this.gvUser.GridControl = this.gridUser;
            this.gvUser.Name = "gvUser";
            this.gvUser.OptionsBehavior.Editable = false;
            this.gvUser.OptionsView.ShowGroupPanel = false;

            // 
            // gcUserName
            // 
            this.gcUserName.Caption = "用户名";
            this.gcUserName.FieldName = "UserName";
            this.gcUserName.Name = "gcUserName";
            this.gcUserName.Visible = true;
            this.gcUserName.VisibleIndex = 0;
            // 
            // gcRealName
            // 
            this.gcRealName.Caption = "用户姓名";
            this.gcRealName.FieldName = "RealName";
            this.gcRealName.Name = "gcRealName";
            this.gcRealName.Visible = true;
            this.gcRealName.VisibleIndex = 1;
            // 
            // gcRole
            // 
            this.gcRole.Caption = "用户角色";
            this.gcRole.FieldName = "RoleName";
            this.gcRole.Name = "gcRole";
            this.gcRole.Visible = true;
            this.gcRole.VisibleIndex = 2;
            // 
            // gcDepartment
            // 
            this.gcDepartment.Caption = "所在部门";
            this.gcDepartment.FieldName = "DepartmentName";
            this.gcDepartment.Name = "gcDepartment";
            this.gcDepartment.Visible = true;
            this.gcDepartment.VisibleIndex = 3;
            // 
            // gcState
            // 
            this.gcState.Caption = "状态";
            this.gcState.FieldName = "State";
            this.gcState.Name = "gcState";
            this.gcState.Visible = true;
            this.gcState.VisibleIndex = 4;
            // 
            // frmUserQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 929);
            this.Controls.Add(this.gridUser);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmUserQuery";
            this.Text = "用户管理";
            ((System.ComponentModel.ISupportInitialize)(this.gridUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUser;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserName;
        private DevExpress.XtraGrid.Columns.GridColumn gcRealName;
        private DevExpress.XtraGrid.Columns.GridColumn gcRole;
        private DevExpress.XtraGrid.Columns.GridColumn gcState;
        private DevExpress.XtraGrid.Columns.GridColumn gcDepartment;
    }
}