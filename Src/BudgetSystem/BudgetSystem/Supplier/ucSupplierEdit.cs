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

namespace BudgetSystem
{
    public partial class ucSupplierEdit : DataControl
    {
        public Supplier CurrentSupplier
        {
            get;
            set;
        }
        private Bll.SupplierManager sm = new Bll.SupplierManager();
        private Bll.DepartmentManager dm = new Bll.DepartmentManager();
        private Bll.SystemConfigManager scm = new Bll.SystemConfigManager();
        private EditFormWorkModels _workModel;

        public EditFormWorkModels WorkModel
        {
            get { return this._workModel; }
            set
            {
                this._workModel = value;
                InitControlState();
            }
        }

        public ucSupplierEdit()
        {
            InitializeComponent();
        }

        public void InitData()
        {
            this.cboSupplierType.Properties.Items.Add("合格供方");
            this.cboSupplierType.Properties.Items.Add("临时供方");
            this.cboSupplierType.Properties.Items.Add("其它供方");
            this.cboSupplierType.SelectedIndex = 1;

            List<string> natureList=scm.GetSystemConfigValue<List<string>>(EnumSystemConfigNames.企业性质.ToString());
            this.cboNature.Properties.Items.Clear();
            this.cboNature.Properties.Items.AddRange(natureList);
            this.cboNature.SelectedIndex = 0;

            List<Department> departmentList = dm.GetAllDepartment();
            this.cboDepartment.Properties.Items.AddRange(departmentList);

            // this.layoutControl1.RestoreLayoutFromStream(this.GetResourceFileByCurrentWorkModel());

        }

        public override void BindingData(int dataID)
        {
            Supplier supplier = sm.GetSupplier(dataID);
            BindingSupplier(supplier);
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

        private void InitControlState()
        {
            if (this.WorkModel == EditFormWorkModels.New)
            {
                this.lcCreateDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.lcCreateUser.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.lcUpdateDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.lcUpdateUser.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                BindingBankInfoDetail(string.Empty);
            }
            else if (this.WorkModel == EditFormWorkModels.Modify)
            {
                Supplier supplier = sm.GetSupplier(CurrentSupplier.ID);
                if (supplier != null)
                {
                    BindingSupplier(supplier);
                    if (supplier.EnumFlowState != EnumDataFlowState.未审批 && supplier.SupplierType == (int)EnumSupplierType.合格供方)
                    {
                        SetReadOnly();
                    }
                }

            }
            else if (this.WorkModel == EditFormWorkModels.View)
            {
                SetReadOnly();
                this.gvBankInfoDetail.Columns.Remove(this.colDelete);
                this.gvBankInfoDetail.OptionsBehavior.Editable = false;
                if (CurrentSupplier != null)
                {
                    Supplier supplier = sm.GetSupplier(CurrentSupplier.ID);
                    BindingSupplier(supplier);
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

        public bool CheckInputData()
        {
            this.dxErrorProvider1.ClearErrors();
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtName, "请输入名称");
            }

            if (string.IsNullOrEmpty(this.cboDepartment.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.cboDepartment, "请选择所属部门");
            }
            var dataSource = (gridBankInfoDetail.DataSource as BindingList<BankInfo>).ToList();
            if (dataSource == null || dataSource.Count == 0)
            {
                XtraMessageBox.Show("至少输入一条银行账号信息", "提示");
                return false;
            }
            if (cboSupplierType.SelectedIndex != 0)
            {
                //非合格供应商，其它项不需要验证
                return !this.dxErrorProvider1.HasErrors;
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
            return !this.dxErrorProvider1.HasErrors;
        }

        public void FillData()
        {
            if (this.CurrentSupplier == null)
            {
                //新增
                this.CurrentSupplier = new Supplier();
                this.CurrentSupplier.CreateUser = RunInfo.Instance.CurrentUser.UserName;
                this.CurrentSupplier.CreateUserName = RunInfo.Instance.CurrentUser.RealName;
                this.CurrentSupplier.CreateDate = DateTime.Now;
            }
            this.CurrentSupplier.Name = this.txtName.Text.Trim();
            this.CurrentSupplier.Address = this.txtAddress.Text.Trim();
            this.CurrentSupplier.TaxpayerID = this.txtTaxpayerID.Text.Trim();
            this.CurrentSupplier.Contacts = this.txtContacts.Text.Trim();
            this.CurrentSupplier.DepartmentCode = (this.cboDepartment.SelectedItem as Department).Code;
            this.CurrentSupplier.FaxNumber = this.txtFaxNumber.Text.Trim();
            this.CurrentSupplier.Legal = this.txtLegal.Text.Trim();
            this.CurrentSupplier.Nature = this.cboNature.Text;
            this.CurrentSupplier.PostalCode = this.txtPostalCode.Text.Trim();
            this.CurrentSupplier.RegisterCapital = txtRegisterCapital.Text.Trim();
            this.CurrentSupplier.SupplierType = this.cboSupplierType.SelectedIndex;
            this.CurrentSupplier.Tell = this.txtTell.Text.Trim();
            this.CurrentSupplier.Discredited = this.chkDiscredited.Checked;
            this.CurrentSupplier.ExistsAgentAgreement = this.chkExistsAgentAgreement.Checked;
            this.CurrentSupplier.Description = this.meDescription.Text.Trim();
            if (this.dteRegistrationDate.EditValue == null)
            {
                this.CurrentSupplier.RegistrationDate = null;
            }
            else
            {
                this.CurrentSupplier.RegistrationDate = this.dteRegistrationDate.DateTime;
            }
            if (this.dteAgreementDate.EditValue == null)
            {
                this.CurrentSupplier.AgreementDate = null;
            }
            else
            {
                this.CurrentSupplier.AgreementDate = this.dteAgreementDate.DateTime;
            }
            if (this.dteBusinessEffectiveDate.EditValue == null)
            {
                this.CurrentSupplier.BusinessEffectiveDate = null;
            }
            else
            {
                this.CurrentSupplier.BusinessEffectiveDate = this.dteBusinessEffectiveDate.DateTime;
            }
            this.CurrentSupplier.BankInfoDetail = this.GetBankInfoDetailString();

            this.CurrentSupplier.UpdateUser = RunInfo.Instance.CurrentUser.UserName;
            this.CurrentSupplier.UpdateUserName = RunInfo.Instance.CurrentUser.RealName;
            this.CurrentSupplier.UpdateDate = DateTime.Now;
        }

        private void BindingBankInfoDetail(string detail)
        {
            List<BankInfo> bankInfoList;
            if (!string.IsNullOrEmpty(detail))
            {
                bankInfoList = detail.ToObjectList<List<BankInfo>>();
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
                return dataSource.ToJson<IEnumerable<BankInfo>>();
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
                gvBankInfoDetail.CloseEditor();
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