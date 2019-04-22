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
        public static DataTable ReadExcelToDataTable(string fileName, out string message, string sheetName = "", List<string> requiredColumns = null, int firstRowIndex = 0)
        {
            message = string.Empty;
            if (string.IsNullOrEmpty(fileName) || !File.Exists(fileName))
            {
                message = "文件不存在";
                return null;
            }
            string ext = Path.GetExtension(fileName).ToLower();
            if (!".xlsx".Equals(ext) && !".xls".Equals(ext))
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
                        IRow firstRow = sheet.GetRow(firstRowIndex);
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
                        if (columnMapping.Count <= 0)
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
                        for (int i = firstRowIndex + 1; i <= rowCount; ++i)
                        {
                            IRow row = sheet.GetRow(i);
                            if (row == null || row.FirstCellNum == -1) continue; //没有数据的行默认是null　　　　　　　

                            DataRow dataRow = data.NewRow();
                            countNull = 0;
                            for (int j = row.FirstCellNum; j < cellCount; ++j)
                            {
                                cell = row.GetCell(j);
                                if (cell != null) //同理，没有数据的单元格都默认是null
                                {
                                    strVal = cell.ToString();
                                    dataRow[j] = strVal;
                                    countNull += string.IsNullOrEmpty(strVal) ? 1 : 0;
                                }
                                else
                                {
                                    countNull++;
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

        /// <summary>
        /// 将DataTable数据导入到excel中
        /// </summary>
        /// <param name="data">要导入的数据</param>
        /// <returns>导入数据行数(包含列名那一行)</returns>
        public static int DataTableToExcel(DataTable data, string fileName, List<ExcelColumn> columns, out string message)
        {
            message = string.Empty;
            if (data == null || data.Rows.Count <= 0)
            {
                return 0;
            }
            string ext = Path.GetExtension(fileName).ToLower();
            if (!".xlsx".Equals(ext) && !".xls".Equals(ext))
            {
                message = "不支持的文件格式";
                return 0;
            }
            try
            {
                IWorkbook workbook = null;

                if (".xlsx".Equals(ext)) // 2007版本
                {
                    workbook = new XSSFWorkbook();
                }
                else  //".xls"// 2003版本
                {
                    workbook = new HSSFWorkbook();
                }
                ISheet sheet = workbook.CreateSheet();
                IRow row = sheet.CreateRow(0);
                int c = 0;
                //通用单元格样式（加边框）
                ICellStyle style = workbook.CreateCellStyle();
                style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                style.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                style.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                style.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;

                ICellStyle cellStyle;
                foreach (ExcelColumn column in columns)
                {
                    row.CreateCell(c, CellType.String);
                    row.Cells[c].SetCellValue(column.Name);
                    cellStyle = workbook.CreateCellStyle();
                    cellStyle.CloneStyleFrom(style);
                    cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                    cellStyle.FillPattern = FillPattern.SolidForeground;//添加背景色必须加这句
                    cellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Grey50Percent.Index;//设置背景填充色50%的灰色                   

                    row.Cells[c].CellStyle = cellStyle;
                    sheet.SetColumnWidth(c, column.Width);
                    c++;
                }
                IDataFormat dataFormat = workbook.CreateDataFormat();
                int rowNum = 1;
                double cellValue = 0;

                for (int i = 0; i < data.Rows.Count; ++i)
                {
                    row = sheet.CreateRow(rowNum);
                    c = 0;
                    foreach (ExcelColumn column in columns)
                    {
                        row.CreateCell(c, column.ColumType);
                        cellStyle = workbook.CreateCellStyle();
                        cellStyle.CloneStyleFrom(style);
                        if (column.DataFormat == 176)
                        {
                            cellStyle.DataFormat = dataFormat.GetFormat("$#,##0.00");
                        }
                        else
                        {
                            cellStyle.DataFormat = column.DataFormat;
                        }
                        row.Cells[c].CellStyle = cellStyle;
                        if (column.ColumType == CellType.Formula)
                        {
                            row.Cells[c].SetCellFormula(string.Format(column.FormulaFormat, i + 2));
                        }
                        else if (column.ColumType == CellType.Numeric)
                        {
                            if (!data.Rows[i].IsNull(column.DataColumnIndex) && double.TryParse(data.Rows[i][column.DataColumnIndex].ToString(), out cellValue))
                            {
                                row.Cells[c].SetCellValue(cellValue);
                            }
                        }
                        else
                        {
                            if (!data.Rows[i].IsNull(column.DataColumnIndex))
                            {
                                row.Cells[c].SetCellValue(data.Rows[i][column.DataColumnIndex].ToString());
                            }
                        }
                        c++;
                    }
                    rowNum++;
                }
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    workbook.Write(fs); //写入到excel
                }
                workbook.Close();
                return rowNum - 1;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return -1;
            }
        }

        /// <summary>
        /// 获取Excel中sheet名称列表
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="message"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public static List<string> GetEexelSheetNames(string fileName, out string message)
        {
            message = string.Empty;
            if (string.IsNullOrEmpty(fileName) || !File.Exists(fileName))
            {
                message = "文件不存在";
                return null;
            }
            string ext = Path.GetExtension(fileName).ToLower();
            if (!".xlsx".Equals(ext) && !".xls".Equals(ext))
            {
                message = "不支持的文件格式";
                return null;
            }

            try
            {
                List<string> result = new List<string>();
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    IWorkbook workbook = null;
                    if (".xlsx".Equals(ext)) // 2007版本
                    {
                        workbook = new XSSFWorkbook(fs);
                    }
                    else  //".xls"// 2003版本
                    {
                        workbook = new HSSFWorkbook(fs);
                    }
                    for (int i = 0; i < workbook.NumberOfSheets; i++)
                    {
                        result.Add(workbook.GetSheetAt(i).SheetName);
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return null;
            }
        }

    }

    public class ExcelColumn
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="width"></param>
        /// <param name="dataColumnIndex"></param>
        /// <param name="type">0:string,1:Nummber,2:Formula</param>
        /// <param name="formulaFormat"></param>
        /// <param name="dataFormat"></param>
        public ExcelColumn(string name, int width, int dataColumnIndex = 0, int type = 0, string formulaFormat = "", short dataFormat = 0)
        {
            this.Name = name;
            this.Width = width;
            this.FormulaFormat = formulaFormat;
            this.DataFormat = dataFormat;
            this.DataColumnIndex = dataColumnIndex;
            switch (type)
            {
                case 1:
                    this.ColumType = CellType.Numeric;
                    break;
                case 2:
                    this.ColumType = CellType.Formula;
                    break;
                default:
                    this.ColumType = CellType.String;
                    break;
            }
        }
        public string Name { get; set; }

        public CellType ColumType { get; set; }

        private string formulaFormat = string.Empty;
        public string FormulaFormat
        {
            get { return formulaFormat; }
            set { formulaFormat = value; }
        }

        private short dataFormat = 0;
        /// <summary>
        /// 数据格式，默认0
        /// $176  ￥7
        /// </summary>
        public short DataFormat
        {
            get { return dataFormat; }
            set { dataFormat = value; }
        }

        public int Width
        {
            get;
            set;
        }
        public int DataColumnIndex
        {
            get;
            set;
        }
    }
}
