namespace WebUI.Tests.Sample.Tests
{
    using System;

    using EnsureThat;
    using Xunit;
    using Xunit.Abstractions;

    using WebUI.Tests.Sample.Tests.Steps;

    public class UserSignUpTests : IDisposable, IClassFixture<TestFixture>
    {
        private readonly TestFixture testFixture = null;
        private readonly UserSignUpSteps steps = null;

        private const int VALID_USERNAME_LENGTH = 39;

        public UserSignUpTests(TestFixture testFixture, ITestOutputHelper output)
        {
            EnsureArg.IsNotNull(testFixture, nameof(TestFixture));

            this.testFixture = testFixture;
            this.testFixture.TestInitializer.InjectUnsetClassMembers(this, output.WriteLine);
        }

        public void Dispose() => this.testFixture.TestInitializer.DisposeScope();

        [Fact]
        public void Should_Be_Able_To_View_SignUp_LinkButton_On_HomePage()
        {
            steps
                .GivenINavigateToGitHubHomePage()
                .WhenHomePageIsLoaded()
                .ThenIExpectSignUpLinkIsExists();
        }

        [Fact]
        public void Should_Be_Able_To_Go_To_SignUpPage_From_HomePage()
        {
            steps
                .GivenINavigateToGitHubHomePage()
                .WhenHomePageIsLoaded()
                .WhenIClickOnSignUpLink()
                .ThenIExpectToBeRedirectedToSignUpPage();
        }

        [Fact]
        public void Should_Disabled_Next_Button_When_SignUp_Form_Is_Empty()
        {
            steps
                .GivenINavigateToGitHubSignUpPage()
                .WhenSignUpPageIsLoaded()
                .ThenIExpectIAmCurrentlyOnSignUpPage()
                .ThenIExpectNextButtonIsDisabled();
        }

        [Theory]
        [InlineData("ValidusernameAutomationTest123")]
        [InlineData("Validusername-AutomationTest123")]
        [InlineData("123Validusername-AutomationTest123")]
        public void Should_Be_Able_To_Enter_Valid_Username(string validUsername)
        {
            steps
                .GivenINavigateToGitHubSignUpPage()
                .WhenIEnterUsername(validUsername)
                .ThenIExpectUsernameHasValue(validUsername)
                .ThenIExpectValidationErrorMessageIsNotBeDisplayed();
        }

        [Theory]
        [InlineData("~!@#$%^&*(")]
        [InlineData("!@#$%Invalidusername-AutomationTest")]
        [InlineData("Invalidusername-AutomationTest123!@#$%")]
        public void Should_Display_Error_Validation_Message_When_Invalid_Username_Is_Entered(string invalidUsername)
        {
            string expectedMessage = "Username may only contain alphanumeric characters or single hyphens, " +
                "and cannot begin or end with a hyphen.";

            steps
                .GivenINavigateToGitHubSignUpPage()
                .WhenIEnterUsername(invalidUsername)
                .ThenIExpectUsernameHasValue(invalidUsername)
                .ThenIExpectValidationErrorMessageIsDisplayed(expectedMessage);
        }

        [Fact]
        public void Should_Display_Error_Validation_Message_When_Username_Is_Exceed_Max_Length()
        {
            string expectedMessage = "Username is too long (maximum is 39 characters).";
            string longUserName = "InvalidUsername1234567890123456789012345678901234567890";
            steps
                .GivenINavigateToGitHubSignUpPage()
                .WhenIEnterUsername(longUserName)
                .ThenIExpectUsernameHasValue(longUserName)
                .ThenIExpectValidationErrorMessageIsDisplayed(expectedMessage);
        }

    }
}
