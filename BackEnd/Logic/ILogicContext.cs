using BackEnd.Logic.Music;
using BackEnd.Logic.Bands;

namespace BackEnd.Logic
{

    public interface ILogicContext
    {
        IBands Bands { get; }
        IMusic Music { get; }
    }

}
