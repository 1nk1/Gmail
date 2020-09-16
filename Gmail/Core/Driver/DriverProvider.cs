using Gmail.Contracts.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Gmail.Core.Driver
{
    public class DriverProvider : IDriverProvider<IWebDriver>
    {
        public IWebDriver GetDriver()
        {
            var optionsChr = new ChromeOptions { AcceptInsecureCertificates = true };
            optionsChr.AddArgument("disable-infobars");

            optionsChr.SetLoggingPreference(LogType.Browser, LogLevel.All);
            var driver = new ChromeDriver(optionsChr);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}