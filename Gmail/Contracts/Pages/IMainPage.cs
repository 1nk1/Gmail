using Gmail.Pages;

namespace Gmail.Contracts.Pages
{
    public interface IMainPage
    {
        MainPage CreateLetter(string to, string subject, string message);
        MainPage CreateLetters(string to, string subject, string message, int count = 10);
    }
}