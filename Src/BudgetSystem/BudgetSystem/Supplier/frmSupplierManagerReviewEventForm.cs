using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;
using BudgetSystem.Bll;

namespace BudgetSystem
{
    public partial class frmSupplierManagerReviewEventForm : BudgetSystem.Base.frmBaseFlowEventForm
    {
        public frmSupplierManagerReviewEventForm()
        {
            InitializeComponent();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.cboItem.SelectedIndex;
                if (result == 1)
                {
                    this.EventResult = false;
                }
                int dataID = ReleateFlowItems.FirstOrDefault().DateItemID;
                SupplierManager sm=new SupplierManager();
                Supplier supplier = sm.GetSupplier(dataID);
                SupplierReviewContents reviewContents = supplier.ReviewContents.ToObjectList<SupplierReviewContents>();
                reviewContents.Manager = RunInfo.Instance.CurrentUser.UserName;
                reviewContents.ManagerResult = result==0?true:false;
                sm.ModifySupplierReviewContents(dataID, reviewContents);
            }
            catch (Exception ex)
            {
                RunInfo.Instance.Logger.LogError(ex);
                XtraMessageBox.Show("保存失败。");
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
