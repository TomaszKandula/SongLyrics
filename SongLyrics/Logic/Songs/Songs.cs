using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SongLyrics.Database;
using SongLyrics.Controllers.Songs.Models;

namespace SongLyrics.Logic.Songs
{
    public class Songs : ISongs
    {
        private readonly MainDbContext FMainDbContext;

        public Songs(MainDbContext AMainDbContext)
        {
            FMainDbContext = AMainDbContext;
        }

        /// <summary>
        /// Return specific song (or songs) from given band's album.
        /// </summary>
        /// <param name="AAlbumId"></param>
        /// <returns></returns>
        public async Task<List<Song>> GetAlbumSongs(int? AAlbumId)
        {
            if (AAlbumId != null)
            {
                return await FMainDbContext.Songs
                    .AsNoTracking()
                    .Include(ASongs => ASongs.Album)
                    .Include(ASongs => ASongs.Artist)
                    .Where(ASongs => ASongs.AlbumId == AAlbumId)
                    .Select(ASongs => new Song
                    {
                        Id = ASongs.Id,
                        Name = ASongs.SongName,
                        AlbumName = ASongs.Album.AlbumName,
                        ArtistName = ASongs.Artist.ArtistName
                    })
                    .ToListAsync();
            }

            return await FMainDbContext.Songs
                .AsNoTracking()
                .Include(ASongs => ASongs.Album)
                .Include(ASongs => ASongs.Artist)
                .Select(ASongs => new Song
                {
                    Id = ASongs.Id,
                    Name = ASongs.SongName,
                    AlbumName = ASongs.Album.AlbumName,
                    ArtistName = ASongs.Artist.ArtistName
                })
                .ToListAsync();
        }

        /// <summary>
        /// Return given song from the entire collection.
        /// </summary>
        /// <param name="ASongId"></param>
        /// <returns></returns>
        public async Task<SingleSong> GetSong(int ASongId)
        {
            return await FMainDbContext.Songs
                .AsNoTracking()
                .Include(ASongs => ASongs.Album)
                .Include(ASongs => ASongs.Artist)
                .Where(ASongs => ASongs.Id == ASongId)
                .Select(ASongs => new SingleSong
                {
                    Name = ASongs.SongName,
                    Lyrics = ASongs.SongLyrics,
                    Url = ASongs.SongUrl,
                    AlbumName = ASongs.Album.AlbumName,
                    ArtistName = ASongs.Artist.ArtistName
                })
                .SingleOrDefaultAsync();
        }
    }
}
