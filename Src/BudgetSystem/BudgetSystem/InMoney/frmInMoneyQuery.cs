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
using BudgetSystem.Entity.QueryCondition;
using BudgetSystem.Util;

namespace BudgetSystem.InMoney
{
    public partial class frmInMoneyQuery : frmBaseQueryForm
    {
        ReceiptMgmtManager arm = new ReceiptMgmtManager();

        public frmInMoneyQuery()
        {
            InitializeComponent();
            this.Module = BusinessModules.InMoneyManagement;
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New, "新增银行水单"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify, "修改银行水单"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.SplitCost, "收汇拆分"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ModifyApply, "申请修改"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Confirm, "收汇确认"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View, "查看详情"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ExportData, "导出数据"));

            this.RegeditQueryOperate<InMoneyQueryCondition>(true, new List<string> { "默认", "查询1", "查询2" });

            this.RegeditPrintOperate();

            this.ModelOperatePageName = "入帐单";
        }

        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {
            base.OperateHandled(operate, e);

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
            else if (operate.Operate == OperateTypes.ModifyApply.ToString())
            {
                StartFlow();
            }
            else if (operate.Operate == OperateTypes.Confirm.ToString())
            {
                Confirm();
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                ViewBankSlip();
            }
            else if (operate.Operate == OperateTypes.ExportData.ToString())
            {
                ExportData();
            }
        }

        protected override void DoCommonQuery(string queryName)
        {
            XtraMessageBox.Show(queryName);
        }

        protected override void DoConditionQuery(BaseQueryCondition condition)
        {
            LoadData(condition as InMoneyQueryCondition);
        }

        protected override QueryConditionEditorForm CreateConditionEditorForm()
        {
            frmInMoneyQueryConditionEditor form = new frmInMoneyQueryConditionEditor();
            form.QueryName = this.GetType().ToString();
            return form;
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

        private void Confirm()
        {
            BankSlip currentRowBankSlip = this.gvInMoney.GetFocusedRow() as BankSlip;

            if (currentRowBankSlip != null)
            {
                currentRowBankSlip = arm.GetBankSlipByBSID(currentRowBankSlip.BSID);
                if (currentRowBankSlip.EnumFlowState == EnumDataFlowState.审批中 || currentRowBankSlip.EnumFlowState == EnumDataFlowState.审批不通过)
                {
                    XtraMessageBox.Show(string.Format("{0}收款单{1}，此时不允许确认入账。", currentRowBankSlip.VoucherNo, currentRowBankSlip.EnumFlowState.ToString()));
                    return;
                }
                if (currentRowBankSlip.CNY2 > 0)
                {
                    XtraMessageBox.Show(string.Format("金额未分拆完成，此时不允许确认入账。"));
                    return;
                }
                try
                {
                    currentRowBankSlip.ReceiptState = ReceiptState.已拆分;
                    currentRowBankSlip.IsActive = true;
                    currentRowBankSlip.UpdateTimestamp = arm.ConfirmSplitAmount(currentRowBankSlip);
                    XtraMessageBox.Show("提交数据成功。");
                }
                catch (Exception ex)
                {
                    RunInfo.Instance.Logger.LogError(ex);
                    XtraMessageBox.Show("提交数据失败。");
                }
            }
        }

        private void SplitConstMoneyBankSlip()
        {
            BankSlip currentRowBankSlip = this.gvInMoney.GetFocusedRow() as BankSlip;
            if (currentRowBankSlip != null)
            {
                if (currentRowBankSlip.EnumFlowState == EnumDataFlowState.审批中 || currentRowBankSlip.EnumFlowState == EnumDataFlowState.审批不通过)
                {
                    XtraMessageBox.Show("当前不属于未审批通过状态，不允许直接进行拆分。");
                    return;
                }
                else
                {
                    if (currentRowBankSlip.ReceiptState == ReceiptState.已拆分 && currentRowBankSlip.EnumFlowState != EnumDataFlowState.审批通过)//不是待拆分状态不允许拆分
                    {
                        XtraMessageBox.Show("当前不属于已拆分状态，不允许直接进行拆分。");
                        return;
                    }
                }
                frmInMoneyEdit form = new frmInMoneyEdit();
                form.WorkModel = EditFormWorkModels.SplitToBudget;
                form.CurrentBankSlip = currentRowBankSlip;
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.RefreshData();
                }
            }
            else
            {
                XtraMessageBox.Show("请选择需要费用拆分的项");
            }
        }

        private void ViewBankSlip()
        {
            BankSlip currentRowBankSlip = this.gvInMoney.GetFocusedRow() as BankSlip;
            if (currentRowBankSlip != null)
            {
                frmInMoneyEdit form = new frmInMoneyEdit();
                form.WorkModel = EditFormWorkModels.View;
                form.CurrentBankSlip = currentRowBankSlip;
                form.ShowDialog(this);
            }
            else
            {
                XtraMessageBox.Show("请选择需要查看详情的项");
            }
        }

        private void ExportData()
        {
            frmInMoneyDetailExport export = new frmInMoneyDetailExport();
            export.ExportData();
        }

        public override void LoadData()
        {
            LoadData(null);
        }

        private void LoadData(InMoneyQueryCondition condition)
        {

            if (condition == null)
            {
                if (RunInfo.Instance.CurrentUser.Role == StringUtil.SaleRoleCode)
                {
                    condition = new InMoneyQueryCondition();
                    condition.Salesman = RunInfo.Instance.CurrentUser.UserName;
                }
            }
            List<BankSlip> bsList = arm.GetAllBankSlipList(condition);

            this.gcInMoney.DataSource = bsList;

            this.gvInMoney.BestFitColumns();
        }

        protected override void InitGridViewAction()
        {
            this.gridViewAction.Add(this.gvInMoney, new ActionWithPermission() { MainAction = ModifyBankSlip, MainOperate = OperateTypes.Modify, SecondAction = ViewBankSlip, SecondOperate = OperateTypes.View });

        }

        protected override void PrintItem()
        {
            BankSlip currentRowBankSlip = this.gvInMoney.GetFocusedRow() as BankSlip;
            if (currentRowBankSlip != null)
            {
                frmInMoneyEdit form = new frmInMoneyEdit();
                form.WorkModel = EditFormWorkModels.Print;
                form.CurrentBankSlip = currentRowBankSlip;
                form.PrintItem();
            }
            else
            {
                XtraMessageBox.Show("请选择需要打印的项");
            }
        }
    }
}
