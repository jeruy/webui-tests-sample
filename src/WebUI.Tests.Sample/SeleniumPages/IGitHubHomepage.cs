namespace WebUI.Tests.Sample.SeleniumPages
{
    using WebUI.Tests.Framework.Selenium;

    public interface IGitHubHomepage : IPage
    {
        bool IsSignUpLinkExists();

        void ClickSignUpLink();
    }
}