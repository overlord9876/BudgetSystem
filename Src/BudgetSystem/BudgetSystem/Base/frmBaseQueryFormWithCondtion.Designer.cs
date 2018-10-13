namespace BudgetSystem
{
    partial class frmBaseQueryFormWithCondtion
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
            this.nbcCondtion = new DevExpress.XtraNavBar.NavBarControl();
            this.nbgMyCondition = new DevExpress.XtraNavBar.NavBarGroup();
            this.panCondition = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.nbgCustonCondtions = new DevExpress.XtraNavBar.NavBarGroup();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.nbcCondtion)).BeginInit();
            this.nbcCondtion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nbcCondtion
            // 
            this.nbcCondtion.ActiveGroup = this.nbgMyCondition;
            this.nbcCondtion.Controls.Add(this.panCondition);
            this.nbcCondtion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nbcCondtion.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nbgMyCondition,
            this.nbgCustonCondtions});
            this.nbcCondtion.Location = new System.Drawing.Point(0, 0);
            this.nbcCondtion.Name = "nbcCondtion";
            this.nbcCondtion.OptionsNavPane.ExpandedWidth = 140;
            this.nbcCondtion.Size = new System.Drawing.Size(293, 897);
            this.nbcCondtion.TabIndex = 0;
            this.nbcCondtion.Text = "nbcConditon";
            // 
            // nbgMyCondition
            // 
            this.nbgMyCondition.Caption = "我的查询";
            this.nbgMyCondition.Expanded = true;
            this.nbgMyCondition.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
            this.nbgMyCondition.Name = "nbgMyCondition";
            // 
            // panCondition
            // 
            this.panCondition.Name = "panCondition";
            this.panCondition.Size = new System.Drawing.Size(285, 463);
            this.panCondition.TabIndex = 1;
            // 
            // nbgCustonCondtions
            // 
            this.nbgCustonCondtions.Caption = "自定义查询";
            this.nbgCustonCondtions.ControlContainer = this.panCondition;
            this.nbgCustonCondtions.Expanded = true;
            this.nbgCustonCondtions.GroupClientHeight = 470;
            this.nbgCustonCondtions.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.nbgCustonCondtions.Name = "nbgCustonCondtions";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel1;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.nbcCondtion);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1440, 897);
            this.splitContainerControl1.SplitterPosition = 293;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // frmBaseQueryFormWithCondtion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 897);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmBaseQueryFormWithCondtion";
            this.Text = "frmBaseQueryFormWithCondtion";
            ((System.ComponentModel.ISupportInitialize)(this.nbcCondtion)).EndInit();
            this.nbcCondtion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraNavBar.NavBarControl nbcCondtion;
        protected DevExpress.XtraNavBar.NavBarGroup nbgMyCondition;
        protected DevExpress.XtraNavBar.NavBarGroup nbgCustonCondtions;
        protected DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        protected DevExpress.XtraNavBar.NavBarGroupControlContainer panCondition;
    }
}