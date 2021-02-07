using System.ComponentModel.DataAnnotations;

namespace SongLyrics.Infrastructure.Domain
{
    public class Entity<TKey>
    {
        [Key]
        public int Id { get; set; }
    }
}
