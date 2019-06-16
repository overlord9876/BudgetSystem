using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Linq;
using BudgetSystem.Entity.QueryCondition;

namespace BudgetSystem.Bll
{
    public class SupplierManager : BaseManager
    {

        Bll.FlowManager fm = new FlowManager();
        Dal.SupplierDal dal = new Dal.SupplierDal();
        Dal.FlowDal fDal = new Dal.FlowDal();
        Dal.ModifyMarkDal mmdal = new Dal.ModifyMarkDal();

        public List<Supplier> GetAllSupplier(SupplierQueryCondition condition = null)
        {
            var lst = this.Query<Supplier>((con) =>
            {
                var uList = dal.GetAllSupplier(con, null, condition);
                return uList;

            });
            return lst.ToList();
        }

        public List<Supplier> GetSupplierListByBudgetId(int budgetId)
        {
            var lst = this.Query<Supplier>((con) =>
            {
                var uList = dal.GetSupplierListByBudgetId(budgetId, con);
                return uList;

            });
            return lst.ToList();
        }

        public Supplier GetSupplier(int id)
        {
            var supplier = this.Query<Supplier>((con) =>
            {
                var uList = dal.GetSupplier(id, con);
                return uList;
            });
            return supplier;
        }

        public int AddSupplier(Supplier supplier)
        {
            return this.ExecuteWithTransaction<int>((con, tran) =>
            {
                int id = dal.AddSupplier(supplier, con, tran);
                return id;
            });
        }

        public void ModifySupplier(Supplier supplier)
        {
            this.ExecuteWithTransaction((con, tran) =>
            {
                dal.ModifySupplier(supplier, con, tran);
            });
        }
        public void ModifySupplierFirstReviewContents(int id, string firstReviewContents)
        {
            this.ExecuteWithTransaction((con, tran) =>
           {
               dal.ModifySupplierFirstReviewContents(id, firstReviewContents, con, tran);
           });
        }

        public void ModifySupplierReviewContents(int id, SupplierReviewContents reviewContents)
        {
            this.ExecuteWithTransaction((con, tran) =>
            {
                if (reviewContents.LeaderResult == null)
                {
                    dal.ModifySupplierReviewContents(id, reviewContents.ToJson(), con, tran);
                }
                else
                {
                    Supplier supplier = GetSupplier(id);
                    supplier.ReviewContents = reviewContents.ToJson();
                    if (reviewContents.LeaderResult == true)
                    {
                        supplier.ReviewDate = supplier.RegistrationDate.Value.AddYears(DateTime.Now.Year - supplier.RegistrationDate.Value.Year + 1);
                    }
                    supplier.Discredited = reviewContents.Discredited;
                    dal.ModifySupplier(supplier, con, tran);
                    mmdal.AddModifyMark<SupplierReviewContents>(reviewContents, id, con, tran);
                }
            });
        }

        /// <summary>
        /// 验证名称是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contractNo"></param>
        /// <param name="con"></param>
        /// <returns></returns>
        public bool CheckName(string name, int id)
        {
            bool result = this.ExecuteWithoutTransaction<bool>((con) =>
           {
               return dal.CheckName(name, id, con);
           });
            return result;
        }
        /// <summary>
        /// 启动审批流程
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentUser"></param>
        /// <returns>返回string.Empty为成功，否则为失败原因</returns>
        public string StartFlow(EnumFlowNames flowName, int id, string currentUser, string description="")
        {
            Supplier supplier = this.GetSupplier(id);
            if (supplier == null)
            {
                return "数据不存在";
            }
            if (supplier.EnumFlowState == EnumDataFlowState.审批中)
            {
                return string.Format("{0}中的数据不能重新启动流程", EnumDataFlowState.审批中);
            }
            if (supplier.SupplierType != (int)EnumSupplierType.合格供方)
            {
                return "非合格供方不能提交审批";
            }

            string message = string.Empty;
            if (flowName == EnumFlowNames.供应商复审流程)
            {
                message = CheckReviewData(supplier);
            }
            else if (flowName == EnumFlowNames.供应商审批流程)
            {
                message = CheckFirstReviewData(supplier);
            }
            else
            {
                return "流程名称错误";
            }
            if (!string.IsNullOrEmpty(message))
            {
                return message;
            }

            FlowRunState state = fm.StartFlow(flowName.ToString(), id, supplier.Name, EnumFlowDataType.供应商.ToString(), currentUser, description);
            if (state != FlowRunState.启动流程成功)
            {
                return state.ToString();
            }
            return string.Empty;
        }

