using BackEnd.Logic.Music;
using BackEnd.Logic.Bands;
using BackEnd.Models.Database;

namespace BackEnd.Logic
{

    public class LogicContext : ILogicContext
    {

        private readonly MainDbContext FMainDbContext;

        private IBands FArtists;
        private IMusic   FMusic;

        public LogicContext(MainDbContext AMainDbContext) 
        {
            FMainDbContext = AMainDbContext;
        }

        public IBands Bands 
        {

            get 
            {

                if (FArtists == null) 
                {
                    FArtists = new Bands.Bands(FMainDbContext);
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
