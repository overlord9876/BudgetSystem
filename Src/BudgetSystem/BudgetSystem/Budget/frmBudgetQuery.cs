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

namespace BudgetSystem
{
    public partial class frmBudgetQuery : frmBaseQueryFormWithCondtion
    {
        private Bll.BudgetManager bm = new Bll.BudgetManager();
        private GridHitInfo hInfo;

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
            //this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View, "查看审批状态"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.BudgetAccountBill));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Print));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View, "自定义查询"));


            this.ModelOperatePageName = "预算单";

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View, "通用查询", UITypes.LargeMenu, new List<string>() { "通用查询1", "通用查询2", "通用查询3" }));
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
            else if (operate.Operate == OperateTypes.Confirm.ToString())
            {
                CommitBudget();
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                if (e.SenderText == "查询")
                {
                    ViewBudget();
                }
                else
                {
                    XtraMessageBox.Show(e.SenderText);
                    this.RefreshData();
                }
            }
            else if (operate.Operate == OperateTypes.Delete.ToString())
            {
                DeleteBudget();
            }
            else if (operate.Operate == OperateTypes.Revoke.ToString())
            {
                RevokeBudget();
            }
            else if (operate.Operate == OperateTypes.Close.ToString())
            {
                CloseBudget();
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

        private void CommitBudget()
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

        private void RevokeBudget()
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

        private void CloseBudget()
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

        private void gvBudget_DoubleClick(object sender, EventArgs e)
        {
            if (hInfo.InRow)
            {
                ModifyBudget();
            }
        }

        private void gvBudget_MouseDown(object sender, MouseEventArgs e)
        {
            hInfo = gvBudget.CalcHitInfo(e.Y, e.Y);
        }


    }
}