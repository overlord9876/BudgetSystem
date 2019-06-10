using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace BudgetSystem.Entity
{
    /// <summary>
    /// 供应商复审内容
    /// </summary>
    public class SupplierReviewContents
    {
        /// <summary>
        /// 总批次
        /// </summary>
        public int TotalBatch { get; set; }

        /// <summary>
        /// 合格批次
        /// </summary>
        public int PassedBatch { get; set; }

        /// <summary>
        /// 不合格批次
        /// </summary>
        public int RejectedBatch { get; set; }

        /// <summary>
        /// 整改批次
        /// </summary>
        public int RectificationBatch { get; set; }

        /// <summary>
        /// 整改合格批次
        /// </summary>
        public int RectificationPassedBatch { get; set; }

        /// <summary>
        /// 整改结果 
        /// </summary>
        public bool RectificationResult { get; set; }

        /// <summary>
        /// 失信企业
        /// </summary>
        [DefaultValue(false)]
        public bool Discredited { get; set; }

        /// <summary>
        /// 业务员
        /// </summary>
        public string Salesman { get; set; }


        /// <summary>
        /// 业务员结论
        /// </summary>
        public bool SalesmanResult { get; set; }

        /// <summary>
        /// 部门经理
        /// </summary>
        public string Manager { get; set; }

        /// <summary>
        /// 部门经理结论
        /// </summary>
        public bool? ManagerResult { get; set; }

        /// <summary>
        /// 评审组长
        /// </summary>
        public string Leader { get; set; }

        /// <summary>
        /// 评审组长结果 
        /// </summary>
        public bool? LeaderResult { get; set; }

        /// <summary>
        /// 经营登记日期
        /// </summary>
        public DateTime? RegistrationDate { get; set; }

        /// <summary>
        /// 经营截止时间
        /// </summary>
        public DateTime? BusinessEffectiveDate { get; set; }
        /// <summary>
        /// 代理协议有效期
        /// </summary>
        public DateTime? AgreementDate { get; set; }

        /// <summary>
        /// 年审日期
        /// </summary>
        public DateTime? ReviewDate { get; set; }
        /// <summary>
        /// 结论日期
        /// </summary>
        public DateTime? ResultDate { get; set; }

        public SupplierReviewContents()
        { 
        
        }
    }
}
