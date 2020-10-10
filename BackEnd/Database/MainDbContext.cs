using Microsoft.EntityFrameworkCore;

namespace BackEnd.Database
{

    public class MainDbContext : DbContext
    {

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        public MainDbContext()
        {
        }

        public virtual DbSet<Albums> Albums { get; set; }
        public virtual DbSet<Artists> Artists { get; set; }
        public virtual DbSet<ArtistsGeneres> ArtistsGeneres { get; set; }
        public virtual DbSet<Generes> Generes { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<Songs> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Albums>(entity =>
            {
                entity.Property(e => e.AlbumName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Issued).HasColumnType("date");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ArtistId__AlbumsArtists");
            });

            modelBuilder.Entity<Artists>(entity =>
            {
                entity.Property(e => e.ActiveUntil).HasColumnType("date");

                entity.Property(e => e.ArtistName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Established).HasColumnType("date");
            });

            modelBuilder.Entity<ArtistsGeneres>(entity =>
            {
                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.ArtistsGeneres)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ArtistId__ArtistsGeneres");

                entity.HasOne(d => d.Genere)
                    .WithMany(p => p.ArtistsGeneres)
                    .HasForeignKey(d => d.GenereId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GenereId__Generes");
            });

            modelBuilder.Entity<Generes>(entity =>
            {
                entity.Property(e => e.Genere)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Members>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ArtistId__MembersArtists");
            });

            modelBuilder.Entity<Songs>(entity =>
            {
                entity.Property(e => e.SongLyrics)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.SongName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.SongUrl)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AlbumId__Albums");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ArtistId__Artists");

            });

        }

    }
}
