using Prism.Regions;

using System;
using System.Diagnostics;

namespace Skymly.JyGameStudio.Wpf.Core.Mvvm
{
    public class RegionViewModelBase : ViewModelBase, INavigationAware, IConfirmNavigationRequest
    {
        protected IRegionManager RegionManager { get; private set; }

        public RegionViewModelBase(IRegionManager regionManager)
        {
            RegionManager = regionManager;
        }

        public virtual void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            continuationCallback(true);
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
            Debug.WriteLine($"{GetType().Name} {nameof(OnNavigatedFrom)}");
        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            Debug.WriteLine($"{GetType().Name} {nameof(OnNavigatedTo)}");

        }
    }
}
