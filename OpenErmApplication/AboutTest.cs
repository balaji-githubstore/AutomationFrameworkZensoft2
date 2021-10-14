using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Zensoft.OpenErmApplication.Pages;
using Zensoft.OpenErmApplication.Base;

namespace Zensoft.OpenErmApplication
{
    class AboutTest : WebDriverWrapper
    {
        [Test]
        public void CheckHeaderAndVersionTest()
        {
            LoginPage.EnterUsername(driver, "admin");
            LoginPage.EnterPassword(driver, "pass");
            LoginPage.ClickOnLogin(driver);
            MainPage.ClickOnAbout(driver);

            Assert.AreEqual("About OpenEMR", AboutPage.GetHeader(driver));
            Assert.AreEqual("Version Number: v6.0.0 (2)", AboutPage.GetVersion(driver));

            Assert.True(AboutPage.GetVersion(driver).Contains("v7.0.0"),"Assertion on v6.0.0");

        }
    }
}
