namespace WebUI.Tests.Sample.Configuration
{
    /// <summary>
    /// Interface for configuring the environment that the tests will run on.
    /// </summary>
    public interface IEnvironmentSettings
    {
        /// <summary>
        /// Gets or sets the base url of the website.
        /// </summary>
        string BaseUrl { get; set; }
    }
}
