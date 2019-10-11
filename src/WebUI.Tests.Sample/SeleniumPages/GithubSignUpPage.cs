namespace WebUI.Tests.Sample.SeleniumPages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    using WebUI.Tests.Framework.Selenium;
    using WebUI.Tests.Framework.Selenium.Utilities;

    public class GitHubSignUpPage : Page, IGitHubSignUpPage
    {
        [FindsBy(How = How.Id, Using = "user_login")]
        private readonly IWebElement usernameInput = null;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"signup-form\"]/auto-check[1]/dl/dd[2]/div/div")]
        private readonly IList<IWebElement> userNameValidationMessageElements = null;

        [FindsBy(How = How.Id, Using = "signup_button")]
        private readonly IWebElement nextButton = null;

        private readonly By userNameValidationMessageNoteLocator = 
            By.XPath("/html/body/div[4]/main/div/div/div[2]/div[1]/form/auto-check[1]/dl/dd/p");

        public GitHubSignUpPage(IWebDriver driver, ICustomLocatorFactory customLocatorFactory)
           : base(driver, customLocatorFactory)
        {
        }

        public override string PageTitle => "Join GitHub · GitHub";

        public override string PageUrl => "https://github.com/join";

        public void EnterUsername(string username, TimeSpan? defaultTimeOut = null)
        {
            var timeOut = defaultTimeOut ?? TimeSpan.FromSeconds(2);
            this.usernameInput.WaitForWebElementToDisplay(timeOut);
            this.usernameInput.Clear();
            this.usernameInput.SendKeys(username);
        }

        public string GetUsernameValue()
        {
            return this.usernameInput.GetAttribute("value");
        }

        public string GetUsernameValidationMessage()
        {
            if (this.userNameValidationMessageElements.Count > 0)
            {
                return this.userNameValidationMessageElements.First().Text;
            }
            else
            {
                //there is a time when error message was displayed in p tag as note
                var pTagElements = this.Driver.FindElements(userNameValidationMessageNoteLocator);
                if (pTagElements.Count == 0) return string.Empty;
                return pTagElements.First().Text;
            }
        }

        public bool UsernameValidationMessageIsNotAvailable()
        {
            return this.userNameValidationMessageElements.Count == 0;
        }

        public bool UsernameValidationMessageIsDisplayed()
        {
            if (this.userNameValidationMessageElements.Count > 0)
            {
                return this.userNameValidationMessageElements.First().Displayed;
            }
            else
            {
                //there is a time when error message was displayed in p tag as note
                var pTagElements = this.Driver.FindElements(userNameValidationMessageNoteLocator);
                if (pTagElements.Count == 0) return false;
                return pTagElements.First().Displayed;
            }
        }

        public bool NextButtonIsDisabled()
        {
            this.nextButton.WaitForWebElementToDisplay(TimeSpan.FromSeconds(2));
            return nextButton.Enabled == false;
        }
    }
}
