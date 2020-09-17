using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models.Json;
using BackEnd.Models.Database;

namespace BackEnd.Logic.Songs
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
        /// <param name="AlbumId"></param>
        /// <returns></returns>
        public async Task<List<Song>> GetAlbumSongs(int? AlbumId)
        {

            if (AlbumId != null)
            {

                return await FMainDbContext.Songs
                    .AsNoTracking()
                    .Include(R => R.Album)
                    .Include(R => R.Artist)
                    .Where(R => R.AlbumId == AlbumId)
                    .Select(R => new Song
                    {
                        Id        = R.Id,
                        Name      = R.SongName,
                        AlbumName = R.Album.AlbumName,
                        ArtistName  = R.Artist.ArtistName
                    })
                    .ToListAsync();

            }
            else
            {

                return await FMainDbContext.Songs
                    .AsNoTracking()
                    .Include(R => R.Album)
                    .Include(R => R.Artist)
                    .Select(R => new Song
                    {
                        Id        = R.Id,
                        Name      = R.SongName,
                        AlbumName = R.Album.AlbumName,
                        ArtistName  = R.Artist.ArtistName
                    })
                    .ToListAsync();

            }

        }

        /// <summary>
        /// Return given song from the entire collection.
        /// </summary>
        /// <param name="SongId"></param>
        /// <returns></returns>
        public async Task<SingleSong> GetSong(int SongId)
        {

            return await FMainDbContext.Songs
                .AsNoTracking()
                .Include(R => R.Album)
                .Include(R => R.Artist)
                .Where(R => R.Id == SongId)
                .Select(R => new SingleSong
                {
                    Name      = R.SongName,
                    Lyrics    = R.SongLyrics,
                    Url       = R.SongUrl,
                    AlbumName = R.Album.AlbumName,
                    ArtistName  = R.Artist.ArtistName
                })
                .SingleOrDefaultAsync();

        }

    }

}
