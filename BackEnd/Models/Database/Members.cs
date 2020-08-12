using System;
using System.Collections.Generic;

namespace BackEnd.Models.Database
{
    public partial class Members
    {
        public int Id { get; set; }
        public int BandId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsPresent { get; set; }

        public virtual Bands Band { get; set; }
    }
}
