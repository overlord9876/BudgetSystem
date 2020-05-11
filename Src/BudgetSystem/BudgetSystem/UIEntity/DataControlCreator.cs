using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using BudgetSystem.Entity;

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
