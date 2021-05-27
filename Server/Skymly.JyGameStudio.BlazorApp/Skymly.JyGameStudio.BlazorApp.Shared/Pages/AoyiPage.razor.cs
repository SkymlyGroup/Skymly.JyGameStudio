using BootstrapBlazor.Components;

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skymly.JyGameStudio.Models;
using Skymly.JyGameStudio.Data;
using Microsoft.EntityFrameworkCore;

namespace Skymly.JyGameStudio.BlazorApp.Shared.Pages
{
    public partial class AoyiPage : ComponentBase
    {


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }


        private static IEnumerable<int> PageItemsSource => new int[] { 10, 20, 100, 500 };


    }
}
