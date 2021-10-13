using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Zensoft.OpenErmApplication.Pages;
using Zensoft.OpenErmApplication.Base;

namespace Zensoft.OpenErmApplication
{
    class LoginTest : WebDriverWrapper
    {
        
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

        [TestCase("admin", "pass", "English (Indian)", "OpenEMR")]
        [TestCase("physician", "physician", "Dutch", "OpenEMR")]
        [Test]
        public void ValidCredentialTest(string username,string password,string language,string expectedValue)
        {
            LoginPage.EnterUsername(driver, username);
            LoginPage.EnterPassword(driver, password);
            LoginPage.SelectLanguageByText(driver, language);
            LoginPage.ClickOnLogin(driver);

            MainPage.WaitForPresenceOfCalendar(driver);
            string actualValue = MainPage.GetMainPageTitle(driver);    
            
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
