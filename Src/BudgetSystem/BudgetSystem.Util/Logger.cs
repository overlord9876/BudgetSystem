using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace BudgetSystem.Util
{
    public class Logger
    {
        private readonly string logFilePath;

        public Logger(string logFilePath)
        {
            this.logFilePath = string.IsNullOrEmpty(logFilePath.Trim()) ? "" : logFilePath;
            CreateFolder();
        }

        private void CreateFolder()
        {
            if (!System.IO.Directory.Exists(this.logFilePath))
            {
                System.IO.Directory.CreateDirectory(this.logFilePath);
            }
        }

        private void Log(string type, string head, string context, bool extendDateToFileName = true)
        {
            string fileName;
            if (extendDateToFileName)
            {
                fileName = System.IO.Path.Combine(this.logFilePath, type + DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
            }
            else
            {
                fileName = System.IO.Path.Combine(this.logFilePath, type + ".txt");
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("{0} : {1}", head, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            sb.AppendLine(context);

            SaveToLogFile(fileName, sb.ToString());
        }

        public void LogError(Exception ex)
        {
            if (ex != null)
            {
                LogError(ex.ToString());
            }
        }

        public void LogError(string context)
        {
            this.Log("error", "error", context);
            this.Log("info", "error", context, true);
        }

        [Conditional("DEBUG")]
        public void LogInfomation(string context)
        {
            this.Log("info", "info", context);
        }

        private void SaveToLogFile(string fileName, string context)
        {
            try
            {
                using (var stream = System.IO.File.AppendText(fileName))
                {
                    stream.Write(context);
                    stream.Close();
                }
            }
            catch
            {

            }
        }
    }
}
