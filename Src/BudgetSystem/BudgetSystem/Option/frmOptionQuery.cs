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
        private Bll.SystemConfigManager scm = new Bll.SystemConfigManager();
        private ucOptionEditBase currentOptionEdit = null;
        private bool allowEdit = false;
        public frmOptionQuery()
        {
            InitializeComponent();
            this.Module = BusinessModules.OptionManagement;
            this.allowEdit = this.CheckPermission(OperateTypes.Save); 
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Save));
            this.ModelOperatePageName = "选项管理";
        }


        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {
            if (operate.Operate == OperateTypes.Save.ToString())
            {
                if (this.currentOptionEdit != null)
                {
                    bool result= this.currentOptionEdit.Save();
                    if (result == true)
                    {
                        XtraMessageBox.Show("保存成功");
                    }
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
            this.lbcType.Items.Clear();
            this.lbcType.Items.AddRange(names);
            this.lbcType.SelectedIndex = 0;
        }

        

       
        private void lbcType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.currentOptionEdit != null&& this.currentOptionEdit.IsDisposed==false)
            {
                if (this.currentOptionEdit.IsChanged == true)
                {
                    DialogResult result = XtraMessageBox.Show(string.Format("选项[{0}]的配置已修改，是否保存？", this.currentOptionEdit.OptionName), "提示", MessageBoxButtons.YesNo);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        bool saveResult = this.currentOptionEdit.Save();
                        if (saveResult == false)
                        {
                            this.lbcType.SelectedIndexChanged -= lbcType_SelectedIndexChanged;
                            this.lbcType.SelectedItem = this.currentOptionEdit.OptionName;
                            this.lbcType.SelectedIndexChanged += lbcType_SelectedIndexChanged;
                            return;
                        }
                    }
                }
                this.pnlOptionList.Controls.Remove(this.currentOptionEdit);
                this.currentOptionEdit.Dispose();
            }
            if (this.lbcType.SelectedItem == null)
            {
                return;
            }
            if (EnumSystemConfigNames.港口信息.ToString().Equals(this.lbcType.SelectedItem))
            {
                this.currentOptionEdit = new ucPortOptionEdit(); 
            }
            else if (EnumSystemConfigNames.国家地区.ToString().Equals(this.lbcType.SelectedItem))
            {
                this.currentOptionEdit = new ucCountryOptionEdit();
            }
            else if (EnumSystemConfigNames.增值税.ToString().Equals(this.lbcType.SelectedItem))
            {
                this.currentOptionEdit = new ucVATOptionEdit();
            }
            else if (EnumSystemConfigNames.币种.ToString().Equals(this.lbcType.SelectedItem))
            {
                this.currentOptionEdit = new ucMoneyTypeOptionEdit();
            }
            else if (EnumSystemConfigNames.用款类型.ToString().Equals(this.lbcType.SelectedItem))
            {
                this.currentOptionEdit = new ucUseMoneyTypeOptionEdit();
            }
            else
            {
                return;
            }
            this.currentOptionEdit.AllowEdit = this.allowEdit;
            this.currentOptionEdit.Dock = DockStyle.Fill;
            this.pnlOptionList.Controls.Add(this.currentOptionEdit);
            this.layoutControlGroupConfigValue.Text = this.currentOptionEdit.OptionName + "选项配置";
        }

    }
}
