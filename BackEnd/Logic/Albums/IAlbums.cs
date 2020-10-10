using System.Threading.Tasks;
using System.Collections.Generic;
using BackEnd.Controllers.Albums.Models;

namespace BackEnd.Logic.Albums
{

    public interface IAlbums
    {

        /// <summary>
        /// Return all albums/given album (by BandId) from the entire collection.
        /// </summary>
        /// <param name="ABandId"></param>
        /// <returns></returns>
        Task<List<Album>> GetAlbums(int? ABandId);

        /// <summary>
        /// Return specific album for given Album Id.
        /// </summary>
        /// <param name="AAlbumId"></param>
        /// <returns></returns>
        Task<List<Album>> GetAlbum(int AAlbumId);

    }

}
