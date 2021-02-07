using System;
using System.IO;
using Serilog;
using Serilog.Events;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SongLyrics
{
    public class Program
    {
        public static IHostBuilder CreateWebHostBuilder(string[] AArgs) =>
            Host.CreateDefaultBuilder(AArgs)
                .ConfigureWebHostDefaults(AWebBuilder =>
                {
                    AWebBuilder.UseStartup<Startup>();
                    AWebBuilder.UseSerilog();
                });

        public static int Main(string[] AArgs)
        {
            var LOgsPath = AppDomain.CurrentDomain.BaseDirectory + "\\logs";
            if (!Directory.Exists(LOgsPath))
            {
                Directory.CreateDirectory(LOgsPath);
            }

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .Enrich.FromLogContext()
                .WriteTo.File
                (
                    LOgsPath + "\\log-.txt",
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                    rollingInterval: RollingInterval.Day,
                    rollOnFileSizeLimit: true,
                    retainedFileCountLimit: null,
                    shared: false
                 )
                .CreateLogger();

            try
            {
                Log.Information("Starting WebHost...");
                CreateWebHostBuilder(AArgs).Build().Run();
                return 0;
            }
            catch (Exception LException)
            {
                Log.Fatal(LException, "WebHost has been terminated unexpectedly.");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
