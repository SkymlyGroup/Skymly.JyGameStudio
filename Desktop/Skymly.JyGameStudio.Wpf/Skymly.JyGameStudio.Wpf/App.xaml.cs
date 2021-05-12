using Prism.Ioc;
using Prism.Modularity;

using Skymly.JyGameStudio.Wpf.Modules.ModuleName;
using Skymly.JyGameStudio.Wpf.Services;
using Skymly.JyGameStudio.Wpf.Services.Interfaces;
using Skymly.JyGameStudio.Wpf.Views;

using System.Windows;

namespace Skymly.JyGameStudio.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleNameModule>();
        }
    }
}
