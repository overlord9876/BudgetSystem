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
    public partial class ucCustomerSelected : UserControl
    {
        public ucCustomerSelected()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 获取当前视图选择的客户列表。
        /// </summary>
        public List<Customer> SelectedCustomers
        {
            get
            {
                //保存更改
                this.gvCustomer.CloseEditor(); 
                var dataSource = (IEnumerable<Customer>)gridCustomer.DataSource;
                if (dataSource != null)
                {
                    return dataSource.Where(r => r.IsSelected ).ToList();
                }
                else
                {
                    return null;
                }
            }
        }
        public void SetDataSource(List<Customer> dataSource)
        {
            this.gridCustomer.DataSource = new BindingList<Customer>(dataSource);
            this.gridCustomer.RefreshDataSource();
        }

        public void SetSelectedItems(List<Customer> selectedItems)
        {
            var customerList = this.gridCustomer.DataSource as BindingList<Customer>;
            if (customerList != null)
            {
                foreach (var customer in customerList)
                {
                    customer.IsSelected = false;
                }

                if (selectedItems != null)
                {
                    foreach (Customer customer in selectedItems)
                    {
                        Customer findedItem = customerList.FirstOrDefault(r => r.ID == customer.ID); 
                        if (findedItem != null)
                        {
                            findedItem.IsSelected = true;
                        }
                    }
                }
            }
            this.gridCustomer.DataSource = customerList;
            this.gridCustomer.RefreshDataSource();
        }

        void gvCustomer_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo info = e.Info as GridGroupRowInfo;
            if (info == null) return;

            if (info.EditValue is bool)
            {
                info.GroupText = (Convert.ToBoolean(info.EditValue) ? "已选择" : "未选择") + info.GroupText;
            }
        }

        void gvCustomer_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == gcIsSelected)
            {
                this.gvCustomer.SetRowCellValue(e.RowHandle, e.Column, e.Value);
                int rowHandle = this.gvCustomer.FocusedRowHandle;
                this.gvCustomer.RefreshData(); 
                this.gvCustomer.FocusedRowHandle = rowHandle;
            }
        }
    }
}
