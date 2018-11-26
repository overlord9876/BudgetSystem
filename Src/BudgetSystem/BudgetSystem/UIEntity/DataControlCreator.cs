using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using BudgetSystem.Entity;

namespace BudgetSystem.UIEntity
{
    public class DataControlCreator
    {
        public static DataControl CreateDataControl(string dataItemType)
        {
            if (dataItemType == EnumFlowDataType.付款单.ToString())
            {
                BudgetSystem.OutMoney.ucOutMoneyEdit edit = new BudgetSystem.OutMoney.ucOutMoneyEdit();
                edit.WorkModel = EditFormWorkModels.View;
                return edit;
            }
            else if (dataItemType == EnumFlowDataType.供应商.ToString())
            {
                BudgetSystem.ucSupplierEdit edit = new BudgetSystem.ucSupplierEdit();
                edit.WorkModel = EditFormWorkModels.View;
                return edit;
            }
            else if (dataItemType == EnumFlowDataType.收款单.ToString())
            {
                BudgetSystem.InMoney.ucInMoneyEdit edit = new BudgetSystem.InMoney.ucInMoneyEdit();
                edit.WorkModel = EditFormWorkModels.View;
                return edit;
            }
            else if (dataItemType == EnumFlowDataType.预算单.ToString())
            {
                ucBudgetEdit edit = new ucBudgetEdit();
                edit.WorkModel = EditFormWorkModels.View;
                return edit;
            }
            else
            {
                //TODO:这里写生成器
                return new DataControl();
            }
        }


    }
}
