using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using Skymly.JyGameStudio.Wpf.ViewModels;
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

        protected override void OnInitialized()
        {
            base.OnInitialized();
            //Container.Resolve<IRegionManager>().RequestNavigate("ContentRegion", "ViewAoyis");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewAoyis, ViewAoyisViewModel>();
            containerRegistry.RegisterForNavigation<ViewBattles, ViewBattlesViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
        }
    }
}
