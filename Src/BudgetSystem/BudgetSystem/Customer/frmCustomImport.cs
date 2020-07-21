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
    public partial class frmCustomImport : frmBaseDialogForm
    {
        private CommonManager cm = new CommonManager();
        private DateTime datetimeNow = DateTime.MinValue;

        public frmCustomImport()
        {
            InitializeComponent();
            datetimeNow = cm.GetDateTimeNow();
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
        }

        private bool ReadData()
        {
            DevExpress.Utils.WaitDialogForm sdf = new DevExpress.Utils.WaitDialogForm("正在读取数据……");
            List<Customer> list = new List<Customer>();
            try
            {
                string message = string.Empty;
                //"是否合格供应商",
                List<string> columns = new List<string> { "编号", "客户名称", "国家或地区", "港口", "可用状态", "创建人", "创建时间" };
                DataTable dt = ExcelHelper.ReadExcelToDataTable(this.btnFileName.Text, out message, cboSheet.SelectedItem.ToString(), columns, 2);
                if (!string.IsNullOrEmpty(message))
                {
                    sdf.Close();
                    XtraMessageBox.Show("读取数据出错：" + message);
                    return false;
                }
                List<User> users = new Bll.UserManager().GetAllUser();
                Customer Customer = null;
                Department department = this.cboDepartment.SelectedItem as Department;
                User user = null;
                string userName = string.Empty;
                foreach (DataRow row in dt.Rows)
                {
                    Customer = new Customer();
                    Customer.Code = DataRowConvertHelper.GetStringValue(row, "编号").Trim();
                    if (string.IsNullOrEmpty(Customer.Code))
                    {
                        break;
                    }
                    Customer.Name = DataRowConvertHelper.GetStringValue(row, "客户名称").Trim().Replace("                               ", " ");
                    if (string.IsNullOrEmpty(Customer.Name))
                    {
                        break;
                    }
                    Customer.Country = DataRowConvertHelper.GetStringValue(row, "国家或地区");
                    Customer.Port = DataRowConvertHelper.GetStringValue(row, "港口");
                    Customer.State = DataRowConvertHelper.GetStringValue(row, "可用状态") == "√";
                    userName = DataRowConvertHelper.GetStringValue(row, "创建人").Trim();
                    string[] userNameArray = userName.Split(new char[] { '，', '/' });
                    if (userNameArray.Length > 0)
                    {
                        user = users.FirstOrDefault(u => u.RealName == userNameArray[0].Trim());
                    }
                    else
                    {
                        user = null;
                    }
                    if (user == null)
                    {
                        Customer.CreateUser = department.Manager;
                        Customer.CreateUserName = department.ManagerName;
                    }
                    else
                    {
                        Customer.CreateUser = user.UserName;
                        Customer.CreateUserName = userName;
                    }

                    Customer.SalesmanList = new List<CustomerSalesman>();
                    Customer.SalesmanList.Add(new CustomerSalesman() { Salesman = Customer.CreateUser });//salesmans;
                    if (userNameArray.Length > 1)
                    {
                        Customer.SalesmanList.Clear();
                        foreach (string salesName in userNameArray)
                        {
                            var salesMan = users.FirstOrDefault(u => u.RealName == salesName.Trim());
                            if (salesMan != null)
                            {
                                Customer.SalesmanList.Add(new CustomerSalesman() { Salesman = salesMan.UserName });//salesmans;
                            }
                        }
                    }
                    Customer.CreateDate = DataRowConvertHelper.GetDateTimeValue(row, "创建时间", "\"");
                    if (Customer.CreateDate <= DateTime.MinValue)
                    {
                        Customer.CreateDate = datetimeNow;
                    }
                    list.Add(Customer);
                }
                this.gridCustomer.DataSource = new BindingList<Customer>(list);
                this.gridCustomer.RefreshDataSource();
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
            if (gridCustomer.DataSource == null)
            {
                XtraMessageBox.Show("请先读取数据");
                return;
            }
            List<Customer> list = (gridCustomer.DataSource as BindingList<Customer>).ToList();
            if (list != null)
            {
                try
                {
                    Department department = this.cboDepartment.SelectedItem as Department;
                    Bll.UserManager um = new Bll.UserManager();
                    Bll.CustomerManager sm = new Bll.CustomerManager();
                    List<Customer> customers = sm.GetAllCustomer();
                    //List<CustomerSalesman> salesmans = new List<CustomerSalesman>();
                    //var users = um.GetDepartmentUsers(department.ID);
                    //if (users != null && users.Count > 0)
                    //{
                    //users.ForEach(u => salesmans.Add(new CustomerSalesman() { Salesman = u.UserName }));
                    //}
                    Customer oldCustomer = null;
                    foreach (Customer customer in list)
                    {
                        try
                        {
                            oldCustomer = customers.FirstOrDefault(c => c.Code == customer.Code && c.Name == customer.Name);
                            if (oldCustomer != null)
                            {
                                oldCustomer.SalesmanList = customer.SalesmanList;
                                oldCustomer.Country = customer.Country;
                                oldCustomer.Port = customer.Port;
                                oldCustomer.State = customer.State;
                                sm.ModifyCustomer(oldCustomer);
                            }
                            else
                            {
                                sm.AddCustomer(customer);
                            }
                        }
                        catch (Exception ex)
                        {
                            RunInfo.Instance.Logger.LogInfomation(ex.ToString()); 
                            //XtraMessageBox.Show(ex.Message);
                        }
                    }
                    if (isContinue)
                    {
                        this.gridCustomer.DataSource = null;
                        this.gridCustomer.RefreshDataSource();
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