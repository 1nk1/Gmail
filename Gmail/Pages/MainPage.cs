using Gmail.Config;
using Gmail.Contracts.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Gmail.Pages
{
    public class MainPage : BasePage, IMainPage
    {
        private readonly IWebDriver _driver;

        public MainPage(IWebDriver driver) : base(driver) => _driver = driver;

        private IWebElement ComposeButton => _driver.FindElement(By.XPath("//div[@class='z0']//div[.='Compose']"));
        private IWebElement MessageSent => _driver.FindElement(By.XPath("//span[.='Message sent.']"));
        private IWebElement ToTextArea => _driver.FindElement(By.Name("to"));
        private IWebElement SubjectTextArea => _driver.FindElement(By.XPath("//input[@placeholder='Subject']"));
        private IWebElement MessageTextArea => _driver.FindElement(By.XPath("//div[@aria-label='Message Body']"));
        private IWebElement SendButton => _driver.FindElement(By.XPath("//div[@role='button' and contains(., 'Send')]"));

        public MainPage CreateLetter(string to, string subject, string message)
        {
            ComposeButton.Click();
            ToTextArea.SendKeys(to);
            SubjectTextArea.SendKeys(subject);
            MessageTextArea.SendKeys(message);
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Convert.ToDouble(Conf.GetByValue("ExplicitDelaySeconds"))));
            if (wait.Until(d => SendButton.Displayed))
                SendButton.Click();
            wait.Until(d => MessageSent.Displayed);
            Assert.That(MessageSent.Text, Is.EqualTo("Message sent."));
            return new MainPage(_driver);
        }

        public MainPage CreateLetters(string to, string subject, string message, int count = 10)
        {
            for (var i = 0; i < count; i++)
                CreateLetter(to, subject, message);
            return new MainPage(_driver);
        }
    }
}