﻿using System;
using System.Collections.Generic;

namespace SongLyrics.Infrastructure.Domain.Entities
{
    public class Artists : Entity<int>
    {
        public string ArtistName { get; set; }

        public DateTime Established { get; set; }

        public DateTime? ActiveUntil { get; set; }

        public virtual ICollection<Albums> Albums { get; set; } = new HashSet<Albums>();

        public virtual ICollection<ArtistsGeneres> ArtistsGeneres { get; set; } = new HashSet<ArtistsGeneres>();

        public virtual ICollection<Members> Members { get; set; } = new HashSet<Members>();

        public virtual ICollection<Songs> Songs { get; set; } = new HashSet<Songs>();
    }
}
