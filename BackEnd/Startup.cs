using Microsoft.OpenApi.Models;
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
using BackEnd.Middleware;

namespace BackEnd
{

    public class Startup
    {

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
                Duration = 10,
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

            AServices.AddSwaggerGen(AOption =>
            {
                AOption.SwaggerDoc("v1", new OpenApiInfo { Title = "SongLyrics Api", Version = "v1" });
            });

        }

        public void Configure(IApplicationBuilder AApplication, IWebHostEnvironment AEnvironment) 
        {

            AApplication.UseMiddleware<CustomCors>();
            AApplication.UseResponseCompression();
            
            if (AEnvironment.IsDevelopment())
                AApplication.UseDeveloperExceptionPage();

            AApplication.UseSwagger();
            AApplication.UseSwaggerUI(AOption =>
            {
                AOption.SwaggerEndpoint("/swagger/v1/swagger.json", "SongLyrics Api version 1");
            });

            AApplication.UseDefaultFiles();
            AApplication.UseStaticFiles();
            AApplication.UseRouting();
            AApplication.UseEndpoints(AOptions => { AOptions.MapControllers(); });

        }

    }

}
