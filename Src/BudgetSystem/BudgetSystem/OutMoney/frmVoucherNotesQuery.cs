using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;
using BudgetSystem.Bll;
using BudgetSystem.InMoney;

namespace BudgetSystem
{
    public partial class frmVoucherNotesQuery : frmBaseQueryForm
    {
        DeclarationformManager dm = new DeclarationformManager();

        public frmVoucherNotesQuery()
        {
            InitializeComponent();
            this.Module = BusinessModules.VoucherNotesManagement;
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New, "新增报关单"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ImportData, "导入报关单"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Delete, "删除报关单"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View, "查看报关单"));

            this.ModelOperatePageName = "报关单管理";
        }

        public override void RefreshData()
        {
            this.gcDeclarationform.DataSource = dm.GetAllDeclarationform();
            this.gcDeclarationform.RefreshDataSource();
        }

        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {

            if (operate.Operate == OperateTypes.ImportData.ToString())
            {
                frmDeclarationformImport form = new frmDeclarationformImport();

                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.RefreshData();
                }

            }
            else if (operate.Operate == OperateTypes.New.ToString())
            {
                NewDeclaration();
            }
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                ModifyDeclaration();
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                ViewDeclarationform();
            }
            else if (operate.Operate == OperateTypes.Delete.ToString())
            {
                DeleteDeclarationform();
            }
            else
            {
                XtraMessageBox.Show("未定义的操作1");
            }
        }

        private void NewDeclaration()
        {
            frmDeclarationformEdit form = new frmDeclarationformEdit();
            form.WorkModel = EditFormWorkModels.New;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.RefreshData();
            }
        }

        private void ModifyDeclaration()
        {
            Declarationform selectedItem = this.gvDeclarationform.GetRow(this.gvDeclarationform.FocusedRowHandle) as Declarationform;
            if (selectedItem == null)
            {
                XtraMessageBox.Show("请选择需要修改的项");
                return;
            }

            frmDeclarationformEdit form = new frmDeclarationformEdit();
            form.WorkModel = EditFormWorkModels.Modify;
            form.CurrentDeclarationform = selectedItem;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.RefreshData();
            }
        }

        private void ViewDeclarationform()
        {
            Declarationform selectedItem = this.gvDeclarationform.GetRow(this.gvDeclarationform.FocusedRowHandle) as Declarationform;
            if (selectedItem == null)
            {
                XtraMessageBox.Show("请选择需要查看详情的项");
                return;
            }
            frmDeclarationformEdit form = new frmDeclarationformEdit();
            form.WorkModel = EditFormWorkModels.View;
            form.CurrentDeclarationform = selectedItem;
            form.ShowDialog(this);
        }

        private void DeleteDeclarationform()
        {
            Declarationform selectedItem = this.gvDeclarationform.GetRow(this.gvDeclarationform.FocusedRowHandle) as Declarationform;
            if (selectedItem == null)
            {
                XtraMessageBox.Show("请选择需要删除的项");
                return;
            }
            if (XtraMessageBox.Show("确认删除吗？", "删除提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                dm.DeleteDeclarationformById(selectedItem.ID);
                XtraMessageBox.Show("删除成功。");
                this.gvDeclarationform.DeleteRow(this.gvDeclarationform.FocusedRowHandle);
            }

        }

        protected override void InitGridViewAction()
        {
            this.gridViewAction.Add(this.gvDeclarationform, new ActionWithPermission() { MainAction = ModifyDeclaration, MainOperate = OperateTypes.Modify, SecondAction = ViewDeclarationform, SecondOperate = OperateTypes.View });

        }

    }
}
