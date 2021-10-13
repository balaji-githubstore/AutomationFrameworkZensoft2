using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.OpenErmApplication.Pages
{
    class LoginPage
    {
        private static By _usernameLocator = By.Id("authUser");
        private static By _passwordLocator = By.Id("clearPass");
        private static By _languageLocator = By.Name("languageChoice");
        private static By _loginLocator = By.XPath("//button[@type='submit']");
        private static By _appDescLocator = By.XPath("//*[contains(text(),'most')]");
        private static By _errorLocator = By.XPath("//div[contains(text(),'Invalid')]");

        public static void EnterUsername(IWebDriver driver, string username)
        {
            driver.FindElement(_usernameLocator).SendKeys(username);
        }

        public static void EnterPassword(IWebDriver driver, string password)
        {
            driver.FindElement(_passwordLocator).SendKeys(password);
        }
        public static void SelectLanguageByText(IWebDriver driver, string language)
        {
            SelectElement selectLanguage = new SelectElement(driver.FindElement(_languageLocator));
            selectLanguage.SelectByText(language);
        }
        public static void ClickOnLogin(IWebDriver driver)
        {
            driver.FindElement(_loginLocator).Click();
        }

        public static string GetApplicationDescription(IWebDriver driver)
        {
            string description = driver.FindElement(_appDescLocator).Text;
            return description;
        }

        public static string GetInvalidErrorMessage(IWebDriver driver)
        {
            return driver.FindElement(_errorLocator).Text.Trim();
        }
    }
}
