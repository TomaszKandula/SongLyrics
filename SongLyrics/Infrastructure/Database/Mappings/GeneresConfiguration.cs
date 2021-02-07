using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SongLyrics.Infrastructure.Domain.Entities;

namespace SongLyrics.Infrastructure.Database.Mappings
{
    public class GeneresConfiguration : IEntityTypeConfiguration<Generes>
    {
        public void Configure(EntityTypeBuilder<Generes> AEntityBuilder)
        {
            AEntityBuilder
                .Property(AGeneres => AGeneres.Genere)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}
