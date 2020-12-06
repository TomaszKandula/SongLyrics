using SongLyrics.Logic.Songs;
using SongLyrics.Logic.Albums;
using SongLyrics.Logic.Artists;

namespace SongLyrics.Logic
{

    public interface ILogicContext
    {
        IArtists Artists { get; }
        IAlbums Albums { get; }
        ISongs Songs { get; }
    }

}
