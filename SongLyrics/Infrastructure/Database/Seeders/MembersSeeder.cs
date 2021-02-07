using Microsoft.EntityFrameworkCore;
using SongLyrics.Infrastructure.Domain.Entities;

namespace SongLyrics.Infrastructure.Database.Seeders
{
    public class MembersSeeder : IMainDbContextSeeder
    {
        public void Seed(ModelBuilder AModelBuilder)
        {
            AModelBuilder.Entity<Members>().HasData(
                new Members 
                {
                    Id = 1,
                    ArtistId = 1,
                    FirstName = "Brian",
                    LastName = "May",
                    IsPresent = true
                },
                new Members
                {
                    Id = 2,
                    ArtistId = 1,
                    FirstName = "Roger",
                    LastName = "Taylor",
                    IsPresent = true
                },
                new Members
                {
                    Id = 3,
                    ArtistId = 1,
                    FirstName = "John",
                    LastName = "Deacon",
                    IsPresent = false
                },
                new Members
                {
                    Id = 4,
                    ArtistId = 1,
                    FirstName = "Freddie",
                    LastName = "Mercury",
                    IsPresent = false
                }
            );
        }
    }
}
