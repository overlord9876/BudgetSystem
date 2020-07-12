﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;
using BudgetSystem.Util;

namespace BudgetSystem.InMoney
{
    public partial class frmInvoiceImport : frmBaseDialogForm
    {
        private bool isFinanceImport = false;
        private string fileName = string.Empty;
        private DateTime datetimeNow;
        private Bll.CommonManager cm = new Bll.CommonManager();
        private Bll.InvoiceManager im = new Bll.InvoiceManager();
        private Bll.BudgetManager bm = new Bll.BudgetManager();

        public frmInvoiceImport(string fileName, bool isFinanceImport = false)
        {
            InitializeComponent();
            this.fileName = fileName;
            this.isFinanceImport = isFinanceImport;
        }

        private void frmInvoiceImport_Load(object sender, EventArgs e)
        {
            if (this.isFinanceImport == true)
            {
                this.Text = "财务导入交单信息";
                this.gvInvoice.Columns.Remove(gcContractNO);
                this.gvInvoice.Columns.Remove(gcOriginalCoin);
                this.gvInvoice.Columns.Remove(gcExchangeRate);
                this.gvInvoice.Columns.Remove(gcCustomsDeclaration);
                this.gvInvoice.Columns.Remove(gcTaxRebateRate);
                this.gvInvoice.Columns.Remove(gcCommission);
                this.gvInvoice.Columns.Remove(gcFeedMoney);
            }
            else
            {
                this.Text = "部门导入交单信息";
                this.gvInvoice.Columns.Remove(gcCode);
                this.gvInvoice.Columns.Remove(gcTaxpayerID);
                this.gvInvoice.Columns.Remove(gcSupplierName);
                this.gvInvoice.Columns.Remove(gcPayment);
                this.gvInvoice.Columns.Remove(gcTaxAmount);
            }
            bool result = ReadData();
            if (!result)
            {
                this.Close();
            }
        }
        private bool ReadData()
        {
            DevExpress.Utils.WaitDialogForm sdf = new DevExpress.Utils.WaitDialogForm("正在读取数据……");
            try
            {
                string message = string.Empty;
                List<string> columns = null;
                if (isFinanceImport)
                {
                    columns = new List<string> { "发票代码", "发票号码", "销方税号", "销方名称", "金额", "税额" };
                }
                else
                {
                    columns = new List<string> { "合同号", "原币", "汇率", "报关单", "发票号", "退税率", "佣金", "进料款" };
                }
                DataTable dt = ExcelHelper.ReadExcelToDataTable(this.fileName, out message, string.Empty, columns);
                if (!string.IsNullOrEmpty(message))
                {
                    sdf.Close();
                    XtraMessageBox.Show("读取数据出错：" + message);
                    return false;
                }
                List<Invoice> list = new List<Invoice>();
                Invoice invoice = null;
                if (isFinanceImport)
                {
                    datetimeNow = cm.GetDateTimeNow();
                    foreach (DataRow row in dt.Rows)
                    {
                        invoice = new Invoice();
                        invoice.Code = DataRowConvertHelper.GetStringValue(row, "发票代码").Trim();
                        invoice.Number = DataRowConvertHelper.GetStringValue(row, "发票号码").Trim();
                        invoice.TaxpayerID = DataRowConvertHelper.GetStringValue(row, "销方税号").Trim();
                        invoice.SupplierName = DataRowConvertHelper.GetStringValue(row, "销方名称").Trim();
                        invoice.Payment = DataRowConvertHelper.GetDecimalValue(row, "金额");
                        invoice.TaxAmount = DataRowConvertHelper.GetDecimalValue(row, "税额");
                        invoice.FinanceImportUser = RunInfo.Instance.CurrentUser.UserName;
                        invoice.FinanceImportDate = datetimeNow;
                        list.Add(invoice);
                    }
                }
                else
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        invoice = new Invoice();
                        invoice.ContractNO = DataRowConvertHelper.GetStringValue(row, "合同号").Trim();
                        invoice.OriginalCoin = DataRowConvertHelper.GetDecimalValue(row, "原币");
                        invoice.ExchangeRate = DataRowConvertHelper.GetDecimalValue(row, "汇率");
                        invoice.CustomsDeclaration = DataRowConvertHelper.GetStringValue(row, "报关单").Trim();
                        invoice.Number = DataRowConvertHelper.GetStringValue(row, "发票号").Trim();
                        if (!string.IsNullOrEmpty(invoice.Number))
                        {
                            DataRow[] rows = dt.Select(string.Format("发票号='{0}'", invoice.Number));
                            if (rows.Length > 1)
                            {
                                invoice.Message = string.Format("发票号在当前表格存在{0}个重复号", rows.Length);
                            }
                        }
                        invoice.TaxRebateRate = DataRowConvertHelper.GetFloatValue(row, "退税率");
                        invoice.Commission = DataRowConvertHelper.GetDecimalValue(row, "佣金");
                        invoice.FeedMoney = DataRowConvertHelper.GetDecimalValue(row, "进料款");
                        invoice.ImportUser = RunInfo.Instance.CurrentUser.UserName;
                        list.Add(invoice);
                    }
                }
                try
                {
                    sdf.Caption = "正在验证数据……";
                    bool result = im.CheckImportData(list, isFinanceImport);
                    this.gridInvoice.DataSource = new BindingList<Invoice>(list);
                    this.gridInvoice.RefreshDataSource();
                    sdf.Close();
                }
                catch (Exception ex)
                {
                    sdf.Close();
                    XtraMessageBox.Show("验证数据时出错：" + ex.Message);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                sdf.Close();
                XtraMessageBox.Show("读取数据出错：" + ex.Message);
                return false;
            }
        }
        private void btnSure_Click(object sender, EventArgs e)
        {
            List<Invoice> list = (gridInvoice.DataSource as BindingList<Invoice>).ToList();
            if (list != null)
            {
                if (list.Exists(i => !string.IsNullOrEmpty(i.Message)))
                {
                    XtraMessageBox.Show("存在不合法数据，不能导入");
                    return;
                }
                bool result = im.ImportData(list.ToList<Invoice>(), isFinanceImport);
                if (result)
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }

        private void gvInvoice_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            gvInvoice.SetColumnError(null, e.ErrorText);
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gvInvoice_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var invoice = e.Row as Invoice;
            List<Invoice> list = (gridInvoice.DataSource as BindingList<Invoice>).ToList();
            if (isFinanceImport)
            {
                if (string.IsNullOrEmpty(invoice.Number.Trim()))
                {
                    e.ErrorText = "发票号不能为空";
                    e.Valid = false;
                    return;
                }
                else if (list.Count(i => i.Number == invoice.Number) > 1)
                {
                    e.ErrorText = "发票号存在重复";
                    e.Valid = false;
                    return;
                }
                else if (!im.CheckNumber(0, invoice.Number.Trim()))
                {
                    e.ErrorText = "发票号不存在";
                    e.Valid = false;
                    return;
                }
                if (string.IsNullOrEmpty(invoice.Code.Trim()))
                {
                    e.ErrorText = "发票代码不能为空";
                    e.Valid = false;
                    return;
                }
                if (string.IsNullOrEmpty(invoice.TaxpayerID.Trim()))
                {
                    e.ErrorText = "销方税号不能为空";
                    e.Valid = false;
                    return;
                }
                if (string.IsNullOrEmpty(invoice.SupplierName.Trim()))
                {
                    e.ErrorText = "销方名称不能为空";
                    e.Valid = false;
                    return;
                }
                //if (invoice.Payment <= 0)
                //{
                //    e.ErrorText = "金额应大于0";
                //    e.Valid = false;
                //    return;
                //}
                //if (invoice.TaxAmount < 0)
                //{
                //    e.ErrorText = "税额应大于等于0";
                //    e.Valid = false;
                //    return;
                //}
            }
            else
            {
                if (string.IsNullOrEmpty(invoice.ContractNO.Trim()))
                {
                    e.ErrorText = "合同号不能为空";
                    e.Valid = false;
                    return;
                }
                else
                {
                    int budgetId = bm.CheckContractNO(invoice.ContractNO.Trim());
                    if (budgetId < 0)
                    {
                        e.ErrorText = "合同号不存在;";
                        e.Valid = false;
                        return;
                    }
                    else
                    {
                        invoice.BudgetID = budgetId;
                    }
                }
                int repeatCount = 0;
                if (list != null && !string.IsNullOrEmpty(invoice.Number.Trim()))
                {
                    repeatCount = list.Count(o => o.Number == invoice.Number);
                }
                if (string.IsNullOrEmpty(invoice.Number.Trim()))
                {
                    e.ErrorText = "发票号不能为空;";
                    e.Valid = false;
                    return;
                }
                else if (repeatCount > 1)
                {
                    e.ErrorText = string.Format("发票号当前表格存在{0}个重复号", repeatCount);
                    e.Valid = false;
                    return;
                }
                else if (im.CheckNumber(0, invoice.Number))
                {
                    e.ErrorText = "发票号已存在;";
                    e.Valid = false;
                    return;
                }
                if (invoice.ExchangeRate <= 0)
                {
                    e.ErrorText = "汇率应大于0";
                    e.Valid = false;
                    return;
                }
                if (string.IsNullOrEmpty(invoice.CustomsDeclaration.Trim()))
                {
                    e.ErrorText = "报关单不能为空";
                    e.Valid = false;
                    return;
                }
                if (invoice.TaxRebateRate < 0)
                {
                    e.ErrorText = "退税率应大于等于0";
                    e.Valid = false;
                    return;
                }
                //if (invoice.Commission < 0)
                //{
                //    e.ErrorText = "佣金应大于等于0";
                //    e.Valid = false;
                //    return;
                //}
                //if (invoice.FeedMoney < 0)
                //{
                //    e.ErrorText = "进料款应大于等于0";
                //    e.Valid = false;
                //    return;
                //}
            }
            invoice.Message = string.Empty;
        }



        private void riLinkDelete_Click(object sender, System.EventArgs e)
        {
            if (this.gvInvoice.FocusedRowHandle < 0)
            {
                gvInvoice.CloseEditor();
                gvInvoice.CancelUpdateCurrentRow();
            }
            else
            {
                gvInvoice.DeleteRow(gvInvoice.FocusedRowHandle);
            }
        }

        private void riLinkDelete_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = "删除";
        }



    }
}