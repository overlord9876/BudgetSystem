using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using BudgetSystem.Entity;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace BudgetSystem
{
    public partial class ucDepartmentSelected : UserControl
    {
        List<Department> dataSource = null;
        public ucDepartmentSelected()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 获取当前视图选择的部门列表。
        /// </summary>
        public List<Department> SelectedDepartments
        {
            get
            {
                //保存更改
                this.gvDepartment.CloseEditor();
                var dataSource = (IEnumerable<Department>)gridDepartment.DataSource;
                if (dataSource != null)
                {
                    return dataSource.Where(r => r.IsSelected).ToList();
                }
                else
                {
                    return null;
                }
            }
        }
        public void SetDataSource(List<Department> dataSource)
        {
            this.gridDepartment.DataSource = new BindingList<Department>(dataSource);
            this.gridDepartment.RefreshDataSource();
            if (dataSource != null)
            {
                this.dataSource = new List<Department>();
                dataSource.ForEach(s => this.dataSource.Add(s));
            }
            else
            {
                this.dataSource = null;
            }
        }

        public void SetSelectedItems(List<Department> selectedItems)
        {
            var departments = this.gridDepartment.DataSource as BindingList<Department>;

            if (departments != null)
            {
                foreach (var department in departments)
                {
                    department.IsSelected = false;
                }

                if (selectedItems != null)
                {
                    foreach (Department dept in selectedItems)
                    {
                        Department findedItem = departments.FirstOrDefault(r => r.ID == dept.ID);
                        if (findedItem != null)
                        {
                            findedItem.IsSelected = true;
                        }
                    }
                }
            }
            this.gridDepartment.DataSource = departments;
            this.gridDepartment.RefreshDataSource();
        }

        void gvDepartment_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo info = e.Info as GridGroupRowInfo;
            if (info == null) return;

            if (info.EditValue is bool)
            {
                string text = info.GroupText.Replace("已选择", "").Replace("未选择", "");

                info.GroupText = (Convert.ToBoolean(info.EditValue) ? "已选择" : "未选择") + text;
            }
        }

        void gvDepartment_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == gcIsSelected)
            {
                this.gvDepartment.SetRowCellValue(e.RowHandle, e.Column, e.Value);
                int rowHandle = this.gvDepartment.FocusedRowHandle;
                this.gvDepartment.RefreshData();// (rowHandle);
                this.gvDepartment.FocusedRowHandle = rowHandle;
            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if (this.Parent is DevExpress.XtraEditors.PopupContainerControl)
            {
                (this.Parent as DevExpress.XtraEditors.PopupContainerControl).OwnerEdit.ClosePopup();
            }
        }
    }
}
