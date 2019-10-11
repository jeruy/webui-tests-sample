namespace WebUI.Tests.Sample
{
    using System;

    using WebUI.Tests.Framework;

    public sealed class TestFixture : IDisposable
    {
        public TestFixture()
        {
            AutofacContainer
             .Setup<TestFixture>()
             .RegisterModule(new TestModule())
             .Build(this);
        }

        public ITestInitializer TestInitializer { get; set; }

        public void Dispose()
        {
            this.TestInitializer.DisposeContainer();
        }
    }
}
