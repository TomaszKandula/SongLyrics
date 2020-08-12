using System;
using System.Collections.Generic;

namespace BackEnd.Models.Database
{
    public partial class Songs
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public string SongName { get; set; }
        public string SongUrl { get; set; }
        public string SongLyrics { get; set; }

        public virtual Albums Album { get; set; }
    }
}
