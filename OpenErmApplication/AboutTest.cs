using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Zensoft.OpenErmApplication.Pages;
using Zensoft.AutomationWrapper.Base;
using Zensoft.OpenErmApplication.Utilities;

namespace Zensoft.OpenErmApplication
{
    class AboutTest : WebDriverWrapper
    {
        [Test,TestCaseSource(typeof(TestCaseSourceUtils), "CheckHeaderAndVersionData")]
        public void CheckHeaderAndVersionTest(string username,string password,string language,string expectedHeader,string expectedVersion)
        {
            //LoginPage login = new LoginPage();
            //login.EnterUsername(driver, username);
            //login.EnterPassword(driver, password);
            //login.SelectLanguageByText(driver, language);
            //login.ClickOnLogin(driver);

            //Assert.AreEqual(expectedHeader, AboutPage.GetHeader(driver));
            //Assert.AreEqual(expectedVersion, AboutPage.GetVersion(driver));

            //Assert.True(AboutPage.GetVersion(driver).Contains(expectedVersion));

        }
    }
}
