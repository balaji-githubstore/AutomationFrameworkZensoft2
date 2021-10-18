using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Zensoft.AutomationWrapper.Utilities;

namespace Zensoft.AutomationWrapper.Base
{
   public class WebDriverWrapper
    {
        protected IWebDriver driver;

        [SetUp]
        public void LaunchBrowser()
        {

            string projectPath = Assembly.GetCallingAssembly().CodeBase;
            projectPath = projectPath.Substring(0, projectPath.IndexOf("bin"));
            projectPath = projectPath.Replace("file:///", "");

            string browser = JsonUtils.GetValue(projectPath+@"/testdata/data.json", "browser");
            string driverPath= JsonUtils.GetValue(projectPath + @"/testdata/data.json", "driver");

            if (browser.ToLower().Equals("ff"))
            {
                driver = new FirefoxDriver(driverPath);
            }
            else if (browser.ToLower().Equals("edge"))
            {
                driver = new EdgeDriver(driverPath);
            }
            else
            {
                driver = new ChromeDriver(driverPath);
            }

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            string url = JsonUtils.GetValue(projectPath + @"/testdata/data.json", "url");
            driver.Url = url;
        }

        [TearDown]
        public void EndBrowser()
        {
            driver.Quit();
        }


    }
}
