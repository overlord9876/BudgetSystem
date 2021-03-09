using System;
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
    public partial class frmDeclarationformImport : frmBaseDialogForm
    {
        private Bll.CommonManager cm = new Bll.CommonManager();
        private Bll.BudgetManager bm = new Bll.BudgetManager();
        private Bll.DeclarationformManager dm = new Bll.DeclarationformManager();
        private DateTime datetimeNow = DateTime.MinValue;

        public frmDeclarationformImport()
        {
            InitializeComponent();
            datetimeNow = cm.GetDateTimeNow();
            RegisterEventHandler();
        }

        private void RegisterEventHandler()
        {
            this.Load += new System.EventHandler(this.frmDeclarationformImport_Load);
            this.btnExport.Click += BtnExport_Click;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);
            this.gvDeclarationform.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(gvDeclarationform_InvalidRowException);
            this.gvDeclarationform.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(gvDeclarationform_ValidateRow);
            this.repositoryItemHyperLinkEdit1.Click += new EventHandler(riLinkDelete_Click);
            this.repositoryItemHyperLinkEdit1.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(riLinkDelete_CustomDisplayText);
        }

        private bool ReadData()
        {
            if (openFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return false;
            }

            DevExpress.Utils.WaitDialogForm sdf = new DevExpress.Utils.WaitDialogForm("正在读取数据……");
            try
            {
                string message = string.Empty;
                List<string> columns = null;

                columns = new List<string> { "海关编号", "合同号", "出口日期", "境外收发货人企业名称英文", "监管方式", "指运港", "成交方式", "贸易国别地区", "商品编号", "商品名称", "规格型号", "成交数量", "成交计量单位", "单价", "总价", "币制", "最终目的国地区", "境内货源地", "离岸价", "美元离岸价", "人民币离岸价" };
                DataTable dt = ExcelHelper.ReadExcelToDataTable(openFileDialog1.FileName, out message, string.Empty, columns);
                if (!string.IsNullOrEmpty(message))
                {
                    sdf.Close();
                    XtraMessageBox.Show("读取数据出错：" + message);
                    return false;
                }
                List<Declarationform> list = new List<Declarationform>();
                Declarationform df = null;

                foreach (DataRow row in dt.Rows)
                {
                    df = new Declarationform();
                    df.NO = DataRowConvertHelper.GetStringValue(row, "海关编号").Trim();
                    df.ContractNO = DataRowConvertHelper.GetStringValue(row, "合同号").Trim();
                    df.ExportDate = DataRowConvertHelper.GetDateTimeValue(row, "出口日期");
                    df.Overseas = DataRowConvertHelper.GetStringValue(row, "境外收发货人企业名称英文").Trim();
                    df.TradeMode = DataRowConvertHelper.GetStringValue(row, "监管方式");
                    df.Port = DataRowConvertHelper.GetStringValue(row, "指运港").Trim();
                    df.Currency = DataRowConvertHelper.GetStringValue(row, "币制");
                    df.PriceClause = DataRowConvertHelper.GetStringValue(row, "成交方式");
                    df.Country = DataRowConvertHelper.GetStringValue(row, "贸易国别地区");
                    df.ProdNumber = DataRowConvertHelper.GetStringValue(row, "商品编号");
                    df.ProdName = DataRowConvertHelper.GetStringValue(row, "商品名称");
                    df.Model = DataRowConvertHelper.GetStringValue(row, "规格型号");
                    df.DealCount = DataRowConvertHelper.GetDoubleValue(row, "成交数量");
                    df.DealUnit = DataRowConvertHelper.GetStringValue(row, "成交计量单位");
                    df.Price = DataRowConvertHelper.GetDecimalValue(row, "单价");
                    df.TotalPrice = DataRowConvertHelper.GetDecimalValue(row, "总价");
                    df.FinalCountry = DataRowConvertHelper.GetStringValue(row, "最终目的国地区");
                    df.DomesticSource = DataRowConvertHelper.GetStringValue(row, "境内货源地");
                    df.OffshoreTotalPrice = DataRowConvertHelper.GetDecimalValue(row, "离岸价");
                    df.USDOffshoreTotalPrice = DataRowConvertHelper.GetDecimalValue(row, "美元离岸价");
                    df.CNYOffshoreTotalPrice = DataRowConvertHelper.GetDecimalValue(row, "人民币离岸价");
                    if (df.ExportDate == DateTime.MinValue)
                    {
                        df.Message = "出口时间不能为空。";
                    }
                    df.CreateUser = RunInfo.Instance.CurrentUser.UserName;
                    df.CreateDate = datetimeNow;
                    df.UpdateUser = RunInfo.Instance.CurrentUser.UserName;
                    df.UpdateDate = datetimeNow;
                    list.Add(df);
                }

                try
                {
                    dm.CheckImportData(list);
                    this.gcDeclarationform.DataSource = new BindingList<Declarationform>(list);
                    this.gcDeclarationform.RefreshDataSource();
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

        private void frmDeclarationformImport_Load(object sender, EventArgs e)
        {
            bool result = ReadData();
            if (!result)
            {
                this.Close();
            }
        }


        private void btnSure_Click(object sender, EventArgs e)
        {
            List<Declarationform> list = (gcDeclarationform.DataSource as BindingList<Declarationform>).ToList();
            if (list != null)
            {
                var warningList = list.Where(i => !string.IsNullOrEmpty(i.Message));
                if (warningList.Any() && !chkIgnore.Checked)
                {
                    XtraMessageBox.Show("存在不合法数据，不能导入");
                    return;
                }
                var importList = list.Where(i => string.IsNullOrEmpty(i.Message)).ToList();
                if (importList.Any())
                {
                    dm.ImportDeclarationform(importList);
                    int rowCount = importList.Count;
                    list.RemoveAll(i => string.IsNullOrEmpty(i.Message));
                    XtraMessageBox.Show($"成功导入{rowCount}条数据。");
                }
                gcDeclarationform.DataSource = new BindingList<Declarationform>(list);
                if (list.Any()) { return; }
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "选择保存路径";
            saveFileDialog1.Filter = "excel文件|*.xls";
            if (saveFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            this.gvDeclarationform.ExportToXls(saveFileDialog1.FileName);
            XtraMessageBox.Show("导出成功。");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void gvDeclarationform_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            gvDeclarationform.SetColumnError(this.gvDeclarationform.FocusedColumn, e.ErrorText);
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gvDeclarationform_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var df = e.Row as Declarationform;
            List<Declarationform> list = (gcDeclarationform.DataSource as BindingList<Declarationform>).ToList();

            if (string.IsNullOrEmpty(df.NO.Trim()))
            {
                e.ErrorText = "报关单号不能为空";
                df.Message = e.ErrorText;
                e.Valid = false;
                return;
            }
            else if (list.Count(i => i.NO == df.NO && df.DealCount == i.DealCount && df.TotalPrice == i.TotalPrice && df.Model == i.Model) > 1)
            {
                e.ErrorText = "报关单号存在重复";
                df.Message = e.ErrorText;
                e.Valid = false;
                return;
            }
            else if (dm.CheckNumber(df.NO, df.DealCount, df.TotalPrice, df.Model))
            {
                e.ErrorText = "报关单号存在重复";
                df.Message = e.ErrorText;
                e.Valid = false;
                return;
            }
            int budgetId = dm.CheckContractNO(df.ContractNO);
            if (budgetId < 0)
            {
                e.ErrorText = "合同号不存在";
                df.Message = e.ErrorText;
                e.Valid = false;
                return;
            }
            else
            {
                df.BudgetID = budgetId;
            }
            if (string.IsNullOrEmpty(df.Currency.Trim()))
            {
                e.ErrorText = "报关币种不能为空";
                df.Message = e.ErrorText;
                e.Valid = false;
                return;
            }
            //if (df.ExportAmount <= 0)
            //{
            //    e.ErrorText = "出口金额应大于0";
            //    df.Message = e.ErrorText;
            //    e.Valid = false;
            //    return;
            //}

        }



        private void riLinkDelete_Click(object sender, System.EventArgs e)
        {
            if (this.gvDeclarationform.FocusedRowHandle < 0)
            {
                gvDeclarationform.CloseEditor();
                gvDeclarationform.CancelUpdateCurrentRow();
            }
            else
            {
                gvDeclarationform.DeleteRow(gvDeclarationform.FocusedRowHandle);
            }
        }

        private void riLinkDelete_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = "删除";
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            this.gvDeclarationform.DeleteSelectedRows();
        }
    }
}