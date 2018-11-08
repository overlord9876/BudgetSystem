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
    /// 币种配置界面
    /// </summary>
    public partial class ucMoneyTypeOptionEdit : ucOptionEditBase
    {
        public ucMoneyTypeOptionEdit()
            : base()
        {
            InitializeComponent();
            this.OptionName = EnumSystemConfigNames.币种.ToString(); 
        }

        protected override void RegisterEvent()
        {
            this.gvMoneyType.CellValueChanged += gvMoneyType_CellValueChanged;
            this.gvMoneyType.ValidateRow += gvMoneyType_ValidateRow;
            this.gvMoneyType.InvalidRowException += gvMoneyType_InvalidRowException;
            this.riHyperLinkEditDelete.Click += riHyperLinkEditDelete_Click;
            this.riHyperLinkEditDelete.CustomDisplayText += riHyperLinkEditDelete_CustomDisplayText;
        }
        protected override void BindingOption()
        {
            List<MoneyType> typeList = this.scm.GetSystemConfigValue<List<MoneyType>>(this.OptionName);
            if (typeList == null)
            {
                typeList = new List<MoneyType>();
            }
            BindingList<MoneyType> dataSource = new BindingList<MoneyType>(typeList);
            this.gridMoneyType.DataSource = dataSource;
            this.gridMoneyType.RefreshDataSource();
        }
        public override bool Save()
        {
            this.gvMoneyType.CloseEditor();
            MoneyType data = this.gvMoneyType.GetFocusedRow() as MoneyType;
            string msg = CheckData(data);
            if (!string.IsNullOrEmpty(msg))
            {
                XtraMessageBox.Show(msg + "，请填写后再保存。");
                return false;
            }

            var dataSource = (IEnumerable<MoneyType>)gridMoneyType.DataSource;
            this.scm.ModifySupplier<IEnumerable<MoneyType>>(this.OptionName, dataSource);
            this.IsChanged = false;
            return true;
        } 
        private void gvMoneyType_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            gvMoneyType.SetColumnError(null, e.ErrorText);
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gvMoneyType_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var data = e.Row as MoneyType;
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
            if (this.gvMoneyType.FocusedRowHandle < 0)
            {
                gvMoneyType.CancelUpdateCurrentRow();
                this.IsChanged = true;
            }
            else
            {
                gvMoneyType.DeleteRow(gvMoneyType.FocusedRowHandle);
            }
        }

        private void gvMoneyType_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.IsChanged = true;
        }

        private string CheckData(MoneyType data)
        { 
            if (data == null)
            {
                return string.Empty;
            }
            if (string.IsNullOrEmpty(data.Name))
            {
                return "名称不能为空";
            }
            return string.Empty;
        }
    }
}