        public void DeleteSupplier(int id)
        {
            this.ExecuteWithTransaction((con, tran) =>
            {
                fDal.DeleteFlowInstanceByDateItem(id, EnumFlowDataType.供应商.ToString(), con, tran);

                dal.DeleteSupplier(id, con);
            });
        }
        private string CheckFirstReviewData(Supplier supplier)
        {
            if (string.IsNullOrEmpty(supplier.TaxpayerID))
            {
                return "请补充纳税人识别号";
            }
            if (string.IsNullOrEmpty(supplier.Legal))
            {
                return "请补充法人代表";
            }
            if (!supplier.ExistsAgentAgreement)
            {
                return "合格供方需要代理协议";
            }
            if (supplier.AgreementDate == null)
            {
                return "请补充代理协议有效期";
            }
            else if (supplier.AgreementDate.Value.Date <= DateTime.Now.AddDays(30).Date)
            {
                return "代理协议有效期应大于当前日期30天";
            }
            if (!supplier.ExistsLicenseCopy)
            {
                return "合格供方需要营业执照复印件";
            }
            if (supplier.Discredited)
            {
                return "合格供方需为非经营异常企业";
            }
            if (supplier.RegistrationDate == null)
            {
                return "请补充工商登记日期";
            }
            else if (supplier.RegistrationDate.Value.Date > DateTime.Now.Date)
            {
                return "工商登记日期应小于当前日期";
            }

            if (supplier.BusinessEffectiveDate == null)
            {
                return "请补充经营截至日期";
            }
            else if (supplier.RegistrationDate != null && supplier.BusinessEffectiveDate.Value.Date < supplier.RegistrationDate.Value.Date)
            {
                return "经营截至日期应大于工商登记日期";
            }
            else if (supplier.BusinessEffectiveDate.Value.Date <= DateTime.Now.AddDays(30).Date)
            {
                return "经营截至日期应大于当前日期30天";
            }
            if (string.IsNullOrEmpty(supplier.FirstReviewContents))
            {
                return "请补充供方能力评价信息";
            }
            else
            {
                SupplierFirstReviewContents reviewContents = supplier.FirstReviewContents.ToObjectList<SupplierFirstReviewContents>();
                if (reviewContents == null)
                {
                    return "请补充供方能力评价信息";
                }
                else if (reviewContents.Result == 3)
                {
                    return "评价结论为D不能提交审批";
                }
            }

            return string.Empty;
        }
        private string CheckReviewData(Supplier supplier)
        {
            if (string.IsNullOrEmpty(supplier.TaxpayerID))
            {
                return "请补充纳税人识别号";
            }
            if (string.IsNullOrEmpty(supplier.Legal))
            {
                return "请补充法人代表";
            }
            if (!supplier.ExistsAgentAgreement)
            {
                return "合格供方需要代理协议";
            }
            if (!supplier.ExistsLicenseCopy)
            {
                return "合格供方需要营业执照复印件";
            }
          
            if (string.IsNullOrEmpty(supplier.ReviewContents))
            {
                return "请补充供方行为和年度重新评价信息";
            }
            else
            {
                SupplierReviewContents reviewContents = supplier.ReviewContents.ToObjectList<SupplierReviewContents>();
                if (reviewContents == null)
                {
                    return "请补充供方行为和年度重新评价信息";
                }
                if (reviewContents.AgreementDate == null)
                {
                    return "请补充代理协议有效期";
                }
                else if (reviewContents.AgreementDate.Value.Date <= DateTime.Now.AddDays(30).Date)
                {
                    return "代理协议有效期应大于当前日期30天";
                }

                if (reviewContents.RegistrationDate == null)
                {
                    return "请补充工商登记日期";
                }
                else if (reviewContents.RegistrationDate.Value.Date > DateTime.Now.Date)
                {
                    return "工商登记日期应小于当前日期";
                }

                if (reviewContents.BusinessEffectiveDate == null)
                {
                    return "请补充经营截至日期";
                }
                else if (reviewContents.RegistrationDate != null && reviewContents.BusinessEffectiveDate < supplier.RegistrationDate)
                {
                    return "经营截至日期应大于工商登记日期";
                }
                else if (reviewContents.BusinessEffectiveDate.Value.Date <= DateTime.Now.AddDays(30).Date)
                {
                    return "经营截至日期应大于当前日期30天";
                }
                if (reviewContents.TotalBatch == 0)
                {
                    return "总批次不能为0";
                }
                if (!reviewContents.RectificationResult)
                {
                    return "不合格整改记录整改后为不合格不能提交审批";
                }
            }
            return string.Empty;
        }
    }
}
