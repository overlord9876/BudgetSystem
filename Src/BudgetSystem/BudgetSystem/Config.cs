using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem
{
    public class Config
    {
        private static string configFileName = "config.json";


        public static Config  Read()
        {
            Config config = null; 
            if (System.IO.File.Exists(configFileName))
            {
                string str = System.IO.File.ReadAllText(configFileName,Encoding.GetEncoding("gb2312"));
                if (!string.IsNullOrEmpty(str))
                {
                    try
                    {
                       config= Newtonsoft.Json.JsonConvert.DeserializeObject<Config>(str);
                    }
                    catch
                    { 
                    
                    }
                }
            }

            if (config == null)
            {
                config = new Config();
            }

            return config;
        }

        public void Save()
        {
            try
            {
                string str = Newtonsoft.Json.JsonConvert.SerializeObject(this);
                System.IO.File.WriteAllText(configFileName, str, Encoding.GetEncoding("gb2312"));
            }
            catch
            { 
            
            }
           
        }

        public string SkinName
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }



    }

   
}
