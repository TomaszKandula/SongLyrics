using System;
using System.Collections.Generic;

namespace BackEnd.Database
{
    public class Artists
    {
        public int Id { get; set; }
        public string ArtistName { get; set; }
        public DateTime Established { get; set; }
        public DateTime? ActiveUntil { get; set; }

        public virtual ICollection<Albums> Albums { get; set; } = new HashSet<Albums>();
        public virtual ICollection<ArtistsGeneres> ArtistsGeneres { get; set; } = new HashSet<ArtistsGeneres>();
        public virtual ICollection<Members> Members { get; set; } = new HashSet<Members>();
        public virtual ICollection<Songs> Songs { get; set; } = new HashSet<Songs>();
    }
}
