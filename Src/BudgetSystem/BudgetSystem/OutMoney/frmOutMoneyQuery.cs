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

namespace BudgetSystem
{
    public partial class frmOutMoneyQuery : frmBaseQueryForm
    {
        PaymentNotesManager pnm = new PaymentNotesManager();

        public frmOutMoneyQuery()
        {
            InitializeComponent();
            this.Module = BusinessModules.OutMoneyManagement;
            this.gvOutMoney.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(gvOutMoney_RowClick);
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New, "付款申请"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify, "修改付款"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Delete, "删除付款"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.SubmitApply, "提交付款申请"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View, "查看详情"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Print));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Confirm));



            this.ModelOperatePageName = "付款管理";
        }

        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {

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
            else if (operate.Operate == OperateTypes.Confirm.ToString())
            {
                StartFlow();
            }
            else if (operate.Operate == OperateTypes.Delete.ToString())
            {
                PaymentNotes currentRowPaymentNote = this.gvOutMoney.GetFocusedRow() as PaymentNotes;
                pnm.DeletePaymentNote(currentRowPaymentNote.ID);
                this.gvOutMoney.DeleteRow(this.gvOutMoney.FocusedRowHandle);
                XtraMessageBox.Show("删除成功");
            }
            else
            {
                XtraMessageBox.Show("未定义的操作1");
            }
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
                string message = pnm.StartFlow(currentRowPaymentNote.ID, RunInfo.Instance.CurrentUser.UserName);
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
            {
                frmOutMoneyEdit form = new frmOutMoneyEdit();
                form.WorkModel = EditFormWorkModels.View;
                form.CurrentPaymentNotes = currentRowPaymentNote;
                form.ShowDialog(this);
            }
        }

        public override void LoadData()
        {
            this.gcOutMoney.DataSource = pnm.GetAllPaymentNotes();
            this.gvOutMoney.RefreshData();
        }

        private void gvOutMoney_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2 && e.RowHandle >= 0)
            {
                if (CheckPermission(OperateTypes.Modify))
                {
                    ModifyPaymentNote();
                }
                else if (CheckPermission(OperateTypes.View))
                {
                    ViewPaymentNote();
                }
            }
        }

    }
}
