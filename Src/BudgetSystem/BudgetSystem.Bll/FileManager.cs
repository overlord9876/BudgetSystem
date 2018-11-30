using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Linq;

namespace BudgetSystem.Bll
{
    public class FileManager : BaseManager
    {
        Dal.FileDal dal = new Dal.FileDal();

        public bool FileExist(string md5)
        {
            var file = this.Query<FileData>((con) =>
            {

                var uList = dal.GetFileWihoutData(md5, con, null);
                return uList;

            });
            return file != null;
        }


        public FileData GetFile(string md5)
        {
            var file = this.Query<FileData>((con) =>
            {

                var uList = dal.GetFileWihData(md5, con, null);
                return uList;

            });
            return file;
        }

        public void AddFile(FileData file)
        {
            this.ExecuteWithoutTransaction((con) => 
            {
                dal.AddFile(file, con, null);
            });
        }
    }
}
