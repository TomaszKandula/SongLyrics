using System;
using System.Collections.Generic;

namespace SongLyrics.Database
{
    public class Albums
    {
        public Albums()
        {
            Songs = new HashSet<Songs>();
        }

        public int Id { get; set; }
        public int ArtistId { get; set; }
        public string AlbumName { get; set; }
        public DateTime Issued { get; set; }

        public Artists Artist { get; set; }
        public ICollection<Songs> Songs { get; set; } 
    }
}
