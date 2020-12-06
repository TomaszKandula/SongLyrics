using Microsoft.EntityFrameworkCore;
using SongLyrics.Database.Models;

namespace SongLyrics.Database
{

    public class MainDbContext : DbContext
    {

        public MainDbContext(DbContextOptions<MainDbContext> AOptions) : base(AOptions)
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

        protected override void OnModelCreating(ModelBuilder AModelBuilder)
        {
            AModelBuilder.Entity<Albums>(AEntity =>
            {
                AEntity.Property(AAlbums => AAlbums.AlbumName)
                    .IsRequired()
                    .HasMaxLength(255);

                AEntity.Property(AAlbums => AAlbums.Issued).HasColumnType("date");

                AEntity.HasOne(AAlbums => AAlbums.Artist)
                    .WithMany(AArtists => AArtists.Albums)
                    .HasForeignKey(AAlbums => AAlbums.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ArtistId__AlbumsArtists");
            });

            AModelBuilder.Entity<Artists>(AEntity =>
            {
                AEntity.Property(AArtists => AArtists.ActiveUntil).HasColumnType("date");

                AEntity.Property(AArtists => AArtists.ArtistName)
                    .IsRequired()
                    .HasMaxLength(255);

                AEntity.Property(AArtists => AArtists.Established).HasColumnType("date");
            });

            AModelBuilder.Entity<ArtistsGeneres>(AEntity =>
            {
                AEntity.HasOne(AArtistsGeneres => AArtistsGeneres.Artist)
                    .WithMany(AArtists => AArtists.ArtistsGeneres)
                    .HasForeignKey(AArtistsGeneres => AArtistsGeneres.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ArtistId__ArtistsGeneres");

                AEntity.HasOne(AArtistsGeneres => AArtistsGeneres.Genere)
                    .WithMany(AGeneres => AGeneres.ArtistsGeneres)
                    .HasForeignKey(AArtistsGeneres => AArtistsGeneres.GenereId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GenereId__Generes");
            });

            AModelBuilder.Entity<Generes>(AEntity =>
            {
                AEntity.Property(AGeneres => AGeneres.Genere)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            AModelBuilder.Entity<Members>(AEntity =>
            {
                AEntity.Property(AMembers => AMembers.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);

                AEntity.Property(AMembers => AMembers.LastName)
                    .IsRequired()
                    .HasMaxLength(255);

                AEntity.HasOne(AMembers => AMembers.Artist)
                    .WithMany(AArtists => AArtists.Members)
                    .HasForeignKey(AMembers => AMembers.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ArtistId__MembersArtists");
            });

            AModelBuilder.Entity<Songs>(AEntity =>
            {
                AEntity.Property(ASongs => ASongs.SongLyrics)
                    .IsRequired()
                    .IsUnicode(false);

                AEntity.Property(ASongs => ASongs.SongName)
                    .IsRequired()
                    .HasMaxLength(255);

                AEntity.Property(ASongs => ASongs.SongUrl)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                AEntity.HasOne(ASongs => ASongs.Album)
                    .WithMany(AAlbums => AAlbums.Songs)
                    .HasForeignKey(ASongs => ASongs.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AlbumId__Albums");

                AEntity.HasOne(ASongs => ASongs.Artist)
                    .WithMany(AArtists => AArtists.Songs)
                    .HasForeignKey(ASongs => ASongs.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ArtistId__Artists");

            });

        }

    }
}
