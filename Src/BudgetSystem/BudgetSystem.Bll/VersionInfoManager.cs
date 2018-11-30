using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Linq;
namespace BudgetSystem.Bll
{
    public class VersionInfoManager : BaseManager
    {
        Dal.VersionDal dal = new Dal.VersionDal();
     

        public bool VersionExist(string version)
        {
            var versionFile = this.Query<VersionFile>((con) =>
            {
                return dal.GetTopVersionInfoFile(version, con, null);
            });
            return versionFile != null;
        }

        public void AddVersion(SystemInfo info,  List<VersionFile> files)
        {
            Dal.SystemConfigDal sd = new Dal.SystemConfigDal();
            this.ExecuteWithTransaction((con, tran) =>
            {
                dal.AddVerisonInfoFiles(files, con, tran);
                sd.InsertOrModifySystemConfig("SystemInfo", Newtonsoft.Json.JsonConvert.SerializeObject(info), con, tran);
            });
        }


    }
}
