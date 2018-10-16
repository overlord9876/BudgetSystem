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

        protected Stream GetResourceFileByCurrentWorkModel()
        {
            string resouceName = "";
            if (WorkModel != EditFormWorkModels.Custom)
            {
                resouceName = this.GetType().ToString() + "_" + this.WorkModel.ToString() + ".xml";
            }
            else
            {
                resouceName = this.GetType().ToString() + "_" + this.CustomWorkModel + ".xml";
            }

            return GetResourceFile(resouceName);
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

        protected virtual void SubmitViewData()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected virtual void SubmitCustomData()
        { 
        
        }
    
    }
}