using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Reflection;

namespace BudgetSystem
{
    public partial class frmBaseDialogForm : frmBaseForm
    {
        public frmBaseDialogForm()
        {
            InitializeComponent();
            this.IsNotifyWhenFormClosing = true;
        }

        public EditFormWorkModels WorkModel
        {
            get;
            set;
        }

        public string CustomWorkModel
        {
            get;
            set;
        }

        protected Stream GetResourceFile(string resouceName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceStream(resouceName);
        }

        protected Stream GetResourceFileByWorkModel(EditFormWorkModels workModel)
        {
            string resouceName = "";
            if (workModel != EditFormWorkModels.Custom)
            {
                resouceName = this.GetType().ToString() + "_" + workModel.ToString() + ".xml";
            }
            else
            {
                resouceName = this.GetType().ToString() + "_" + this.CustomWorkModel + ".xml";
            }

            return GetResourceFile(resouceName);
        }

        protected Stream GetResourceFileByCurrentWorkModel()
        {
            return GetResourceFileByWorkModel(this.WorkModel);
        }

        protected void SetLayoutControlStyle(EditFormWorkModels workModel = EditFormWorkModels.Default, DevExpress.XtraLayout.LayoutControl layout = null)
        {
            if (layout == null)
            {
                layout = GetMainLayoutControl();
            }
            if (layout == null)
            {
                throw new Exception("未找到需要配置的Layount");
            }

            if (workModel == EditFormWorkModels.Default)
            {
                workModel = this.WorkModel;
            }

            Stream stream = GetResourceFileByWorkModel(workModel);

            if (stream != null)
            {
                layout.RestoreLayoutFromStream(stream);
                stream.Close();
                stream.Dispose();
            }

        }

        protected virtual void SubmitDataByWorkModel()
        {
            if (this.WorkModel == EditFormWorkModels.New)
            {
                SubmitNewData();
            }

            else if (this.WorkModel == EditFormWorkModels.Modify)
            {
                SubmitModifyData();
            }

            else if (this.WorkModel == EditFormWorkModels.View)
            {
                SubmitViewData();
            }
            else if (this.WorkModel == EditFormWorkModels.SplitToBudget)
            {
                SubmitSplitToBudgetData();
            }
            else if (this.WorkModel == EditFormWorkModels.Custom)
            {
                SubmitCustomData();
            }
        }

        protected virtual void SubmitNewData()
        {

        }

        protected virtual void SubmitModifyData()
        {

        }

        protected virtual void SubmitSplitToBudgetData()
        {

        }

        protected virtual void SubmitViewData()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected virtual void SubmitCustomData()
        {

        }

        private DevExpress.XtraLayout.LayoutControl GetMainLayoutControl()
        {
            foreach (Control c in this.Controls)
            {
                if (c is DevExpress.XtraLayout.LayoutControl)
                {
                    return c as DevExpress.XtraLayout.LayoutControl;
                }

            }
            return null;
        }


        public bool IsNotifyWhenFormClosing
        {
            get;
            set;
        }



        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {

            int WM_KEYDOWN = 256;
            int WM_SYSKEYDOWN = 260;

            if (msg.Msg == WM_KEYDOWN | msg.Msg == WM_SYSKEYDOWN)
            {
                if (keyData == Keys.Escape)
                {
                    if (XtraMessageBox.Show("是否关闭编辑窗体？", "请确认", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                    {
                        return true;
                    }

                }
            }

            return base.ProcessCmdKey(ref msg,  keyData);
        }


        public virtual void PrintItem()
        { 
        
        }
    }
}