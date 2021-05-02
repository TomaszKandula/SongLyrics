using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace SongLyrics.IntegrationTests.Configuration
{
    public class TestFixture<TStartup> : IDisposable
    {
        private TestServer Server { get; }
        
        public HttpClient Client { get; }

        public string BaseAddress { get; set; } = "http://localhost:5000";
        
        public TestFixture() : this(Path.Combine("")) { }

        protected TestFixture(string ARelativeTargetProjectParentDir)
        {
            var LStartupAssembly = typeof(TStartup).GetTypeInfo().Assembly;
            var LContentRoot = GetProjectPath(ARelativeTargetProjectParentDir, LStartupAssembly);

            var LConfigurationBuilder = new ConfigurationBuilder()
                .SetBasePath(LContentRoot)
                .AddJsonFile("appsettings.json")
                .AddUserSecrets(LStartupAssembly);

            var LWebHostBuilder = new WebHostBuilder()
                .UseContentRoot(LContentRoot)
                .ConfigureServices(InitializeServices)
                .UseConfiguration(LConfigurationBuilder.Build())
                .UseStartup(typeof(TStartup));

            // Create instance of test server
            Server = new TestServer(LWebHostBuilder);

            // Add configuration for client
            Client = Server.CreateClient();
            Client.BaseAddress = new Uri(BaseAddress);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void Dispose()
        {
            Client.Dispose();
            Server.Dispose();
        }

        private static string GetProjectPath(string AProjectRelativePath, Assembly AStartupAssembly)
        {
            var LProjectName = AStartupAssembly.GetName().Name;
            var LApplicationBasePath = AppContext.BaseDirectory;
            var LDirectoryInfo = new DirectoryInfo(LApplicationBasePath);

            do
            {
                LDirectoryInfo = LDirectoryInfo.Parent;
                var LProjectDirectoryInfo = new DirectoryInfo(Path.Combine(LDirectoryInfo?.FullName ?? string.Empty, AProjectRelativePath));
                if (!LProjectDirectoryInfo.Exists) 
                    continue;
                
                if (new FileInfo(Path.Combine(LProjectDirectoryInfo.FullName, LProjectName ?? string.Empty, $"{LProjectName}.csproj")).Exists)
                    return Path.Combine(LProjectDirectoryInfo.FullName, LProjectName ?? string.Empty);
            }
            while (LDirectoryInfo?.Parent != null);
            
            throw new Exception($"Project root could not be located using the application root {LApplicationBasePath}.");
        }

        protected virtual void InitializeServices(IServiceCollection AServices)
        {
            var LStartupAssembly = typeof(TStartup).GetTypeInfo().Assembly;
            var LManager = new ApplicationPartManager
            {
                ApplicationParts =
                {
                    new AssemblyPart(LStartupAssembly)
                },
                FeatureProviders =
                {
                    new ControllerFeatureProvider(),
                    new ViewComponentFeatureProvider()
                }
            };
            AServices.AddSingleton(LManager);
        }
    }
}
