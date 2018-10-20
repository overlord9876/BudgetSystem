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
        private GridHitInfo hInfo;

        public frmSupplierQuery()
        {
            InitializeComponent();
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Enabled));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Disabled));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));
            this.ModelOperatePageName = "供应商管理";
        }


        public override void OperateHandled(ModelOperate operate)
        {

            if (operate.Operate == OperateTypes.New.ToString())
            {
                CreateSupplier();
            }
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                ModifySupplier();
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
                form.Supplier = supplier;
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.RefreshData();
                }
            }
        }
        private void ViewSupplier()
        {
            Supplier currentRowSupplier = this.gvSupplier.GetFocusedRow() as Supplier;
            {
                frmSupplierEdit form = new frmSupplierEdit();
                form.WorkModel = EditFormWorkModels.View;
                form.Supplier = currentRowSupplier;
                form.ShowDialog(this);
            }
        }

        public override void LoadData()
        {
            var list = sm.GetAllSupplier();
            this.gridSupplier.DataSource = list;
        }
        private void gvSupplier_DoubleClick(object sender, EventArgs e)
        {
            if (hInfo.InRow)
            {
                ModifySupplier();
            }
        }

        private void gvSupplier_MouseDown(object sender, MouseEventArgs e)
        {
            hInfo = gvSupplier.CalcHitInfo(e.Y, e.Y);
        }
    }
}
