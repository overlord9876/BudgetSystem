using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Deploy
{
    public class DeployConfig
    {
        private static string configFileName = "config.json";


        public static DeployConfig  Read()
        {
            DeployConfig config = null; 
            if (System.IO.File.Exists(configFileName))
            {
                string str = System.IO.File.ReadAllText(configFileName,Encoding.GetEncoding("gb2312"));
                if (!string.IsNullOrEmpty(str))
                {
                    try
                    {
                       config= Newtonsoft.Json.JsonConvert.DeserializeObject<DeployConfig>(str);
                    }
                    catch
                    { 
                    
                    }
                }
            }

            if (config == null)
            {
                config = new DeployConfig();
                config.ConnectionString = "";
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


        public string VersionCode
        {
            get;
            set;
        }

        public string ConnectionString
        {
            get;
            set;
        }

    }

   
}
