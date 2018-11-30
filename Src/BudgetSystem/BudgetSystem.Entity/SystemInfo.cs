using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    public class SystemInfo
    {
        public string Version
        {
            get;
            set;
        }

        public DateTime PublishDate
        {
            get;
            set;
        }

        public string Remark
        {
            get;
            set;
        }

        public override string ToString()
        {
            return string.Format("版本号：{0}\r\n说明：{2}\r\n发布日期：{1}", Version, PublishDate.ToString("G"), Remark);
        }
    }
}
