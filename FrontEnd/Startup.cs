using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1
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

            AServices.AddControllersWithViews();

            // In production, the React files will be served from this directory
            AServices.AddSpaStaticFiles(LConfiguration =>
            {
                LConfiguration.RootPath = "ClientApp/build";
            });
        }

        public void Configure(IApplicationBuilder AApplication, IWebHostEnvironment AEnvironment)
        {

            if (AEnvironment.IsDevelopment())
            {
                AApplication.UseDeveloperExceptionPage();
            }
            else
            {
                AApplication.UseExceptionHandler("/Error");
            }

            AApplication.UseStaticFiles();
            AApplication.UseSpaStaticFiles();

            AApplication.UseRouting();

            AApplication.UseEndpoints(LEndpoints =>
            {
                LEndpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            AApplication.UseSpa(LSpa =>
            {

                LSpa.Options.SourcePath = "ClientApp";

                if (AEnvironment.IsDevelopment())
                {
                    LSpa.UseReactDevelopmentServer(npmScript: "start");
                }

            });

        }
    }
}
