using Autofac;
using Gmail.Contracts.Pages;
using Gmail.Pages;

namespace Gmail.Modules
{
    public class PagesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainPage>().As<IMainPage>().SingleInstance();
            builder.RegisterType<LoginPage>().As<ILoginPage>().SingleInstance();
            builder.RegisterType<SendPage>().As<ISendPage>().SingleInstance();
        }
    }
}