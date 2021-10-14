using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.OpenErmApplication.Pages
{
    class MainPage
    {
        private static By _calendarLocator = By.XPath("//div[text()='Calendar' or text()='Agenda']");
        private static By _AboutLocator = By.XPath("//div[text()='About']");

        public static void WaitForPresenceOfCalendar(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Until(x => x.FindElement(_calendarLocator));
        }

        public static void ClickOnCalendar(IWebDriver driver)
        {
            driver.FindElement(_calendarLocator).Click();
        }

        //get main page title
        public static string GetMainPageTitle(IWebDriver driver)
        {
            return driver.Title.Trim();
        }

        public static void ClickOnAbout(IWebDriver driver)
        {
            driver.FindElement(_AboutLocator).Click();
        }
    }
}
