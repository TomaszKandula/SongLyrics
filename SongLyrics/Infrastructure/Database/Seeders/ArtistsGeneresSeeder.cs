using Microsoft.EntityFrameworkCore;
using SongLyrics.Infrastructure.Domain.Entities;

namespace SongLyrics.Infrastructure.Database.Seeders
{
    public class ArtistsGeneresSeeder : IMainDbContextSeeder
    {
        public void Seed(ModelBuilder AModelBuilder)
        {
            AModelBuilder.Entity<ArtistsGeneres>().HasData(
                new ArtistsGeneres 
                {
                    Id = 1,
                    GenereId = 23,
                    ArtistId = 1
                }   
            );
        }
    }
}
