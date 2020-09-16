using Gmail.Config;
using Gmail.Contracts.Driver;
using Gmail.Contracts.Pages;
using OpenQA.Selenium;

namespace Gmail.Pages
{
    public class LoginPage : ILoginPage
    {
        private readonly IDriver _driver;
        public LoginPage(IDriver driver) => _driver = driver;
        private IWebElement NextButton => _driver.FindElement(By.XPath("//button[@jsname='LgbsSe']"));
        private IWebElement EmailInput => _driver.FindElement(By.Id("identifierId"));
        private IWebElement PasswordInput => _driver.FindElement(By.XPath("//input[@type='password']"));


        public LoginPage TryAuthorize()
        {
            //var _el = Wait(driver => driver.FindElement(By.XPath("dsdfs"))).Displayed;
            EmailInput.SendKeys(Conf.GetByValue("email"));
            if (NextButton.Enabled)
                NextButton.Click();
            _driver.Wait(d => PasswordInput.Displayed, 3);
            PasswordInput.SendKeys(Conf.GetByValue("password"));
            NextButton.Click();
            return new LoginPage(_driver);
        }
    }
}