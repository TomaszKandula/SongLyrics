using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models.Json;
using BackEnd.Models.Database;

namespace BackEnd.Logic.Music
{

    public class Music : IMusic
    {

        private readonly MainDbContext FMainDbContext;

        public Music(MainDbContext AMainDbContext) 
        {
            FMainDbContext = AMainDbContext;
        }

        /// <summary>
        /// Return all albums/given album (by BandId) from the entire collection.
        /// </summary>
        /// <param name="BandId"></param>
        /// <returns></returns>
        public async Task<List<Album>> GetAlbums(int? BandId) 
        {

            if (BandId != null)
            {

                return await FMainDbContext.Albums
                    .AsNoTracking()
                    .Include(R => R.Band)
                    .Where(R => R.BandId == BandId)
                    .Select(R => new Album 
                    { 
                        Id        = R.Id,
                        AlbumName = R.AlbumName,
                        BandName  = R.Band.BandName
                    })
                    .ToListAsync();

            }
            else 
            {

                return await FMainDbContext.Albums
                    .AsNoTracking()
                    .Include(R => R.Band)
                    .Select(R => new Album
                    {
                        Id        = R.Id,
                        AlbumName = R.AlbumName,
                        BandName  = R.Band.BandName
                    })
                    .ToListAsync();

            }

        }

        /// <summary>
        /// Return specific album for given Band Id.
        /// </summary>
        /// <param name="AlbumId"></param>
        /// <returns></returns>
        public async Task<List<Album>> GetAlbum(int AlbumId) 
        { 

             return await FMainDbContext.Albums
                .AsNoTracking()
                .Include(R => R.Band)
                .Where(R => R.Id == AlbumId)
                .Select(R => new Album 
                { 
                    Id        = R.Id,
                    AlbumName = R.AlbumName,
                    BandName  = R.Band.BandName
                })
                .ToListAsync();

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
                    .Include(R => R.Band)
                    .Where(R => R.AlbumId == AlbumId)
                    .Select(R => new Song
                    {
                        Name      = R.SongName,
                        Lyrics    = R.SongLyrics,
                        Url       = R.SongUrl,
                        AlbumName = R.Album.AlbumName,
                        BandName  = R.Band.BandName
                    })
                    .ToListAsync();

            }
            else 
            {

                return await FMainDbContext.Songs
                    .AsNoTracking()
                    .Include(R => R.Album)
                    .Include(R => R.Band)
                    .Select(R => new Song
                    {
                        Name      = R.SongName,
                        Lyrics    = R.SongLyrics,
                        Url       = R.SongUrl,
                        AlbumName = R.Album.AlbumName,
                        BandName  = R.Band.BandName
                    })
                    .ToListAsync();

            }

        }

        /// <summary>
        /// Return given song from the entire collection.
        /// </summary>
        /// <param name="SongId"></param>
        /// <returns></returns>
        public async Task<List<Song>> GetSong(int SongId)
        {

            return await FMainDbContext.Songs
                .AsNoTracking()
                .Include(R => R.Album)
                .Include(R => R.Band)
                .Where(R => R.Id == SongId)
                .Select(R => new Song
                {
                    Name      = R.SongName,
                    Lyrics    = R.SongLyrics,
                    Url       = R.SongUrl,
                    AlbumName = R.Album.AlbumName,
                    BandName  = R.Band.BandName
                })
                .ToListAsync();

        }

    }

}
