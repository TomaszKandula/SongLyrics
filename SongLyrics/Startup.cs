using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SongLyrics.Logic;
using SongLyrics.Logger;
using SongLyrics.Middleware;
using SongLyrics.Infrastructure.Database;

namespace SongLyrics
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration AConfiguration)
            => Configuration = AConfiguration;

        public void ConfigureServices(IServiceCollection AServices)
        {
            AServices.AddMvc(AOption => AOption
            .CacheProfiles
            .Add("ResponseCache", new CacheProfile()
            {
                Duration = 10,
                Location = ResponseCacheLocation.Any,
                NoStore = false
            }));

            AServices.AddControllers();
            AServices.AddSpaStaticFiles(AConfiguration 
                => AConfiguration.RootPath = "ClientApp/build");

            AServices.AddSingleton<IAppLogger, AppLogger>();
            AServices.AddDbContext<MainDbContext>(AOptions => 
            {
                AOptions.UseSqlServer(Configuration.GetConnectionString("DbConnect"),
                AAddOptions => AAddOptions.EnableRetryOnFailure());
            });
            
            AServices.AddScoped<ILogicContext, LogicContext>();
            AServices.AddResponseCompression(AOptions => AOptions.Providers.Add<GzipCompressionProvider>());
            AServices.AddSwaggerGen(AOption 
                => AOption.SwaggerDoc("v1", new OpenApiInfo { Title = "SongLyrics Api", Version = "v1" }));
        }

        public void Configure(IApplicationBuilder AApplication, IWebHostEnvironment AEnvironment) 
        {
            AApplication.UseMiddleware<CustomCors>();
            AApplication.UseResponseCompression();
            
            if (AEnvironment.IsDevelopment())
                AApplication.UseDeveloperExceptionPage();

            AApplication.UseSwagger();
            AApplication.UseSwaggerUI(AOption 
                => AOption.SwaggerEndpoint("/swagger/v1/swagger.json", "SongLyrics Api version 1"));

            AApplication.UseStaticFiles();
            AApplication.UseSpaStaticFiles();
            AApplication.UseRouting();
            AApplication.UseEndpoints(AEndpoints 
                => AEndpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}"));

            AApplication.UseSpa(AConfiguration =>
            {
                AConfiguration.Options.SourcePath = "ClientApp";
                if (AEnvironment.IsDevelopment())
                    AConfiguration
                        .UseProxyToSpaDevelopmentServer(Configuration.GetSection("DevelopmentOrigin").Value);
            });
        }
    }
}
