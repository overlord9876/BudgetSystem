﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace BudgetSystem.Util
{
    public class MD5
    {
        public static string GetMD5HashFromFile(string fileName)
        {

            FileStream file = new FileStream(fileName, System.IO.FileMode.Open);
            System.Security.Cryptography.MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(file);
            file.Close();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
