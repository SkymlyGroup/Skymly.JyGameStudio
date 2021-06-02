using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Skymly.JyGameStudio.Data;
using Serilog;
using LogDashboard;
using LogDashboard.Authorization.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Extensions;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Any;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace Skymly.JyGameStudio.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        const string AllowSpecificOrigins = nameof(AllowSpecificOrigins);

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ScriptsContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString(nameof(ScriptsContext))));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddLogDashboard(opt =>
            {
                opt.AddAuthorizationFilter(new LogDashboardBasicAuthFilter("admin", "123456"));
            });
            services.AddCors(options =>
            {
                options.AddPolicy(AllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           //.AllowCredentials()
                           .AllowAnyMethod()
                           .Build();
                });
            });
            services.AddControllers()
                    //.AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1",
                    Title = "Skymly.JyGameStudio.Api",
                    Description = "JyGameStudio Open API",
                    TermsOfService = new Uri("https://github.com/SkymlyGroup/Skymly.JyGameStudio"),
                    Contact = new OpenApiContact
                    {
                        Name = "落笔",
                        Email = "skym.ly@foxmail.com",
                        Url = new Uri("http://182.254.145.138:12300/Index"),
                    },
                });
                //c.SwaggerDoc("v1", new OpenApiInfo { Title = "Skymly.JyGameStudio.Api", Version = "v1" });
                var xmlPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Skymly.JyGameStudio.Api.xml");
                c.IncludeXmlComments(xmlPath);//启用swagger注释
            });
            services.AddScoped<ScriptsContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => { 
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Skymly.JyGameStudio.Api v1");
                c.RoutePrefix = "OpenApi";
            }); 
            /*
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Skymly.JyGameStudio.Api v1"));
            }
            else
            {
                //正式环境再启用Https
                app.UseHttpsRedirection();
            }
            */
            app.UseLogDashboard();

            app.UseStaticFiles();

            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Mod")),
                RequestPath = new PathString("/Mod"),
                EnableDirectoryBrowsing = true,

            });

            app.UseCors(AllowSpecificOrigins);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
