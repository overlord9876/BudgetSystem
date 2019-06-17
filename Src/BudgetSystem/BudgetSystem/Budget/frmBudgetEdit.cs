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

        private bool isStartFlow = false;
        private Bll.BudgetManager bm = new Bll.BudgetManager();
        public frmBudgetEdit()
        {
            InitializeComponent();
        }

        protected override void SubmitNewData()
        {
            base.SubmitNewData();
            bool requiredResult = true;
            bool checkResult = this.ucBudgetEdit1.CheckInputData(isStartFlow, out requiredResult);
            if (!checkResult && isStartFlow || requiredResult == false)
            {
                return;
            }
            this.ucBudgetEdit1.FillData();
            this.ucBudgetEdit1.CurrentBudget.IsValid = checkResult;
            int result = bm.AddBudget(this.ucBudgetEdit1.CurrentBudget, isStartFlow);
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
            bool requiredResult = true;
            bool checkResult = this.ucBudgetEdit1.CheckInputData(isStartFlow, out requiredResult);
            if (!checkResult && isStartFlow || requiredResult == false)
            {
                return;
            }
            this.ucBudgetEdit1.FillData();
            this.ucBudgetEdit1.CurrentBudget.IsValid = checkResult;
            string message = bm.ModifyBudget(this.ucBudgetEdit1.CurrentBudget, string.Empty, isStartFlow);
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
                this.btnSubmit.Enabled = false;
            }
            else if (this.WorkModel == EditFormWorkModels.Print)
            {
                this.Text = "打印";
                layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                emptySpaceItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem51.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem50.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            isStartFlow = false;
            SubmitDataByWorkModel();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            isStartFlow = true;
            SubmitDataByWorkModel();
        }
        #endregion

        public override void PrintData()
        {
            this.Height += 200;
            PrinterHelper.PrintControl(true, this.layoutControl1);
        }
    }
}
