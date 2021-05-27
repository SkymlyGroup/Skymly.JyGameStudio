using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

using Serilog.Events;
using Serilog;
using System.IO;

namespace Skymly.JyGameStudio.BlazorApp.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logFile = Path.Combine(Path.GetDirectoryName(typeof(Program).Assembly.Location), "Logs/Log{Date}.txt");
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Debug()//最小的输出单位是Debug级别的
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)//将Microsoft前缀的日志的最小输出级别改成Information
                .WriteTo.Console()
                .WriteTo.Debug()
                .WriteTo.Seq("http://localhost:5341/")
                .WriteTo.File(logFile, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception} \r\n",rollingInterval: RollingInterval.Day,rollOnFileSizeLimit:true,fileSizeLimitBytes: 1048576)
                .CreateLogger();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                    .UseSerilog()
                    .UseStartup<Startup>();
                });
    }
}
