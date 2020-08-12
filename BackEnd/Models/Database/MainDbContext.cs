using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models.Database
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
        public virtual DbSet<Bands> Bands { get; set; }
        public virtual DbSet<BandsGeneres> BandsGeneres { get; set; }
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

                entity.HasOne(d => d.Band)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.BandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BandId__AlbumsBands");
            });

            modelBuilder.Entity<Bands>(entity =>
            {
                entity.Property(e => e.ActiveUntil).HasColumnType("date");

                entity.Property(e => e.BandName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Established).HasColumnType("date");
            });

            modelBuilder.Entity<BandsGeneres>(entity =>
            {
                entity.HasOne(d => d.Band)
                    .WithMany(p => p.BandsGeneres)
                    .HasForeignKey(d => d.BandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BandId__BandsGeneres");

                entity.HasOne(d => d.Genere)
                    .WithMany(p => p.BandsGeneres)
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

                entity.HasOne(d => d.Band)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.BandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BandId__MembersBands");
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
            });

        }

    }
}
