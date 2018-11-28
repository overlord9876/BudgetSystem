﻿namespace BudgetSystem.WorkSpace
{
    partial class frmApproveEx
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
            this.btnViewFlow = new DevExpress.XtraEditors.SimpleButton();
            this.btnViewHistory = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.btnReturn = new DevExpress.XtraEditors.SimpleButton();
            this.btnRevoke = new DevExpress.XtraEditors.SimpleButton();
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.txtMyInfo = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcApproveGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcDataGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.查询审批记录 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.esiData = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMyInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcApproveGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcDataGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.查询审批记录)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnViewFlow);
            this.layoutControl1.Controls.Add(this.btnViewHistory);
            this.layoutControl1.Controls.Add(this.btnExit);
            this.layoutControl1.Controls.Add(this.btnConfirm);
            this.layoutControl1.Controls.Add(this.btnReturn);
            this.layoutControl1.Controls.Add(this.btnRevoke);
            this.layoutControl1.Controls.Add(this.btnAccept);
            this.layoutControl1.Controls.Add(this.txtMyInfo);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem5});
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1197, 392, 547, 488);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1363, 1017);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnViewFlow
            // 
            this.btnViewFlow.Location = new System.Drawing.Point(504, 965);
            this.btnViewFlow.Name = "btnViewFlow";
            this.btnViewFlow.Size = new System.Drawing.Size(116, 28);
            this.btnViewFlow.StyleController = this.layoutControl1;
            this.btnViewFlow.TabIndex = 11;
            this.btnViewFlow.Text = "查看流程";
            this.btnViewFlow.Click += new System.EventHandler(this.btnViewFlow_Click);
            // 
            // btnViewHistory
            // 
            this.btnViewHistory.Location = new System.Drawing.Point(384, 965);
            this.btnViewHistory.Name = "btnViewHistory";
            this.btnViewHistory.Size = new System.Drawing.Size(116, 28);
            this.btnViewHistory.StyleController = this.layoutControl1;
            this.btnViewHistory.TabIndex = 10;
            this.btnViewHistory.Text = "查询审批记录";
            this.btnViewHistory.Click += new System.EventHandler(this.btnViewHistory_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(1223, 965);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(116, 28);
            this.btnExit.StyleController = this.layoutControl1;
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "退出";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(264, 965);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(116, 28);
            this.btnConfirm.StyleController = this.layoutControl1;
            this.btnConfirm.TabIndex = 8;
            this.btnConfirm.Text = "确认审批结果";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(144, 965);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(116, 28);
            this.btnReturn.StyleController = this.layoutControl1;
            this.btnReturn.TabIndex = 7;
            this.btnReturn.Text = "驳回";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnRevoke
            // 
            this.btnRevoke.Location = new System.Drawing.Point(384, 965);
            this.btnRevoke.Name = "btnRevoke";
            this.btnRevoke.Size = new System.Drawing.Size(116, 28);
            this.btnRevoke.StyleController = this.layoutControl1;
            this.btnRevoke.TabIndex = 6;
            this.btnRevoke.Text = "撤回审批";
            this.btnRevoke.Click += new System.EventHandler(this.btnRevoke_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(24, 965);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(116, 28);
            this.btnAccept.StyleController = this.layoutControl1;
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "审批通过";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtMyInfo
            // 
            this.txtMyInfo.Location = new System.Drawing.Point(24, 803);
            this.txtMyInfo.Name = "txtMyInfo";
            this.txtMyInfo.Size = new System.Drawing.Size(1315, 158);
            this.txtMyInfo.StyleController = this.layoutControl1;
            this.txtMyInfo.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcApproveGroup,
            this.lcDataGroup});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1363, 1017);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lcApproveGroup
            // 
            this.lcApproveGroup.CustomizationFormText = "我的审批";
            this.lcApproveGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.emptySpaceItem1,
            this.查询审批记录,
            this.layoutControlItem8,
            this.emptySpaceItem3});
            this.lcApproveGroup.Location = new System.Drawing.Point(0, 733);
            this.lcApproveGroup.Name = "lcApproveGroup";
            this.lcApproveGroup.Size = new System.Drawing.Size(1343, 264);
            this.lcApproveGroup.Text = "审批";
            // 
            // lcDataGroup
            // 
            this.lcDataGroup.CustomizationFormText = "审批对象";
            this.lcDataGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.esiData});
            this.lcDataGroup.Location = new System.Drawing.Point(0, 0);
            this.lcDataGroup.Name = "lcDataGroup";
            this.lcDataGroup.Size = new System.Drawing.Size(1343, 733);
            this.lcDataGroup.Text = "审批对象";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtMyInfo;
            this.layoutControlItem1.CustomizationFormText = "审批意见：";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(79, 120);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1319, 183);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "审批意见：";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(75, 18);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnAccept;
            this.layoutControlItem2.CustomizationFormText = "审批通过";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 183);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(120, 32);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(100, 32);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(120, 32);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "审批通过";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnReturn;
            this.layoutControlItem4.CustomizationFormText = "驳回";
            this.layoutControlItem4.Location = new System.Drawing.Point(120, 183);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(120, 32);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(100, 32);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(120, 32);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "驳回";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnExit;
            this.layoutControlItem6.CustomizationFormText = "退出";
            this.layoutControlItem6.Location = new System.Drawing.Point(1199, 183);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(120, 32);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(100, 32);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(120, 32);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "退出";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(600, 183);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(599, 32);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // 查询审批记录
            // 
            this.查询审批记录.Control = this.btnViewHistory;
            this.查询审批记录.CustomizationFormText = "查询审批记录";
            this.查询审批记录.Location = new System.Drawing.Point(360, 183);
            this.查询审批记录.MaxSize = new System.Drawing.Size(120, 32);
            this.查询审批记录.MinSize = new System.Drawing.Size(100, 32);
            this.查询审批记录.Name = "查询审批记录";
            this.查询审批记录.Size = new System.Drawing.Size(120, 32);
            this.查询审批记录.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.查询审批记录.Text = "查询审批记录";
            this.查询审批记录.TextSize = new System.Drawing.Size(0, 0);
            this.查询审批记录.TextToControlDistance = 0;
            this.查询审批记录.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnViewFlow;
            this.layoutControlItem8.CustomizationFormText = "查看流程";
            this.layoutControlItem8.Location = new System.Drawing.Point(480, 183);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(120, 32);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(100, 32);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(120, 32);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.Text = "查看流程";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(240, 183);
            this.emptySpaceItem3.MaxSize = new System.Drawing.Size(120, 32);
            this.emptySpaceItem3.MinSize = new System.Drawing.Size(100, 32);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(120, 32);
            this.emptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // esiData
            // 
            this.esiData.AllowHotTrack = false;
            this.esiData.CustomizationFormText = "emptySpaceItem2";
            this.esiData.Location = new System.Drawing.Point(0, 0);
            this.esiData.Name = "esiData";
            this.esiData.Size = new System.Drawing.Size(1319, 684);
            this.esiData.Text = "esiData";
            this.esiData.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnRevoke;
            this.layoutControlItem3.CustomizationFormText = "撤回审批";
            this.layoutControlItem3.Location = new System.Drawing.Point(360, 183);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(120, 32);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(100, 32);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(120, 32);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "撤回审批";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnConfirm;
            this.layoutControlItem5.CustomizationFormText = "确认审批结果";
            this.layoutControlItem5.Location = new System.Drawing.Point(240, 183);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(120, 32);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(100, 32);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(120, 32);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "确认审批结果";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // frmApproveEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(1363, 1017);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmApproveEx";
            this.Text = "frmApproveEx";
            this.Load += new System.EventHandler(this.frmApproveEx_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtMyInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcApproveGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcDataGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.查询审批记录)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.MemoEdit txtMyInfo;
        private DevExpress.XtraEditors.SimpleButton btnConfirm;
        private DevExpress.XtraEditors.SimpleButton btnReturn;
        private DevExpress.XtraEditors.SimpleButton btnRevoke;
        private DevExpress.XtraEditors.SimpleButton btnAccept;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnViewFlow;
        private DevExpress.XtraEditors.SimpleButton btnViewHistory;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlGroup lcApproveGroup;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem 查询审批记录;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlGroup lcDataGroup;
        private DevExpress.XtraLayout.EmptySpaceItem esiData;
    }
}