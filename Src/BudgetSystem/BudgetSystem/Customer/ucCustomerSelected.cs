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
using DevExpress.XtraGrid;
using DevExpress.Data;

namespace BudgetSystem
{
    public partial class ucCustomerSelected : UserControl
    {
        bool isShowSelectedColumn = true;
        /// <summary>
        /// 是否显示选择列
        /// </summary>
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
        public bool IsShowSelectedColumn
        {
            set
            {
                isShowSelectedColumn = value;
                if (value && !this.gvCustomer.Columns.Contains(this.gcIsSelected))
                {
                    this.gvCustomer.Columns.Insert(0, this.gcIsSelected);
                    this.gvCustomer.GroupSummary.Clear();
                    this.gvCustomer.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                                          new GridGroupSummaryItem(SummaryItemType.Count, "IsSelected", null, "")});
                    this.gvCustomer.SortInfo.Clear();
                    this.gvCustomer.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
                         new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcIsSelected, DevExpress.Data.ColumnSortOrder.Descending)});
                }
                else if (!value && this.gvCustomer.Columns.Contains(this.gcIsSelected))
                {
                    this.gvCustomer.Columns.Remove(this.gcIsSelected);
                }
                this.gridCustomer.RefreshDataSource();
                if (value)
                {
                    this.layoutControlItemSure.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
                else
                {
                    this.layoutControlItemSure.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
            }
        }

        /// <summary>
        /// 是否可以编辑
        /// </summary>
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
        public bool CanEdit
        {
            set
            {
                this.gvCustomer.OptionsBehavior.Editable = value;
            }
        }

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
                    return dataSource.Where(r => r.IsSelected).ToList();
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// 当前光标行对应客户信息
        /// </summary>
        public Customer FocusedCustomer
        {
            get
            {
                if (this.gvCustomer.FocusedRowHandle >= 0)
                {
                    return this.gvCustomer.GetRow(this.gvCustomer.FocusedRowHandle) as Customer;
                }
                return null;
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

        public void SetFocusedItem(int customerID)
        {
            if (customerID <= 0)
            {
                return;
            }
            var customerList = this.gridCustomer.DataSource as BindingList<Customer>;
            if (customerList != null)
            {
                Customer temp = customerList.FirstOrDefault(c => c.ID == customerID);
                if (temp != null)
                {
                    this.gvCustomer.FocusedRowHandle = this.gvCustomer.GetRowHandle(customerList.IndexOf(temp));
                }
            }
        }
        void gvCustomer_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo info = e.Info as GridGroupRowInfo;
            if (info == null) return;

            if (info.EditValue is bool)
            {
                string text = info.GroupText.Replace("已选择", "").Replace("未选择", "");

                info.GroupText = (Convert.ToBoolean(info.EditValue) ? "已选择" : "未选择") + text;
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

        private void gvCustomer_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (!this.isShowSelectedColumn
                && this.gvCustomer.FocusedRowHandle >= 0
                && this.Parent is DevExpress.XtraEditors.PopupContainerControl)
            {
                (this.Parent as DevExpress.XtraEditors.PopupContainerControl).OwnerEdit.ClosePopup();
            }
            //是否有必要实现在非选择列点击时选择（或取消选择）?
            //else if (this.gvCustomer.FocusedRowHandle >= 0)
            //{
            //    bool isSelect=(bool)this.gvCustomer.GetRowCellValue(this.gvCustomer.FocusedRowHandle,this.gcIsSelected);
            //    int rowHandle = this.gvCustomer.FocusedRowHandle;
            //    this.gvCustomer.SetRowCellValue(e.RowHandle, gcIsSelected,!isSelect);
            //    this.gvCustomer.RefreshData();
            //    this.gvCustomer.FocusedRowHandle = rowHandle;
            //}
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
