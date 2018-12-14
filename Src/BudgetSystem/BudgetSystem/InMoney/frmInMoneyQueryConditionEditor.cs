using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity.QueryCondition;

namespace BudgetSystem
{
    public partial class frmInMoneyQueryConditionEditor : frmUserQueryConditionEditorTransit
    {
        public frmInMoneyQueryConditionEditor()
        {
            InitializeComponent();
        }


        public override bool CollectData()
        {
            InMoneyQueryCondition c = new InMoneyQueryCondition();
            c.Customer = this.txtCustomer.Text;
            if (this.deReceiptDateBegin.EditValue != null)
                c.ReceiptDateBegin = (DateTime)this.deReceiptDateBegin.EditValue;
            if (this.deReceiptDateEnd.EditValue != null)
                c.ReceiptDateEnd = (DateTime)this.deReceiptDateEnd.EditValue;
            c.VoucherNo = this.txtVoucherNo.Text;
            c.BudgetNO = this.txtBudgetNO.Text;
            this.QueryCondition = c;
            return true;

        }
    }


    /// <summary>
    /// 过渡一下，不然窗体编辑器无法打开
    /// </summary>
    public class frmInMoneyQueryConditionEditorTransit : Base.frmBaseQueryConditionEditor<InMoneyQueryCondition>
    {

    }

}