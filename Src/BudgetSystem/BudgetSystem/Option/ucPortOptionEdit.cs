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
    /// 港口信息配置界面
    /// </summary>
    public partial class ucPortOptionEdit : ucOptionEditBase
    {
        public ucPortOptionEdit()
            : base()
        {
            InitializeComponent();
            this.OptionName = EnumSystemConfigNames.港口信息.ToString(); 
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
                this.gcEnName.OptionsColumn.AllowEdit = false;
                this.gcName.OptionsColumn.AllowEdit = false;
                this.gvPort.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            }
            List<Port> portList = this.scm.GetSystemConfigValue<List<Port>>(this.OptionName);
            if (portList == null)
            {
                portList = new List<Port>();
            }
            BindingList<Port> dataSource = new BindingList<Port>(portList);
            this.gridPort.DataSource = dataSource;
            this.gridPort.RefreshDataSource();
        }
        public override bool Save()
        {
            this.gvPort.CloseEditor();
            Port port = this.gvPort.GetFocusedRow() as Port;
            string msg = CheckData(port);
            if (!string.IsNullOrEmpty(msg))
            {
                XtraMessageBox.Show(msg + "，请填写后再保存。");
                return false;
            }
           
            var dataSource = (IEnumerable<Port>)gridPort.DataSource;
            this.scm.ModifySystemConfig<IEnumerable<Port>>(this.OptionName, dataSource);
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
            var data = e.Row as Port;
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

        private string CheckData(Port port) 
        {
            if (port == null)
            {
                return string.Empty;
            } 
            if (string.IsNullOrEmpty(port.Name))
            {
                return "名称不能为空";
            }
            if (string.IsNullOrEmpty(port.EnName))
            {
                return "英文名称不能为空";
            }
            return string.Empty;
        }
    }
}
