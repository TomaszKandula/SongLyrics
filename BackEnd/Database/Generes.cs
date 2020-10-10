﻿using System.Collections.Generic;

namespace BackEnd.Database
{
    public class Generes
    {
        public int Id { get; set; }
        public string Genere { get; set; }

        public virtual ICollection<ArtistsGeneres> ArtistsGeneres { get; set; } = new HashSet<ArtistsGeneres>();
    }
}