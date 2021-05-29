using BootstrapBlazor.Components;

using LogDashboard;
using LogDashboard.Authorization.Filters;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

using Serilog;

using Skymly.JyGameStudio.BlazorApp.Shared;
using Skymly.JyGameStudio.BlazorApp.Shared.Data;
using Skymly.JyGameStudio.Data;

namespace Skymly.JyGameStudio.BlazorApp.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ScriptsContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString(nameof(ScriptsContext))));
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddLogDashboard(opt =>
            {
                opt.AddAuthorizationFilter(new LogDashboardBasicAuthFilter("admin", "123456"));
            });

            services.AddBootstrapBlazor(setupAction: options =>
            {
                options.AdditionalJsonAssemblies = new[] { typeof(App).Assembly };
            });

            services.AddRequestLocalization<IOptions<BootstrapBlazorOptions>>((localizerOption, blazorOption) =>
            {
                var supportedCultures = blazorOption.Value.GetSupportedCultures();

                localizerOption.SupportedCultures = supportedCultures;
                localizerOption.SupportedUICultures = supportedCultures;
            });

            services.AddSingleton<WeatherForecastService>();

            // 增加 Table 数据服务操作类
            services.AddTableDemoDataService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseSerilogRequestLogging();

            //app.UseRequestLocalization(app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value);

            app.UseLogDashboard();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
