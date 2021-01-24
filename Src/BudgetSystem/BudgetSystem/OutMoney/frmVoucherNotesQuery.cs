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
using BudgetSystem.Entity.QueryCondition;

namespace BudgetSystem
{
    public partial class frmVoucherNotesQuery : frmBaseQueryForm
    {
        DeclarationformManager dm = new DeclarationformManager();
        CommonManager cm = new CommonManager();

        const string COMMONQUERY_ALL = "所有报关单";
        const string THE_SAME_DAY = "当天报关单";
        const string THE_SAME_MONTH = "当月报关单";
        const string THE_SAME_YEAR = "当年审报关单";

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

            this.RegeditQueryOperate<VoucherNotesQueryCondition>(true, new List<string> { COMMONQUERY_ALL, THE_SAME_DAY, THE_SAME_MONTH, THE_SAME_YEAR }, "报关单查询");

            this.RegeditPrintOperate();

            this.ModelOperatePageName = "报关单管理";
        }

        public override void RefreshData()
        {
            LoadData();
        }

        public override void LoadData()
        {
            DoCommonQuery(THE_SAME_MONTH);
        }

        public void LoadData(VoucherNotesQueryCondition condition)
        {
            this.gcDeclarationform.DataSource = dm.GetAllDeclarationform(condition);
            this.gcDeclarationform.RefreshDataSource();
            this.gvDeclarationform.BestFitColumns();
        }

        protected override void DoCommonQuery(string queryName)
        {
            VoucherNotesQueryCondition condition = new VoucherNotesQueryCondition();

            if (THE_SAME_DAY.Equals(queryName))
            {
                DateTime datetimeNow = cm.GetDateTimeNow();
                condition.ExportBeginDate = new DateTime(datetimeNow.Year, datetimeNow.Month, datetimeNow.Day, 0, 0, 0);
                condition.ExportEndDate = condition.ExportBeginDate.AddDays(1).AddSeconds(-1);
            }
            else if (THE_SAME_MONTH.Equals(queryName))
            {
                DateTime datetimeNow = cm.GetDateTimeNow();
                condition.ExportBeginDate = new DateTime(datetimeNow.Year, datetimeNow.Month, 1, 0, 0, 0);
                condition.ExportEndDate = condition.ExportBeginDate.AddMonths(1).AddSeconds(-1);
            }
            else if (THE_SAME_YEAR.Equals(queryName))
            {
                DateTime datetimeNow = cm.GetDateTimeNow();
                condition.ExportBeginDate = new DateTime(datetimeNow.Year, 1, 1, 0, 0, 0);
                condition.ExportEndDate = condition.ExportBeginDate.AddYears(1).AddSeconds(-1);
            }

            LoadData(condition);
        }

        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {
            base.OperateHandled(operate, e);

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

            }
        }

        protected override void DoConditionQuery(BaseQueryCondition condition)
        {
            VoucherNotesQueryCondition vnCondition = condition as VoucherNotesQueryCondition;

            LoadData(vnCondition);
        }

        protected override QueryConditionEditorForm CreateConditionEditorForm()
        {
            frmVoucherNotesQueryConditionEditor form = new frmVoucherNotesQueryConditionEditor();
            form.QueryName = this.GetType().ToString();
            return form;
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
