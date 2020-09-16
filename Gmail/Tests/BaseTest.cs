using Autofac;
using Gmail.Contracts.Driver;
using Gmail.Core;
using Gmail.Modules;
using NUnit.Framework;

namespace Gmail.Tests
{
    [TestFixture]
    public abstract class BaseTest
    {
        protected IDriver driver { get; private set; }
        protected ILifetimeScope lifescope { get; private set; }
        [SetUp]
        public void SetUp()
        {
            var builder = new ContainerBuilder();
            RegisterDependencies(builder);
            lifescope = builder.Build();
            InitializeWebDriver();

            //_driver = new ChromeDriver();
            //_driver.Navigate().GoToUrl(Conf.GetByValue("BaseUrl"));
            //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            //_driver.Manage().Window.Maximize();
        }

        protected virtual void InitializeWebDriver() => driver = lifescope.Resolve<IDriver>();

        private void RegisterDependencies(ContainerBuilder builder)
        {
            builder.RegisterModule<WebDriverModule>();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            lifescope.Dispose();
        }

    }
}