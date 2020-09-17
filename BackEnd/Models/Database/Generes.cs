using System;
using System.Collections.Generic;

namespace BackEnd.Models.Database
{
    public partial class Generes
    {
        public Generes()
        {
            ArtistsGeneres = new HashSet<ArtistsGeneres>();
        }

        public int Id { get; set; }
        public string Genere { get; set; }

        public virtual ICollection<ArtistsGeneres> ArtistsGeneres { get; set; }
    }
}
