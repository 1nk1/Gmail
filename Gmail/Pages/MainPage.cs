using Gmail.Contracts.Driver;
using Gmail.Contracts.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Gmail.Pages
{
    public class MainPage : IMainPage
    {
        private readonly IDriver _driver;

        public MainPage(IDriver driver) => _driver = driver;

        private IWebElement ComposeButton => _driver.FindElement(By.XPath("//div[@class='z0']//div[.='Compose']"));
        private IWebElement MessageSent => _driver.FindElement(By.XPath("//span[.='Message sent.']"));
        private IWebElement ToTextArea => _driver.FindElement(By.Name("to"));
        private IWebElement SubjectTextArea => _driver.FindElement(By.XPath("//input[@placeholder='Subject']"));
        private IWebElement MessageTextArea => _driver.FindElement(By.XPath("//div[@aria-label='Message Body']"));
        private IWebElement SendButton => _driver.FindElement(By.XPath("//div[@role='button' and contains(., 'Send')]"));
        private ReadOnlyCollection<IWebElement> ListCheckbox => _driver.FindElements(By.XPath("//td[@data-tooltip='Select']"));

        public void CreateLetter(string to, string subject, string message)
        {
            ComposeButton.Click();
            ToTextArea.SendKeys(to);
            SubjectTextArea.SendKeys(subject);
            MessageTextArea.SendKeys(message);
            _driver.Wait(d => SendButton.Displayed, 45);
            _driver.Wait(d => SendButton.Enabled, 3);
            SendButton.Click();
            _driver.Wait(driver => MessageSent.Displayed, 4);
            Assert.That(MessageSent.Text, Is.EqualTo("Message sent."));
        }
    }
}