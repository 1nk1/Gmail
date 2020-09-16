using Gmail.Config;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Gmail.Tests
{
    [TestFixture]
    public abstract class BaseTest
    {
        protected IWebDriver _driver { get; private set; }

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(new ChromeOptions { AcceptInsecureCertificates = true, PageLoadStrategy = PageLoadStrategy.Normal });
            _driver.Navigate().GoToUrl(Conf.GetByValue("BaseUrl"));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Convert.ToDouble(Conf.GetByValue("ImplicitDelaySeconds")));
            _driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown() => _driver.Quit();
    }
}