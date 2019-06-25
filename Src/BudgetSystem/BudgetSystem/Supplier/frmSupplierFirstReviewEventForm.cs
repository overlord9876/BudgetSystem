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
    public partial class frmSupplierFirstReviewEventForm : BudgetSystem.Base.frmBaseFlowEventForm
    {
        private string caption;

        public frmSupplierFirstReviewEventForm(string caption)
        {
            InitializeComponent();
            this.Text = caption;
            this.caption = caption;
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.cboItem.SelectedIndex;
                this.EventResult = result != 3;
                foreach (var releateFlowItem in ReleateFlowItems)
                {
                    int dataID = releateFlowItem.DateItemID;
                    SupplierManager sm = new SupplierManager();
                    Supplier supplier = sm.GetSupplier(dataID);
                    SupplierFirstReviewContents reviewContents = supplier.FirstReviewContents.ToObjectList<SupplierFirstReviewContents>();
                    if (caption == BudgetSystem.Base.frmBaseFlowEventForm.FirstReviewManager)
                    {
                        reviewContents.Manager = RunInfo.Instance.CurrentUser.RealName;
                        reviewContents.ManagerResult = result;
                    }
                    else if (caption == BudgetSystem.Base.frmBaseFlowEventForm.FirstReviewLeader)
                    {
                        reviewContents.Leader = RunInfo.Instance.CurrentUser.RealName;
                        reviewContents.LeaderResult = result;
                        reviewContents.ResultDate = DateTime.Now;
                    }
                    sm.ModifySupplierFirstReviewContents(dataID, reviewContents);
                }
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
