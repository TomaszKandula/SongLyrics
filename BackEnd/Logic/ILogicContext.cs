using BackEnd.Logic.Music;
using BackEnd.Logic.Artists;

namespace BackEnd.Logic
{

    public interface ILogicContext
    {
        IArtists Artists { get; }
        IMusic Music { get; }
    }

}
