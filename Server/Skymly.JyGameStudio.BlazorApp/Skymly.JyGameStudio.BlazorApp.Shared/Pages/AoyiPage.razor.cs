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
    public partial class AoyiPage: ComponentBase
    {
        [Inject]
        private IStringLocalizer<Foo> Localizer { get; set; }
        [Inject]
        private ScriptsContext Context { get; set; }

        private IEnumerable<Aoyi> Aoyis { get; set; }


        /// <summary>
        /// 
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Aoyis = await Context.Aoyis.ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        private static IEnumerable<int> PageItemsSource => new int[] { 4, 10, 20 };


    }
}
