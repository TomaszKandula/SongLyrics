using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SongLyrics.Infrastructure.Database.Seeders;
using SongLyrics.Infrastructure.Domain.Entities;

namespace SongLyrics.Infrastructure.Database
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> AOptions) : base(AOptions) { }

        public MainDbContext() { }

        public virtual DbSet<Albums> Albums { get; set; }

        public virtual DbSet<Artists> Artists { get; set; }
        
        public virtual DbSet<ArtistsGeneres> ArtistsGeneres { get; set; }
        
        public virtual DbSet<Generes> Generes { get; set; }
        
        public virtual DbSet<Members> Members { get; set; }
        
        public virtual DbSet<Songs> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder AModelBuilder)
        {
            base.OnModelCreating(AModelBuilder);
            ApplyConfiguration(AModelBuilder);

            new ArtistsSeeder().Seed(AModelBuilder);
            new MembersSeeder().Seed(AModelBuilder);
            new SongsSeeder().Seed(AModelBuilder);
            new AlbumsSeeder().Seed(AModelBuilder);
            new ArtistsGeneresSeeder().Seed(AModelBuilder);
            new GeneresSeeder().Seed(AModelBuilder);
        }

        private static void ApplyConfiguration(ModelBuilder AModelBuilder)
            => AModelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
