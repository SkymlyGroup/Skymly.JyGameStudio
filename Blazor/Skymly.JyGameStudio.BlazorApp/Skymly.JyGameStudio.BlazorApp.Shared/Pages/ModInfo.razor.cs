using BootstrapBlazor.Components;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skymly.JyGameStudio.BlazorApp.Shared.Pages
{
    public sealed partial class ModInfo : ComponentBase
    {

        private List<MenuItem> Menus { get; set; }
        /// <summary>
        /// OnInitialized 方法
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Menus = GetIconSideMenuItems();
        }

        private static List<MenuItem> GetIconSideMenuItems()
        {
            var menus = new List<MenuItem>
            {
                new MenuItem() { Text = "API", Url=Constants.ApiUrl, Icon = "fa fa-fw fa-table", Target="_blank"  },
                new MenuItem() { Text = "Github", Url=Constants.ProjectUrl, Icon = "fa fa-fw fa-table", Target="_blank" },
                new MenuItem() { Text = "奥义", Icon = "fa fa-fw fa-table", Target="_blank"},
                new MenuItem() { Text = "特技", Icon = "fa fa-fw fa-table",Target="_blank"  },
                new MenuItem() { Text = "地图", Icon = "fa fa-fw fa-table", Target="_blank" },
                new MenuItem() { Text = "角色", Icon = "fa fa-fw fa-table", Target="_self" },
                new MenuItem() { Text = "物品", Icon = "fa fa-fw fa-table", Target="_self" },
            };
            return menus;
        }
    }
}
