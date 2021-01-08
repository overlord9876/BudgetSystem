using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using BudgetSystem.Entity;
using BudgetSystem.InMoney;

namespace BudgetSystem.UIEntity
{
    public class DataControlCreator
    {
        public static DataControl CreateDataControl(string flowName, string dataItemType)
        {
            if (dataItemType == EnumFlowDataType.付款单.ToString())
            {
                BudgetSystem.OutMoney.ucOutMoneyEdit edit = new BudgetSystem.OutMoney.ucOutMoneyEdit();
                edit.WorkModel = EditFormWorkModels.View;
                edit.Height = 400 + 150;
                return edit;
            }
            else if (dataItemType == EnumFlowDataType.供应商.ToString() && flowName == EnumFlowNames.供应商审批流程.ToString())
            {
                BudgetSystem.ucSupplierEdit edit = new BudgetSystem.ucSupplierEdit();
                edit.WorkModel = EditFormWorkModels.View;
                return edit;
            }
            else if (dataItemType == EnumFlowDataType.供应商.ToString() && flowName == EnumFlowNames.供应商复审流程.ToString())
            {
                BudgetSystem.ucSupplierEdit edit = new BudgetSystem.ucSupplierEdit();
                edit.WorkModel = EditFormWorkModels.View;
                return edit;
            }
            else if (dataItemType == EnumFlowDataType.收款单.ToString())
            {
                BudgetSystem.InMoney.ucInMoneyEdit edit = new BudgetSystem.InMoney.ucInMoneyEdit();
                edit.WorkModel = EditFormWorkModels.View;
                edit.Height = 500;
                return edit;
            }
            else if (dataItemType == EnumFlowDataType.预算单.ToString())
            {
                ucBudgetDetailView edit = new ucBudgetDetailView();
                edit.Height = 800;
                edit.WorkModel = EditFormWorkModels.View;
                return edit;
            }
            else if (flowName == EnumFlowNames.调账审批流程.ToString() || flowName == EnumFlowNames.修改调账审批流程.ToString() || flowName == EnumFlowNames.删除调账审批流程.ToString()
                || flowName == EnumFlowNames.财务调账审批流程.ToString() || flowName == EnumFlowNames.财务修改调账审批流程.ToString() || flowName == EnumFlowNames.财务删除调账审批流程.ToString())
            {
                AdjustmentType at = AdjustmentType.交单;
                if (dataItemType == EnumFlowDataType.收款调账.ToString())
                {
                    at = AdjustmentType.收款;
                }
                else if (dataItemType == EnumFlowDataType.付款调账.ToString())
                {
                    at = AdjustmentType.付款;
                }
                else
                {
                    at = AdjustmentType.交单;
                }

                ucAccountAdjustmentEdit edit = new ucAccountAdjustmentEdit();
                edit.Height = 800;
                edit.WorkModel = EditFormWorkModels.View;
                edit.SetAdjustmentType(at);
                return edit;
            }
            else if (dataItemType == "BatchApprove")
            {
                BatchDataControl c = new BatchDataControl();
                return c;
            }
            else
            {
                //TODO:这里写生成器
                return new DataControl();
            }
        }


    }
}
