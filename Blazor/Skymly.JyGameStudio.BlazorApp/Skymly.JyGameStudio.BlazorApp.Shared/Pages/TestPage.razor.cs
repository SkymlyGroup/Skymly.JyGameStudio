using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skymly.JyGameStudio.BlazorApp.Shared.Pages
{
    partial class TestPage:ComponentBase
    {
        [Inject]
        JSRuntime Js { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Message = await GetWindowWidth();
            await base.OnInitializedAsync();
        }

        public string Message { get; set; }

        async Task<string> GetWindowWidth()
        {
            try
            {
                var width = await Js.InvokeAsync<int>(@"function(){return window.screen.availWidth } ");
                return width.ToString();
            }
            catch (Exception ex)
            {
                return $"{ex.GetType().FullName} {ex.Message}";
                
            }
        }

    }
}
