using Gmail.Contracts.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;

namespace Gmail.Pages
{
    public class SendPage : BasePage, ISendPage
    {
        private readonly IWebDriver _driver;

        public SendPage(IWebDriver driver) : base(driver) => _driver = driver;

        private ReadOnlyCollection<IWebElement> CheckBoxesElements => _driver.FindElements(By.XPath("//div[@title='Inbox']/ancestor::tr/td[2]/div"));
        private ReadOnlyCollection<IWebElement> SubjectsLetters => _driver.FindElements(By.XPath("//div[@title='Inbox']/ancestor::td/div[1]/div/div[2]"));
        private IWebElement SentLetterSidebar => _driver.FindElement(By.XPath("//a[@aria-label='Sent']"));

        public void NavigateToSentBox() => SentLetterSidebar.Click();

        public void SelectLetters(int count)
        {
            for (var i = 0; i < count; i++)
                CheckBoxesElements[i].Click();
        }

        public void PrintSubjectToLog(int count)
        {
            for (var i = 0; i < count; i++)
                Console.WriteLine(SubjectsLetters[i].Text);
        }
    }
}