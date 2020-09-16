using Gmail.Contracts.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace Gmail.Core.Driver
{
    public class Driver : IDriver
    {
        protected readonly IDriver _driver;

        public string Url { get; set; }
        public string Title { get; }
        public string PageSource { get; }
        public string CurrentWindowHandle { get; }
        public ReadOnlyCollection<string> WindowHandles { get; }

        public Driver(IDriver driver) => _driver = driver;
        public Screenshot GetScreenshot() => throw new NotImplementedException();
        public IWebElement FindElement(By @by) => _driver.FindElement(@by);
        public ReadOnlyCollection<IWebElement> FindElements(By @by) => _driver.FindElements(@by);

        public IOptions Manage() => _driver.Manage();
        public INavigation Navigate() => _driver.Navigate();
        public ITargetLocator SwitchTo() => _driver.SwitchTo();

        public void Back() => _driver.Navigate().Back();
        public void Forward() => _driver.Navigate().Forward();
        public void GoToUrl(string url) => _driver.Navigate().GoToUrl(url);
        public void GoToUrl(Uri url) => _driver.Navigate().GoToUrl(url);
        public void Refresh() => _driver.Navigate().Refresh();
        public void Close() => _driver.Close();
        public void Quit() => _driver.Quit();
        public void Dispose() => _driver.Close();
        public void Wait(Func<IDriver, bool> condition, int seconds) => new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds)).Until(d => condition(this));
    }
}