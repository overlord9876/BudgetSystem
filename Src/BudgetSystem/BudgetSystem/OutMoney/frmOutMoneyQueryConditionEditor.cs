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
    public partial class frmOutMoneyQueryConditionEditor : frmUserQueryConditionEditorTransit
    {
        public frmOutMoneyQueryConditionEditor()
        {
            InitializeComponent();
        }


        public override bool CollectData()
        {
            OutMoneyQueryCondition c = new OutMoneyQueryCondition();
            c.Applicant = this.txtApplicant.Text;
            c.BudgetNO = this.txtBudgetNO.Text;
            c.Supplier = this.txtSupplier.Text;
            c.VoucherNo = this.txtVoucherNo.Text;
            this.QueryCondition = c;
            return true;

        }
    }


    /// <summary>
    /// 过渡一下，不然窗体编辑器无法打开
    /// </summary>
    public class frmOutMoneyQueryConditionEditorTransit : Base.frmBaseQueryConditionEditor<OutMoneyQueryCondition>
    {

    }

}