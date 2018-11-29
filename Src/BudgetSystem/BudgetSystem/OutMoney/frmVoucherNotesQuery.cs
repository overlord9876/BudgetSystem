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
    public partial class frmVoucherNotesQuery : frmBaseQueryFormWithCondtion
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
                frmDeclarationformEdit form = new frmDeclarationformEdit();
                form.WorkModel = EditFormWorkModels.Modify;
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.RefreshData();
                }
            }
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                Declarationform selectedItem = this.gvDeclarationform.GetRow(this.gvDeclarationform.FocusedRowHandle) as Declarationform;
                if (selectedItem == null)
                {
                    XtraMessageBox.Show("请选择要修改的项");
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
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                frmDeclarationformEdit form = new frmDeclarationformEdit();
                form.WorkModel = EditFormWorkModels.View;
                form.ShowDialog(this);
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

        private void DeleteDeclarationform()
        {
            Declarationform selectedItem = this.gvDeclarationform.GetRow(this.gvDeclarationform.FocusedRowHandle) as Declarationform;
            if (selectedItem == null)
            {
                XtraMessageBox.Show("请选择要删除的项");
                return;
            }
            dm.DeleteDeclarationformById(selectedItem.ID);
            XtraMessageBox.Show("删除成功。");
            this.gvDeclarationform.DeleteRow(this.gvDeclarationform.FocusedRowHandle);

        }
    }
}
