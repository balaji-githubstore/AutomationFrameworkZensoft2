using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Zensoft.AutomationWrapper.Base;
using Zensoft.OpenErmApplication.Pages;
using Zensoft.OpenErmApplication.Utilities;

namespace Zensoft.OpenErmApplication
{
    class LoginTest : WebDriverWrapper
    {

        //admin12,pass12,Dutch,Invalid username or password
        //jack,jack123,Dutch,Invalid username or password
        [Test, TestCaseSource(typeof(TestCaseSourceUtils), "InvalidCredentialData")]
        public void InvalidCredentialTest(string username,string password,string language,string expectedValue)
        {
            LoginPage login = new LoginPage(driver);

            login.EnterUsername(username);
            test.Log(Status.Info, "entered username " + username);
            login.EnterPassword(password);
            test.Log(Status.Info, "entered password");
            login.SelectLanguageByText(language);
            test.Log(Status.Info, "Selected language "+language);
            login.ClickOnLogin();
            string actualValue = login.GetInvalidErrorMessage();
           
            Assert.AreEqual(expectedValue, actualValue);
            test.Log(Status.Info, "Compeleted the validation - actual value is " + actualValue);
        }

        //[TestCase("admin", "pass", "English (Indian)", "OpenEMR")]
        //[TestCase("physician", "physician", "Dutch", "OpenEMR")]
        [Test,TestCaseSource(typeof(TestCaseSourceUtils), "ValidCredentialData")]
        public void ValidCredentialTest(string username,string password,string language,string expectedValue)
        {
            LoginPage login = new LoginPage(driver);
            login.EnterUsername(username);
            login.EnterPassword(password);
            login.SelectLanguageByText(language);
            login.ClickOnLogin();

            MainPage main = new MainPage(driver);
            main.WaitForPresenceOfCalendar();
            string actualValue = main.GetMainPageTitle();    
            
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
