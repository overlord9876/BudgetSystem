using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity.QueryCondition;
using BudgetSystem.Entity;
using BudgetSystem.Bll;

namespace BudgetSystem
{
    public partial class frmSupplierQueryConditionEditor : frmSupplierQueryConditionEditorTransit
    {
        public frmSupplierQueryConditionEditor()
        {
            InitializeComponent();
        }
        private void frmSupplierQueryConditionEditor_Load(object sender, EventArgs e)
        {
            List<Department> departmentList = new DepartmentManager().GetAllDepartment();
            if (departmentList == null)
            {
                departmentList = new List<Department>();
            }
            departmentList.Insert(0, new Department() { Code = string.Empty, Name = string.Empty });
            this.cboDepartment.Properties.Items.AddRange(departmentList);

            this.cboType.Properties.Items.Add("");
            this.cboType.Properties.Items.Add("合格供方");
            this.cboType.Properties.Items.Add("临时供方");
            this.cboType.Properties.Items.Add("其它供方");
        }
        public override bool CollectData()
        {
            SupplierQueryCondition c = new SupplierQueryCondition();
            c.SupplierName = this.txtName.Text;
            if (this.cboType.SelectedIndex >= 0)
            {
                c.SupplierType = this.cboType.SelectedIndex - 1;
            }
            else
            {
                c.SupplierType = -1;
            }
            if (this.cboDepartment.SelectedItem != null)
            {
                c.Department = ((Department)this.cboDepartment.SelectedItem).Code;
            }
            this.QueryCondition = c;
            return true;
        }


    }


    /// <summary>
    /// 过渡一下，不然窗体编辑器无法打开
    /// </summary>
    public class frmSupplierQueryConditionEditorTransit : Base.frmBaseQueryConditionEditor<SupplierQueryCondition>
    {

    }

}