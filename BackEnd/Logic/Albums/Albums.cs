using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models.Database;
using BackEnd.Models.Json;

namespace BackEnd.Logic.Albums
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
        /// <param name="BandId"></param>
        /// <returns></returns>
        public async Task<List<Album>> GetAlbums(int? BandId)
        {

            if (BandId != null)
            {

                return await FMainDbContext.Albums
                    .AsNoTracking()
                    .Include(R => R.Artist)
                    .Where(R => R.ArtistId == BandId)
                    .Select(R => new Album
                    {
                        Id        = R.Id,
                        AlbumName = R.AlbumName,
                        Issued    = R.Issued,
                        BandName  = R.Artist.ArtistName
                    })
                    .ToListAsync();

            }
            else
            {

                return await FMainDbContext.Albums
                    .AsNoTracking()
                    .Include(R => R.Artist)
                    .Select(R => new Album
                    {
                        Id        = R.Id,
                        AlbumName = R.AlbumName,
                        Issued    = R.Issued,
                        BandName  = R.Artist.ArtistName
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
               .Include(R => R.Artist)
               .Where(R => R.Id == AlbumId)
               .Select(R => new Album
               {
                   Id        = R.Id,
                   AlbumName = R.AlbumName,
                   Issued    = R.Issued,
                   BandName  = R.Artist.ArtistName
               })
               .ToListAsync();

        }

    }

}
