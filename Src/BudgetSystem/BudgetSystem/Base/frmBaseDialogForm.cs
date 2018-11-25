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
            else if (this.WorkModel == EditFormWorkModels.SplitConst)
            {
                SubmitSplitConstData();
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

        protected virtual void SubmitSplitConstData()
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

    }
}