using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.ResponseCompression;
using BackEnd.Models.Database;
using BackEnd.Extensions.AppLogger;

namespace SongLyrics
{

    public class Startup
    {

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

            AServices.AddResponseCompression(Options =>
            {
                Options.Providers.Add<GzipCompressionProvider>();
            });

        }

        public void Configure(IApplicationBuilder AApplication, IWebHostEnvironment AEnvironment)
        {

            if (AEnvironment.IsDevelopment())
            {
                AApplication.UseDeveloperExceptionPage();
            }

            AApplication.UseStaticFiles();
            AApplication.UseRouting();
            AApplication.UseAuthorization();
            AApplication.UseEndpoints(Options =>
            {
                Options.MapControllers();
            });

        }

    }

}
