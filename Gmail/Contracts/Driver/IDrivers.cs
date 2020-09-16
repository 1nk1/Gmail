using OpenQA.Selenium;
using System;

namespace Gmail.Contracts.Driver
{
    public interface IDriver : INavigation, ITakesScreenshot, IWebDriver, IWaits { }

    public interface IWaits
    {
        void Wait(Func<IDriver, bool> condition, int seconds);
    }
}