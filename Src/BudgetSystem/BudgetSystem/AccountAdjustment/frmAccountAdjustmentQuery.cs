using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BudgetSystem.Entity;
using BudgetSystem.Entity.QueryCondition;
using BudgetSystem.WorkSpace;

namespace BudgetSystem
{
    public partial class frmAccountAdjustmentQuery : frmBaseQueryForm
    {
        private Bll.AccountAdjustmentManager aam = new Bll.AccountAdjustmentManager();
        private Bll.FlowManager fm = new Bll.FlowManager();
        private const string COMMONQUERY_MYCREATE = "我创建的";
        AccountAdjustmentQueryCondition currentCondition = null;
        public frmAccountAdjustmentQuery()
        {
            InitializeComponent();
            this.Module = BusinessModules.AccountAdjustmentManagement;
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New, "新增付款调账"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.NewReciept, "新增收款调账"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.NewPayment, "新增交单调账"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Delete));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.SubmitApply, "调账申请"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ModifyApply, "调账修改"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.DeleteApply, "调账删除"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ViewApply, "查看审批状态"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ExportData, "导出数据"));

            this.RegeditQueryOperate<AccountAdjustmentQueryCondition>(true, new List<string> { COMMONQUERY_MYCREATE }, "调账查询");

            this.RegeditPrintOperate();

            this.ModelOperatePageName = "调账列表";
        }
        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {
            base.OperateHandled(operate, e);
            if (operate.Operate == OperateTypes.New.ToString())
            {
                this.CreateAccountAdjustment(AdjustmentType.付款);
            }
            else if (operate.Operate == OperateTypes.NewReciept.ToString())
            {
                this.CreateAccountAdjustment(AdjustmentType.收款);
            }
            else if (operate.Operate == OperateTypes.NewPayment.ToString())
            {
                this.CreateAccountAdjustment(AdjustmentType.交单);
            }
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                this.ModifyAccountAdjustment();
            }
            else if (operate.Operate == OperateTypes.SubmitApply.ToString())
            {
                SubmitApply();
            }
            else if (operate.Operate == OperateTypes.ModifyApply.ToString())
            {
                ModifyApply();
            }
            else if (operate.Operate == OperateTypes.DeleteApply.ToString())
            {
                DeleteApply();
            }
            else if (operate.Operate == OperateTypes.ViewApply.ToString())
            {
                ViewApplyHistory();
            }
            else if (operate.Operate == OperateTypes.Delete.ToString())
            {
                this.DeleteAccountAdjustment();
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                this.ViewAccountAdjustment();
            }
            else if (operate.Operate == OperateTypes.ExportData.ToString())
            {
                ExportData();
            }

        }

        protected override void DoCommonQuery(string queryName)
        {
            if (COMMONQUERY_MYCREATE.Equals(queryName))
            {
                AccountAdjustmentQueryCondition condition = new AccountAdjustmentQueryCondition() { CreateUser = RunInfo.Instance.CurrentUser.UserName };
                LoadData(condition);
            }
        }

        protected override void DoConditionQuery(BaseQueryCondition condition)
        {
            this.LoadData((AccountAdjustmentQueryCondition)condition);
        }

        protected override QueryConditionEditorForm CreateConditionEditorForm()
        {
            frmAccountAdjustmentQueryConditionEditor form = new frmAccountAdjustmentQueryConditionEditor();
            form.QueryName = this.GetType().ToString();
            form.QueryCondition = this.currentCondition;
            return form;
        }

        private static List<string> Sales = new List<string>();

        private void CreateAccountAdjustment(AdjustmentType atType)
        {
            frmAccountAdjustmentEdit form = new frmAccountAdjustmentEdit();
            form.WorkModel = EditFormWorkModels.New;
            form.SetAdjustmentType(atType);
            form.SetAdjustmentRole(RunInfo.Instance.GetAdjustmentRole());
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.RefreshData();
            }
        }

        private void ModifyAccountAdjustment()
        {
            if (this.gvAccountAdjustment.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("请选择需要修改的项");
                return;
            }
            AccountAdjustment AccountAdjustment = this.gvAccountAdjustment.GetRow(this.gvAccountAdjustment.FocusedRowHandle) as AccountAdjustment;
            if (AccountAdjustment == null)
            {
                XtraMessageBox.Show("请选择需要修改的项");
                return;
            }
            AccountAdjustment = aam.GetAccountAdjustment(AccountAdjustment.ID, AccountAdjustment.Type);
            if (AccountAdjustment == null)
            {

                XtraMessageBox.Show("您选择修改的项已经不存在，请刷新数据");
                return;
            }

            EnumFlowNames updateFlowName = EnumFlowNames.修改调账审批流程;
            if (AccountAdjustment.EnumRole == AdjustmentRole.财务调账)
            {
                updateFlowName = EnumFlowNames.财务修改调账审批流程;
            }
            if (AccountAdjustment.EnumFlowState == EnumDataFlowState.审批中 || (AccountAdjustment.EnumFlowState == EnumDataFlowState.审批通过 && !updateFlowName.ToString().Equals(AccountAdjustment.FlowName)))
            {
                string priex = AccountAdjustment.EnumFlowState == EnumDataFlowState.审批中 ? "正在" : "已经";
                XtraMessageBox.Show($"您选择修改的项{priex}{AccountAdjustment.EnumFlowState}，不允许修改。");
                return;
            }
            frmAccountAdjustmentEdit form = new frmAccountAdjustmentEdit();
            form.WorkModel = EditFormWorkModels.Modify;
            form.SetAdjustmentType(AccountAdjustment.Type);
            form.CurrentAccountAdjustment = AccountAdjustment;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.RefreshData();
            }
        }

        private void DeleteAccountAdjustment()
        {
            if (this.gvAccountAdjustment.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("请选择需要删除的项");
                return;
            }
            AccountAdjustment accountAdjustment = this.gvAccountAdjustment.GetRow(this.gvAccountAdjustment.FocusedRowHandle) as AccountAdjustment;
            if (accountAdjustment == null)
            {
                XtraMessageBox.Show("请选择需要删除的项");
                return;
            }

            accountAdjustment = aam.GetAccountAdjustment(accountAdjustment.ID, accountAdjustment.Type);
            if (accountAdjustment == null)
            {
                XtraMessageBox.Show("您选择删除的项已经不存在，请刷新数据");
                return;
            }

            EnumFlowNames flowName = EnumFlowNames.删除调账审批流程;
            if (accountAdjustment.EnumRole == AdjustmentRole.财务调账)
            {
                flowName = EnumFlowNames.财务删除调账审批流程;
            }
            if (!string.IsNullOrEmpty(accountAdjustment.FlowName) && (accountAdjustment.FlowName != flowName.ToString() || accountAdjustment.EnumFlowState != EnumDataFlowState.审批通过))
            {
                XtraMessageBox.Show($"您选择删除的项未审批通过，不允许删除。");
                return;
            }
            aam.DeleteAccountAdjustment(accountAdjustment);

            this.gvAccountAdjustment.DeleteRow(this.gvAccountAdjustment.FocusedRowHandle);
        }

        private void ViewAccountAdjustment()
        {
            if (this.gvAccountAdjustment.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("请选择需要查看详情的项");
                return;
            }
            AccountAdjustment AccountAdjustment = this.gvAccountAdjustment.GetRow(this.gvAccountAdjustment.FocusedRowHandle) as AccountAdjustment;
            if (AccountAdjustment != null)
            {
                AccountAdjustment = aam.GetAccountAdjustment(AccountAdjustment.ID, AccountAdjustment.Type);
                if (AccountAdjustment == null)
                {

                    XtraMessageBox.Show("您选择修改的项已经不存在，请刷新数据");
                    return;
                }
                frmAccountAdjustmentEdit form = new frmAccountAdjustmentEdit();
                form.WorkModel = EditFormWorkModels.View;
                form.SetAdjustmentType(AccountAdjustment.Type);
                form.CurrentAccountAdjustment = AccountAdjustment;
                form.ShowDialog(this);
            }
            else
            {
                XtraMessageBox.Show("请选择需要查看详情的项");
            }
        }

        private void ViewApplyHistory()
        {
            if (this.gvAccountAdjustment.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("请选择需要查看审批状态的项");
                return;
            }
            AccountAdjustment adjustment = this.gvAccountAdjustment.GetRow(this.gvAccountAdjustment.FocusedRowHandle) as AccountAdjustment;
            if (adjustment != null)
            {
                frmHistory hisotryForm = new frmHistory();
                hisotryForm.Points = fm.GetFlowRunPointsByData(adjustment.ID, adjustment.ToDataType().ToString());
                hisotryForm.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("请选择需要查看审批状态的项");
            }
        }

        private void SubmitApply()
        {
            if (this.gvAccountAdjustment.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("请选择需要提交流程的项");
                return;
            }
            AccountAdjustment adjustment = this.gvAccountAdjustment.GetRow(this.gvAccountAdjustment.FocusedRowHandle) as AccountAdjustment;
            if (adjustment != null)
            {
                adjustment = this.aam.GetAccountAdjustment(adjustment.ID, adjustment.Type);
                if (adjustment == null)
                {
                    XtraMessageBox.Show("您选择提交流程的项已经不存在，请刷新数据");
                    return;
                }
                if (adjustment.State != AccountAdjustmentState.调账完成)
                {
                    XtraMessageBox.Show("调账未完成，请先完成调账再提交审批。");
                    return;
                }
                EnumFlowNames flowName = EnumFlowNames.调账审批流程;
                EnumFlowNames updateFlowName = EnumFlowNames.修改调账审批流程;
                EnumFlowNames deleteFlowName = EnumFlowNames.删除调账审批流程;
                if (adjustment.EnumRole == AdjustmentRole.财务调账)
                {
                    flowName = EnumFlowNames.财务调账审批流程;
                    updateFlowName = EnumFlowNames.财务修改调账审批流程;
                    deleteFlowName = EnumFlowNames.财务删除调账审批流程;
                }
                if (!string.IsNullOrEmpty(adjustment.FlowName))
                {
                    if (!ValidationFlowState(adjustment, flowName)) { return; }
                    if (adjustment.EnumRole != RunInfo.Instance.GetAdjustmentRole())
                    {
                        XtraMessageBox.Show($"当前用户只可提交{RunInfo.Instance.GetAdjustmentRole()}类别流程单，不允许提交{adjustment.EnumRole}类别流程单。");
                    }
                    if (adjustment.FlowName.Equals(updateFlowName) && (adjustment.EnumFlowState == EnumDataFlowState.审批中))
                    {
                        XtraMessageBox.Show($"{updateFlowName}未完成，不能重新启动流程。");
                        return;
                    }
                    if (adjustment.FlowName.Equals(deleteFlowName) && (adjustment.EnumFlowState == EnumDataFlowState.审批中))
                    {
                        XtraMessageBox.Show($"{deleteFlowName}未完成，不能重新启动流程。");
                        return;
                    }
                }
                string message = aam.StartFlow(adjustment, flowName, RunInfo.Instance.CurrentUser.UserName, RunInfo.Instance.CurrentUser.RealName, string.Format("发起{0}", flowName));
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
            else
            {
                XtraMessageBox.Show("请选择需要提交流程的项");
            }
        }

        private void ModifyApply()
        {
            if (this.gvAccountAdjustment.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("请选择需要申请修改的项");
                return;
            }
            AccountAdjustment adjustment = this.gvAccountAdjustment.GetRow(this.gvAccountAdjustment.FocusedRowHandle) as AccountAdjustment;
            if (adjustment != null)
            {
                adjustment = this.aam.GetAccountAdjustment(adjustment.ID, adjustment.Type);
                if (adjustment == null)
                {
                    XtraMessageBox.Show("您选择提交流程的项已经不存在，请刷新数据");
                    return;
                }
                if (adjustment.State != AccountAdjustmentState.调账完成)
                {
                    XtraMessageBox.Show("调账未完成，请先完成调账再提交审批。");
                    return;
                }
                EnumFlowNames flowName = EnumFlowNames.调账审批流程;
                EnumFlowNames updateFlowName = EnumFlowNames.修改调账审批流程;
                EnumFlowNames deleteFlowName = EnumFlowNames.删除调账审批流程;

                if (adjustment.EnumRole == AdjustmentRole.财务调账)
                {
                    flowName = EnumFlowNames.财务调账审批流程;
                    updateFlowName = EnumFlowNames.财务修改调账审批流程;
                    deleteFlowName = EnumFlowNames.财务删除调账审批流程;
                }
                if (string.IsNullOrEmpty(adjustment.FlowName))
                {
                    XtraMessageBox.Show($"未启动{flowName},不允许直接启动{updateFlowName}");
                    return;
                }
                if (!ValidationFlowState(adjustment, updateFlowName)) { return; }
                if (adjustment.EnumRole != RunInfo.Instance.GetAdjustmentRole())
                {
                    XtraMessageBox.Show($"当前用户只可提交{RunInfo.Instance.GetAdjustmentRole()}类别流程单，不允许提交{adjustment.EnumRole}类别流程单。");
                }
                if (adjustment.FlowName.Equals(flowName) && (adjustment.EnumFlowState == EnumDataFlowState.审批中))
                {
                    XtraMessageBox.Show($"{flowName}未完成，不能重新启动流程。");
                    return;
                }
                if (adjustment.FlowName.Equals(deleteFlowName) && (adjustment.EnumFlowState == EnumDataFlowState.审批中))
                {
                    XtraMessageBox.Show($"{deleteFlowName}未完成，不能重新启动流程。");
                    return;
                }
                frmDescription frmBudget = new frmDescription();
                if (frmBudget.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    string message = aam.StartFlow(adjustment, updateFlowName, RunInfo.Instance.CurrentUser.UserName, RunInfo.Instance.CurrentUser.RealName, string.Format("发起{0}，{1}", updateFlowName, frmBudget.Description), false);
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
            else
            {
                XtraMessageBox.Show("请选择需要申请修改的项");
            }
        }

        private void DeleteApply()
        {
            if (this.gvAccountAdjustment.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("请选择需要申请删除的项");
                return;
            }
            AccountAdjustment adjustment = this.gvAccountAdjustment.GetRow(this.gvAccountAdjustment.FocusedRowHandle) as AccountAdjustment;
            if (adjustment != null)
            {
                adjustment = this.aam.GetAccountAdjustment(adjustment.ID, adjustment.Type);
                if (adjustment == null)
                {
                    XtraMessageBox.Show("您选择提交流程的项已经不存在，请刷新数据");
                    return;
                }
                if (adjustment.State != AccountAdjustmentState.调账完成)
                {
                    XtraMessageBox.Show("调账未完成，请先完成调账再提交审批。");
                    return;
                }
                EnumFlowNames flowName = EnumFlowNames.调账审批流程;
                EnumFlowNames updateFlowName = EnumFlowNames.修改调账审批流程;
                EnumFlowNames deleteFlowName = EnumFlowNames.删除调账审批流程;

                if (adjustment.EnumRole == AdjustmentRole.财务调账)
                {
                    flowName = EnumFlowNames.财务调账审批流程;
                    updateFlowName = EnumFlowNames.财务修改调账审批流程;
                    deleteFlowName = EnumFlowNames.财务删除调账审批流程;
                }
                if (string.IsNullOrEmpty(adjustment.FlowName))
                {
                    XtraMessageBox.Show($"未启动{flowName},不允许直接启动{deleteFlowName}");
                    return;
                }
                if (!ValidationFlowState(adjustment, EnumFlowNames.修改调账审批流程)) { return; }
                if (adjustment.EnumRole != RunInfo.Instance.GetAdjustmentRole())
                {
                    XtraMessageBox.Show($"当前用户只可提交{RunInfo.Instance.GetAdjustmentRole()}类别流程单，不允许提交{adjustment.EnumRole}类别流程单。");
                }
                if (adjustment.FlowName.Equals(flowName) && (adjustment.EnumFlowState == EnumDataFlowState.审批中))
                {
                    XtraMessageBox.Show($"{flowName}未完成，不能重新启动流程。");
                    return;
                }
                if (adjustment.FlowName.Equals(updateFlowName) && (adjustment.EnumFlowState == EnumDataFlowState.审批中))
                {
                    XtraMessageBox.Show($"{updateFlowName}未完成，不能重新启动流程。");
                    return;
                }
                frmDescription frmBudget = new frmDescription("填写申请删除说明", "删除说明");
                if (frmBudget.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    string message = aam.StartFlow(adjustment, deleteFlowName, RunInfo.Instance.CurrentUser.UserName, RunInfo.Instance.CurrentUser.RealName, string.Format("发起{0}，{1}", deleteFlowName, frmBudget.Description), false);
                    if (string.IsNullOrEmpty(message))
                    {
                        XtraMessageBox.Show("提交流程成功。");
                        LoadData();
                        XtraMessageBox.Show("请选择需要申请删除的项");
                    }
                    else
                    {
                        XtraMessageBox.Show(message);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("请选择需要申请删除的项");
            }
        }

        private void ExportData()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel|*.xlsx|Excel2003|*.xls";
            saveFileDialog.Title = "保存";
            if (saveFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            if (saveFileDialog.FileName.ToLower().EndsWith(".xls"))
            {
                this.gvAccountAdjustment.Export(DevExpress.XtraPrinting.ExportTarget.Xls, saveFileDialog.FileName);
            }
            else
            {
                this.gvAccountAdjustment.Export(DevExpress.XtraPrinting.ExportTarget.Xlsx, saveFileDialog.FileName);
            }
        }

        private void LoadData(AccountAdjustmentQueryCondition condition)
        {
            currentCondition = condition;
            if (condition == null)
            {
                condition = new AccountAdjustmentQueryCondition();
            }
            var conditionNew = RunInfo.Instance.GetConditionByCurrentUser(condition) as AccountAdjustmentQueryCondition;
            var list = aam.GetAllAccountAdjustment(conditionNew);
            this.gridAccountAdjustment.DataSource = list;
            this.gvAccountAdjustment.BestFitColumns();
        }

        public override void LoadData()
        {
            LoadData(null);
        }

        protected override void InitGridViewAction()
        {
            this.gridViewAction.Add(this.gvAccountAdjustment, new ActionWithPermission() { MainAction = ModifyAccountAdjustment, MainOperate = OperateTypes.Modify, SecondAction = ViewAccountAdjustment, SecondOperate = OperateTypes.View });

        }

        protected override void PrintItem()
        {
            if (this.gvAccountAdjustment.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("请选择需要打印的项");
                return;
            }
            AccountAdjustment AccountAdjustment = this.gvAccountAdjustment.GetRow(this.gvAccountAdjustment.FocusedRowHandle) as AccountAdjustment;
            if (AccountAdjustment != null)
            {
                frmAccountAdjustmentPrint form = new frmAccountAdjustmentPrint();
                form.WorkModel = EditFormWorkModels.Print;
                form.BindData(AccountAdjustment.ID, AccountAdjustment.Type);
                form.PrintItem();
                //form.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("请选择需要打印的项");
            }
        }
        private bool ValidationFlowState(AccountAdjustment adjustment, EnumFlowNames flowName)
        {
            if (adjustment.EnumFlowState == EnumDataFlowState.审批中 || (flowName.ToString().Equals(adjustment.FlowName) && adjustment.EnumFlowState == EnumDataFlowState.审批通过))
            {
                XtraMessageBox.Show($"{adjustment.FlowName }{adjustment.EnumFlowState},不能重新启动流程");
                return false;
            }
            if (!adjustment.CreateUser.Equals(RunInfo.Instance.CurrentUser.UserName))
            {
                XtraMessageBox.Show(string.Format("当前预算单由{0}创建，不允许由{1}提交流程", adjustment.CreateRealUserName, RunInfo.Instance.CurrentUser.RealName));
                return false;
            }
            return true;
        }

    }
}