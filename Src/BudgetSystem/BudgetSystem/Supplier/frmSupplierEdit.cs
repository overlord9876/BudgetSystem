using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;
using Newtonsoft.Json;

namespace BudgetSystem
{
    public partial class frmSupplierEdit : frmBaseDialogForm
    {
        public Bll.SupplierManager sm = new Bll.SupplierManager();
        public Supplier CurrentSupplier
        {
            get;
            set;
        }
        public frmSupplierEdit()
        {
            InitializeComponent();
        }

        private void frmSupplierEdit_Load(object sender, EventArgs e)
        {
            this.ucSupplierEdit1.InitData();
            this.ucSupplierEdit1.CurrentSupplier = this.CurrentSupplier;
            this.ucSupplierEdit1.WorkModel = this.WorkModel;
            if (this.WorkModel == EditFormWorkModels.New)
            {
                this.Text = "创建供应商";
            }
            else if (this.WorkModel == EditFormWorkModels.Modify)
            {
                this.Text = "编辑供应商信息";
            }
            else if (this.WorkModel == EditFormWorkModels.View)
            {
                this.Text = "查看供应商信息";
            }
        }

        private bool IsOk = false;

        private void btnSure_Click(object sender, EventArgs e)
        {
            SubmitDataByWorkModel();
            if (IsOk)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }


        protected override void SubmitNewData()
        {
            base.SubmitNewData();
            bool result = this.ucSupplierEdit1.CheckInputData();
            if (result == false)
            {
                return;
            }
            this.ucSupplierEdit1.FillData();
            int id = sm.AddSupplier(this.ucSupplierEdit1.CurrentSupplier);
            if (id <= 0)
            {
                throw new Exception("创建失败！");
            }
            IsOk = true;
        }



        protected override void SubmitModifyData()
        {
            base.SubmitModifyData();
            bool result = this.ucSupplierEdit1.CheckInputData();
            if (result == false)
            {
                return;
            }
            this.ucSupplierEdit1.FillData();
            sm.ModifySupplier(this.ucSupplierEdit1.CurrentSupplier);
            IsOk = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SubmitDataByWorkModel();
            if (IsOk)
            {
                if (this.ucSupplierEdit1.CurrentSupplier.EnumFlowState == EnumDataFlowState.审批中)
                {
                    XtraMessageBox.Show(string.Format("{0}的供方{1}，不允许重复提交。", this.ucSupplierEdit1.CurrentSupplier.Name, this.ucSupplierEdit1.CurrentSupplier.EnumFlowState.ToString()));
                    return;
                }
                string message = sm.StartFlow(this.ucSupplierEdit1.CurrentSupplier.ID, RunInfo.Instance.CurrentUser.UserName);
                if (string.IsNullOrEmpty(message))
                {
                    XtraMessageBox.Show("提交流程成功。");
                }
                else
                {
                    XtraMessageBox.Show(message);
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }



    }
}