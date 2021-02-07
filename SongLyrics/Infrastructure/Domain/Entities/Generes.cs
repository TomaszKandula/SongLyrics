using System.Collections.Generic;

namespace SongLyrics.Infrastructure.Domain.Entities
{
    public class Generes : Entity<int>
    {
        public string Genere { get; set; }

        public virtual ICollection<ArtistsGeneres> ArtistsGeneres { get; set; } = new HashSet<ArtistsGeneres>();
    }
}
