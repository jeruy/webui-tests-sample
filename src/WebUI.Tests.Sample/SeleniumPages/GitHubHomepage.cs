using System;
namespace WebUI.Tests.Sample.SeleniumPages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    using WebUI.Tests.Framework.Selenium;
    using WebUI.Tests.Framework.Selenium.Utilities;

    public class GitHubHomepage : Page, IGitHubHomepage
    {
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/header/div/div[2]/div[2]/a[2]")]
        private readonly IWebElement signUpLink = null;

        public GitHubHomepage(IWebDriver driver, ICustomLocatorFactory customLocatorFactory)
            : base(driver, customLocatorFactory)
        {
        }

        public override string PageTitle => "The world’s leading software development platform · GitHub";

        public override string PageUrl => "http://www.github.com";

        public bool IsSignUpLinkExists()
        {
            return this.signUpLink != null;
        }

        public void ClickSignUpLink()
        {
            WaitTillSignUpLinkIsDisplayed();
            this.signUpLink.Click();
        }

        private void WaitTillSignUpLinkIsDisplayed(TimeSpan? defaultTimeOut = null)
        {
            var timeOut = defaultTimeOut ?? TimeSpan.FromMinutes(1);
            this.signUpLink.WaitForWebElementToDisplay(timeOut);
        }
    }
}
