﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ClosedXML.Excel;


namespace OpenErmApplication
{
    class Demo
    {
        [Test]
        public void ExcelRead()
        {
            XLWorkbook book = new XLWorkbook(@"D:\B-Mine\Company\Company\Zensoft\OpenErmApplication\OpenErmApplication\TestData\OpenEmrTestData.xlsx");

            var sheet = book.Worksheet("invalidCredentialData");

            var range = sheet.RangeUsed();

            int rowCount = range.RowCount();
            int colCount = range.ColumnCount();

            Console.WriteLine(rowCount);
            Console.WriteLine(colCount);

            string value = range.Cell(1, 2).GetString();
            Console.WriteLine(value);


            //print all the cell value 
            //based on the row count --> number of temp object (parameter - number of columns) 
            //main[] size --> number of rows

            book.Dispose();
        }






        public static object[] ValidData()
        {
            object[] temp1 = new object[2]; //number of parameter 
            temp1[0] = "jack";
            temp1[1] = "jack123";

            object[] temp2 = new object[2];
            temp2[0] = "peter";
            temp2[1] = "peter123";

            object[] temp3 = new object[2];
            temp3[0] = "mark";
            temp3[1] = "makr123";

            object[] temp4 = new object[2];
            temp4[0] = "king";
            temp4[1] = "king123";

            object[] main = new object[4]; //number of test case

            main[0] = temp1;
            main[1] = temp2;
            main[2] = temp3;
            main[3] = temp4;

            return main;
        }


        //jack, jack123-->temp1
        //peter,peter123 --> temp2
        //mark,makr123 --> temp3
        //king,king123
        [Test, TestCaseSource("ValidData")]
        public void ValidTest(string username, string password)
        {

            Console.WriteLine(username + password);
        }
    }
}
