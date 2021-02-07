namespace SongLyrics.Infrastructure.Domain.Entities
{
    public class ArtistsGeneres : Entity<int>
    {
        public int GenereId { get; set; }

        public int ArtistId { get; set; }

        public virtual Artists Artist { get; set; }

        public virtual Generes Genere { get; set; }
    }
}
