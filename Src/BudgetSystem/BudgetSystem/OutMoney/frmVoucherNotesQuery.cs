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
using DevExpress.XtraBars;

namespace BudgetSystem
{
    public partial class frmVoucherNotesQuery : frmBaseQueryForm
    {
        private DeclarationformManager dm = new DeclarationformManager();
        private CommonManager cm = new CommonManager();
        private BudgetManager bm = new BudgetManager();
        private DateTime datetimeNow = DateTime.MinValue;

        const string COMMONQUERY_ALL = "所有报关单";
        const string THE_SAME_DAY = "当天报关单";
        const string THE_SAME_MONTH = "当月报关单";
        const string THE_SAME_YEAR = "当年审报关单";

        public frmVoucherNotesQuery()
        {
            InitializeComponent();
            this.Module = BusinessModules.VoucherNotesManagement;

            datetimeNow = cm.GetDateTimeNow();
            int year = datetimeNow.Year - 2;
            for (int index = 0; index < 52; index++)
            {
                cboYears.Items.Add((year + index));
            }
            this.cboSelectYear.EditValue = datetimeNow.Year;

            this.deStartDate.EditValue = new DateTime(datetimeNow.Year, datetimeNow.Month, 1);
            DateTime nextMonth = new DateTime(datetimeNow.Year, datetimeNow.Month, 1);
            this.deEndDate.EditValue = new DateTime(datetimeNow.Year, datetimeNow.Month, nextMonth.AddMonths(1).AddDays(-1).Day);

            BudgetQueryCondition condition = new BudgetQueryCondition();
            condition = RunInfo.Instance.GetConditionByCurrentUser(condition) as BudgetQueryCondition;
            List<Budget> budgetList = bm.GetAllBudget(condition);
            this.repositoryItemGridLookUpEdit1.DataSource = budgetList;

            RegisterEventHandler();
        }

        private void RegisterEventHandler()
        {
            this.btnJanuary.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJanuary_ItemClick);
            this.btnFebruary.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFebruary_ItemClick);
            this.btnMarch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMarch_ItemClick);
            this.btnApril.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnApril_ItemClick);
            this.btnMay.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMay_ItemClick);
            this.btnJune.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJune_ItemClick);
            this.btnJuly.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJuly_ItemClick);
            this.btnAugust.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAugust_ItemClick);
            this.btnSeptember.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSeptember_ItemClick);
            this.btnOctober.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOctober_ItemClick);
            this.btnNovember.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNovember_ItemClick);
            this.btnDecember.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDecember_ItemClick);
            this.btnSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSearch_ItemClick);
            this.btn_Print.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Print_ItemClick);
            this.btnExportExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportExcel_ItemClick);
            this.cboSelectYear.EditValueChanged += cboSelectYear_EditValueChanged;
        }


        protected override void InitModelOperate()
        {
            base.InitModelOperate();

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New, "新增报关单"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify, "修改报关单"));
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
            DoCommonQuery("");
        }

        public void LoadData(VoucherNotesQueryCondition condition)
        {
            if (condition == null)
            {
                condition = new VoucherNotesQueryCondition();
            }
            condition = RunInfo.Instance.GetConditionByCurrentUser(condition) as VoucherNotesQueryCondition;
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
            else
            {
                DateTime startTime = (DateTime)deStartDate.EditValue;
                startTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 0, 0, 0);
                DateTime endTime = (DateTime)deEndDate.EditValue;
                endTime = new DateTime(endTime.Year, endTime.Month, endTime.Day, 0, 0, 0).AddDays(1).AddSeconds(-1);
                condition.ExportBeginDate = startTime;
                condition.ExportEndDate = endTime;
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
            var selectedRows = this.gvDeclarationform.GetSelectedRows();

            if (selectedRows.Length <= 0)
            {
                XtraMessageBox.Show("请选择需要删除的项");
                return;
            }
            if (XtraMessageBox.Show("确认删除吗？", "删除提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Declarationform selectedItem = null;
                foreach (var rowIndex in selectedRows)
                {
                    selectedItem = this.gvDeclarationform.GetRow(rowIndex) as Declarationform;
                    if (selectedItem != null)
                        dm.DeleteDeclarationformById(selectedItem.ID);
                }
                this.gvDeclarationform.DeleteSelectedRows();
                this.gvDeclarationform.SelectRow(0);
                XtraMessageBox.Show("删除成功。");
            }

        }

        protected override void InitGridViewAction()
        {
            this.gridViewAction.Add(this.gvDeclarationform, new ActionWithPermission() { MainAction = ModifyDeclaration, MainOperate = OperateTypes.Modify, SecondAction = ViewDeclarationform, SecondOperate = OperateTypes.View });

        }

        #region Search

        private void btnJanuary_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChangedMonth(1);
        }

        private void btnFebruary_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChangedMonth(2);
        }

        private void btnMarch_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChangedMonth(3);
        }

        private void btnApril_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChangedMonth(4);
        }

        private void btnMay_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChangedMonth(5);
        }

        private void btnJune_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChangedMonth(6);
        }

        private void btnJuly_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChangedMonth(7);
        }

        private void btnAugust_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChangedMonth(8);
        }

        private void btnSeptember_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChangedMonth(9);
        }

        private void btnOctober_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChangedMonth(10);
        }

        private void btnNovember_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChangedMonth(11);
        }

        private void btnDecember_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChangedMonth(12);
        }

        private void cboSelectYear_EditValueChanged(object sender, EventArgs e)
        {
            int year = (int)cboSelectYear.EditValue;
            deStartDate.EditValue = new DateTime(year, 1, 1, 0, 0, 0);
            deEndDate.EditValue = new DateTime(year, 1, 1, 0, 0, 0).AddYears(1).AddMinutes(-1);
            LoadData();
        }

        private void barSelectedMode_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ChangedMonth(int month)
        {
            int year = (int)cboSelectYear.EditValue;
            DateTime beginDate = new DateTime(year, month, 1, 0, 0, 0);
            deStartDate.EditValue = beginDate;
            deEndDate.EditValue = beginDate.AddMonths(1).AddMinutes(-1);
            LoadData();
        }

        private void btnSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData();
        }

        private void btn_Print_ItemClick(object sender, ItemClickEventArgs e)
        {
            PrinterHelper.PrintControl(true, this.gcDeclarationform, Size.Empty, false, System.Drawing.Printing.PaperKind.A4);
        }

        private void btnExportExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "选择保存路径";
                dialog.Filter = "excel文件|*.xls";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.gvDeclarationform.ExportToXls(dialog.FileName);
                }
            }
        }

        #endregion

    }
}
