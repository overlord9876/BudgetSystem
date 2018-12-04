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

namespace BudgetSystem
{
    public partial class frmSupplierQuery : frmBaseQueryForm
    {
        private Bll.SupplierManager sm = new Bll.SupplierManager();

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
            this.ModelOperatePageName = "供应商管理";
        }


        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {

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
        }

        private void ViewSupplier()
        {
            Supplier currentRowSupplier = this.gvSupplier.GetFocusedRow() as Supplier;
            {
                frmSupplierEdit form = new frmSupplierEdit();
                form.WorkModel = EditFormWorkModels.View;
                form.CurrentSupplier = currentRowSupplier;
                form.ShowDialog(this);
            }
        }

        public override void LoadData()
        {
            var list = sm.GetAllSupplier();
            this.gridSupplier.DataSource = list;
        }

        protected override void InitGridViewAction()
        {
            this.gridViewAction.Add(this.gvSupplier, new ActionWithPermission() { MainAction = ModifySupplier, MainOperate = OperateTypes.Modify, SecondAction = ViewSupplier, SecondOperate = OperateTypes.View });

        }
    }
}
