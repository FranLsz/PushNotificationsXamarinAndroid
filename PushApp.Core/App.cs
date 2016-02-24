using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using PushApp.Core.Servicios;
using PushApp.Core.ViewModels;

namespace PushApp.Core
{
    public class App : MvxApplication
    {
        public App()
        {
            Mvx.RegisterType<IServicioDatos, ServicioDatos>();
            Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<HomeViewModel>());
        }
    }
}