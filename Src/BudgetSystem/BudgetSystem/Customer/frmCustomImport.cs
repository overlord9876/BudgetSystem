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

namespace BudgetSystem
{
    public partial class frmCustomImport : frmBaseDialogForm
    {
        public frmCustomImport()
        {
            InitializeComponent();
        }

        private void frmCustomImport_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void InitData()
        {
            Bll.DepartmentManager dm = new Bll.DepartmentManager();
            List<Department> departmentList = dm.GetAllDepartment();
            this.cboDepartment.Properties.Items.AddRange(departmentList);

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
                List<string> columns = new List<string> { "供应商名称", "纳税人识别号", "供应商类型", "工商登记日期", "经营截至日期", "存在合格供方代理", "是否失信企业", "代理协议有效期", "创建时间", "创建人", "备注" };
                DataTable dt = ExcelHelper.ReadExcelToDataTable(this.btnFileName.Text, out message, cboSheet.SelectedItem.ToString(), columns);
                if (!string.IsNullOrEmpty(message))
                {
                    sdf.Close();
                    XtraMessageBox.Show("读取数据出错：" + message);
                    return false;
                }
                List<User> users = new Bll.UserManager().GetAllUser();
                Supplier supplier = null;
                User user = null;
                Department department = this.cboDepartment.SelectedItem as Department;
                string userName = string.Empty;
                foreach (DataRow row in dt.Rows)
                {
                    supplier = new Supplier();
                    supplier.Name = DataRowConvertHelper.GetStringValue(row, "供应商名称").Trim();
                    if (string.IsNullOrEmpty(supplier.Name))
                    {
                        break;
                    }
                    supplier.TaxpayerID = DataRowConvertHelper.GetStringValue(row, "纳税人识别号").Trim();
                    supplier.SupplierType = (int)DataRowConvertHelper.GetEnumValue<EnumSupplierType>(row, "供应商类型");
                    supplier.RegistrationDate = DataRowConvertHelper.GetDateTimeValue_AllowNull(row, "工商登记日期", "\"");
                    supplier.BusinessEffectiveDate = DataRowConvertHelper.GetDateTimeValue_AllowNull(row, "经营截至日期", "\"");
                    supplier.ExistsAgentAgreement = "代理".Equals(DataRowConvertHelper.GetStringValue(row, "存在合格供方代理").Trim()) ? true : false;
                    supplier.Discredited = "是".Equals(DataRowConvertHelper.GetStringValue(row, "是否失信企业").Trim()) ? true : false;
                    supplier.AgreementDate = DataRowConvertHelper.GetDateTimeValue_AllowNull(row, "代理协议有效期");
                    supplier.CreateDate = DataRowConvertHelper.GetDateTimeValue(row, "创建时间", "\"");
                    userName = DataRowConvertHelper.GetStringValue(row, "创建人").Trim();
                    user = users.FirstOrDefault(u => u.RealName == userName);
                    supplier.CreateUser = user.UserName;
                    supplier.CreateUserName = userName;
                    supplier.Description = DataRowConvertHelper.GetStringValue(row, "备注").Trim();
                    supplier.DeptID = department.ID;
                    //银行信息暂用默认
                    supplier.BankInfoDetail = "[{\"Name\":\"中国银行\",\"Account\":\"\"}]";
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
            if (this.cboDepartment.SelectedItem == null)
            {
                XtraMessageBox.Show("请选择所属部门");
                return;
            }
            this.ReadData();
        }
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
                    Bll.SupplierManager sm = new Bll.SupplierManager();
                    foreach (Supplier supplier in list)
                    {
                        sm.AddSupplier(supplier);
                    }
                    if (isContinue)
                    {
                        this.gridSupplier.DataSource =null;
                        this.gridSupplier.RefreshDataSource();
                    }
                    else
                    {
                        DialogResult = System.Windows.Forms.DialogResult.OK;
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





    }
}