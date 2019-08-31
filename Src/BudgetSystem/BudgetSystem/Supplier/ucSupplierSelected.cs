﻿using System;
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
    public partial class ucSupplierSelected : UserControl
    {
        private EnumSupplierType supplierType = EnumSupplierType.临时供方;
        List<Supplier> dataSource = null;
        public ucSupplierSelected()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 获取当前视图选择的供应商列表。
        /// </summary>
        public List<Supplier> SelectedSuppliers
        {
            get
            {
                //保存更改
                this.gvSupplier.CloseEditor();
                var dataSource = (IEnumerable<Supplier>)gridSupplier.DataSource;
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
        /// 是否可以编辑
        /// </summary>
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
        public bool CanEdit
        {
            set
            {
                this.gvSupplier.OptionsBehavior.Editable = value;
            }
        }

        public void SetDataSource(List<Supplier> dataSource)
        {
            this.gridSupplier.DataSource = new BindingList<Supplier>(dataSource);
            this.gridSupplier.RefreshDataSource();
            if (dataSource != null)
            {
                this.dataSource = new List<Supplier>();
                dataSource.ForEach(s => this.dataSource.Add(s));
            }
            else
            {
                this.dataSource = null;
            }
        }

        public void SetSelectedItems(List<Supplier> selectedItems, EnumSupplierType type)
        {
            var suppliers = this.gridSupplier.DataSource as BindingList<Supplier>;

            if (suppliers != null)
            {
                if (this.supplierType != type)
                {
                    List<Supplier> newDataSource = new List<Supplier>();
                    if (type == EnumSupplierType.合格供方)
                    {
                        this.dataSource.ForEach(s => { if (s.IsQualified == true) { newDataSource.Add(s); } });
                    }
                    else if (type == EnumSupplierType.临时供方)
                    {
                        this.dataSource.ForEach(s => { if (s.SupplierType == (int)type) { newDataSource.Add(s); } });
                    }
                    else
                    {
                        this.dataSource.ForEach(s => { if (s.SupplierType != (int)EnumSupplierType.临时供方 && s.IsQualified == false) { newDataSource.Add(s); } });
                    }
                    suppliers = new BindingList<Supplier>(newDataSource);
                }
                foreach (var supplier in suppliers)
                {
                    supplier.IsSelected = false;
                }

                if (selectedItems != null)
                {
                    foreach (Supplier supplier in selectedItems)
                    {
                        Supplier findedItem = suppliers.FirstOrDefault(r => r.ID == supplier.ID);
                        if (findedItem != null)
                        {
                            findedItem.IsSelected = true;
                        }
                    }
                }
            }
            this.supplierType = type;
            this.gridSupplier.DataSource = suppliers;
            this.gridSupplier.RefreshDataSource();
        }

        void gvSupplier_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo info = e.Info as GridGroupRowInfo;
            if (info == null) return;

            if (info.EditValue is bool)
            {
                string text = info.GroupText.Replace("已选择", "").Replace("未选择", "");

                info.GroupText = (Convert.ToBoolean(info.EditValue) ? "已选择" : "未选择") + text;
            }
        }

        void gvSupplier_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == gcIsSelected)
            {
                this.gvSupplier.SetRowCellValue(e.RowHandle, e.Column, e.Value);
                int rowHandle = this.gvSupplier.FocusedRowHandle;
                this.gvSupplier.RefreshData();// (rowHandle);
                this.gvSupplier.FocusedRowHandle = rowHandle;
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
