using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BackEnd.Logic;
using BackEnd.Database;
using BackEnd.AppLogger;

namespace BackEnd
{

    public class Startup
    {

        private const string DevelopmentOrigin = "http://localhost:59457";
        private const string DeploymentOrigin = "https://songlyrics.azurewebsites.net";

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration AConfiguration)
        {
            Configuration = AConfiguration;
        }

        public void ConfigureServices(IServiceCollection AServices)
        {

            AServices.AddMvc(AOption => AOption
                .CacheProfiles
                .Add("ResponseCache", new CacheProfile()
                {
                    Duration = 5,
                    Location = ResponseCacheLocation.Any,
                    NoStore = false
                }));

            AServices.AddControllers();
            AServices.AddSingleton<IAppLogger, AppLogger.AppLogger>();
            AServices.AddDbContext<MainDbContext>(AOptions => 
            {
                AOptions.UseSqlServer(Configuration.GetConnectionString("DbConnect"),
                AAddOptions => AAddOptions.EnableRetryOnFailure());
            });
            
            AServices.AddScoped<ILogicContext, LogicContext>();
            AServices.AddResponseCompression(AOptions => { AOptions.Providers.Add<GzipCompressionProvider>(); });

        }

        public void Configure(IApplicationBuilder AApplication, IWebHostEnvironment AEnvironment) 
        {

            AApplication.UseResponseCompression();
            
            if (AEnvironment.IsDevelopment())
                AApplication.UseDeveloperExceptionPage();

            AApplication.UseDefaultFiles();
            AApplication.UseStaticFiles();
            AApplication.UseRouting();

            AApplication.Use((AContext, ANext) => 
            {

                if (AContext.Request.Headers["Origin"] == DeploymentOrigin || AContext.Request.Headers["Origin"] == DevelopmentOrigin) 
                    AContext.Response.Headers.Add("Access-Control-Allow-Origin", AContext.Request.Headers["Origin"]);

                AContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET");
                AContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
                AContext.Response.Headers.Add("Access-Control-Allow-Headers", "AccessToken, Content-Type");

                return ANext();

            });

            AApplication.UseEndpoints(AOptions => { AOptions.MapControllers(); });

        }

    }

}
