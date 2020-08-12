using System;
using System.Collections.Generic;

namespace BackEnd.Models.Database
{
    public partial class Albums
    {
        public Albums()
        {
            Songs = new HashSet<Songs>();
        }

        public int Id { get; set; }
        public int BandId { get; set; }
        public string AlbumName { get; set; }
        public DateTime Issued { get; set; }

        public virtual Bands Band { get; set; }
        public virtual ICollection<Songs> Songs { get; set; }
    }
}
