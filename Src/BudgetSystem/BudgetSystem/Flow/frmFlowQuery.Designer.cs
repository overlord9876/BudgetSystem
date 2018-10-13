namespace BudgetSystem
{
    partial class frmFlowQuery
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcFlowName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEditor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLastEditTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(916, 812);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcFlowName,
            this.gcEditor,
            this.gcLastEditTime,
            this.gcDesc});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            // 
            // gcFlowName
            // 
            this.gcFlowName.Caption = "流程名称";
            this.gcFlowName.FieldName = "Name";
            this.gcFlowName.Name = "gcFlowName";
            this.gcFlowName.OptionsColumn.FixedWidth = true;
            this.gcFlowName.Visible = true;
            this.gcFlowName.VisibleIndex = 0;
            this.gcFlowName.Width = 117;
            // 
            // gcEditor
            // 
            this.gcEditor.Caption = "修改人";
            this.gcEditor.FieldName = "Editor";
            this.gcEditor.Name = "gcEditor";
            this.gcEditor.OptionsColumn.FixedWidth = true;
            this.gcEditor.Visible = true;
            this.gcEditor.VisibleIndex = 1;
            this.gcEditor.Width = 120;
            // 
            // gcLastEditTime
            // 
            this.gcLastEditTime.Caption = "修改时间";
            this.gcLastEditTime.FieldName = "EditTime";
            this.gcLastEditTime.Name = "gcLastEditTime";
            this.gcLastEditTime.OptionsColumn.FixedWidth = true;
            this.gcLastEditTime.Visible = true;
            this.gcLastEditTime.VisibleIndex = 2;
            this.gcLastEditTime.Width = 153;
            // 
            // gcDesc
            // 
            this.gcDesc.Caption = "描述";
            this.gcDesc.FieldName = "Description";
            this.gcDesc.Name = "gcDesc";
            this.gcDesc.Visible = true;
            this.gcDesc.VisibleIndex = 3;
            this.gcDesc.Width = 508;
            // 
            // frmFlowQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 812);
            this.Controls.Add(this.gridControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmFlowQuery";
            this.Text = "流程配置";

            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcFlowName;
        private DevExpress.XtraGrid.Columns.GridColumn gcEditor;
        private DevExpress.XtraGrid.Columns.GridColumn gcLastEditTime;
        private DevExpress.XtraGrid.Columns.GridColumn gcDesc;
    }
}