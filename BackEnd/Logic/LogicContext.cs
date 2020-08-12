using BackEnd.Logic.Music;
using BackEnd.Logic.Artists;
using BackEnd.Models.Database;

namespace BackEnd.Logic
{

    public class LogicContext : ILogicContext
    {

        private readonly MainDbContext FMainDbContext;

        private IArtists FArtists;
        private IMusic FMusic;

        public LogicContext(MainDbContext AMainDbContext) 
        {
            FMainDbContext = AMainDbContext;
        }

        public IArtists Artists 
        {

            get 
            {

                if (FArtists == null) 
                {
                    FArtists = new Artists.Artists(FMainDbContext);
                }

                return FArtists;

            }

        }

        public IMusic Music 
        {

            get 
            {

                if (FMusic == null) 
                {
                    FMusic = new Music.Music(FMainDbContext);
                }

                return FMusic;            
            
            }
        
        }

    }

}
