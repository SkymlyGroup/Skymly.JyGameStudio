using Prism.Regions;

using Skymly.JyGameStudio.Wpf.Core.Mvvm;
using Skymly.JyGameStudio.Wpf.Services.Interfaces;

namespace Skymly.JyGameStudio.Wpf.Modules.ModuleName.ViewModels
{
    public class ViewAViewModel : RegionViewModelBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ViewAViewModel(IRegionManager regionManager, IMessageService messageService) :
            base(regionManager)
        {
            Message = messageService.GetMessage();
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }
    }
}
