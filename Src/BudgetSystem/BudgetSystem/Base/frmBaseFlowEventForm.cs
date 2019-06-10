using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;

namespace BudgetSystem.Base
{
    public partial class frmBaseFlowEventForm : DevExpress.XtraEditors.XtraForm
    {
        public frmBaseFlowEventForm()
        {
            InitializeComponent();
        }
        [DefaultValue(true)]
        public bool EventResult
        {
            get;
            set;
        }
        public List<FlowItem> ReleateFlowItems
        {
            get;
            set;
        }

        public static frmBaseFlowEventForm GetFlowExtEventForm(string extEventName, List<FlowItem> items)
        {
            frmBaseFlowEventForm form = null;
            if (extEventName == "修改付款银行")
            {
                form = new frmTestFlowEventForm();
            }
            else if (extEventName == "供应商初审部门经理审批")
            {
                form = new frmSupplierManagerFirstReviewEventForm ();
            }
            else if (extEventName == "供应商初审贸管部审批")
            {
                form = new frmSupplierLeaderFirstReviewEventForm();
            }
            else if (extEventName == "供应商复审部门经理审批")
            {
                form = new frmSupplierManagerReviewEventForm();
            }
            else if (extEventName == "供应商复审贸管部审批")
            {
                form = new frmSupplierLeaderReviewEventForm();
            }
            if (form != null)
            {
                form.ReleateFlowItems = items;
            }
            return form;
        }
    }
}