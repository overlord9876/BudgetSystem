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

namespace BudgetSystem
{
    public partial class frmFinancialArchiveApplyImport : frmBaseDialogForm
    {
        public List<Budget> BudgetList { get; private set; }

        private Bll.BudgetManager bm = new Bll.BudgetManager();

        public frmFinancialArchiveApplyImport()
        {
            InitializeComponent();
            RegisterEventHandler();
        }

        private void RegisterEventHandler()
        {
            this.Load += new System.EventHandler(this.frmFinancialArchiveApplyImport_Load);
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);
            this.gvBudgetList.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(gvBudgetList_InvalidRowException);
            this.gvBudgetList.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(gvBudgetList_ValidateRow);
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

                columns = new List<string> { "合同号" };
                DataTable dt = ExcelHelper.ReadExcelToDataTable(openFileDialog1.FileName, out message, string.Empty, columns);
                if (!string.IsNullOrEmpty(message))
                {
                    sdf.Close();
                    XtraMessageBox.Show("读取数据出错：" + message);
                    return false;
                }
                try
                {
                    BudgetList = new List<Budget>();
                    foreach (DataRow row in dt.Rows)
                    {
                        string contractNo = DataRowConvertHelper.GetStringValue(row, "合同号").Trim();
                        if (contractNo.Length < 12)
                        {
                            continue;
                        }
                        string contractNoNew = contractNo.Substring(0, 12);
                        Budget b = bm.GetBudgetByNo(contractNoNew);
                        if (b == null)
                        {
                            b = new Budget();
                            b.ContractNO = contractNo;
                            b.Message = "合同号不存在";
                        }
                        else if (b.EnumState != EnumBudgetState.进行中 && b.EnumState != EnumBudgetState.驳回归档征求)
                        {
                            b.Message = string.Format("{0}状态的预算单不允许财务归档征求。", b.EnumState);
                        }
                        else if (!EnumFlowNames.预算单审批流程.ToString().Equals(b.FlowName) || b.EnumFlowState != EnumDataFlowState.审批通过)
                        {
                            b.Message = string.Format("预算单当前不满足{0}且审批状态为{1}，不能进行当前操作。", EnumFlowNames.预算单审批流程, EnumDataFlowState.审批通过);
                        }
                        BudgetList.Add(b);
                    }
                    this.gcBudgetList.DataSource = new BindingList<Budget>(BudgetList);
                    this.gcBudgetList.RefreshDataSource();
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

        private void frmFinancialArchiveApplyImport_Load(object sender, EventArgs e)
        {
            bool result = ReadData();
            if (!result)
            {
                this.Close();
            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            List<Budget> list = (gcBudgetList.DataSource as BindingList<Budget>).ToList();
            if (list != null)
            {
                if (list.Exists(i => !string.IsNullOrEmpty(i.Message)))
                {
                    XtraMessageBox.Show("存在不合法数据，不能导入");
                    return;
                }
                foreach (var budget in list)
                {
                    bm.ModifyBudgetState(budget.ID, EnumBudgetState.财务归档征求);
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void gvBudgetList_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            gvBudgetList.SetColumnError(this.gvBudgetList.FocusedColumn, e.ErrorText);
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gvBudgetList_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var df = e.Row as Budget;
            List<Budget> list = (gcBudgetList.DataSource as BindingList<Budget>).ToList();

            if (string.IsNullOrEmpty(df.ContractNO.Trim()))
            {
                e.ErrorText = "合同编号不能为空";
                df.Message = e.ErrorText;
                e.Valid = false;
                return;
            }
            else if (df.ContractNO.Length < 12)
            {
                e.ErrorText = "合同编号不能少于12位字符";
                df.Message = e.ErrorText;
                e.Valid = false;
                return;
            }
            else if (list.Count(i => i.ContractNO == df.ContractNO) > 1)
            {
                e.ErrorText = "合同编号存在重复";
                df.Message = e.ErrorText;
                e.Valid = false;
                return;
            }
            string contractNoNew = df.ContractNO.Substring(0, 12);
            var budget = bm.GetBudgetByNo(contractNoNew);
            if (budget == null)
            {
                e.ErrorText = "合同编号不存在";
                df.Message = e.ErrorText;
                e.Valid = false;
                return;
            }
            else if (budget.EnumState != EnumBudgetState.进行中 && budget.EnumState != EnumBudgetState.驳回归档征求)
            {
                e.ErrorText = string.Format("{0}状态的预算单不允许财务归档征求。", budget.EnumState);
                df.Message = e.ErrorText;
                e.Valid = false;
                return;
            }
            else if (!EnumFlowNames.预算单审批流程.ToString().Equals(budget.FlowName) || budget.EnumFlowState != EnumDataFlowState.审批通过)
            {
                e.ErrorText = string.Format("预算单当前不满足{0}且审批状态为{1}，不能进行当前操作。", EnumFlowNames.预算单审批流程, EnumDataFlowState.审批通过);
                df.Message = e.ErrorText;
                e.Valid = false;
                return;
            }
            df.Message = string.Empty;
            df.ID = budget.ID;
            df.State = budget.State;
        }

        private void riLinkDelete_Click(object sender, System.EventArgs e)
        {
            if (this.gvBudgetList.FocusedRowHandle < 0)
            {
                gvBudgetList.CloseEditor();
                gvBudgetList.CancelUpdateCurrentRow();
            }
            else
            {
                gvBudgetList.DeleteRow(gvBudgetList.FocusedRowHandle);
            }
        }

        private void riLinkDelete_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = "删除";
        }



    }
}