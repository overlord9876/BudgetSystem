using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Bll;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BudgetSystem.Entity;

namespace BudgetSystem.InMoney
{
    public partial class frmInMoneyQuery : frmBaseQueryFormWithCondtion
    {
        ActualReceiptsManager arManager = new ActualReceiptsManager();


        private GridHitInfo hInfo;

        public frmInMoneyQuery()
        {
            InitializeComponent();
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New, "新增入账"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify, "分拆至合同"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Delete, "删除入账"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.SplitCost, "费用拆分"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View, "查看详情"));

            this.ModelOperatePageName = "入帐单";
        }


        public override void OperateHandled(ModelOperate operate)
        {

            if (operate.Operate == OperateTypes.New.ToString())
            {
                AddActualReceipts();
            }
            //else if (operate.Operate == OperateTypes.Modify.ToString())
            //{
            //    ModifyActualReceipts();
            //}
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                SplitMoneyToBudgetActualReceipts();
            }
            else if (operate.Operate == OperateTypes.SplitCost.ToString())
            {
                SplitConstMoneyActualReceipts();
            }
            else if (operate.Operate == OperateTypes.Delete.ToString())
            {
                //？可能不存在删除
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                ViewActualReceipts();
            }
        }

        private void AddActualReceipts()
        {
            ActualReceipts currentRowActualReceipts = this.gvInMoney.GetFocusedRow() as ActualReceipts;
            {
                frmInMoneyEdit form = new frmInMoneyEdit();
                form.WorkModel = EditFormWorkModels.New;
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.RefreshData();
                }
            }
        }

        private void ModifyActualReceipts()
        {
            ActualReceipts currentRowActualReceipts = this.gvInMoney.GetFocusedRow() as ActualReceipts;
            if (currentRowActualReceipts != null)
            {
                frmInMoneyEdit form = new frmInMoneyEdit();
                form.WorkModel = EditFormWorkModels.Modify;
                form.CurrentActualReceipts = currentRowActualReceipts;
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.RefreshData();
                }
            }
        }

        private void SplitMoneyToBudgetActualReceipts()
        {
            ActualReceipts currentRowActualReceipts = this.gvInMoney.GetFocusedRow() as ActualReceipts;
            if (currentRowActualReceipts != null)
            {
                frmInMoneyEdit form = new frmInMoneyEdit();
                form.WorkModel = EditFormWorkModels.SplitToBudget;
                form.CurrentActualReceipts = currentRowActualReceipts;
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.RefreshData();
                }
            }
        }

        private void SplitConstMoneyActualReceipts()
        {
            ActualReceipts currentRowActualReceipts = this.gvInMoney.GetFocusedRow() as ActualReceipts;
            if (currentRowActualReceipts != null)
            {
                frmInMoneyEdit form = new frmInMoneyEdit();
                form.WorkModel = EditFormWorkModels.SplitConst;
                form.CurrentActualReceipts = currentRowActualReceipts;
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.RefreshData();
                }
            }
        }

        private void ViewActualReceipts()
        {
            ActualReceipts currentRowActualReceipts = this.gvInMoney.GetFocusedRow() as ActualReceipts;
            {
                frmInMoneyEdit form = new frmInMoneyEdit();
                form.WorkModel = EditFormWorkModels.View;
                form.CurrentActualReceipts = currentRowActualReceipts;
                form.ShowDialog(this);
            }
        }

        public override void LoadData()
        {
            var list = arManager.GetAllActualReceipts();

            this.gridControl1.DataSource = list;
        }


        private void gvUser_DoubleClick(object sender, EventArgs e)
        {
            if (hInfo.InRow)
            {
                ModifyActualReceipts();
            }
        }

        private void gvUser_MouseDown(object sender, MouseEventArgs e)
        {
            hInfo = gvInMoney.CalcHitInfo(e.Y, e.Y);
        }


    }
}
