using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.OpenErmApplication.Pages
{
    class AboutPage
    {
        private static By _headerLocator = By.TagName("h1");
        private static By _versionrLocator = By.TagName("h4");
        private static string mscFrameName = "msc";

        public static void SwitchToMscFrame(IWebDriver driver)
        {
            driver.SwitchTo().Frame(mscFrameName);
        }
        public static void SwitchOutOfFrame(IWebDriver driver)
        {
            driver.SwitchTo().DefaultContent();
        }
        public static string GetHeader(IWebDriver driver)
        {
            SwitchToMscFrame(driver);
            string h1= driver.FindElement(_headerLocator).Text;
            SwitchOutOfFrame(driver);
            return h1;
        }

        public static string GetVersion(IWebDriver driver)
        {
            SwitchToMscFrame(driver);
            string version = driver.FindElement(_versionrLocator).Text;
            SwitchOutOfFrame(driver);
            return version;
        }
    }
}
