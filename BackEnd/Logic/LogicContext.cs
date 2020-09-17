using BackEnd.Logic.Songs;
using BackEnd.Logic.Albums;
using BackEnd.Logic.Artists;
using BackEnd.Models.Database;

namespace BackEnd.Logic
{

    public class LogicContext : ILogicContext
    {

        private readonly MainDbContext FMainDbContext;

        private IArtists FArtists;
        private IAlbums  FAlbums;
        private ISongs   FSongs;

        public LogicContext(MainDbContext AMainDbContext) 
        {
            FMainDbContext = AMainDbContext;
        }

        public IArtists Artists { get { if (FArtists == null) FArtists = new Artists.Artists(FMainDbContext); return FArtists; } }
        public IAlbums Albums { get { if (FAlbums == null) FAlbums = new Albums.Albums(FMainDbContext); return FAlbums; } }
        public ISongs Songs { get { if (FSongs == null) FSongs = new Songs.Songs(FMainDbContext); return FSongs; } }

    }

}
