using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Zensoft.OpenErmApplication.Pages;

namespace Zensoft.OpenErmApplication
{
    class LoginTest
    {
        IWebDriver driver;

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

        [Test]    
        public void InvalidCredentialTest()
        {
            LoginPage.EnterUsername(driver, "bala");
            LoginPage.EnterPassword(driver, "king123");
            LoginPage.SelectLanguageByText(driver, "English (Indian)");
            LoginPage.ClickOnLogin(driver);
            string actualValue = LoginPage.GetInvalidErrorMessage(driver);
           
            Assert.AreEqual("Invalid username or password", actualValue);
        }


        [Test]
        public void ValidCredentialTest()
        {
            LoginPage.EnterUsername(driver, "admin");
            LoginPage.EnterPassword(driver, "pass");
            LoginPage.SelectLanguageByText(driver, "English (Indian)");
            LoginPage.ClickOnLogin(driver);

            MainPage.WaitForPresenceOfCalendar(driver);
            string actualValue = MainPage.GetMainPageTitle(driver);    
            
            Assert.AreEqual("OpenEMR", actualValue);
        }
    }
}
