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
    public partial class ucUserSelected : UserControl
    {
        /// <summary>
        /// 是否显示选择列
        /// </summary>
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
        public bool IsShowSelectedColumn
        {
            set
            {
                if (value && !this.gvUsers.Columns.Contains(this.gcIsSelected))
                {
                    this.gvUsers.Columns.Insert(0, this.gcIsSelected);
                    this.gvUsers.GroupSummary.Clear();
                    this.gvUsers.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                                          new GridGroupSummaryItem(SummaryItemType.Count, "IsSelected", null, "")});
                    this.gvUsers.SortInfo.Clear();
                    this.gvUsers.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
                         new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcIsSelected, DevExpress.Data.ColumnSortOrder.Descending)});
                }
                else if (!value && this.gvUsers.Columns.Contains(this.gcIsSelected))
                {
                    this.gvUsers.Columns.Remove(this.gcIsSelected);
                }
                this.gridUsers.RefreshDataSource();
            }
        }

        public ucUserSelected()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 获取当前视图选择的用户列表。
        /// </summary>
        public List<User> SelectedUsers
        {
            get
            {
                //保存更改
                this.gvUsers.CloseEditor();
                var dataSource = (IEnumerable<User>)gridUsers.DataSource;
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
        /// 当前光标行对应用户信息
        /// </summary>
        public User FocusedUser
        {
            get
            {
                if (this.gvUsers.FocusedRowHandle >= 0)
                {
                    return this.gvUsers.GetRow(this.gvUsers.FocusedRowHandle) as User;
                }
                return null;
            }
        }

        public void SetDataSource(List<User> dataSource)
        {
            this.gridUsers.DataSource = new BindingList<User>(dataSource);
            this.gridUsers.RefreshDataSource();
        }

        public void SetSelectedItems(List<User> selectedItems)
        {
            var customerList = this.gridUsers.DataSource as BindingList<User>;
            if (customerList != null)
            {
                foreach (var customer in customerList)
                {
                    customer.IsSelected = false;
                }

                if (selectedItems != null)
                {
                    foreach (User user in selectedItems)
                    {
                        User findedItem = customerList.FirstOrDefault(r => r.UserName == user.UserName);
                        if (findedItem != null)
                        {
                            findedItem.IsSelected = true;
                        }
                    }
                }
            }
            this.gridUsers.DataSource = customerList;
            this.gridUsers.RefreshDataSource();
        }

        public void SetFocusedItem(string userName)
        {
            var customerList = this.gridUsers.DataSource as BindingList<User>;
            if (customerList != null)
            {
                User temp = customerList.FirstOrDefault(c => c.UserName == userName);
                if (temp != null)
                {
                    this.gvUsers.FocusedRowHandle = this.gvUsers.GetRowHandle(customerList.IndexOf(temp));
                }
            }
        }
        void gvUser_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo info = e.Info as GridGroupRowInfo;
            if (info == null) return;

            if (info.EditValue is bool)
            {
                info.GroupText = (Convert.ToBoolean(info.EditValue) ? "已选择" : "未选择") + info.GroupText;
            }
        }

        void gvUser_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == gcIsSelected)
            {
                this.gvUsers.SetRowCellValue(e.RowHandle, e.Column, e.Value);
                int rowHandle = this.gvUsers.FocusedRowHandle;
                this.gvUsers.RefreshData();
                this.gvUsers.FocusedRowHandle = rowHandle;
            }
        }
    }
}
