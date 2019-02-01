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
        private Bll.BudgetManager bm = new Bll.BudgetManager();
        private Bll.DeclarationformManager dm = new Bll.DeclarationformManager();

        public frmDeclarationformImport()
        {
            InitializeComponent();
            RegisterEventHandler();
        }

        private void RegisterEventHandler()
        {
            this.Load += new System.EventHandler(this.frmDeclarationformImport_Load);
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);
            this.gvDeclarationform.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(gvDeclarationform_InvalidRowException);
            this.gvDeclarationform.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(gvDeclarationform_ValidateRow);
            this.riLinkDelete.Click += new EventHandler(riLinkDelete_Click);
            this.riLinkDelete.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(riLinkDelete_CustomDisplayText);
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

                columns = new List<string> { "合同号", "报关单号", "报关币种", "出口金额", "出口日期", "是否已报告延期收款" };
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
                    df.ContractNO = DataRowConvertHelper.GetStringValue(row, "合同号").Trim();
                    df.NO = DataRowConvertHelper.GetStringValue(row, "报关单号").Trim();
                    df.Currency = DataRowConvertHelper.GetStringValue(row, "报关币种").Trim();
                    df.ExportAmount = DataRowConvertHelper.GetDecimalValue(row, "出口金额");
                    df.ExportDate = DataRowConvertHelper.GetDateTimeValue(row, "出口日期");
                    df.IsReport = DataRowConvertHelper.GetStringValue(row, "是否已报告延期收款") == "是";
                    df.CreateUser = RunInfo.Instance.CurrentUser.UserName;
                    df.CreateDate = DateTime.Now;
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
                if (list.Exists(i => !string.IsNullOrEmpty(i.Message)))
                {
                    XtraMessageBox.Show("存在不合法数据，不能导入");
                    return;
                }
                dm.ImportDeclarationform(list);
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
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
            else if (list.Count(i => i.NO == df.NO) > 1)
            {
                e.ErrorText = "报关单号存在重复";
                df.Message = e.ErrorText;
                e.Valid = false;
                return;
            }
            else if (dm.CheckNumber(df.NO))
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
            if (df.ExportAmount <= 0)
            {
                e.ErrorText = "出口金额应大于0";
                df.Message = e.ErrorText;
                e.Valid = false;
                return;
            }

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



    }
}