using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;

namespace BudgetSystem.Util
{
    /// <summary>
    /// Excel操作类
    /// </summary>
    public class ExcelHelper
    {
        /// <summary>
        /// 将excel中的数据读取到DataTable中
        /// </summary>
        /// <param name="fileName">Excel文件</param>
        /// <param name="message">当读取失败时的错误描述</param>
        /// <param name="sheetName">excel工作薄sheet的名称</param>
        /// <param name="requiredColumns">必须存在的列，当缺少列时不读取</param>
        /// <returns>返回的DataTable</returns>
        public static DataTable ReadExcelToDataTable(string fileName, out string message, string sheetName = "", List<string> requiredColumns = null)
        {
            message = string.Empty;
            if(string.IsNullOrEmpty(fileName)||!File.Exists(fileName))
            {
                message="文件不存在";
                return null;
            }
            string ext=Path.GetExtension(fileName).ToLower();
            if(!".xlsx".Equals(ext)&&!".xls".Equals(ext))
            {
                message = "不支持的文件格式";
                return null;
            }
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    ISheet sheet = null;
                    IWorkbook workbook = null;
                    if (".xlsx".Equals(ext)) // 2007版本
                    {
                        workbook = new XSSFWorkbook(fs);
                    }
                    else  //".xls"// 2003版本
                    {
                        workbook = new HSSFWorkbook(fs);
                    } 

                    if (!string.IsNullOrEmpty(sheetName))
                    {
                        sheet = workbook.GetSheet(sheetName);
                        if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                        {
                            sheet = workbook.GetSheetAt(0);
                        }
                    }
                    else
                    {
                        sheet = workbook.GetSheetAt(0);
                    }

                    if (sheet == null)
                    {
                        message = "无数据";
                        return null;
                    }
                    else
                    {
                        IRow firstRow = sheet.GetRow(0);
                        int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数 
                        Dictionary<int, string> columnMapping = new Dictionary<int, string>();
                        DataTable data = new DataTable();
                        ICell cell;
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (!string.IsNullOrEmpty(cellValue))
                                {
                                    columnMapping.Add(i, cellValue);
                                    data.Columns.Add(cellValue);
                                }
                            }
                        }
                        if (columnMapping.Count <=1)
                        {
                            message = "无有效数据";
                            return null;
                        }
                        if (requiredColumns != null && requiredColumns.Count > 0)
                        {
                            foreach (string rcol in requiredColumns)
                            {
                                if (!columnMapping.ContainsValue(rcol))
                                {
                                    message = string.Format("列[{0}]不存在", rcol);
                                    return null;
                                }
                            }
                        }
                        //最后一列的标号
                        int rowCount = sheet.LastRowNum;
                        int countNull = 0; 
                        string strVal;
                        for (int i = 1; i <= rowCount; ++i)
                        {
                            IRow row = sheet.GetRow(i);
                            if (row == null || row.FirstCellNum == -1) continue; //没有数据的行默认是null　　　　　　　

                            DataRow dataRow = data.NewRow();
                            countNull = 0; 
                            for (int j = row.FirstCellNum; j < cellCount; ++j)
                            {
                                cell=row.GetCell(j);
                                if ( cell!= null) //同理，没有数据的单元格都默认是null
                                {
                                    strVal = cell.ToString();
                                    dataRow[j] = strVal;
                                    countNull += string.IsNullOrEmpty(strVal) ? 1 : 0;
                                }
                                else
                                {
                                    countNull ++;
                                }
                            }
                            if (countNull == cellCount)
                            { 
                                //空行不再读取
                                break;
                            }
                            data.Rows.Add(dataRow);
                        }
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return null;
            }
        }

    }
}
