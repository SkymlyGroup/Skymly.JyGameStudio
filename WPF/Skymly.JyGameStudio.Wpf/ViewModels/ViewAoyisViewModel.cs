using Prism.Commands;
using Prism.Common;
using Prism.Mvvm;
using Prism.Regions;

using Skymly.JyGameStudio.Models;
using Skymly.JyGameStudio.Wpf.Core.Mvvm;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Tools;
namespace Skymly.JyGameStudio.Wpf.ViewModels
{
    public class ViewAoyisViewModel : RegionViewModelBase,IRegionMemberLifetime
    {
        public ViewAoyisViewModel(IRegionManager regionManager) : base(regionManager)
        {
            Aoyis = new ObservableCollection<Aoyi>(XmlSerializeTool.DeserializeFromFile<AoyiRoot>("Mod/Scripts/aoyis.xml").Aoyis);   
        }

        public ObservableCollection<Aoyi> Aoyis { get; private set; }
        public bool KeepAlive { get; }
    }
}
