using NUnit.Framework;
using System;
using Zensoft.AutomationWrapper.Base;

namespace RoyalProject
{
    class DivideCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { 12, 3, 4 };
            yield return new object[] { 12, 2, 6 };
            yield return new object[] { 12, 4, 3 };
        }
    }
    //public IEnumerator GetEnumerator()
    //{
    //    //pick the file,sheetname
    //    using (XLWorkbook book = new XLWorkbook(file))
    //    {
    //        var sheet = book.Worksheet(sheetname);
    //        var range = sheet.RangeUsed();

    //        int rowCount = range.RowCount();
    //        int colCount = range.ColumnCount();


    //        for (int r = 2; r <= rowCount; r++)
    //        {
    //            object[] temp = new object[colCount];
    //            for (int c = 1; c <= colCount; c++)
    //            {
    //                string value = range.Cell(r, c).GetString();
    //                temp[c - 1] = value;
    //            }
    //            yield return temp;
    //        }

    //    }

    public class MyTestClass
    {
        [TestCaseSource(typeof(DivideCases))]
        public void DivideTest(int n, int d, int q)
        {
            Assert.AreEqual(q, n / d);
        }
    }
    public class SignUpTest : WebDriverWrapper
    {

        [Test]
        public void ValidSignUpTest()
        {
            Console.WriteLine(driver.Title);
        }
    }
}