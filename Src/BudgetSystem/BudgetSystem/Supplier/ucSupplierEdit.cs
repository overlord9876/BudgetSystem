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
            this.Load += new System.EventHandler(this.ucSupplierEdit_Load);
        }
        private void ucSupplierEdit_Load(object sender, EventArgs e)
        {
            RegisterEvent();
        }
        private void RegisterEvent()
        {
            this.dteRegistrationDate.EditValueChanged += new EventHandler(dteRegistrationDate_EditValueChanged);
            foreach (Control control in this.layoutControl2.Controls)
            {
                if (control is RadioGroup && control.Tag != null)
                {
                    (control as RadioGroup).SelectedIndexChanged += new EventHandler(FirstReviewItem_SelectedIndexChanged);
                }
            }
            this.rgResult.SelectedIndexChanged += new EventHandler(rgResult_SelectedIndexChanged);
            this.txtPassedBatch.EditValueChanged+=new EventHandler(Batch_EditValueChanged);
            this.txtRejectedBatch.EditValueChanged += new EventHandler(Batch_EditValueChanged);
        }

       

        void dteRegistrationDate_EditValueChanged(object sender, EventArgs e)
        {
            if (this.WorkModel == EditFormWorkModels.New
                ||(this.WorkModel== EditFormWorkModels.Modify
                   && (this.CurrentSupplier.EnumFlowState== EnumDataFlowState.未审批||this.CurrentSupplier.EnumFlowState== EnumDataFlowState.审批不通过)))
            {
                this.dteReviewDate.EditValue = this.dteRegistrationDate.DateTime.AddYears(DateTime.Now.Year - this.dteRegistrationDate.DateTime.Year + 1);
            }
        }
        void FirstReviewItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.WorkModel == EditFormWorkModels.New
                || (this.WorkModel == EditFormWorkModels.Modify
                   && (this.CurrentSupplier.EnumFlowState == EnumDataFlowState.未审批||this.CurrentSupplier.EnumFlowState== EnumDataFlowState.审批不通过)))
            {
                int result = 0; int maxResult = 3;
                int currentResult = 0;
                foreach (Control control in this.layoutControl2.Controls)
                {
                    if (control is RadioGroup && control.Tag != null)
                    {
                        currentResult= (control as RadioGroup).SelectedIndex;
                        if (currentResult > result)
                        {
                            result = currentResult;
                        }
                        if (result == maxResult)
                        {
                            break;
                        }
                    }
                }
                this.rgResult.SelectedIndex = result;
            }
        }
        void rgResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboSalesmanResult.SelectedIndex = this.rgResult.SelectedIndex;
        }
        void Batch_EditValueChanged(object sender, EventArgs e)
        {
            int pass = 0;
            if (!string.IsNullOrEmpty(txtPassedBatch.Text.Trim()))
            {
                pass = int.Parse(this.txtPassedBatch.Text.Trim());
            }
            int count = pass;
            if (!string.IsNullOrEmpty(txtRejectedBatch.Text.Trim()))
            {
                count += int.Parse(this.txtRejectedBatch.Text.Trim());
            }
            this.txtTotalBatch.Text =string.Format("总共:{0}批次", count.ToString());
            this.txtTotalBatch.Tag = count;
        }
        
        public void InitData()
        {
            this.cboSupplierType.Properties.Items.Add("合格供方");
            this.cboSupplierType.Properties.Items.Add("临时供方");
            this.cboSupplierType.Properties.Items.Add("其它供方");
            //this.cboSupplierType.Properties.Items.Add("货运供方");
            //this.cboSupplierType.Properties.Items.Add("佣金供方");
            this.cboSupplierType.SelectedIndex = 1;

            List<string> natureList = scm.GetSystemConfigValue<List<string>>(EnumSystemConfigNames.企业性质.ToString());
            this.cboNature.Properties.Items.Clear();
            if (natureList != null && natureList.Count > 0)
            {
                this.cboNature.Properties.Items.AddRange(natureList);
                this.cboNature.SelectedIndex = 0;
            }
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
                this.chkExistsLicenseCopy.Checked = supplier.ExistsLicenseCopy;
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
                this.BindingFirstReviewDetail(supplier.FirstReviewContents);
                if (this.WorkModel == EditFormWorkModels.Custom)
                {
                    this.BindingReviewHistory(supplier.ID);
                    this.BindingReviewDetail(string.Empty);
                }
                else
                {
                    if (EnumFlowNames.供应商复审流程.ToString() == supplier.FlowName)
                    {
                        this.BindingReviewHistory(supplier.ID);
                    }
                    this.BindingReviewDetail(supplier.ReviewContents);
                }
                foreach (Department department in this.cboDepartment.Properties.Items)
                {
                    if (department.ID == supplier.DeptID)
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
                this.lcgReviewContents.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.lcgReviewResult.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                this.xtraTabControl1.TabPages.Remove(this.xtraTabPage3);
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
                        SetReviewControlReadOnly();
                    }
                    if (supplier.FlowName != EnumFlowNames.供应商复审流程.ToString()) 
                    {
                        this.lcgReviewContents.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        this.lcgReviewResult.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        this.xtraTabControl1.TabPages.Remove(this.xtraTabPage3);
                    }
                }

            }
            else if (this.WorkModel == EditFormWorkModels.View)
            {
                SetReadOnly();
                SetReviewControlReadOnly();
                this.gvBankInfoDetail.Columns.Remove(this.colDelete);
                this.gvBankInfoDetail.OptionsBehavior.Editable = false;

                Supplier supplier = sm.GetSupplier(CurrentSupplier.ID);
                if (supplier != null)
                {
                    BindingSupplier(supplier);
                    if (supplier.FlowName != EnumFlowNames.供应商复审流程.ToString())
                    {
                        this.lcgReviewContents.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        this.lcgReviewResult.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        this.xtraTabControl1.TabPages.Remove(this.xtraTabPage3);
                    }
                }
            }
            else if (this.WorkModel == EditFormWorkModels.Custom)
            {
                SetReadOnly();
                Supplier supplier = sm.GetSupplier(CurrentSupplier.ID);
                if (supplier != null)
                {
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
            foreach (var control in this.layoutControl2.Controls)
            {
                if (control is BaseEdit)
                {
                    (control as BaseEdit).Properties.ReadOnly = true;
                }
            }
            
        }
        private void SetReviewControlReadOnly()
        {
            txtPassedBatch.Properties.ReadOnly = true;
            txtRejectedBatch.Properties.ReadOnly = true;
            txtRectificationPassedBatch.Properties.ReadOnly = true;
            txtRectificationBatch.Properties.ReadOnly = true;
            rgDiscredited.Properties.ReadOnly = true;
            rgRectificationResult.Properties.ReadOnly = true;
        }

        public bool CheckInputData(bool isStartFlow)
        {
            this.dxErrorProvider1.ClearErrors();
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtName, "请输入名称");
            }
            else
            {
                int id = this.CurrentSupplier == null ? 0 : this.CurrentSupplier.ID;
                if (sm.CheckName(this.txtName.Text.Trim(), id))
                {
                    this.dxErrorProvider1.SetError(this.txtName, "名称已存在");
                }
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
            if (cboSupplierType.SelectedIndex != 0 && isStartFlow)
            {
                XtraMessageBox.Show("非合格供方不需要提交审批流程", "提示");
                return false;
            }
            if (cboSupplierType.SelectedIndex != 0||!isStartFlow)
            {
                //非合格供应商或不提交流程时，其它项不需要验证
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
            if (!this.chkExistsAgentAgreement.Checked)
            {
                this.dxErrorProvider1.SetError(this.chkExistsAgentAgreement, "合格供方需要代理协议");
            }
            if (this.dteAgreementDate.EditValue == null)
            {
                this.dxErrorProvider1.SetError(this.dteAgreementDate, "请输入代理协议有效期");
            }
            else if (this.dteAgreementDate.DateTime.AddDays(30).Date < DateTime.Now.Date)
            {
                this.dxErrorProvider1.SetError(this.dteAgreementDate, "代理协议有效期应大于当前日期30天");
            }
            if (!chkExistsLicenseCopy.Checked)
            {
                this.dxErrorProvider1.SetError(this.chkExistsLicenseCopy, "合格供方需要营业执照复印件");
            }
            if (chkDiscredited.Checked)
            {
                this.dxErrorProvider1.SetError(this.chkDiscredited, "合格供方需为非经营异常企业");
            }
            if (dteRegistrationDate.EditValue == null)
            {
                this.dxErrorProvider1.SetError(this.dteRegistrationDate, "请输入工商登记日期");
            }
            else if (this.dteRegistrationDate.DateTime.Date > DateTime.Now.Date)
            {
                this.dxErrorProvider1.SetError(this.dteRegistrationDate, "工商登记日期应小于当前日期");
            }

            if (dteBusinessEffectiveDate.EditValue == null)
            {
                this.dxErrorProvider1.SetError(this.dteBusinessEffectiveDate, "请输入经营截至日期");
            }
            else if (dteRegistrationDate.EditValue != null && dteBusinessEffectiveDate.DateTime < dteRegistrationDate.DateTime)
            {
                this.dxErrorProvider1.SetError(this.dteBusinessEffectiveDate, "经营截至日期应大于工商登记日期");
            }
            else if (dteBusinessEffectiveDate.DateTime.AddDays(30).Date < DateTime.Now.Date)
            {
                this.dxErrorProvider1.SetError(this.dteBusinessEffectiveDate, "经营截至日期应大于当前日期30天");
            }
            if (this.WorkModel == EditFormWorkModels.Custom)
            {
                //复审
                if (txtTotalBatch.Tag == null || ((int)txtTotalBatch.Tag) == 0)
                {
                    this.dxErrorProvider1.SetError(this.txtTotalBatch, "总批次不能为0");
                }
                if (rgRectificationResult.SelectedIndex != 0)
                {
                    this.dxErrorProvider1.SetError(this.rgRectificationResult, "不合格整改记录整改后应为合格");
                }
            }
            else
            {
                foreach (Control control in this.layoutControl2.Controls)
                {
                    if (control is RadioGroup && control.Tag != null&& (control as RadioGroup).SelectedIndex == -1)
                    {
                        this.dxErrorProvider1.SetError(control, string.Format("请选择{0}评价",control.Tag));
                    }
                }
                if (rgResult.SelectedIndex == 3)
                {
                    this.dxErrorProvider1.SetError(this.rgResult, "评价结论为D不能提交审批");
                }
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
                this.CurrentSupplier.FlowState = -1;
            }
            this.CurrentSupplier.Name = this.txtName.Text.Trim();
            this.CurrentSupplier.Address = this.txtAddress.Text.Trim();
            this.CurrentSupplier.TaxpayerID = this.txtTaxpayerID.Text.Trim();
            this.CurrentSupplier.Contacts = this.txtContacts.Text.Trim();
            this.CurrentSupplier.DeptID = (this.cboDepartment.SelectedItem as Department).ID;
            this.CurrentSupplier.DepartmentCode = (this.cboDepartment.SelectedItem as Department).Code;
            this.CurrentSupplier.DepartmentName = (this.cboDepartment.SelectedItem as Department).Name;
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
            this.CurrentSupplier.ReviewDate = this.dteReviewDate.DateTime;
            this.CurrentSupplier.ExistsLicenseCopy = this.chkExistsLicenseCopy.Checked;
            this.CurrentSupplier.BankInfoDetail = this.GetBankInfoDetailString();

            DateTime? registrationDate;
            DateTime? agreementDate;
            DateTime? businesseffectiveDate;
            if (this.dteRegistrationDate.EditValue == null)
            {
                registrationDate = null;
            }
            else
            {
                registrationDate = this.dteRegistrationDate.DateTime;
            }
            if (this.dteAgreementDate.EditValue == null)
            {
                agreementDate = null;
            }
            else
            {
                agreementDate = this.dteAgreementDate.DateTime;
            }
            if (this.dteBusinessEffectiveDate.EditValue == null)
            {
                businesseffectiveDate = null;
            }
            else
            {
                businesseffectiveDate = this.dteBusinessEffectiveDate.DateTime;
            }
            if (this.WorkModel == EditFormWorkModels.Custom)
            {
                //复审
                SupplierReviewContents reviewContents = new SupplierReviewContents();
                reviewContents.AgreementDate = agreementDate;
                reviewContents.BusinessEffectiveDate = businesseffectiveDate;
                reviewContents.RegistrationDate = registrationDate;
                reviewContents.PassedBatch=int.Parse(txtPassedBatch.Text.Trim()) ;
                reviewContents.RejectedBatch = int.Parse(txtRejectedBatch.Text.Trim());
                reviewContents.RectificationPassedBatch=int.Parse(txtRectificationPassedBatch.Text.Trim());
                reviewContents.RectificationBatch=int.Parse(txtRectificationBatch.Text.Trim());
                reviewContents.RectificationResult=rgRectificationResult.SelectedIndex==0?true:false;
                reviewContents.SalesmanResult = cboReviewSalesmanResult.SelectedIndex == 0 ? true : false;
                reviewContents.Salesman = RunInfo.Instance.CurrentUser.UserName;
                this.CurrentSupplier.ReviewContents = reviewContents.ToJson();
            }
            else
            {
                this.CurrentSupplier.RegistrationDate=registrationDate;
                this.CurrentSupplier.AgreementDate= agreementDate;
                this.CurrentSupplier.BusinessEffectiveDate= businesseffectiveDate;
                if (this.CurrentSupplier.EnumFlowState == EnumDataFlowState.未审批
                    || this.CurrentSupplier.EnumFlowState == EnumDataFlowState.审批不通过)
                {
                    SupplierFirstReviewContents reviewContents = new SupplierFirstReviewContents();
                    reviewContents.Result = this.rgResult.SelectedIndex;
                    reviewContents.ReviewItems = new Dictionary<string, int>();
                    foreach (Control control in this.layoutControl2.Controls)
                    {
                        if (control is RadioGroup && control.Tag != null)
                        {
                            reviewContents.ReviewItems.Add(control.Tag.ToString(), (control as RadioGroup).SelectedIndex);
                        }
                    }
                    reviewContents.Salesman = RunInfo.Instance.CurrentUser.UserName;
                    reviewContents.SalesmanResult = this.cboSalesmanResult.SelectedIndex;
                    this.CurrentSupplier.FirstReviewContents=reviewContents.ToJson();
                }
            }

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
        private void BindingFirstReviewDetail(string detail)
        {
            if (!string.IsNullOrEmpty(detail))
            {
                SupplierFirstReviewContents firstReviewContents = detail.ToObjectList<SupplierFirstReviewContents>();
                foreach (Control control in this.layoutControl2.Controls)
                {
                    if (control is RadioGroup && control.Tag != null)
                    {
                        if (firstReviewContents.ReviewItems.Keys.Contains(control.Tag.ToString()))
                        {
                            (control as RadioGroup).SelectedIndex = firstReviewContents.ReviewItems[control.Tag.ToString()];
                        }
                    }
                }
                rgResult.SelectedIndex = firstReviewContents.Result;
                cboSalesmanResult.SelectedIndex = firstReviewContents.SalesmanResult;
                txtSalesman.Text = firstReviewContents.Salesman;                
                cboManagerResult.SelectedIndex = firstReviewContents.ManagerResult;
                txtManager.Text = firstReviewContents.Manager;
                cboLeaderResult.SelectedIndex = firstReviewContents.LeaderResult;
                txtLeader.Text = firstReviewContents.Leader;
                dteFirstReviewResultDate.EditValue = firstReviewContents.ResultDate;
            }
        }
        private void BindingReviewDetail(string detail)
        {
            if (!string.IsNullOrEmpty(detail))
            {
                SupplierReviewContents reviewContents = detail.ToObjectList<SupplierReviewContents>();
                txtPassedBatch.EditValue = reviewContents.PassedBatch;
                txtRejectedBatch.EditValue = reviewContents.RejectedBatch;
                txtRectificationPassedBatch.EditValue = reviewContents.RectificationPassedBatch;
                txtRectificationBatch.EditValue = reviewContents.RectificationBatch;
                rgDiscredited.SelectedIndex = reviewContents.Discredited ? 1 : 0;
                rgRectificationResult.SelectedIndex = reviewContents.RectificationResult ? 0 : 1;
                cboReviewSalesmanResult.SelectedIndex = reviewContents.SalesmanResult ? 0 : 1;
                txtReviewSalesman.Text = reviewContents.Salesman;
                dteRegistrationDate.EditValue = reviewContents.RegistrationDate;
                dteAgreementDate.EditValue = reviewContents.AgreementDate;
                dteBusinessEffectiveDate.EditValue = reviewContents.BusinessEffectiveDate;
                if (reviewContents.ManagerResult != null)
                {
                    txtReviewManager.Text = reviewContents.Manager;
                    cboReviewManagerResult.SelectedIndex = reviewContents.ManagerResult == true ? 0 : 1;
                    if (reviewContents.LeaderResult != null)
                    {
                        cboReviewLeaderResult.SelectedIndex = reviewContents.LeaderResult == true ? 0 : 1;
                        txtReviewLeader.Text = reviewContents.Leader;
                        dteReviewResultDate.EditValue = reviewContents.ResultDate;
                    }
                }
            }
        }

        public void BindingReviewHistory(int id)
        {
            Bll.ModifyMarkManager mm = new Bll.ModifyMarkManager();
            List<SupplierReviewContents> list= mm.GetAllModifyMark<SupplierReviewContents>(id);
            this.gridSupplier.DataSource = list;
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