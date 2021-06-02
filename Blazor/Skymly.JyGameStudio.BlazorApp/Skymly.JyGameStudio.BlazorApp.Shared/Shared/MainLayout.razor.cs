using BootstrapBlazor.Components;

using Microsoft.AspNetCore.Components.Routing;

using Skymly.JyGameStudio.BlazorApp.Shared.Pages;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using static System.Net.Mime.MediaTypeNames;

namespace Skymly.JyGameStudio.BlazorApp.Shared.Shared
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class MainLayout
    {
        private bool UseTabSet { get; set; } = true;

        private string Theme { get; set; } = "";

        private bool IsOpen { get; set; }

        private bool IsFixedHeader { get; set; } = true;

        private bool IsFixedFooter { get; set; } = true;

        private bool IsFullSide { get; set; } = true;

        private bool ShowFooter { get; set; } = true;

        private List<MenuItem> Menus { get; set; }

        private Dictionary<string, string> TabItemTextDictionary { get; set; }

        /// <summary>
        /// OnInitialized 方法
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            // 模拟异步线程切换，正式代码中删除此行代码
            await Task.Yield();

            ShowFooter = false;
            IsFixedFooter = false;


            // 菜单获取可以通过数据库获取，此处为示例直接拼装的菜单集合
            TabItemTextDictionary = new()
            {
                [""] = "Index",
                ["ModInfo"] = "哈哈"
            };
            Menus = GetIconSideMenuItems();
        }

        private static List<MenuItem> GetIconSideMenuItems()
        {
            var menus = new List<MenuItem>
            {
                new MenuItem() { Text = "首页", Icon = "fa fa-fw fa-fa", Url = "/" },
                
                //new MenuItem() { Text = "Table", Icon = "fa fa-fw fa-table", Url = "table" },
                new MenuItem("原版游戏脚本",null,"fa fa-fw fa-check-square-o")
                {
                    Url="/Scripts",
                   Items =new List<MenuItem>
                   {
                        new MenuItem() { Text = "奥义", Icon = "fa fa-fw fa-table", Url = "/Aoyis" },
                        new MenuItem() { Text = "战斗", Icon = "fa fa-fw fa-table", Url = "/Battles"  },
                        new MenuItem() { Text = "剧情", Icon = "fa fa-fw fa-table", Url="/Storys"  },
                        new MenuItem() { Text = "技能", Icon = "fa fa-fw fa-table", Url="/Skills" },
                        new MenuItem() { Text = "内功", Icon = "fa fa-fw fa-table", Url="Internals" },
                        new MenuItem() { Text = "特技", Icon = "fa fa-fw fa-table", Url="/Speicals" },
                        new MenuItem() { Text = "地图", Icon = "fa fa-fw fa-table", Url="/Maps" },
                        new MenuItem() { Text = "角色", Icon = "fa fa-fw fa-table", Url="/Roles" },
                        new MenuItem() { Text = "物品", Icon = "fa fa-fw fa-table", Url="/Items" },
                   }
                },
                new MenuItem()
                {
                    Text="Mod信息",Icon="fa fa-fw fa-check-square-o",Url="/ModInfo"
                },
                new MenuItem("其他页面",null, "fa fa-fw fa-fa")
                {
                    Url="/Others",
                    Items = new List<MenuItem>
                    {
                        new MenuItem() { Text="日志",Icon="fa fa-fw fa-check-square-o",Url="/LogDashboard"},
                        //new MenuItem() { Text = "Test", Icon = "fa fa-fw fa-check-square-o", Url = "/TestPage" },
                        new MenuItem() { Text = "Counter", Icon = "fa fa-fw fa-check-square-o", Url = "/counter" },
                        new MenuItem() { Text = "FetchData", Icon = "fa fa-fw fa-database", Url = "/fetchdata" },
                        new MenuItem() { Text = "BootstrapBlazor组件库", Icon = "fa fa-fw fa-home", Target="_blank", Url = "https://www.blazor.zone/components" },
                    }
                },
            };
            return menus;
        }
    }
}
