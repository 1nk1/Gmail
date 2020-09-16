using Gmail.Config;
using Gmail.Pages;
using NUnit.Framework;

namespace Gmail.Tests
{
    public class CreateLetterFlow : BaseTest
    {
        [Test]
        [TestCase("Subject topic", "Body Test")]
        public void SendLetter(string subject, string message)
        {
            var loginPage = new LoginPage(_driver);
            var mainPage = new MainPage(_driver);

            loginPage.TryAuthorize();
            mainPage.CreateLetters(Conf.GetByValue("email"), subject, message);
        }

        [Test]
        public void VerifyLettersAfterSending()
        {
            var loginPage = new LoginPage(_driver);
            var sendPage = new SendPage(_driver);

            loginPage.TryAuthorize();
            sendPage.NavigateToSentBox();
            sendPage.SelectLetters(10);
            sendPage.PrintSubjectToLog(10);
        }
    }
}