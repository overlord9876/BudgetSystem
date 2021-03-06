﻿using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraScheduler.Localization;

namespace DevExpress.Localization.Zh_Chs
{
    public class SchedulerLocalizer_zhchs : SchedulerLocalizer
    {
        public override string Language
        { get { return "简体中文"; } }
        public override string GetLocalizedString(SchedulerStringId id)
        {
            switch (id)
            {
                case SchedulerStringId.MenuCmd_AppointmentLabelPhoneCall: return "电话";
                case SchedulerStringId.PrintTimeIntervalControlInvalidStartEndTime: return "结束日期不能小于开始日期";
                case SchedulerStringId.MenuCmd_ShowTimeAs: return "显示时间为";
                case SchedulerStringId.MenuCmd_OtherSettings: return "其他设置...";
                case SchedulerStringId.PrintCalendarDetailsControlDayPeriod: return "日";
                case SchedulerStringId.Caption_15Minutes: return "15 分钟";
                case SchedulerStringId.MenuCmd_AppointmentLabelNone: return "没有";
                case SchedulerStringId.Caption_RecurrenceEndTime: return "结束时间:";
                case SchedulerStringId.Format_TimeBeforeStart: return "{0} 开始之前";
                case SchedulerStringId.Msg_OverflowTimeOfDayInterval: return "TimeOfDayInterval的无效值。 应该小于或者等于一天";
                case SchedulerStringId.MenuCmd_5Minutes: return "5 分钟";
                case SchedulerStringId.Caption_RecurrenceShowTimeAs: return "显示时间为:";
                case SchedulerStringId.Msg_InvalidDayNumberValue: return "无效的天数值。请输入从整数值从1到 {0}。";
                case SchedulerStringId.TextWeeklyPatternString_EveryWeeks: return "{0} {1} on {2} {3}";
                case SchedulerStringId.Caption_WeekOfMonthSecond: return "第二周";
                case SchedulerStringId.Msg_Conflict: return "编辑的日程安排与其他日程安排相冲突。";
                case SchedulerStringId.Msg_InvalidWeekCount: return "无效的周数数值。 请输入一个正整数值。";
                case SchedulerStringId.MenuCmd_NewRecurringAppointment: return "新建定期日程安排";
                case SchedulerStringId.Msg_InvalidWeekCountValue: return "无效的周数数值。请输入一个正整数值。";
                case SchedulerStringId.MenuCmd_Busy: return "忙碌";
                case SchedulerStringId.MenuCmd_Free: return "空闲";
                case SchedulerStringId.Caption_ShadingApplyToCells: return "单元";
                case SchedulerStringId.Caption_RecurrenceSubject: return "主题:";
                case SchedulerStringId.Abbr_Months: return "月";
                case SchedulerStringId.Abbr_Minute: return "分钟";
                case SchedulerStringId.Caption_DecreaseVisibleResourcesCount: return "减少可见资源数目";
                case SchedulerStringId.MenuCmd_AppointmentLabelBirthday: return "生日";
                case SchedulerStringId.Msg_WarningDayNumber: return "某些月份会少于{0}天数。对于这些月份来说，这将会发生在月份的最后一天。";
                case SchedulerStringId.MenuCmd_DeleteAppointment: return "删除";
                case SchedulerStringId.AppointmentLabel_Birthday: return "生日";
                case SchedulerStringId.Caption_Tentative: return "暂时";
                case SchedulerStringId.Caption_5Minutes: return "5 分钟";
                case SchedulerStringId.PrintWeeklyOptControlTwoWeekPerPage: return "2 页/周";
                case SchedulerStringId.Caption_RecurrencePattern: return "循环模式:";
                case SchedulerStringId.Caption_PleaseSeeAbove: return "请看上面";
                case SchedulerStringId.Abbr_Minutes: return "分钟";
                case SchedulerStringId.TextDuration_FromForDaysHours: return "从 {0} 开始延续 {1} {2}";
                case SchedulerStringId.PrintPageSetupFormatTabControlSizeAndFontName: return "{0} pt. {1}";
                case SchedulerStringId.Caption_ResourceAll: return "(All)";
                case SchedulerStringId.TextDailyPatternString_EveryWeekend: return "每个周末 {0}";
                case SchedulerStringId.TextDailyPatternString_EveryWeekDay: return "每个周日 {0}";
                case SchedulerStringId.Msg_LoadCollectionFromXml: return "日程安排器要求以菲绑定的方式来从xml数据源中导入数据项。";
                case SchedulerStringId.Caption_ColorConverterBlackAndWhite: return "单色";
                case SchedulerStringId.Caption_60Minutes: return "60 分钟";
                case SchedulerStringId.Abbr_DaysShort: return "d";
                case SchedulerStringId.MenuCmd_AppointmentLabelTravelRequired: return "要求旅游";
                case SchedulerStringId.PrintPageSetupFormCaption: return "打印选项: {0}";
                case SchedulerStringId.Abbr_MinutesShort2: return "min";
                case SchedulerStringId.Abbr_MinutesShort1: return "m";
                case SchedulerStringId.Caption_ShadingApplyToAppointments: return "日程安排";
                case SchedulerStringId.MenuCmd_AppointmentLabelBusiness: return "商务";
                case SchedulerStringId.PrintMonthlyOptControlTwoPagesPerMonth: return "2 页/月";
                case SchedulerStringId.Caption_MonthlyPrintStyle: return "月风格";
                case SchedulerStringId.MenuCmd_CustomizeTimeRuler: return "自定义时间标尺...";
                case SchedulerStringId.Abbr_Day: return "日";
                case SchedulerStringId.MenuCmd_PrintAppointment: return "打印";
                case SchedulerStringId.Caption_WeekOfMonthFourth: return "第四周";
                case SchedulerStringId.MenuCmd_AppointmentLabelMustAttend: return "必须 &出席";
                case SchedulerStringId.Caption_ResourceNone: return "(None)";
                case SchedulerStringId.Caption_DailyPrintStyle: return "日风格";
                case SchedulerStringId.Msg_InvalidYearCount: return "无效的年份数值。请输入一个正整数值。";
                case SchedulerStringId.Caption_Recurrence: return "循环:";
                case SchedulerStringId.MenuCmd_SwitchToDayView: return "日视图";
                case SchedulerStringId.TextDuration_FromForDaysHoursMinutes: return "从 {0} 开始延续 {1} {2} {3}";
                case SchedulerStringId.MenuCmd_SwitchViewMenu: return "更改视图到";
                case SchedulerStringId.AppointmentLabel_Business: return "商务";
                case SchedulerStringId.Msg_InvalidDayCountValue: return "无效天数数值。 请输入一个正整数值。";
                case SchedulerStringId.MenuCmd_Tentative: return "暂时";
                case SchedulerStringId.PrintNoPrintersInstalled: return "没有安装打印机。";
                case SchedulerStringId.MenuCmd_CustomizeCurrentView: return "自定义当前视图...";
                case SchedulerStringId.TextDuration_FromForDaysMinutes: return "从 {0} 开始延续 {1} {3}";
                case SchedulerStringId.MenuCmd_6Minutes: return "6 分钟";
                case SchedulerStringId.MenuCmd_AppointmentMove: return "移动";
                case SchedulerStringId.MenuCmd_AppointmentCopy: return "拷贝";
                case SchedulerStringId.Caption_Free: return "空闲";
                case SchedulerStringId.Caption_Busy: return "忙碌";
                case SchedulerStringId.Caption_ShadingApplyToAllDayArea: return "全天范围";
                case SchedulerStringId.PrintTriFoldOptControlWeeklyCalendar: return "周历";
                case SchedulerStringId.Msg_InvalidOccurrencesCountValue: return "无效的发生次数。请输入一个正整数值。";
                case SchedulerStringId.AppointmentLabel_PhoneCall: return "电话";
                case SchedulerStringId.MenuCmd_20Minutes: return "20 分钟";
                case SchedulerStringId.Caption_OutOfOffice: return "不在办公室";
                case SchedulerStringId.AppointmentLabel_TravelRequired: return "要求旅游";
                case SchedulerStringId.AppointmentLabel_Anniversary: return "周年纪念日";
                case SchedulerStringId.MenuCmd_AppointmentLabelNeedsPreparation: return "需要准备";
                case SchedulerStringId.PrintRangeControlInvalidDate: return "结束日期必须大于或者等于开始日期。";
                case SchedulerStringId.TextMonthlyPatternString_SubPattern: return "每 {0} {1} {2}";
                case SchedulerStringId.Caption_IncreaseVisibleResourcesCount: return "增加可见资源数目";
                case SchedulerStringId.ViewDisplayName_Month: return "月历";
                case SchedulerStringId.MenuCmd_NewRecurringEvent: return "新建定期事件";
                case SchedulerStringId.ViewDisplayName_Day: return "日历";
                case SchedulerStringId.MenuCmd_NewAppointment: return "新建日程安排";
                case SchedulerStringId.PrintMonthlyOptControlOnePagePerMonth: return "1 页/月";
                case SchedulerStringId.Msg_InvalidOccurrencesCount: return "无效的发生次数。请输入一个正整数值。";
                case SchedulerStringId.ViewDisplayName_WorkDays: return "工作周历";
                case SchedulerStringId.MenuCmd_SwitchToWeekView: return "周视图";
                case SchedulerStringId.MenuCmd_15Minutes: return "15 分钟";
                case SchedulerStringId.Msg_InvalidAppointmentDuration: return "无效的间隔时长值。请输入一个正数值。";
                case SchedulerStringId.MenuCmd_AppointmentLabelImportant: return "重要";
                case SchedulerStringId.PrintCalendarDetailsControlWeekPeriod: return "周";
                case SchedulerStringId.MenuCmd_AppointmentLabelPersonal: return "个人";
                case SchedulerStringId.TextDuration_FromTo: return "从{0} 到 {1}";
                case SchedulerStringId.MenuCmd_10Minutes: return "10 分钟";
                case SchedulerStringId.MemoPrintDateFormat: return "{0} {1} {2}";
                case SchedulerStringId.Caption_RecurrenceLocation: return "地点:";
                case SchedulerStringId.Msg_XtraSchedulerNotAssigned: return "控件SchedulerStorage没有指定分配到控件SchedulerControl上";
                case SchedulerStringId.Caption_ColorConverterFullColor: return "全色";
                case SchedulerStringId.Caption_ColorConverterGrayScale: return "灰度色标";
                case SchedulerStringId.Caption_UntitledAppointment: return "无标题";
                case SchedulerStringId.MenuCmd_OpenAppointment: return "打开";
                case SchedulerStringId.AppointmentLabel_NeedsPreparation: return "需要准备";
                case SchedulerStringId.Caption_10Minutes: return "10 分钟";
                case SchedulerStringId.Abbr_HoursShort: return "h";
                case SchedulerStringId.TextYearlyPattern_YearString2: return "第 {0} {1} of {2} {5}";
                case SchedulerStringId.TextYearlyPattern_YearString1: return "每 {0} {1} {4}";
                case SchedulerStringId.MenuCmd_GotoToday: return "跳转到某一天";
                case SchedulerStringId.Caption_ShadingApplyToTimeRulers: return "时间标尺";
                case SchedulerStringId.PrintTimeIntervalControlInvalidDuration: return "间隔时间必须大于0且小于等于一天。";
                case SchedulerStringId.Caption_TrifoldPrintStyle: return "三重风格 Style";
                case SchedulerStringId.Caption_StartTime: return "开始时间: {0}";
                case SchedulerStringId.TextDuration_ForPattern: return "{0} {1}";
                case SchedulerStringId.TextYearlyPattern_YearsString1: return "{0} {1} of every {2} {3} {4}";
                case SchedulerStringId.TextYearlyPattern_YearsString2: return "第 {0} {1} of {2} 每 {3} {4} {5}";
                case SchedulerStringId.Msg_InternalError: return "内部错误!";
                case SchedulerStringId.Caption_30Minutes: return "30 分钟";
                case SchedulerStringId.Caption_WeeklyPrintStyle: return "周风格";
                case SchedulerStringId.Caption_WeekDaysWeekendDays: return "周末";
                case SchedulerStringId.MenuCmd_RestoreOccurrence: return "恢复默认状态";
                case SchedulerStringId.PrintWeeklyOptControlOneWeekPerPage: return "1 页/周";
                case SchedulerStringId.MenuCmd_NewAllDayEvent: return "新建所有当天事件";
                case SchedulerStringId.Msg_InvalidDayNumber: return "无效的天数值。请输入从整数值从1到 {0}。";
                case SchedulerStringId.TextDailyPatternString_EveryDay: return "每 {0} {1}";
                case SchedulerStringId.Caption_20Minutes: return "20 分钟";
                case SchedulerStringId.Msg_InvalidMonthCount: return "无效的月份数值。 请输入一个正整数值。";
                case SchedulerStringId.AppointmentLabel_MustAttend: return "必须出席";
                case SchedulerStringId.Msg_InvalidDayOfWeek: return "没有选择日。请至少选择一周之中的一天。";
                case SchedulerStringId.MenuCmd_SwitchToMonthView: return "月视图";
                case SchedulerStringId.PrintCalendarDetailsControlMonthPeriod: return "月";
                case SchedulerStringId.Msg_InvalidDayOfWeekForDailyRecurrence: return "对于日期引用来说，是一个无效的周日数值. 只有周日.每天, 周日.周末和周日 .在当前上下文内，周日数值有效.";
                case SchedulerStringId.MenuCmd_EditSeries: return "编辑系列";
                case SchedulerStringId.Msg_InvalidEndDate: return "你输入的结束日期在起始日期之前。";
                case SchedulerStringId.PrintTriFoldOptControlMonthlyCalendar: return "月历";
                case SchedulerStringId.MenuCmd_OutOfOffice: return "不在办公室";
                case SchedulerStringId.AppointmentLabel_Personal: return "个人";
                case SchedulerStringId.MenuCmd_GotoThisDay: return "跳转到这一天";
                case SchedulerStringId.Caption_CalendarDetailsPrintStyle: return "日历风格";
                case SchedulerStringId.MenuCmd_GotoDate: return "跳转到某日期...";
                case SchedulerStringId.Abbr_WeeksShort: return "w";
                case SchedulerStringId.Caption_EmptyResource: return "(Any)";
                case SchedulerStringId.AppointmentLabel_Vacation: return "假期";
                case SchedulerStringId.MenuCmd_AppointmentCancel: return "取消";
                case SchedulerStringId.PrintPageSetupFormatTabControlCustomizeShading: return "<自定义...>";
                case SchedulerStringId.MenuCmd_30Minutes: return "30 分钟";
                case SchedulerStringId.Msg_IsNotValid: return "'{0}' 不是一个有效值，对于 '{1}'来说";
                case SchedulerStringId.Msg_InvalidMonthCountValue: return "无效的月份数值。请输入一个正整数值。";
                case SchedulerStringId.MenuCmd_AppointmentLabelAnniversary: return "周年纪念日";
                case SchedulerStringId.TextDailyPatternString_EveryDays: return "每 {0} {1} {2}";
                case SchedulerStringId.AppointmentLabel_Important: return "重要";
                case SchedulerStringId.MenuCmd_SwitchToWorkWeekView: return "工作周视图";
                case SchedulerStringId.ViewDisplayName_Week: return "周历";
                case SchedulerStringId.PrintMoreItemsMsg: return "更多选项...";
                case SchedulerStringId.TextWeekly_7Day: return "{0}, {1}, {2}, {3}, {4}, {5}, 和 {6}";
                case SchedulerStringId.TextWeekly_6Day: return "{0}, {1}, {2}, {3}, {4}, 和 {5}";
                case SchedulerStringId.TextWeekly_3Day: return "{0}, {1}, 和 {2}";
                case SchedulerStringId.TextWeekly_2Day: return "{0} 和 {1}";
                case SchedulerStringId.TextWeekly_5Day: return "{0}, {1}, {2}, {3}, 和 {4}";
                case SchedulerStringId.TextWeekly_4Day: return "{0}, {1}, {2}, 和 {3}";
                case SchedulerStringId.TextWeekly_1Day: return "{0}";
                case SchedulerStringId.Caption_RecurrenceStartTime: return "起始时间:";
                case SchedulerStringId.MenuCmd_60Minutes: return "60 分钟";
                case SchedulerStringId.Caption_WeekDaysEveryDay: return "日";
                case SchedulerStringId.AppointmentLabel_None: return "没有";
                case SchedulerStringId.MenuCmd_AppointmentLabelVacation: return "假期";
                case SchedulerStringId.Caption_AllDay: return "全天";
                case SchedulerStringId.Caption_ShadingApplyToAppointmentStatuses: return "日程安排状态";
                case SchedulerStringId.Caption_6Minutes: return "6 分钟";
                case SchedulerStringId.Msg_InvalidReminderTimeBeforeStart: return "无效的事件提醒时间值。 请输入一个正数值。";
                case SchedulerStringId.TextWeeklyPatternString_EveryWeek: return "每 {2} {3}";
                case SchedulerStringId.Caption_Appointment: return "{0} - 日程安排";
                case SchedulerStringId.Caption_ShadingApplyToHeaders: return "头部";
                case SchedulerStringId.Caption_WeekOfMonthThird: return "第三周";
                case SchedulerStringId.Caption_WeekOfMonthFirst: return "第一周";
                case SchedulerStringId.Caption_Reminders: return "{0} 提醒者";
                case SchedulerStringId.Msg_InvalidDayCount: return "无效天数数值。请输入一个正整数值。";
                case SchedulerStringId.Caption_Event: return "{0} - 事件";
                case SchedulerStringId.Caption_WeekOfMonthLast: return "最后一周";
                case SchedulerStringId.Abbr_Hours: return "小时";
                case SchedulerStringId.Abbr_Years: return "年";
                case SchedulerStringId.Caption_NoneRecurrence: return "(none)";
                case SchedulerStringId.Abbr_Weeks: return "周";
                case SchedulerStringId.Msg_InvalidYearCountValue: return "无效的年份数值。 请输入一个正整数值。";
                case SchedulerStringId.PrintTriFoldOptControlDailyCalendar: return "日历";
                case SchedulerStringId.Abbr_Hour: return "小时";
                case SchedulerStringId.Abbr_Days: return "日";
                case SchedulerStringId.Abbr_Year: return "年";
                case SchedulerStringId.Abbr_Week: return "周";
                case SchedulerStringId.Caption_WeekDaysWorkDays: return "周日";
                case SchedulerStringId.Caption_NAppointmentsAreSelected: return "{0} 日程安排已经选定";
                case SchedulerStringId.Msg_NoMappingForObject: return "以下必需的关于对象{0}的映射没有指定";
                case SchedulerStringId.Caption_MemoPrintStyle: return "备忘录风格";
                case SchedulerStringId.MenuCmd_LabelAs: return "标记为";
                case SchedulerStringId.Msg_InvalidTimeOfDayInterval: return "TimeOfDayInterval的无效的持续时间值";
                case SchedulerStringId.TextDuration_FromForDays: return "从 {0} 开始延续 {1} ";
                case SchedulerStringId.Caption_Reminder: return "{0} 提醒者";

            }
            return base.GetLocalizedString(id);
        }
    }
}
