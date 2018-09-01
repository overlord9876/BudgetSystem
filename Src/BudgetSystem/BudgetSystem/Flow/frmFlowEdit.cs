using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BudgetSystem
{
    public partial class frmFlowEdit : frmBaseDialogForm
    {
        public frmFlowEdit()
        {
            InitializeComponent();
        }


        public void LoadData()
        {
            this.txtFlowName.Text = "预算单审批流程";
            this.txtFlowDescription.Text = "预算单审批流程";


            DataTable dt = new DataTable();
            dt.Columns.Add("Approver");
            dt.Columns.Add("ApproverJob");

            dt.Rows.Add("谈乐平", "总经理");
            dt.Rows.Add("财务部经理", "财务主管");
            dt.Rows.Add("提出人所在部门经理", "部门经理");
            this.gridControl1.DataSource = dt;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void frmFlowEdit_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
