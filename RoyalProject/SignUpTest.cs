using NUnit.Framework;
using System;
using Zensoft.AutomationWrapper.Base;

namespace RoyalProject
{
    public class SignUpTest : WebDriverWrapper
    {

        [Test]
        public void ValidSignUpTest()
        {
            Console.WriteLine(driver.Title);
        }
    }
}