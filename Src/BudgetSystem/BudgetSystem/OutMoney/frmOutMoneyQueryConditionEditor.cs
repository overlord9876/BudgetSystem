using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity.QueryCondition;
using BudgetSystem.Entity;

namespace BudgetSystem
{
    public partial class frmOutMoneyQueryConditionEditor : frmOutMoneyQueryConditionEditorTransit
    {
        private Bll.UserManager um = new Bll.UserManager();
        public frmOutMoneyQueryConditionEditor()
        {
            InitializeComponent();
            cboApproveUser.Properties.Items.AddRange(um.GetAllUser());
        }


        public override bool CollectData()
        {
            OutMoneyQueryCondition c = new OutMoneyQueryCondition();
            c.Applicant = this.txtApplicant.Text;
            c.BudgetNO = this.txtBudgetNO.Text;
            c.Supplier = this.txtSupplier.Text;
            c.VoucherNo = this.txtVoucherNo.Text;
            if (cboApproveUser.EditValue is User)
            {
                c.ApproveUser = (cboApproveUser.EditValue as User).UserName;
            }
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