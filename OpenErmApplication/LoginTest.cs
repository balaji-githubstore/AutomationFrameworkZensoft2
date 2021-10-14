using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Zensoft.OpenErmApplication.Pages;
using Zensoft.OpenErmApplication.Base;
using Zensoft.OpenErmApplication.Utilities;

namespace Zensoft.OpenErmApplication
{
    class LoginTest : WebDriverWrapper
    {
        //admin12,pass12,Dutch,Invalid username or password
        //jack,jack123,Dutch,Invalid username or password
        [Test,TestCaseSource(typeof(TestCaseSourceUtils), "InvalidCredentialData")]    
        public void InvalidCredentialTest(string username,string password,string language,string expectedValue)
        {
            LoginPage.EnterUsername(driver, username);
            LoginPage.EnterPassword(driver, password);
            LoginPage.SelectLanguageByText(driver, language);
            LoginPage.ClickOnLogin(driver);
            string actualValue = LoginPage.GetInvalidErrorMessage(driver);
           
            Assert.AreEqual(expectedValue, actualValue);
        }

        //[TestCase("admin", "pass", "English (Indian)", "OpenEMR")]
        //[TestCase("physician", "physician", "Dutch", "OpenEMR")]
        [Test,TestCaseSource(typeof(TestCaseSourceUtils), "ValidCredentialData")]
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
