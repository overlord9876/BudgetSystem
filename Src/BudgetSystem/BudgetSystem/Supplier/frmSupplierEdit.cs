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
        private Bll.SupplierManager sm = new Bll.SupplierManager();
        private bool saveSucceed = false;
        private bool isStartFlow = false;
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
                this.ucSupplierEdit1.BindingData(this.CurrentSupplier.ID);
            }
            else if (this.WorkModel == EditFormWorkModels.View)
            {
                this.ucSupplierEdit1.BindingData(this.CurrentSupplier.ID);
                this.Text = "查看供应商信息";
            }
            else if (this.WorkModel == EditFormWorkModels.Custom)
            {
                this.ucSupplierEdit1.BindingData(this.CurrentSupplier.ID);
                this.Text = "提交复审审批";
            }
        }

        

        private void btnSure_Click(object sender, EventArgs e)
        {
            if (this.WorkModel == EditFormWorkModels.Custom)
            {
                XtraMessageBox.Show("复评审批申请，请提交流程审批");
                return;
            }
            isStartFlow = false;
            SubmitDataByWorkModel();
            if (saveSucceed)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }


        protected override void SubmitNewData()
        {
            base.SubmitNewData();
            bool result = this.ucSupplierEdit1.CheckInputData(isStartFlow);
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
            saveSucceed = true;
        }
        protected override void SubmitCustomData()
        {
            base.SubmitCustomData();
            //复审
            bool result = this.ucSupplierEdit1.CheckInputData(isStartFlow);
            if (result == false)
            {
                return;
            }
            this.ucSupplierEdit1.FillData();
            sm.ModifySupplier(this.ucSupplierEdit1.CurrentSupplier);
            saveSucceed = true;
        }



        protected override void SubmitModifyData()
        {
            base.SubmitModifyData();
            bool result = this.ucSupplierEdit1.CheckInputData(isStartFlow);
            if (result == false)
            {
                return;
            }
            this.ucSupplierEdit1.FillData();
            sm.ModifySupplier(this.ucSupplierEdit1.CurrentSupplier);
            saveSucceed = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            isStartFlow = true;
            SubmitDataByWorkModel();
            if (saveSucceed)
            {
                if (this.ucSupplierEdit1.CurrentSupplier.EnumFlowState == EnumDataFlowState.审批中)
                {
                    XtraMessageBox.Show("审批中不允许重复提交。");
                    return;
                }
                EnumFlowNames flowName = EnumFlowNames.供应商审批流程;
                if (this.WorkModel == EditFormWorkModels.Custom)
                {
                    flowName = EnumFlowNames.供应商复审流程;
                }
                string message = sm.StartFlow(flowName,this.ucSupplierEdit1.CurrentSupplier.ID, RunInfo.Instance.CurrentUser.UserName);
                if (string.IsNullOrEmpty(message))
                {
                    XtraMessageBox.Show("提交流程成功。");
                }
                else
                {
                    XtraMessageBox.Show(message);
                    return;
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }



    }
}