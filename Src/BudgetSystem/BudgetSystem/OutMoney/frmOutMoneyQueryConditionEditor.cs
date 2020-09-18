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
            c.Salesman = this.txtApplicant.Text;
            c.BudgetNO = this.txtBudgetNO.Text;
            c.Supplier = this.txtSupplier.Text;
            c.VoucherNo = this.txtVoucherNo.Text;
            if (cboApproveUser.EditValue is User)
            {
                c.ApproveUser = (cboApproveUser.EditValue as User).UserName;
            }

            if (this.deDateBegin.EditValue != null)
            {
                var commitBeginDate = (DateTime)this.deDateBegin.EditValue;
                c.CommitBeginDate = new DateTime(commitBeginDate.Year, commitBeginDate.Month, commitBeginDate.Day, 0, 0, 0);
            }
            else
            {
                c.CommitBeginDate = DateTime.MinValue;
            }
            if (this.deDateEnd.EditValue != null)
            {
                var commitEndDate = (DateTime)this.deDateEnd.EditValue;
                c.CommitEndDate = new DateTime(commitEndDate.Year, commitEndDate.Month, commitEndDate.Day).AddDays(1).AddMilliseconds(-1);
            }
            else
            {
                c.CommitEndDate = DateTime.MinValue;
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