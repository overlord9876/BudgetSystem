﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
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
        private Bll.PaymentNotesManager pnm = new Bll.PaymentNotesManager();

        public ucUseMoneyTypeOptionEdit()
            : base()
        {
            InitializeComponent();
            this.OptionName = EnumSystemConfigNames.用款类型.ToString();

            this.cboType.Items.AddRange(Enum.GetNames(typeof(PaymentType)).Select(o => o.Trim()).ToList());
        }

        protected override void RegisterEvent()
        {
            this.gvPort.CellValueChanged += gvPort_CellValueChanged;
            this.gvPort.ValidateRow += gvPort_ValidateRow;
            this.gvPort.InvalidRowException += gvPort_InvalidRowException;
            this.gvPort.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gvPort_FocusedRowChanged);
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
            if (this.gvPort.HasColumnErrors) { return false; }
            if (this.gvPort.FocusedRowHandle >= 0)
            {
                UseMoneyType type = this.gvPort.GetRow(this.gvPort.FocusedRowHandle) as UseMoneyType;
                string msg = CheckData(type);
                if (!string.IsNullOrEmpty(msg))
                {
                    XtraMessageBox.Show(msg + "，请填写后再保存。");
                    return false;
                }
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
                UseMoneyType umt = gvPort.GetRow(gvPort.FocusedRowHandle) as UseMoneyType;
                if (umt == null || pnm.ExistsPaymentMoneyUsed(umt.Name))
                {
                    XtraMessageBox.Show("名称已经被使用，不允许删除");
                    gvPort.CloseEditor();
                    gvPort.CancelUpdateCurrentRow();
                    this.IsChanged = true;
                }
                else
                {
                    gvPort.DeleteRow(gvPort.FocusedRowHandle);
                }
            }
        }

        private void gvPort_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.IsChanged = true;
        }

        private void gvPort_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            UseMoneyType umt = gvPort.GetRow(e.FocusedRowHandle) as UseMoneyType;
            if (umt != null && pnm.ExistsPaymentMoneyUsed(umt.Name))
            {
                gvPort.OptionsBehavior.Editable = false;
            }
            else
            {
                gvPort.OptionsBehavior.Editable = true;
            }
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
            var source = (IEnumerable<UseMoneyType>)gridPort.DataSource;
            if (source != null && source.Where(o => o != type).Any(o => o.Name == type.Name))
            {
                return "名称不允许重复";
            }
            return string.Empty;
        }
    }
}
