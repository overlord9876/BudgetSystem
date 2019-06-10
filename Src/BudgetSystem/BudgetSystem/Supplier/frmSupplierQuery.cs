using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BudgetSystem.Entity.QueryCondition;

namespace BudgetSystem
{
    public partial class frmSupplierQuery : frmBaseQueryForm
    {
        private Bll.SupplierManager sm = new Bll.SupplierManager();
        private const string COMMONQUERY_MYCREATE = "我创建的";
        public frmSupplierQuery()
        {
            InitializeComponent();
            this.Module = BusinessModules.SupplierManagement;
            CommonControl.LookUpEditHelper.FillRepositoryItemLookUpEditByEnum_IntValue(this.rilueSupplierType, typeof(EnumSupplierType));
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(frmSupplierQuery_KeyDown);
        }



        protected override void InitModelOperate()
        {
            base.InitModelOperate();
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Enabled));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Disabled));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.SubmitApply, "提交审批"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Approve, "提交复评审批"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ViewApply, "查看复评历史记录"));

            this.RegeditQueryOperate<SupplierQueryCondition>(true, new List<string> { COMMONQUERY_MYCREATE }, "供应商查询");

            this.ModelOperatePageName = "供应商管理";
        }


        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {
            base.OperateHandled(operate, e);

            if (operate.Operate == OperateTypes.New.ToString())
            {
                CreateSupplier();
            }
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                ModifySupplier();
            }
            else if (operate.Operate == OperateTypes.SubmitApply.ToString())
            {
                CommitSupplier();
            }
            else if (operate.Operate == OperateTypes.Approve.ToString())
            {
                ReviewSupplier();
            }
            else if (operate.Operate == OperateTypes.Enabled.ToString())
            {
                XtraMessageBox.Show("启用供应商，如果是合格供商则发启合格供商发启流程。");
            }
            else if (operate.Operate == OperateTypes.Disabled.ToString())
            {
                XtraMessageBox.Show("停用供应商");
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                ViewSupplier();
            }
            else if (operate.Operate == OperateTypes.ViewApply.ToString())
            {
                ViewApply();
            }
        }

        protected override void DoCommonQuery(string queryName)
        {
            if (COMMONQUERY_MYCREATE.Equals(queryName))
            {
                SupplierQueryCondition condition = new SupplierQueryCondition() { CreateUser = RunInfo.Instance.CurrentUser.UserName };
                LoadData(condition);
            }
        }

        protected override void DoConditionQuery(BaseQueryCondition condition)
        {
            this.LoadData((SupplierQueryCondition)condition);
        }

        protected override QueryConditionEditorForm CreateConditionEditorForm()
        {
            frmSupplierQueryConditionEditor form = new frmSupplierQueryConditionEditor();
            form.QueryName = this.GetType().ToString();
            return form;
        }
        public override void LoadData()
        {
            LoadData(null);
        }

        private void LoadData(SupplierQueryCondition condition)
        {
            if (condition == null)
            {
                condition = new SupplierQueryCondition();
            }

            if (RunInfo.Instance.CurrentUser.Role == StringUtil.SaleRoleCode)
            {
                condition.DeptID = RunInfo.Instance.CurrentUser.DeptID;
            }

            var list = sm.GetAllSupplier(condition);
            this.gridSupplier.DataSource = list;
        }

        private void CreateSupplier()
        {
            frmSupplierEdit form = new frmSupplierEdit();
            form.WorkModel = EditFormWorkModels.New;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.RefreshData();
            }
        }
        private void ModifySupplier()
        {
            Supplier supplier = this.gvSupplier.GetFocusedRow() as Supplier;
            if (supplier != null)
            {
                frmSupplierEdit form = new frmSupplierEdit();
                form.WorkModel = EditFormWorkModels.Modify;
                form.CurrentSupplier = supplier;
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

        private void CommitSupplier()
        {
            Supplier supplier = this.gvSupplier.GetFocusedRow() as Supplier;
            if (supplier != null)
            {
                if (supplier.EnumFlowState != EnumDataFlowState.未审批&&supplier.EnumFlowState!= EnumDataFlowState.审批不通过)
                {
                    XtraMessageBox.Show(string.Format("{0}的供方{1}，不允许提交审批。", supplier.Name, supplier.EnumFlowState.ToString()));
                    return;
                }
                if (supplier.FlowName == EnumFlowNames.供应商复审流程.ToString())
                {
                    XtraMessageBox.Show(string.Format("{0}供方不允许提交审批。", supplier.Name));
                    return;
                }
                
                string message = sm.StartFlow(EnumFlowNames.供应商审批流程, supplier.ID, RunInfo.Instance.CurrentUser.UserName);
                if (string.IsNullOrEmpty(message))
                {
                    XtraMessageBox.Show("提交流程成功。");
                    RefreshData();
                }
                else
                {
                    XtraMessageBox.Show(message);
                }
            }
            else
            {
                XtraMessageBox.Show("请选择需要提交审批的项");
            }
        }
        private void ReviewSupplier()
        {
            Supplier supplier = this.gvSupplier.GetFocusedRow() as Supplier;
            if (supplier != null)
            {
                if ((supplier.EnumFlowState == EnumDataFlowState.审批中 || supplier.EnumFlowState == EnumDataFlowState.未审批)
                    || (EnumFlowNames.供应商审批流程.ToString() == supplier.FlowName && supplier.EnumFlowState == EnumDataFlowState.审批不通过))
                {
                    XtraMessageBox.Show(string.Format("{0}的供方{1}，不允许复评审批申请。", supplier.Name, supplier.EnumFlowState.ToString()));
                    return;
                }
                if ((supplier.ReviewDate != null && supplier.ReviewDate.Value.AddDays(-30).Date <= DateTime.Now.Date)
                    || (supplier.AgreementDate != null && supplier.AgreementDate.Value.AddDays(-30).Date <= DateTime.Now.Date)
                    || (supplier.BusinessEffectiveDate != null && supplier.BusinessEffectiveDate.Value.AddDays(-30).Date <= DateTime.Now.Date))
                {
                    frmSupplierEdit form = new frmSupplierEdit();
                    form.WorkModel = EditFormWorkModels.Custom;
                    form.CurrentSupplier = supplier;
                    if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        this.RefreshData();
                    }
                }
                else
                {
                    XtraMessageBox.Show(string.Format("{0}的供方，不满足复评时间要求，不允许复评审批申请。", supplier.Name));
                    return;
                }
            }
            else
            {
                XtraMessageBox.Show("请选择需要复评审批申请的项");
            }
        }
        private void ViewSupplier()
        {
            Supplier currentRowSupplier = this.gvSupplier.GetFocusedRow() as Supplier;
            if (currentRowSupplier != null)
            {
                frmSupplierEdit form = new frmSupplierEdit();
                form.WorkModel = EditFormWorkModels.View;
                form.CurrentSupplier = currentRowSupplier;
                form.ShowDialog(this);
            }
            else
            {
                XtraMessageBox.Show("请选择需要查看详情的项");
            }
        }

        private void ViewApply()
        {
            Supplier currentRowSupplier = this.gvSupplier.GetFocusedRow() as Supplier;
            if (currentRowSupplier != null)
            {
                if (string.IsNullOrEmpty(currentRowSupplier.FlowName)
                    || currentRowSupplier.FlowName == EnumFlowNames.供应商审批流程.ToString())
                {
                    XtraMessageBox.Show("当前选择供应商不存在复评历史记录");
                }
                else
                {
                    frmSupplierReviewHistory form = new frmSupplierReviewHistory(currentRowSupplier.ID);
                    form.WorkModel = EditFormWorkModels.View; 
                    form.ShowDialog(this);
                }
            }
            else
            {
                XtraMessageBox.Show("请选择需要查看复评历史记录的项");
            }
            
        }

        protected override void InitGridViewAction()
        {
            this.gridViewAction.Add(this.gvSupplier, new ActionWithPermission() { MainAction = ModifySupplier, MainOperate = OperateTypes.Modify, SecondAction = ViewSupplier, SecondOperate = OperateTypes.View });

        }

        void frmSupplierQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.I && e.Control)
            {
                frmSupplierImport frm = new frmSupplierImport();
                frm.ShowDialog();
            }
        }
    }
}
