using Prism.Commands;
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
    public class ViewBattlesViewModel : RegionViewModelBase, IRegionMemberLifetime
    {
        public ViewBattlesViewModel(IRegionManager regionManager) : base(regionManager)
        {
            Battles = new ObservableCollection<Battle>(XmlSerializeTool.DeserializeFromFile<BattleRoot>("Mod/Scripts/battles.xml").Battles);
        }

        public ObservableCollection<Battle>  Battles { get; set; }


        public bool KeepAlive { get; } = false;
    }
}
