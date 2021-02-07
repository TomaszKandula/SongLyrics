using System;
using Microsoft.EntityFrameworkCore;
using SongLyrics.Infrastructure.Domain.Entities;

namespace SongLyrics.Infrastructure.Database.Seeders
{
    public class ArtistsSeeder : IMainDbContextSeeder
    {
        public void Seed(ModelBuilder AModelBuilder)
        {
            AModelBuilder.Entity<Artists>().HasData(
                new Artists 
                {
                    Id = 1,
                    ArtistName = "Queen",
                    Established = DateTime.Parse("1970-01-01 00:00:00"),
                    ActiveUntil = null
                }
            );
        }
    }
}
