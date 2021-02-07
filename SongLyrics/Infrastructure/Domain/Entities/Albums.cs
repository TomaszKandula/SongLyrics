using System;
using System.Collections.Generic;

namespace SongLyrics.Infrastructure.Domain.Entities
{
    public class Albums : Entity<int>
    {
        public int ArtistId { get; set; }

        public string AlbumName { get; set; }

        public DateTime Issued { get; set; }

        public Artists Artist { get; set; }

        public ICollection<Songs> Songs { get; set; } = new HashSet<Songs>();
    }
}
