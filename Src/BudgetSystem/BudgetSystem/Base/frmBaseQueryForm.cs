using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

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

        public string FormID
        {
             get;
             private set;
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
    }
}