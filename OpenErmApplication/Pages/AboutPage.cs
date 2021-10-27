using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.OpenErmApplication.Pages
{
    class AboutPage
    {
        private By _headerLocator = By.TagName("h1");
        private By _versionrLocator = By.TagName("h4");
        private string mscFrameName = "msc";
        private IWebDriver driver;
        public AboutPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SwitchToMscFrame()
        {
            driver.SwitchTo().Frame(mscFrameName);
        }
        public void SwitchOutOfFrame()
        {
            driver.SwitchTo().DefaultContent();
        }
        public string GetHeader()
        {
            SwitchToMscFrame();
            string h1= driver.FindElement(_headerLocator).Text;
            SwitchOutOfFrame();
            return h1;
        }

        public string GetVersion()
        {
            SwitchToMscFrame();
            string version = driver.FindElement(_versionrLocator).Text;
            SwitchOutOfFrame();
            return version;
        }
    }
}
