using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.OpenErmApplication.Utilities
{
    class TestCaseSourceUtils
    {
        public static object[] CheckHeaderAndVersionData()
        {
            object[] main = ExcelUtlis.ConvertSheetIntoObjectArray(@"D:\B-Mine\Company\Company\Zensoft\OpenErmApplication\OpenErmApplication\TestData\OpenEmrTestData.xlsx", "CheckHeaderAndVersionData");
            return main;
        }
        public static object[] InvalidCredentialData()
        {
            object[] main = ExcelUtlis.ConvertSheetIntoObjectArray(@"D:\B-Mine\Company\Company\Zensoft\OpenErmApplication\OpenErmApplication\TestData\OpenEmrTestData.xlsx", "InvalidCredentialData");
            return main;
        }
        //public static object[] InvalidCredentialData()
        //{
        //    object[] temp1 = new object[4];
        //    temp1[0] = "admin12";
        //    temp1[1] = "pass12";
        //    temp1[2] = "English (Indian)";
        //    temp1[3] = "Invalid username or password";

        //    object[] temp2 = new object[4];
        //    temp2[0] = "physician12";
        //    temp2[1] = "physician12";
        //    temp2[2] = "Dutch";
        //    temp2[3] = "Invalid username or password";

        //    object[] main = new object[2];
        //    main[0] = temp1;
        //    main[1] = temp2;


        //    return main;
        //}

        public static object[] ValidCredentialData()
        {
            object[] temp1 = new object[4];
            temp1[0] = "admin";
            temp1[1] = "pass";
            temp1[2] = "English (Indian)";
            temp1[3] = "OpenEMR";

            object[] temp2 = new object[4];
            temp2[0] = "physician";
            temp2[1] = "physician";
            temp2[2] = "Dutch";
            temp2[3] = "OpenEMR";

            object[] temp3 = new object[4];
            temp3[0] = "accountant";
            temp3[1] = "accountant";
            temp3[2] = "Dutch";
            temp3[3] = "OpenEMR";

            object[] main = new object[3];
            main[0] = temp1;
            main[1] = temp2;
            main[2] = temp3;

            return main;
        }

    }
}
