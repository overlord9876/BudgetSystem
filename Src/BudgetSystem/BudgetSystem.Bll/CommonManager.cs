using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Linq;

namespace BudgetSystem.Bll
{
    public class CommonManager : BaseManager
    {
        Dal.CommonDal dal = new Dal.CommonDal();

        public int GetNewCode(CodeType ct)
        {
            return this.ExecuteWithTransaction<int>((con, tran) =>
            {
                int codeValue = 1;
                if (dal.ExistsCodeType(ct, con, tran))
                {
                    codeValue = dal.GetCodeValueByType(ct, con, tran);
                    codeValue = codeValue + 1;
                    dal.UpdateCodeGenerator(ct, codeValue, con, tran);
                }
                else
                {
                    dal.AddCodeGenerator(ct, con, tran);
                    codeValue = 1;
                }
                return codeValue;
            });
        }
    }
}
