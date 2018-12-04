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

namespace BudgetSystem
{
    public partial class frmBudgetQuery : frmBaseQueryForm
    {
        private FlowManager fm = new FlowManager();
        private Bll.BudgetManager bm = new Bll.BudgetManager();
        private GridHitInfo hInfo;

        public frmBudgetQuery()
        {
            InitializeComponent();
            this.gvBudget.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(gvBudget_RowClick);
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


            this.ModelOperatePageName = "预算单";

        }

        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {

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
            else
            {
                XtraMessageBox.Show("未定义的操作");
            }
        }

        public override void LoadData()
        {
            var list = bm.GetAllBudget();
            this.gridBudget.DataSource = list;
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
        }


        private void gvBudget_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2 && e.RowHandle >= 0)
            {
                if (CheckPermission(OperateTypes.Modify))
                {
                    ModifyBudget();
                }
                else if (CheckPermission(OperateTypes.View))
                {
                    ViewBudget();
                }
            }
        }


    }
}