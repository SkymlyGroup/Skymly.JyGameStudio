using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skymly.JyGameStudio.BlazorApp.Shared.Pages
{
    public partial class BattlePage : ComponentBase
    {
        

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }
        private static IEnumerable<int> PageItemsSource => new int[] { 10, 20, 100, 500 };
    }
}
