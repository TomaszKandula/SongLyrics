using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SongLyrics.Infrastructure.Domain.Entities;

namespace SongLyrics.Infrastructure.Database.Mappings
{
    public class MembersConfiguration : IEntityTypeConfiguration<Members>
    {
        public void Configure(EntityTypeBuilder<Members> AEntityBuilder)
        {
            AEntityBuilder
                .Property(AMembers => AMembers.FirstName)
                .IsRequired()
                .HasMaxLength(255);

            AEntityBuilder
                .Property(AMembers => AMembers.LastName)
                .IsRequired()
                .HasMaxLength(255);

            AEntityBuilder
                .HasOne(AMembers => AMembers.Artist)
                .WithMany(AArtists => AArtists.Members)
                .HasForeignKey(AMembers => AMembers.ArtistId)
                .OnDelete(DeleteBehavior.ClientNoAction)
                .HasConstraintName("FK__ArtistId__MembersArtists");
        }
    }
}
