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

        private IWebDriver driver;
        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitForPresenceOfCalendar()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Until(x => x.FindElement(_calendarLocator));
        }

        public void ClickOnCalendar()
        {
            driver.FindElement(_calendarLocator).Click();
        }

        //get main page title
        public string GetMainPageTitle()
        {
            return driver.Title.Trim();
        }

        public void ClickOnAbout()
        {
            driver.FindElement(_AboutLocator).Click();
        }
    }
}
