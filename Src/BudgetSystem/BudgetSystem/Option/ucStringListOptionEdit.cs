using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BudgetSystem.Entity;
using DevExpress.XtraEditors;

namespace BudgetSystem
{
    /// <summary>
    /// 字符串列表配置界面
    /// </summary>
    public partial class ucStringListOptionEdit : ucOptionEditBase
    {
        public ucStringListOptionEdit(EnumSystemConfigNames name)
            : base()
        {
            InitializeComponent();
            this.OptionName = name.ToString();
        }

        protected override void RegisterEvent()
        {
            this.gvStringList.CellValueChanged += gvStringList_CellValueChanged;
            this.gvStringList.ValidateRow += gvStringList_ValidateRow;
            this.gvStringList.InvalidRowException += gvStringList_InvalidRowException;
            this.riHyperLinkEditDelete.Click += riHyperLinkEditDelete_Click;
            this.riHyperLinkEditDelete.CustomDisplayText += riHyperLinkEditDelete_CustomDisplayText;
        }
        protected override void BindingOption()
        {
            if (!AllowEdit)
            {
                this.gvStringList.Columns.Remove(this.gcDelete);
                this.gcName.OptionsColumn.AllowEdit = false;
                this.gvStringList.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            }
            List<string> options = this.scm.GetSystemConfigValue<List<string>>(this.OptionName);
            if (options == null)
            {
                options = new List<string>();
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            options.ForEach(o => dt.Rows.Add(o));
            this.gridStringList.DataSource = dt;
            this.gridStringList.RefreshDataSource();
        }
        public override bool Save()
        {
            this.gvStringList.CloseEditor();
            DataTable dataSource = gridStringList.DataSource as DataTable;
            List<string> options = new List<string>();
            object focusedCellValue = this.gvStringList.GetRowCellValue(gvStringList.FocusedRowHandle, gcName);
            if (dataSource.Rows.Count == 0 && focusedCellValue != null)
            {
                options.Add(focusedCellValue.ToString());
            }
            else
            {
                foreach (DataRow row in dataSource.Rows)
                {
                    options.Add(row[0].ToString());
                }
            }
            options.RemoveAll(o => string.IsNullOrEmpty(o));
            this.scm.ModifySystemConfig<List<string>>(this.OptionName, options);
            this.IsChanged = false;
            return true;
        }
        private void gvStringList_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            gvStringList.SetColumnError(null, e.ErrorText);
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gvStringList_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var data = gvStringList.GetRowCellValue(e.RowHandle, gcName) as string;
            e.ErrorText = CheckData(data);
            if (!string.IsNullOrEmpty(e.ErrorText))
            {
                e.Valid = false;
            }
        }

        private void riHyperLinkEditDelete_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = "删除";
        }

        private void riHyperLinkEditDelete_Click(object sender, EventArgs e)
        {
            if (this.gvStringList.FocusedRowHandle < 0)
            {
                gvStringList.CloseEditor();
                gvStringList.CancelUpdateCurrentRow();
                this.IsChanged = true;
            }
            else
            {
                gvStringList.DeleteRow(gvStringList.FocusedRowHandle);
            }
        }

        private void gvStringList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.IsChanged = true;
        }

        private string CheckData(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return this.OptionName + "不能为空";
            }
            return string.Empty;
        }
    }
}
