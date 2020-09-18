using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity.QueryCondition;

namespace BudgetSystem
{
    public partial class frmInMoneyQueryConditionEditor : frmInMoneyQueryConditionEditorTransit
    {
        public frmInMoneyQueryConditionEditor()
        {
            InitializeComponent();
            this.txtState.Properties.Items.AddRange(Enum.GetNames(typeof(QueryReceiptState)).Select(o => o.Trim()).ToArray());
            this.txtState.SelectedIndex = 0;
        }


        public override bool CollectData()
        {
            InMoneyQueryCondition c = new InMoneyQueryCondition();
            c.Customer = this.txtCustomer.Text;

            if (this.deReceiptDateBegin.EditValue != null)
            {
                var commitBeginDate = (DateTime)this.deReceiptDateBegin.EditValue;
                c.ReceiptDateBegin = new DateTime(commitBeginDate.Year, commitBeginDate.Month, commitBeginDate.Day, 0, 0, 0);
            }
            else
            {
                c.ReceiptDateBegin = DateTime.MinValue;
            }
            if (this.deReceiptDateEnd.EditValue != null)
            {
                var commitEndDate = (DateTime)this.deReceiptDateEnd.EditValue;
                c.ReceiptDateEnd = new DateTime(commitEndDate.Year, commitEndDate.Month, commitEndDate.Day).AddDays(1).AddMilliseconds(-1);
            }
            else
            {
                c.ReceiptDateEnd = DateTime.MinValue;
            }
            c.State = (QueryReceiptState)Enum.Parse(typeof(QueryReceiptState), txtState.EditValue.ToString());
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