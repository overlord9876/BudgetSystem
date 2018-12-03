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

        private Bll.FlowManager fm = new Bll.FlowManager();

        private void frmApprove_Load(object sender, EventArgs e)
        {
            this.txtFlowName.Text = this.FlowItem.FlowName;
            this.txtDataItemText.Text = this.FlowItem.DateItemText;
            this.txtCreateUserRealName.Text = this.FlowItem.CreateUserRealName;
            this.dtCrateDate.EditValue = this.FlowItem.CreateDate;

            //List<FlowRunPoint> points = fm.GetFlowRunPointsByData(FlowItem.DateItemID,FlowItem.DateItemType).ToList();
            List<FlowRunPoint> points = fm.GetFlowRunPointsByInstance(FlowItem.ID).ToList();
            this.gdApproveList.DataSource = points;
        }


    }
}
