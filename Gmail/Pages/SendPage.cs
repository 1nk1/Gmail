using Gmail.Contracts.Driver;
using Gmail.Contracts.Pages;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Gmail.Pages
{
    public class SendPage : ISendPage
    {
        private readonly IDriver _driver;
        public SendPage(IDriver driver) => _driver = driver;
        private ReadOnlyCollection<IWebElement> chekBoxElement => _driver.FindElements(By.XPath("//div[@aria-checked='false']"));
        private IWebElement SentLetterSidebar => _driver.FindElement(By.XPath("//a[@aria-label='Sent']"));

        private ReadOnlyCollection<IWebElement> example => _driver.FindElements(By.CssSelector("a[href='https://mail.google.com/mail/u/1/#sent']"));
        public void SelectFirstTenLetters()
        {
            throw new System.NotImplementedException();
        }
    }
}