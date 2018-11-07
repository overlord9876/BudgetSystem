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


        protected bool CheckPermission(OperateTypes operate)
        {
            string permission = this.Module +"." +operate.ToString();

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


        public virtual void OperateHandled(ModelOperate operate)
        {

            
        }

        protected bool AutoRegeditGridViewDoubleClick = true;

        protected Dictionary<GridView, ActionWithPermission> gridViewAction = new Dictionary<GridView, ActionWithPermission>();

        protected virtual void InitGridViewAction()
        {
        
        }

        private void frmBaseQueryForm_Load(object sender, EventArgs e)
        {
            this.InitGridViewAction();
            if (this.AutoRegeditGridViewDoubleClick)
            {
                List<GridView> gvList = new List<GridView>();
                foreach (Control c in this.Controls)
                {
                    GetGridViews(ref gvList, c);
                }
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
                    if (action != null && action.MainAction!=null && CheckPermission(action.MainOperate))
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


        private void GetGridViews(ref  List<GridView> list,Control control)
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




    }
}