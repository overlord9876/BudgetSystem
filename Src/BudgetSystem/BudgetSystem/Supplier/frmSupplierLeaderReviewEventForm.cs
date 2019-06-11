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
    public partial class frmSupplierLeaderReviewEventForm : BudgetSystem.Base.frmBaseFlowEventForm
    {
        public frmSupplierLeaderReviewEventForm()
        {
            InitializeComponent();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if (this.cboItem.SelectedIndex == 0 && this.rgDiscredited.SelectedIndex == 1)
            {
                XtraMessageBox.Show("复审合格时应为非失信企业。");
                return;
            }
            if (this.rgDiscredited.SelectedIndex == -1)
            {
                XtraMessageBox.Show("请选择企业信用信息。");
                return;
            }
            try
            {
                int result = this.cboItem.SelectedIndex;
                this.EventResult = (result != 1 && rgDiscredited.SelectedIndex != 1);
                
                int dataID = ReleateFlowItems.FirstOrDefault().DateItemID;
                SupplierManager sm=new SupplierManager();
                Supplier supplier = sm.GetSupplier(dataID);
                SupplierReviewContents reviewContents = supplier.ReviewContents.ToObjectList<SupplierReviewContents>();
                reviewContents.Leader = RunInfo.Instance.CurrentUser.RealName;
                reviewContents.LeaderResult = this.cboItem.SelectedIndex == 0;
                reviewContents.ResultDate = DateTime.Now;
                reviewContents.Discredited = this.rgDiscredited.SelectedIndex == 1;
                sm.ModifySupplierReviewContents(dataID, reviewContents);
            }
            catch (Exception ex)
            {
                RunInfo.Instance.Logger.LogError(ex);
                XtraMessageBox.Show("保存失败。");
                this.EventResult = null;
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
