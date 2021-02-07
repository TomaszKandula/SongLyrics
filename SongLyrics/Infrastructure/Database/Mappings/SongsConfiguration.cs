using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SongLyrics.Infrastructure.Domain.Entities;

namespace SongLyrics.Infrastructure.Database.Mappings
{
    public class SongsConfiguration : IEntityTypeConfiguration<Songs>
    {
        public void Configure(EntityTypeBuilder<Songs> AEntityBuilder)
        {
            AEntityBuilder
                .Property(ASongs => ASongs.SongLyrics)
                .IsRequired()
                .IsUnicode(false);

            AEntityBuilder
                .Property(ASongs => ASongs.SongName)
                .IsRequired()
                .HasMaxLength(255);

            AEntityBuilder
                .Property(ASongs => ASongs.SongUrl)
                .HasMaxLength(2048)
                .IsUnicode(false);

            AEntityBuilder
                .HasOne(ASongs => ASongs.Album)
                .WithMany(AAlbums => AAlbums.Songs)
                .HasForeignKey(ASongs => ASongs.AlbumId)
                .OnDelete(DeleteBehavior.ClientNoAction)
                .HasConstraintName("FK__AlbumId__Albums");

            AEntityBuilder
                .HasOne(ASongs => ASongs.Artist)
                .WithMany(AArtists => AArtists.Songs)
                .HasForeignKey(ASongs => ASongs.ArtistId)
                .OnDelete(DeleteBehavior.ClientNoAction)
                .HasConstraintName("FK__ArtistId__Artists");
        }
    }
}
