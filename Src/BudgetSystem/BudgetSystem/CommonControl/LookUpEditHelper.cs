using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace BudgetSystem.CommonControl
{
    public class LookUpEditHelper
    {
        /// <summary>
        /// 设置LookUpEdit枚举类型数据源,LookUpEdit选项值为enum类型
        /// </summary>
        /// <param name="edit"></param>
        /// <param name="enumType"></param>
        public static void FillLookUpEditByEnum_EnumValue(LookUpEdit edit, Type enumType)
        {
            FillLookUpEditByEnum(edit, enumType, "EnumValue");
        }

        /// <summary>
        /// 设置LookUpEdit枚举类型数据源,LookUpEdit选项值为Int类型
        /// </summary>
        /// <param name="edit"></param>
        /// <param name="enumType"></param> 
        public static void FillLookUpEditByEnum_IntValue(LookUpEdit edit, Type enumType)
        {
            FillLookUpEditByEnum(edit, enumType, "IntValue");
        }

        /// <summary>
        /// 设置LookUpEdit枚举类型数据源
        /// </summary>
        /// <param name="edit"></param>
        /// <param name="enumType"></param>
        /// <param name="valueMember">LookUpEdit：EnumValue或IntValue</param>
        public static void FillLookUpEditByEnum(LookUpEdit edit, Type enumType, string valueMember = "EnumValue")
        {
            List<ComboPair> list = new List<ComboPair>();
            foreach (var v in Enum.GetValues(enumType))
            {
                list.Add(new ComboPair(v.ToString(), (int)v));
            }
            edit.Properties.Columns.Clear();
            edit.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text"));
            edit.Properties.DisplayMember = "Text";
            edit.Properties.ValueMember = valueMember;
            edit.Properties.NullText = string.Empty;
            edit.Properties.ShowHeader = false;
            edit.Properties.ShowFooter = false;
            edit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            edit.Properties.DropDownRows = list.Count > 10 ? 10 : list.Count;
            edit.Properties.PopupFormMinSize = new System.Drawing.Size(edit.Width - 15, 0);
            edit.Properties.DataSource = list;
        }

        /// <summary>
        /// 设置RepositoryItemLookUpEdit枚举类型数据源,RepositoryItemLookUpEdit选项值为enum类型
        /// </summary>
        /// <param name="edit"></param>
        /// <param name="enumType"></param>
        public static void FillRepositoryItemLookUpEditByEnum_EnumValue(RepositoryItemLookUpEdit edit, Type enumType)
        {
            FillRepositoryItemLookUpEditByEnum(edit, enumType, "EnumValue");
        }

        /// <summary>
        /// 设置LookUpEdit枚举类型数据源,LookUpEdit选项值为Int类型
        /// </summary>
        /// <param name="edit"></param>
        /// <param name="enumType"></param> 
        public static void FillRepositoryItemLookUpEditByEnum_IntValue(RepositoryItemLookUpEdit edit, Type enumType)
        {
            FillRepositoryItemLookUpEditByEnum(edit, enumType, "IntValue");
        }

        /// <summary>
        /// 设置LookUpEdit枚举类型数据源
        /// </summary>
        /// <param name="edit"></param>
        /// <param name="enumType"></param>
        /// <param name="valueMember">LookUpEdit：EnumValue或IntValue</param>
        public static void FillRepositoryItemLookUpEditByEnum(RepositoryItemLookUpEdit edit, Type enumType, string valueMember = "EnumValue")
        {
            List<ComboPair> list = new List<ComboPair>();
            foreach (var v in Enum.GetValues(enumType))
            {
                list.Add(new ComboPair(v.ToString(), (int)v));
            }
            edit.Columns.Clear();
            edit.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text"));
            edit.DisplayMember = "Text";
            edit.ValueMember = valueMember;
            edit.NullText = string.Empty;
            edit.ShowHeader = false;
            edit.ShowFooter = false;
            edit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            edit.DropDownRows = list.Count > 10 ? 10 : list.Count;
            edit.DataSource = list;
        }

        public class ComboPair
        {
            public ComboPair(string text, object value)
            {
                this.Text = text;
                this.EnumValue = value;
            }

            public string Text
            {
                get;
                set;
            }
            public object EnumValue
            {
                get;
                set;
            }

            public int IntValue
            {
                get
                {
                    return Convert.ToInt32(EnumValue);
                }
            }

            public override string ToString()
            {
                return Text;
            }
        }
    }

}
