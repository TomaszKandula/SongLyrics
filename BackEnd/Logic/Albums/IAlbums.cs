using System.Threading.Tasks;
using System.Collections.Generic;
using BackEnd.Controllers.Albums.Models;
using BackEnd.Models.Json;

namespace BackEnd.Logic.Albums
{

    public interface IAlbums
    {

        /// <summary>
        /// Return all albums/given album (by BandId) from the entire collection.
        /// </summary>
        /// <param name="BandId"></param>
        /// <returns></returns>
        Task<List<Album>> GetAlbums(int? BandId);

        /// <summary>
        /// Return specific album for given Album Id.
        /// </summary>
        /// <param name="AlbumId"></param>
        /// <returns></returns>
        Task<List<Album>> GetAlbum(int AlbumId);

    }

}
