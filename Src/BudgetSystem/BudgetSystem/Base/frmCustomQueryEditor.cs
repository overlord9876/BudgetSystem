using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity.QueryCondition;

namespace BudgetSystem.Base
{
    public partial class frmCustomQueryEditor : DevExpress.XtraEditors.XtraForm
    {
        public frmCustomQueryEditor()
        {
            InitializeComponent();
        }

        public string QueryName
        {
            get;
            set;
        }

        public bool IsModifyedCondition
        {
            get;
            set;
        }

        List<BaseQueryCondition> conditions;


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.listBoxControl1.SelectedItem != null)
            {
                conditions.Remove(this.listBoxControl1.SelectedItem as BaseQueryCondition);
                this.listBoxControl1.Refresh();
                UIEntity.QueryConditionHelper.SaveCondition(conditions, this.QueryName);
                this.IsModifyedCondition = true;
            }
            else
            {
                XtraMessageBox.Show("请选中要删除的查询");
            }
        }

        private void frmCustomQueryEditor_Load(object sender, EventArgs e)
        {
            conditions = UIEntity.QueryConditionHelper.GetExistCondition<BaseQueryCondition>(this.QueryName);
            this.listBoxControl1.DataSource = conditions;
        }
    }
}