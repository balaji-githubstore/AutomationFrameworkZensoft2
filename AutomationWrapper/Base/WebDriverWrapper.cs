using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
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

        public static string projectPath;
        public static ExtentReports extent; //helps setting up the report dir,intialization
        public static ExtentTest test; //create and storing the test method status, info, warning
        public static string screenShotPath;



        [OneTimeSetUp]
        public void Start()
        {
            //to avoid unnecessary update on each class intialization
            if (extent == null)
            {
                projectPath = Assembly.GetCallingAssembly().CodeBase;
                projectPath = projectPath.Substring(0, projectPath.LastIndexOf("bin"));
                projectPath = new Uri(projectPath).LocalPath;

                string reportPath = projectPath + @"Reports\OpenEMRSpark.html";

                ExtentSparkReporter reporter = new ExtentSparkReporter(reportPath);
                extent = new ExtentReports();
                extent.AttachReporter(reporter);
            }
        }

        [OneTimeTearDown]
        public void EndReport()
        {
            extent.Flush();
        }


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
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        public void TakeScreenShot(string testName)
        {
            if (driver != null)
            {
                string name = DateTime.Now.ToString().Replace('/', '-').Replace(':', '-');
                screenShotPath = projectPath + @"\Reports\screenshot_" + testName + "_" + name + ".png";

                ITakesScreenshot ts = (ITakesScreenshot)driver;
                Screenshot ss = ts.GetScreenshot();
                ss.SaveAsFile(screenShotPath);
            }
        }

        [TearDown]
        public void AddTestResultAndQuitBrowser()
        {
            string testName = TestContext.CurrentContext.Test.MethodName;

            TestStatus status = TestContext.CurrentContext.Result.Outcome.Status;

            if (status == TestStatus.Failed)
            {
                var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
                var errorMessage = TestContext.CurrentContext.Result.Message;
                TakeScreenShot(testName);
                test.Log(Status.Fail, stackTrace + errorMessage);
                test.Log(Status.Fail, "Failed - Snapshot below:");
                test.AddScreenCaptureFromPath(screenShotPath, title: testName);
            }
            else if (status == TestStatus.Passed)
            {
                TakeScreenShot(testName);
                test.Log(Status.Pass, "Passed - Snapshot below:");
                //test.AddScreenCaptureFromPath(screenShotPath, title: testName);
            }
            else if (status == TestStatus.Skipped)
            {
                test.Log(Status.Skip, "Skipped - " + testName);
            }
            driver.Quit();
        }

    }
}
