using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;
using Newtonsoft.Json;

namespace BudgetSystem
{
    public partial class frmSupplierEdit : frmBaseDialogForm
    {
        public Supplier CurrentSupplier
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
                this.lcUpdateDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.lcUpdateUser.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else if (this.WorkModel == EditFormWorkModels.Modify)
            {
                this.Text = "编辑供应商信息";
                Supplier supplier = sm.GetSupplier(CurrentSupplier.ID);
                if (supplier != null)
                {
                    BindingSupplier(supplier);
                    if (supplier.EnumFlowState != EnumDataFlowState.未审批 && supplier.SupplierType != (int)EnumSupplierType.临时供方)
                    {
                        SetReadOnly();
                    }
                }

            }
            else if (this.WorkModel == EditFormWorkModels.View)
            {
                this.Text = "查看供应商信息";
                SetReadOnly();
                this.btnSure.Enabled = false;
                this.gvBankInfoDetail.Columns.Remove(this.colDelete);
                this.gvBankInfoDetail.OptionsBehavior.Editable = false;
                Supplier supplier = sm.GetSupplier(CurrentSupplier.ID);
                BindingSupplier(supplier);
            }
        }
        private void btnSure_Click(object sender, EventArgs e)
        {
            SubmitDataByWorkModel();
        }


        private void BindingSupplier(Supplier supplier)
        {
            if (supplier != null)
            {
                this.txtName.Text = supplier.Name;
                this.txtTaxpayerID.Text = supplier.TaxpayerID;
                this.txtLegal.Text = supplier.Legal;
                this.cboSupplierType.SelectedIndex = supplier.SupplierType;
                this.cboNature.Text = supplier.Nature;
                this.txtRegisterCapital.EditValue = supplier.RegisterCapital;
                this.txtPostalCode.Text = supplier.PostalCode;
                this.txtAddress.Text = supplier.Address;
                this.txtTell.Text = supplier.Tell;
                this.txtContacts.Text = supplier.Contacts;
                this.txtFaxNumber.Text = supplier.FaxNumber;
                this.txtContacts.Text = supplier.Contacts;
                this.txtCreateUser.Text = supplier.CreateUserName;
                this.txtCreateDate.EditValue = supplier.CreateDate;
                this.meDescription.Text = supplier.Description;
                this.chkDiscredited.Checked = supplier.Discredited;
                this.chkExistsAgentAgreement.Checked = supplier.ExistsAgentAgreement;
                this.dteAgreementDate.EditValue = supplier.AgreementDate;
                this.dteBusinessEffectiveDate.EditValue = supplier.BusinessEffectiveDate;
                this.dteRegistrationDate.EditValue = supplier.RegistrationDate;
                this.txtUpdateDate.EditValue = supplier.UpdateDate;
                this.txtUpdateUser.Text = supplier.UpdateUserName;
                this.dteAgreementDate.EditValue = supplier.AgreementDate;
                this.dteBusinessEffectiveDate.EditValue = supplier.BusinessEffectiveDate;
                this.dteRegistrationDate.EditValue = supplier.RegistrationDate;
                this.BindingBankInfoDetail(supplier.BankInfoDetail);
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
        private void SetReadOnly()
        {
            foreach (var control in this.layoutControl1.Controls)
            {
                if (control is BaseEdit)
                {
                    (control as BaseEdit).Properties.ReadOnly = true;
                }
            }
        }
        #region Check
        public bool CheckBankInfo()
        {
            var dataSource = (gridBankInfoDetail.DataSource as BindingList<BankInfo>).ToList();
            if (dataSource == null || dataSource.Count == 0)
            {
                XtraMessageBox.Show("至少输入一条银行账号信息", "提示");
                return false;
            }
            return true;
        }

        public void CheckInputData()
        {
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtName, "请输入名称");
            }

            if (string.IsNullOrEmpty(this.cboDepartment.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.cboDepartment, "请选择所属部门");
            }

            if (cboSupplierType.SelectedIndex != 0)
            {
                //非合格供应商，其它项不需要验证
                return;
            }
            if (string.IsNullOrEmpty(this.txtTaxpayerID.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtTaxpayerID, "请输入纳税人识别号");
            }
            if (string.IsNullOrEmpty(this.txtLegal.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtLegal, "请输入法人代表");
            }
            if (this.chkExistsAgentAgreement.Checked && this.dteAgreementDate.EditValue == null)
            {
                this.dxErrorProvider1.SetError(this.dteAgreementDate, "请输入代理协议有效期");
            }
            if (dteRegistrationDate.EditValue == null)
            {
                this.dxErrorProvider1.SetError(this.dteRegistrationDate, "请输入工商登记日期");
            }
            if (dteBusinessEffectiveDate.EditValue == null)
            {
                this.dxErrorProvider1.SetError(this.dteBusinessEffectiveDate, "请输入经营截至日期");
            }
            if (dteRegistrationDate.EditValue != null
                && dteBusinessEffectiveDate.EditValue != null
                && (DateTime)dteRegistrationDate.EditValue > (DateTime)dteBusinessEffectiveDate.EditValue)
            {
                this.dxErrorProvider1.SetError(this.dteBusinessEffectiveDate, "经营截至日期应大于工商登记日期");
            }


            if (string.IsNullOrEmpty(this.txtAddress.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtAddress, "请输入地址");
            }
            if (string.IsNullOrEmpty(this.txtTell.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtTell, "请输入联系电话");
            }
            if (string.IsNullOrEmpty(this.txtContacts.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtContacts, "请输入联系人");
            }


        }


