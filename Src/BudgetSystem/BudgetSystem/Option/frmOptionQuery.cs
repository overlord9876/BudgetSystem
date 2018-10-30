using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;

namespace BudgetSystem
{
    public partial class frmOptionQuery : frmBaseQueryForm
    {
        private bool isChanged = false;
        private Bll.SystenConfigManager scm = new Bll.SystenConfigManager();
        public frmOptionQuery()
        {
            InitializeComponent();
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Save));
            this.ModelOperatePageName = "选项管理";
        }


        public override void OperateHandled(ModelOperate operate)
        {
            if (operate.Operate == OperateTypes.Save.ToString())
            {
                if (this.treeListSystemConfigNames.FocusedNode != null)
                {
                    Save(this.treeListSystemConfigNames.FocusedNode.GetDisplayText(0));
                }
            }
            else
            {
                XtraMessageBox.Show("未定义的操作");
            }
        }

        public override void LoadData()
        {
            string[] names = Enum.GetNames(typeof(EnumSystemConfigNames));
            this.treeListSystemConfigNames.Nodes.Clear();
            foreach (string name in names)
            {
                treeListSystemConfigNames.AppendNode(new object[] { name }, null, name);
            }
            treeListSystemConfigNames.FocusedNode = treeListSystemConfigNames.Nodes[0];
        }

        private void LoadConfigData(string configName)
        {
            DataTable dt = scm.GetSystemConfigValue(configName);
            if (dt != null)
            {
                this.isChanged = false;
                this.gvSystemConfig.CellValueChanged -= gvSystemConfig_CellValueChanged;
                //TODO:这里暂只处理3列及以下列，后续如果需要可以改为自动生成列
                for (int i = 0; i < 3 && i < dt.Columns.Count; i++)
                {
                    this.gvSystemConfig.Columns[i].Visible = true;
                    this.gvSystemConfig.Columns[i].Caption = dt.Columns[i].ColumnName;
                    this.gvSystemConfig.Columns[i].FieldName = dt.Columns[i].ColumnName;
                }
                for (int i = dt.Columns.Count; i < 3; i++)
                {
                    this.gvSystemConfig.Columns[i].Visible = false;
                }
                this.gridSystemConfig.DataSource = dt;
                this.gvSystemConfig.RefreshData();
                this.gvSystemConfig.CellValueChanged += gvSystemConfig_CellValueChanged;
            }
        }
        private void Save(string configName)
        {
            this.gvSystemConfig.CloseEditor();
            DataTable dt = this.gridSystemConfig.DataSource as DataTable;
            scm.ModifySupplier(configName, dt);
            this.isChanged = false;
            XtraMessageBox.Show("保存成功");
        }

        private void gvSystemConfig_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            gvSystemConfig.SetColumnError(null, e.ErrorText);
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gvSystemConfig_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var data = e.Row as DataRowView;
            int nullValueCount=0;
            int columnCount=data.Row.Table.Columns.Count;
            for(int i=0;i<columnCount;i++)
            {
                if (data.Row.IsNull(i) || string.IsNullOrEmpty(data.Row[i].ToString()))
                {
                    nullValueCount++;
                }
            }
            if (columnCount == nullValueCount)
            {
                e.ErrorText = "选项配置只少有一列不能为空";
                e.Valid = false;
                return;
            } 
        }

        private void riHyperLinkEditDelete_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = "删除";
        }

        private void riHyperLinkEditDelete_Click(object sender, EventArgs e)
        {
            if (this.gvSystemConfig.FocusedRowHandle < 0)
            {
                gvSystemConfig.CancelUpdateCurrentRow();
                this.isChanged = true;
            }
            else
            {
                gvSystemConfig.DeleteRow(gvSystemConfig.FocusedRowHandle);
            }
        }

        private void gvSystemConfig_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.isChanged = true;
        }

        private void treeListSystemConfigNames_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (this.isChanged)
            {
                string name = e.OldNode.GetDisplayText(0);
                DialogResult result = XtraMessageBox.Show(string.Format("选项[{0}]的配置已修改，是否保存？", e.OldNode.GetDisplayText(0)), "提示", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    Save(name);
                }
            }
            
            if (e.Node != null)
            {
                string configName = e.Node.GetDisplayText(0);
                this.LoadConfigData(configName);
                layoutControlGroupConfigValue.Text = configName+"选项配置";
            }
        }

    }
}
