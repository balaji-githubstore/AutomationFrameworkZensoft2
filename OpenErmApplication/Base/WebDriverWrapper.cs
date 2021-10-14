using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.OpenErmApplication.Base
{
    class WebDriverWrapper
    {
        protected IWebDriver driver;

        [SetUp]
        public void LaunchBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://demo.openemr.io/b/openemr";
        }

        [TearDown]
        public void EndBrowser()
        {
            driver.Quit();
        }


    }
}
