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
    public partial class frmSupplierImport : frmBaseDialogForm
    {
        public frmSupplierImport()
        {
            InitializeComponent();
        }

        private void frmInvoiceImport_Load(object sender, EventArgs e)
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
                List<string> columns = new List<string> { "供应商名称", "法人代表", "是否有营业执照复印件", "纳税人识别号", "供应商类型", "工商登记日期", "经营截至日期", "存在合格供方代理", "是否失信企业", "代理协议有效期", "创建时间", "创建人", "备注" };
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
                    if (row["供应商类型"] != null && row["供应商类型"] != DBNull.Value && !string.IsNullOrEmpty(row["供应商类型"].ToString()))
                    {
                        supplier.SupplierType = (int)DataRowConvertHelper.GetEnumValue<EnumSupplierType>(row, "供应商类型");
                    }
                    else
                    {
                        supplier.SupplierType = 1;
                    }
                    supplier.Legal = DataRowConvertHelper.GetStringValue(row, "法人代表").Trim();

                    supplier.ExistsLicenseCopy = "是".Equals(DataRowConvertHelper.GetStringValue(row, "是否有营业执照复印件").Trim()) ? true : false; ;

                    supplier.RegistrationDate = DataRowConvertHelper.GetDateTimeValue_AllowNull(row, "工商登记日期", "\"");
                    supplier.BusinessEffectiveDate = DataRowConvertHelper.GetDateTimeValue_AllowNull(row, "经营截至日期", "\"");
                    if (row["存在合格供方代理"] != null && row["存在合格供方代理"] != DBNull.Value && !string.IsNullOrEmpty(row["存在合格供方代理"].ToString()))
                    {
                        supplier.AgentType = (int)DataRowConvertHelper.GetEnumValue<EnumAgentType>(row, "存在合格供方代理");
                    }
                    else
                    {
                        supplier.AgentType = (int)EnumAgentType.无;
                    }
                    supplier.Discredited = "是".Equals(DataRowConvertHelper.GetStringValue(row, "是否失信企业").Trim()) ? true : false;
                    supplier.AgreementDate = DataRowConvertHelper.GetDateTimeValue_AllowNull(row, "代理协议有效期");

                    supplier.CreateDate = DataRowConvertHelper.GetDateTimeValue(row, "创建时间", "\"");
                    if (supplier.CreateDate <= DateTime.MinValue)
                    {
                        supplier.CreateDate = DateTime.Now;
                    }
                    userName = DataRowConvertHelper.GetStringValue(row, "创建人").Trim();
                    user = users.FirstOrDefault(u => u.RealName == userName);
                    if (user != null)
                    {
                        supplier.CreateUser = user.UserName;
                        supplier.CreateUserName = userName;
                    }
                    else
                    {
                        supplier.CreateUser = department.Manager;
                        supplier.CreateUserName = department.ManagerName;
                    }
                    supplier.UpdateUser = supplier.CreateUser;
                    supplier.UpdateUserName = supplier.CreateUserName;
                    if (supplier.SupplierType == (int)EnumSupplierType.合格供方)
                    {
                        supplier.FirstReviewContents = "{\"ReviewItems\":{\"交付\":1,\"服务\":1,\"价格\":1,\"技术力量\":1,\"生产设备\":1,\"产品质量\":1,\"质量管理体系\":1,\"社会责任表现\":1,\"社会责任承诺\":1},\"Result\":1,\"Salesman\":\"" + supplier.CreateUserName + "\",\"SalesmanResult\":1,\"Manager\":null,\"ManagerResult\":0,\"Leader\":null,\"LeaderResult\":0,\"ResultDate\":null}";
                    }
                    supplier.Description = DataRowConvertHelper.GetStringValue(row, "备注").Trim();
                    supplier.Departments.Add(department);
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
                        supplier.ID = sm.AddSupplier(supplier);
                        if (supplier.SupplierType == 0)
                        {
                            string message = sm.StartFlow(EnumFlowNames.供应商审批流程, supplier.ID, supplier.CreateUser);
                            if (!string.IsNullOrEmpty(message))
                            {
                                //TODO启动流程失败
                            }
                        }
                    }
                    if (isContinue)
                    {
                        this.gridSupplier.DataSource = null;
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