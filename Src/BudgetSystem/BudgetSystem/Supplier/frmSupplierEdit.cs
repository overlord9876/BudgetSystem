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
    public partial class frmSupplierEdit : frmBaseDialogForm
    {
        public Supplier Supplier
        {
            get;
            set;
        }
        private Bll.SupplierManager sm = new Bll.SupplierManager();
        private Bll.DepartmentManager dm = new Bll.DepartmentManager();
        public frmSupplierEdit()
        {
            InitializeComponent();
        }

        private void frmSupplierEdit_Load(object sender, EventArgs e)
        { 
            this.cboSupplierType.Properties.Items.Add("合格供方");
            this.cboSupplierType.Properties.Items.Add("临时供方");
            this.cboSupplierType.Properties.Items.Add("货运供方");
            this.cboSupplierType.SelectedIndex = 1;

            this.cboNature.Properties.Items.Add("有限责任公司"); 
            this.cboNature.Properties.Items.Add("股份有限责任公司");
            this.cboNature.Properties.Items.Add("个人独资企业");
            this.cboNature.Properties.Items.Add("合伙企业");
            this.cboNature.Properties.Items.Add("其它");
            this.cboNature.SelectedIndex = 0;

            List<Department> departmentList = dm.GetAllDepartment();
            this.cboDepartment.Properties.Items.AddRange(departmentList);

             // this.layoutControl1.RestoreLayoutFromStream(this.GetResourceFileByCurrentWorkModel());
            if (this.WorkModel == EditFormWorkModels.New)
            {
                this.Text = "创建供应商";
                this.lcCreateDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.lcCreateUser.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else if (this.WorkModel == EditFormWorkModels.Modify)
            { 
                this.Text = "编辑供应商信息"; 
                BindingSupplier(Supplier.ID); 
            }
            else if (this.WorkModel == EditFormWorkModels.View)
            {
                this.Text = "查看供应商信息";
                this.txtName.Properties.ReadOnly=true; 
                this.txtTaxpayerID.Properties.ReadOnly=true;  
                this.txtBankName.Properties.ReadOnly=true;
                this.txtBankNO.Properties.ReadOnly = true;
                this.txtLegal.Properties.ReadOnly = true;
                this.cboSupplierType.Properties.ReadOnly = true;
                this.cboNature.Properties.ReadOnly = true;
                this.txtRegisterCapital.Properties.ReadOnly = true;
                this.txtTaxpayerID.Properties.ReadOnly = true;
                this.txtPostalCode.Properties.ReadOnly = true;
                this.txtAddress.Properties.ReadOnly = true;
                this.txtTell.Properties.ReadOnly = true;
                this.txtContacts.Properties.ReadOnly = true;
                this.txtFaxNumber.Properties.ReadOnly = true;
                this.txtContacts.Properties.ReadOnly = true;
                this.txtCreateUser.Properties.ReadOnly = true;
                this.txtCreateDate.Properties.ReadOnly = true;
                this.meDescription.Properties.ReadOnly = true;
                this.cboDepartment.Properties.ReadOnly = true;
                this.chkDiscredited.Properties.ReadOnly = true;
                this.chkExistsAgentAgreement.Properties.ReadOnly = true;
                BindingSupplier(Supplier.ID); 
            }
        }
        private void btnSure_Click(object sender, EventArgs e)
        {
            SubmitDataByWorkModel();
        }


        private void BindingSupplier(int id) 
        {
            Supplier supplier = sm.GetSupplier(id);
            if (supplier != null)
            {
                this.txtName.Text = supplier.Name;
                this.txtTaxpayerID.Text = supplier.TaxpayerID;
                this.txtBankName.Text = supplier.BankName;
                this.txtBankNO.Text = supplier.BankNO;
                this.txtLegal.Text = supplier.Legal;
                this.cboSupplierType.SelectedIndex = supplier.SupplierType;
                this.cboNature.Text = supplier.Nature;
                this.txtRegisterCapital.EditValue = supplier.RegisterCapital;
                this.txtPostalCode.Text = supplier.PostalCode;
                this.txtAddress.Text = supplier.Address;
                this.txtTell.Text=supplier.Tell;
                this.txtContacts.Text = supplier.Contacts;
                this.txtFaxNumber.Text = supplier.FaxNumber;
                this.txtContacts.Text = supplier.Contacts;
                this.txtCreateUser.Text = supplier.CreateUserName;
                this.txtCreateDate.EditValue = supplier.CreateDate;
                this.meDescription.Text = supplier.Description;
                this.chkDiscredited.Checked = supplier.Discredited;
                this.chkExistsAgentAgreement.Checked = supplier.ExistsAgentAgreement;
                foreach (Department department in this.cboDepartment.Properties.Items)
                {
                    if (department.Code == supplier.DepartmentCode) 
                    {
                        this.cboDepartment.SelectedItem = department;
                        break;
                    }
                } 
            }
        }

        #region Check
        private void CheckNameInput()
        {
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtName, "请输入名称");
            }
        }
        private void CheckAddressInput()
        {
            if (string.IsNullOrEmpty(this.txtAddress.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtAddress, "请输入地址");
            }
        }
        private void CheckTellInput()
        {
            if (string.IsNullOrEmpty(this.txtTell.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtTell, "请输入联系电话");
            }
        }
        private void CheckContactsInput()
        {
            if (string.IsNullOrEmpty(this.txtContacts.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtContacts, "请输入联系人");
            }
        }
        private void CheckLegalInput()
        {
            if (string.IsNullOrEmpty(this.txtLegal.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtLegal, "请输入法人代表");
            }
        }
        private void CheckDepartmentInput()
        {
            if (string.IsNullOrEmpty(this.cboDepartment.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.cboDepartment, "请选择所属部门");
            }
        }

        private void CheckSupplierTypeInput()
        {
            if (string.IsNullOrEmpty(this.cboSupplierType.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.cboSupplierType, "请选择类型");
            }
        }
        private void CheckTaxpayerIDInput()
        {
            if (string.IsNullOrEmpty(this.txtTaxpayerID.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtTaxpayerID, "请输入纳税人识别号");
            }
        }
        #endregion

        protected override void SubmitNewData()
        {
            base.SubmitNewData();

            this.dxErrorProvider1.ClearErrors();
            this.CheckNameInput();
            this.CheckAddressInput();
            this.CheckContactsInput();
            this.CheckDepartmentInput();
            this.CheckTellInput();
            this.CheckLegalInput();
            this.CheckSupplierTypeInput();
            this.CheckTaxpayerIDInput();
            if (dxErrorProvider1.HasErrors)
            {
                return;
            }
            Supplier supplier = new Entity.Supplier();
            supplier.Name=this.txtName.Text.Trim();
            supplier.Address = this.txtAddress.Text.Trim();
            supplier.TaxpayerID = this.txtTaxpayerID.Text.Trim();
            supplier.BankName = this.txtBankName.Text.Trim();
            supplier.BankNO = this.txtBankNO.Text.Trim();
            supplier.Contacts = this.txtContacts.Text.Trim();
            supplier.DepartmentCode=(this.cboDepartment.SelectedItem as Department).Code;
            supplier.FaxNumber = this.txtFaxNumber.Text.Trim();
            supplier.Legal = this.txtLegal.Text.Trim();
            supplier.Nature = this.cboNature.Text;
            supplier.PostalCode = this.txtPostalCode.Text.Trim();
            supplier.RegisterCapital = txtRegisterCapital.Text.Trim();
            supplier.SupplierType = this.cboSupplierType.SelectedIndex;
            supplier.Tell = this.txtTell.Text.Trim();
            supplier.Discredited = this.chkDiscredited.Checked;
            supplier.ExistsAgentAgreement = this.chkExistsAgentAgreement.Checked;
            supplier.Description = this.meDescription.Text.Trim();
            supplier.CreateUser = RunInfo.Instance.CurrentUser.UserName;
            int result = sm.AddSupplier(supplier); 

            if (result <=0)
            {
                XtraMessageBox.Show("创建失败！");
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

       

        protected override void SubmitModifyData()
        {
            base.SubmitModifyData();

            this.dxErrorProvider1.ClearErrors();
            this.CheckNameInput();
            this.CheckAddressInput();
            this.CheckContactsInput();
            this.CheckDepartmentInput();
            this.CheckTellInput();
            this.CheckLegalInput();
            this.CheckSupplierTypeInput();
            this.CheckTaxpayerIDInput();
            if (dxErrorProvider1.HasErrors)
            {
                return;
            }

            Supplier.Name = this.txtName.Text.Trim();
            Supplier.Address = this.txtAddress.Text.Trim();
            Supplier.TaxpayerID = this.txtTaxpayerID.Text.Trim();
            Supplier.BankName = this.txtBankName.Text.Trim();
            Supplier.BankNO = this.txtBankNO.Text.Trim();
            Supplier.Contacts = this.txtContacts.Text.Trim();
            Supplier.DepartmentCode = (this.cboDepartment.SelectedItem as Department).Code;
            Supplier.FaxNumber = this.txtFaxNumber.Text.Trim();
            Supplier.Legal = this.txtLegal.Text.Trim();
            Supplier.Nature = this.cboNature.Text;
            Supplier.PostalCode = this.txtPostalCode.Text.Trim();
            Supplier.RegisterCapital = txtRegisterCapital.Text.Trim();
            Supplier.SupplierType = this.cboSupplierType.SelectedIndex;
            Supplier.Tell = this.txtTell.Text.Trim();
            Supplier.Description = this.meDescription.Text.Trim();
            Supplier.Discredited = this.chkDiscredited.Checked;
            Supplier.ExistsAgentAgreement = this.chkExistsAgentAgreement.Checked;
            sm.ModifySupplier(Supplier); 

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

    }
}