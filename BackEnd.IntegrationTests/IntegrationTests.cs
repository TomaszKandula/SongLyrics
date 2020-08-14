using Xunit;
using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BackEnd.Models.Database;
using BackEnd.Utilities.AppLogger;
using Serilog;
using Serilog.Events;

namespace SongLyricsBackEnd.IntegrationTests
{

    public class Startup
    {
    }

    public class DbFixture
    {

        public ServiceProvider FServiceProvider { get; private set; }

        public DbFixture() 
        {

            var LConfiguration = new ConfigurationBuilder().AddUserSecrets<DbFixture>().Build();
            var ConnectionString = LConfiguration.GetValue<string>("DbConnect");
            var LServices = new ServiceCollection();

            LServices.AddDbContext<MainDbContext>(Options => Options.UseSqlServer(ConnectionString), ServiceLifetime.Transient);
            LServices.AddSingleton<IAppLogger, AppLogger>();
            FServiceProvider = LServices.BuildServiceProvider();

        }

    }

    public class IntegrationTests : IClassFixture<DbFixture>
    {

        private readonly ServiceProvider FServiceProvider;

        private readonly MainDbContext FMainDbContext;
        private readonly IAppLogger    FAppLogger;

        public IntegrationTests(DbFixture ADbFixture)
        {

            FServiceProvider = ADbFixture.FServiceProvider;

            FMainDbContext = FServiceProvider.GetService<MainDbContext>();
            FAppLogger     = FServiceProvider.GetService<IAppLogger>();

        }

        /* APPLOGGER TESTS */

        [Fact]
        public void SeriLogConfig() 
        {

            // Arrange
            var LogsPath = AppDomain.CurrentDomain.BaseDirectory + "\\test-logs";
            var FileName = $"log-{string.Format("{0:yyyyMMdd}", DateTime.Now)}.txt";

            if (!Directory.Exists(LogsPath))
            {
                Directory.CreateDirectory(LogsPath);
            }

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .Enrich.FromLogContext()
                .WriteTo.File
                (
                    LogsPath + "\\log-.txt",
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                    rollingInterval: RollingInterval.Day,
                    rollOnFileSizeLimit: true,
                    retainedFileCountLimit: null,
                    shared: false
                 )
                .CreateLogger();

            // Act
            FAppLogger.LogInfo("Integration Tests for SeriLog sitting behind AppLogger.");

            // Assert
            File.Exists(LogsPath + "\\" + FileName).Should().BeTrue();

        }

        /* DATABASE RETRIEVAL TESTS */

        [Fact]
        public async void GetBands()
        {

            var LResult = await FMainDbContext.Bands
                .AsNoTracking()
                .Select(R => R)
                .ToListAsync();

            LResult.Should().NotBeEmpty();

        }

        [Fact]
        public async void GetAlbums()
        {

            var LResult = await FMainDbContext.Albums
                .Include(R => R.Band)
                .AsNoTracking()
                .Select(R => new 
                { 
                    R.Band.BandName,
                    R.AlbumName,
                    R.Issued
                })
                .ToListAsync();

            LResult.Should().HaveCount(15);

        }

        [Fact]
        public async void GetBandGeneres()
        {

            var LResult = await FMainDbContext.BandsGeneres
                .Include(R => R.Band)
                .Include(R => R.Genere)
                .AsNoTracking()
                .Select(R => new 
                { 
                    R.Band.BandName,
                    R.Genere.Genere
                })
                .ToListAsync();

            LResult.Should().NotBeEmpty();

        }

        [Fact]
        public async void GetGeneres()
        {

            var LResult = await FMainDbContext.Generes
                .AsNoTracking()
                .Select(R => R)
                .ToListAsync();

            LResult.Should().NotBeEmpty();

        }

        [Fact]
        public async void GetMembers()
        {

            var LResult = await FMainDbContext.Members
                .Include(R => R.Band)
                .AsNoTracking()
                .Select(R => new 
                { 
                    R.Band.BandName,
                    R.FirstName,
                    R.LastName,
                    R.IsPresent
                })
                .ToListAsync();

            LResult.Should().HaveCount(4);

        }

        [Fact]
        public async void GetSongs()
        {

            var LResult = await FMainDbContext.Songs
                .Include(R => R.Band)
                .Include(R => R.Album)
                .AsNoTracking()
                .Select(R => new 
                { 
                    R.Album.AlbumName,
                    R.Band.BandName,
                    R.SongName,
                    R.SongLyrics,
                    R.SongUrl
                })
                .ToListAsync();

            LResult.Should().HaveCount(10);

        }

    }

}
