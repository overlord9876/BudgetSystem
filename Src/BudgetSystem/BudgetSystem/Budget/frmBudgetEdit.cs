using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Newtonsoft.Json;
using BudgetSystem.Entity;
using DevExpress.XtraEditors;
using System.Text.RegularExpressions;

namespace BudgetSystem
{
    public partial class frmBudgetEdit : frmBaseDialogForm
    {
        public Budget CurrentBudget { get; set; }

       
        private Bll.BudgetManager bm = new Bll.BudgetManager();
        public frmBudgetEdit()
        {
            InitializeComponent();
        }

        protected override void SubmitNewData()
        {
            base.SubmitNewData();

            bool checkResult = this.ucBudgetEdit1.CheckInputData();
            if (!checkResult)
            {
                return;
            }
            this.ucBudgetEdit1.FillData();

            int result = bm.AddBudget(this.ucBudgetEdit1.CurrentBudget);
            if (result <= 0)
            {
                XtraMessageBox.Show("创建失败！");
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected override void SubmitModifyData()
        {
            base.SubmitModifyData();  
            bool checkResult = this.ucBudgetEdit1.CheckInputData();
            if (!checkResult)
            {
                return;
            }
            this.ucBudgetEdit1.FillData(); 

            string message= bm.ModifyBudget(this.ucBudgetEdit1.CurrentBudget);
            if (!string.IsNullOrEmpty(message))
            {
                XtraMessageBox.Show(message, "提示");
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }


 
        #region Event Method
        private void frmBudgetEditEx_Load(object sender, EventArgs e)
        {
            this.ucBudgetEdit1.InitData();
            this.ucBudgetEdit1.CurrentBudget = this.CurrentBudget;
            this.ucBudgetEdit1.WorkModel = this.WorkModel;
            if (this.WorkModel == EditFormWorkModels.New)
            { 
                this.Text = "创建预算单";
            }
            else if (this.WorkModel == EditFormWorkModels.Modify)
            {
                this.Text = "编辑预算单信息"; 
            }
            else if (this.WorkModel == EditFormWorkModels.View)
            {
                this.Text = "查看预算单信息"; 
                this.btnSure.Enabled = false; 
            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            SubmitDataByWorkModel();
        }

        #endregion

       




    }
}
