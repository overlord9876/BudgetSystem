using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 文件表
    /// </summary>
    public class FileData : IEntity
    {
        /// <summary>
        /// 文件MD5
        /// </summary>
        public string MD5 { get; set; }

        /// <summary>
        /// FileData
        /// </summary>
        public byte[] Data { get; set; }


        public void ReadFile(string fileName)
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
            using (System.IO.FileStream stream = fi.OpenRead())
            {
                Data = new byte[stream.Length];
                stream.Read(Data, 0, (int)stream.Length);
                stream.Close();
            } 
        
        
        }
    }
}
