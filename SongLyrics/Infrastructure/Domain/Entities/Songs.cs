namespace SongLyrics.Infrastructure.Domain.Entities
{
    public class Songs : Entity<int>
    {
        public int AlbumId { get; set; }

        public int ArtistId { get; set; }

        public string SongName { get; set; }

        public string SongUrl { get; set; }

        public string SongLyrics { get; set; }

        public virtual Albums Album { get; set; }

        public virtual Artists Artist { get; set; }
    }
}
