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
using BudgetSystem.Bll;

namespace BudgetSystem
{
    public partial class ucSupplierSelected : UserControl
    {
        private EnumSupplierType supplierType = EnumSupplierType.临时供方;
        private PaymentNotesManager pnm = new PaymentNotesManager();
        List<Supplier> dataSource = null;
        private int budgetId;
        public ucSupplierSelected()
        {
            InitializeComponent();

            gcIsSelected.OptionsColumn.ShowCaption = false;
            gcIsSelected.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            RegisterEventHandler();
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

        public void SetSelectedItems(int budgetId, List<Supplier> selectedItems, EnumSupplierType type)
        {
            this.budgetId = budgetId;
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

        private void RegisterEventHandler()
        {
            this.gvSupplier.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gvSupplier_CustomDrawGroupRow);
            this.gvSupplier.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvSupplier_CellValueChanging);
            this.gvSupplier.CustomDrawColumnHeader += new DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventHandler(gvSupplier_CustomDrawColumnHeader);
            this.gvSupplier.Click += new EventHandler(gvSupplier_Click);
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
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
                //Supplier supplier = this.gvSupplier.GetRow(e.RowHandle) as Supplier;
                //if (supplier != null)
                //{
                //    if (pnm.IsPay(budgetId, supplier.ID) && (bool)e.Value == false)
                //    {
                //        this.gvSupplier.SetRowCellValue(e.RowHandle, e.Column, true);
                //    }
                //    else
                //    {
                this.gvSupplier.SetRowCellValue(e.RowHandle, e.Column, e.Value);
                //}
                int rowHandle = this.gvSupplier.FocusedRowHandle;
                this.gvSupplier.RefreshData();// (rowHandle);
                this.gvSupplier.FocusedRowHandle = rowHandle;
                //}
            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if (this.Parent is DevExpress.XtraEditors.PopupContainerControl)
            {
                (this.Parent as DevExpress.XtraEditors.PopupContainerControl).OwnerEdit.ClosePopup();
            }
        }


        #region GridControl 全选

        /// <summary>
        /// 是否选中
        /// </summary>
        private bool chkState = false;

        private void gvSupplier_Click(object sender, EventArgs e)
        {
            if (ClickGridCheckBox(this.gvSupplier, chkState))
            {
                chkState = !chkState;
            }
        }

        private void gvSupplier_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column != null && e.Column == gcIsSelected)
            {
                e.Info.InnerElements.Clear();
                e.Painter.DrawObject(e.Info);
                DrawCheckBox(e, chkState);
                e.Handled = true;
            }
        }

        private void DrawCheckBox(DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e, bool chk)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryCheck = e.Column.ColumnEdit as DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit;
            if (repositoryCheck != null)
            {
                System.Drawing.Graphics g = e.Graphics;
                System.Drawing.Rectangle r = e.Bounds;

                DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo info;
                DevExpress.XtraEditors.Drawing.CheckEditPainter painter;
                DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs args;
                info = repositoryCheck.CreateViewInfo() as DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo;

                painter = repositoryCheck.CreatePainter() as DevExpress.XtraEditors.Drawing.CheckEditPainter;
                info.EditValue = chk;
                info.Bounds = r;
                info.CalcViewInfo(g);
                args = new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info, new DevExpress.Utils.Drawing.GraphicsCache(g), r);
                painter.Draw(args);
                args.Cache.Dispose();
            }
        }

        private bool ClickGridCheckBox(DevExpress.XtraGrid.Views.Grid.GridView gridView, bool currentStatus)
        {
            bool result = false;
            if (gridView != null)
            {
                //禁止排序 
                gridView.ClearSorting();

                gridView.PostEditor();
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info;
                System.Drawing.Point pt = gridView.GridControl.PointToClient(Control.MousePosition);
                info = gridView.CalcHitInfo(pt);
                if (info.InColumn && info.Column != null && info.Column == gcIsSelected)
                {
                    for (int i = 0; i < gridView.RowCount; i++)
                    {
                        gridView.SetRowCellValue(i, gcIsSelected, !currentStatus);
                    }
                    return true;
                }
            }
            return result;
        }

        #endregion
    }
}
