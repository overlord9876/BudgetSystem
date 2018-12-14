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
        private const string COMMONQUERY_MYCREATE = "我负责的";
        public frmBudgetQuery()
        {
            InitializeComponent();
            this.Module = BusinessModules.BuggetManagement;

            LookUpEditHelper.FillRepositoryItemLookUpEditByEnum_IntValue(this.rilueTradeNature, typeof(EnumTradeNature));
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.SubmitApply, "提交流程"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ModifyApply, "申请修改"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.DeleteApply, "申请删除"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Close));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Delete, "删除"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ViewApply, "查看审批状态"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.BudgetAccountBill));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Print));

            this.RegeditQueryOperate<CustomerQueryCondition>(true, new List<string> { COMMONQUERY_MYCREATE });
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
        }
        
        protected override void DoCommonQuery(string queryName)
        {
            if (COMMONQUERY_MYCREATE.Equals(queryName))
            {
                BudgetQueryCondition condition = new BudgetQueryCondition() {  Salesman = RunInfo.Instance.CurrentUser.UserName };
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
            if (RunInfo.Instance.CurrentUser.Role == StringUtil.SaleRoleCode)
            {
                if (condition == null)
                {
                    condition = new BudgetQueryCondition();
                }
                condition.Salesman = RunInfo.Instance.CurrentUser.UserName;
            }
            List<Budget> budgetList = bm.GetAllBudget(condition);
            this.gridBudget.DataSource = budgetList;
        }
     
        private void ShowBudgetAccountBillView()
        {
            Budget budget = this.gvBudget.GetFocusedRow() as Budget;
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
            Budget budget = this.gvBudget.GetFocusedRow() as Budget;
            if (budget != null)
            {
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
            else
            {
                XtraMessageBox.Show("请选择需要修改的项");
            }
        }

        private void SubmitApply()
        {
            Budget budget = this.gvBudget.GetFocusedRow() as Budget;
            if (budget != null)
            {
                if (budget.EnumFlowState == EnumDataFlowState.审批中)
                {
                    XtraMessageBox.Show(string.Format("{0}的预算单正在审批，不允许重复提交。", budget.ContractNO));
                    return;
                }
                string message = bm.StartFlow(budget.ID, EnumFlowNames.预算单审批流程, RunInfo.Instance.CurrentUser.UserName);
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
            Budget budget = this.gvBudget.GetFocusedRow() as Budget;
            if (budget != null)
            {
                if (budget.EnumFlowState == EnumDataFlowState.审批中)
                {
                    XtraMessageBox.Show(string.Format("{0}的预算单正在审批，不允许重复提交。", budget.ContractNO));
                    return;
                }
                string message = bm.StartFlow(budget.ID, EnumFlowNames.预算单修改流程, RunInfo.Instance.CurrentUser.UserName);
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
                XtraMessageBox.Show("请选择需要申请修改的项");
            }
        }

        private void DeleteApply()
        {
            Budget budget = this.gvBudget.GetFocusedRow() as Budget;
            if (budget != null)
            {
                if (budget.EnumFlowState == EnumDataFlowState.审批中)
                {
                    XtraMessageBox.Show(string.Format("{0}的预算单正在审批，不允许重复提交。", budget.ContractNO));
                    return;
                }
                string message = bm.StartFlow(budget.ID, EnumFlowNames.预算单删除流程, RunInfo.Instance.CurrentUser.UserName);
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
                XtraMessageBox.Show("请选择需要申请删除的项");
            }
        }

        private void ViewBudget()
        {
            Budget budget = this.gvBudget.GetFocusedRow() as Budget;
            if (budget != null)
            {
                frmBudgetEdit form = new frmBudgetEdit();
                form.WorkModel = EditFormWorkModels.View;
                form.CurrentBudget = budget;
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.RefreshData();
                }
            }
            else
            {
                XtraMessageBox.Show("请选择需要查看详情的项");
            }
        }

        private void ViewApplyHistory()
        {
            Budget budget = this.gvBudget.GetFocusedRow() as Budget;
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
        private void DeleteBudget()
        {
            Budget budget = this.gvBudget.GetFocusedRow() as Budget;
            if (budget != null)
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
            else
            {
                XtraMessageBox.Show("请选择需要删除的项");
            }
        }

        protected override void InitGridViewAction()
        {
            this.gridViewAction.Add(this.gvBudget, new ActionWithPermission() { MainAction = ModifyBudget, MainOperate = OperateTypes.Modify, SecondAction = ViewBudget, SecondOperate = OperateTypes.View });

        }


    }
}