        #endregion

        protected override void SubmitNewData()
        {
            base.SubmitNewData();
            this.dxErrorProvider1.ClearErrors();
            this.CheckInputData();
            bool checkBankInfoResult = this.CheckBankInfo();
            if (dxErrorProvider1.HasErrors || checkBankInfoResult == false)
            {
                return;
            }
            Supplier supplier = new Entity.Supplier();
            supplier.Name = this.txtName.Text.Trim();
            supplier.Address = this.txtAddress.Text.Trim();
            supplier.TaxpayerID = this.txtTaxpayerID.Text.Trim();
            supplier.Contacts = this.txtContacts.Text.Trim();
            supplier.DepartmentCode = (this.cboDepartment.SelectedItem as Department).Code;
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
            supplier.RegistrationDate = this.dteRegistrationDate.DateTime;
            supplier.AgreementDate = this.dteAgreementDate.DateTime;
            supplier.BusinessEffectiveDate = this.dteBusinessEffectiveDate.DateTime;
            supplier.BankInfoDetail = this.GetBankInfoDetailString();
            supplier.CreateUser = RunInfo.Instance.CurrentUser.UserName;
            supplier.CreateUserName = RunInfo.Instance.CurrentUser.RealName;
            supplier.CreateDate = DateTime.Now;
            supplier.UpdateUser = RunInfo.Instance.CurrentUser.UserName;
            supplier.UpdateUserName = RunInfo.Instance.CurrentUser.RealName;
            supplier.UpdateDate = DateTime.Now;
            int result = sm.AddSupplier(supplier);

            if (result <= 0)
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
            bool checkBankInfoResult = this.CheckBankInfo();
            if (dxErrorProvider1.HasErrors || checkBankInfoResult == false)
            {
                return;
            }

            CurrentSupplier.Name = this.txtName.Text.Trim();
            CurrentSupplier.Address = this.txtAddress.Text.Trim();
            CurrentSupplier.TaxpayerID = this.txtTaxpayerID.Text.Trim();
            CurrentSupplier.Contacts = this.txtContacts.Text.Trim();
            CurrentSupplier.DepartmentCode = (this.cboDepartment.SelectedItem as Department).Code;
            CurrentSupplier.FaxNumber = this.txtFaxNumber.Text.Trim();
            CurrentSupplier.Legal = this.txtLegal.Text.Trim();
            CurrentSupplier.Nature = this.cboNature.Text;
            CurrentSupplier.PostalCode = this.txtPostalCode.Text.Trim();
            CurrentSupplier.RegisterCapital = txtRegisterCapital.Text.Trim();
            CurrentSupplier.SupplierType = this.cboSupplierType.SelectedIndex;
            CurrentSupplier.Tell = this.txtTell.Text.Trim();
            CurrentSupplier.Description = this.meDescription.Text.Trim();
            CurrentSupplier.Discredited = this.chkDiscredited.Checked;
            CurrentSupplier.ExistsAgentAgreement = this.chkExistsAgentAgreement.Checked;
            CurrentSupplier.RegistrationDate = this.dteRegistrationDate.DateTime;
            CurrentSupplier.AgreementDate = this.dteAgreementDate.DateTime;
            CurrentSupplier.BusinessEffectiveDate = this.dteBusinessEffectiveDate.DateTime;
            CurrentSupplier.BankInfoDetail = this.GetBankInfoDetailString();
            CurrentSupplier.UpdateUser = RunInfo.Instance.CurrentUser.UserName;
            CurrentSupplier.UpdateUserName = RunInfo.Instance.CurrentUser.RealName;
            CurrentSupplier.UpdateDate = DateTime.Now;
            sm.ModifySupplier(CurrentSupplier);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void BindingBankInfoDetail(string detail)
        {
            List<BankInfo> bankInfoList;
            if (!string.IsNullOrEmpty(detail))
            {
                bankInfoList = JsonConvert.DeserializeObject<List<BankInfo>>(detail);
            }
            else
            {
                bankInfoList = new List<BankInfo>();
            }

            this.gridBankInfoDetail.DataSource = new BindingList<BankInfo>(bankInfoList);
            this.gridBankInfoDetail.RefreshDataSource();
        }

        private string GetBankInfoDetailString()
        {
            this.gvBankInfoDetail.CloseEditor();
            var dataSource = (IEnumerable<BankInfo>)gridBankInfoDetail.DataSource;
            if (dataSource != null)
            {
                return JsonConvert.SerializeObject(dataSource);
            }
            else
            {
                return "";
            }
        }
        private void gvBankInfoDetail_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (e.Value == null || string.IsNullOrEmpty(e.Value.ToString()))
            {
                if (gvBankInfoDetail.FocusedColumn == gcName)
                {
                    e.ErrorText = "开户行不能为空";
                    gvBankInfoDetail.SetColumnError(gcName, e.ErrorText);
                }
                else if (gvBankInfoDetail.FocusedColumn == gcAccount)
                {
                    e.ErrorText = "银行账号不能为空";
                    gvBankInfoDetail.SetColumnError(gcAccount, e.ErrorText);
                }
                e.Valid = false;
            }
            else
            {
                gvBankInfoDetail.SetColumnError(gvBankInfoDetail.FocusedColumn, null, DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);
            }
        }
        private void gvBankInfoDetail_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
        private void gvBankInfoDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var info = e.Row as BankInfo;
            if (string.IsNullOrEmpty(info.Name))
            {
                e.ErrorText = "开户行不能为空";
                gvBankInfoDetail.SetColumnError(gcName, e.ErrorText);
                e.Valid = false;
            }
            else if (string.IsNullOrEmpty(info.Account))
            {
                e.ErrorText = "银行账号不能为空";
                gvBankInfoDetail.SetColumnError(gcAccount, e.ErrorText);
                e.Valid = false;
            }
        }
        private void gvBankInfoDetail_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
        private void riLinkDelete_Click(object sender, System.EventArgs e)
        {
            if (this.gvBankInfoDetail.FocusedRowHandle < 0)
            {
                gvBankInfoDetail.CancelUpdateCurrentRow();
            }
            else
            {
                gvBankInfoDetail.DeleteRow(gvBankInfoDetail.FocusedRowHandle);
            }
            gvBankInfoDetail.ClearColumnErrors();
        }

        private void riLinkDelete_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = "删除";
        }

    }
}