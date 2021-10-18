using NUnit.Framework;
using OpenQA.Selenium;
using Zensoft.AutomationWrapper.Base;

namespace Zensoft.OrageHrm
{
    public class LoginTest : WebDriverWrapper
    {
        [Test]
        public void InvalidCredentialTest()
        {
            driver.FindElement(By.Id("txtUsername")).SendKeys("admin");
            driver.FindElement(By.Id("txtPassword")).SendKeys("admin1");

            driver.FindElement(By.Id("btnLogin")).Click();

            Assert.AreEqual("Invalid credentials", driver.FindElement(By.Id("spanMessage")).Text);

        }
    }
}