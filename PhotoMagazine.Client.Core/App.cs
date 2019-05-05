using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using PhotoMagazine.Client.Core.ViewModels;
using MvvmCross;
using PhotoMagazine.Client.Core.Models.Base;

namespace PhotoMagazine.Client.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

#if DEBUG
            Mvx.IoCProvider.IoCConstruct<AppConfiguration>(ConfigurationManager.GetBase("Debug"));
#endif
#if !DEBUG
            Mvx.IoCProvider.IoCConstruct<AppConfiguration>(ConfigurationManager.GetBase("Release"));
#endif

            RegisterAppStart<LoginViewModel>();
        }
    }
}
