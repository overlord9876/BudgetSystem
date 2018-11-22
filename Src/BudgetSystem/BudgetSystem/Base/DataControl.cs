using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BudgetSystem.UIEntity;

namespace BudgetSystem
{
    public partial class DataControl : UserControl,IDataControl
    {
        public DataControl()
        {
            InitializeComponent();
        }

        public void BindingData(int dataID)
        {
            this.BackColor = Color.Red;
            this.Width = 800;
            this.Height = 600;

        }
    }
}
