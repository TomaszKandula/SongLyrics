using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SongLyrics.Infrastructure.Domain.Entities;

namespace SongLyrics.Infrastructure.Database.Mappings
{
    public class ArtistsConfiguration : IEntityTypeConfiguration<Artists>
    {
        public void Configure(EntityTypeBuilder<Artists> AEntityBuilder)
        {
            AEntityBuilder
                .Property(AArtists => AArtists.ActiveUntil)
                .HasColumnType("date");

            AEntityBuilder
                .Property(AArtists => AArtists.ArtistName)
                .IsRequired()
                .HasMaxLength(255);

            AEntityBuilder
                .Property(AArtists => AArtists.Established)
                .HasColumnType("date");
        }
    }
}
