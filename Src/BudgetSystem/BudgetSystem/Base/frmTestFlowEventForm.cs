using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BudgetSystem.Entity;

namespace BudgetSystem.Base
{
    public partial class frmTestFlowEventForm : BudgetSystem.Base.frmBaseFlowEventForm
    {
        public frmTestFlowEventForm()
        {
            InitializeComponent();
        }


        private void SaveData()
        {
            foreach (FlowItem fi in this.ReleateFlowItems)
            {

                //DoSave
            }

        }

        private void btnSure_Click(object sender, EventArgs e)
        {


            SaveData();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }
    }
}
