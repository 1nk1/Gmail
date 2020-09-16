using Gmail.Config;
using Gmail.Contracts.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Gmail.Pages
{
    public class LoginPage : BasePage, ILoginPage
    {
        private IWebDriver _driver;
        public LoginPage(IWebDriver driver) : base(driver) => _driver = driver;

        private IWebElement NextButton => _driver.FindElement(By.XPath("//button[@jsname='LgbsSe']"));
        private IWebElement EmailInput => _driver.FindElement(By.Id("identifierId"));
        private IWebElement PasswordInput => _driver.FindElement(By.XPath("//input[@type='password']"));


        public LoginPage TryAuthorize()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Convert.ToDouble(Conf.GetByValue("ImplicitDelaySeconds"))));
            EmailInput.SendKeys(Conf.GetByValue("email"));
            if (NextButton.Enabled)
                NextButton.Click();
            if (wait.Until(d => PasswordInput.Displayed))
                PasswordInput.SendKeys(Conf.GetByValue("password"));
            NextButton.Click();
            return new LoginPage(_driver);
        }
    }
}