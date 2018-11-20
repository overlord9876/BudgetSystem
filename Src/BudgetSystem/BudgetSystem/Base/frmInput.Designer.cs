namespace BudgetSystem.Base
{
    partial class frmInput
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
            this.labInfo = new DevExpress.XtraEditors.LabelControl();
            this.txtInput = new DevExpress.XtraEditors.TextEdit();
            this.btnSure = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtInput.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labInfo
            // 
            this.labInfo.Location = new System.Drawing.Point(52, 31);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(60, 18);
            this.labInfo.TabIndex = 0;
            this.labInfo.Text = "请输入：";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(52, 66);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(579, 25);
            this.txtInput.TabIndex = 1;
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(442, 108);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(85, 32);
            this.btnSure.TabIndex = 2;
            this.btnSure.Text = "确定";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(546, 108);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 32);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // frmInput
            // 
            this.AcceptButton = this.btnSure;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(679, 165);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.labInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "输入";
            ((System.ComponentModel.ISupportInitialize)(this.txtInput.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labInfo;
        private DevExpress.XtraEditors.TextEdit txtInput;
        private DevExpress.XtraEditors.SimpleButton btnSure;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
    }
}