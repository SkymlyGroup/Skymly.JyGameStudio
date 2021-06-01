using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skymly.JyGameStudio.BlazorApp.Shared.Pages
{
    public partial class Index : ComponentBase
    {
        


        static NavLink GetItem(string content, string herf, string target = "_blank")
        {
            var link = new NavLink();
            link.SetParametersAsync(ParameterView.FromDictionary(new Dictionary<string, object?>()
            {
                ["href"] = herf,
                ["class"] = "nav-link nav-item",
                ["target"] = target,
                ["ChildContent"] = new RenderFragment(builder =>
                {
                    builder.AddContent(0, content);
                })
            }));
            return link;
        }

        private IEnumerable<NavLink> Items => GetItems();

        private IEnumerable<NavLink> GetItems()
        {
            yield return GetItem("开源地址(Github)",Constants.ProjectUrl);
            yield return GetItem("BlazorApp地址", Constants.BlazorAppUrl);
            yield return GetItem("开放API接口", Constants.ApiUrl);
            yield return GetItem("BlazorApp日志", Constants.BlazorAppLogDashboardUrl);
            yield return GetItem("API接口日志", Constants.ApiLogDashboardUrl);
            yield return GetItem("全部日志", Constants.LogSeqUrl);
        }

    }
}
