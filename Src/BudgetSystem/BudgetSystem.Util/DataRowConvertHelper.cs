using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BudgetSystem.Util
{
    public static class DataRowConvertHelper
    {
        /// <summary>
        /// 获取的Guid类型值
        /// </summary>
        /// <param name="r">所在行</param>
        /// <param name="name">所在列</param>
        /// <returns>
        /// GUID值
        /// 如果发生错误返回Guid.Empty
        /// </returns>
        public static Guid GetGuidValue(DataRow r, string name)
        {
            Guid result = Guid.Empty;

            if (r[name] != null && r[name] != DBNull.Value && !string.IsNullOrEmpty(r[name].ToString()))
            {
                try
                {
                    result = (Guid)Convert.ChangeType(r[name], typeof(Guid));
                }
                catch
                {

                }
            }

            return result;
        }
        /// <summary>
        /// 获取的String类型值
        /// </summary>
        /// <param name="r">所在行</param>
        /// <param name="name">所在列</param>
        /// <returns>
        /// 字符串
        /// </returns>
        public static string GetStringValue(DataRow r, string name)
        {
            string result = "";

            if (r[name] != null && r[name] != DBNull.Value)
            {
                result = r[name].ToString();
            }

            return result;
        }

        /// <summary>
        /// 获取的Int类型值
        /// </summary>
        /// <param name="r">所在行</param>
        /// <param name="name">所在列</param>
        /// <returns>
        /// Int值
        /// 如果发生错误返回int.MinValue;
        /// </returns>
        public static int GetIntValue(DataRow r, string name)
        {
            int result = int.MinValue;

            if (r[name] != null && r[name] != DBNull.Value && !string.IsNullOrEmpty(r[name].ToString()))
            {
                try
                {
                    result = Convert.ToInt32(r[name]);
                }
                catch
                {
                }
            }

            return result;
        }

        /// <summary>
        /// 获取的double类型值
        /// </summary>
        /// <param name="r">所在行</param>
        /// <param name="name">所在列</param>
        /// <returns>
        /// double值
        /// 如果发生错误返回double.MinValue;
        /// </returns>
        public static double GetDoubleValue(DataRow r, string name)
        {
            double result = double.MinValue;

            if (r[name] != null && r[name] != DBNull.Value && !string.IsNullOrEmpty(r[name].ToString()))
            {
                try
                {
                    result = Convert.ToDouble(r[name]);
                }
                catch
                {
                }
            }
            return result;
        }


        /// <summary>
        /// Decimal
        /// </summary>
        /// <param name="r">所在行</param>
        /// <param name="name">所在列</param>
        /// <returns>
        /// Decimal
        /// 如果发生错误返回0;
        /// </returns>
        public static decimal GetDecimalValue(DataRow r, string name)
        {
            decimal result = 0;

            if (r[name] != null && r[name] != DBNull.Value && !string.IsNullOrEmpty(r[name].ToString()))
            {
                try
                {
                    string value = r[name].ToString();
                    value = value.Replace("$", "").Replace("￥", "");
                    result = Convert.ToDecimal(value);
                }
                catch
                {
                }
            }

            return result;
        }
        /// <summary>
        /// Decimal
        /// </summary>
        /// <param name="r">所在行</param>
        /// <param name="name">所在列</param>
        /// <returns>
        /// float
        /// 如果发生错误返回0;
        /// </returns>
        public static float GetFloatValue(DataRow r, string name)
        {
            float result = 0;

            if (r[name] != null && r[name] != DBNull.Value && !string.IsNullOrEmpty(r[name].ToString()))
            {
                try
                {
                    result = Convert.ToSingle(r[name]);
                }
                catch
                {
                }
            }

            return result;
        }
        /// <summary>
        /// 获取的Datetime类型值
        /// </summary>
        /// <param name="r">所在行</param>
        /// <param name="name">所在列</param>
        /// <returns>
        /// datetime值
        /// 如果发生错误返回DateTime.MinValue;
        /// </returns>
        public static DateTime GetDateTimeValue(DataRow r, string name, string ignore = "")
        {
            DateTime result = DateTime.MinValue;

            if (r[name] != null && r[name] != DBNull.Value && !string.IsNullOrEmpty(r[name].ToString()))
            {
                try
                {
                    if (!string.IsNullOrEmpty(ignore))
                    {
                        result = Convert.ToDateTime(r[name].ToString().Replace("\"", ""));
                    }
                    else
                    {
                        result = Convert.ToDateTime(r[name]);
                    }
                }
                catch
                {

                }
            }

            return result;
        }
        /// <summary>
        /// 获取的Datetime类型值
        /// </summary>
        /// <param name="r">所在行</param>
        /// <param name="name">所在列</param>
        /// <returns>
        /// datetime值
        /// 如果发生错误返回DateTime.MinValue;
        /// </returns>
        public static DateTime? GetDateTimeValue_AllowNull(DataRow r, string name, string ignore = "")
        {
            DateTime? result = null;
            if (r[name] != null && r[name] != DBNull.Value && !string.IsNullOrEmpty(r[name].ToString()))
            {
                try
                {
                    if (r[name].ToString().Trim().StartsWith("***"))
                    {
                        return new DateTime(2199, 1, 1);
                    }

                    if (!string.IsNullOrEmpty(ignore))
                    {
                        result = Convert.ToDateTime(r[name].ToString().Replace("\"", ""));
                    }
                    else
                    {
                        result = Convert.ToDateTime(r[name]);
                    }
                }
                catch
                {

                }
            }

            return result;
        }
        /// <summary>
        /// 获取的Bool类型值
        /// </summary>
        /// <param name="r">所在行</param>
        /// <param name="name">所在列</param>
        /// <returns>
        /// Bool值
        /// 如果发生错误返回false
        /// </returns>
        public static bool GetBoolValue(DataRow r, string name)
        {
            bool result = false;

            if (r[name] != null && r[name] != DBNull.Value && !string.IsNullOrEmpty(r[name].ToString()))
            {
                try
                {
                    result = Convert.ToBoolean(r[name]);
                }
                catch
                {

                }
            }
            return result;
        }
        /// <summary>
        /// 获取枚举对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="r"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T GetEnumValue<T>(DataRow r, string name)
        {
            Type type = typeof(T);

            if (!type.IsEnum)
            {
                throw new Exception("GetEnumValue<T>只接受Enum的泛型类型");
            }
            string value = GetStringValue(r, name);
            return (T)Enum.Parse(typeof(T), value);
        }

    }
}
