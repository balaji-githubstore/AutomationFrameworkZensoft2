using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenErmApplication.BaseObject
{
    class PageWrapper
    {
        protected IWebDriver driver;
        private IJavaScriptExecutor js;

        public PageWrapper(IWebDriver driver)
        {
            this.driver = driver;
            this.js = (IJavaScriptExecutor)driver;
        }

        public void ClickUsingLocator(By locator)
        {
            driver.FindElement(locator).Click();
        }
        public void TypeUsingLocator(By locator,string text)
        {
            driver.FindElement(locator).SendKeys(text);
        }
        public void JavaScriptClickUsingLocator(By locator)
        {
           
            IWebElement ele = driver.FindElement(locator);
            js.ExecuteScript("arguments[0].click();", ele);
        }
    }
}
