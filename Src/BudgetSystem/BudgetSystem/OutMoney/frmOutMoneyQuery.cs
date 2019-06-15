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
using BudgetSystem.OutMoney;
using BudgetSystem.Entity.QueryCondition;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Reflection;

namespace BudgetSystem
{
    public partial class frmOutMoneyQuery : frmBaseQueryForm
    {
        PaymentNotesManager pnm = new PaymentNotesManager();

        const string COMMONQUERY_APPLICATIONFORPAYMENT = "申请付款";
        const string COMMONQUERY_BEPAID = "已付货款";
        const string COMMONQUERY_ALL = "所有付款单";
        const string THE_SAME_DAY = "当天审批付款单";
        const string THE_SAME_MONTH = "当月审批付款单";
        const string THE_SAME_YEAR = "当年审批付款单";

        public frmOutMoneyQuery()
        {
            InitializeComponent();
            this.gvOutMoney.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(gvOutMoney_CustomDrawGroupRow);
            this.Module = BusinessModules.OutMoneyManagement;
        }

        void gvOutMoney_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo GridGroupRowInfo = e.Info as GridGroupRowInfo;
            string fullName = GridGroupRowInfo.EditValue == null ? string.Empty : GridGroupRowInfo.EditValue.ToString();
            string columnFieldName = GridGroupRowInfo.Column.FieldName;

            PropertyInfo propety = typeof(PaymentNotes).GetProperty(columnFieldName);
            if (propety == null) return;

            decimal totalCNY = 0;
            List<PaymentNotes> allPayment = gvOutMoney.DataSource as List<PaymentNotes>;
            foreach (PaymentNotes pn in allPayment)
            {
                object obj = propety.GetValue(pn, null);
                string value = obj == null ? string.Empty : obj.ToString(); //对应的值
                if (value == fullName)
                {
                    totalCNY += pn.CNY;
                }
            }

