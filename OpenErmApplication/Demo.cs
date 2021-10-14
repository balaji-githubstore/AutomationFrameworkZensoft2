using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;


namespace OpenErmApplication
{
    class Demo
    {
        
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
        [Test,TestCaseSource("ValidData")]
        public void ValidTest(string username,string password)
        {
            
            Console.WriteLine(username+password);
        }
    }
}
