namespace WebUI.Tests.Sample.SeleniumPages
{
    using System;

    using WebUI.Tests.Framework.Selenium;

    public interface IGitHubSignUpPage : IPage
    {
        void EnterUsername(string username, TimeSpan? defaultTimeOut = null);

        string GetUsernameValue();

        string GetUsernameValidationMessage();

        bool NextButtonIsDisabled();

        bool UsernameValidationMessageIsNotAvailable();

        bool UsernameValidationMessageIsDisplayed();
    }
}
