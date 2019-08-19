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
        UserManager um = new UserManager();
        const string COMMONQUERY_TOBECONFIRMED = "未确认银行水单";
        const string COMMONQUERY_CONFIRMED = "已确认银行水单";
        const string COMMONQUERY_ALL = "所有银行水单";

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
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Delete, "删除银行水单"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.SplitCost, "收汇进入合同"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ModifyApply, "申请修改"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Confirm, "收汇确认"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View, "查看详情"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ExportData, "导出数据"));

            this.RegeditQueryOperate<InMoneyQueryCondition>(true, new List<string> { COMMONQUERY_ALL, COMMONQUERY_CONFIRMED, COMMONQUERY_TOBECONFIRMED }, "收款查询");

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
            else if (operate.Operate == OperateTypes.Delete.ToString())
            {
                DeleteBankSlip();
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
            InMoneyQueryCondition condition = new InMoneyQueryCondition();
            if (COMMONQUERY_TOBECONFIRMED.Equals(queryName))
            {
                condition.State = QueryReceiptState.ToBeConfirmed;
            }
            else if (COMMONQUERY_CONFIRMED.Equals(queryName))
            {
                condition.State = QueryReceiptState.Confirmed;
            }
            LoadData(condition);
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
                currentRowBankSlip = arm.GetBankSlipByBSID(currentRowBankSlip.BSID);
                if (currentRowBankSlip == null)
                {
                    XtraMessageBox.Show(string.Format("{0}收款单，已经被删除，请刷新数据。", currentRowBankSlip.VoucherNo));
                    return;
                }
                if (currentRowBankSlip.State == 2)
                {
                    XtraMessageBox.Show(string.Format("{0}收款单已经完成拆分，不允许再修改数据。", currentRowBankSlip.VoucherNo));
                    return;
                }
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

        private void DeleteBankSlip()
        {
            BankSlip currentRowBankSlip = this.gvInMoney.GetFocusedRow() as BankSlip;
            if (currentRowBankSlip != null)
            {
                currentRowBankSlip = arm.GetBankSlipByBSID(currentRowBankSlip.BSID);
                if (currentRowBankSlip == null)
                {
                    XtraMessageBox.Show(string.Format("{0}收款单，已经被删除，请刷新数据。", currentRowBankSlip.VoucherNo));
                    return;
                }
                if (currentRowBankSlip.State != 0)
                {
                    XtraMessageBox.Show(string.Format("{0}收款单不是已发布状态，不允删除数据。", currentRowBankSlip.VoucherNo));
                    return;
                }
                if (XtraMessageBox.Show(string.Format("是否真的要删除【{0}】银行水单？删除后将无法恢复。", currentRowBankSlip.VoucherNo), "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.arm.DeleteBankSlip(currentRowBankSlip);

                    XtraMessageBox.Show("删除成功。");
                    this.gvInMoney.DeleteRow(this.gvInMoney.FocusedRowHandle);
                }
            }
            else
            {
                XtraMessageBox.Show("请选择需要删除的项");
            }
        }

        private void StartFlow()
        {
            BankSlip currentRowBankSlip = this.gvInMoney.GetFocusedRow() as BankSlip;

            if (currentRowBankSlip != null)
            {
                currentRowBankSlip = arm.GetBankSlipByBSID(currentRowBankSlip.BSID);

                if (currentRowBankSlip == null)
                {
                    XtraMessageBox.Show(string.Format("{0}收款单，已经被删除，请刷新数据。", currentRowBankSlip.VoucherNo));
                    return;
                }
                List<User> salesMans = um.GetBankSlipSalesmanList(currentRowBankSlip.BSID);
                if (!salesMans.Exists(o => o.UserName.Equals(RunInfo.Instance.CurrentUser.UserName)))
                {
                    XtraMessageBox.Show(string.Format("当前银行水单不属于【{0}】，不允许提交流程", RunInfo.Instance.CurrentUser.RealName));
                    return;
                }
                if (currentRowBankSlip.EnumFlowState == EnumDataFlowState.审批中)
                {
                    XtraMessageBox.Show(string.Format("{0}收款单{1}，不允许重复提交。", currentRowBankSlip.VoucherNo, currentRowBankSlip.EnumFlowState.ToString()));
                    return;
                }
                if (currentRowBankSlip.ReceiptState != ReceiptState.已拆分)
                {
                    XtraMessageBox.Show(string.Format("{0}收款单不是已拆分状态，不需要提交修改申请。", currentRowBankSlip.VoucherNo));
                    return;
                }
                frmDescription frmBudget = new frmDescription();
                if (frmBudget.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    currentRowBankSlip.ReceiptState = ReceiptState.拆分中;
                    currentRowBankSlip.UpdateTimestamp = arm.ModifyBankSlipState(currentRowBankSlip);
                    string message = arm.StartFlow(currentRowBankSlip.BSID, RunInfo.Instance.CurrentUser.UserName, frmBudget.Description);
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
        }

        private void Confirm()
        {
            BankSlip currentRowBankSlip = this.gvInMoney.GetFocusedRow() as BankSlip;

            if (currentRowBankSlip != null)
            {
                currentRowBankSlip = arm.GetBankSlipByBSID(currentRowBankSlip.BSID);
                if (currentRowBankSlip == null)
                {
                    XtraMessageBox.Show(string.Format("{0}收款单，已经被删除，请刷新数据。", currentRowBankSlip.VoucherNo));
                    return;
                }
                if (currentRowBankSlip.EnumFlowState == EnumDataFlowState.审批中 || currentRowBankSlip.EnumFlowState == EnumDataFlowState.审批不通过)
                {
                    XtraMessageBox.Show(string.Format("{0}收款单{1}，此时不允许确认入账。", currentRowBankSlip.VoucherNo, currentRowBankSlip.EnumFlowState.ToString()));
                    return;
                }
                if (currentRowBankSlip.CNY2 != 0)
                {
                    XtraMessageBox.Show(string.Format("金额未分拆完成，此时不允许确认入账。"));
                    return;
                }
                if (currentRowBankSlip.State == 2)
                {
                    XtraMessageBox.Show(string.Format("{0}收款单已经被拆分，不允许重复拆分。", currentRowBankSlip.VoucherNo));
                    return;
                }
                try
                {
                    currentRowBankSlip.ReceiptState = ReceiptState.已拆分;
                    currentRowBankSlip.IsActive = true;
                    currentRowBankSlip.UpdateTimestamp = arm.ConfirmSplitAmount(currentRowBankSlip);
                    XtraMessageBox.Show("提交数据成功。");
                    this.RefreshData();
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
                currentRowBankSlip = arm.GetBankSlipByBSID(currentRowBankSlip.BSID);
                if (currentRowBankSlip == null)
                {
                    XtraMessageBox.Show(string.Format("{0}收款单，已经被删除，请刷新数据。", currentRowBankSlip.VoucherNo));
                    return;
                }
                if (currentRowBankSlip.EnumFlowState == EnumDataFlowState.审批中 || currentRowBankSlip.EnumFlowState == EnumDataFlowState.审批不通过)
                {
                    XtraMessageBox.Show("当前属于未审批通过状态，不允许直接进行拆分。");
                    return;
                }
                else
                {
                    if (currentRowBankSlip.ReceiptState == ReceiptState.已拆分)
                    {
                        XtraMessageBox.Show("当前属于已拆分状态，不允许再次进行拆分。");
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
                condition = new InMoneyQueryCondition();
            }
            condition = RunInfo.Instance.GetConditionByCurrentUser(condition) as InMoneyQueryCondition;
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
