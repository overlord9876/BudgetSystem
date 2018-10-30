using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Newtonsoft.Json;

namespace BudgetSystem.Bll
{
    public class SystenConfigManager : BaseManager
    {
        Dal.SystemConfigDal dal = new Dal.SystemConfigDal();
        /// <summary>
        /// 获取系统配置项的值 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataTable GetSystemConfigValue(string name) 
        {
            string value = this.ExecuteWithoutTransaction<string>((con) =>
            {
                return dal.GetSystemConfigValue(name,con); 
            });
            if (!string.IsNullOrEmpty(value))
            {
                return JsonConvert.DeserializeObject<DataTable>(value);
            }
            else
            {
                return null;
            } 
        } 
        public void ModifySupplier(string name,DataTable dtValue) 
        {
            string value = JsonConvert.SerializeObject(dtValue);
            this.ExecuteWithTransaction((con, tran) =>
            {
                dal.ModifySystemConfig(name,value,con,tran); 
            });
        }
    }
}
