namespace WebUI.Tests.Sample.Configuration
{
    using System;
    using System.Collections.Generic;
    using OpenQA.Selenium;
    using WebUI.Tests.Framework.Selenium;
    using WebUI.Tests.Framework.Selenium.DriverConfig;

    internal sealed class WebDriverConfig : IWebDriverConfig
    {
        public RunConfiguration RunConfiguration { get; set; } = RunConfiguration.Chrome;

        public TimeSpan CommandTimeout { get; set; }

        public TimeSpan ImplicitlyWait { get; set; } = TimeSpan.FromSeconds(3);

        public TimeSpan SetPageLoadTimeout { get; set; }

        public TimeSpan SetScriptTimeout { get; set; }

        public bool? UseValueChangingEventHandlers { get; set; }

        public bool? UseHttpConnectionPatch { get; set; }

        public string FileDownloadDirectory { get; set; }

        public bool UseSeleniumGrid { get; set; }

        public bool UseRemoteWebDriver { get; set; }

        public Uri RemoteDriverAddress { get; set; }

        public Proxy BrowserProxy { get; set; }

        public IDictionary<string, string> Capabilities { get; set; }

        public IDictionary<string, string> CloudUiCapabilities { get; set; }
    }
}
