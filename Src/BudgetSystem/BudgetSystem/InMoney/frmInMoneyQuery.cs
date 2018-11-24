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
        ReceiptMgmtManager arm = new ReceiptMgmtManager();


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
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New, "新增银行水单"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify, "修改银行水单"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.SplitCost, "费用拆分"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.SplitRequest, "申请修改费用拆分"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View, "查看详情"));

            this.ModelOperatePageName = "入帐单";
        }


        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
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
                BankSlip currentRowActualReceipts = this.gvInMoney.GetFocusedRow() as BankSlip;

                if (currentRowActualReceipts != null)
                {
                    currentRowActualReceipts = arm.GetAllActualReceipts(currentRowActualReceipts.BSID);
                    if (currentRowActualReceipts != null)
                    {
                        if (currentRowActualReceipts.State == 0)
                        {
                            //设置成待拆分状态
                            //arm.ModifyActualReceiptState(currentRowActualReceipts.BSID, (int)ReceiptState.待拆分);
                            currentRowActualReceipts.State = (int)ReceiptState.待拆分;
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
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                ViewActualReceipts();
            }
        }

        private void AddActualReceipts()
        {
            frmInMoneyEdit form = new frmInMoneyEdit();
            form.WorkModel = EditFormWorkModels.New;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.RefreshData();
            }
        }

        private void ModifyActualReceipts()
        {
            BankSlip currentRowBankSlip = this.gvInMoney.GetFocusedRow() as BankSlip;
            if (currentRowBankSlip != null)
            {
                frmInMoneyEdit form = new frmInMoneyEdit();
                form.WorkModel = EditFormWorkModels.Modify;
                form.CurrentBankSlip = currentRowBankSlip;
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.RefreshData();
                }
            }
            else
            {
                XtraMessageBox.Show("请选择需要修改的项");
            }
        }

        private void SplitMoneyToBudgetActualReceipts()
        {
            BankSlip currentRowBankSlip = this.gvInMoney.GetFocusedRow() as BankSlip;
            if (currentRowBankSlip != null)
            {
                frmInMoneyEdit form = new frmInMoneyEdit();
                form.WorkModel = EditFormWorkModels.SplitToBudget;
                form.CurrentBankSlip = currentRowBankSlip;
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.RefreshData();
                }
            }
        }

        private void SplitConstMoneyActualReceipts()
        {
            BudgetBill currentRowActualReceipts = this.gvInMoney.GetFocusedRow() as BudgetBill;
            if (currentRowActualReceipts != null)
            {
                //if (currentRowActualReceipts.State != 1)//不是待拆分状态不允许拆分
                //{
                //    XtraMessageBox.Show("当前不属于待拆分状态，不允许直接进行拆分。");
                //    return;
                //}
                //frmInMoneyEdit form = new frmInMoneyEdit();
                //form.WorkModel = EditFormWorkModels.SplitConst;
                //form.CurrentBankSlip = currentRowActualReceipts;
                //if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                //{
                //    this.RefreshData();
                //}
            }
        }

        private void ViewActualReceipts()
        {
            BankSlip currentRowBankSlip = this.gvInMoney.GetFocusedRow() as BankSlip;
            {
                frmInMoneyEdit form = new frmInMoneyEdit();
                form.WorkModel = EditFormWorkModels.View;
                form.CurrentBankSlip = currentRowBankSlip;
                form.ShowDialog(this);
            }
        }

        public override void LoadData()
        {
            List<BankSlip> arList = null;
            if (RunInfo.Instance.CurrentUser.Role == frmInMoneyEdit.SaleRoleCode)
            {
                arList = arm.GetBankSlipListByUserName(RunInfo.Instance.CurrentUser.UserName);
            }
            else
            {
                arList = arm.GetAllBankSlipList();
            }
            this.gcInMoney.DataSource = arList;
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
