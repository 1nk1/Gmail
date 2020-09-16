using Gmail.Pages;

namespace Gmail.Contracts.Pages
{
    public interface ILoginPage
    {
        LoginPage TryAuthorize();
    }
}