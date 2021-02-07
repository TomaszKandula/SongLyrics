namespace SongLyrics.Infrastructure.Domain.Entities
{
    public class Members : Entity<int>
    {
        public int ArtistId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsPresent { get; set; }

        public virtual Artists Artist { get; set; }
    }
}
