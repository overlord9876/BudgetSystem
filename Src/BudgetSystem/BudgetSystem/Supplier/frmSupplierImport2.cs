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
using System.IO;
using BudgetSystem.Bll;

namespace BudgetSystem
{
    public partial class frmSupplierImport2 : frmBaseDialogForm
    {
        private CommonManager cm = new CommonManager();
        private DateTime datetimeNow = DateTime.MinValue;
        private List<Department> departmentList;

        public frmSupplierImport2()
        {
            InitializeComponent();
            datetimeNow = cm.GetDateTimeNow();
        }

        private void frmSupplierImport2_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void InitData()
        {
            Bll.DepartmentManager dm = new Bll.DepartmentManager();
            this.departmentList = dm.GetAllDepartment();

            CommonControl.LookUpEditHelper.FillRepositoryItemLookUpEditByEnum_IntValue(this.rilueSupplierType, typeof(EnumSupplierType));
        }

        private bool ReadData()
        {
            DevExpress.Utils.WaitDialogForm sdf = new DevExpress.Utils.WaitDialogForm("正在读取数据……");
            List<Supplier> list = new List<Supplier>();
            try
            {
                string message = string.Empty;
                //"是否合格供应商",
                List<string> columns = new List<string> { "供方名称", "所属部门", "企业性质", "法人代表", "业务强项" };
                DataTable dt = ExcelHelper.ReadExcelToDataTable(this.btnFileName.Text, out message, cboSheet.SelectedItem.ToString(), columns);
                if (!string.IsNullOrEmpty(message))
                {
                    sdf.Close();
                    XtraMessageBox.Show("读取数据出错：" + message);
                    return false;
                }
                List<User> users = new Bll.UserManager().GetAllUser();
                Supplier supplier = null;
                string userName = string.Empty;
                foreach (DataRow row in dt.Rows)
                {
                    supplier = new Supplier(datetimeNow);
                    supplier.Name = DataRowConvertHelper.GetStringValue(row, "供方名称").Trim();
                    if (string.IsNullOrEmpty(supplier.Name))
                    {
                        break;
                    }
                    supplier.Nature = DataRowConvertHelper.GetStringValue(row, "企业性质").Trim();
                    string departmentStr = DataRowConvertHelper.GetStringValue(row, "所属部门").Trim();
                    supplier.Legal = DataRowConvertHelper.GetStringValue(row, "法人代表").Trim();
                    supplier.DepartmentCode = departmentStr;
                    supplier.Description = DataRowConvertHelper.GetStringValue(row, "业务强项").Trim();
                    if (string.IsNullOrEmpty(departmentStr) && departmentStr.Length > 3)
                    {
                        Department department = departmentList.FirstOrDefault(o => o.Code == departmentStr.Substring(0, 3));
                        if (department != null)
                        {
                            supplier.Departments.Add(department);
                        }
                    }
                    list.Add(supplier);
                }
                this.gridSupplier.DataSource = new BindingList<Supplier>(list);
                this.gridSupplier.RefreshDataSource();
                sdf.Close();
                return true;
            }
            catch (Exception ex)
            {
                sdf.Close();
                XtraMessageBox.Show("读取数据出错：" + ex.Message);
                return false;
            }
        }
        private void btnRead_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.btnFileName.Text))
            {
                XtraMessageBox.Show("请选择数据文件");
                return;
            }
            if (!File.Exists(this.btnFileName.Text))
            {
                XtraMessageBox.Show("数据文件不存在");
                return;
            }
            if (this.cboSheet.SelectedItem == null)
            {
                XtraMessageBox.Show("请选择数据Sheet");
                return;
            }

            this.ReadData();
        }

        Bll.SupplierManager sm = new Bll.SupplierManager();
        private void Import(bool isContinue = false)
        {
            if (gridSupplier.DataSource == null)
            {
                XtraMessageBox.Show("请先读取数据");
                return;
            }
            List<Supplier> list = (gridSupplier.DataSource as BindingList<Supplier>).ToList();
            if (list != null)
            {
                try
                {
                    for (int index = list.Count - 1; index >= 0; index--)
                    {
                        Supplier supplier = list[index];
                        bool exists = sm.CheckExistsByName(supplier.Name);
                        if (!exists)
                        {
                            continue;
                            //supplier.Name = string.Format("不存在名称:{0}", supplier.Name);
                        }
                        sm.ModifySupplierByName(supplier);
                        list.RemoveAt(index);

                    }
                    if (isContinue)
                    {
                        this.gridSupplier.DataSource = null;
                        this.gridSupplier.RefreshDataSource();
                    }
                    else
                    {
                        this.gridSupplier.DataSource = list;
                        this.gridSupplier.RefreshDataSource();
                        //DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("导入出错：" + ex.Message);
                }
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            Import(true);
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            Import();
        }

        private void btnFileName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileName = this.openFileDialog.FileName;
                string message = string.Empty;
                List<string> sheetNames = ExcelHelper.GetEexelSheetNames(fileName, out  message);
                if (!string.IsNullOrEmpty(message))
                {
                    XtraMessageBox.Show(message);
                    this.cboSheet.Properties.Items.Clear();
                    return;
                }
                this.btnFileName.Text = this.openFileDialog.FileName;
                this.cboSheet.Properties.Items.AddRange(sheetNames);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "选择保存路径";
            dialog.Filter = "excel文件|*.xls";
            if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                gridSupplier.ExportToXls(dialog.FileName);
            }
        }




    }
}