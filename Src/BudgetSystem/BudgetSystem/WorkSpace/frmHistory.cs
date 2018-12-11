using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BudgetSystem.Entity;
using System.Linq;
using DevExpress.XtraEditors;
using BudgetSystem.Bll;
using BudgetSystem.OutMoney;

namespace BudgetSystem.WorkSpace
{
    public partial class frmHistory : frmBaseDialogForm
    {
        public frmHistory()
        {
            InitializeComponent();
        }


        public FlowItem FlowItem
        {
            get;
            set;
        }

        public List<FlowRunPoint> Points
        {
            get;
            set;
        }


        private Bll.FlowManager fm = new Bll.FlowManager();

        private void frmApprove_Load(object sender, EventArgs e)
        {
            if (FlowItem != null)
            {
                this.txtFlowName.Text = this.FlowItem.FlowName;
                this.txtDataItemText.Text = this.FlowItem.DateItemText;
                this.txtCreateUserRealName.Text = this.FlowItem.CreateUserRealName;
                this.dtCrateDate.EditValue = this.FlowItem.CreateDate;
                if (this.FlowItem.IsClosed)
                { 
                    this.txtCloseReason.Text=this.FlowItem.CloseReason;
                    this.dtEndDate.EditValue=this.FlowItem.CloseDateTime;
                    this.txtResult.Text = this.FlowItem.InstanceStateWithEmptyState;
                }
                //List<FlowRunPoint> points = fm.GetFlowRunPointsByData(FlowItem.DateItemID,FlowItem.DateItemType).ToList();
                List<FlowRunPoint> points = fm.GetFlowRunPointsByInstance(FlowItem.ID).ToList();

                foreach (FlowRunPoint point in points)
                {
                    FlowApproveDisplayHelper.SetRunPointFlowNodeApproveResultWithStateDisplayName(point, this.FlowItem.FlowName);
                }

                this.gdApproveList.DataSource = points;
            }
            else
            {
                this.layoutControlGroup2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.gdApproveList.DataSource = Points;
            }
        }


    }
}
