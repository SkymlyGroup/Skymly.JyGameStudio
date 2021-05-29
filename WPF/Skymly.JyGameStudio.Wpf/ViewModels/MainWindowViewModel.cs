using Prism.Commands;
using Prism.Regions;

using Skymly.JyGameStudio.Wpf.Core.Mvvm;
using Skymly.JyGameStudio.Wpf.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Skymly.JyGameStudio.Wpf.ViewModels
{
    public class MainWindowViewModel : RegionViewModelBase
    {

       
        public List<Type> Views { get; set; }


        public MainWindowViewModel(IRegionManager regionManager) : base(regionManager)
        {
            this.Title = "Prism Application";
            Views = GetType().Assembly.GetTypes().Where(v => typeof(UserControl).IsAssignableFrom(v)).ToList();

        }

        private Type currentItem;
        public Type CurrentItem 
        { 
            get => currentItem;
            set 
            {
                SetProperty(ref currentItem, value);
                RegionManager.RequestNavigate("ContentRegion", value.Name);
            }
        }



    }
}
