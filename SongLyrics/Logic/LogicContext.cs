using SongLyrics.Logic.Songs;
using SongLyrics.Logic.Albums;
using SongLyrics.Logic.Artists;
using SongLyrics.Infrastructure.Database;

namespace SongLyrics.Logic
{
    public class LogicContext : ILogicContext
    {
        private readonly MainDbContext FMainDbContext;

        private IArtists FArtists;
        private IAlbums FAlbums;
        private ISongs FSongs;

        public LogicContext(MainDbContext AMainDbContext) 
            => FMainDbContext = AMainDbContext;

        public IArtists Artists => FArtists ??= new Artists.Artists(FMainDbContext);

        public IAlbums Albums => FAlbums ??= new Albums.Albums(FMainDbContext);

        public ISongs Songs => FSongs ??= new Songs.Songs(FMainDbContext);
    }
}
