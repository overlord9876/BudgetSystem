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
    public partial class frmOutMoneyQuery : frmBaseQueryFormWithCondtion
    {
        PaymentNotesManager pnm = new PaymentNotesManager();

        public frmOutMoneyQuery()
        {
            InitializeComponent();
            this.Module = BusinessModules.OutMoneyManagement;
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New, "付款申请"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify, "修改付款申请"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Delete, "删除付款申请"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Confirm, "确认已付款"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.GiveUp, "放弃付款"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View, "查看详情"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View, "查看审批记录"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Print));



            this.ModelOperatePageName = "付款管理";
        }

        public override void OperateHandled(ModelOperate operate)
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
            {
                frmOutMoneyEdit form = new frmOutMoneyEdit();
                form.WorkModel = EditFormWorkModels.Modify;
                form.CurrentPaymentNotes = currentRowPaymentNote;
                form.ShowDialog(this);
            }
            LoadData();
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
    }
}