            fullName = fullName + " (合计人民币：" + totalCNY + ")";
            GridGroupRowInfo.GroupText = fullName;
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New, "付款申请"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify, "修改付款"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Delete, "删除付款"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.SubmitApply, "提交付款申请"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View, "查看详情"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ViewMoneyDetail, "用款查询"));

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Confirm, "借款归还确认"));

            this.RegeditQueryOperate<OutMoneyQueryCondition>(true, new List<string> { COMMONQUERY_ALL, COMMONQUERY_APPLICATIONFORPAYMENT, COMMONQUERY_BEPAID, THE_SAME_DAY, THE_SAME_MONTH, THE_SAME_YEAR }, "付款查询");

            this.RegeditPrintOperate();

            this.ModelOperatePageName = "付款管理";
        }

        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {
            base.OperateHandled(operate, e);

            if (operate.Operate == OperateTypes.New.ToString())
            {
                CreatePaymentNote();
            }
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                ModifyPaymentNote();
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                ViewPaymentNote();
            }
            else if (operate.Operate == OperateTypes.ViewMoneyDetail.ToString())
            {
                frmPaymentCalcEdit form = new frmPaymentCalcEdit();
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.SubmitApply.ToString())
            {
                StartFlow();
            }
            else if (operate.Operate == OperateTypes.Delete.ToString())
            {
                PaymentNotes currentRowPaymentNote = this.gvOutMoney.GetFocusedRow() as PaymentNotes;
                if (currentRowPaymentNote == null)
                {
                    XtraMessageBox.Show("请选择需要删除的项");
                    return;
                }
                currentRowPaymentNote = pnm.GetPaymentNoteById(currentRowPaymentNote.ID);
                if (currentRowPaymentNote == null)
                {
                    XtraMessageBox.Show("您选择的项已经不存在，请刷新后重试。");
                    return;
                }
                if (currentRowPaymentNote.EnumFlowState == EnumDataFlowState.审批通过 || currentRowPaymentNote.EnumFlowState == EnumDataFlowState.审批中)
                {
                    XtraMessageBox.Show(string.Format("当前【{0}】付款单{1}，不允许删除。", currentRowPaymentNote.VoucherNo, currentRowPaymentNote.EnumFlowState));
                }
                if (XtraMessageBox.Show(string.Format("是否真的要删除【{0}】付款单？删除后将无法恢复。", currentRowPaymentNote.VoucherNo), "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    pnm.DeletePaymentNote(currentRowPaymentNote.ID);
                    this.gvOutMoney.DeleteRow(this.gvOutMoney.FocusedRowHandle);
                    XtraMessageBox.Show("删除成功");
                }
            }
            else if (operate.Operate == OperateTypes.Confirm.ToString())
            {
                RepayLoanPaymentNote();
            }
        }

        protected override void DoCommonQuery(string queryName)
        {
            OutMoneyQueryCondition outMoneyCondition = new OutMoneyQueryCondition();

            outMoneyCondition.BeginDate = DateTime.MinValue;
            outMoneyCondition.EndDate = DateTime.MinValue;

            if (COMMONQUERY_APPLICATIONFORPAYMENT.Equals(queryName))
            {
                outMoneyCondition.PayState = PaymentState.PendingPayment;
            }
            else if (COMMONQUERY_BEPAID.Equals(queryName))
            {
                outMoneyCondition.PayState = PaymentState.Paid;
            }
            else if (THE_SAME_DAY.Equals(queryName))
            {
                outMoneyCondition.BeginDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                outMoneyCondition.EndDate = outMoneyCondition.BeginDate.AddDays(1).AddSeconds(-1);
            }
            else if (THE_SAME_MONTH.Equals(queryName))
            {
                outMoneyCondition.BeginDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
                outMoneyCondition.EndDate = outMoneyCondition.BeginDate.AddMonths(1).AddSeconds(-1);
            }
            else if (THE_SAME_YEAR.Equals(queryName))
            {
                outMoneyCondition.BeginDate = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
                outMoneyCondition.EndDate = outMoneyCondition.BeginDate.AddYears(1).AddSeconds(-1);
            }

            LoadData(outMoneyCondition);
        }

        protected override void DoConditionQuery(BaseQueryCondition condition)
        {
            OutMoneyQueryCondition outMoneyCondition = condition as OutMoneyQueryCondition;

            LoadData(outMoneyCondition);
        }

        protected override QueryConditionEditorForm CreateConditionEditorForm()
        {
            frmOutMoneyQueryConditionEditor form = new frmOutMoneyQueryConditionEditor();
            form.QueryName = this.GetType().ToString();
            return form;
        }

        private void CreatePaymentNote()
        {
            PaymentNotes currentRowPaymentNote = this.gvOutMoney.GetFocusedRow() as PaymentNotes;
            {
                frmOutMoneyEdit form = new frmOutMoneyEdit();
                form.WorkModel = EditFormWorkModels.New;
                form.ShowDialog(this);
            }
            LoadData();
        }

        private void ModifyPaymentNote()
        {
            PaymentNotes currentRowPaymentNote = this.gvOutMoney.GetFocusedRow() as PaymentNotes;
            if (currentRowPaymentNote == null)
            {
                XtraMessageBox.Show("请选择需要修改的项");
                return;
            }

            if (currentRowPaymentNote.EnumFlowState == EnumDataFlowState.审批中
              || currentRowPaymentNote.EnumFlowState == EnumDataFlowState.审批通过)
            {
                XtraMessageBox.Show(string.Format("{0}付款单{1}不能修改信息。", currentRowPaymentNote.VoucherNo, currentRowPaymentNote.EnumFlowState.ToString()));
                return;
            }

            frmOutMoneyEdit form = new frmOutMoneyEdit();
            form.WorkModel = EditFormWorkModels.Modify;
            form.CurrentPaymentNotes = currentRowPaymentNote;
            form.ShowDialog(this);

            LoadData();
        }

        private void RepayLoanPaymentNote()
        {
            PaymentNotes currentRowPaymentNote = this.gvOutMoney.GetFocusedRow() as PaymentNotes;
            if (currentRowPaymentNote == null)
            {
                XtraMessageBox.Show("请选择需要确认归还的项");
                return;
            }

            if (!currentRowPaymentNote.IsIOU)
            {
                XtraMessageBox.Show(string.Format("该付款不是借款类型。"));
                return;
            }
            frmOutMoneyEdit form = new frmOutMoneyEdit();
            form.WorkModel = EditFormWorkModels.Custom;
            form.CurrentPaymentNotes = currentRowPaymentNote;
            form.ShowDialog(this);

        }

        private void StartFlow()
        {
            PaymentNotes currentRowPaymentNote = this.gvOutMoney.GetFocusedRow() as PaymentNotes;

            if (currentRowPaymentNote != null)
            {
                if (currentRowPaymentNote.EnumFlowState == EnumDataFlowState.审批中)
                {
                    XtraMessageBox.Show(string.Format("{0}付款单{1}，不允许重复提交。", currentRowPaymentNote.VoucherNo, currentRowPaymentNote.EnumFlowState.ToString()));
                    return;
                }
                string message = pnm.StartFlow(currentRowPaymentNote.ID, RunInfo.Instance.CurrentUser.UserName, "");
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

        private void ViewPaymentNote()
        {
            PaymentNotes currentRowPaymentNote = this.gvOutMoney.GetFocusedRow() as PaymentNotes;
            if (currentRowPaymentNote == null)
            {
                XtraMessageBox.Show("请选择需要查看详情的项");
                return;
            }
            frmOutMoneyEdit form = new frmOutMoneyEdit();
            form.WorkModel = EditFormWorkModels.View;
            form.CurrentPaymentNotes = currentRowPaymentNote;
            form.ShowDialog(this);
        }

        public override void LoadData()
        {
            var outMoneyCondition = RunInfo.Instance.GetConditionByCurrentUser(new OutMoneyQueryCondition()) as OutMoneyQueryCondition;

            LoadData(outMoneyCondition);
        }

        private void LoadData(OutMoneyQueryCondition condition)
        {
            if (condition == null)
            {
                condition = new OutMoneyQueryCondition();
            }
            var outMoneyCondition = RunInfo.Instance.GetConditionByCurrentUser(condition) as OutMoneyQueryCondition;

            this.gcOutMoney.DataSource = pnm.GetAllPaymentNoteByCondition(outMoneyCondition);
            this.gvOutMoney.RefreshData();
        }

        protected override void InitGridViewAction()
        {
            this.gridViewAction.Add(this.gvOutMoney, new ActionWithPermission() { MainAction = ModifyPaymentNote, MainOperate = OperateTypes.Modify, SecondAction = ViewPaymentNote, SecondOperate = OperateTypes.View });

        }


        protected override void PrintItem()
        {
            PaymentNotes currentRowPaymentNote = this.gvOutMoney.GetFocusedRow() as PaymentNotes;
            if (currentRowPaymentNote == null)
            {
                XtraMessageBox.Show("请选择需要打印项");
                return;
            }
            frmOutMoneyPrint form = new frmOutMoneyPrint();
            form.WorkModel = EditFormWorkModels.View;
            form.CurrentPaymentNotes = currentRowPaymentNote;
            form.PrintItem();
        }

    }
}
