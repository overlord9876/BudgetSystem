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
using BudgetSystem.CommonControl;
using BudgetSystem.Bll;
using BudgetSystem.WorkSpace;
using BudgetSystem.Entity.QueryCondition;

namespace BudgetSystem
{
    public partial class frmBudgetQuery : frmBaseQueryForm
    {
        private FlowManager fm = new FlowManager();
        private Bll.BudgetManager bm = new Bll.BudgetManager();
        private CommonManager cm = new CommonManager();
        private DateTime datetimeNow = DateTime.MinValue;

        private const string COMMONQUERY_MYCREATE = "我负责的";
        private const string COMMONQUERY_GENERALMANAGERAPPROVAL = "已完成审批预算单列表";
        private const string COMMONQUERY_MANAGERAPPROVAL = "未完成审批预算单列表";
        private const string COMMONQUERY_ARCHIVEWARNINGQUERY = "预算单归档预警";
        private const string COMMONQUERY_FINANCEQUERY = "财务归档征求";
        private const string COMMONQUERY_FINANCEQUERYANDREJECTED = "财务归档征求及驳回归档";
        private const string COMMONQUERY_ARCHIVEQUERY = "预算单已归档合同列表";

        public frmBudgetQuery()
        {
            InitializeComponent();
            datetimeNow = cm.GetDateTimeNow();
            this.Module = BusinessModules.BuggetManagement;
            LookUpEditHelper.FillRepositoryItemLookUpEditByEnum_IntValue(this.rilueTradeNature, typeof(EnumTradeNature));
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ModifyEx, "修改其他供应商"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.SubmitApply, "提交流程"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ModifyApply, "申请修改"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.DeleteApply, "申请删除"));
            //this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Close));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Delete, "删除"));

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.FinancialArchiveApply, "财务归档征求"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Archive, "归档"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.RejectedAccount, "驳回归档征求"));

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ExportData, "导出"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ViewApply, "查看审批状态"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.BudgetAccountBill));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.FinalAccount));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.NewPayment, "财务调账"));

            this.RegeditQueryOperate<BudgetQueryCondition>(true, new List<string> 
                                                                            { COMMONQUERY_MYCREATE,
                                                                              COMMONQUERY_MANAGERAPPROVAL,
                                                                              COMMONQUERY_GENERALMANAGERAPPROVAL,     
                                                                              COMMONQUERY_ARCHIVEWARNINGQUERY,
                                                                              COMMONQUERY_FINANCEQUERY,
                                                                              COMMONQUERY_FINANCEQUERYANDREJECTED,
                                                                              COMMONQUERY_ARCHIVEQUERY
                                                                              }, "预算单查询");

            this.RegeditPrintOperate();

            this.ModelOperatePageName = "预算单";

        }

        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {
            base.OperateHandled(operate, e);

            if (operate.Operate == OperateTypes.New.ToString())
            {
                CreateBudget();
            }
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                ModifyBudget();
            }
            else if (operate.Operate == OperateTypes.ModifyEx.ToString())
            {
                ModifyBudgetSlipper();
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
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                ViewBudget();
            }
            else if (operate.Operate == OperateTypes.ViewApply.ToString())
            {
                ViewApplyHistory();
            }
            else if (operate.Operate == OperateTypes.Delete.ToString())
            {
                DeleteBudget();
            }
            else if (operate.Operate == OperateTypes.BudgetAccountBill.ToString())
            {
                ShowBudgetAccountBillView();
            }
            else if (operate.Operate == OperateTypes.ExportData.ToString())
            {
                ExportDataBudget();
            }
            else if (operate.Operate == OperateTypes.RejectedAccount.ToString())
            {
                RejectedAccount();
            }
            else if (operate.Operate == OperateTypes.FinancialArchiveApply.ToString())
            {
                FinancialArchiveApply();
            }
            else if (operate.Operate == OperateTypes.Archive.ToString())
            {
                Archive();
            }
            else if (operate.Operate == OperateTypes.FinalAccount.ToString())
            {
                FinalAccount();
            }
            else if (operate.Operate == OperateTypes.NewPayment.ToString())
            {
                AddPaymentNote();
            }
        }

        protected override void DoCommonQuery(string queryName)
        {
            if (COMMONQUERY_MYCREATE.Equals(queryName))
            {
                BudgetQueryCondition condition = new BudgetQueryCondition() { Salesman = RunInfo.Instance.CurrentUser.UserName };
                LoadData(condition);
            }
            else if (COMMONQUERY_GENERALMANAGERAPPROVAL.Equals(queryName))
            {
                BudgetQueryCondition condition = new BudgetQueryCondition() { IsGeneralManagerApproval = true };
                LoadData(condition);
            }
            else if (COMMONQUERY_MANAGERAPPROVAL.Equals(queryName))
            {
                BudgetQueryCondition condition = new BudgetQueryCondition() { IsManagerApproval = true };
                LoadData(condition);
            }
            else if (COMMONQUERY_ARCHIVEQUERY.Equals(queryName))
            {
                BudgetQueryCondition condition = new BudgetQueryCondition() { State = (int)EnumBudgetState.已结束 };
                LoadData(condition);
            }
            else if (COMMONQUERY_ARCHIVEWARNINGQUERY.Equals(queryName))
            {
                BudgetQueryCondition condition = new BudgetQueryCondition() { IsArchiveWarningQuery = true };
                LoadData(condition);
            }
            else if (COMMONQUERY_FINANCEQUERY.Equals(queryName))
            {
                BudgetQueryCondition condition = new BudgetQueryCondition() { State = (int)EnumBudgetState.财务归档征求 };
                LoadData(condition);
            }
            else if (COMMONQUERY_FINANCEQUERYANDREJECTED.Equals(queryName))
            {
                BudgetQueryCondition condition = new BudgetQueryCondition() { State = (int)EnumBudgetState.财务归档征求 | (int)EnumBudgetState.驳回归档征求 };
                LoadData(condition);
            }
        }

        protected override void DoConditionQuery(BaseQueryCondition condition)
        {
            this.LoadData((BudgetQueryCondition)condition);
        }

        protected override QueryConditionEditorForm CreateConditionEditorForm()
        {
            frmBudgetQueryConditionEditor form = new frmBudgetQueryConditionEditor();
            form.QueryName = this.GetType().ToString();
            return form;
        }
        public override void LoadData()
        {
            LoadData(null);
        }

        private void LoadData(BudgetQueryCondition condition)
        {
            if (condition == null)
            {
                condition = new BudgetQueryCondition();
            }
            condition = RunInfo.Instance.GetConditionByCurrentUser(condition) as BudgetQueryCondition;

            List<Budget> budgetList = bm.GetAllBudget(condition);
            this.gridBudget.DataSource = budgetList;
        }

        private void ShowBudgetAccountBillView()
        {
            if (this.gvBudget.FocusedRowHandle < 0)
            {
                return;
            }
            Budget budget = this.gvBudget.GetRow(this.gvBudget.FocusedRowHandle) as Budget;
            if (budget != null)
            {
                frmAccountBillView form = new frmAccountBillView();
                form.CurrentBudget = budget;

                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.RefreshData();
                }
            }
            else
            {
                XtraMessageBox.Show("请选择需要按合同查看收支情况的项");
            }
        }

        private void CreateBudget()
        {
            frmBudgetEdit form = new frmBudgetEdit();
            form.WorkModel = EditFormWorkModels.New;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.RefreshData();
            }
        }

        private void ModifyBudget()
        {
            if (this.gvBudget.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("请选择需要修改的项");
                return;
            }
            Budget budget = this.gvBudget.GetRow(this.gvBudget.FocusedRowHandle) as Budget;
            if (budget == null)
            {
                XtraMessageBox.Show("请选择需要修改的项");
                return;
            }
            budget = bm.GetBudget(budget.ID);
            if (budget == null)
            {
                XtraMessageBox.Show("选择修改的项已经不存在。");
                return;
            }
            string message = string.Empty;
            if (budget.EnumFlowState == EnumDataFlowState.审批中
                || (EnumFlowNames.预算单审批流程.ToString().Equals(budget.FlowName) && budget.EnumFlowState == EnumDataFlowState.审批通过))
            {
                message = string.Format("{0}的预算单不能修改。", budget.EnumFlowState.ToString());
            }
            else if (EnumFlowNames.预算单修改流程.ToString().Equals(budget.FlowName) && budget.EnumFlowState != EnumDataFlowState.审批通过)
            {
                message = string.Format("{0}未审批通过不能修改。", EnumFlowNames.预算单修改流程.ToString());
            }
            if (!RunInfo.Instance.CurrentUser.UserName.Equals(budget.Salesman))
            {
                message = string.Format("当前为{0}的预算单，{1}不能修改。", RunInfo.Instance.CurrentUser.RealName, budget.SalesmanName);
            }
            if (!string.IsNullOrEmpty(message))
            {
                XtraMessageBox.Show(message, "提示");
                this.ViewBudget();
                return;
            }
            frmBudgetEdit form = new frmBudgetEdit();
            form.WorkModel = EditFormWorkModels.Modify;
            form.CurrentBudget = budget;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.RefreshData();
            }
        }

        private void ModifyBudgetSlipper()
        {
            if (this.gvBudget.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("请选择需要修改的项。");
                return;
            }
            Budget budget = this.gvBudget.GetRow(this.gvBudget.FocusedRowHandle) as Budget;
            if (budget == null)
            {
                XtraMessageBox.Show("请选择需要修改的项。");
                return;
            }
            budget = bm.GetBudget(budget.ID);
            if (budget == null)
            {
                XtraMessageBox.Show("请选择修改的项已经不存在。");
                return;
            }
            string message = string.Empty;
            if (!RunInfo.Instance.CurrentUser.UserName.Equals(budget.Salesman))
            {
                message = string.Format("当前为{0}的预算单，{1}不能修改。", RunInfo.Instance.CurrentUser.RealName, budget.SalesmanName);
            }
            if (!string.IsNullOrEmpty(message))
            {
                XtraMessageBox.Show(message, "提示");
                this.ViewBudget();
                return;
            }
            frmBudgetEdit form = new frmBudgetEdit();
            form.WorkModel = EditFormWorkModels.Custom;
            form.CurrentBudget = budget;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.RefreshData();
            }
        }

        private void SubmitApply()
        {
            if (this.gvBudget.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("请选择需要提交流程的项");
                return;
            }
            Budget budget = this.gvBudget.GetRow(this.gvBudget.FocusedRowHandle) as Budget;
            if (budget != null)
            {
                if (budget.EnumFlowState == EnumDataFlowState.审批中)
                {
                    XtraMessageBox.Show(string.Format("{0}的预算单正在审批，不允许重复提交。", budget.ContractNO));
                    return;
                }
                string message = bm.StartFlow(budget.ID, EnumFlowNames.预算单审批流程, RunInfo.Instance.CurrentUser.UserName, RunInfo.Instance.CurrentUser.RealName, string.Format("发起{0}", EnumFlowNames.预算单审批流程));
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
            if (this.gvBudget.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("请选择需要申请修改的项");
                return;
            }
            Budget budget = this.gvBudget.GetRow(this.gvBudget.FocusedRowHandle) as Budget;
            if (budget != null)
            {
                budget = bm.GetBudget(budget.ID);
                if (budget != null)
                {
                    if (budget.EnumFlowState == EnumDataFlowState.审批中)
                    {
                        XtraMessageBox.Show(string.Format("{0}的预算单正在审批，不允许重复提交。", budget.ContractNO));
                        return;
                    }
                    if (budget.EnumFlowState == EnumDataFlowState.未审批)
                    {
                        XtraMessageBox.Show(string.Format("{0}的预算单未审批，不需要提交申请修改。", budget.ContractNO));
                        return;
                    }
                    frmDescription frmBudget = new frmDescription();
                    if (frmBudget.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        string message = bm.StartFlow(budget.ID, EnumFlowNames.预算单修改流程, RunInfo.Instance.CurrentUser.UserName, RunInfo.Instance.CurrentUser.RealName, string.Format("发起{0}，{1}", EnumFlowNames.预算单修改流程, frmBudget.Description));
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
                    XtraMessageBox.Show("您选择的项已经不存在。");
                }
            }
            else
            {
                XtraMessageBox.Show("请选择需要申请修改的项");
            }
        }

        private void DeleteApply()
        {
            if (this.gvBudget.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("请选择需要申请删除的项");
                return;
            }
            Budget budget = this.gvBudget.GetRow(this.gvBudget.FocusedRowHandle) as Budget;
            if (budget != null)
            {
                if (budget.EnumFlowState == EnumDataFlowState.审批中)
                {
                    XtraMessageBox.Show(string.Format("{0}的预算单正在审批，不允许重复提交。", budget.ContractNO));
                    return;
                }
                else if (budget.State == (int)EnumBudgetState.已结束)
                {
                    XtraMessageBox.Show(string.Format("{0}的预算单{1}，不允许删除。", budget.ContractNO, (EnumBudgetState)budget.State));
                    return;
                }
                frmDescription frmBudget = new frmDescription("填写申请删除说明", "删除说明");
                if (frmBudget.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    string message = bm.StartFlow(budget.ID, EnumFlowNames.预算单删除流程, RunInfo.Instance.CurrentUser.UserName, RunInfo.Instance.CurrentUser.RealName, string.Format("发起{0}，{1}", EnumFlowNames.预算单删除流程, frmBudget.Description));
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

        private void ViewBudget()
        {
            if (this.gvBudget.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("请选择需要查看详情的项");
                return;
            }
            Budget budget = this.gvBudget.GetRow(this.gvBudget.FocusedRowHandle) as Budget;
            if (budget == null)
            {
                XtraMessageBox.Show("请选择需要查看详情的项");
                return;
            }
            budget = bm.GetBudget(budget.ID);
            if (budget == null)
            {
                XtraMessageBox.Show("您选择查看详情的项不存在，请刷新数据。");
                return;
            }
            frmBudgetDatail form = new frmBudgetDatail();
            form.WorkModel = EditFormWorkModels.View;
            form.CurrentBudget = budget;
            form.ShowDialog(this);
        }

        private void ViewApplyHistory()
        {
            if (this.gvBudget.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("请选择需要查看审批状态的项");
                return;
            }
            Budget budget = this.gvBudget.GetRow(this.gvBudget.FocusedRowHandle) as Budget;
            if (budget != null)
            {
                frmHistory hisotryForm = new frmHistory();
                hisotryForm.Points = fm.GetFlowRunPointsByData(budget.ID, EnumFlowDataType.预算单.ToString());
                hisotryForm.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("请选择需要查看审批状态的项");
            }
        }

        private void FinalAccount()
        {
            if (this.gvBudget.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("请选择需要查看单一合同决算报表的项");
                return;
            }
            Budget budget = this.gvBudget.GetRow(this.gvBudget.FocusedRowHandle) as Budget;
            if (budget != null)
            {
                frmSingleBudgetFinalAccountsReport finalAccountReportForm = new frmSingleBudgetFinalAccountsReport();
                finalAccountReportForm.CurrentBudget = budget;
                finalAccountReportForm.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("请选择需要查看单一合同决算报表的项");
            }
        }

        private void DeleteBudget()
        {
            if (this.gvBudget.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("请选择需要删除的项");
                return;
            }
            Budget budget = this.gvBudget.GetRow(this.gvBudget.FocusedRowHandle) as Budget;
            if (budget != null)
            {
                if (XtraMessageBox.Show(string.Format("是否真的要删除【{0}】合同？删除后将无法恢复。", budget.ContractNO), "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    string message = this.bm.DeleteBudget(budget.ID);
                    if (!string.IsNullOrEmpty(message))
                    {
                        XtraMessageBox.Show(message, "提示");
                    }
                    else
                    {
                        this.RefreshData();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("请选择需要删除的项");
            }
        }

        private void ExportDataBudget()
        {
            if (saveFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            if (saveFileDialog1.FileName.ToLower().EndsWith(".xls"))
            {
                this.gvBudget.Export(DevExpress.XtraPrinting.ExportTarget.Xls, saveFileDialog1.FileName);
            }
            else
            {
                this.gvBudget.Export(DevExpress.XtraPrinting.ExportTarget.Xlsx, saveFileDialog1.FileName);
            }
        }

        protected override void InitGridViewAction()
        {
            this.gridViewAction.Add(this.gvBudget, new ActionWithPermission() { MainAction = ModifyBudget, MainOperate = OperateTypes.Modify, SecondAction = ModifyBudgetSlipper, SecondOperate = OperateTypes.ModifyEx });

        }

        protected override void PrintItem()
        {
            if (this.gvBudget.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("请选择需要打印的项");
                return;
            }
            Budget budget = this.gvBudget.GetRow(this.gvBudget.FocusedRowHandle) as Budget;
            if (budget != null)
            {
                frmBudgetEdit form = new frmBudgetEdit();
                form.WorkModel = EditFormWorkModels.Print;
                form.CurrentBudget = budget;
                form.PrintItem();
            }
            else
            {
                XtraMessageBox.Show("请选择需要打印的项");
            }
        }


        /// <summary>
        /// 驳回申请
        /// </summary>
        private void RejectedAccount()
        {
            if (this.gvBudget.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("请选择需要驳回结账申请的项");
                return;
            }
            Budget budget = this.gvBudget.GetRow(this.gvBudget.FocusedRowHandle) as Budget;
            if (budget != null)
            {
                if (budget.EnumState != EnumBudgetState.财务归档征求)
                {
                    XtraMessageBox.Show(string.Format("{0}状态的预算单不允许驳回归档征求。", budget.StringState));
                    return;
                }
                string message = bm.ModifyBudgetState(budget.ID, EnumBudgetState.驳回归档征求);
                if (string.IsNullOrEmpty(message))
                {
                    XtraMessageBox.Show("驳回归档征求成功。");
                    LoadData();
                }
                else
                {
                    XtraMessageBox.Show(message);
                }
            }
            else
            {
                XtraMessageBox.Show("请选择需要驳回结账申请的项");
            }
        }

        /// <summary>
        /// 财务归档征求
        /// </summary>
        private void FinancialArchiveApply()
        {
            frmFinancialArchiveApplyImport frm = new frmFinancialArchiveApplyImport();

            if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                List<Budget> budgetList = gvBudget.DataSource as List<Budget>;
                if (budgetList != null)
                {
                    foreach (var budget in frm.BudgetList)
                    {
                        var findItem = budgetList.Find(o => o.ID.Equals(budget.ID));
                        if (findItem != null)
                        {
                            findItem.State = (int)EnumBudgetState.财务归档征求;
                            findItem.ArchiveApplyDate = datetimeNow;
                        }
                    }
                    this.gvBudget.RefreshData();
                }
            }


            //if (this.gvBudget.FocusedRowHandle < 0)
            //{
            //    XtraMessageBox.Show("请选择需要财务归档征求的项");
            //    return;
            //}
            //Budget budget = this.gvBudget.GetRow(this.gvBudget.FocusedRowHandle) as Budget; ;
            //if (budget != null)
            //{
            //    if (budget.EnumState != EnumBudgetState.进行中)
            //    {
            //        XtraMessageBox.Show(string.Format("{0}状态的预算单不允许财务归档征求。", budget.StringState));
            //        return;
            //    }
            //    string message = bm.ModifyBudgetState(budget.ID, EnumBudgetState.财务归档征求);
            //    if (string.IsNullOrEmpty(message))
            //    {
            //        XtraMessageBox.Show("财务归档征求成功。");
            //        LoadData();
            //    }
            //    else
            //    {
            //        XtraMessageBox.Show(message);
            //    }
            //}
            //else
            //{
            //    XtraMessageBox.Show("请选择需要财务归档征求的项");
            //}
        }

        /// <summary>
        /// 归档
        /// </summary>
        private void Archive()
        {
            if (this.gvBudget.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("请选择需要归档的项");
                return;
            }
            Budget budget = this.gvBudget.GetRow(this.gvBudget.FocusedRowHandle) as Budget;
            if (budget != null)
            {
                budget = bm.GetBudget(budget.ID);
                if (budget == null)
                {
                    XtraMessageBox.Show("您选择的项已经不存在");
                    return;
                }
                if (budget.EnumState != EnumBudgetState.财务归档征求)
                {
                    XtraMessageBox.Show(string.Format("{0}状态的预算单不允许归档。", budget.StringState));
                    return;
                }
                string message = bm.ModifyBudgetState(budget.ID, EnumBudgetState.已结束);
                if (string.IsNullOrEmpty(message))
                {
                    XtraMessageBox.Show("归档成功。");
                    LoadData();
                }
                else
                {
                    XtraMessageBox.Show(message);
                }
            }
            else
            {
                XtraMessageBox.Show("请选择需要归档的项");
            }
        }

        private void AddPaymentNote()
        {
            if (this.gvBudget.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("请选择合同");
                return;
            }
            Budget budget = this.gvBudget.GetRow(this.gvBudget.FocusedRowHandle) as Budget;
            if (budget == null)
            {
                XtraMessageBox.Show("请选择合同");
                return;
            }

            XtraMessageBox.Show("TODO:财务调账");
            //BudgetSystem.OutMoney.frmOutMoneyEdit form = new BudgetSystem.OutMoney.frmOutMoneyEdit();
            //form.WorkModel = EditFormWorkModels.New;
            //form.SelectedBudget(budget.ID);
            //form.ShowDialog(this);
        }

    }
}