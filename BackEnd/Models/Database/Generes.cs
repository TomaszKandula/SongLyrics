using System;
using System.Collections.Generic;

namespace BackEnd.Models.Database
{
    public partial class Generes
    {
        public Generes()
        {
            BandsGeneres = new HashSet<BandsGeneres>();
        }

        public int Id { get; set; }
        public string Genere { get; set; }

        public virtual ICollection<BandsGeneres> BandsGeneres { get; set; }
    }
}
