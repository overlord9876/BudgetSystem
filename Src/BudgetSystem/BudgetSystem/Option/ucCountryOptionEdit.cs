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
    /// 国家地区配置界面
    /// </summary>
    public partial class ucCountryOptionEdit : ucOptionEditBase
    {
        public ucCountryOptionEdit():base()
        {
            InitializeComponent();
            this.OptionName = EnumSystemConfigNames.国家地区.ToString(); 
        }

        protected override void RegisterEvent()
        {
            this.gvCountry.CellValueChanged += gvCountry_CellValueChanged;
            this.gvCountry.ValidateRow += gvCountry_ValidateRow;
            this.gvCountry.InvalidRowException += gvCountry_InvalidRowException;
            this.riHyperLinkEditDelete.Click += riHyperLinkEditDelete_Click;
            this.riHyperLinkEditDelete.CustomDisplayText += riHyperLinkEditDelete_CustomDisplayText;
        }
        protected override void BindingOption()
        {
            if (!AllowEdit)
            {
                this.gvCountry.Columns.Remove(this.gcDelete);
                this.gcEnName.OptionsColumn.AllowEdit = false;
                this.gcName.OptionsColumn.AllowEdit = false;
                this.gcCode.OptionsColumn.AllowEdit = false;
                this.gvCountry.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            }
            List<Country> countryList = this.scm.GetSystemConfigValue<List<Country>>(this.OptionName);
            if (countryList == null)
            {
                countryList = new List<Country>();
            }
            BindingList<Country> dataSource = new BindingList<Country>(countryList);
            this.gridCountry.DataSource = dataSource;
            this.gridCountry.RefreshDataSource();
        }
        public override bool Save()
        {
            this.gvCountry.CloseEditor();
            Country country = this.gvCountry.GetFocusedRow() as Country;
            string msg = CheckData(country);
            if (!string.IsNullOrEmpty(msg))
            {
                XtraMessageBox.Show(msg+"，请填写后再保存。");
                return false;
            }
            var dataSource = (IEnumerable<Country>)gridCountry.DataSource;
            this.scm.ModifySystemConfig<IEnumerable<Country>>(this.OptionName, dataSource);
            this.IsChanged = false;
            return true;
        } 
        private void gvCountry_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            gvCountry.SetColumnError(null, e.ErrorText);
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gvCountry_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var data = e.Row as Country;
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
            if (this.gvCountry.FocusedRowHandle < 0)
            {
                gvCountry.CloseEditor();
                gvCountry.CancelUpdateCurrentRow();
                this.IsChanged = true;
            }
            else
            {
                gvCountry.DeleteRow(gvCountry.FocusedRowHandle);
            }
        }

        private void gvCountry_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.IsChanged = true; 
        }

        private string CheckData(Country country)
        {
            if (country == null)
            {
                return string.Empty;
            }
            if (string.IsNullOrEmpty(country.Code))
            {
               return "编码不能为空"; 
            }
            if (string.IsNullOrEmpty(country.Name))
            {
                return "名称不能为空"; 
            }
            if (string.IsNullOrEmpty(country.EnName))
            {
                return  "英文名称不能为空"; 
            }
            return string.Empty;
        }

       
    }
}
