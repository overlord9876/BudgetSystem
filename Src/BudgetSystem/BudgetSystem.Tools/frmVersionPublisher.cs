using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BudgetSystem.Entity;

namespace BudgetSystem.Tools
{
    public partial class frmVersionPublisher : Form
    {
        public frmVersionPublisher()
        {
            InitializeComponent();
        }

        private string rootPath;

        private FileInfo[] upFiles;

        private void btnAddFile_Click(object sender, EventArgs e)
        {


            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.gridView.Rows.Clear();

                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(fd.SelectedPath);

                FileInfo[] files = di.GetFiles("*.*", System.IO.SearchOption.AllDirectories);
                rootPath = fd.SelectedPath;
                upFiles = files;
                foreach (FileInfo file in files)
                {
                    string path = file.DirectoryName.Replace(fd.SelectedPath, "");
                    if (string.IsNullOrEmpty(path))
                    {
                        path = "\\";
                    }

                    this.gridView.Rows.Add(file.Name, path);
                }


            }
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {

            Bll.FileManager fileBll = new Bll.FileManager();
            Bll.VersionInfoManager versionBll = new Bll.VersionInfoManager();

            SystemInfo si = new SystemInfo() { Version = this.txtVersion.Text.Trim(), Remark = this.txtRemark.Text.Trim(), PublishDate = DateTime.Now };


            if (string.IsNullOrEmpty(si.Version))
            {
                MessageBox.Show("请输入版本号");
                return;
            }

            if (this.gridView.Rows.Count == 0)
            {
                MessageBox.Show("请选择版本文件");
                return;
            }

            if (versionBll.VersionExist(si.Version))
            {
                MessageBox.Show("此版本已使用过了，请使用其它版本号");
                return;
            }

            List<VersionFile> vfs = new List<VersionFile>();
            foreach (FileInfo fi in upFiles)
            {
                string md5 = Util.MD5.GetMD5HashFromFile(fi.FullName);
                bool exist = fileBll.FileExist(md5);
                if (!exist)
                {
                    FileData file = new FileData() { MD5 = md5 };
                    file.ReadFile(fi.FullName);
                    fileBll.AddFile(file);

                }

                string path = fi.DirectoryName.Replace(rootPath, "");
                VersionFile vf = new VersionFile() { FileName = fi.Name, FilePath = path, FileMD5 = md5, Version = si.Version };
                vfs.Add(vf);
            }
            versionBll.AddVersion(si, vfs);

            MessageBox.Show("发布完成");
        }
    }
}
