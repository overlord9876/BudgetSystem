
using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Data;
using Dapper_NET20;
using System.Linq;
using Newtonsoft.Json;

namespace BudgetSystem.Dal
{
    public class ModifyMarkDal
    {
        public IEnumerable<ModifyMark> GetAllModifyMark(string type, int dataID, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = @"SELECT *  FROM `ModifyMark`
                                 WHERE `DateItemType` = @DateItemType AND `DataID`=@DataID";
            return con.Query<ModifyMark>(selectSql, new { DateItemType = type, DataID = dataID }, tran);
        }
        public List<T> GetAllModifyMark<T>(int dataID, IDbConnection con, IDbTransaction tran = null)
        {
            IEnumerable<ModifyMark> modifyMarkList = this.GetAllModifyMark(typeof(T).Name, dataID, con, tran);
            List<T> result = new List<T>();
            modifyMarkList.ToList().ForEach(m => result.Add(JsonConvert.DeserializeObject<T>(m.Content)));
            return result;
        }
        public int AddModifyMark<T>(T content, int dataID, IDbConnection con, IDbTransaction tran = null)
        {
            ModifyMark modifyMark = new ModifyMark()
            {
                DataID = dataID,
                DateItemType = typeof(T).Name,
                Content = JsonConvert.SerializeObject(content)
            };
            return this.AddModifyMark(modifyMark, con, tran);
        }
        public int AddModifyMark(ModifyMark modifyMark, IDbConnection con, IDbTransaction tran = null)
        {
            string insertSql = "Insert Into `ModifyMark` (`DateItemType`,`DataID`,`Content`) Values (@DateItemType,@DataID,@Content)";
            int id = con.Insert(insertSql, modifyMark, tran);
            if (id > 0)
            {
                modifyMark.ID = id;
            }
            return id;
        }
        public void DeleteModifyMark<T>(int dataID, IDbConnection con, IDbTransaction tran = null)
        {
            string deleteSql = "Delete From `ModifyMark` Where `DateItemType` = @DateItemType AND `DataID`=@DataID";
            con.Execute(deleteSql, new { DateItemType = typeof(T).Name, DataID = dataID }, tran);
        }

        public void DeleteModifyMark(int id, IDbConnection con, IDbTransaction tran = null)
        {
            string deleteSql = "Delete From `ModifyMark` Where `ID` = @ID";
            con.Execute(deleteSql, new { ID = id }, tran);
        }


    }
}
