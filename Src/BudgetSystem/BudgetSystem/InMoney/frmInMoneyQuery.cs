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
            //this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify, "修改银行水单"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.SplitCost, "费用拆分"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.SplitRequest, "申请修改费用拆分"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View, "查看详情"));

            this.ModelOperatePageName = "入帐单";
        }


        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {

            if (operate.Operate == OperateTypes.New.ToString())
            {
                AddBankSlip();
            }
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                ModifyBankSlip();
            }
            else if (operate.Operate == OperateTypes.SplitCost.ToString())
            {
                SplitConstMoneyBankSlip();
            }
            else if (operate.Operate == OperateTypes.SplitRequest.ToString())
            {
                StartFlow();
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                ViewBankSlip();
            }
        }

        private void AddBankSlip()
        {
            frmInMoneyEdit form = new frmInMoneyEdit();
            form.WorkModel = EditFormWorkModels.New;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.RefreshData();
            }
        }

        private void ModifyBankSlip()
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

        private void SplitMoneyToBudgetBankSlip()
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

        private void StartFlow()
        {
            BankSlip currentRowBankSlip = this.gvInMoney.GetFocusedRow() as BankSlip;

            if (currentRowBankSlip != null)
            {
                if (currentRowBankSlip.EnumFlowState == EnumDataFlowState.审批中)
                {
                    XtraMessageBox.Show(string.Format("{0}收款单{1}，不允许重复提交。", currentRowBankSlip.VoucherNo, currentRowBankSlip.EnumFlowState.ToString()));
                    return;
                }
                string message = arm.StartFlow(currentRowBankSlip.BSID, RunInfo.Instance.CurrentUser.UserName);
                if (string.IsNullOrEmpty(message))
                {
                    XtraMessageBox.Show("提交流程成功。");
                    LoadData();
                }
                else
                {
                    XtraMessageBox.Show(message);
                }
            }
        }

        private void SplitConstMoneyBankSlip()
        {
            BankSlip currentRowBankSlip = this.gvInMoney.GetFocusedRow() as BankSlip;
            if (currentRowBankSlip != null)
            {
                if (currentRowBankSlip.EnumFlowState != EnumDataFlowState.审批通过)
                {
                    if (currentRowBankSlip.State != 0)//不是待拆分状态不允许拆分
                    {
                        XtraMessageBox.Show("当前不属于待拆分状态，不允许直接进行拆分。");
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show("当前不属于未审批通过状态，不允许直接进行拆分。");
                }
                frmInMoneyEdit form = new frmInMoneyEdit();
                form.WorkModel = EditFormWorkModels.SplitConst;
                form.CurrentBankSlip = currentRowBankSlip;
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.RefreshData();
                }
            }
        }

        private void ViewBankSlip()
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
            List<BankSlip> bsList = null;
            if (RunInfo.Instance.CurrentUser.Role == ucInMoneyEdit.SaleRoleCode)
            {
                bsList = arm.GetBankSlipListByUserName(RunInfo.Instance.CurrentUser.UserName);
            }
            else
            {
                bsList = arm.GetAllBankSlipList();
            }
            this.gcInMoney.DataSource = bsList;
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
