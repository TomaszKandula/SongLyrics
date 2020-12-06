namespace SongLyrics.Database.Models
{
    public class Members
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsPresent { get; set; }

        public virtual Artists Artist { get; set; }
    }
}
