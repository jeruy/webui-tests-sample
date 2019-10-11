namespace WebUI.Tests.Sample.Tests.Steps
{
    using FluentAssertions;
    using FluentAssertions.Execution;

    using WebUI.Tests.Framework.Selenium;
    using WebUI.Tests.Sample.Configuration;
    using WebUI.Tests.Sample.SeleniumPages;

    internal sealed class UserSignUpSteps
    {
        private readonly IGitHubHomepage gitHubHomePage;
        private readonly IGitHubSignUpPage gitHubSignUpPage;
        private readonly IEnvironmentSettings settings;

        public UserSignUpSteps(
            IGitHubHomepage gitHubHomePage,
            IGitHubSignUpPage gitHubSignUpPage,
            IEnvironmentSettings settings)
        {
            this.gitHubHomePage = gitHubHomePage;
            this.gitHubSignUpPage = gitHubSignUpPage;
            this.settings = settings;
        }

        public UserSignUpSteps GivenINavigateToGitHubHomePage()
        {
            if (string.IsNullOrEmpty(settings.BaseUrl))
            {
                this.gitHubHomePage.NavigateTo();
                return this;
            }

            this.gitHubHomePage.NavigateTo(settings.BaseUrl);
            return this;
        }

        public UserSignUpSteps GivenINavigateToGitHubSignUpPage()
        {
            this.gitHubSignUpPage.NavigateTo();
            return this;
        }

        public UserSignUpSteps WhenHomePageIsLoaded()
        {
            this.gitHubHomePage.WaitForPageTitleToDisplay();
            return this;
        }

        public UserSignUpSteps WhenSignUpPageIsLoaded()
        {
            this.gitHubSignUpPage.WaitForPageTitleToDisplay();
            return this;
        }

        public UserSignUpSteps WhenIClickOnSignUpLink()
        {
            this.gitHubHomePage.ClickSignUpLink();
            return this;
        }

        public UserSignUpSteps WhenIEnterUsername(string username)
        {
            this.gitHubSignUpPage.EnterUsername(username);
            return this;
        }

        public UserSignUpSteps ThenIExpectSignUpLinkIsExists()
        {
            this.gitHubHomePage.IsSignUpLinkExists().Should().BeTrue();
            return this;
        }

        public UserSignUpSteps ThenIExpectToBeRedirectedToSignUpPage()
        {
            IsBrowserCurrentlyDisplayingThisPage(this.gitHubSignUpPage).Should().BeTrue();
            return this;
        }

        public UserSignUpSteps ThenIExpectIAmCurrentlyOnSignUpPage()
        {
            IsBrowserCurrentlyDisplayingThisPage(this.gitHubSignUpPage).Should().BeTrue();
            return this;
        }
        public UserSignUpSteps ThenIExpectNextButtonIsDisabled()
        {
            this.gitHubSignUpPage.NextButtonIsDisabled().Should().BeTrue();
            return this;
        }

        public UserSignUpSteps ThenIExpectUsernameHasValue(string expectedUsername)
        {
            this.gitHubSignUpPage
                .GetUsernameValue()
                .Should()
                .Be(expectedUsername);

            return this;
        }

        public UserSignUpSteps ThenIExpectValidationErrorMessageIsDisplayed(string expectedMessage)
        {
            using (new AssertionScope())
            {
                this.gitHubSignUpPage
                    .UsernameValidationMessageIsDisplayed()
                    .Should()
                    .BeTrue("Validation Error Message is expected to be displayed with expected message");

                this.gitHubSignUpPage
                    .GetUsernameValidationMessage()
                    .Should()
                    .Equals(expectedMessage);
            };

            return this;
        }

        public UserSignUpSteps ThenIExpectValidationErrorMessageIsNotBeDisplayed()
        {
            this.gitHubSignUpPage
                .UsernameValidationMessageIsNotAvailable()
                .Should()
                .BeTrue("Validation Error Message is expected not to be displayed!");

            return this;
        }

        private static bool IsBrowserCurrentlyDisplayingThisPage<T>(T currentPage) 
            where T : IPage
        {
            return currentPage.BrowserIsCurrentlyDisplayingThisPage();
        }
    }
}
