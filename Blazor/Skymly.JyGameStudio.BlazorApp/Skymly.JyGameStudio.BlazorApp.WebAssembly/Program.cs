using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Skymly.JyGameStudio.BlazorApp.Shared;
using Skymly.JyGameStudio.BlazorApp.Shared.Data;
using Skymly.JyGameStudio.Data;

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Skymly.JyGameStudio.BlazorApp.WebAssembly
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddDbContext<ScriptsContext>(options => options.UseSqlServer("Server=.;Database=jygamestudio;Trusted_Connection=True;MultipleActiveResultSets=true"));

            // 增加 BootstrapBlazor 组件
            builder.Services.AddBootstrapBlazor();

            builder.Services.AddSingleton<WeatherForecastService>();

            // 增加 Table 数据服务操作类
            builder.Services.AddTableDemoDataService();

            var host = builder.Build();

            await host.RunAsync();
        }
    }
}
