using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BudgetSystem.Entity;
using DevExpress.XtraLayout;
using BudgetSystem.UIEntity;
using DevExpress.XtraEditors;
using BudgetSystem.FlowManage;

namespace BudgetSystem.WorkSpace
{
    public partial class frmApproveEx : frmBaseDialogForm
    {
        public frmApproveEx()
        {
            InitializeComponent();
        }

        private Bll.FlowManager fm = new Bll.FlowManager();

        public FlowItem FlowItem
        {
            get;
            set;
        }

        public const string ApproveModel = "Approve";
        public const string ConfirmOrRevokeModel = "ConfirmOrRevoke";
        public const string ViewModel = "View";

        private void frmApproveEx_Load(object sender, EventArgs e)
        {
            SetLayoutControlStyle();
            CreateView();

            if (this.CustomWorkModel == ApproveModel)
            {
                this.Text = "流程审批";
            }
            else if (this.CustomWorkModel == ViewModel)
            {
                this.Text = "查看审批数据";
            }
            else if (this.CustomWorkModel == ConfirmOrRevokeModel)
            {
                this.Text = "流程发起人确认或撤回";
            }
        }


        public void CreateView()
        {
            lcDataGroup.BeginUpdate();

            lcDataGroup.Clear();

            DataControl dc = DataControlCreator.CreateDataControl(FlowItem.DateItemType);
            dc.BindingData(FlowItem.DateItemID);




            this.layoutControl1.Controls.Add(dc);
            var temp = lcDataGroup.AddItem(FlowItem.DateItemText, dc);


            temp.TextLocation = DevExpress.Utils.Locations.Top;
            temp.SizeConstraintsType = SizeConstraintsType.Custom;
            temp.MaxSize = new Size(0, dc.Height);
            temp.MinSize = new Size(0, dc.Height);
            this.Width = dc.Width + 20;

            this.lcDataGroup.Remove(emptySpaceItem1);
            lcDataGroup.EndUpdate();
        }

        private void Submit(bool result)
        {
            FlowRunState state = fm.SubmitFlow(this.FlowItem.RunPointID, result, this.txtMyInfo.Text.Trim());
            string info;
            if (state.Translate(out info))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                XtraMessageBox.Show(info);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Submit(true);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Submit(false);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!FlowItem.IsClosed)
            {
                XtraMessageBox.Show("当选中流程尚未审批完成，不可以确认");
                return;
            }


            FlowRunState state = fm.ConfirmFlowInstance(this.FlowItem.ID);
            string info;
            if (state.Translate(out info))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                XtraMessageBox.Show(info);
            }
        }

        private void btnRevoke_Click(object sender, EventArgs e)
        {
            if (FlowItem.IsClosed)
            {
                XtraMessageBox.Show("当选中流程已审批完成，不可以撤回");
                return;
            }


            FlowRunState state = fm.RevokeFlow(this.FlowItem.ID, true);
            string info;
            if (state.Translate(out info))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                XtraMessageBox.Show(info);
            }
        }

        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            frmHistory hisotryForm = new frmHistory();
            hisotryForm.FlowItem = this.FlowItem;
            hisotryForm.ShowDialog();
        }

        private void btnViewFlow_Click(object sender, EventArgs e)
        {
            Flow flow= fm.GetFlow(FlowItem.FlowName, FlowItem.FlowVersionNumber);

            frmFlowEdit form = new frmFlowEdit() { WorkModel = EditFormWorkModels.View, Flow = flow };
            form.SetVersionReadOnly();
            form.ShowDialog();
        }
    }
}
