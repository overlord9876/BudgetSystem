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
            CommonControl.LookUpEditHelper.FillRepositoryItemLookUpEditByEnum_IntValue(this.rilueSupplierType, typeof(EnumSupplierType));
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Enabled));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Disabled));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.SubmitApply, "提交审批"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));

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
                if (supplier.EnumFlowState == EnumDataFlowState.审批中)
                {
                    XtraMessageBox.Show(string.Format("{0}的供方{1}，不允许重复提交。", supplier.Name, supplier.EnumFlowState.ToString()));
                    return;
                }
                string message = sm.StartFlow(supplier.ID, RunInfo.Instance.CurrentUser.UserName);
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


        protected override void InitGridViewAction()
        {
            this.gridViewAction.Add(this.gvSupplier, new ActionWithPermission() { MainAction = ModifySupplier, MainOperate = OperateTypes.Modify, SecondAction = ViewSupplier, SecondOperate = OperateTypes.View });

        }
    }
}
