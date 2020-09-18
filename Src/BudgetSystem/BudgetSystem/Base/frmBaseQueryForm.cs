using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BudgetSystem.Entity;
using BudgetSystem.Entity.QueryCondition;
using BudgetSystem.Base;
using DevExpress.XtraPrinting;

namespace BudgetSystem
{
    public partial class frmBaseQueryForm : frmBaseForm
    {
        public frmBaseQueryForm()
        {
            InitializeComponent();
            this.CanRefreshData = true;
            InitModelOperate();
            this.ModelOperatePageName = "操作页";
            this.FormID = Guid.NewGuid().ToString("N");
        }

        List<GridView> gridViewList = null;
        GridView printGridView;
        bool isPrintLandscape;

        protected bool CheckPermission(OperateTypes operate)
        {
            string permission = this.Module + "." + operate.ToString();

            return RunInfo.Instance.UserPermission.Contains(permission);

        }

        public string FormID
        {
            get;
            private set;
        }

        public virtual Entity.BusinessModules Module
        {
            get;
            set;
        }

        protected virtual void InitModelOperate()
        {
            this.ModelOperateRegistry = new List<ModelOperate>();
        }

        public virtual bool CanRefreshData
        {
            get;
            set;
        }

        public virtual void RefreshData()
        {
            this.LoadData();
        }


        public virtual List<ModelOperate> ModelOperateRegistry
        {
            get;
            protected set;
        }

        public virtual string ModelOperatePageName
        {
            get;
            protected set;
        }

        public virtual void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {
            if (operate.Operate == OperateTypes.CommonQuery.ToString())
            {
                DoCommonQuery(e.SenderText);
            }
            else if (operate.Operate == OperateTypes.CustomQuery.ToString())
            {
                QueryConditionEditorForm form = this.CreateConditionEditorForm();

                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    DoConditionQuery(form.QueryCondition);
                }
                if (form.IsSavedNewCondition)
                {
                    this.InitModelOperate();
                    RunInfo.Instance.MainForm.RefreshQueryOperateRibbonUI(this);
                }
            }
            else if (operate.Operate == OperateTypes.MyQuery.ToString())
            {
                DoConditionQuery(e.Tag as BaseQueryCondition);
            }
            else if (operate.Operate == OperateTypes.QueryManager.ToString())
            {
                frmCustomQueryEditor editor = new frmCustomQueryEditor();
                editor.QueryName = this.GetType().ToString();
                editor.ShowDialog();

                if (editor.IsModifyedCondition)
                {
                    this.InitModelOperate();
                    RunInfo.Instance.MainForm.RefreshQueryOperateRibbonUI(this);
                }
            }
            else if (operate.Operate == OperateTypes.PrintList.ToString())
            {
                PrinterHelper.PrintControl(this.isPrintLandscape, this.GetPrintView().GridControl);

            }
            else if (operate.Operate == OperateTypes.Print.ToString())
            {
                this.PrintItem();
            }
        }

        protected virtual void DoCommonQuery(string queryName)
        {

        }

        protected virtual void DoConditionQuery(BaseQueryCondition condition)
        {

        }

        protected virtual QueryConditionEditorForm CreateConditionEditorForm()
        {
            return null;
        }

        protected bool AutoRegeditGridViewDoubleClick = true;

        protected Dictionary<GridView, ActionWithPermission> gridViewAction = new Dictionary<GridView, ActionWithPermission>();

        protected virtual void InitGridViewAction()
        {

        }

        private void frmBaseQueryForm_Load(object sender, EventArgs e)
        {
            //this.LoadGridViews()[0].IndicatorWidth = 45;
            //this.LoadGridViews()[0].CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(frmBaseQueryForm_CustomDrawRowIndicator);
            this.InitGridViewAction();

            if (this.AutoRegeditGridViewDoubleClick)
            {
                List<GridView> gvList = LoadGridViews();

                foreach (GridView gv in gvList)
                {
                    gv.MouseDown += new MouseEventHandler(gv_MouseDown);
                    gv.DoubleClick += new EventHandler(gv_DoubleClick);
                }

            }
        }
        private GridHitInfo hInfo;

        private void gv_DoubleClick(object sender, EventArgs e)
        {
            GridView gv = sender as GridView;

            if (hInfo.InRow)
            {
                if (gridViewAction.ContainsKey(gv))
                {
                    ActionWithPermission action = gridViewAction[gv];
                    if (action != null && action.MainAction != null && CheckPermission(action.MainOperate))
                    {
                        action.MainAction.Invoke();
                    }
                    else if (action != null && action.SecondAction != null && CheckPermission(action.SecondOperate))
                    {
                        action.SecondAction.Invoke();
                    }
                }
            }
        }

        private void gv_MouseDown(object sender, MouseEventArgs e)
        {

            GridView gv = sender as GridView;

            hInfo = gv.CalcHitInfo(e.Y, e.Y);
        }

        private void frmBaseQueryForm_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private List<GridView> LoadGridViews()
        {
            if (this.gridViewList == null)
            {
                this.gridViewList = new List<GridView>();
                foreach (Control c in this.Controls)
                {
                    GetGridViews(ref gridViewList, c);
                }
            }
            return this.gridViewList;
        }

        private void GetGridViews(ref  List<GridView> list, Control control)
        {
            if (control is GridControl)
            {
                GridControl gc = control as GridControl;

                foreach (var view in gc.Views)
                {
                    if (view is GridView)
                    {
                        list.Add(view as GridView);
                    }
                }
            }
            else
            {
                foreach (Control c in control.Controls)
                {
                    if (c.Controls.Count > 0)
                    {
                        GetGridViews(ref list, c);
                    }
                }
            }


        }

        protected void RegeditQueryOperate<T>(bool supportCustomCondition, List<string> commonQueryConditions, string caption) where T : BaseQueryCondition
        {
            if (commonQueryConditions != null && commonQueryConditions.Count > 0)
            {
                ModelOperate mo = ModelOperateHelper.GetOperate(OperateTypes.CommonQuery, caption, UITypes.LargeMenu, commonQueryConditions);

                this.ModelOperateRegistry.Add(mo);

            }

            if (supportCustomCondition)
            {
                ModelOperate mo = ModelOperateHelper.GetOperate(OperateTypes.CustomQuery);

                this.ModelOperateRegistry.Add(mo);
            }

            List<T> condition = UIEntity.QueryConditionHelper.GetExistCondition<T>(this.GetType().ToString());

            if (condition.Count > 0)
            {
                this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.MyQuery, "我的查询", UITypes.LargeMenu, condition));
                this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.QueryManager));
            }
        }
        
        protected void RegeditPrintOperate(bool isPrintLandscape = true, bool supposePrintItem = true, GridView printListGridView = null)
        {
            this.isPrintLandscape = isPrintLandscape;
            this.printGridView = printListGridView;
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.PrintList));
            if (supposePrintItem)
            {
                this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Print));
            }
        }

        private GridView GetPrintView()
        {
            return this.printGridView == null ? this.LoadGridViews()[0] : printGridView; ;
        }

        protected virtual void PrintItem()
        {

        }
    }
}