using System;
using System.Collections.Generic;

namespace BackEnd.Models.Database
{
    public partial class Artists
    {
        public Artists()
        {
            Albums = new HashSet<Albums>();
            ArtistsGeneres = new HashSet<ArtistsGeneres>();
            Members = new HashSet<Members>();
            Songs = new HashSet<Songs>();
        }

        public int Id { get; set; }
        public string ArtistName { get; set; }
        public DateTime Established { get; set; }
        public DateTime? ActiveUntil { get; set; }

        public virtual ICollection<Albums> Albums { get; set; }
        public virtual ICollection<ArtistsGeneres> ArtistsGeneres { get; set; }
        public virtual ICollection<Members> Members { get; set; }
        public virtual ICollection<Songs> Songs { get; set; }
    }
}
