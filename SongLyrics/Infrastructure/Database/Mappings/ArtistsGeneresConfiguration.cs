using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SongLyrics.Infrastructure.Domain.Entities;

namespace SongLyrics.Infrastructure.Database.Mappings
{
    public class ArtistsGeneresConfiguration : IEntityTypeConfiguration<ArtistsGeneres>
    {
        public void Configure(EntityTypeBuilder<ArtistsGeneres> AEntityBuilder)
        {
            AEntityBuilder
                .HasOne(AArtistsGeneres => AArtistsGeneres.Artist)
                .WithMany(AArtists => AArtists.ArtistsGeneres)
                .HasForeignKey(AArtistsGeneres => AArtistsGeneres.ArtistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ArtistId__ArtistsGeneres");

            AEntityBuilder
                .HasOne(AArtistsGeneres => AArtistsGeneres.Genere)
                .WithMany(AGeneres => AGeneres.ArtistsGeneres)
                .HasForeignKey(AArtistsGeneres => AArtistsGeneres.GenereId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GenereId__Generes");
        }
    }
}
