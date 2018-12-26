using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BudgetSystem.Entity;
using DevExpress.XtraEditors;
using BudgetSystem.Deploy.Properties;

namespace BudgetSystem.Deploy
{
    public partial class frmVersionUpdate : XtraForm
    {
        public frmVersionUpdate()
        {
            InitializeComponent();

            this.Icon = Resources.logo;
        }


        public bool IsSuccess
        {
            get;
            set;
        }

        private void frmVersionUpdate_Load(object sender, EventArgs e)
        {
            this.labInfo.Text = NewSystemInfo.ToString();


        }


        public SystemInfo NewSystemInfo
        {
            get;
            set;
        }

        public void DoUpdate()
        {
            System.Threading.Thread t = new System.Threading.Thread(DoUpdateByThread);
            t.IsBackground = true;
            t.Start();
        }

        public void DoUpdateByThread()
        {


            try
            {
                Bll.VersionInfoManager vm = new Bll.VersionInfoManager();
                Bll.FileManager fm = new Bll.FileManager();

                List<VersionFile> files = vm.GetVersionFiles(NewSystemInfo.Version);


                this.progressBarControl.Properties.Maximum = files.Count;


                for (int i = 0; i < files.Count; i++)
                {
                    VersionFile vf = files[i];

                    string[] folderNames = vf.FilePath.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                    string fileName = ConstData.BudgetSystemRootPath;
                    foreach (string folderName in folderNames)
                    {
                        if (!string.IsNullOrEmpty(folderName))
                        {
                            fileName = System.IO.Path.Combine(fileName, folderName);
                        }
                    }

                    if (!System.IO.Directory.Exists(fileName))
                    {
                        System.IO.Directory.CreateDirectory(fileName);
                    }

                    fileName = System.IO.Path.Combine(fileName, vf.FileName);

                    bool needUpdate = IfCheckFileNeedUpdate(fileName, vf.FileMD5);


                    if (needUpdate || true)
                    {
                        FileData data = fm.GetFile(vf.FileMD5);
                        System.IO.File.WriteAllBytes(fileName, data.Data);
                    }


                    this.progressBarControl.EditValue = i + 1;
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("更新失败！/r/n" + ex.Message);

                throw;
            }




            this.IsSuccess = true;
            this.Close();
        }

        private bool IfCheckFileNeedUpdate(string fileName, string md5)
        {
            if (!System.IO.File.Exists(fileName))
            {
                return true;
            }

            string existMd5 = Util.MD5.GetMD5HashFromFile(fileName);

            if (existMd5 != md5)
            {
                return true;
            }

            return false;
        }



    }
}
