﻿using OpenErmApplication.BaseObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.OpenErmApplication.Pages
{
    class LoginPage //: PageWrapper
    {
        private By _usernameLocator = By.Id("authUser");
        private By _passwordLocator = By.Id("clearPass");
        private By _languageLocator = By.Name("languageChoice");
        private By _loginLocator = By.XPath("//button[@type='submit']");
        private By _appDescLocator = By.XPath("//*[contains(text(),'most')]");
        private By _errorLocator = By.XPath("//div[contains(text(),'Invalid')]");

        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Enter Username
        public void EnterUsername(string username)
        {
            driver.FindElement(_usernameLocator).SendKeys(username);
            //TypeUsingLocator(_usernameLocator, username);
        }

        //enter password
        public void EnterPassword(string password)
        {
            driver.FindElement(_passwordLocator).SendKeys(password);
            //TypeUsingLocator(_passwordLocator, password);
        }

        //select language
        public void SelectLanguageByText(string language)
        {
            SelectElement selectLanguage = new SelectElement(driver.FindElement(_languageLocator));
            selectLanguage.SelectByText(language);
        }
        public void ClickOnLogin()
        {
            driver.FindElement(_loginLocator).Click();
        }

        public string GetApplicationDescription()
        {
            string description = driver.FindElement(_appDescLocator).Text;
            return description;
        }

        public string GetInvalidErrorMessage()
        {
            return driver.FindElement(_errorLocator).Text.Trim();
        }
    }
}
