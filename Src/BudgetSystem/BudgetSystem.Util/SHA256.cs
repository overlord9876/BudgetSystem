using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace BudgetSystem.Util
{
    public class SHA256
    {
        public static string ToSHA256(string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            byte[] hash = SHA256Managed.Create().ComputeHash(bytes);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString("X2"));
            }
            return builder.ToString();
        }

    }
}
