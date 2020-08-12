using System;
using System.Collections.Generic;

namespace BackEnd.Models.Database
{
    public partial class BandsGeneres
    {
        public int Id { get; set; }
        public int GenereId { get; set; }
        public int BandId { get; set; }

        public virtual Bands Band { get; set; }
    }
}
