using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Report
{

    public class MyDollarFormat : IFormatProvider, ICustomFormatter
    {
        public string NumberToDollar(decimal num)
        {
            return string.Format("${0}", num);
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            return NumberToDollar(decimal.Parse(arg + ""));
        }
    }

    public class MyCNYFormat : IFormatProvider, ICustomFormatter
    {
        public string NumberToDollar(decimal num)
        {
            return string.Format("￥{0}", num);
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            return NumberToDollar(decimal.Parse(arg + ""));
        }
    }
    public class MyDecimalFormat : IFormatProvider, ICustomFormatter
    {
        public string NumberToDollar(decimal num)
        {
            return string.Format("{0}", num);
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            return NumberToDollar(decimal.Parse(arg + ""));
        }
    }
}
