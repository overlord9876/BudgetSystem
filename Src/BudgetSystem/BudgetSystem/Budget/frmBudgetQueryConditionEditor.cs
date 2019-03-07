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
    public partial class frmBudgetQueryConditionEditor : frmBudgetQueryConditionEditorTransit
    {
        public frmBudgetQueryConditionEditor()
        {
            InitializeComponent();
        }
        private void frmBudgetQueryConditionEditor_Load(object sender, EventArgs e)
        {
            List<Department> departmentList = new DepartmentManager().GetAllDepartment();
            if (departmentList == null)
            {
                departmentList = new List<Department>();
            }
            departmentList.Insert(0, new Department() { Code = string.Empty, Name = string.Empty });
            this.cboDepartment.Properties.Items.AddRange(departmentList);
        }
        public override bool CollectData()
        {
            BudgetQueryCondition c = new BudgetQueryCondition();
            c.ContractNO = this.txtContractNO.Text;
            c.CustomerName = this.txtCustomerName.Text;
            if (this.cboDepartment.SelectedItem != null)
            {
                c.DeptID = ((Department)this.cboDepartment.SelectedItem).ID;
            }
            this.QueryCondition = c;
            return true;
        }


    }


    /// <summary>
    /// 过渡一下，不然窗体编辑器无法打开
    /// </summary>
    public class frmBudgetQueryConditionEditorTransit : Base.frmBaseQueryConditionEditor<BudgetQueryCondition>
    {

    }

}