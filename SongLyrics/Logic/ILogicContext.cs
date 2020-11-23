using BackEnd.Logic.Songs;
using BackEnd.Logic.Albums;
using BackEnd.Logic.Artists;

namespace BackEnd.Logic
{

    public interface ILogicContext
    {
        IArtists Artists { get; }
        IAlbums Albums { get; }
        ISongs Songs { get; }
    }

}
