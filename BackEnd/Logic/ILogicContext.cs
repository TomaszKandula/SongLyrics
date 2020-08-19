using BackEnd.Logic.Bands;
using BackEnd.Logic.Songs;
using BackEnd.Logic.Albums;

namespace BackEnd.Logic
{

    public interface ILogicContext
    {
        IBands Bands { get; }
        IAlbums Albums { get; }
        ISongs Songs { get; }
    }

}
