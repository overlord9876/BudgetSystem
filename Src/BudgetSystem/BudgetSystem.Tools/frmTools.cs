using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BudgetSystem.Entity;
using BudgetSystem.Bll;
using System.Configuration;
using BudgetSystem.Tools.Properties;

namespace BudgetSystem.Tools
{
    public partial class frmTools : Form
    {
        public frmTools()
        {
            InitializeComponent();

            this.Icon = Resources.logo;       
        }

        private void frmTools_Load(object sender, EventArgs e)
        {
            SystemConfigManager sm = new SystemConfigManager();
            SystemInfo si = sm.GetSystemConfigValue<Entity.SystemInfo>("SystemInfo");
            if (si != null)
            {
                this.labSystemInfo.Text = si.ToString();
            }
            else
            {
                this.labSystemInfo.Text = "获取失败";
            }
        }

        private void btnCreateDBConnectionString_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connection"].ToString();
            string ss = Util.DES.Encrypt(connectionString);
            frmMessage.ShowMessage(ss);
        }

        private void btnPublishVersion_Click(object sender, EventArgs e)
        {
            frmVersionPublisher form = new frmVersionPublisher();
            form.ShowDialog();
        }
    }
}
