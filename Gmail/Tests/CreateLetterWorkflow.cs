using Autofac;
using Gmail.Config;
using Gmail.Contracts.Pages;
using NUnit.Framework;

namespace Gmail.Tests
{
    public class CreateLetterFlow : BaseTest
    {
        [Test]
        [TestCase("Subject", "test")]
        public void SendLetter(string subject, string message)
        {
            var mainPage = lifescope.Resolve<IMainPage>();
            var loginPage = lifescope.Resolve<ILoginPage>();

            loginPage.TryAuthorize();
            mainPage.CreateLetter(Conf.GetByValue("email"), subject, message);
        }

        [Test]
        public void VerifyLettersAfterSending()
        {
            var loginPage = lifescope.Resolve<ILoginPage>();
            var sendPage = lifescope.Resolve<ISendPage>();

            loginPage.TryAuthorize();
            sendPage.SelectFirstTenLetters();
        }
    }
}