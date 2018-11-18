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
        ActualReceiptsManager arm = new ActualReceiptsManager();


        private GridHitInfo hInfo;

        public frmInMoneyQuery()
        {
            InitializeComponent();
            this.Module = BusinessModules.InMoneyManagement;
            this.gvInMoney.MouseDown += new MouseEventHandler(gvInMoney_MouseDown);
            this.gvInMoney.DoubleClick += new EventHandler(gvInMoney_DoubleClick);
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New, "新增入账"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify, "分拆至合同"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Delete, "删除入账"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.SplitCost, "费用拆分"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.SplitRequest, "费用拆分申请"));
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
            else if (operate.Operate == OperateTypes.SplitRequest.ToString())
            {
                ActualReceipts currentRowActualReceipts = this.gvInMoney.GetFocusedRow() as ActualReceipts;

                if (currentRowActualReceipts != null)
                {
                    currentRowActualReceipts = arm.GetActualReceiptById(currentRowActualReceipts.ID);
                    if (currentRowActualReceipts != null)
                    {
                        if (currentRowActualReceipts.State == 0)
                        {
                            //设置成待拆分状态
                            arm.ModifyActualReceiptState(currentRowActualReceipts.ID, (int)ReceiptState.入账);
                            currentRowActualReceipts.State = (int)ReceiptState.入账;
                        }
                        else
                        {
                            XtraMessageBox.Show("入帐单不是入账状态，不允许提交拆分申请。");
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("入帐单已不存在。");
                    }

                }
                else
                {
                    XtraMessageBox.Show("入帐单已不存在。");
                }
            }
            else if (operate.Operate == OperateTypes.Delete.ToString())
            {
                ActualReceipts currentRowActualReceipts = this.gvInMoney.GetFocusedRow() as ActualReceipts;
                if (currentRowActualReceipts != null)
                {
                    arm.DeleteActualReceipt(currentRowActualReceipts.ID, RunInfo.Instance.CurrentUser.UserName);
                    XtraMessageBox.Show("删除成功");
                }
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                ViewActualReceipts();
            }
        }

        private void DeleteActualReceipts()
        {

            ActualReceipts currentRowActualReceipts = this.gvInMoney.GetFocusedRow() as ActualReceipts;
            if (currentRowActualReceipts != null)
            {
                //arm.CreateActualReceipts
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
            var list = arm.GetAllActualReceipts();

            this.gcInMoney.DataSource = list;
        }


        private void gvInMoney_DoubleClick(object sender, EventArgs e)
        {
            if (hInfo.InRow)
            {
                //ModifyActualReceipts();
            }
        }

        private void gvInMoney_MouseDown(object sender, MouseEventArgs e)
        {
            hInfo = gvInMoney.CalcHitInfo(e.Y, e.Y);
        }


    }
}
