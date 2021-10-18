using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.OpenErmApplication.Utilities
{
    class ExcelUtlis
    {
        public static object[] ConvertSheetIntoObjectArray(string file,string sheetname)
        {
            using (XLWorkbook book = new XLWorkbook(file))
            {
                var sheet = book.Worksheet(sheetname);
                var range = sheet.RangeUsed();

                int rowCount = range.RowCount();
                int colCount = range.ColumnCount();

                object[] main = new object[rowCount - 1];

                for (int r = 2; r <= rowCount; r++)
                {
                    object[] temp = new object[colCount];
                    for (int c = 1; c <= colCount; c++)
                    {
                        string value = range.Cell(r, c).GetString();
                        temp[c - 1] = value;
                    }
                    main[r - 2] = temp;
                }
                return main;
            }
        }

    }
}
