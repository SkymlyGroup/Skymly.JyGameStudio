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
using Newtonsoft.Json.Serialization;
using Skymly.JyGameStudio.Data;
using Serilog;

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

            services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);//保留Json大小写原样

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Skymly.JyGameStudio.Api", Version = "v1" });
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
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Skymly.JyGameStudio.Api v1"));

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
