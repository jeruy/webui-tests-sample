namespace WebUI.Tests.Sample
{
    using System;
    using System.IO;

    using Autofac;
    using Microsoft.Extensions.Configuration;
    using OpenQA.Selenium;

    using WebUI.Tests.Framework.Helpers;
    using WebUI.Tests.Framework.Selenium.DriverConfig;
    using WebUI.Tests.Sample.Configuration;

    public sealed class TestModule : Module
    {
        private const string EnvironmentAttributeKey = "Environment";

        protected override void Load(ContainerBuilder builder)
        {
            // Environment settings
            builder
                .Register(context => GetEnvironmentSettings(context.Resolve<ITestLogger>()))
                .As<IEnvironmentSettings>().InstancePerLifetimeScope();

            // Web Driver settings
            builder.RegisterType<WebDriverConfig>().As<IWebDriverConfig>().InstancePerLifetimeScope();

            // Selenium Web Driver creation
            builder
                .Register(c => c.Resolve<DriverFactory>().MakeWebDriver())
                .As<IWebDriver>().InstancePerLifetimeScope();
        }

        private static EnvironmentSettings GetEnvironmentSettings(ITestLogger logger)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                   .Build();

            var environment = Environment.GetEnvironmentVariable(EnvironmentAttributeKey)
                              ?? configuration[EnvironmentAttributeKey]
                              ?? "dev";

            logger.LogLine(FormattableString.Invariant($"[{nameof(TestModule)}]: Using '{environment}' environment configuration."));

            return new EnvironmentSettings() {
                BaseUrl = configuration["EnvironmentSettings:BaseUrl"]
            };
        }
    }
}