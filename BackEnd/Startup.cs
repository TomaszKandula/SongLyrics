using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.ResponseCompression;
using BackEnd.Logic;
using BackEnd.Models.Database;
using BackEnd.Utilities.AppLogger;

namespace SongLyrics
{

    public class Startup
    {

        private readonly string FDevelopmentOrigin = "http://localhost:59457";
        private readonly string FDeploymentOrigin  = "https://songlyrics.azurewebsites.net";

        public IConfiguration FConfiguration { get; }

        public Startup(IConfiguration AConfiguration)
        {
            FConfiguration = AConfiguration;
        }

        public void ConfigureServices(IServiceCollection AServices)
        {

            AServices.AddMvc(Option => Option.CacheProfiles
                .Add("ResponseCache", new CacheProfile()
                {
                    Duration = 5,
                    Location = ResponseCacheLocation.Any,
                    NoStore = false
                }));

            AServices.AddControllers();
            AServices.AddSingleton<IAppLogger, AppLogger>();
            AServices.AddDbContext<MainDbContext>(Options => 
            {
                Options.UseSqlServer(FConfiguration.GetConnectionString("DbConnect"),
                AddOptions => AddOptions.EnableRetryOnFailure());
            });
            AServices.AddScoped<ILogicContext, LogicContext>();

            AServices.AddResponseCompression(Options =>
            {
                Options.Providers.Add<GzipCompressionProvider>();
            });

        }

        public void Configure(IApplicationBuilder AApplication, IWebHostEnvironment AEnvironment) 
        {

            AApplication.UseResponseCompression();
            
            if (AEnvironment.IsDevelopment())
            {
                AApplication.UseDeveloperExceptionPage();
            }

            AApplication.UseDefaultFiles();
            AApplication.UseStaticFiles();
            AApplication.UseRouting();

            AApplication.Use((LContext, LNext) => 
            {

                if (LContext.Request.Headers["Origin"] == FDeploymentOrigin || LContext.Request.Headers["Origin"] == FDevelopmentOrigin) 
                    LContext.Response.Headers.Add("Access-Control-Allow-Origin", LContext.Request.Headers["Origin"]);

                LContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET");
                LContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
                LContext.Response.Headers.Add("Access-Control-Allow-Headers", "AccessToken, Content-Type");

                return LNext();

            });

            AApplication.UseEndpoints(Options =>
            {
                Options.MapControllers();
            });

        }

    }

}
