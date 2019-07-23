using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BudgetSystem.Entity;
using BudgetSystem.Entity.QueryCondition;

namespace BudgetSystem.Bll
{
    public class InvoiceManager : BaseManager
    {
        Dal.InvoiceDal invoiceDal = new Dal.InvoiceDal();
        Dal.BudgetDal budgetDal = new Dal.BudgetDal();
        Dal.SupplierDal supplierDal = new Dal.SupplierDal();
        public List<Invoice> GetAllInvoice(InvoiceQueryCondition condition)
        {
            var lst = this.Query<Invoice>((con) => { return invoiceDal.GetAllInvoice(condition, con, null); });
            return lst.ToList();
        }
        public List<Invoice> GetAllInvoiceByBudgetID(int budgetID)
        {
            var lst = this.Query<Invoice>((con) => { return invoiceDal.GetAllInvoiceByBudgetID(budgetID, con, null); });
            return lst.ToList();
        }
        public Invoice GetInvoice(int id)
        {
            return this.Query<Invoice>((con) => { return invoiceDal.GetInvoice(id, con, null); });
        }

        public void AddInvoice(Invoice invoice)
        {
            this.ExecuteWithTransaction((con, tran) =>
            {
                invoiceDal.AddInvoice(invoice, con, tran);
            });
        }

        public void ModifyInvoice(Invoice invoice)
        {
            this.ExecuteWithTransaction((con, tran) =>
            {
                invoiceDal.ModifyInvoice(invoice, con, tran);
            });
        }

        /// <summary>
        /// 验证导入数据是否合法
        /// </summary>
        /// <param name="list">待导入数据</param>
        /// <param name="isFinanceImport">是否财务导入</param>
        /// <returns></returns>
        public bool CheckImportData(List<Invoice> list, bool isFinanceImport)
        {
            bool result = true;
            this.ExecuteWithoutTransaction((con) =>
            {
                if (isFinanceImport)
                {
                    foreach (Invoice invoice in list)
                    {
                        if (string.IsNullOrEmpty(invoice.Number.Trim()))
                        {
                            invoice.Message += "发票号不能为空;";
                            result = false;
                        }
                        else if (list.Count(i => i.Number == invoice.Number) > 1)
                        {
                            invoice.Message += "发票号存在重复;";
                            result = false;
                        }
                        else if (!invoiceDal.CheckNumber(0, invoice.Number.Trim(), con, null))
                        {
                            invoice.Message += "发票号不存在;";
                            result = false;
                        }
                        if (string.IsNullOrEmpty(invoice.Code.Trim()))
                        {
                            invoice.Message += "发票代码不能为空;";
                            result = false;
                        }
                        if (string.IsNullOrEmpty(invoice.TaxpayerID.Trim()))
                        {
                            invoice.Message += "销方税号不能为空;";
                            result = false;
                        }
                        if (string.IsNullOrEmpty(invoice.SupplierName.Trim()))
                        {
                            invoice.Message += "销方名称不能为空;";
                            result = false;
                        }
                        else if(!supplierDal.CheckName(invoice.SupplierName.Trim(),-1,con))
                        {
                            invoice.Message += "销方名称不存在;";
                            result = false;
                        }
                        if (invoice.Payment <= 0)
                        {
                            invoice.Message += "金额应大于0;";
                            result = false;
                        }
                        if (invoice.TaxAmount < 0)
                        {
                            invoice.Message += "税额应大于等于0;";
                            result = false;
                        }
                    }
                }
                else
                {
                    foreach (Invoice invoice in list)
                    {
                        if (string.IsNullOrEmpty(invoice.ContractNO.Trim()))
                        {
                            invoice.Message += "合同号不能为空;";
                            result = false;
                        }
                        else
                        {
                            int budgetId = budgetDal.CheckContractNO(invoice.ContractNO.Trim(), con);
                            if (budgetId < 0)
                            {
                                invoice.Message += "合同号不存在;";
                                result = false;
                            }
                            else
                            {
                                invoice.BudgetID = budgetId;
                            }
                        }
                        if (string.IsNullOrEmpty(invoice.Number.Trim()))
                        {
                            invoice.Message += "发票号不能为空;";
                            result = false;
                        }
                        else if (invoiceDal.CheckNumber(0, invoice.Number, con, null))
                        {
                            invoice.Message += "发票号已存在;";
                            result = false;
                        }
                        if (invoice.ExchangeRate <= 0)
                        {
                            invoice.Message += "汇率应大于0;";
                            result = false;
                        }
                        if (string.IsNullOrEmpty(invoice.CustomsDeclaration.Trim()))
                        {
                            invoice.Message += "报关单不能为空;";
                            result = false;
                        }
                        if (invoice.TaxRebateRate < 0)
                        {
                            invoice.Message += "退税率应大于等于0;";
                            result = false;
                        }
                        if (invoice.Commission < 0)
                        {
                            invoice.Message += "佣金应大于等于0;";
                            result = false;
                        }
                        if (invoice.FeedMoney < 0)
                        {
                            invoice.Message += "进料款应大于等于0;";
                            result = false;
                        }
                    }
                }

            });
            return result;
        }
        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="list"></param>
        /// <param name="isFinanceImport"></param>
        /// <returns></returns>
        public bool ImportData(List<Invoice> list, bool isFinanceImport)
        {
            bool checkResult = this.CheckImportData(list, isFinanceImport);
            if (checkResult == false)
            {
                return false;
            }
            this.ExecuteWithTransaction((con, tran) =>
            {
                if (isFinanceImport)
                {
                    foreach (Invoice invoice in list)
                    {
                        invoiceDal.ModifyFinanceData(invoice, con, tran);
                    }
                }
                else
                {
                    foreach (Invoice invoice in list)
                    {
                        invoiceDal.AddInvoice(invoice, con, tran);
                    }
                }
            });
            return true;
        }

        /// <summary>
        /// 验证发票号是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <param name="number"></param>
        /// <param name="con"></param>
        /// <returns></returns>
        public bool CheckNumber(int id, string number)
        {
            return this.ExecuteWithTransaction((con, tran) =>
            {
                return invoiceDal.CheckNumber(id, number, con, tran);
            });
        }
    }
}
