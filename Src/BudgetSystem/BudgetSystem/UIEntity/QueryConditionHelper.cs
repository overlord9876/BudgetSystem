using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity.QueryCondition;

namespace BudgetSystem.UIEntity
{
    public class QueryConditionHelper
    {
        public static string GetQuerySaveFileName(string queryName)
        {
            string fileName = System.IO.Path.Combine(Environment.CurrentDirectory, "Query");
            if (!System.IO.Directory.Exists(fileName))
            {
                System.IO.Directory.CreateDirectory(fileName);
            }

            fileName = System.IO.Path.Combine(fileName, queryName + ".json");
            return fileName;
        }

        public static List<T> GetExistCondition<T>(string queryName) where T : Entity.QueryCondition.BaseQueryCondition
        {
            string queryFileName = GetQuerySaveFileName(queryName);
            try
            {
                if (System.IO.File.Exists(queryFileName))
                {
                    string str = System.IO.File.ReadAllText(queryFileName, Encoding.UTF8);
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(str);
                }
                return new List<T>();
            }
            catch
            {
                return new List<T>();
            }
        }

        public static void SaveCondition<T>(List<T> conditions,string queryName) where T:Entity.QueryCondition.BaseQueryCondition
        {
            try
            {

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(conditions);

                System.IO.File.WriteAllText(QueryConditionHelper.GetQuerySaveFileName(queryName), json, Encoding.UTF8);

            }
            catch
            {

            }


        }


    }
}
