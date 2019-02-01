using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;
using BudgetSystem.Entity;
using DevExpress.Utils;

namespace BudgetSystem.Base
{
    public partial class frmBaseCommonReportForm : frmBaseQueryForm
    {
        public frmBaseCommonReportForm()
        {
            InitializeComponent();
            InitData();
        }

        private void frmBaseCommonReportForm_Load(object sender, EventArgs e)
        {

        }


        protected bool supportPivotGrid = true;
        protected bool supportPivotGridSaveView = true;


        protected Dictionary<string, Action> GridToolBarActions = new Dictionary<string, Action>();
        protected Dictionary<string, Action> PrivotToolBarActions = new Dictionary<string, Action>();



        protected virtual void InitData()
        {

        }

        protected void InitShowStyle()
        {
            if (!supportPivotGrid)
            {
                this.lcgPivote.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            if (supportPivotGrid && !supportPivotGridSaveView)
            {
                this.lcList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.splitterItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.btnSaveView.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.btnDeleteView.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.btnShowOrVisible.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }

            if (supportPivotGrid && supportPivotGridSaveView)
            {
                this.LoadReportConfig();
            }


            foreach (var kv in GridToolBarActions)
            {
                DevExpress.XtraBars.BarItem item = new DevExpress.XtraBars.BarButtonItem(this.barManager1, kv.Key);
                this.gridViewBar.AddItem(item);
                item.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(GridBarItem_ItemClick);
            }


            foreach (var kv in PrivotToolBarActions)
            {
                DevExpress.XtraBars.BarItem item = new DevExpress.XtraBars.BarButtonItem(this.barManager1, kv.Key);
                this.pivotViewBar.AddItem(item);
                item.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(PrivotBarItem_ItemClick);
            }

            if (GetBarShowState(this.gridViewBar))
            {
                this.lcGridBar.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            if (GetBarShowState(this.pivotViewBar))
            {
                this.lcStatBar.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

        }



        private bool GetBarShowState(Bar bar)
        {
            bool isBarEmpty = true;


            foreach (DevExpress.XtraBars.BarItemLink item in bar.ItemLinks)
            {
                if (item.Visible)
                {
                    isBarEmpty = false;
                    break;
                }
            }
            return isBarEmpty;
        }

        void PrivotBarItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string key = e.Item.Caption;
            Action action = this.PrivotToolBarActions[key];
            action.Invoke();
        }

        void GridBarItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string key = e.Item.Caption;
            Action action = this.GridToolBarActions[key];
            action.Invoke();

        }

        protected void ClearColumns()
        {
            i = 0;
            gridView.Columns.Clear();
            this.pivotGridControl.Fields.Clear();
        }

        int i;
        protected GridColumn CreateGridColumn(string caption, string fieldName, int width = 0)
        {
            GridColumn gc = new GridColumn();
            gc.Name = caption;
            gc.Caption = caption;
            gc.FieldName = fieldName;
            if (width > 0)
            {
                gc.Width = width;
            }
            gc.Visible = true;
            gc.VisibleIndex = i++;
            this.gridView.Columns.Add(gc);
            return gc;
        }


        protected PivotGridField CreatePivotGridField(string caption, string fieldName, PivotArea area = PivotArea.FilterArea, FormatType valueFormatType = FormatType.None, string valueFormatString = "")
        {
            PivotGridField field = new PivotGridField(fieldName, area);
            field.Name = caption;
            field.Caption = caption;
            field.ValueFormat.FormatType = valueFormatType;
            field.ValueFormat.FormatString = valueFormatString;
            this.pivotGridControl.Fields.Add(field);

            return field;
        }

        protected PivotGridField CreatePivotGridDefaultRowField(PivotArea area = PivotArea.FilterArea)
        {
            PivotGridField field = new PivotGridField();
            field.Caption = "计数";
            field.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            field.UnboundFieldName = "CC";
            field.UnboundExpression = "1";
            field.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridControl.Fields.Add(field);

            return field;
        }

        private void btnShowOrVisible_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.lcList.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Never)
            {
                this.lcList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.splitterItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                this.lcList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.splitterItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void btnSaveView_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmInput inputForm = new frmInput("请输入", "请输入视图名称：");
            if (inputForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (this.reportConfigs.Exists(s => s.Name == inputForm.Result.Trim()))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("视图名称已存在，请使用其它名称");
                    return;
                }

                string fileName = Guid.NewGuid().ToString("N") + ".xml";
                string layoutName = GetReportFileFile(fileName);
                this.pivotGridControl.SaveLayoutToXml(layoutName);

                ReportConfig rc = new ReportConfig() { Name = inputForm.Result.Trim(), FileName = fileName };
                this.reportConfigs.Add(rc);
                SaveReportConfig();
                LoadReportConfig();
            }



        }
        private void btnDeleteView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportConfig rc = this.listBox.SelectedItem as ReportConfig;
            if (rc != null)
            {
                try
                {
                    this.reportConfigs.Remove(rc);
                    System.IO.File.Delete(GetReportFileFile(rc.FileName));
                    this.SaveReportConfig();
                    this.LoadReportConfig();
                }
                catch
                {

                }

            }

        }

        private string reportName = "";
        protected string ReportName
        {
            get
            {
                if (string.IsNullOrEmpty(reportName.Trim()))
                {
                    return this.Text;
                }
                else
                {
                    return this.reportName;
                }
            }
            set
            {
                this.reportName = value;
            }

        }


        List<ReportConfig> reportConfigs;



        private string GetReportFileFile(string name)
        {
            string fileName = System.IO.Path.Combine(Environment.CurrentDirectory, "Report");
            if (!System.IO.Directory.Exists(fileName))
            {
                System.IO.Directory.CreateDirectory(fileName);
            }

            fileName = System.IO.Path.Combine(fileName, name);
            return fileName;
        }

        private void LoadReportConfig()
        {
            this.listBox.Items.Clear();
            string fileName = GetReportFileFile(this.ReportName + ".json");

            if (System.IO.File.Exists(fileName))
            {
                try
                {
                    string json = System.IO.File.ReadAllText(fileName, Encoding.UTF8);
                    reportConfigs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ReportConfig>>(json);
                    if (reportConfigs != null)
                    {
                        foreach (ReportConfig rc in reportConfigs)
                        {
                            this.listBox.Items.Add(rc);
                        }
                    }
                }
                catch
                {

                }
            }

            if (reportConfigs == null)
            {
                reportConfigs = new List<ReportConfig>();
            }


        }

        private void SaveReportConfig()
        {
            string fileName = GetReportFileFile(this.ReportName + ".json");
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(reportConfigs);
                System.IO.File.WriteAllText(fileName, json, Encoding.UTF8);
            }
            catch
            {

            }
        }

        private void listBox_DoubleClick(object sender, EventArgs e)
        {
            ReportConfig rc = this.listBox.SelectedItem as ReportConfig;

            if (rc != null)
            {
                try
                {
                    this.pivotGridControl.RestoreLayoutFromXml(GetReportFileFile(rc.FileName));
                    LoadData();
                }
                catch
                {

                }



            }



        }


    }
}
