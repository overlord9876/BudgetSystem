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

        public List<FlowItem> ReleateFlowItems
        {
            get;
            set;
        }

        public static frmBaseFlowEventForm GetFlowExtEventForm(string extEventName,List<FlowItem> items)
        {
            frmBaseFlowEventForm form =null;
            if (extEventName == "test")
            {
                form = new frmTestFlowEventForm();
            }
        
            if (form !=null)
            {
                form.ReleateFlowItems = items;
            }
            return form;
        }
    }
}