using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;
using DevExpress.XtraGrid.Views.Grid;

namespace BudgetSystem
{
    public partial class frmAccountAdjustmentEdit : frmBaseDialogForm
    {
        private Bll.AccountAdjustmentManager cm = new Bll.AccountAdjustmentManager();

        public AccountAdjustment CurrentAccountAdjustment { get; set; }

        public frmAccountAdjustmentEdit()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmAccountAdjustmentEdit_Load);
        }

        public void SetAdjustmentType(AdjustmentType atType)
        {
            this.ucAccountAdjustmentEdit1.SetAdjustmentType(atType);
        }

        public void SetAdjustmentRole(AdjustmentRole enumRole)
        {
            this.ucAccountAdjustmentEdit1.SetAdjustmentRole(enumRole);
        }

        private void frmAccountAdjustmentEdit_Load(object sender, EventArgs e)
        {
            if (this.WorkModel == EditFormWorkModels.New)
            {
                this.Text = "创建调账信息";
            }
            else if (this.WorkModel == EditFormWorkModels.Modify)
            {
                this.Text = "编辑调账信息";
                //BindingCustomer(Customer.ID);
            }
            else if (this.WorkModel == EditFormWorkModels.View)
            {
                this.Text = "查看调账信息";
            }
            this.ucAccountAdjustmentEdit1.WorkModel = this.WorkModel;
            this.ucAccountAdjustmentEdit1.InitData(CurrentAccountAdjustment);
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            SubmitDataByWorkModel();
        }

        private List<User> GetSelectUsers(GridView view)
        {
            List<User> result = new List<User>();
            int[] selectRows = view.GetSelectedRows();
            foreach (int row in selectRows)
            {
                User user = view.GetRow(row) as User;
                result.Add(user);
            }
            return result;
        }

        protected override void SubmitNewData()
        {
            base.SubmitNewData();

            this.dxErrorProvider1.ClearErrors();

            if (dxErrorProvider1.HasErrors)
            {
                return;
            }

            this.ucAccountAdjustmentEdit1.FillData();
            int result = cm.AddAccountAdjustment(this.ucAccountAdjustmentEdit1.Adjustment, this.ucAccountAdjustmentEdit1.AdjustmentDetail);
            if (result == -2)
            {
                XtraMessageBox.Show("已包含调账内容，请重新刷新数据。");
                return;
            }
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
            this.dxErrorProvider1.ClearErrors();

            if (dxErrorProvider1.HasErrors)
            {
                return;
            }
            this.ucAccountAdjustmentEdit1.FillData();
            this.ucAccountAdjustmentEdit1.Adjustment.UpdateDate = cm.ModifyAccountAdjustment(this.ucAccountAdjustmentEdit1.Adjustment, this.ucAccountAdjustmentEdit1.AdjustmentDetail);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public override void PrintData()
        {
            int SH = Screen.PrimaryScreen.Bounds.Height;
            if (SH < 800)
            {
                SH = 800;
            }
            else if (SH > 800)
            {
                SH = 719;
            }
            //this.Height = SH;
            //this.Height += 100;
            PrinterHelper.PrintControl(true, this.layoutControl1, new Size());
        }
    }
}