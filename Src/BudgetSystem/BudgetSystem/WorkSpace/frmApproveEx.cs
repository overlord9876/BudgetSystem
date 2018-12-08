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

        public List<FlowItem> BatchFlowItems
        {
            get;
            set;
        }

        //public bool IsBatchApprove
        //{
        //    get;
        //    set;
        //}

        public const string ApproveModel = "Approve";
        public const string BatchApproveModel = "BatchApprove";
        public const string ConfirmOrRevokeModel = "ConfirmOrRevoke";
        public const string ViewModel = "View";
     

        private void frmApproveEx_Load(object sender, EventArgs e)
        {
            SetLayoutControlStyle();
            CreateView();

            if (this.CustomWorkModel == ApproveModel || this.CustomWorkModel== BatchApproveModel)
            {
                this.Text = "流程审批";
                string flowName = this.CustomWorkModel == BatchApproveModel ? BatchFlowItems[0].FlowName : FlowItem.FlowName;


                this.btnAccept.Text = RunInfo.Instance.FlowAppreveNameConfigs.GetDisplayAcceptName(flowName);
                this.btnReturn.Text = RunInfo.Instance.FlowAppreveNameConfigs.GetDisplayRefuseName(flowName);

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

            string dcType = this.CustomWorkModel == BatchApproveModel ? "BatchApprove" : FlowItem.DateItemType;

            DataControl dc = DataControlCreator.CreateDataControl(dcType);
            string layoutItemName;
            if (dc is BatchDataControl)
            {
                (dc as BatchDataControl).BindingBachData(this.BatchFlowItems );
                layoutItemName = "批量审批-" + this.BatchFlowItems[0].FlowName;
            }
            else
            {
                dc.BindingData(FlowItem.DateItemID);
                layoutItemName = FlowItem.DateItemText;
            }

        
            this.layoutControl1.Controls.Add(dc);
            var temp = lcDataGroup.AddItem(layoutItemName, dc);


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

        private void BatchSubmit(bool result)
        {
            string info;
            foreach (FlowItem item in this.BatchFlowItems)
            {
                FlowRunState state = fm.SubmitFlow(item.RunPointID, result, this.txtMyInfo.Text.Trim());
                if (state.Translate(out info))
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    XtraMessageBox.Show(item.DateItemText + "\r\n" + info);
                }
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (this.CustomWorkModel == BatchApproveModel)
            {
                BatchSubmit(true);
            }
            else
            {
                Submit(true);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (this.CustomWorkModel == BatchApproveModel)
            {
                BatchSubmit(false);
            }
            else
            {
                Submit(false);
            }
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
