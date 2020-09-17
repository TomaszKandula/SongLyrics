using System;
using System.Collections.Generic;

namespace BackEnd.Models.Database
{
    public partial class Members
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsPresent { get; set; }

        public virtual Artists Artist { get; set; }
    }
}
