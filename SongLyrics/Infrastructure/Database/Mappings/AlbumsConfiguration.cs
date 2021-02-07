using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SongLyrics.Infrastructure.Domain.Entities;

namespace SongLyrics.Infrastructure.Database.Mappings
{
    public class AlbumsConfiguration : IEntityTypeConfiguration<Albums>
    {
        public void Configure(EntityTypeBuilder<Albums> AEntityBuilder)
        {
            AEntityBuilder
                .Property(AAlbums => AAlbums.AlbumName)
                .IsRequired()
                .HasMaxLength(255);

            AEntityBuilder
                .Property(AAlbums => AAlbums.Issued)
                .HasColumnType("date");

            AEntityBuilder
                .HasOne(AAlbums => AAlbums.Artist)
                .WithMany(AArtists => AArtists.Albums)
                .HasForeignKey(AAlbums => AAlbums.ArtistId)
                .OnDelete(DeleteBehavior.ClientNoAction)
                .HasConstraintName("FK__ArtistId__AlbumsArtists");
        }
    }
}
