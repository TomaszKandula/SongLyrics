using System;
using System.Collections.Generic;

namespace BackEnd.Models.Database
{
    public partial class Bands
    {
        public Bands()
        {
            Albums = new HashSet<Albums>();
            BandsGeneres = new HashSet<BandsGeneres>();
            Members = new HashSet<Members>();
        }

        public int Id { get; set; }
        public string BandName { get; set; }
        public DateTime Established { get; set; }
        public DateTime? ActiveUntil { get; set; }

        public virtual ICollection<Albums> Albums { get; set; }
        public virtual ICollection<BandsGeneres> BandsGeneres { get; set; }
        public virtual ICollection<Members> Members { get; set; }
    }
}
