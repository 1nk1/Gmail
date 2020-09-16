using Autofac;
using Gmail.Contracts.Driver;
using Gmail.Core.Driver;
using OpenQA.Selenium;

namespace Gmail.Modules
{
    public class WebDriverModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DriverProvider>().As<IDriverProvider<IWebDriver>>().AsSelf();
            builder.Register(c => c.Resolve<IDriverProvider<IWebDriver>>().GetDriver()).As<IDriver>().SingleInstance();
            builder.RegisterModule<PagesModule>();
        }
    }
}