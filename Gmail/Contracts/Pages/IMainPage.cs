namespace Gmail.Contracts.Pages
{
    public interface IMainPage
    {
        void CreateLetter(string to, string subject, string message);
    }
}