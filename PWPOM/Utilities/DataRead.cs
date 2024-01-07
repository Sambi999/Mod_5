using ExcelDataReader;
using PWPOM.Test_Helper_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWPOM.Utilities
{
    internal class DataRead
    {
        public static List<EAText> ReadLoginCredData(string excelFilePath, string sheetName)
        {
            List<EAText> excelDataList = new List<EAText>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using (var stream = File.Open(excelFilePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });
                    var dataTable = result.Tables[sheetName];
                    if (dataTable != null)

                    {

                        foreach (DataRow row in dataTable.Rows)
                        {
                            EAText excelData = new EAText
                            {
                                UserName = GetValueOrDefault(row, "un"),
                                Password = GetValueOrDefault(row, "pwd"),
                                
                            };
                            excelDataList.Add(excelData);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Sheet '{sheetName}' not found in the Excel file.");
                    }
                }
            }
            return excelDataList;
        }
        static string? GetValueOrDefault(DataRow row, string columnName)
        {
            return row.Table.Columns.Contains(columnName) ? row[columnName]?.ToString() : null;
        }
    }
}

