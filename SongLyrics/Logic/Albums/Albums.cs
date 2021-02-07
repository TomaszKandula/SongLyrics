using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SongLyrics.Database;
using SongLyrics.Controllers.Albums.Models;

namespace SongLyrics.Logic.Albums
{
    public class Albums : IAlbums
    {
        private readonly MainDbContext FMainDbContext;

        public Albums(MainDbContext AMainDbContext)
        {
            FMainDbContext = AMainDbContext;
        }

        /// <summary>
        /// Return all albums/given album (by BandId) from the entire collection.
        /// </summary>
        /// <param name="ABandId"></param>
        /// <returns></returns>
        public async Task<List<Album>> GetAlbums(int? ABandId)
        {
            if (ABandId != null)
            {
                return await FMainDbContext.Albums
                    .AsNoTracking()
                    .Include(AAlbums => AAlbums.Artist)
                    .Where(AAlbums => AAlbums.ArtistId == ABandId)
                    .Select(AAlbums => new Album
                    {
                        Id = AAlbums.Id,
                        AlbumName = AAlbums.AlbumName,
                        Issued = AAlbums.Issued,
                        ArtistName = AAlbums.Artist.ArtistName
                    })
                    .ToListAsync();
            }

            return await FMainDbContext.Albums
                .AsNoTracking()
                .Include(AAlbums => AAlbums.Artist)
                .Select(AAlbums => new Album
                {
                    Id = AAlbums.Id,
                    AlbumName = AAlbums.AlbumName,
                    Issued = AAlbums.Issued,
                    ArtistName = AAlbums.Artist.ArtistName
                })
                .ToListAsync();
        }

        /// <summary>
        /// Return specific album for given Band Id.
        /// </summary>
        /// <param name="AAlbumId"></param>
        /// <returns></returns>
        public async Task<List<Album>> GetAlbum(int AAlbumId)
        {
            return await FMainDbContext.Albums
               .AsNoTracking()
               .Include(AAlbums => AAlbums.Artist)
               .Where(AAlbums => AAlbums.Id == AAlbumId)
               .Select(AAlbums => new Album
               {
                   Id = AAlbums.Id,
                   AlbumName = AAlbums.AlbumName,
                   Issued = AAlbums.Issued,
                   ArtistName = AAlbums.Artist.ArtistName
               })
               .ToListAsync();
        }
    }
}
