using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraBars;
using BudgetSystem.Entity;

namespace BudgetSystem
{
    public class ModelOperate
    {

        public ModelOperate(OperateTypes operate, string text, string groupText, int order,int imageIndex, UITypes uiType = UITypes.LargeButton)
           : this(operate.ToString(), text, groupText, order,imageIndex, uiType)
        {
            
        }

        public ModelOperate(string operate, string text, string groupText, int order, int imageIndex,UITypes uiType = UITypes.LargeButton)
        {
            this.Operate = operate;
            this.Text = text;
            this.GroupText = groupText;
            this.Order = order;
            this.ImageIndex = imageIndex;
            this.UIType = uiType;
        }

        public string Operate
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }

        public string GroupText
        {
            get;
            set;
        }

        public int Order
        {
            get;
            set;
        }

        public int ImageIndex
        {
            get;
            set;
        }

        public UITypes UIType
        {
            get;
            set;
        }


        /// <summary>
        /// 现在看来只需要处理Button不用支持扩展的控制数据
        /// 如果要支持CheckBox，CheckedButton一类的，还需要处理额外的控制状态数据。
        /// </summary>
        public object UIElementData
        {
            get;
            set;
        }

    }
}
