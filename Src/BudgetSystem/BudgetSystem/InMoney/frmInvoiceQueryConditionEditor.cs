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

namespace BudgetSystem
{
    public partial class frmInvoiceQueryConditionEditor : frmInvoiceQueryConditionEditorTransit
    {
        private Bll.DepartmentManager dm = new Bll.DepartmentManager();
        private ucDepartmentSelected ucDepartmentSelected1;
        public frmInvoiceQueryConditionEditor()
        {
            InitializeComponent();

            if (!frmBaseForm.IsDesignMode)
            {
                ucDepartmentSelected1 = new ucDepartmentSelected();
                this.pccDepartment.Controls.Add(ucDepartmentSelected1);
                ucDepartmentSelected1.Dock = DockStyle.Fill;

                List<Department> departmentList = dm.GetAllDepartment();

                this.ucDepartmentSelected1.SetDataSource(departmentList);

                this.pceDepartment.Properties.PopupControl = this.pccDepartment;
                this.pceDepartment.QueryResultValue += new DevExpress.XtraEditors.Controls.QueryResultValueEventHandler(pceDepartment_QueryResultValue);
                this.pceDepartment.QueryPopUp += new CancelEventHandler(pceDepartment_QueryPopUp);
            }
        }

        void pceDepartment_QueryPopUp(object sender, CancelEventArgs e)
        {
            PopupContainerEdit popupedit = (PopupContainerEdit)sender;
            popupedit.Properties.PopupControl = this.pccDepartment;
            this.ucDepartmentSelected1.SetSelectedItems(popupedit.Tag as List<Department>);
            pccDepartment.Width = popupedit.Width;
            pccDepartment.Height = 300;
        }

        void pceDepartment_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
            List<Department> departments = this.ucDepartmentSelected1.SelectedDepartments;
            e.Value = departments.ToNameString();
            PopupContainerEdit popupedit = (PopupContainerEdit)sender;
            popupedit.Tag = departments;
        }

        public override bool CollectData()
        {
            InvoiceQueryCondition c = new InvoiceQueryCondition();
            c.Code = this.txtCode.Text;
            c.ContractNO = this.txtContract.Text;

            if (this.deDateBegin.EditValue != null)
                c.BeginTimestamp = (DateTime)this.deDateBegin.EditValue;
            if (this.deEndDate.EditValue != null)
                c.EndTimestamp = (DateTime)this.deEndDate.EditValue;

            if (this.ucDepartmentSelected1.SelectedDepartments != null && this.ucDepartmentSelected1.SelectedDepartments.Count > 0)
            {
                c.DeptID = this.ucDepartmentSelected1.SelectedDepartments[0].ID;
            }

            this.QueryCondition = c;
            return true;
        }
    }


    /// <summary>
    /// 过渡一下，不然窗体编辑器无法打开
    /// </summary>
    public class frmInvoiceQueryConditionEditorTransit : Base.frmBaseQueryConditionEditor<InvoiceQueryCondition>
    {

    }

}