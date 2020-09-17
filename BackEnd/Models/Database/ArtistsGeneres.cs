﻿namespace BackEnd.Models.Database
{
    public partial class ArtistsGeneres
    {
        public int Id { get; set; }
        public int GenereId { get; set; }
        public int ArtistId { get; set; }

        public virtual Artists Artist { get; set; }
        public virtual Generes Genere { get; set; }
    }
}