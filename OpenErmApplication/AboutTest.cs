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
            LoginPage login = new LoginPage(driver);
            login.EnterUsername(username);
            login.EnterPassword(password);
            login.SelectLanguageByText(language);
            login.ClickOnLogin();

            AboutPage about = new AboutPage(driver);
            Assert.AreEqual(expectedHeader, about.GetHeader());
            Assert.AreEqual(expectedVersion, about.GetVersion());

            Assert.True(about.GetVersion().Contains(expectedVersion));

        }
    }
}
