using Prism.Mvvm;
using Prism.Navigation;

using System;
using System.Diagnostics;

namespace Skymly.JyGameStudio.XF.Core
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }
        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        private bool isBusy;
        public bool IsBusy { get => isBusy; set => SetProperty(ref isBusy, value); }

        private string title;

        public string Title { get => title; set => SetProperty(ref title, value); }

        public virtual void Destroy()
        {
            Debug.WriteLine($"{GetType().FullName} {nameof(Destroy)}");
        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }
    }
}
