using Microsoft.EntityFrameworkCore;

namespace SongLyrics.Infrastructure.Database.Seeders
{
    public interface IMainDbContextSeeder
    {
        void Seed(ModelBuilder AModelBuilder);
    }
}
