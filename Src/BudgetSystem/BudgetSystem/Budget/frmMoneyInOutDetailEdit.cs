using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BudgetSystem
{
    public partial class frmMoneyInOutDetailEdit : frmBaseQueryForm
    {
        public frmMoneyInOutDetailEdit()
        {
            InitializeComponent();
        }

        public override void RefreshData()
        {
            //创建或者添加标题需要编辑
            XtraMessageBox.Show(this.Text);
        }

    }
}