using System;
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
    /// 用款类型配置界面
    /// </summary>
    public partial class ucUseMoneyTypeOptionEdit : ucOptionEditBase
    {
        public ucUseMoneyTypeOptionEdit()
            : base()
        {
            InitializeComponent();
            this.OptionName = EnumSystemConfigNames.用款类型.ToString(); 
        }

        protected override void RegisterEvent()
        {
            this.gvPort.CellValueChanged += gvPort_CellValueChanged;
            this.gvPort.ValidateRow += gvPort_ValidateRow;
            this.gvPort.InvalidRowException += gvPort_InvalidRowException;
            this.riHyperLinkEditDelete.Click += riHyperLinkEditDelete_Click;
            this.riHyperLinkEditDelete.CustomDisplayText += riHyperLinkEditDelete_CustomDisplayText;
        }
        protected override void BindingOption()
        {
            if (!AllowEdit)
            {
                this.gvPort.Columns.Remove(this.gcDelete);
                this.gcName.OptionsColumn.AllowEdit = false;
                this.gcProvideInvoice.OptionsColumn.AllowEdit = false;
                this.gvPort.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            }
            List<UseMoneyType> typeList = this.scm.GetSystemConfigValue<List<UseMoneyType>>(this.OptionName);
            if (typeList == null)
            {
                typeList = new List<UseMoneyType>();
            }
            BindingList<UseMoneyType> dataSource = new BindingList<UseMoneyType>(typeList);
            this.gridPort.DataSource = dataSource;
            this.gridPort.RefreshDataSource();
        }
        public override bool Save()
        {
            this.gvPort.CloseEditor();
            UseMoneyType type = this.gvPort.GetFocusedRow() as UseMoneyType;
            string msg = CheckData(type);
            if (!string.IsNullOrEmpty(msg))
            {
                XtraMessageBox.Show(msg + "，请填写后再保存。");
                return false;
            }

            var dataSource = (IEnumerable<UseMoneyType>)gridPort.DataSource;
            this.scm.ModifySystemConfig<IEnumerable<UseMoneyType>>(this.OptionName, dataSource);
            this.IsChanged = false;
            return true;
        } 
        private void gvPort_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            gvPort.SetColumnError(null, e.ErrorText);
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gvPort_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var data = e.Row as UseMoneyType;
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
            if (this.gvPort.FocusedRowHandle < 0)
            {
                gvPort.CloseEditor();
                gvPort.CancelUpdateCurrentRow();
                this.IsChanged = true;
            }
            else
            {
                gvPort.DeleteRow(gvPort.FocusedRowHandle);
            }
        }

        private void gvPort_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.IsChanged = true;
        }

        private string CheckData(UseMoneyType type) 
        {
            if (type == null)
            {
                return string.Empty;
            } 
            if (string.IsNullOrEmpty(type.Name))
            {
                return "名称不能为空";
            }
            return string.Empty;
        }
    }
}
