using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Newtonsoft.Json;

namespace BudgetSystem.Bll
{
    public class SystemConfigManager : BaseManager
    {
        Dal.SystemConfigDal dal = new Dal.SystemConfigDal();
        /// <summary>
        /// 获取系统配置项的值 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public T GetSystemConfigValue<T>(string name)
        {
            string value = this.ExecuteWithoutTransaction<string>((con) =>
            {
                return dal.GetSystemConfigValue(name,con); 
            });
            if (!string.IsNullOrEmpty(value))
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            else
            {
                return default(T);
            } 
        }
        public void ModifySystemConfig<T>(string name, T data) 
        {
            string value = JsonConvert.SerializeObject(data);
            this.ExecuteWithTransaction((con, tran) =>
            {
                dal.ModifySystemConfig(name,value,con,tran); 
            });
        }
    }
}
