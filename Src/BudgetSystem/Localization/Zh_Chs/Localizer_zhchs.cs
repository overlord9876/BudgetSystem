using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors.Controls;

namespace DevExpress.Localization.Zh_Chs
{
    public class Localizer_zhchs : Localizer
    {
        public override string Language
        { get { return "简体中文"; } }
        public override string GetLocalizedString(StringId id)
        {
            switch (id)
            {
                case StringId.PictureEditOpenFileFilter: return ";*.ico;*.位图文件 (*.bmp)|*.bmp|GIF文件 (*.gif)|*.gif|JPEG文件 (*.jpg;*.jpeg)|*.jpg;*.jpeg|Icon 文件 (*.ico)|*.ico|所有图像文件 |*.bmp;*.gif;*.jpg;*.jpeg;*.ico;*.png;*.tif|所有文件 |*.*";
                case StringId.NavigatorNextButtonHint: return "下一个";
                case StringId.ImagePopupPicture: return "(图像)";
                case StringId.TabHeaderButtonNext: return "向右滚动";
                case StringId.TabHeaderButtonPrev: return "向左滚动";
                case StringId.XtraMessageBoxOkButtonText: return "确定(&O)";
                case StringId.Cancel: return "取消";
                case StringId.DateEditToday: return "今天";
                case StringId.DateEditClear: return "清除";
                case StringId.PictureEditMenuCut: return "剪切";
                case StringId.NavigatorEditButtonHint: return "编辑";
                case StringId.TextEditMenuCut: return "剪切(&t)";
                case StringId.ImagePopupEmpty: return "(空)";
                case StringId.NavigatorNextPageButtonHint: return "下一页";
                case StringId.NavigatorTextStringFormat: return "记录 {0} of {1}";
                case StringId.CaptionError: return "错误";
                case StringId.XtraMessageBoxNoButtonText: return "否(&N)";
                case StringId.PictureEditOpenFileTitle: return "打开";
                case StringId.PictureEditOpenFileError: return "错误的图像格式";
                case StringId.XtraMessageBoxIgnoreButtonText: return "忽略(&I)";
                case StringId.NavigatorRemoveButtonHint: return "删除";
                case StringId.TabHeaderButtonClose: return "关闭";
                case StringId.CheckUnchecked: return "非校验";
                case StringId.PictureEditSaveFileFilter: return "位图文件 (*.bmp)|*.bmp|GIF文件 (*.gif)|*.gif|JPEG 文件 (*.jpg)|*.jpg";
                case StringId.TextEditMenuSelectAll: return "全选(&A)";
                case StringId.PictureEditSaveFileTitle: return "另存为";
                case StringId.DataEmpty: return "没有图像数据";
                case StringId.XtraMessageBoxAbortButtonText: return "中断(&A)";
                case StringId.CheckIndeterminate: return "不确定";
                case StringId.NavigatorLastButtonHint: return "最后一个";
                case StringId.TextEditMenuCopy: return "复制(&C)";
                case StringId.TextEditMenuUndo: return "撤销(&U)";
                case StringId.CalcError: return "计算错误";
                case StringId.CalcButtonBack: return "后退";
                case StringId.CalcButtonSqrt: return "平方根";
                case StringId.LookUpColumnDefaultName: return "名称";
                case StringId.NavigatorEndEditButtonHint: return "结束编辑";
                case StringId.NotValidArrayLength: return "无效的数组长度。";
                case StringId.ColorTabWeb: return "网页";
                case StringId.PictureEditMenuSave: return "保存";
                case StringId.PictureEditMenuCopy: return "复制";
                case StringId.PictureEditMenuLoad: return "调用";
                case StringId.NavigatorFirstButtonHint: return "第一个";
                case StringId.MaskBoxValidateError: return "输入值不完整,是否修正?			是 - 返回编辑器,修正该值.	否 -保留该值.	取消 - 重设为原来的值.	";
                case StringId.UnknownPictureFormat: return "未知的图形格式";
                case StringId.NavigatorPreviousPageButtonHint: return "前一页";
                case StringId.XtraMessageBoxRetryButtonText: return "重试(&R)";
                case StringId.LookUpEditValueIsNull: return "[编辑值为空]";
                case StringId.CalcButtonC: return "C";
                case StringId.XtraMessageBoxCancelButtonText: return "取消";
                case StringId.LookUpInvalidEditValueType: return "无效的 LookUpEdit 编辑值类型。";
                case StringId.NavigatorAppendButtonHint: return "追加";
                case StringId.CalcButtonMx: return "M+";
                case StringId.CalcButtonMC: return "MC";
                case StringId.CalcButtonMS: return "MS";
                case StringId.CalcButtonMR: return "MR";
                case StringId.CalcButtonCE: return "CE";
                case StringId.NavigatorCancelEditButtonHint: return "取消编辑";
                case StringId.PictureEditOpenFileErrorCaption: return "打开错误";
                case StringId.OK: return "确定(&O)";
                case StringId.CheckChecked: return "校验";
                case StringId.TextEditMenuPaste: return "粘贴(&P)";
                case StringId.TextEditMenuDelete: return "删除(&D)";
                case StringId.ColorTabSystem: return "系统";
                case StringId.PictureEditMenuPaste: return "粘贴";
                case StringId.XtraMessageBoxYesButtonText: return "是(&Y)";
                case StringId.InvalidValueText: return "无效值";
                case StringId.PictureEditMenuDelete: return "删除";
                case StringId.NavigatorPreviousButtonHint: return "前一个";
                case StringId.ColorTabCustom: return "自定义";
                case StringId.FilterOutlookDateText: return "显示所有|显示空|根据指定日期筛选|早于今年的|在今年的指定日期之后|在本月的指定日期之后|下周|在本周的指定日期之后|明天|今天|昨天|在本周的指定日期之前|上周|在本月的指定日期之前|在今年的指定日期之前|晚于今年的";



            }
            return base.GetLocalizedString(id);
        }
    }
}
