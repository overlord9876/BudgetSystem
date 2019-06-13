using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using BudgetSystem.Entity;
using DevExpress.XtraPivotGrid;
using DevExpress.Utils;
using BudgetSystem.Entity.QueryCondition;
using System.IO;

namespace BudgetSystem.Report
{
    public partial class frmCapitalReport : Base.frmBaseCommonReportForm
    {
        public frmCapitalReport()
        {
            InitializeComponent();
            this.Module = BusinessModules.RecieptCapital;
        }

        protected override void InitLayout()
        {
            base.InitModelOperate();
        }

        protected override void InitModelOperate()
        {
            this.supportPivotGrid = true;
            this.supportPivotGridSaveView = true;
        }

        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {
            base.OperateHandled(operate, e);
        }

        private void frmBudgetReport_Load(object sender, EventArgs e)
        {
            InitShowStyle();
        }

        const string DepartmentCaption = "部门";
        private Dictionary<string, string> dic = new Dictionary<string, string>();

        protected override void LoadDataByCondition(BudgetQueryCondition condition)
        {
            Bll.ReportManager um = new Bll.ReportManager();

            base.ClearColumns();

            decimal exchangeRate = um.GetAverageUSDExchange(condition);
            if (exchangeRate == 0) { return; }
            var lst = um.GetRecieptCapital(condition);

            DataTable dt = new DataTable();
            if (!dic.ContainsKey(DepartmentCaption))
            {
                dic.Add(DepartmentCaption, "departmentCode");
            }
            dt.Columns.Add(dic[DepartmentCaption], typeof(string));

            base.CreateGridColumn(DepartmentCaption, dic[DepartmentCaption]);
            base.CreatePivotGridField(DepartmentCaption, dic[DepartmentCaption]);
            for (int index = 0; index < lst.Count; index++)
            {
                RecieptCapital rc = lst[index];

                rc.OriginalCoin = Math.Round(rc.CNY / exchangeRate, 2);
                if (!dic.ContainsKey(rc.BankCode))
                {
                    dic.Add(rc.BankCode, string.Format("code{0}", index));
                }

                if (!dt.Columns.Contains(dic[rc.BankCode]))
                {
                    base.CreateGridColumn(rc.BankCode, dic[rc.BankCode]);
                    base.CreatePivotGridField(rc.BankCode, dic[rc.BankCode], valueFormatType: FormatType.Custom, formatProvider: new MyDollarFormat());
                    dt.Columns.Add(dic[rc.BankCode], typeof(decimal));
                }
            }

            base.CreatePivotGridDefaultRowField();

            foreach (RecieptCapital rc in lst)
            {
                DataRow[] rows = dt.Select(string.Format("{0}='{1}'", dic[DepartmentCaption], rc.Department));
                if (rows != null && rows.Length > 0)
                {
                    decimal money = 0;
                    if (!(rows[0][dic[rc.BankCode]] is System.DBNull))
                    {
                        money = (decimal)rows[0][dic[rc.BankCode]];
                    }
                    rows[0][dic[rc.BankCode]] = money + rc.OriginalCoin;
                }
                else
                {
                    DataRow newRow = dt.NewRow();
                    newRow[dic[DepartmentCaption]] = rc.Department;
                    newRow[dic[rc.BankCode]] = rc.OriginalCoin;
                    dt.Rows.Add(newRow);
                }
            }
            string defaultFileName = base.GetDefaultLayoutXmlFile();
            if (File.Exists(defaultFileName))
            {
                this.pivotGridControl.RestoreLayoutFromXml(defaultFileName);
            }

            this.pivotGridControl.DataSource = dt;
            this.gridControl.DataSource = dt;
        }
    }
}
